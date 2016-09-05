using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Management.Commons;
using Management.Commons.SQL;
namespace Management.Products
{
    public partial class frmVendorReturnProduct : DevExpress.XtraEditors.XtraForm
    {

        public delegate void CapNhatDuLieu();
        public CapNhatDuLieu updateData;


        public event EventHandler Form_Closing;
        QryData clsSQL;
        QryParam param;
        int iOrder_ID, iImportOrder_ID, QtyWarehouse = 0,QtyPromotionWarehouse=0;
        string strTotalAmount = "", moneyPayment = "", strHaveAmount="";
        decimal PriceSell = 0;
        DataTable tbListProductOrder;
        DataTable tbListProductOrderNew;
        public frmVendorReturnProduct()
        {
            InitializeComponent();
        }
        int intProduct_ID = 0;

        public int GetSetImportOrder_ID
        {
            get { return iImportOrder_ID; }
            set { iImportOrder_ID = value; }
        }

        public string GetTotalAmount
        {
            get { return strTotalAmount; }
            set { strTotalAmount = value; }
        }
        public string getHaveAmount
        {
            get { return strHaveAmount; }
            set { strHaveAmount = value; }
        }
        public string GetTotalpayment
        {
            get { return moneyPayment; }
            set { moneyPayment = value; }
        }
        private void frmVendorReturnProduct_Load(object sender, EventArgs e)
        {
            try
            {

                clsSQL = new QryData(Program.config.ConnectionString);
                 cboProduct.EditValue = null;
                 if (this.GetSetImportOrder_ID == 0) return;
                 tbListProductOrder = new DataTable();
                 param = new QryParam();
                 param.Add("@ImportOrder_ID", SqlDbType.Int, this.GetSetImportOrder_ID);
                 tbListProductOrder = clsSQL.GetTableStore("spReturn_ListProductIOrder", param);
                 cboProduct.Properties.DataSource = tbListProductOrder;
                 cboProduct.Properties.DisplayMember = "ProductName";
                 //cboProduct.Properties.DisplayMember = "Product_ID";
                 cboProduct.Properties.ValueMember = "ImportOrderDetail_ID";
                 cboProduct.ItemIndex = 0;
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "TRA HANG");
            }
        }

