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
    public partial class frmReturnProduct : DevExpress.XtraEditors.XtraForm
    {

        #region Delegate load lai data trong uct
        public delegate void CapNhatDuLieu();
        public CapNhatDuLieu updateData;
        #endregion
        public event EventHandler Form_Closing;
        QryData clsSQL;
        QryParam param;
        int iOrder_ID;
        Decimal strTotalAmount = 0;
        Decimal strPriceActual = 0;

        DataTable tbListProductOrder;
        DataTable tbListProductOrderNew;
        public frmReturnProduct()
        {
            InitializeComponent();
        }
        int intProduct_ID = 0;
        public int GetSetOrder_ID
        {
            get { return iOrder_ID; }
            set { iOrder_ID = value; }
        }
        public Decimal  GetTotalAmount
        {
            get { return strTotalAmount; }
            set { strTotalAmount = value; }
        }

        public Decimal PriceActual
        {
            get { return strPriceActual; }
            set { strPriceActual = value; }
        }
        private void frmReturnProduct_Load(object sender, EventArgs e)
        {
            try
            {

                clsSQL = new QryData(Program.config.ConnectionString);
                 cboProduct.EditValue = null;
                 if (this.GetSetOrder_ID == 0) return;
                 tbListProductOrder = new DataTable();
                 param = new QryParam();
                 param.Add("@Order_ID", SqlDbType.Int, this.GetSetOrder_ID);
                 tbListProductOrder = clsSQL.GetTableStore("spChangePro_ListProductOrder", param);
                 cboProduct.Properties.DataSource = tbListProductOrder;
                 cboProduct.Properties.DisplayMember = "ProductName";
                 //cboProduct.Properties.DisplayMember = "Product_ID";
                 cboProduct.Properties.ValueMember = "OrderDetail_ID";
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
                    foreach (DataRow row in tbListProductOrder.Select("OrderDetail_ID=" + cboProduct.EditValue.ToString()))
                    {
                        intProduct_ID = Common.ParseInt(row["Product_ID"]);
                        txtAmount.Text = String.Format("{0:N0}", row["Amount"]);
                        txtDisCount.Text = row["Discount"].ToString();
                        txtForm.Text = row["Form"].ToString();
                        txtPrice.Text = String.Format("{0:N0}", row["Price"]);
                        txtPromotionPercent.Text = row["PercentPromotion"].ToString();
                        txtQuantity.Text = String.Format("{0:N0}", row["Quantity"]);
                        txtQuantityPromotion.Text = String.Format("{0:N0}", row["QuantityPromotion"]);
                        PriceActual = Common.ParseDecimal(row["Price_Import"]);
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
                if (Common.ParseDouble(txtQtyPromotionNeed.Text) > Common.ParseDouble(txtQuantityPromotion.Text))
                {
                    Program.MessagerErr("Số Lượng Khuyến Mại Cần Trả Không Thể Lớn Hơn Số Lượng KM Trong HĐ", "DOI HANG");
                    txtQtyPromotionNeed.Focus();
                    CheckVal = false;
                }
               
                if (CheckVal)
                {
                    if (XtraMessageBox.Show("Bạn Chắc Chắn Muốn Trả Sản Phẩm Này ???", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool CheckAction = false;
                        clsSQL = new QryData(Program.config.ConnectionString);
                        param = new QryParam();
                        clsSQL.BeginTrans();
                        int Order_ID = this.GetSetOrder_ID;
                        decimal Quantity = Common.ParseDecimal(txtQtyNeed.Text);
                        decimal QuantityPromotion = Common.ParseDecimal(txtQtyPromotionNeed.Text);
                        decimal PriceSale = Common.ParseDecimal(txtPrice.Text);
                        string strQry = "select Price_Import from tbl_OrderDetails where Product_ID = " + intProduct_ID + " and Order_ID =" + Order_ID + " and Price =" + PriceSale + " and Price_Import =" + PriceActual;
                        DataTable CheckPrice = clsSQL.GetTableSQL(strQry);
                        decimal Price_Import = Common.ParseDecimal(CheckPrice.Rows[0][0]);

                        #region tinh lai tien da tra trong hoa don
                        decimal Percent = Common.ParseDecimal(txtPromotionPercent.Text) + Common.ParseDecimal(txtDisCount.Text);
                        decimal TotalAmountOnView = (Quantity * PriceSale) - ((Quantity * PriceSale) * (Percent) / 100);
                        string strQryAmount = "select SUM(PaymentAmount) from tbl_PaymentOrders where Order_ID =" + Order_ID;
                        DataTable CheckAmount = clsSQL.GetTableSQL(strQryAmount);
                        decimal sumAmount = Common.ParseDecimal(CheckAmount.Rows[0][0]);
                        if (sumAmount != 0)
                        {
                            decimal oldPayment = Common.ParseDecimal(GetTotalAmount) - TotalAmountOnView;
                            decimal newPayment = sumAmount;// lay trong DB 
                            if (newPayment > oldPayment)
                            {
                                CheckAction = false;
                                Program.MessagerErr("Số tiền trả hàng > số tiền khách hàng còn nợ trong hóa đơn. \n Bạn không thể tiếp tục", "TRA HANG");
                                // do khong lam chuc nang nay nua.
                                // Neu vao day thi ko cho tra SP
                                //if (XtraMessageBox.Show("Số tiền trả hàng > số tiền khách hàng còn nợ trong hóa đơn. \n Bạn không thể tiếp tục ?", "CHI TIET TRA SAN PHAM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                //{
                                //    //CheckAction = true;
                                //    //param = new QryParam();
                                //    //param.Add("@Order_ID", SqlDbType.Int, this.GetSetOrder_ID);
                                //    //clsSQL.ExecStore("spPaymentOrder_Del", param);

                                //    //string Note = "Do Trả Sản Phẩm Nhiều Quá Nên Tính Lại Số Tiền Trong Hóa Đon";
                                //    //param = new QryParam();
                                //    //param.Add("@Order_ID", SqlDbType.Int, this.GetSetOrder_ID);
                                //    //param.Add("@OrderDate", SqlDbType.DateTime, Convert.ToDateTime(DateTime.Now));
                                //    //param.Add("@Amount", SqlDbType.Decimal, oldPayment);
                                //    //param.Add("@Note", SqlDbType.NVarChar, Note);
                                //    //param.Add("@CheckInsertSalaries", SqlDbType.Int, 0);
                                //    //clsSQL.ExecStore("spPaymentOrder_Ins", param);
                                //    CheckAction = false;
                                //}
                                //else
                                //{
                                //    CheckAction = false;
                                //}
                            }
                            else {
                                CheckAction = true;
                            }

                        }
                        else {
                            CheckAction = true;
                        }


                        #endregion
                        if (CheckAction)
                        {
                            int OrderDetail_ID = Common.ParseInt(cboProduct.EditValue.ToString());
                            param = new QryParam();
                            param.Add("@OrderDetail_ID", SqlDbType.Int, OrderDetail_ID);
                            param.Add("@Order_ID", SqlDbType.Int, Order_ID);
                            param.Add("@Product_ID", SqlDbType.Int, intProduct_ID);
                            param.Add("@Quantity", SqlDbType.Int, Quantity);
                            param.Add("@QuantityPromotion", SqlDbType.Int, QuantityPromotion);
                            param.Add("@Price_Import", SqlDbType.Decimal, Price_Import);
                            param.Add("@Price_Sale", SqlDbType.Decimal, PriceSale);
                            clsSQL.ExecStore("spReturnProduct", param);
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
                    Program.MessagerErr("Số lượng cần đổi phải lớn hơn 0.", "DOI HANG");
                    txtQtyNeed.Focus();

                }
                else
                {
                    if (Common.ParseDouble(txtQtyNeed.Value) > Common.ParseDouble(txtQuantity.Text))
                    {
                        Program.MessagerErr("Số lượng cần đổi phải nhỏ hơn số lượng mà khách hàng mua.", "DOI HANG");
                        txtQtyNeed.Focus();
                    }
                    else
                    {
                        if (txtForm.Text == SettingCodeDB.TypePromotion_Product)
                        {
                            txtQtyPromotionNeed.Text = Math.Floor(Common.ParseDouble(Common.ParseInt(txtQtyNeed.Value) * Common.ParseInt(txtPromotionPercent.Text) / 100)).ToString();
                        }
                       
                    }
                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "DOI HANG");
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