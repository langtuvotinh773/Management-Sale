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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace Management.Products
{
    public partial class frmEditOrders : DevExpress.XtraEditors.XtraForm
    {
        #region validation
        #region Delegate load lai data trong uct
        public delegate void CapNhatDuLieu();
        public CapNhatDuLieu updateData;
        #endregion

        public event EventHandler Form_Closing;
        int iOrder_ID;
        String moneyPayment, strTotalAmount;
        QryData clsSQL;
        QryParam param;
        int intProductID = 0;
        DataTable tbPayments, tbDetails, tbOrders, tbTotalNo;
        uctOrders Neworders = new uctOrders();
        int checkExist = 0;
        int ProductID_Selected = 0;
        decimal PriceImport_Selected = 0;
        decimal Price_Selected = 0;
        string strMsg = "";

        public int GetSetOrder_ID
        {
            get { return iOrder_ID; }
            set { iOrder_ID = value; }
        }

        public string GetTotalpayment
        {
            get { return moneyPayment; }
            set { moneyPayment = value; }
        }
        DataTable dtNew;
        public DataTable GetDelete_Order
        {
            get { return dtNew; }
            set { dtNew = value; }
        }

        public string GetTotalAmount
        {
            get { return strTotalAmount; }
            set { strTotalAmount = value; }
        }

        public frmEditOrders()
        {
            InitializeComponent();
        }
        #endregion

        #region Event
        private void frmEditOrders_Load(object sender, EventArgs e)
        {
            try
            {
                setDeaultGrid();

                //Add value for Combobox ProductName
                // DataTable tbProName = new DataTable();
                clsSQL = new QryData(Program.config.ConnectionString);
                param = new QryParam();
                ///////////////////////////
                totalno.Text = String.Format("{0:N0}", Common.ParseDecimal(this.GetTotalpayment));

                clsSQL = new QryData(Program.config.ConnectionString);
                param = new QryParam();
                param.Add("@Order_ID", SqlDbType.Int, this.GetSetOrder_ID);
                tbPayments = new DataTable();
                tbDetails = new DataTable();
                tbOrders = new DataTable();
                tbPayments = clsSQL.GetTableStore("spOD_frmEdit_ListPayment", param);
                param = param.Copy();
                tbDetails = clsSQL.GetTableStore("spOD_frmEdit_ListDetail", param);


                param = param.Copy();
                tbOrders = clsSQL.GetTableStore("spOD_frmEdit_List", param);
                gcOrderDetail.DataSource = tbDetails;
                gcPayments.DataSource = tbPayments;
                lblOrder_ID.Text = tbOrders.Rows[0]["Order_ID"].ToString();
                lblDate.Text = tbOrders.Rows[0]["OrderDate"].ToString();
                lblCastPromotion.Text = tbOrders.Rows[0]["CastPromotion"].ToString();

                // Add Hinh Thuc vao Combobox
                //SetValueComboboxTypePromotion();
                dropPromotion_Edit.Items.Clear();
                //dropPromotion_Edit.Items.Add("Không Khuyến Mãi");
                //dropPromotion_Edit.Items.Add(SettingCodeDB.TypePromotion_Discount);
                //dropPromotion_Edit.Items.Add(SettingCodeDB.TypePromotion_Product);
                //dropPromotion_Edit.Items.Add(SettingCodeDB.TypePromotion_Product_Discount);
                dropPromotion_Edit.Items.Add(SettingCodeDB.TypePromotion_No);
                dropPromotion_Edit.Items.Add(SettingCodeDB.TypePromotion_Discount);
                dropPromotion_Edit.Items.Add(SettingCodeDB.TypePromotion_Product);
                dropPromotion_Edit.Items.Add(SettingCodeDB.TypePromotion_Product_Discount);
                //Add value for Combobox ProductName
                SetValueComboboxProductName();

                #region
                //RepositoryItemComboBox repositoryItemBetVillk = new RepositoryItemComboBox();
                //repositoryItemBetVillk.Items.Clear();
                //repositoryItemBetVillk.Items.AddRange(new string[] { "12", "24", "36" });
                //repositoryItemBetVillk.ShowDropDown = ShowDropDown.SingleClick;
                ////repositoryItemBetVillk.AllowDropDownWhenReadOnly = DefaultBoolean.True;
                //repositoryItemBetVillk.DropDownRows = 3;
                //repositoryItemBetVillk.Enabled = true;
                //repositoryItemBetVillk.ReadOnly = true;
                //repositoryItemBetVillk.TextEditStyle = TextEditStyles.Standard;
                //repositoryItemBetVillk.UseCtrlScroll = false;
                //gvOrderDetail.Columns["BetVillk"].ColumnEdit = repositoryItemBetVillk;
                ////gvOrderDetail.RepositoryItems.Add(repositoryItemBetVillk);
                #endregion
                //  colODD_Discount.OptionsColumn.AllowEdit = false;
                // colODD_QtyPromotion.OptionsColumn.AllowEdit = false;

                if (Convert.ToBoolean(tbOrders.Rows[0]["IsLock"]) == true)
                {
                    lblStatus.Text = "Đã Khóa";
                    gvPayments.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                }
                else
                {
                    lblStatus.Text = "Chưa Khóa";
                    gvPayments.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
                }

                lblEmpName.Text = tbOrders.Rows[0]["EmpName"].ToString();
                lblCust.Text = tbOrders.Rows[0]["CustName"].ToString();
                lblAddress.Text = tbOrders.Rows[0]["Address"].ToString();

            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "HOA DON XUAT");
            }
        }
        private void btnReturnProduct_Click(object sender, EventArgs e)
        {
            try
            {
                frmReturnProduct obj = new frmReturnProduct();
                obj.GetSetOrder_ID = this.GetSetOrder_ID;
                obj.Form_Closing += frmEditOrders_Load;
                obj.ShowDialog();
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "TRA HANG");
            }
        }
        private void btnChangeProduct_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    frmChangeProduct obj = new frmChangeProduct();
            //    obj.GetSetOrder_ID = this.GetSetOrder_ID;
            //    obj.GetTotalAmount = this.GetTotalAmount;
            //    obj.Form_Closing += frmEditOrders_Load ;
            //    this.Hide();
            //    obj.ShowDialog();


            //}
            //catch (Exception ex)
            //{

            //    Program.MessagerErr(ex.ToString(), "DOI HANG");
            //}
        }
        private void frmEditOrders_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Form_Closing != null)
                {
                    Form_Closing(sender, e);
                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "CHINH SUA HOA DON");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string sErr = "";
                bool bValid = true;
                string strData = string.Empty;
                if (bValid)
                {
                    clsSQL = new QryData(Program.config.ConnectionString);
                    param = new QryParam();
                    clsSQL.BeginTrans();
                    int OrderID = Common.ParseInt(lblOrder_ID.Text);
                    int CountRows = tbDetails.Rows.Count;


                    decimal sumObject = 0;
                    sumObject = Common.ParseDecimal(tbDetails.Compute("Sum(Amount)", ""));
                    decimal totalMoneyOrder = sumObject + Common.ParseDecimal(totalno.Text);

                    string getPaymentOrderID = "select SUM(PaymentAmount ) from tbl_PaymentOrders where Order_ID = " + OrderID;
                    DataTable PaymentOrderID = clsSQL.GetTableSQL(getPaymentOrderID);
                    decimal Payment_Bill = Common.ParseDecimal(PaymentOrderID.Rows[0][0]);

                    if (Payment_Bill > totalMoneyOrder)
                    {
                        sErr = "Không thể cập nhật hóa đơn này";
                        Program.MessagerErr(sErr, "CHINH SUA HOA DON XUAT");
                        return;
                    }
                    else if (Payment_Bill > sumObject)
                    {
                        sErr = "Tổng tiền trong hóa đơn nhỏ hơn tổng tiền khách hàng đã trả";
                        Program.MessagerErr(sErr, "CHINH SUA HOA DON XUAT");
                        return;
                    }
                    #region xoa san pham da click button Delete tren luoi
                    if (GetDelete_Order != null)
                    {
                        foreach (DataRow dr in GetDelete_Order.Rows)
                        {
                            param.Clear();
                            param.Add("@OrderID", SqlDbType.Int, Common.ParseInt(dr["OrderID"]));
                            param.Add("@OrderDetail_ID", SqlDbType.Int, Common.ParseInt(dr["OrderDetail_ID"]));
                            param.Add("@Product_ID", SqlDbType.Int, Common.ParseInt(dr["Product_ID"]));
                            param.Add("@PriceImport", SqlDbType.Decimal, Common.ParseDecimal(dr["PriceImport"]));
                            param.Add("@Price", SqlDbType.Decimal, Common.ParseDecimal(dr["Price"]));
                            param.Add("@Quantity", SqlDbType.Int, Common.ParseInt(dr["Quantity"]));
                            param.Add("@QuantityPromotion", SqlDbType.Int, Common.ParseInt(dr["QuantityPromotion"]));
                            string outParmater = string.Empty;
                            clsSQL.ExecStore("spDelete_OrderDetails", param, out outParmater);
                            strData = strData + " " + outParmater;

                        }
                    }

                    #endregion

                    foreach (DataRow row in tbDetails.Rows)
                    {
                        int ProductID_tbDetails = 0;
                        string strDetail = Common.ParseString(row["strDetial_Selected"]);
                        ProductID_tbDetails = Common.ParseInt(strDetail.Split('_')[0]);
                        decimal Price = Common.ParseDecimal(row["Price"]);
                        decimal Price_Import = Common.ParseDecimal(row["Price_Import"]);

                        string checkAction = "select COUNT(*) from tbl_OrderDetails where Order_ID = " + OrderID + " and Product_ID = " + ProductID_tbDetails + "and Price = " + Price + " and Price_Import = " + Price_Import;
                        DataTable CheckEmpty_OrderDetail = clsSQL.GetTableSQL(checkAction);

                        if (Common.ParseInt(CheckEmpty_OrderDetail.Rows[0][0]) == 0) // insert moi order detail
                        {
                            #region
                            int Product_ID = ProductID_tbDetails;
                            param.Clear();
                            param.Add("@Order_ID", SqlDbType.Int, OrderID);
                            param.Add("@Product_ID", SqlDbType.Int, Product_ID);
                            param.Add("@Quantity", SqlDbType.Int, Common.ParseInt(row["Quantity"]));
                            param.Add("@QuantityPromotion", SqlDbType.Int, Common.ParseInt(row["QuantityPromotion"]));
                            param.Add("@DisCount", SqlDbType.SmallInt, Common.ParseInt(row["Discount"]));
                            param.Add("@PercentDiscount", SqlDbType.SmallInt, 0); // cot nay khong hien thi ra nua
                            param.Add("@Price", SqlDbType.Decimal, Price);
                            param.Add("@Form", SqlDbType.NVarChar, row["Form"].ToString());
                            param.Add("@Price_Import", SqlDbType.Decimal, Common.ParseDecimal(row["Price_Import"]));
                            string outParmater = string.Empty;
                            clsSQL.ExecStore("spODD_Ins", param, out outParmater);
                            strData = strData + " " + outParmater;
                            #endregion
                        }
                        else
                        {
                            #region "Update lai thog tin hoa don"
                            string checkEditDataOld = "select Product_ID,Quantity,QuantityPromotion,Discount,Form from tbl_OrderDetails where OrderDetail_ID =  " + Common.ParseInt(row["OrderDetail_ID"]);
                            DataTable OrderOld = clsSQL.GetTableSQL(checkEditDataOld);
                            int old_ProductID = Common.ParseInt(OrderOld.Rows[0]["Product_ID"]);
                            int old_Quantity = Common.ParseInt(OrderOld.Rows[0]["Quantity"]);
                            int old_QuantityPromotion = Common.ParseInt(OrderOld.Rows[0]["QuantityPromotion"]);
                            int old_DisCount = Common.ParseInt(OrderOld.Rows[0]["Discount"]);

                            int OrderDetail_ID = Common.ParseInt(row["OrderDetail_ID"]);
                            int Order_ID = Common.ParseInt(OrderID);
                            int Product_ID = ProductID_tbDetails;
                            int Quantity = Common.ParseInt(row["Quantity"]);
                            int QuantityPromotion = Common.ParseInt(row["QuantityPromotion"]);
                            int DisCount = Common.ParseInt(row["Discount"]);
                            int PercentDiscount = 0;
                            string Form = Common.ParseString(row["Form"]);
                            if (Product_ID != old_ProductID || Quantity != old_Quantity || QuantityPromotion != old_QuantityPromotion || DisCount != old_DisCount)
                            {
                                param.Clear();
                                param.Add("@OrderDetail_ID", SqlDbType.Int, OrderDetail_ID);
                                param.Add("@Order_ID", SqlDbType.Int, Order_ID);
                                param.Add("@Product_ID", SqlDbType.Int, Product_ID);
                                param.Add("@Quantity", SqlDbType.Int, Quantity);
                                param.Add("@QuantityPromotion", SqlDbType.Int, QuantityPromotion);
                                param.Add("@DisCount", SqlDbType.SmallInt, DisCount);
                                param.Add("@PercentDiscount", SqlDbType.SmallInt, 0); // cot nay khong hien thi ra nua
                                param.Add("@Price", SqlDbType.Decimal, Price);
                                param.Add("@Form", SqlDbType.NVarChar, Form);
                                param.Add("@Price_Import", SqlDbType.Decimal, Common.ParseDecimal(row["Price_Import"]));
                                string outParmater = string.Empty;
                                clsSQL.ExecStore("spODD_Edit", param, out outParmater);
                                strData = strData + " " + outParmater;
                            }
                            #endregion
                        }
                    }
                    #region // Check Value Gridview Payment
                    for (int i = 0; i < gvPayments.RowCount; i++)
                    {
                        DataTable dtPayment = new DataTable();
                        dtPayment = ((System.Data.DataView)(gvPayments.DataSource)).Table;
                        decimal TotalPayment_dtPayment = Common.ParseDecimal(dtPayment.Compute("Sum(PaymentAmount)", ""));
                        if (Payment_Bill == 0)
                        {
                            if (Common.ParseDecimal(TotalPayment_dtPayment) > totalMoneyOrder)
                            {
                                clsSQL.RollBackTrans();
                                sErr = "Vui lòng chỉnh lại số tiền đã trả cho hóa đơn.";
                                Program.MessagerErr(sErr, "HOA DON XUAT SP");
                                return;
                            }
                        }
                        string col0 = gvPayments.GetDataRow(i).ItemArray[0].ToString(); //0 Ma PaymentOrder_ID
                        string col1 = gvPayments.GetDataRow(i).ItemArray[1].ToString(); //0 Ma Hoa don
                        string col2 = gvPayments.GetDataRow(i).ItemArray[2].ToString(); //0 Ngay Tra Tien
                        string col3 = gvPayments.GetDataRow(i).ItemArray[3].ToString(); //0 So tien dc tra
                        string col4 = gvPayments.GetDataRow(i).ItemArray[4].ToString(); //0 note


                        if (Common.ParseInt(col0) == 0) // Insert tbl_Salaries
                        {
                            param = new QryParam();
                            param.Add("@Order_ID", SqlDbType.Int, this.GetSetOrder_ID);
                            param.Add("@OrderDate", SqlDbType.DateTime, Convert.ToDateTime(col2));
                            param.Add("@Amount", SqlDbType.Decimal, Convert.ToDecimal(col3));
                            param.Add("@Note", SqlDbType.NVarChar, col4);
                            param.Add("@CheckInsertSalaries", SqlDbType.Int, 0);
                            string outParmater = string.Empty;
                            clsSQL.ExecStore("spPaymentOrder_Ins", param, out outParmater);
                            strData = strData + " " + outParmater;
                        }
                        else // edit tbl_Salaries
                        {
                            param = new QryParam();
                            param.Add("@Order_ID", SqlDbType.Int, this.GetSetOrder_ID);
                            param.Add("@OrderDate", SqlDbType.DateTime, Convert.ToDateTime(col2));
                            param.Add("@Amount", SqlDbType.Decimal, Convert.ToDecimal(col3));
                            param.Add("@Note", SqlDbType.NVarChar, col4);
                            param.Add("@CheckInsertSalaries", SqlDbType.Int, 1);
                            string outParmater = string.Empty;
                            clsSQL.ExecStore("spPaymentOrder_Ins", param, out outParmater);
                            strData = strData + " " + outParmater;

                        }

                    }
                    #endregion
                    if (strData.Trim().Length > 0)
                    {
                        clsSQL.InsertLogData("spPro_InsertLogData", SettingCodeDB.listActions.Update.ToString(), Common.getPermissionType(SettingCodeDB.USERNAME_Admin, SettingCodeDB.PASSWORD_Admin).ToString(), SettingCodeDB.listScreens.frmEditOrders.ToString(), strData);
                    }
                    clsSQL.CommitTrans();
                    Program.MessagerInfo("Cập Nhật Hóa Đơn Xuất Thành Công", "CHỈNH SỬA HÓA ĐƠN XUẤT");
                    //frmEditOrders_Load(null, null);
                    updateData();
                    this.Close();
                }

                else
                {

                    Program.MessagerErr(sErr, "HOA DON XUAT");
                }

            }
            catch (Exception ex)
            {

                clsSQL.RollBackTrans();
                Program.MessagerErr(ex.ToString(), "HOA DON XUAT SP");
            }

        }

        private void dropPromotion_EditValueChanged(object sender, EventArgs e)
        {
            //var item = lookUpEdit1.GetSelectedDataRow() as Example;
        }
        private void gcOrderDetail_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && gvOrderDetail.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing && gvOrderDetail.FocusedRowHandle >= 0)
                {
                    if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa Sản Phẩm này?", "CHI TIET HOA DON", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        bool bValid = true;
                        string sErr = "";
                        int CountRows = gvOrderDetail.RowCount;
                        if (CountRows == 1)
                        {
                            bValid = false;
                            sErr = sErr + Environment.NewLine + "Không Thể Xóa 1 Sản Phẩm Còn Lại Trong Chi Tiết Hóa Đơn. \n Vui Lòng Chọn Hóa Đơn Cần Xóa Và Nhấn Phím Delete.";
                            Program.MessagerErr(sErr, "HOA DON XUAT");
                        }
                        else
                        {

                            //int OrderIDCurrent = (int)gvOrderDetail.GetRowCellValue(gvOrderDetail.FocusedRowHandle, "OrderID");
                            int OrderDetail_IDCurrent = Common.ParseInt(gvOrderDetail.GetRowCellValue(gvOrderDetail.FocusedRowHandle, "OrderDetail_ID"));
                            int Product_IDCurrent = Common.ParseInt(gvOrderDetail.GetRowCellValue(gvOrderDetail.FocusedRowHandle, "Product_ID"));
                            decimal PriceCurrent = Common.ParseDecimal(gvOrderDetail.GetRowCellValue(gvOrderDetail.FocusedRowHandle, "Price"));

                            decimal PriceImport = Common.ParseDecimal(gvOrderDetail.GetRowCellValue(gvOrderDetail.FocusedRowHandle, "Price_Import"));

                            int QuantityCurrent = Common.ParseInt(gvOrderDetail.GetRowCellValue(gvOrderDetail.FocusedRowHandle, "Quantity"));
                            int QuantityPromotionCurrent = Common.ParseInt(gvOrderDetail.GetRowCellValue(gvOrderDetail.FocusedRowHandle, "QuantityPromotion"));

                            string strProductName = Common.ParseString(gvOrderDetail.GetRowCellValue(gvOrderDetail.FocusedRowHandle, "ProductName"));

                            if (QuantityCurrent == 0 && QuantityPromotionCurrent == 0)
                            {
                                QuantityCurrent = Common.ParseInt(gvOrderDetail.GetRowCellValue(gvOrderDetail.FocusedRowHandle, "oldQty"));
                                QuantityPromotionCurrent = Common.ParseInt(gvOrderDetail.GetRowCellValue(gvOrderDetail.FocusedRowHandle, "oldQtyPromotion"));
                            }

                            decimal TotalMoney_Delete = QuantityCurrent * PriceCurrent;
                            if (Common.ParseDecimal(this.GetTotalpayment) < TotalMoney_Delete)
                            {
                                sErr = "Không thể xóa sản phẩm " + strProductName + " ! Gì đã vượt quá số tiền khách hàng còn nợ.";
                                Program.MessagerErr(sErr, "HOA DON XUAT");
                            }
                            else
                            {
                                DataTable dtNewDelete = new DataTable();
                                dtNewDelete.Columns.Add("OrderID");
                                dtNewDelete.Columns.Add("OrderDetail_ID");
                                dtNewDelete.Columns.Add("Product_ID");
                                dtNewDelete.Columns.Add("PriceImport");
                                dtNewDelete.Columns.Add("Price");
                                dtNewDelete.Columns.Add("Quantity");
                                dtNewDelete.Columns.Add("QuantityPromotion");
                                dtNewDelete.Rows.Add(this.GetSetOrder_ID, OrderDetail_IDCurrent, Product_IDCurrent, PriceImport, PriceCurrent, QuantityCurrent, QuantityPromotionCurrent);
                                DataTable dtNewDelete_AddRow = new DataTable();
                                if (GetDelete_Order != null)
                                {
                                    dtNewDelete_AddRow = GetDelete_Order;
                                    dtNewDelete_AddRow.Rows.Add(this.GetSetOrder_ID, OrderDetail_IDCurrent, Product_IDCurrent, PriceImport, PriceCurrent, QuantityCurrent, QuantityPromotionCurrent);
                                    GetDelete_Order = dtNewDelete_AddRow;
                                }
                                else
                                {
                                    GetDelete_Order = dtNewDelete;
                                }
                                tbDetails.Rows.RemoveAt(gvOrderDetail.FocusedRowHandle);
                                totalno.Text = String.Format("{0:N0}", (Common.ParseDecimal(totalno.Text) - TotalMoney_Delete));

                                //totalno.Text = String.Format("{0:N0}", (Common.ParseDecimal(this.GetTotalpayment) - TotalMoney_Delete));
                            }
                            // updateData();
                        }
                    }
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    ProductID_Selected = 0;
                    checkExist = 0;
                    PriceImport_Selected = 0;
                    Price_Selected = 0;
                    strMsg = "";
                }
            }
            catch (Exception ex)
            {
                Program.MessagerErr(ex.ToString(), "HOA DON XUAT");
            }
        }


        public void SetValueComboboxProductName()
        {
            #region Add value for Combobox ProductName
            DataTable tbProName = new DataTable();
            string strSql = "select distinct pr.Product_ID,pr.ProductName,pri.Price ,pri.PriceActual_Import, pri.Quantity,(convert(varchar,pr.Product_ID)+'_'+convert(varchar,convert(decimal,pri.Price)) +'_'+convert(varchar,convert(decimal,pri.PriceActual_Import))) as strDetial_Selected from tbl_Products pr,tbl_ProductPrices pri where pr.Product_ID not in (0) and pr.Product_ID = pri.Product_ID and pri.Price > 0";// and pri.Quantity > 0
            tbProName = clsSQL.GetTableSQL(strSql);
            colProductName_Edit.DataSource = tbProName;
            colProductName_Edit.DisplayMember = "ProductName";
            colProductName_Edit.ValueMember = "strDetial_Selected";
            // colProductName_Edit.ValueMember = "PriceActual_Import";

            //colProductName_Edit.Properties.PopulateColumns();
            // colProductName_Edit.Properties.Columns["Product_ID"].Visible = false;
            #endregion

        }

        private void btnReturnProducts_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    frmReturnProduct obj = new frmReturnProduct();
            //    obj.GetSetOrder_ID = this.GetSetOrder_ID;
            //    obj.GetTotalAmount = this.GetTotalAmount;
            //   obj.Form_Closing += frmEditOrders_Load;
            //   this.Hide();
            //    obj.ShowDialog();


            //}
            //catch (Exception ex)
            //{

            //    Program.MessagerErr(ex.ToString(), "DOI HANG");
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void colProductName_Edit_EditValueChanged(object sender, EventArgs e)
        {

            //colODD_Quantity.OptionsColumn.AllowEdit = true;
            //colTypePromotion.OptionsColumn.AllowEdit = true;

            //colODD_Discount.OptionsColumn.AllowFocus = true;
            //colODD_Quantity.OptionsColumn.AllowFocus = true;
            //colTypePromotion.OptionsColumn.AllowFocus = true;
            //colTypePromotion.OptionsColumn.AllowFocus = true;
            //colODD_QtyPromotion.OptionsColumn.AllowFocus = true;

            DevExpress.XtraEditors.LookUpEdit editor = (sender as DevExpress.XtraEditors.LookUpEdit);
            DataRowView row = editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue) as DataRowView;
            string strDetail = Common.ParseString(row["strDetial_Selected"]);
            ProductID_Selected = Common.ParseInt(strDetail.Split('_')[0]);
            string productName = Common.ParseString(row["ProductName"]);
            PriceImport_Selected = Common.ParseDecimal(row["PriceActual_Import"]);
            Price_Selected = Common.ParseDecimal(row["Price"]);
            intProductID = ProductID_Selected;

            DevExpress.XtraGrid.Views.Grid.GridView view = gvOrderDetail;
            comboboxPrice_Edit.Items.Clear();
            comboboxPrice_Edit.Items.Add(Price_Selected);
            view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Price"], comboboxPrice_Edit.Items[0]);
            view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Price_Import"], PriceImport_Selected);
            view.SetRowCellValue(view.FocusedRowHandle, view.Columns["strDetial_Selected"], strDetail);



            #region validation productID
            for (int i = 0; i < gvOrderDetail.RowCount; i++)
            {
                int col1 = Common.ParseInt(gvOrderDetail.GetRowCellValue(i, "Product_ID").ToString());// ma sp
                decimal col2 = Common.ParseDecimal(gvOrderDetail.GetRowCellValue(i, "Price_Import").ToString());// price_Import
                decimal col3 = Common.ParseDecimal(gvOrderDetail.GetRowCellValue(i, "Price").ToString());// priceSale
                if (col1 == 0)
                {
                    string strFullPar = gvOrderDetail.GetRowCellValue(i, "strDetial_Selected").ToString();// ma sp
                    col1 = Common.ParseInt(strFullPar.Split('_')[0]);

                }
                if (ProductID_Selected == col1 && col2 == PriceImport_Selected && col3 == Price_Selected)
                {
                    checkExist = 1;
                    strMsg = "Sản phẩm này đã có trong hóa đơn";
                    break;
                }
            }
            #endregion

        }

        public void setDeaultGrid()
        {
            //colODD_Discount.OptionsColumn.AllowFocus = false;
            //colODD_Quantity.OptionsColumn.AllowFocus = false;
            //colTypePromotion.OptionsColumn.AllowFocus = false;
            //colTypePromotion.OptionsColumn.AllowFocus = false;
            //colODD_QtyPromotion.OptionsColumn.AllowFocus = false;

            //colODD_Quantity.OptionsColumn.AllowEdit = false;
            //colTypePromotion.OptionsColumn.AllowEdit = false;
            //colTypePromotion.OptionsColumn.AllowEdit = false;
            //colODD_QtyPromotion.OptionsColumn.AllowEdit = false;
        }

        #endregion

        #region gvOrderDetail
        private void gvOrderDetail_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gvOrderDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {

                e.Info.DisplayText = (e.RowHandle + 1).ToString();

            }
        }

        private void gvOrderDetail_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (e.FocusedRowHandle == 0)
            //{
            colODD_ProName.OptionsColumn.AllowEdit = e.FocusedRowHandle == Program.NEW_ROW;
            colTypePromotion.OptionsColumn.AllowEdit = e.FocusedRowHandle == Program.NEW_ROW;
            colODD_Price.OptionsColumn.AllowEdit = e.FocusedRowHandle == Program.NEW_ROW;
            //}
        }

        private void gvOrderDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "Product_ID")
                {
                    intProductID = Common.ParseInt(e.Value);
                }

                if (e.Column.FieldName == "Form")
                {
                    if (e.Value.ToString() == SettingCodeDB.TypePromotion_Discount)
                    {
                        colODD_Discount.OptionsColumn.AllowEdit = true;
                        colODD_QtyPromotion.OptionsColumn.AllowEdit = false;
                        //gvOrderDetail.SetRowCellValue(e.RowHandle, "Discount", DBNull.Value);
                        //gvOrderDetail.SetRowCellValue(e.RowHandle, "QuantityPromotion", 0);
                    }
                    else if (e.Value.ToString() == SettingCodeDB.TypePromotion_Product)
                    {
                        colODD_Discount.OptionsColumn.AllowEdit = false;
                        colODD_QtyPromotion.OptionsColumn.AllowEdit = true;
                        //gvOrderDetail.SetRowCellValue(e.RowHandle, "Discount", 0);
                        //gvOrderDetail.SetRowCellValue(e.RowHandle, "QuantityPromotion", DBNull.Value);
                    }
                    else if (e.Value.ToString() == SettingCodeDB.TypePromotion_Product_Discount)
                    {
                        colODD_Discount.OptionsColumn.AllowEdit = true;
                        colODD_QtyPromotion.OptionsColumn.AllowEdit = true;
                        //gvOrderDetail.SetRowCellValue(e.RowHandle, "Discount", DBNull.Value);
                        //gvOrderDetail.SetRowCellValue(e.RowHandle, "QuantityPromotion", DBNull.Value);
                    }
                    else
                    {
                        colODD_Discount.OptionsColumn.AllowEdit = false;
                        colODD_QtyPromotion.OptionsColumn.AllowEdit = false;
                        //gvOrderDetail.SetRowCellValue(e.RowHandle, "Discount", 0);
                        //gvOrderDetail.SetRowCellValue(e.RowHandle, "QuantityPromotion", 0);
                    }
                }

                if (e.Column.FieldName == "Product_ID")
                {
                    int intProductId = Common.ParseInt(e.Value);
                    #region validation productID
                    for (int i = 0; i < gvOrderDetail.RowCount; i++)
                    {
                        int col0 = Common.ParseInt(gvOrderDetail.GetRowCellValue(i, "Product_ID"));

                        if (intProductId == col0)
                        {
                            checkExist = 1;
                            strMsg = "Sản phẩm này đã có trong hóa đơn";
                            break;
                        }
                    }
                    #endregion

                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "KHUYEN MAI");
            }
        }

        private void gvOrderDetail_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                // gvOrderDetail.SetRowCellValue(e.RowHandle, "strDetial_Selected", "CHỌN SẢN PHẨM");
                gvOrderDetail.SetRowCellValue(e.RowHandle, "Quantity", DBNull.Value);
                //gvOrderDetail.SetRowCellValue(e.RowHandle, "Form", DBNull.Value);
                gvOrderDetail.SetRowCellValue(e.RowHandle, "QuantityPromotion", DBNull.Value);
                gvOrderDetail.SetRowCellValue(e.RowHandle, "PercentPromotion", DBNull.Value);
                gvOrderDetail.SetRowCellValue(e.RowHandle, "Price", DBNull.Value);
                gvOrderDetail.SetRowCellValue(e.RowHandle, "PriceSell", DBNull.Value);


            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "HOA DON XUAT SP");
            }
        }

        private void gvOrderDetail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                bool bVali = true;
                int Product_Extist = 0;
                int ItemProductID = 0;
                int Product_ID = 0;
                decimal Price = 0;
                int QtyCurrent = 0;
                int QtyPromotionCurrent = 0;
                int QtyRemainder = 0;
                Decimal Percent = 0;
                string TypePromotion = "";
                decimal PriceTemp = 0;
                int oldQty = 0;
                int oldQtyPromotion = 0;
                string sErr = "";

                if (e.RowHandle < 0)
                {
                    if (ProductID_Selected == 0)
                    {
                        sErr = "Vui lòng chọn sản phẩm.";
                        e.Valid = false;
                        Program.MessagerErr(sErr, "HOA DON XUAT SP");
                        return;
                    }
                    if (checkExist == 1)
                    {
                        sErr = strMsg;
                        e.Valid = false;
                        Program.MessagerErr(sErr, "HOA DON XUAT SP");
                        return;
                    }
                }
                else
                {
                    ProductID_Selected = Common.ParseInt(gvOrderDetail.GetRowCellValue(gvOrderDetail.FocusedRowHandle, "Product_ID"));
                    Price_Selected = Common.ParseDecimal(gvOrderDetail.GetRowCellValue(gvOrderDetail.FocusedRowHandle, "Price"));
                    PriceImport_Selected = Common.ParseDecimal(gvOrderDetail.GetRowCellValue(gvOrderDetail.FocusedRowHandle, "Price_Import"));
                }


                #region Check Data
                if (checkExist == 1)
                {
                    bVali = false;
                    sErr = strMsg;
                    Product_Extist = 1;
                }
                else
                {
                    Product_ID = ProductID_Selected;
                    Price = Price_Selected;
                    // check so luong ton kho
                    string strGetQtyRemainder = "select Quantity from tbl_ProductPrices where Product_ID =" + Product_ID + " and Price =" + Price + "And PriceActual_Import = " + PriceImport_Selected;
                    DataTable tbTempGetQty = new DataTable();
                    tbTempGetQty = clsSQL.GetTableSQL(strGetQtyRemainder);
                    QtyRemainder = Common.ParseInt(tbTempGetQty.Rows[0]["Quantity"].ToString());

                    // Infor tren hoa don
                    QtyCurrent = Common.ParseInt(gvOrderDetail.GetRowCellValue(e.RowHandle, "Quantity"));
                    QtyPromotionCurrent = Common.ParseInt(gvOrderDetail.GetRowCellValue(e.RowHandle, "QuantityPromotion"));

                    Percent = Common.ParseDecimal(gvOrderDetail.GetRowCellValue(e.RowHandle, "Discount"));
                    TypePromotion = Common.ParseString(gvOrderDetail.GetRowCellValue(e.RowHandle, "Form"));
                    PriceTemp = Price_Selected;
                    oldQty = Common.ParseInt(gvOrderDetail.GetRowCellValue(e.RowHandle, "oldQty"));
                    oldQtyPromotion = Common.ParseInt(gvOrderDetail.GetRowCellValue(e.RowHandle, "oldQtyPromotion"));
                    ItemProductID = Product_ID;

                }
                if (Product_Extist == 0)
                {

                    if (ItemProductID == 0)
                    {
                        sErr = sErr + Environment.NewLine + "Vui lòng chọn Sản Phẩm.";
                        bVali = false;
                    }
                    if (!string.IsNullOrEmpty(gvOrderDetail.GetRowCellValue(e.RowHandle, "Quantity").ToString()) == true)
                    {
                        if (Convert.ToInt32(gvOrderDetail.GetRowCellValue(e.RowHandle, "Quantity")) <= 0)
                        {
                            sErr = sErr + Environment.NewLine + "Vui Lòng nhập số lượng phải lớn hơn 0.";
                            bVali = false;
                        }

                    }
                    else
                    {
                        sErr = sErr + Environment.NewLine + "Vui lòng nhập số lượng";
                        bVali = false;
                    }
                    int totalQtyRemainder = QtyRemainder + (oldQty + oldQtyPromotion);
                    int totalNewQty = QtyCurrent + QtyPromotionCurrent;

                    //int totalQtyPromotionRemainder = oldQtyPromotion;
                    //int totalNewPromotion = QtyPromotionCurrent;

                    if (totalNewQty > totalQtyRemainder)
                    {
                        sErr = sErr + Environment.NewLine + "Vui Lòng Nhập Số Lượng Không Thể Vượt Quá " + totalQtyRemainder;
                        bVali = false;
                    }
                    // validation promotion Data
                    if ((totalNewQty) > totalQtyRemainder)
                    {
                        string Quantity = (totalQtyRemainder - totalNewQty) < 0 ? "0" : (totalQtyRemainder - totalNewQty).ToString();
                        sErr = sErr + Environment.NewLine + "Vui Lòng Nhập Số Lượng Khuyến Mãi Không Thể Vượt Quá " + Quantity;
                        bVali = false;
                    }

                    #region Validation Promotion
                    if (TypePromotion == SettingCodeDB.TypePromotion_Product)
                    {
                        if (QtyPromotionCurrent == 0)
                        {
                            sErr = sErr + Environment.NewLine + "Vui Lòng Nhập Số Lượng Khuyến Mãi.";
                            bVali = false;
                        }
                    }
                    if (TypePromotion == SettingCodeDB.TypePromotion_Discount)
                    {
                        if (Percent == 0)
                        {
                            sErr = sErr + Environment.NewLine + "Vui Lòng Nhập % Chiết Khấu.";
                            bVali = false;
                        }
                        if (Percent < 0)
                        {
                            sErr = sErr + Environment.NewLine + "Vui Lòng Nhập % Chiết Khấu Phải Lớn Hơn 0";
                            bVali = false;
                        }
                    }
                    if (TypePromotion == SettingCodeDB.TypePromotion_Product_Discount)
                    {
                        if (QtyPromotionCurrent == 0)
                        {
                            sErr = sErr + Environment.NewLine + "Vui Lòng Nhập Số Lượng Khuyến Mãi.";
                            bVali = false;
                        }
                        if (Percent == 0)
                        {
                            sErr = sErr + Environment.NewLine + "Vui Lòng Nhập % Khuyến Mãi.";
                            bVali = false;
                        }

                    }
                    #endregion

                    if (!string.IsNullOrEmpty(gvOrderDetail.GetRowCellValue(e.RowHandle, "QuantityPromotion").ToString()) == true)
                    {
                        if (Convert.ToInt32(gvOrderDetail.GetRowCellValue(e.RowHandle, "QuantityPromotion")) < 0)
                        {
                            sErr = sErr + Environment.NewLine + "Vui lòng nhập số lượng khuyến mại phải lớn hơn 0.";
                            bVali = false;
                        }
                    }


                }
                if (bVali)
                {
                    #region check Amount
                    decimal dAmount = 0;
                    if (Percent != 0)
                    {
                        dAmount = (QtyCurrent * PriceTemp) - ((QtyCurrent * PriceTemp) * (Percent) / 100);
                    }
                    if (Percent == 0)
                    {
                        dAmount = (QtyCurrent * PriceTemp);
                    }
                    gvOrderDetail.SetRowCellValue(e.RowHandle, "Amount", dAmount);
                    gvOrderDetail.SetRowCellValue(e.RowHandle, "Price_Import", PriceImport_Selected);
                    gvOrderDetail.SetRowCellValue(e.RowHandle, "Price", Price_Selected);

                    ProductID_Selected = 0;
                    checkExist = 0;
                    PriceImport_Selected = 0;
                    Price_Selected = 0;

                    setDeaultGrid();
                    #endregion
                }
                else
                {
                    e.Valid = false;
                    Program.MessagerErr(sErr, "HOA DON XUAT SP");
                }
                #endregion

            }
            catch (Exception ex)
            {
                clsSQL.RollBackTrans();
                Program.MessagerErr(ex.ToString(), "HOA DON XUAT SP");
            }
        }
        #endregion

        #region gvPayments
        private void gvPayments_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            try
            {
                e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
            }
            catch (Exception ex)
            {
                Program.MessagerErr(ex.ToString(), "CHI TRA");
            }
        }
        private void gvPayments_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                gvPayments.SetRowCellValue(e.RowHandle, "PaymentOrderDate", DateTime.Now);
                //gvPayments.SetRowCellValue(e.RowHandle, "PaymentAmount", DBNull.Value);
                //gvPayments.SetRowCellValue(e.RowHandle, "Note", "");
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "CHI TRA");
            }
        }
        private void gvPayments_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                decimal dTotalAmount = 0;
                string sErr = "";
                bool bValid = true;

                if (gvPayments.GetRowCellValue(e.RowHandle, "PaymentOrderDate") == null)
                {
                    sErr = sErr + Environment.NewLine + "Vui lòng chọn ngày trả tiền.";
                    bValid = false;
                }
                if (Common.ParseDecimal(gvPayments.GetRowCellValue(e.RowHandle, "PaymentAmount")) <= 0)
                {
                    sErr = sErr + Environment.NewLine + "Vui lòng nhập số tiền.";
                    bValid = false;
                }
                else
                {

                    foreach (DataRow row in tbPayments.Rows)
                    {
                        dTotalAmount = dTotalAmount + Convert.ToDecimal(row["PaymentAmount"]);
                    }
                    //dTotalAmount = dTotalAmount +Convert.ToDecimal( gvPayments.GetRowCellValue(e.RowHandle, "PaymentAmount"));

                    if ((dTotalAmount) > Convert.ToDecimal(colODD_Amount.SummaryItem.SummaryValue))
                    {
                        sErr = sErr + Environment.NewLine + "Số tiền không được vượt quá:" + Convert.ToDouble((Convert.ToDecimal(colODD_Amount.SummaryItem.SummaryValue) - dTotalAmount)).ToString();
                        bValid = false;
                    }
                }
                if (bValid)
                {
                    GetTotalpayment = (Convert.ToDecimal(strTotalAmount) - Convert.ToDecimal(dTotalAmount)).ToString();
                    //(Convert.ToDecimal(totalno.Text) - Convert.ToDecimal(gvPayments.GetRowCellValue(e.RowHandle, "PaymentAmount"))).ToString();

                    totalno.Text = String.Format("{0:N0}", Common.ParseDecimal(GetTotalpayment));
                }
                else
                {
                    e.Valid = false;
                    Program.MessagerErr(sErr, "CHI TRA");
                }

            }
            catch (Exception ex)
            {
                clsSQL.RollBackTrans();
                Program.MessagerErr(ex.ToString(), "CHI TRA");
            }
        }
        private void gvPayments_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (e.FocusedRowHandle < 0 || e.FocusedRowHandle == Program.NEW_ROW)
                {
                    gvPayments.OptionsBehavior.Editable = true;

                }
                else
                {
                    gvPayments.OptionsBehavior.Editable = true;
                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "CHI TRA");
            }
        }


        #endregion

        private void gcPayments_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                decimal dTotalAmount = 0;
                if (e.KeyCode == Keys.Delete && gvOrderDetail.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing && gvOrderDetail.FocusedRowHandle >= 0)
                {
                    if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa số tiền đã trả ?", "CHI TIET HOA DON", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        tbPayments.Rows.RemoveAt(gvPayments.FocusedRowHandle);

                        foreach (DataRow row in tbPayments.Rows)
                        {
                            dTotalAmount = dTotalAmount + Convert.ToDecimal(row["PaymentAmount"]);
                        }
                        GetTotalpayment = (Convert.ToDecimal(strTotalAmount) - Convert.ToDecimal(dTotalAmount)).ToString();
                       totalno.Text = String.Format("{0:N0}", Common.ParseDecimal(GetTotalpayment));


                    }
                }
            }
            catch (Exception ex)
            {
                Program.MessagerErr(ex.ToString(), "HOA DON XUAT");
            }
        }
    }
}