        private void cboProduct_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                intProduct_ID = 0;
                if (cboProduct.EditValue == null)
                {
                    return;
                }
                else
                {
                    foreach (DataRow row in tbListProductOrder.Select("ImportOrderDetail_ID=" + cboProduct.EditValue.ToString()))
                    {
                        QtyWarehouse = Common.ParseInt(row["QtyWarehouse"].ToString());
                        QtyPromotionWarehouse = Common.ParseInt(row["QtyPromotionWarehouse"].ToString());
                        PriceSell = Common.ParseDecimal(row["PriceSell"].ToString());


                        intProduct_ID = Common.ParseInt(row["Product_ID"]);
                        txtDisCount.Text = row["Discount"].ToString();
                        txtPrice.Text = String.Format("{0:N0}", row["Price"]);
                        txtPromotionPercent.Text = row["PercentPromotion"].ToString();
                        txtQuantity.Text = String.Format("{0:N0}", QtyWarehouse);
                        txtQuantityPromotion.Text = String.Format("{0:N0}", 0);

                        decimal Percent = Common.ParseDecimal(row["PercentPromotion"].ToString()) + Common.ParseDecimal(row["Discount"].ToString());
                        decimal Amount = Common.ParseDecimal(row["Quantity"].ToString()) * Common.ParseDecimal(row["Price"].ToString());
                        if (Percent == 0 && Common.ParseInt(row["QuantityPromotion"].ToString()) == 0)
                        {
                            txtForm.Text = "Không";
                        }
                        else {
                            int icheck = 0;

                            if (Percent != 0 && Common.ParseInt(row["QuantityPromotion"].ToString()) != 0)
                            {
                                icheck = 1;
                                txtForm.Text = SettingCodeDB.TypePromotion_Product_Discount;
                            }
                            if (icheck == 0)
                            {
                                if (Percent != 0)
                                {
                                    txtForm.Text = SettingCodeDB.TypePromotion_Discount;
                                }
                                if (Common.ParseInt(row["QuantityPromotion"].ToString()) != 0)
                                {

                                    txtForm.Text = SettingCodeDB.TypePromotion_Product;
                                }
                            }
                           
                        }
                        if (Percent <= 0)
                        {
                            txtAmount.Text = String.Format("{0:N0}", Amount);
                        }
                        else {
                            //(odd.Quantity * odd.Price)-((odd.Quantity * odd.Price) * (odd.Discount )/100.00)
                            decimal clacAmount = Amount - ((Common.ParseDecimal(row["Quantity"].ToString()) * Common.ParseDecimal(row["Price"].ToString())) * (Percent)/100);
                            txtAmount.Text = String.Format("{0:N0}", clacAmount);
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "DOI HANG");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                bool CheckVal = true;
                if (txtQtyNeed.Value==0)
                {
                    Program.MessagerErr("Vui Lòng Nhập Số Lượng Cần Trả", "TRA HANG");
                    txtQtyNeed.Focus();
                    CheckVal = false;
                }
                if (Common.ParseDouble(txtQtyPromotionNeed.Text) > Common.ParseDouble(QtyPromotionWarehouse))
                {
                    Program.MessagerErr("Số Lượng Khuyến Mại Cần Trả Không Thể Lớn Hơn Số Lượng Có Trong Kho", "TRA HANG");
                    txtQtyPromotionNeed.Focus();
                    CheckVal = false;
                }
               
                if (CheckVal)
                {
                    if (XtraMessageBox.Show("Bạn Chắc Chắn Muốn Trả Sản Phẩm Này ???", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool CheckAction = true;
                        clsSQL = new QryData(Program.config.ConnectionString);
                        param = new QryParam();
                        clsSQL.BeginTrans();
                        //int Order_ID = this.GetSetOrder_ID;
                        int Order_ID = 0;
                        decimal Quantity = Common.ParseDecimal(txtQtyNeed.Text);
                        decimal QuantityPromotion = Common.ParseDecimal(txtQtyPromotionNeed.Text);
                        decimal PriceSale = Common.ParseDecimal(txtPrice.Text);
                        decimal Percent = Common.ParseDecimal(txtPromotionPercent.Text) + Common.ParseDecimal(txtDisCount.Text);
                        decimal AmountOnView = (Quantity * PriceSale) - ((Quantity * PriceSale) * (Percent) / 100); // so tien tra san pham

                        decimal TotalAmountIOrder = Common.ParseDecimal(this.GetTotalAmount); // Tong so tien trong hoa don
                        decimal HaveAmount = Common.ParseDecimal(this.getHaveAmount); // so tien da tra 
                        decimal Totalpayment = Common.ParseDecimal(this.GetTotalpayment); // so tien con no
                        decimal Payment = TotalAmountIOrder - AmountOnView;

                        #region Canh bao Nha cung cap phai thoi tien lai
                        if (HaveAmount > Payment)
                            {
                                if (XtraMessageBox.Show("Số Tiền Đã Trả Cho HĐ Hiện Tại Lớn Hơn Tổng Tiền Trong Hóa Đơn Này. \n Bạn Có Muốn Tiếp Tục Thực Hiện Không ?", "CHI TIET TRA SAN PHAM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    decimal ReturnMoney = HaveAmount - Payment;
                                    decimal Update_Payment = TotalAmountIOrder - AmountOnView;
                                    string strMoney = String.Format("{0:N0}", ReturnMoney);
                                    Program.MessagerErr("Bạn Được Trả Lại " + strMoney + " VNĐ", "TRA HANG");
                                   

                                    param.Clear();
                                    param.Add("@ImportOrder_ID", SqlDbType.Int, this.GetSetImportOrder_ID);
                                    param.Add("@Note", SqlDbType.NVarChar, "Do Trả Hàng Quá Nhiều Cập Nhật Lại Chỉ Còn 1 Dòng");
                                    param.Add("@PaymentAmount", SqlDbType.Decimal, Update_Payment);
                                    clsSQL.ExecStore("spPaymentInputDelete_Insert", param);

                                }
                                else
                                {
                                    CheckAction = false;
                                }
                            }
                            else {
                                CheckAction = true;
                            }
                        #endregion
                        if (CheckAction)
                        {
                            int ImportOrderDetail_ID = Common.ParseInt(cboProduct.EditValue.ToString());
                            param.Clear();
                            param.Add("@ImportOrderDetail_ID", SqlDbType.Int, ImportOrderDetail_ID);
                            param.Add("@Product_ID", SqlDbType.Int, intProduct_ID);
                            param.Add("@Quantity", SqlDbType.Int, Common.ParseInt(Quantity));
                            param.Add("@QuantityPromotion", SqlDbType.Int, Common.ParseInt(QuantityPromotion));
                            param.Add("@Price_Sell", SqlDbType.Decimal, PriceSell);
                            clsSQL.ExecStore("spReturnProductVendor", param);
                            clsSQL.CommitTrans();
                            Program.MessagerInfo("Trả Hàng Thành Công!!!", "TRA HANG");
                            updateData();
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "TRA HANG");
            }
        }

        private void txtQtyNeed_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtQtyNeed_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cboProduct.EditValue == null) return;
                if (txtQtyNeed.Value < 0)
                {
                    Program.MessagerErr("Số Lượng Cần Trả Phải > 0.", "TRA HANG");
                    txtQtyNeed.Focus();

                }
                else
                {
                    if (Common.ParseDouble(txtQtyNeed.Value) > QtyWarehouse)
                    {
                        Program.MessagerErr("Số Lượng Cần Đổi Không Được Lớn Hơn Số Lượng Trong Kho", "DOI HANG");
                        txtQtyNeed.Focus();
                    }
                    else
                    {
                        if (txtForm.Text == SettingCodeDB.TypePromotion_Product)
                        {
                           // txtQtyPromotionNeed.Text = Math.Floor(Common.ParseDouble(Common.ParseInt(txtQtyNeed.Value) * Common.ParseInt(txtPromotionPercent.Text) / 100)).ToString();
                        }
                       
                    }
                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "TRA HANG");
            }
        }

        private void txtQtyPromotionNeed_Leave(object sender, EventArgs e)
        {
            try
            {
                   
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "DOI HANG");
            }
        }
    }
}