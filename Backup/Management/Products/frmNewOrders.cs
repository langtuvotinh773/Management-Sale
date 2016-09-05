using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Management.Reports;
using Management.Commons;
using DevExpress.XtraEditors.Repository;
using Management.Commons.SQL;
namespace Management.Products
{
    public partial class frmNewOrders : DevExpress.XtraEditors.XtraForm
    {
        public frmNewOrders()
        {
            InitializeComponent();
        }
        QryData clsSQL;
        QryParam param;

        DataTable tbCust, tbEmp, tbProducts, tbDetails;
        int checkAlter = 0;// neu checkALter = 1 thi show Mesg 
        bool checkOrderCode(string sOrderCode)
        {
            bool iValid = true;
            try
            {
                int isCheck;
                clsSQL = new QryData(Program.config.ConnectionString);
                param = new QryParam();
                param.Add("@OrderCode", SqlDbType.VarChar, sOrderCode);
                isCheck = Common.ParseInt(clsSQL.ExecScalarStore("spODD_checkOrderCode", param));
                if (isCheck > 0)
                {
                    iValid = false;
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.ToString());
            }
            return iValid;
        }

        private void frmNewOrders_Load(object sender, EventArgs e)
        {
            try
            {



                clsSQL = new QryData(Program.config.ConnectionString);
                string sQueryCust = "SElect Cust_ID, CustName, Address From tbl_Customers Order By CustName";
                string sQueryEmp = "SElect Emp_ID, EmpName , Address From tbl_Employees where IsDefault != 1 Order By EmpName";
                tbCust = new DataTable();
                tbEmp = new DataTable();
                tbCust = clsSQL.GetTableSQL(sQueryCust);
                tbEmp = clsSQL.GetTableSQL(sQueryEmp);
                //
                cboCust.Properties.DataSource = tbCust;
                cboCust.Properties.DisplayMember = "CustName";
                cboCust.Properties.ValueMember = "Cust_ID";
                //cboCust.ItemIndex = 0;
                //
                cboEmp.Properties.DataSource = tbEmp;
                cboEmp.Properties.ValueMember = "Emp_ID";
                cboEmp.Properties.DisplayMember = "EmpName";
                // cboEmp.ItemIndex = 0;

                tbProducts = new DataTable();
                tbProducts = clsSQL.GetTableStore("spODD_ListProduct");
                gcProducts.DataSource = tbProducts;
                // SetValueComboboxTypePromotion();
                // Add Hinh Thuc vao Combobox
                dropboxTypePromotion_Edit.Items.Clear();
                dropboxTypePromotion_Edit.Items.Add(SettingCodeDB.TypePromotion_No);
                dropboxTypePromotion_Edit.Items.Add(SettingCodeDB.TypePromotion_Discount);
                dropboxTypePromotion_Edit.Items.Add(SettingCodeDB.TypePromotion_Product);
                dropboxTypePromotion_Edit.Items.Add(SettingCodeDB.TypePromotion_Product_Discount);
                //
                tbDetails = new DataTable();
                tbDetails.Columns.Add(new DataColumn("Product_ID"));
                tbDetails.Columns.Add(new DataColumn("ProductName"));
                tbDetails.Columns.Add(new DataColumn("Discount", System.Type.GetType("System.Int32")));
                tbDetails.Columns.Add(new DataColumn("Quantity", System.Type.GetType("System.Int32")));
                tbDetails.Columns.Add(new DataColumn("QuantityPromotion", System.Type.GetType("System.Int32")));
                tbDetails.Columns.Add(new DataColumn("PercentDonation", System.Type.GetType("System.Int32")));
                tbDetails.Columns.Add(new DataColumn("PercentDiscount", System.Type.GetType("System.Int32")));
                tbDetails.Columns.Add(new DataColumn("UnitName"));
                tbDetails.Columns.Add(new DataColumn("PriceActual_Import", System.Type.GetType("System.Decimal")));
                tbDetails.Columns.Add(new DataColumn("Price", System.Type.GetType("System.Decimal")));
                tbDetails.Columns.Add(new DataColumn("Weight"));
                tbDetails.Columns.Add(new DataColumn("Form"));

                tbDetails.Columns.Add(new DataColumn("TotalAmount", System.Type.GetType("System.Decimal")));
                tbDetails.Columns.Add(new DataColumn("QuantityInventory", System.Type.GetType("System.Int32")));
                
                gcDetails.DataSource = tbDetails;

            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "HOA DON XUAT");
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvProducts.FocusedRowHandle < 0)
                {

                }
                else
                {
                    dropboxTypePromotion_Edit.Items.Clear();
                    //dropboxTypePromotion_Edit.Items.Add("Không Khuyến Mãi");
                    //dropboxTypePromotion_Edit.Items.Add(SettingCodeDB.TypePromotion_Discount);
                    //dropboxTypePromotion_Edit.Items.Add(SettingCodeDB.TypePromotion_Product);
                    //dropboxTypePromotion_Edit.Items.Add(SettingCodeDB.TypePromotion_Product_Discount);
                    dropboxTypePromotion_Edit.Items.Add(SettingCodeDB.TypePromotion_No);
                    dropboxTypePromotion_Edit.Items.Add(SettingCodeDB.TypePromotion_Discount);
                    dropboxTypePromotion_Edit.Items.Add(SettingCodeDB.TypePromotion_Product);
                    dropboxTypePromotion_Edit.Items.Add(SettingCodeDB.TypePromotion_Product_Discount);

                    // dropboxTypePromotion_Edit. = 1;
                    // SetValueComboboxTypePromotion();
                    RepositoryItemComboBox obj = new RepositoryItemComboBox();
                    obj.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

                    bool bValid = true;
                    string sProcut_ID = gvProducts.GetRowCellValue(gvProducts.FocusedRowHandle, "Product_ID").ToString();
                    string sPrice = gvProducts.GetRowCellValue(gvProducts.FocusedRowHandle, "Price").ToString();
                    string sPriceActual = gvProducts.GetRowCellValue(gvProducts.FocusedRowHandle, "PriceActual_Import").ToString();
                    foreach (DataRow item in tbDetails.Select("Product_ID=" + sProcut_ID + " And Price = " + sPrice + " And PriceActual_Import = " + sPriceActual))
                    {
                        bValid = false;
                    }
                    if (bValid)
                    {
                        DataRow dr;
                        dr = tbDetails.NewRow();
                        foreach (DataRow row in tbProducts.Select("Product_ID=" + sProcut_ID + " And Price = " + sPrice + " And PriceActual_Import = " + sPriceActual))
                        {
                            dr["Product_ID"] = row["Product_ID"];
                            dr["ProductName"] = row["ProductName"];
                            dr["Quantity"] = DBNull.Value;
                            dr["QuantityPromotion"] = DBNull.Value;
                            dr["Discount"] = DBNull.Value;
                            dr["PercentDiscount"] = row["PercentDiscount"];
                            dr["PercentDonation"] = row["PercentDonation"];
                            dr["PriceActual_Import"] = row["PriceActual_Import"];
                            dr["Price"] = row["Price"];
                            dr["UnitName"] = row["UnitName"];
                            //dr["Form"] = "9999";
                            dr["Weight"] = row["Weight"];
                            dr["TotalAmount"] = DBNull.Value;
                            //PriceActual_Import
                            dr["QuantityInventory"] = row["Quantity"];

                        }
                        tbDetails.Rows.Add(dr);
                    }


                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "HOA DON NHAP");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                string sErr = "";
                bool bValid = true;
                if (TypeOrder.SelectedIndex == -1)
                {
                    sErr = "Vui lòng chọn loại hóa đơn muốn xuất";
                    bValid = false;
                }
                if (cboCust.EditValue == null)
                {
                    sErr = sErr + Environment.NewLine + "Vui lòng chọn Khách Hàng.";
                    bValid = false;
                }
                if (cboEmp.EditValue == null)
                {

                    sErr = sErr + Environment.NewLine + "Vui lòng chọn Nhân Viên.";
                    bValid = false;
                }
                if (tbDetails.Rows.Count == 0)
                {
                    sErr = sErr + Environment.NewLine + "Vui lòng chọn Sản Phẩm.";
                    bValid = false;
                }
                else
                {
                    foreach (DataRow row in tbDetails.Rows)
                    {
                        int Quantity = 0;
                        if (row["Quantity"].ToString() != "")
                        {
                            Quantity = Common.ParseInt(row["Quantity"]);
                        }
                        if (Quantity <= 0)
                        {
                            decimal iii = decimal.Parse(row["Price"].ToString());
                            string VND = String.Format("{0:0,0}", iii);
                            sErr = sErr + Environment.NewLine + "Vui lòng nhập Số Lượng cho Sản Phẩm." + row["ProductName"].ToString() + ". Đơn giá: " + VND;
                            bValid = false;
                        }
                        else if ((Common.ParseDecimal(row["Quantity"]) + Common.ParseDecimal(row["QuantityPromotion"])) > Common.ParseDecimal(row["QuantityInventory"]))
                        {
                            sErr = sErr + Environment.NewLine + row["ProductName"] + " số lượng tồn kho không đủ";
                            bValid = false;
                        }
                    }
                }
                if (!bValid)
                {
                    clsSQL.RollBackTrans();
                    Program.MessagerErr(sErr, "HOA DON XUAT");
                }
                else
                {

                    int iOrder_ID = 0;

                    string outParmater = string.Empty;
                    if (bValid)
                    {
                        clsSQL = new QryData(Program.config.ConnectionString);
                        param = new QryParam();
                        #region Check Money
                        decimal TotalAmountOrder = 0;
                        decimal TotalAmountImportOrder = 0;
                        int IDEmp = Common.ParseInt(cboEmp.EditValue.ToString());
                        DataTable dt_Current = new DataTable();
                        DataView dv = new DataView();
                        dv = (DataView)gvDetails.DataSource;
                        dt_Current = dv.ToTable();
                        foreach (DataRow dr in dt_Current.Rows)
                        {
                            decimal PriceSell = Common.ParseDecimal(dr["Price"]);
                            decimal PriceActual = Common.ParseDecimal(dr["PriceActual_Import"]);
                            decimal Quantity = Common.ParseDecimal(dr["Quantity"]);
                            decimal QuantityPromotion = Common.ParseDecimal(dr["QuantityPromotion"]);
                            decimal TotalAmount = Common.ParseDecimal(dr["TotalAmount"]);
                            param.Clear();
                            param.Add("@Emp_ID", SqlDbType.Int, IDEmp);
                            param.Add("@Product_ID", SqlDbType.Int, Common.ParseInt(dr["Product_ID"]));
                            DataTable dtResultPercent = new DataTable();
                            dtResultPercent = clsSQL.GetTableStore("sp_GetPercents", param);
                            decimal percentSalary = 0;
                            if (dtResultPercent.Rows.Count > 0)
                            {
                                percentSalary = Common.ParseDecimal(dtResultPercent.Rows[0]["Percents"]);
                                TotalAmountOrder = TotalAmountOrder + TotalAmount - ((TotalAmount * percentSalary) / 100);
                            }
                            else
                            {
                                TotalAmountOrder = TotalAmountOrder + TotalAmount;
                            }
                            TotalAmountImportOrder = TotalAmountImportOrder + (PriceActual * (Quantity + QuantityPromotion));
                        }
                        TotalAmountOrder = TotalAmountOrder - Common.ParseDecimal(txtPercentMoney.Text);
                        if (TotalAmountOrder < TotalAmountImportOrder)
                        {
                            //Msg Error;
                            Program.MessagerErr("Tổng tiền lời cho hóa đơn < 0", "HOA DON XUAT");
                            return;
                        }
                        #endregion


                        param.Clear();
                        clsSQL.BeginTrans();
                        param.Add("@Cust_ID", SqlDbType.Int, Common.ParseInt(cboCust.EditValue));
                        param.Add("@Emp_ID", SqlDbType.Int, Common.ParseInt(cboEmp.EditValue));
                        param.Add("@TypeOption", SqlDbType.Int, Commons.Common.ParseInt(TypeOrder.Text));
                        param.Add("@CastPromotion", SqlDbType.Decimal, Commons.Common.ParseDecimal(txtPercentMoney.Text));
                        param.AddOutput("@Order_ID", SqlDbType.Int, 0);
                        string outData0 = string.Empty;
                        clsSQL.ExecStore("spOD_Ins", param, out outData0);
                        outParmater = outParmater + outData0;
                        iOrder_ID = (int)param.GetValue("@Order_ID");
                        foreach (DataRow row in tbDetails.Rows)
                        {

                            int Product_ID = Common.ParseInt(row["Product_ID"]);
                            decimal Price = Common.ParseDecimal(row["Price"]);
                            string strForm = getTypePromotion(Common.ParseDecimal(row["QuantityPromotion"]),Common.ParseDecimal(row["Discount"]));
                            param.Clear();
                            param.Add("@Order_ID", SqlDbType.Int, iOrder_ID);
                            param.Add("@Product_ID", SqlDbType.Int, Product_ID);
                            param.Add("@Quantity", SqlDbType.Int, Common.ParseInt(row["Quantity"])  );
                            param.Add("@QuantityPromotion", SqlDbType.Int, Common.ParseInt(row["QuantityPromotion"]));
                            param.Add("@DisCount", SqlDbType.Decimal, Common.ParseDecimal(row["Discount"]));
                            param.Add("@PercentDiscount", SqlDbType.Decimal, Common.ParseDecimal(row["PercentDiscount"]));
                            param.Add("@Price", SqlDbType.Decimal, Price);
                            param.Add("@Form", SqlDbType.NVarChar,strForm);
                            param.Add("@Price_Import", SqlDbType.Decimal, Convert.ToDecimal(row["PriceActual_Import"]));


                            if (Commons.Common.ParseInt(TypeOrder.Text) == 1)
                            {
                                #region Insert tbl_OrderDetails
                                string outData = string.Empty;
                                clsSQL.ExecStore("spODD_Ins", param, out outData);
                                outParmater = outParmater + outData;
                                #endregion
                            }

                            else if (Commons.Common.ParseInt(TypeOrder.Text) == 0)
                            {
                                #region Insert tbl_OrderDetails_Option2
                                string outData = string.Empty;
                                clsSQL.ExecStore("spODD_Ins_Option2", param, out outData);
                                outParmater = outParmater + outData;
                                #endregion
                            }
                        }
                        clsSQL.InsertLogData("spPro_InsertLogData", SettingCodeDB.listActions.Create.ToString(), Common.getPermissionType(SettingCodeDB.USERNAME_User, SettingCodeDB.PASSWORD_User).ToString(), SettingCodeDB.listScreens.frmNewOrders.ToString(), outParmater);
                        clsSQL.CommitTrans();

                    }



                    // In bao cao
                    frmNewOrders_Load(null, null);
                    param = new QryParam();
                    param.Add("Order_ID", SqlDbType.Int, iOrder_ID);
                    Installer1 rptOrder = new Installer1();
                    rptOrder.DataSource = clsSQL.GetTableStore("spRpt_Orders_Details", param);
                    frmShowPrint frmShow = new frmShowPrint();
                    frmShow.MyTitle = "HOA DON XUAT";
                    frmShow.MyReport = rptOrder;
                    frmShow.ShowDialog();
                    this.Close();

                }
            }
            catch (Exception ex)
            {
                clsSQL.RollBackTrans();
                Program.MessagerErr(ex.ToString(), "HOA DON XUAT");
            }

        }

        private string getTypePromotion(decimal quantity, decimal percent)
        {
            string strResult = "";
            if (quantity > 0 && percent > 0)
            {
                strResult = SettingCodeDB.TypePromotion_Product_Discount;
            }
            else if (quantity > 0 && percent == 0)
            {
                strResult = SettingCodeDB.TypePromotion_Product;
            }
            else if (quantity == 0 && percent > 0)
            {
                strResult = SettingCodeDB.TypePromotion_Discount;
            }
            else
            {
                strResult = SettingCodeDB.TypePromotion_No;
            }
                return strResult;
        }
        private void gcDetails_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && gvDetails.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing && gvDetails.FocusedRowHandle >= 0)
                {
                    tbDetails.Rows.RemoveAt(gvDetails.FocusedRowHandle);

                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "HOA DON XUAT");
            }
        }

        private void gvDetails_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                string sErr = "";
                bool bValid = true;
                if (checkAlter ==1)
                {
                    sErr = sErr + Environment.NewLine + "Số lượng không đủ để KM";
                    bValid = false;
                }
                if (Common.ParseInt(gvDetails.GetRowCellValue(e.RowHandle, "Quantity")) <= 0)
                {
                    sErr = sErr + Environment.NewLine + "Số lượng phải lớn hơn 0";
                    bValid = false;
                }

                int ID_Product = Common.ParseInt(gvDetails.GetRowCellValue(e.RowHandle, "Product_ID"));
                int Number_Product = Common.ParseInt(gvDetails.GetRowCellValue(e.RowHandle, "Quantity"));
                decimal Discount = 0;

                if (gvDetails.GetRowCellValue(e.RowHandle, "Discount").ToString() != "")
                {
                    Discount = Common.ParseDecimal(gvDetails.GetRowCellValue(e.RowHandle, "Discount"));
                }

                if (Discount < 0)
                {
                    sErr = sErr + Environment.NewLine + "Chiết khấu phải >=0";
                    bValid = false;
                }
                else
                {

                    decimal dAmount = 0;
                    decimal dPrice = 0;
                    decimal dQuantity = 0;
                    decimal iDiscount = 0;
                    int iPercentDonation = 0;
                    int iQuantityPromotion = 0;
                    int iPercentDiscount = 0;
                    dPrice = Common.ParseDecimal(gvDetails.GetRowCellValue(e.RowHandle, "Price"));
                    int dQuantity222 = 0;
                    if (gvDetails.GetRowCellValue(e.RowHandle, "Quantity").ToString() != "")
                    {
                        dQuantity = Common.ParseInt(gvDetails.GetRowCellValue(e.RowHandle, "Quantity"));
                    }
                    if (gvDetails.GetRowCellValue(e.RowHandle, "Discount").ToString() != "")
                    {
                        iDiscount = Common.ParseDecimal(gvDetails.GetRowCellValue(e.RowHandle, "Discount"));
                    }
                    // iDiscount = iDiscount222;
                    iPercentDiscount = Common.ParseInt(gvDetails.GetRowCellValue(e.RowHandle, "PercentDiscount"));
                    dAmount = Convert.ToDecimal((dQuantity * dPrice) - ((dQuantity * dPrice * (iDiscount + iPercentDiscount)) / 100));

                    #region Validation form
                    // khong Nhan dc KM
                    if (gvDetails.GetRowCellValue(e.RowHandle, "Form").ToString() == "Không Khuyến Mãi")
                    {
                        gvDetails.SetRowCellValue(e.RowHandle, "Discount", DBNull.Value);
                        gvDetails.SetRowCellValue(e.RowHandle, "QuantityPromotion", DBNull.Value);

                        col_ODDQuantityPromo.OptionsColumn.AllowEdit = false;
                        col_ODDDiscount.OptionsColumn.AllowEdit = false;
                    }

                    // Giam Gia
                    if (gvDetails.GetRowCellValue(e.RowHandle, "Form").ToString() == SettingCodeDB.TypePromotion_Discount)
                    {
                        decimal PerDiscount = Common.ParseDecimal(gvDetails.GetRowCellValue(e.RowHandle, "Discount"));
                        if (PerDiscount == 0 || PerDiscount < 0)
                        {
                            sErr = sErr + Environment.NewLine + "% Chiết Khấu Phải > 0";
                            bValid = false;
                        }
                        col_ODDQuantityPromo.OptionsColumn.AllowEdit = false;
                        col_ODDDiscount.OptionsColumn.AllowEdit = true;
                        gvDetails.SetRowCellValue(e.RowHandle, "QuantityPromotion", DBNull.Value);
                    }

                    // Tang San Pham
                    if (gvDetails.GetRowCellValue(e.RowHandle, "Form").ToString() == SettingCodeDB.TypePromotion_Product)
                    {
                        int QtyPromotionCurrent = Common.ParseInt(gvDetails.GetRowCellValue(e.RowHandle, "QuantityPromotion"));
                        if (QtyPromotionCurrent == 0 || QtyPromotionCurrent < 0)
                        {
                            sErr = sErr + Environment.NewLine + "Số Lượng Khuyến Mãi Phải > 0";
                            bValid = false;
                        }
                        col_ODDQuantityPromo.OptionsColumn.AllowEdit = true;
                        col_ODDDiscount.OptionsColumn.AllowEdit = false;
                        gvDetails.SetRowCellValue(e.RowHandle, "Discount", DBNull.Value);
                    }

                    //Giam Gia - Tang San Pham
                    if (gvDetails.GetRowCellValue(e.RowHandle, "Form").ToString() == SettingCodeDB.TypePromotion_Product_Discount)
                    {
                        col_ODDQuantityPromo.OptionsColumn.AllowEdit = true;
                        col_ODDDiscount.OptionsColumn.AllowEdit = true;

                        int QtyPromotionCurrent = Common.ParseInt(gvDetails.GetRowCellValue(e.RowHandle, "QuantityPromotion"));
                        int PerDiscount = Common.ParseInt(gvDetails.GetRowCellValue(e.RowHandle, "Discount"));
                        if (QtyPromotionCurrent == 0 || QtyPromotionCurrent < 0)
                        {
                            sErr = sErr + Environment.NewLine + "Số Lượng Khuyến Mãi Phải > 0";
                            bValid = false;
                        }
                        if (PerDiscount == 0 || PerDiscount < 0)
                        {
                            sErr = sErr + Environment.NewLine + "% Chiết Khấu Phải > 0";
                            bValid = false;
                        }
                    }
                    #endregion
                    gvDetails.SetRowCellValue(e.RowHandle, "TotalAmount", dAmount);
                }

                //
                string sProductID = gvDetails.GetRowCellValue(e.RowHandle, "Product_ID").ToString();

                decimal sPriceDetail = Common.ParseDecimal(gvDetails.GetRowCellValue(e.RowHandle, "Price").ToString());
                decimal sPriceImport = Common.ParseDecimal(gvDetails.GetRowCellValue(e.RowHandle, "PriceActual_Import").ToString());

                // validation Value input percent Quanlity
                //foreach (DataRow row in tbProducts.Select("Product_ID=" + sProductID + " And Price=" + sPriceDetail + " And PriceActual_Import = " + sPriceImport))
                //{
                //    if (Common.ParseInt(gvDetails.GetRowCellValue(e.RowHandle, "Quantity")) > Common.ParseInt(row["Quantity"]))
                //    {
                //        sErr = sErr + Environment.NewLine + "Số lượng xuất không được lớn hơn : " + row["Quantity"].ToString();
                //        bValid = false;
                //    }
                //    if (Common.ParseInt(gvDetails.GetRowCellValue(e.RowHandle, "QuantityPromotion")) > Common.ParseInt(row["QuantityPromotion"]))
                //    {
                //        sErr = sErr + Environment.NewLine + "Số Lượng Khuyến Mại xuất không được lớn hơn : " + row["QuantityPromotion"].ToString();
                //        bValid = false;
                //    }
                //}

                if (bValid)
                {
                    //(iod.Quantity * iod.Price)-((iod.Quantity * iod.Price) * (iod.Discount + iod.PercentPromotion)/100.00) as Amount
                    e.Valid = true;
                }
                else
                {
                    e.Valid = false;
                    Program.MessagerErr(sErr, "HOA DON XUAT");
                }

            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "HOA DON XUAT");
            }
        }

        private void gvDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                //if (gvDetails.GetRowCellValue(e.RowHandle, "Form").ToString() == "Không Khuyến Mãi")
                //{
                //    col_ODDQuantityPromo.OptionsColumn.AllowEdit = false;
                //    col_ODDDiscount.OptionsColumn.AllowEdit = false;

                //    //gvDetails.SetRowCellValue(e.RowHandle, "QuantityPromotion", 0);
                //    //gvDetails.SetRowCellValue(e.RowHandle, "Discount", 0);

                //}
                //if (gvDetails.GetRowCellValue(e.RowHandle, "Form").ToString() == SettingCodeDB.TypePromotion_Discount)
                //{
                //    col_ODDQuantityPromo.OptionsColumn.AllowEdit = false;
                //    col_ODDDiscount.OptionsColumn.AllowEdit = true;

                //    //gvDetails.SetRowCellValue(e.RowHandle, "QuantityPromotion", DBNull.Value);
                //    //gvDetails.SetRowCellValue(e.RowHandle, "Discount", DBNull.Value);
                //}
                //if (gvDetails.GetRowCellValue(e.RowHandle, "Form").ToString() == SettingCodeDB.TypePromotion_Product)
                //{
                //    col_ODDQuantityPromo.OptionsColumn.AllowEdit = true;
                //    col_ODDDiscount.OptionsColumn.AllowEdit = false;
                //    //gvDetails.SetRowCellValue(e.RowHandle, "QuantityPromotion", DBNull.Value);
                //    //gvDetails.SetRowCellValue(e.RowHandle, "Discount", 0);
                //}
                //if (gvDetails.GetRowCellValue(e.RowHandle, "Form").ToString() == SettingCodeDB.TypePromotion_Product_Discount)
                //{
                //    col_ODDQuantityPromo.OptionsColumn.AllowEdit = true;
                //    col_ODDDiscount.OptionsColumn.AllowEdit = true;
                //    //gvDetails.SetRowCellValue(e.RowHandle, "QuantityPromotion", DBNull.Value);
                //    //gvDetails.SetRowCellValue(e.RowHandle, "Discount", DBNull.Value);
                //}


                //clsSQL = new QryData(Program.config.ConnectionString);
                if (e.Column.FieldName == "Quantity")
                {
                    int iPercentDonation = 0;
                    int iQuantityPromotion = 0;
                    decimal dQuantity = 0;
                    // get value from gridview
                    dQuantity = Convert.ToDecimal(gvDetails.GetRowCellValue(e.RowHandle, "Quantity"));
                    int strProduct_Id = Common.ParseInt(gvDetails.GetRowCellValue(e.RowHandle, "Product_ID"));
                    decimal strPrice = decimal.Parse(gvDetails.GetRowCellValue(e.RowHandle, "Price").ToString());
                    decimal strPriceActual_Import = decimal.Parse(gvDetails.GetRowCellValue(e.RowHandle, "PriceActual_Import").ToString());
                    clsSQL = new QryData(Program.config.ConnectionString);
                    param = new QryParam();
                    param.Add("@Product_ID", SqlDbType.Int, strProduct_Id);
                    param.Add("@Price", SqlDbType.Decimal, strPrice);
                    param.Add("@PriceActual_Import", SqlDbType.Decimal, strPriceActual_Import);
                    DataTable tbQuantityImp = new DataTable();
                    tbQuantityImp = clsSQL.GetTableStore("spgetQuantity_Promotion", param);
                    decimal Number_Buy = 0;
                    decimal Number_Promotion = 0;
                    if(tbQuantityImp.Rows.Count>0)
                    {
                     Number_Buy = Common.ParseDecimal(tbQuantityImp.Rows[0]["Number_buy"]);
                     Number_Promotion = Common.ParseDecimal(tbQuantityImp.Rows[0]["Number_Promotions"]);
                    }
                    if (Number_Buy > 0)
                    {
                        decimal Persent = dQuantity / Number_Buy;
                        //set so luong km 
                        iQuantityPromotion = Common.ParseInt(Math.Floor(Number_Promotion * Persent));


                        if (iQuantityPromotion > 0)
                        {
                            param.Clear();
                            param.Add("@Product_ID", SqlDbType.Int, strProduct_Id);
                            param.Add("@Price", SqlDbType.Decimal, strPrice);
                            param.Add("@PriceActual_Import", SqlDbType.Decimal, strPriceActual_Import);
                            DataTable tbGetCurrentQuatity = new DataTable();
                            tbGetCurrentQuatity = clsSQL.GetTableStore("spGetCurrentQuantity", param);
                            decimal TotalCurrentQuantity = Common.ParseDecimal(tbGetCurrentQuatity.Rows[0]["Quantity"]);
                            if (TotalCurrentQuantity < (iQuantityPromotion + dQuantity))
                            {
                                iQuantityPromotion = 0;
                                checkAlter = 1;
                            }
                            else
                            {
                                checkAlter = 0;
                            }
                        }

                        ////iPercentDonation = Common.ParseInt(gvDetails.GetRowCellValue(e.RowHandle, "PercentDonation"));
                        ////int NumberRound = (Common.ParseInt(dQuantity) * iPercentDonation) / 100;
                        ////iQuantityPromotion = NumberRound;

                        #region Nếu số lượng khuyến mãi ít hơn số lượng nhập vào thì set = 0
                        ////clsSQL = new QryData(Program.config.ConnectionString);
                        ////param = new QryParam();
                        ////QryParam paramOrder = new QryParam();
                        ////QryParam paramPromotions = new QryParam();
                        ////QryParam paramPromotionsType = new QryParam();



                        ////param.Add("@Product_ID", SqlDbType.Int, strProduct_Id);
                        ////param.Add("@PriceSell", SqlDbType.Decimal, strPrice);
                        ////DataTable tbQuantityImp = new DataTable();
                        ////tbQuantityImp = clsSQL.GetTableStore("spImpQuantityPromotion", param);


                        ////paramOrder.Add("@Product_ID", SqlDbType.Int, strProduct_Id);
                        ////paramOrder.Add("@PriceSell", SqlDbType.Decimal, strPrice);
                        ////DataTable tbQuantityOrder = new DataTable();
                        ////tbQuantityOrder = clsSQL.GetTableStore("spOrderQuantityPromotion", paramOrder);

                        ////DateTime dateNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
                        ////paramPromotionsType.Add("@Product_ID", SqlDbType.Int, strProduct_Id);
                        ////paramPromotionsType.Add("@Price", SqlDbType.Decimal, strPrice);
                        ////paramPromotionsType.Add("@BeginDate", SqlDbType.DateTime, dateNow);
                        ////DataTable tbPromotionsType = new DataTable();
                        ////tbPromotionsType = clsSQL.GetTableStore("spPromo_checkPromotionType", paramPromotionsType);
                        ////int CheckPromotion = 0;
                        ////if (tbPromotionsType.Rows.Count > 0)
                        ////{
                        ////    if (tbPromotionsType.Rows[0][0].ToString().Length >= 12)
                        ////    {
                        ////        CheckPromotion = 1;
                        ////    }
                        ////}
                        ////if (CheckPromotion == 1)
                        ////{
                        ////    #region Set Value cho cột số Lượng Khuyến Mãi
                        ////    if (tbQuantityImp.Rows[0][0].ToString().Length > 0)
                        ////    {
                        ////        int QuantityImp = Common.ParseInt(tbQuantityImp.Rows[0][0].ToString());
                        ////        int QuantityOrder = 0;
                        ////        int QuantityCurrent = 0;

                        ////        if (tbQuantityOrder.Rows[0][0].ToString().Length > 0)
                        ////        {
                        ////            QuantityOrder = Common.ParseInt(tbQuantityOrder.Rows[0][0].ToString());
                        ////            QuantityCurrent = QuantityImp - QuantityOrder;

                        ////            if (iQuantityPromotion > QuantityCurrent)
                        ////            {
                        ////                if (XtraMessageBox.Show("Số lượng khuyến mãi không thể vượt quá " + QuantityCurrent + " !" + Environment.NewLine + " Bạn có muốn lấy số lượng KM hiện có không ?", "Khuyen Main", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        ////                {
                        ////                    iQuantityPromotion = QuantityCurrent;
                        ////                }
                        ////                else
                        ////                {
                        ////                    iQuantityPromotion = 0;
                        ////                }
                        ////            }

                        ////        }
                        ////        else
                        ////        {
                        ////            // iQuantityPromotion = QuantityImp;
                        ////        }


                        ////    }
                        ////    #endregion

                        ////}
                    }
                    gvDetails.SetRowCellValue(e.RowHandle, "QuantityPromotion", iQuantityPromotion);
                    #endregion
                }
                if (e.Column.FieldName == "Discount")
                {
                    int iQtyOut = Common.ParseInt(gvDetails.GetRowCellValue(e.RowHandle, "Quantity"));

                    int iDiscountOut = 0;
                    if (gvDetails.GetRowCellValue(e.RowHandle, "Discount").ToString() != "")
                    {
                        iDiscountOut = Common.ParseInt(gvDetails.GetRowCellValue(e.RowHandle, "Discount"));
                    }
                    // int iDiscountOut = iDiscountOut222;
                    decimal iPriceOut = Convert.ToDecimal(gvDetails.GetRowCellValue(e.RowHandle, "Price"));
                    int iPercentDiscountOut = Common.ParseInt(gvDetails.GetRowCellValue(e.RowHandle, "PercentDiscount"));
                    decimal TotalAmountOut = (iQtyOut * iPriceOut) - ((iQtyOut * iPriceOut) * (iDiscountOut + iPercentDiscountOut) / 100);
                    gvDetails.SetRowCellValue(e.RowHandle, "TotalAmount", TotalAmountOut);
                    col_ODDTotalAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    col_ODDTotalAmount.DisplayFormat.FormatString = "{0:c0}";
                }
                //e.Column.FieldName=="Quantity" ||

            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "HOA DON XUAT");
            }
        }

        private void gvProducts_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                btnAdd.PerformClick();
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "HOA DON XUAT");
            }
        }

        private void gvDetails_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {

            try
            {
                e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "HOA DON NHAP");
            }
        }


        private void gvDetails_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            //dr["Product_ID"] = row["Product_ID"];
            //dr["ProductName"] = row["ProductName"];
            //dr["Quantity"] = DBNull.Value;
            //dr["QuantityPromotion"] = DBNull.Value;
            //dr["Discount"] = DBNull.Value;
            //dr["PercentDiscount"] = row["PercentDiscount"];
            //dr["PercentDonation"] = row["PercentDonation"];
            //dr["Price"] = row["Price"];
            //dr["UnitName"] = row["UnitName"];
            ////dr["Form"] = "9999";
            //dr["Weight"] = row["Weight"];
            //dr["TotalAmount"] = DBNull.Value;
            // gvImportOrder.SetRowCellValue(e.RowHandle, "ProductName", "CHỌN SẢN PHẨM");

            //gvDetails.SetRowCellValue(e.RowHandle, "Product_ID", DBNull.Value);
            //gvDetails.SetRowCellValue(e.RowHandle, "ProductName", DBNull.Value);
            //gvDetails.SetRowCellValue(e.RowHandle, "Quantity", DBNull.Value);
            //gvDetails.SetRowCellValue(e.RowHandle, "QuantityPromotion", DBNull.Value);
            //gvDetails.SetRowCellValue(e.RowHandle, "Discount", DBNull.Value);
            //gvDetails.SetRowCellValue(e.RowHandle, "PercentDiscount", DBNull.Value);
            //gvDetails.SetRowCellValue(e.RowHandle, "PercentDonation", DBNull.Value);
            //gvDetails.SetRowCellValue(e.RowHandle, "Price", DBNull.Value);
            //gvDetails.SetRowCellValue(e.RowHandle, "UnitName", DBNull.Value);
            //gvDetails.SetRowCellValue(e.RowHandle, "Weight", DBNull.Value);
            //gvDetails.SetRowCellValue(e.RowHandle, "TotalAmount", DBNull.Value);

        }

        private void gvDetails_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {

            //if (e.Column.FieldName == "Form")
            //{
            //    dropboxTypePromotion_Edit.Items.Clear();
            //    dropboxTypePromotion_Edit.Items.Add("Không Khuyến Mãi");
            //    dropboxTypePromotion_Edit.Items.Add(SettingCodeDB.TypePromotion_Discount);
            //    dropboxTypePromotion_Edit.Items.Add(SettingCodeDB.TypePromotion_Product);
            //    dropboxTypePromotion_Edit.Items.Add(SettingCodeDB.TypePromotion_Product_Discount);

            //}
        }

        private void gvDetails_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                //col_ODDQuantityPromo.OptionsColumn.AllowEdit = false;
                //col_ODDDiscount.OptionsColumn.AllowEdit = false;
                //SetValueComboboxTypePromotion();
                col_ODDForm.OptionsColumn.AllowEdit = e.FocusedRowHandle == Program.NEW_ROW;
                col_ODDForm.OptionsColumn.AllowEdit = true;


            }
            catch (Exception ex)
            {
                Program.MessagerErr(ex.ToString(), "HOA DON NHAP");

            }

        }
        private void typePromotion_Edit_Properties_QueryPopUp(object sender, CancelEventArgs e)
        {
            e.Cancel = true;

        }
        private void typePromotion_Edit_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ComboBoxEdit combo = sender as ComboBoxEdit;
            e.Cancel = combo.Properties.Items.IndexOf(combo.Text) == -1;
        }


        private void gvDetails_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }


        //public void SetValueComboboxTypePromotion()
        //{
        //    #region Add value for Combobox Promotion
        //    DataTable tb_temp = new DataTable();
        //    string strSql = "select Code_Id,Item_Name from tbl_code where Item_CD = '100' and Status = 0";
        //    tb_temp = clsSQL.GetTableSQL(strSql);
        //    typePromotion_Edit.DataSource = tb_temp;
        //    typePromotion_Edit.DisplayMember = "Item_Name";
        //    typePromotion_Edit.ValueMember = "Code_Id";
        //    typePromotion_Edit.Properties.PopulateColumns();
        //    typePromotion_Edit.Properties.Columns["Code_Id"].Visible = false;
        //    #endregion

        //}


    }
}