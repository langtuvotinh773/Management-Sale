using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Management.Commons.SQL;
using Management.Commons;
namespace Management.Products
{
    public partial class frmChangeProduct : DevExpress.XtraEditors.XtraForm
    {
        #region Delegate load lai data trong uct
        public delegate void CapNhatDuLieu();
        public CapNhatDuLieu updateData;
        #endregion
        public event EventHandler Form_Closing;
        QryData clsSQL;
        QryParam param;
        int iOrder_ID;
        string strTotalAmount;
        DataTable tbListProductOrder;
        DataTable tbListProductOrderNew;

        public int GetSetOrder_ID
        {
            get { return iOrder_ID; }
            set { iOrder_ID = value; }
        }
        public string GetTotalAmount
        {
            get { return strTotalAmount; }
            set { strTotalAmount = value; }
        }
        decimal gPriceImport;
        public decimal  getSetPriceImport
        {
            get { return gPriceImport; }
            set { gPriceImport = value; }
        }

        public frmChangeProduct()
        {
            InitializeComponent();
            clsSQL = new QryData(Program.config.ConnectionString);
        }

        private void frmChangeProduct_Load(object sender, EventArgs e)
        {
            try
            {
                var dict = new Dictionary<int, string>();
                dict.Add(1, SettingCodeDB.TypePromotion_No);
                dict.Add(2, SettingCodeDB.TypePromotion_Discount);
                dict.Add(3, SettingCodeDB.TypePromotion_Product);
                dict.Add(4, SettingCodeDB.TypePromotion_Product_Discount);

            
                SetValueComboboxTypePromotion();
                //lookUpEdit1.Properties.DataSource = new BindingSource(dict, null);
                //lookUpEdit1.Properties.DisplayMember = "Value";
                //lookUpEdit1.Properties.ValueMember = "Key";
                //lookUpEdit1.ItemIndex = 0;


                cboProduct.EditValue = null;
                cboCompany.EditValue = null;
                if (this.GetSetOrder_ID == 0) return;
                tbListProductOrder = new DataTable();
                param = new QryParam();
                param.Add("@Order_ID", SqlDbType.Int, this.GetSetOrder_ID);
                tbListProductOrder = clsSQL.GetTableStore("spChangePro_ListProductOrder", param);
                cboProduct.Properties.DataSource = tbListProductOrder;
                cboProduct.Properties.DisplayMember = "ProductName";
                cboProduct.Properties.ValueMember = "OrderDetail_ID";
                cboProduct.ItemIndex = 0;
                //
                string sQueryCompany = "Select Company_ID, CompanyName, Address From tbl_Companies Order by CompanyName";
                cboCompany.Properties.DataSource = clsSQL.GetTableSQL(sQueryCompany);
                cboCompany.Properties.DisplayMember = "CompanyName";
                cboCompany.Properties.ValueMember = "Company_ID";
                cboCompany.ItemIndex = 0;

                txtQtyNeed.Text = "0";
                txtQtyPromotionNeed.Text = "0";
                txtQuantityNew.Text = "0";
                txtQtyPromotionNew.Text = "0";
                txtQtyNeed.Focus();

            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "DOI HANG");
            }
        }

        private void cboProduct_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboProduct.EditValue == null)
                {
                    return;
                }
                else
                {
                    foreach (DataRow row in tbListProductOrder.Select("OrderDetail_ID=" + cboProduct.EditValue.ToString()))
                    {
                        txtAmount.Text = row["Amount"].ToString();
                        txtDisCount.Text = row["Discount"].ToString();
                       // txtForm.Text = row["Form"].ToString();
                        txtPrice.Text = row["Price"].ToString();
                        txtPromotionPercent.Text = row["PercentPromotion"].ToString();
                        txtQuantity.Text = row["Quantity"].ToString();
                        txtQuantityPromotion.Text = row["QuantityPromotion"].ToString();
                        txtQtyPromotionNeed.Text = row["QuantityPromotion"].ToString();
                        getSetPriceImport = Common.ParseDecimal(row["Price_Import"]);
                    }
                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "DOI HANG");
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
                    if (Convert.ToDouble(txtQtyNeed.Value) > Convert.ToDouble(txtQuantity.Text))
                    {
                        Program.MessagerErr("Số lượng cần đổi phải nhỏ hơn số lượng mà khách hàng mua.", "DOI HANG");
                        txtQtyNeed.Focus();
                    }
                    else
                    {
                        if (txtForm.Text == SettingCodeDB.TypePromotion_Product)
                        {
                            txtQtyPromotionNeed.Text = Math.Floor(Convert.ToDouble(Convert.ToInt32(txtQtyNeed.Value) * Convert.ToInt32(txtPromotionPercent.Text) / 100)).ToString();
                        }
                        cboPrice_EditValueChanged(null, null);
                    }
                }
                SetValueComboboxTypePromotion();
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "DOI HANG");
            }
        }

        private void cboCompany_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboCompany.EditValue == null) return;

                //cboProcutNew.EditValue = null;
                string sQryProductNew = "SElect pr.Product_ID, pr.ProductName,pr_price.PriceActual_Import as Price_Import,pr_price.Price ,  pr.Discount, pr.[Weight], (convert(varchar,pr.Product_ID)+'_'+convert(varchar,convert(decimal,pr_price.Price)) +'_'+convert(varchar,convert(decimal,pr_price.PriceActual_Import))) as strDetial_Selected From tbl_Products pr,tbl_ProductPrices pr_price Where pr.Company_Id=@Company_ID and pr.Product_ID = pr_price.Product_ID and pr_price.Quantity >0";
                param = new QryParam();
                param.Add("@Company_ID", SqlDbType.Int, Convert.ToInt32(cboCompany.EditValue));
                cboProcutNew.Properties.DataSource = clsSQL.GetTableSQL(sQryProductNew, param);
                cboProcutNew.Properties.DisplayMember = "ProductName";
                cboProcutNew.Properties.ValueMember = "strDetial_Selected";
                cboProcutNew.ItemIndex = 0;
                SetValueComboboxTypePromotion();
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "DOI HANG");
            }
        }

        private void cboProcutNew_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraEditors.LookUpEdit editor = (sender as DevExpress.XtraEditors.LookUpEdit);
                DataRowView row = editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue) as DataRowView;
                string strDetail = Common.ParseString(row["strDetial_Selected"]);
                int ProductID = Common.ParseInt(strDetail.Split('_')[0]);
                decimal Price_Import  = Common.ParseDecimal(row["Price_Import"]);
                decimal Price = Common.ParseDecimal(row["Price"]);

                //string strGetQtyRemainder = "SElect ProductPrice_ID, Product_ID, PriceActual_Import as Price_Import,Price , Quantity, QuantityPromotion, (convert(varchar,Product_ID)+'_'+convert(varchar,convert(decimal,Price)) +'_'+convert(varchar,convert(decimal,PriceActual_Import))) as strDetial_Selected From tbl_ProductPrices where Product_ID=" + ProductID + " And Quantity>0 and Price = " + Price + " And PriceActual_Import = " + Price_Import ;
                //DataTable tbTempGetPrice = new DataTable();
                //tbTempGetPrice = clsSQL.GetTableSQL(strGetQtyRemainder);


                if (cboProcutNew.EditValue == null) return;
                cboPrice.EditValue = null;
                string sQryPriceNew = "SElect ProductPrice_ID, Product_ID, PriceActual_Import as Price_Import,Price , Quantity, QuantityPromotion, (convert(varchar,Product_ID)+'_'+convert(varchar,convert(decimal,Price)) +'_'+convert(varchar,convert(decimal,PriceActual_Import))) as strDetial_Selected From tbl_ProductPrices where Product_ID=" + "@ProductID" + " And Quantity>0 and Price = " + "@Price" + " And PriceActual_Import = " + "@Price_Import";
                param = new QryParam();
                param.Add("@ProductID", SqlDbType.Int, ProductID);
                param.Add("@Price_Import", SqlDbType.Decimal, Price_Import);
                param.Add("@Price", SqlDbType.Decimal, Price);

                cboPrice.Properties.DataSource = clsSQL.GetTableSQL(sQryPriceNew, param);
                cboPrice.Properties.DisplayMember = "Price";
                cboPrice.Properties.ValueMember = "ProductPrice_ID";
                cboPrice.ItemIndex = 0;
                SetValueComboboxTypePromotion();
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "DOI HANG");
            }
        }
       
        private void cboPrice_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                //if (sender == null && e == null)
                //{
                //    return;
                //}
                if (cboPrice.EditValue == null)
                {
                    txtDiscountNew.Value = 0;
                    txtPercentPromotionNEw.Text = "0";
                    txtQuantityNew.Text = "0";
                    txtQtyPromotionNew.Text = "0";
                }
                else
                {
                    int ProductID = 0;
                    if (sender == null && e == null)
                    {
                        
                    }else {
                        DevExpress.XtraEditors.LookUpEdit editor = (sender as DevExpress.XtraEditors.LookUpEdit);
                        DataRowView row = editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue) as DataRowView;
                        string strDetail = Common.ParseString(row["strDetial_Selected"]);
                        ProductID = Common.ParseInt(strDetail.Split('_')[0]);

                        tbListProductOrderNew = new DataTable();
                        param = new QryParam();
                        param.Add("@Product_ID", SqlDbType.Int, ProductID);
                        param.Add("@ProductPrice_ID", SqlDbType.Int, Convert.ToInt32(cboPrice.EditValue));
                        tbListProductOrderNew = clsSQL.GetTableStore("spChangeProduct_ListProductNew", param);
                        txtDiscountNew.Value = Convert.ToDecimal(tbListProductOrderNew.Rows[0]["Discount"]);
                        txtPercentPromotionNEw.Text = tbListProductOrderNew.Rows[0]["PercentPromotion"].ToString();
                        txtPercentDonation.Text = tbListProductOrderNew.Rows[0]["PercentDonation"].ToString();
                        comboboxTypePromotion.Text = tbListProductOrderNew.Rows[0]["Form"].ToString();
                    }
                    // tính ra so tien
                    decimal dAmountOld;
                    int iQtyOld = Convert.ToInt32(txtQtyNeed.Value);
                    int dPriceOld = Convert.ToInt32(txtPrice.Text);
                    int iDiscountOld = Convert.ToInt32(txtDisCount.Text);
                    int iPerPromotionOld = Convert.ToInt32(txtPromotionPercent.Text);
                    int iPriceNew = Convert.ToInt32(cboPrice.GetColumnValue("Price"));
                    int iDiscountNew = Convert.ToInt32(txtDiscountNew.Value);
                    int iPerPromotionNew = Convert.ToInt32(txtPercentPromotionNEw.Text);
                    int iPriceNewWhenDiscount;
                    if (txtForm.Text == SettingCodeDB.TypePromotion_Discount || txtForm.Text == SettingCodeDB.TypePromotion_Product_Discount)
                    {

                        dAmountOld = Convert.ToDecimal(iQtyOld * dPriceOld - ((iQtyOld * dPriceOld) * (iDiscountOld + iPerPromotionOld) / 100.0));

                    }
                    else if (txtForm.Text == SettingCodeDB.TypePromotion_Product)
                    {
                        //(odd.Quantity * odd.Price)-((odd.Quantity * odd.Price) * (odd.Discount )/100.00)
                        dAmountOld = Convert.ToDecimal(iQtyOld * dPriceOld - ((iQtyOld * dPriceOld) * (iDiscountOld) / 100.0));
                    }
                    else
                    {
                        dAmountOld = Convert.ToDecimal(iQtyOld * dPriceOld - ((iQtyOld * dPriceOld) * (iDiscountOld) / 100.0));
                    }
                    // tinh ra so luong
                    if (comboboxTypePromotion.Text == SettingCodeDB.TypePromotion_Discount || txtForm.Text == SettingCodeDB.TypePromotion_Product_Discount)
                    {
                        iPriceNewWhenDiscount = (iPriceNew / 100) * (100 - (iDiscountNew + iPerPromotionNew));
                        txtQuantityNew.Text = Math.Floor(dAmountOld / Convert.ToDecimal(iPriceNewWhenDiscount)).ToString();
                    }
                    else if (comboboxTypePromotion.Text == SettingCodeDB.TypePromotion_Product)
                    {
                        iPriceNewWhenDiscount = (iPriceNew / 100) * (100 - (iDiscountNew));
                        txtQuantityNew.Text = Math.Floor(dAmountOld / Convert.ToDecimal(iPriceNewWhenDiscount)).ToString();
                        txtQtyPromotionNew.Text = Math.Floor(Convert.ToDecimal(Convert.ToInt32(txtQuantityNew.Text) * (1 + Convert.ToInt32(txtPercentDonation.Text) / 100))).ToString();
                    }
                    else
                    {
                        iPriceNewWhenDiscount = (iPriceNew / 100) * (100 - (iDiscountNew));
                        txtQuantityNew.Text = Math.Floor(dAmountOld / Convert.ToDecimal(iPriceNewWhenDiscount)).ToString();
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

        private void txtDiscountNew_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtDiscountNew.Value < 0)
                {
                    Program.MessagerErr("% Chiết khấu phải lớn hơn hoặc bằng 0", "DOI HANG");
                    txtDiscountNew.Focus();
                }
                else if (txtDiscountNew.Value >= 100)
                {
                    Program.MessagerErr("% Chiết khấu phải nhỏ hơn 100", "DOI HANG");
                    txtDiscountNew.Focus();
                }
                else
                {
                    // tính ra so tien
                    decimal dAmountOld;
                    int iQtyOld = Convert.ToInt32(txtQtyNeed.Value);
                    int dPriceOld = Convert.ToInt32(txtPrice.Text);
                    int iDiscountOld = Convert.ToInt32(txtDisCount.Text);
                    int iPerPromotionOld = Convert.ToInt32(txtPromotionPercent.Text);
                    int iPriceNew = Convert.ToInt32(cboPrice.GetColumnValue("Price"));
                    int iDiscountNew = Convert.ToInt32(txtDiscountNew.Value);
                    int iPerPromotionNew = Convert.ToInt32(txtPercentPromotionNEw.Text);
                    int iPriceNewWhenDiscount;
                    if (comboboxTypePromotion.Text == SettingCodeDB.TypePromotion_Discount)
                    {

                        dAmountOld = Convert.ToDecimal(iQtyOld * dPriceOld - ((iQtyOld * dPriceOld) * (iDiscountOld + iPerPromotionOld) / 100.0));

                    }
                    else if (comboboxTypePromotion.Text == SettingCodeDB.TypePromotion_Product)
                    {
                        //(odd.Quantity * odd.Price)-((odd.Quantity * odd.Price) * (odd.Discount )/100.00)
                        dAmountOld = Convert.ToDecimal(iQtyOld * dPriceOld - ((iQtyOld * dPriceOld) * (iDiscountOld) / 100.0));
                    }
                    else
                    {
                        dAmountOld = Convert.ToDecimal(iQtyOld * dPriceOld - ((iQtyOld * dPriceOld) * (iDiscountOld) / 100.0));
                    }
                    // tinh ra so luong
                    if (comboboxTypePromotion.Text == SettingCodeDB.TypePromotion_Discount)
                    {
                        iPriceNewWhenDiscount = (iPriceNew / 100) * (100 - (iDiscountNew + iPerPromotionNew));
                        txtQuantityNew.Text = Math.Floor(dAmountOld / Convert.ToDecimal(iPriceNewWhenDiscount)).ToString();
                    }
                    else if (comboboxTypePromotion.Text == SettingCodeDB.TypePromotion_Product)
                    {
                        iPriceNewWhenDiscount = (iPriceNew / 100) * (100 - (iDiscountNew));
                        txtQuantityNew.Text = Math.Floor(dAmountOld / Convert.ToDecimal(iPriceNewWhenDiscount)).ToString();
                        txtQtyPromotionNew.Text = Math.Floor(Convert.ToDecimal(Convert.ToInt32(txtQuantityNew.Text) * (1 + Convert.ToInt32(txtPercentPromotionNEw) / 100))).ToString();
                    }
                    else
                    {
                        iPriceNewWhenDiscount = (iPriceNew / 100) * (100 - (iDiscountNew));
                        txtQuantityNew.Text = Math.Floor(dAmountOld / Convert.ToDecimal(iPriceNewWhenDiscount)).ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "DOI HANG");
            }
        }

        private void btnChangePro_Click(object sender, EventArgs e)
        {
            try
            {
                
                bool CheckAction = true;
                string sErr = "";
                if (txtQtyNeed.Value <= 0 || Common.IsNullOrEmpty(txtQtyNeed.Value))
                {
                    sErr = sErr + Environment.NewLine + "Vui Lòng Nhập Số Lượng Cần Đổi";
                    CheckAction = false;
                }
                if (Common.ParseInt(txtQuantityNew.Text) <= 0 || Common.IsNullOrEmpty(txtQtyNeed.Value))
                {
                    sErr = sErr + Environment.NewLine + "Vui Lòng Nhập Số Lượng Cần Đổi Sang";
                    CheckAction = false;
                }
                if (comboboxTypePromotion.Text == SettingCodeDB.TypePromotion_Discount)
                {
                    if (Common.ParseInt(txtDiscountNew.Text) <= 0)
                    {
                        sErr = sErr + Environment.NewLine + "Vui Lòng Nhập Lại % Chiết Khấu.";
                        CheckAction = false;
                    }
                }
                if (comboboxTypePromotion.Text == SettingCodeDB.TypePromotion_Product)
                {
                    if (Common.ParseInt(txtQtyPromotionNew.Text) <= 0)
                    {
                        sErr = sErr + Environment.NewLine + "Vui Lòng Nhập Lại Số Lượng Khuyến Mãi.";
                        CheckAction = false;
                    }
                }
                if (comboboxTypePromotion.Text == SettingCodeDB.TypePromotion_Product_Discount)
                {
                    if (Common.ParseInt(txtDiscountNew.Text) <= 0)
                    {
                        sErr = sErr + Environment.NewLine + "Vui Lòng Nhập Lại % Chiết Khấu.";
                        CheckAction = false;
                    }
                    if (Common.ParseInt(txtQtyPromotionNew.Text) <= 0)
                    {
                        sErr = sErr + Environment.NewLine + "Vui Lòng Nhập Lại Số Lượng Khuyến Mãi.";
                        CheckAction = false;
                    }
                }
                
                int intPromotionPercent = Convert.ToInt32(txtPromotionPercent.Text);
                int intDisCount = Convert.ToInt32(txtDisCount.Text);
                decimal intPrice = Convert.ToDecimal(txtPrice.Text);
                decimal intQtyNeed = Convert.ToDecimal(txtQtyNeed.Value);

                int intPercentPromotionNEw = Convert.ToInt32(txtPercentPromotionNEw.Text);
                int intDiscountNew = Convert.ToInt32(txtDiscountNew.Text);
                decimal intQuantityNew = Convert.ToDecimal(txtQuantityNew.Text);
                decimal intPriceNew = Convert.ToDecimal(cboPrice.GetColumnValue("Price"));

                int sumDisCountOld = intPromotionPercent + intDisCount;
                int sumDisCountNew = intPercentPromotionNEw + intDiscountNew;
                decimal TotalOld = (intQtyNeed * intPrice) - ((intQtyNeed * intPrice) * (sumDisCountOld) / 100); ;
                decimal TotalNew = intQuantityNew * intPriceNew;

                decimal ShowToalOld = 0;
                decimal ShowToalNew = 0;


                int iDelete_Salary = 0;
                if (CheckAction)
                {
                    #region Check Validation Tien da tra nhieu hon trong hoa don
                    decimal Percent = sumDisCountNew;
                    decimal TotalAmountOnView = (intQuantityNew * intPriceNew) - ((intQuantityNew * intPriceNew) * (Percent) / 100);
                    string strQryAmount = "select SUM(PaymentAmount) from tbl_PaymentOrders where Order_ID =" + this.GetSetOrder_ID;
                    DataTable CheckAmount = clsSQL.GetTableSQL(strQryAmount);
                    decimal sumAmount = Common.ParseDecimal(CheckAmount.Rows[0][0]);
                    decimal oldPayment = Common.ParseDecimal(this.GetTotalAmount) - (TotalOld - TotalNew);
                    decimal newPayment = sumAmount;// lay trong DB 

                    if (sumAmount != 0)
                    {
                        
                        if (newPayment > oldPayment)
                        {
                            if (XtraMessageBox.Show("Số Tiền Đã Trả Cho HĐ Hiện Tại Lớn Hơn Tổng Tiền Trong Hóa Đơn Này. \n Bạn Có Muốn Tiếp Tục Thực Hiện Không ?", "CHI TIET DOI SAN PHAM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                #region check coi có cập nhật lại totalSalary hay ko ?
                                //int CheckInsertSalaries = 0;
                                //DataTable dt_TotalAmountOrder = new DataTable();
                                //DataTable dt_TotalAmountPaymentOrders = new DataTable();
                                //string Sql_TotalAmountOrder = "select Sum(Quantity * Price) from tbl_OrderDetails  where Order_ID =" + this.GetSetOrder_ID;
                                //string Sql_TotalAmountPaymentOrders = "select SUM(PaymentAmount) from tbl_PaymentOrders where Order_ID =" + this.GetSetOrder_ID;
                                //dt_TotalAmountOrder = clsSQL.GetTableSQL(Sql_TotalAmountOrder);
                                //dt_TotalAmountPaymentOrders = clsSQL.GetTableSQL(Sql_TotalAmountPaymentOrders);
                                //decimal dc_TotalAmountOrder = 0;
                                //decimal dc_TotalAmountPaymentOrders = 0;
                                //if (!Common.IsNullOrEmpty(dt_TotalAmountOrder.Rows[0][0].ToString()))
                                //{
                                //    dc_TotalAmountOrder = Common.ParseDecimal(dt_TotalAmountOrder.Rows[0][0].ToString());
                                //}
                                //if (!Common.IsNullOrEmpty(dt_TotalAmountPaymentOrders.Rows[0][0].ToString()))
                                //{
                                //    dc_TotalAmountPaymentOrders = Common.ParseDecimal(dt_TotalAmountPaymentOrders.Rows[0][0].ToString());
                                //}
                                //if (dc_TotalAmountOrder != dc_TotalAmountPaymentOrders)
                                //{
                                //    CheckInsertSalaries = 1;
                                //}
                                #endregion
                                iDelete_Salary = 1;
                            }
                            else { CheckAction = false; }
                        }
                    }

                    #endregion
                    if (sumDisCountOld != 0)
                    {
                        ShowToalOld = TotalOld - ((TotalOld * sumDisCountOld) / 100);
                    }
                    else
                    {
                        ShowToalOld = TotalOld;
                    }
                    if (sumDisCountNew != 0)
                    {
                        //(intQuantityNew * intPriceNew) - ((intQuantityNew * intPriceNew) * (Percent) / 100);
                        ShowToalNew = TotalNew - (TotalNew * sumDisCountNew) / 100;
                    }
                    else
                    {
                        ShowToalNew = TotalNew;
                    }

                    //////////////////////////////////////
                    if (CheckAction)
                    {
                        decimal AddMoney = 0;
                        int CheckRun = 0;
                        int CheckInsert = 0;
                        if (ShowToalNew > ShowToalOld)
                        {
                            AddMoney = ShowToalNew - ShowToalOld;
                            CheckRun = 1;
                            string strReturnMoney = String.Format("{0:N0}", Common.ParseDecimal(AddMoney));
                            if (XtraMessageBox.Show("Khách hàng phải trả thêm số tiền là : " + strReturnMoney, "Cảnh Báo Đổi Sản Phẩm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                CheckInsert = 1;
                            }
                            else { CheckInsert = 2; }
                        }
                        if (CheckInsert != 2)
                        {
                            #region Add
                            if (txtQtyNeed.Value == 0)
                            {
                                Program.MessagerErr("Vui lòng nhập số lượng cần đổi", "DOI HANG");
                                txtQtyNeed.Focus();
                            }
                            else if (txtQuantityNew.Text == "0")
                            {
                                Program.MessagerErr("Vui lòng chọn sản phẩm mới khác." + Environment.NewLine, "DOI HANG");
                            }
                            else
                            {
                                if (tbListProductOrderNew.Rows.Count > 0)
                                {
                                    if (Convert.ToDouble(txtQuantityNew.Text) > Convert.ToDouble(tbListProductOrderNew.Rows[0]["Quantity"]))
                                    {
                                        Program.MessagerErr("Sản phầm :" + tbListProductOrderNew.Rows[0]["ProductName"].ToString() + ". Không đủ số lượng :" + txtQuantityNew.Text + "." + Environment.NewLine + "Vui lòng kiểm tra lại.", "DOI HANG");
                                    }
                                    else
                                    {
                                        if (XtraMessageBox.Show("Bạn có chắc chắn muốn đổi???", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        {
                                            string strDetail = Common.ParseString(cboProcutNew.EditValue);
                                            param = new QryParam();
                                            param.Add("@OrderDetail_ID", SqlDbType.Int, Common.ParseInt(cboProduct.EditValue));
                                            param.Add("@QuantityOld", SqlDbType.Int, Common.ParseInt(txtQtyNeed.Text));
                                            param.Add("@QuantityPromotionOld", SqlDbType.Int, Common.ParseInt(txtQtyPromotionNeed.Text));
                                            param.Add("@Order_ID", SqlDbType.Int, this.GetSetOrder_ID);
                                            param.Add("@Product_IDOld", SqlDbType.Int, Common.ParseInt(cboProduct.GetColumnValue("Product_ID")));
                                            param.Add("@Product_IDNew", SqlDbType.Int, Common .ParseInt(strDetail.Split ('_')[0]));
                                            param.Add("@PriceNew", SqlDbType.Decimal, Convert.ToDecimal(cboPrice.GetColumnValue("Price")));
                                            param.Add("@QuantityNew", SqlDbType.Int, Common.ParseInt(txtQuantityNew.Text));
                                            param.Add("@QuantityPromotionNew", SqlDbType.Int, Common.ParseInt(txtQtyPromotionNew.Text));
                                            param.Add("@DiscountNew", SqlDbType.Int, Common.ParseInt(txtDiscountNew.Value));
                                            if (comboboxTypePromotion.Text == "Không Khuyến Mãi")
                                            {
                                                param.Add("@FormNew", SqlDbType.NVarChar, "");
                                            }
                                            else
                                            {
                                                param.Add("@FormNew", SqlDbType.NVarChar, comboboxTypePromotion.Text);
                                            }
                                            param.Add("@PercentPromotion", SqlDbType.Int, Convert.ToInt32(txtPercentPromotionNEw.Text));
                                            param.Add("@PriceOld", SqlDbType.Decimal, Convert.ToInt32(txtPrice.Text));
                                            param.Add("@PriceImportOld", SqlDbType.Decimal, getSetPriceImport);
                                            param.Add("@PriceImportNew", SqlDbType.Decimal, Convert.ToDecimal(strDetail.Split('_')[2]));
                                            clsSQL.BeginTrans();
                                            clsSQL.ExecStore("spChangeProduct_Process", param);

                                            if (iDelete_Salary == 1)
                                            {
                                                #region cap nhat payment
                                                CheckAction = true;
                                                param = new QryParam();
                                                param.Add("@Order_ID", SqlDbType.Int, this.GetSetOrder_ID);
                                                clsSQL.ExecStore("spPaymentOrder_Del", param);

                                                string Note = "Do Thay Đổi Sản Phẩm Nhiều Quá Nên Tính Lại Số Tiền Trong Hóa Đon";
                                                param = new QryParam();
                                                param.Add("@Order_ID", SqlDbType.Int, this.GetSetOrder_ID);
                                                param.Add("@OrderDate", SqlDbType.DateTime, Convert.ToDateTime(DateTime.Now));
                                                param.Add("@Amount", SqlDbType.Decimal, oldPayment);
                                                param.Add("@Note", SqlDbType.NVarChar, Note);
                                                param.Add("@CheckInsertSalaries", SqlDbType.Int, 2);
                                                clsSQL.ExecStore("spPaymentOrder_Ins", param);
                                                #endregion
                                            }
                                            

                                            clsSQL.CommitTrans();
                                            Program.MessagerInfo("Đổi Hàng Thành Công!!!", "DOI HANG");
                                            updateData();
                                        }
                                        else { CheckAction = false; }

                                    }
                                }
                            }
                            #endregion
                        }
                        else { 
                         CheckAction = false;
                        }
                       
                    }
                    if (CheckAction)
                    {
                        this.Close();
                    }
                }
                else {
                    Program.MessagerErr(sErr, "HOA DON NHAP");
                }
                    
                
            }
            catch (Exception ex)
            {
                clsSQL.RollBackTrans();
                Program.MessagerErr("Đổi Hàng Thất Bại" + Environment.NewLine + ex.ToString(), "DOI HANG");
            }
        }

        private void txtQuantityNew_EditValueChanged(object sender, EventArgs e)
        {

        }
        public void SetValueComboboxTypePromotion()
        {
            #region Add value for Combobox Promotion
            DataTable tb_temp = new DataTable();
            string strSql = "select Code_Id,Item_Name from tbl_code where Item_CD = '100' and Status = 0";
            tb_temp = clsSQL.GetTableSQL(strSql);
            comboboxTypePromotion.Properties.DataSource = tb_temp;
            comboboxTypePromotion.Properties.DisplayMember = "Item_Name";
            comboboxTypePromotion.Properties.ValueMember = "Code_Id";
            //comboboxTypePromotion.Properties.PopulateColumns();
            //comboboxTypePromotion.Properties.Columns["Code_Id"].Visible = false;
            #endregion

        }
    }
}