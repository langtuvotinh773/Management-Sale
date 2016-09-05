using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
//using Management.Commons.SQL;
using System.Data;
using Management.Commons;
using System.Threading;
using Management.Commons.SQL;
using System.Data.SqlClient;
namespace Management.Products
{
    public partial class frmCreatNewImport : DevExpress.XtraEditors.XtraForm
    {
        #region VARIABLES

        public delegate void CapNhatDuLieu();
        public CapNhatDuLieu updateData;

        int checkAction = 0;
        String moneyPayment;
        string ItemProductName = "", strTotalAmount = "", strHaveAmount = "";
        int addProduct = 0, iOrder_ID = 0;
        int checkExist = 0;
        string strMsg = "";
        public string GetTotalpayment
        {
            get { return moneyPayment; }
            set { moneyPayment = value; }
        }
        public frmCreatNewImport()
        {
            InitializeComponent();
        }
        DataTable dtNew;
        public DataTable GetDelete_ImportOrder
        {
            get { return dtNew; }
            set { dtNew = value; }
        }
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
        public string getHaveAmount
        {
            get { return strHaveAmount; }
            set { strHaveAmount = value; }
        }
        public event EventHandler Form_Closing;

        QryData clsSQL;
        QryParam param;


        DataTable tbProducts, tbPaymentTemps, tbImportOrders, tbImportOrderDetails, tbPayments, tbTemps;



        int iImportOrder_ID;

        bool bIsLock;
        int iPrice = 0;
        int iiEnabled = 0;
        #endregion

        #region SUB AND FUNCTION

        public int GetSetImportOrder_ID
        {
            get { return iImportOrder_ID; }
            set { iImportOrder_ID = value; }
        }

        bool checkOrderCompany(string sOrderCompany)
        {
            bool iVaild = true;
            try
            {
                // Kiểm tra xem mã hóa đơn của khách hàng đã có chưa khi bấm nút tạo hóa đơn
                if (sOrderCompany == "")
                {
                    iVaild = false;
                }
                else
                {
                    // Code here to check OrderCompany
                    string sQueryOrderCompany = "SElect OrderCompany_ID From tbl_ImportOrders where OrderCompany_ID = '" + sOrderCompany + "'";
                    clsSQL = new QryData(Program.config.ConnectionString);
                    param = new QryParam();
                    DataTable dt = new DataTable();
                    dt = clsSQL.GetTableSQL(sQueryOrderCompany);
                    if (dt.Rows.Count == 0)
                    {
                        iVaild = true;
                    }
                    else
                    { iVaild = false; }

                }
            }
            catch (Exception e)
            {

                Program.MessagerErr(e.ToString(), "HOA DON NHAP");
            }
            return iVaild;
        }


        void Print()
        {
            if (xtabMain.SelectedTabPageIndex == 0)
            {
                gcImportOrder.ShowPrintPreview();
            }
            else
            {
                gcPayment.ShowPrintPreview();
            }
        }

        #endregion

        #region     EVENTS

        private void frmCreatNewImport_Load(object sender, EventArgs e)
        {
            //Chia thành 2 trường hợp: Tạo mới và sửa hóa đơn nhập
            try
            {

                if (uctImportOrder.getset_rdOrder)
                {
                    rdOrder.Checked = uctImportOrder.getset_rdOrder;
                }
                else
                {
                    rdChangeProduct.Checked = uctImportOrder.getset_rdOrder;
                }
                if (this.GetTotalpayment == null || this.GetTotalpayment == "")
                {
                    txtOrderCompany_ID.Text = DateTime.Now.ToString("ddMMyyyy_H-m-s");
                    totalNO.Hide();
                    labelControl4.Hide();

                    col_PIDate.OptionsColumn.AllowFocus = false;
                    col_PINote.OptionsColumn.AllowFocus = false;
                    col_PIAmount.OptionsColumn.AllowFocus = false;

                }
                else
                {
                    checkAction = 1;
                    iiEnabled = 1;
                    //labelControl3.Hide();
                    //txtCast.Hide();
                    //txtCast.Enabled = false;
                    double y = double.Parse(this.GetTotalpayment);
                    totalNO.Text = String.Format("{0:0,0}", y);
                    gvPayment.OptionsView.EnableAppearanceOddRow = true;
                    rdChangeProduct.Visible = false;
                }
                clsSQL = new QryData(Program.config.ConnectionString);
                param = new QryParam();
                string sQueryCompany = "Select Company_ID, CompanyName, Address From tbl_Companies Order by CompanyName";
                cboCompany.Properties.DataSource = clsSQL.GetTableSQL(sQueryCompany);
                cboCompany.Properties.DisplayMember = "CompanyName";
                cboCompany.Properties.ValueMember = "Company_ID";
                if (this.GetSetImportOrder_ID == 0)
                {
                    txtOrderCompany_ID.Enabled = true;

                    // cboCompany.ItemIndex = 0;
                    // Add source to Gridview
                    tbProducts = new DataTable();

                    tbProducts.Columns.Add(new DataColumn("ProductName"));
                    tbProducts.Columns.Add(new DataColumn("Quantity"));
                    tbProducts.Columns.Add(new DataColumn("QuantityPromotion"));
                    tbProducts.Columns.Add(new DataColumn("PercentPromotion"));
                    tbProducts.Columns.Add(new DataColumn("Discount"));
                    tbProducts.Columns.Add(new DataColumn("Amount"));
                    tbProducts.Columns.Add(new DataColumn("Price"));
                    tbProducts.Columns.Add(new DataColumn("PriceSell"));
                    tbProducts.AcceptChanges();
                    gcImportOrder.DataSource = tbProducts;
                    // Payment
                    tbPaymentTemps = new DataTable();
                    tbPaymentTemps.Columns.Add(new DataColumn("DatePayment"));
                    tbPaymentTemps.Columns.Add(new DataColumn("PaymentAmount"));
                    tbPaymentTemps.Columns.Add(new DataColumn("Note"));
                    gcPayment.DataSource = tbPaymentTemps;
                    //
                    gvImportOrder.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                    gvPayment.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

                }
                else
                {
                    ////////////////////////////////////////////////////////////
                    tbPaymentTemps = new DataTable();
                    tbPaymentTemps.Columns.Add(new DataColumn("DatePayment"));
                    tbPaymentTemps.Columns.Add(new DataColumn("PaymentAmount"));
                    tbPaymentTemps.Columns.Add(new DataColumn("Note"));
                    gcPayment.DataSource = tbPaymentTemps;
                    gvPayment.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;


                    /////////////////////////////////////////////////////
                    txtOrderCompany_ID.Enabled = false;
                    txtCast.Enabled = false;
                    tbImportOrders = new DataTable();
                    tbImportOrderDetails = new DataTable();
                    tbPayments = new DataTable();
                    string sQueryImportOrder = "Select ImportOrder_ID,OrderCompany_ID, ImportOrderDate, Company_ID, IsLock,Convert(Float,CastPromotion) as CastPromotion From tbl_ImportOrders Where ImportOrder_ID=@ImportOrder_ID";
                    string sQueryImportOrderDetail = "spIOD_List";
                    string sQueryPayment = "spPI_List";
                    param.Add("@ImportOrder_ID", SqlDbType.Int, this.GetSetImportOrder_ID);
                    tbImportOrders = clsSQL.GetTableSQL(sQueryImportOrder, param);
                    
                    
                    // Details
                    param = param.Copy();
                    tbImportOrderDetails = clsSQL.GetTableStore(sQueryImportOrderDetail, param);


                    gcImportOrder.DataSource = tbImportOrderDetails;

                    tbTemps = tbImportOrderDetails;
                    // Payments
                    param = param.Copy();
                    tbPayments = clsSQL.GetTableStore(sQueryPayment, param);
                    gcPayment.DataSource = tbPayments;

                    //hh
                    int Company_ID = Common.ParseInt(tbImportOrders.Rows[0]["Company_ID"]);
                    cboCompany.EditValue = Company_ID;
                    cboCompany.Enabled = false;

                    txtOrderCompany_ID.Text = tbImportOrders.Rows[0]["OrderCompany_ID"].ToString();
                    txtCast.Text = tbImportOrders.Rows[0]["CastPromotion"].ToString();
                    bIsLock = Convert.ToBoolean(tbImportOrders.Rows[0]["IsLock"]);

                    btnCreate.Enabled = !Convert.ToBoolean(this.GetSetImportOrder_ID);
                    if (bIsLock)
                    {
                        gvImportOrder.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                        gvPayment.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                        gvImportOrder.OptionsBehavior.Editable = false;
                        gvPayment.OptionsBehavior.Editable = false;
                        txtCast.Enabled = false;
                        btnSave.Enabled = false;
                    }
                    else
                    {
                        gvImportOrder.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
                        gvPayment.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
                        gvImportOrder.OptionsBehavior.Editable = true;
                        gvPayment.OptionsBehavior.Editable = true;
                        txtCast.Enabled = true;
                        btnSave.Enabled = true;
                    }

                }



            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "HOA DON NHAP");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string strData = string.Empty;
                string sErr = "";
                clsSQL = new QryData(Program.config.ConnectionString);
                param = new QryParam();
                DataView dataView;
                DataRow cet = gvImportOrder.GetDataRow(1);
                // intCheckAction = 0; Add
                // intCheckAction = 1; Edit
                clsSQL.BeginTrans();

                #region xoa san pham da click button Delete tren luoi
                if (GetDelete_ImportOrder != null)
                {
                    foreach (DataRow dr in GetDelete_ImportOrder.Rows)
                    {
                        param.Clear();
                        param.Add("@ImportOrderDetail_ID", SqlDbType.Int, Common.ParseInt(dr["ImportOrderDetail_ID"]));

                        string outParmater = string.Empty;
                        clsSQL.ExecStore("spIOD_Del", param, out outParmater);
                        strData = strData + " " + outParmater;
                    }
                }
                #endregion


                if (rdOrder.Checked)
                {
                    decimal TotalMoney_ImportOrder = 0;
                    decimal TotalPaymentMoney = 0;
                    for (int i = 0; i < gvImportOrder.RowCount; i++)
                    {
                        TotalMoney_ImportOrder += Common.ParseDecimal(gvImportOrder.GetRowCellValue(i, "Amount").ToString());//9 Thanh Tien
                    }
                    for (int i = 0; i < gvPayment.RowCount; i++)
                    {
                        TotalPaymentMoney += Common.ParseDecimal(gvPayment.GetRowCellValue(i, "PaymentAmount").ToString());//9 Thanh Tien
                    }

                    if (Common.ParseDecimal(getHaveAmount) > TotalMoney_ImportOrder || TotalMoney_ImportOrder < TotalPaymentMoney)
                    {
                        sErr = "Không thể cập nhật hóa đơn này";
                        Program.MessagerErr(sErr, "CHINH SUA HOA DON NHAP HANG");
                        return;
                    }

                    #region Type Import Order
                    // check price Actual
                    decimal totalQuantity = 0;
                    decimal castOnOnceProduct = 0;
                    DataTable dt_Current = new DataTable();
                    DataView dv = new DataView();
                    dv = (DataView)gvImportOrder.DataSource;
                    dt_Current = dv.ToTable();
                    foreach (DataRow dr in dt_Current.Rows)
                    {
                        totalQuantity = totalQuantity + (Common.ParseDecimal(dr["Quantity"]) + Common.ParseDecimal(dr["QuantityPromotion"]));
                    }
                    castOnOnceProduct = Common.ParseDecimal(txtCast.Text) / totalQuantity;

                    if (checkAction == 1)
                    {

                        #region Action Edit
                        for (int i = 0; i < gvImportOrder.RowCount; i++)
                        {


                            string col0 = Common.ParseString(gvImportOrder.GetRowCellValue(i, "ImportOrderDetail_ID")); //0 Ma chi tiet hoa don
                            string col1 = Common.ParseString(gvImportOrder.GetRowCellValue(i, "ProductName"));//1 ten sp
                            int col2 = Common.ParseInt(gvImportOrder.GetRowCellValue(i, "Product_ID"));//2 ma sp
                            decimal col3 = Common.ParseDecimal(gvImportOrder.GetRowCellValue(i, "Price"));//3gia nhap
                            decimal col4 = Common.ParseDecimal(gvImportOrder.GetRowCellValue(i, "PriceSell"));//4gia ban
                            int col5 = Common.ParseInt(gvImportOrder.GetRowCellValue(i, "Quantity"));//5 so luong mua
                            int col6 = Common.ParseInt(gvImportOrder.GetRowCellValue(i, "QuantityPromotion"));//6 so luong km
                            string col7 = "0";//7% KM
                            decimal col8 = Common.ParseDecimal(gvImportOrder.GetRowCellValue(i, "Discount"));//8% Chiet Khau
                            decimal col9 = Common.ParseDecimal(gvImportOrder.GetRowCellValue(i, "Amount"));//9 Thanh Tien
                            decimal oldPrice = 0, oldPriceActual = 0, oldPriceSell = 0, oldQuantity = 0, oldQuantityPromotion = 0;
                            // Check old Data get ProductID and Price ...
                            int iAction = 0;
                            //iAction = 0 ko lam ji het
                            //iAction = 1 add
                            //iAction = 2 edit
                            int iTypeActionEdit = 0;
                            //iTypeActionEdit = 0; ko thay doi thong tin gi het
                            //iTypeActionEdit = 1; chi edit 2 loai gia
                            //iTypeActionEdit = 2; Thay doi so luong va discount

                            // set priceActual
                            decimal ThanhTien = (col5 * (col3 - castOnOnceProduct));
                            decimal ThanhTienDiscount = ThanhTien - (ThanhTien * col8) / 100;
                            decimal priceActual = ThanhTienDiscount / (col5 + col6);

                            if (Common.ParseInt(col0) == 0)
                            {
                                iAction = 1; //Action Add
                            }
                            else
                            {
                                DataTable ImportOrderDetail_Old = new DataTable();

                                param.Clear();
                                param.Add("@ImportOrderDetail_ID", SqlDbType.Int, Common.ParseInt(col0));
                                // int saa = param.ParamList;
                                ImportOrderDetail_Old = clsSQL.GetTableStore("spGetInfor_ImportOrderDetails", param);

                                int oldProductID;

                                decimal oldDiscount = 0;
                                decimal NewPriceActual = Common.ParseDecimal(priceActual.ToString("N2"));
                                foreach (DataRow dr in ImportOrderDetail_Old.Rows)
                                {
                                    oldProductID = Common.ParseInt(dr["Product_ID"]);
                                    oldPriceActual = Common.ParseDecimal(dr["PriceActual"]);
                                    oldPriceSell = Common.ParseDecimal(dr["PriceSell"]);
                                    oldDiscount = Common.ParseDecimal(dr["Discount"]);
                                    oldQuantity = Common.ParseDecimal(dr["Quantity"]);
                                    oldQuantityPromotion = Common.ParseDecimal(dr["QuantityPromotion"]);
                                    oldPrice = Common.ParseDecimal(dr["Price"]);

                                    if (oldProductID == col2)
                                    {
                                        if (NewPriceActual == oldPriceActual && col4 == oldPriceSell && col5 == oldQuantity
                                            && col6 == oldQuantityPromotion && col8 == oldDiscount)
                                        {
                                            iAction = 0;
                                        }
                                        else if ((NewPriceActual != oldPriceActual || col4 != oldPriceSell) && (col5 == oldQuantity && col6 == oldQuantityPromotion && col8 == oldDiscount))
                                        {
                                            iAction = 2; // Eidt Data
                                            iTypeActionEdit = 1; // edit Price
                                        }
                                        else if (col5 != oldQuantity || col6 != oldQuantityPromotion || col8 != oldDiscount)
                                        {
                                            iAction = 2;// Eidt Data
                                            iTypeActionEdit = 2; // Quantity and Discount
                                        }
                                        else
                                        {
                                            iAction = 1; //Action Add
                                        }
                                        break;
                                    }
                                }
                            }
                            if (iAction == 1)
                            {
                                #region Add 1 product



                                param.Clear();
                                param.Add("@ImportOrder_ID", SqlDbType.Int, this.GetSetImportOrder_ID);

                                param.Add("@Company_ID", SqlDbType.Int, cboCompany.EditValue);
                                param.Add("@ProductName", SqlDbType.NVarChar, col1);
                                param.Add("@Quantity", SqlDbType.Int, col5);
                                param.Add("@QuantityPromotion", SqlDbType.Int, col6);
                                param.Add("@PercentPromotion", SqlDbType.SmallInt, Common.ParseInt(col7));
                                param.Add("@Discount", SqlDbType.Decimal, Common.ParseDecimal(col8));
                                param.Add("@PriceActual", SqlDbType.Decimal, priceActual);
                                param.Add("@Price", SqlDbType.Decimal, Common.ParseDecimal(col3));
                                param.Add("@PriceSell", SqlDbType.Decimal, Common.ParseDecimal(col4));
                                string outParmater = string.Empty;
                                clsSQL.ExecStore("spIOD_Ins", param, out outParmater);
                                strData = strData + " " + outParmater;
                                foreach (DataRow row in tbPaymentTemps.Rows)
                                {
                                    param.Clear();
                                    param.Add("@Note", SqlDbType.NVarChar, row["Note"].ToString());
                                    param.Add("@PaymentAmount", SqlDbType.Decimal, Convert.ToDecimal(row["PaymentAmount"]));
                                    param.Add("@ImportOrder_ID", SqlDbType.Int, this.GetSetImportOrder_ID);
                                    string outParmater1 = string.Empty;
                                    clsSQL.ExecStore("spPI_Ins", param, out outParmater1);
                                    strData = strData + " " + outParmater1;
                                }
                                #endregion
                            }
                            else if (iAction == 2)
                            {
                                if (iTypeActionEdit == 1)
                                {
                                    string DatetimeImport = Convert.ToDateTime(tbImportOrders.Rows[0]["ImportOrderDate"]).ToString("yyyy-MM-dd");
                                    param.Clear();
                                    param.Add("@Product_ID", SqlDbType.Int, col2);
                                    param.Add("@Price", SqlDbType.Decimal, oldPriceSell);
                                    param.Add("@Price_Import", SqlDbType.Decimal, oldPriceActual);
                                    param.Add("@OrderDate", SqlDbType.DateTime, DatetimeImport);

                                    DataTable dtResultOrdered = new DataTable();
                                    dtResultOrdered = clsSQL.GetTableStore("spGetQuantityOrdered", param);
                                    if (dtResultOrdered.Rows.Count > 0)
                                    {
                                        //kiem tra so luong order
                                        #region //kiem tra so luong order
                                        int totalQuantity_Ordered = 0, totalQuantityPromotion_Ordered = 0;
                                        foreach (DataRow dr in dtResultOrdered.Rows)
                                        {
                                            totalQuantity_Ordered = totalQuantity_Ordered + Common.ParseInt(dr["totalQuantity"]);
                                            totalQuantityPromotion_Ordered = totalQuantityPromotion_Ordered + Common.ParseInt(dr["totalQuantityPromotion"]);
                                        }
                                        if ((totalQuantity_Ordered + totalQuantityPromotion_Ordered) <= (col5 + col6) && (totalQuantity_Ordered + totalQuantityPromotion_Ordered) > 0)
                                        {
                                            int ChangeQuantity = col5 - totalQuantity_Ordered;
                                            int ChangeQuantityPromotion = col6 - totalQuantityPromotion_Ordered;

                                            //insert Data moi
                                            #region Add 1 product
                                            param.Clear();
                                            param.Add("@ImportOrder_ID", SqlDbType.Int, this.GetSetImportOrder_ID);

                                            param.Add("@Company_ID", SqlDbType.Int, cboCompany.EditValue);
                                            param.Add("@ProductName", SqlDbType.NVarChar, col1);
                                            param.Add("@Quantity", SqlDbType.Int, ChangeQuantity < 0 ? 0 : ChangeQuantity);
                                            param.Add("@QuantityPromotion", SqlDbType.Int, ChangeQuantityPromotion < 0 ? 0 : ChangeQuantityPromotion);
                                            param.Add("@PercentPromotion", SqlDbType.SmallInt, Common.ParseInt(col7));
                                            param.Add("@Discount", SqlDbType.Decimal, Common.ParseDecimal(col8));
                                            param.Add("@PriceActual", SqlDbType.Decimal, priceActual);
                                            param.Add("@Price", SqlDbType.Decimal, Common.ParseDecimal(col3));
                                            param.Add("@PriceSell", SqlDbType.Decimal, Common.ParseDecimal(col4));
                                            string outParmater = string.Empty;
                                            clsSQL.ExecStore("spIOD_Ins", param, out outParmater);
                                            strData = strData + " " + outParmater;
                                            #endregion

                                            // update lai so luong trong Kho
                                            param.Clear();
                                            param.Add("@Product_ID", SqlDbType.Int, col2);
                                            param.Add("@Price", SqlDbType.Decimal, oldPriceSell);
                                            param.Add("@PriceActual_Import", SqlDbType.Decimal, oldPriceActual);
                                            string outData = string.Empty;
                                            clsSQL.ExecStore("spGetQuantityCurrent_Updatetbl_ProductPrices", param, out outData);
                                            outParmater = outParmater + outData;
                                            //update lai hoa don cu
                                            param.Clear();
                                            param.Add("@ImportOrderDetail_ID", SqlDbType.Int, Common.ParseInt(col0));
                                            param.Add("@Company_ID", SqlDbType.Int, cboCompany.EditValue);
                                            param.Add("@Product_ID", SqlDbType.Int, col2);
                                            param.Add("@Quantity", SqlDbType.Int, totalQuantity_Ordered);
                                            param.Add("@QuantityPromotion", SqlDbType.Int, oldQuantityPromotion);
                                            param.Add("@PercentPromotion", SqlDbType.SmallInt, Common.ParseInt(col7));
                                            param.Add("@Discount", SqlDbType.Decimal, Common.ParseDecimal(col8));
                                            param.Add("@PriceActual", SqlDbType.Decimal, oldPriceActual);
                                            param.Add("@Price", SqlDbType.Decimal, oldPrice);
                                            param.Add("@PriceSell", SqlDbType.Decimal, oldPriceSell);
                                            param.Add("@iTypeActionEdit", SqlDbType.Int, iTypeActionEdit);
                                            string outParmater1 = string.Empty;
                                            clsSQL.ExecStore("spIOD_Edit", param, out outParmater1);
                                            strData = strData + " " + outParmater1;
                                            // tinh lai tien da tra cho hoa don
                                            param.Clear();
                                            param.Add("@ImportOrder_ID", SqlDbType.Int, this.GetSetImportOrder_ID);
                                            DataTable dtResultPaymentIntputs = new DataTable();
                                            dtResultPaymentIntputs = clsSQL.GetTableStore("spGetTotalPaymentAmount_tbl_PaymentIntputs", param);
                                            decimal totalPaymentAmount = 0;
                                            if (dtResultPaymentIntputs.Rows.Count > 0)
                                            {
                                                totalPaymentAmount = Common.ParseDecimal(dtResultPaymentIntputs.Rows[0]["totalPaymentAmount"]);
                                            }
                                        }
                                        else
                                        {
                                            if ((totalQuantity_Ordered + totalQuantityPromotion_Ordered) > 0)
                                            {
                                                clsSQL.RollBackTrans();
                                                Program.MessagerErr("Số lượng bán lớn hơn số lượng có trong hóa đơn nhập.", "SUA HOA DON NHAP");
                                            }
                                        }

                                        #endregion
                                    }
                                    else
                                    {
                                        #region Price Change
                                        param.Clear();
                                        param.Add("@ImportOrderDetail_ID", SqlDbType.Int, Common.ParseInt(col0));
                                        param.Add("@Company_ID", SqlDbType.Int, cboCompany.EditValue);
                                        param.Add("@Product_ID", SqlDbType.Int, col2);
                                        param.Add("@Quantity", SqlDbType.Int, Common.ParseInt(col5));
                                        param.Add("@QuantityPromotion", SqlDbType.Int, Common.ParseInt(col6));
                                        param.Add("@PercentPromotion", SqlDbType.SmallInt, Common.ParseInt(col7));
                                        param.Add("@Discount", SqlDbType.Decimal, Common.ParseDecimal(col8));
                                        param.Add("@PriceActual", SqlDbType.Decimal, priceActual);
                                        param.Add("@Price", SqlDbType.Decimal, Common.ParseDecimal(col3));
                                        param.Add("@PriceSell", SqlDbType.Decimal, Common.ParseDecimal(col4));
                                        param.Add("@iTypeActionEdit", SqlDbType.Int, iTypeActionEdit);

                                        string outParmater0 = string.Empty;
                                        clsSQL.ExecStore("spIOD_Edit", param, out outParmater0);
                                        strData = strData + " " + outParmater0;
                                        // Payment
                                        param.Clear();
                                        param.Add("@Company_ID", SqlDbType.Int, cboCompany.EditValue);
                                        param.Add("@ImportOrder_ID", SqlDbType.Int, this.GetSetImportOrder_ID);
                                        param.Add("@CastPromotion", SqlDbType.Decimal, Convert.ToDecimal(txtCast.Text));
                                        param.Add("@OrderCompany_ID", SqlDbType.VarChar, txtOrderCompany_ID.Text.Trim());
                                        string outParmater = string.Empty;
                                        clsSQL.ExecStore("spIO_Edit", param, out outParmater);
                                        strData = strData + " " + outParmater;
                                        #endregion
                                    }
                                }
                                else if (iTypeActionEdit == 2)
                                {
                                    #region Price Change
                                    param.Clear();
                                    param.Add("@ImportOrderDetail_ID", SqlDbType.Int, Common.ParseInt(col0));
                                    param.Add("@Company_ID", SqlDbType.Int, cboCompany.EditValue);
                                    param.Add("@Product_ID", SqlDbType.Int, col2);
                                    param.Add("@Quantity", SqlDbType.Int, Common.ParseInt(col5));
                                    param.Add("@QuantityPromotion", SqlDbType.Int, Common.ParseInt(col6));
                                    param.Add("@PercentPromotion", SqlDbType.SmallInt, Common.ParseInt(col7));
                                    param.Add("@Discount", SqlDbType.Decimal, Common.ParseDecimal(col8));
                                    param.Add("@PriceActual", SqlDbType.Decimal, priceActual);
                                    param.Add("@Price", SqlDbType.Decimal, Common.ParseDecimal(col3));
                                    param.Add("@PriceSell", SqlDbType.Decimal, Common.ParseDecimal(col4));
                                    param.Add("@iTypeActionEdit", SqlDbType.Int, iTypeActionEdit);
                                    string outParmater = string.Empty;
                                    clsSQL.ExecStore("spIOD_Edit", param, out outParmater);
                                    strData = strData + " " + outParmater;
                                    // Payment
                                    param.Clear();
                                    param.Add("@Company_ID", SqlDbType.Int, cboCompany.EditValue);
                                    param.Add("@ImportOrder_ID", SqlDbType.Int, this.GetSetImportOrder_ID);
                                    param.Add("@CastPromotion", SqlDbType.Decimal, Convert.ToDecimal(txtCast.Text));
                                    param.Add("@OrderCompany_ID", SqlDbType.VarChar, txtOrderCompany_ID.Text.Trim());
                                    string outParmater1 = string.Empty;
                                    clsSQL.ExecStore("spIO_Edit", param, out outParmater1);
                                    strData = strData + " " + outParmater1;
                                    #endregion
                                }

                                // select San pham nay coi co nam trong hoa don xuat hay ko ?
                                // neu co thi tiep tuc xem time xuat cua hoa don do voi time nhap cua sp naj
                                //



                            }
                        }
                        #region Validation GvPayment
                        for (int i = 0; i < gvPayment.RowCount; i++)
                        {
                            string col0 = gvPayment.GetDataRow(i).ItemArray[0].ToString(); //0 PayMentID
                            string col1 = gvPayment.GetDataRow(i).ItemArray[1].ToString();//1 Ngay Tra
                            string col2 = gvPayment.GetDataRow(i).ItemArray[2].ToString();//2 Note
                            string col3 = gvPayment.GetDataRow(i).ItemArray[3].ToString();//3 Tien tra
                            if (Common.ParseInt(col0) != 0)
                            {
                            }
                            else
                            {
                                param.Clear();
                                // param.Add("@PaymentInput_ID", SqlDbType.Int,Common.ParseInt(col0));
                                param.Add("@Note", SqlDbType.NVarChar, col2);
                                param.Add("@PaymentAmount", SqlDbType.Decimal, Common.ParseDecimal(col3));
                                param.Add("@ImportOrder_ID", SqlDbType.Int, this.GetSetImportOrder_ID);
                                string outParmater = string.Empty;
                                clsSQL.ExecStore("spPI_Ins", param, out outParmater);
                                strData = strData + " " + outParmater;
                            }
                        }
                        #endregion
                        #endregion
                        Program.MessagerInfo("Cập Nhật Hóa Đơn Thành Công", "TRA HANG");
                        //insert LogData
                        if (strData.Trim().Length > 0)
                        {
                            clsSQL.InsertLogData("spPro_InsertLogData", SettingCodeDB.listActions.Update.ToString(), Common.getPermissionType(SettingCodeDB.USERNAME_Admin, SettingCodeDB.PASSWORD_Admin).ToString(), SettingCodeDB.listScreens.frmCreatNewImport.ToString(), strData);
                        }
                        clsSQL.CommitTrans();
                        updateData();
                    }
                    else
                    {

                        #region// Action Add
                        param.AddOutput("@ImportOrder_ID", SqlDbType.Int, 0);
                        param.Add("@Company_ID", SqlDbType.Int, cboCompany.EditValue);
                        param.Add("@OrderCompany_ID", SqlDbType.VarChar, txtOrderCompany_ID.Text.Trim());
                        param.Add("@CastPromotion", SqlDbType.Decimal, Convert.ToDecimal(txtCast.Text));
                        param.Add("@TypeImportOrder", SqlDbType.Int, 1);// Order
                        string outParmater = string.Empty;
                        clsSQL.ExecStore("spIO_Ins", param, out outParmater);// Insert into ImportOrders
                        strData = strData + " " + outParmater;
                        int iIOIDOutput = (int)param.GetValue("@ImportOrder_ID");

                        foreach (DataRow row in tbProducts.Rows)
                        {
                            // set priceActual
                            //decimal priceDiscount = Common.ParseDecimal(row["Price"]) - ((Common.ParseDecimal(row["Price"]) * Common.ParseDecimal(row["Discount"])) / 100);
                            //decimal priceActual = priceDiscount - castOnOnceProduct;

                            decimal ThanhTien = Common.ParseDecimal(row["Quantity"]) * ((Common.ParseDecimal(row["Price"]) - castOnOnceProduct));
                            decimal ThanhTienDiscount = ThanhTien - (ThanhTien * Common.ParseDecimal(row["Discount"])) / 100;
                            decimal priceActual = ThanhTienDiscount / (Common.ParseInt(row["Quantity"]) + Common.ParseInt(row["QuantityPromotion"]));


                            param.Clear();
                            param.Add("@ImportOrder_ID", SqlDbType.Int, iIOIDOutput);

                            param.Add("@Company_ID", SqlDbType.Int, cboCompany.EditValue);
                            param.Add("@ProductName", SqlDbType.NVarChar, row["ProductName"].ToString());
                            param.Add("@Quantity", SqlDbType.Int, Common.ParseInt(row["Quantity"]));
                            param.Add("@QuantityPromotion", SqlDbType.Int, Common.ParseInt(row["QuantityPromotion"]));
                            param.Add("@PercentPromotion", SqlDbType.SmallInt, 0);
                            param.Add("@Discount", SqlDbType.Decimal, Common.ParseDecimal(row["Discount"]));
                            param.Add("@PriceActual", SqlDbType.Decimal, priceActual);
                            param.Add("@Price", SqlDbType.Decimal, Common.ParseDecimal(row["Price"]));
                            param.Add("@PriceSell", SqlDbType.Decimal, Common.ParseDecimal(row["PriceSell"]));
                            string outParmater1 = string.Empty;
                            clsSQL.ExecStore("spIOD_Ins", param, out outParmater1);
                            strData = strData + " " + outParmater1;
                        }
                        foreach (DataRow row in tbPaymentTemps.Rows)
                        {
                            param.Clear();
                            param.Add("@Note", SqlDbType.NVarChar, row["Note"].ToString());
                            param.Add("@PaymentAmount", SqlDbType.Decimal, Convert.ToDecimal(row["PaymentAmount"]));
                            param.Add("@ImportOrder_ID", SqlDbType.Int, this.GetSetImportOrder_ID);
                            string outParmater2 = string.Empty;
                            clsSQL.ExecStore("spPI_Ins", param, out outParmater2);
                            strData = strData + " " + outParmater2;
                        }

                        #endregion

                        Program.MessagerInfo("Thêm Hóa Đơn Mới Thành Công", "TRA HANG");
                        //insert LogData
                        clsSQL.InsertLogData("spPro_InsertLogData", SettingCodeDB.listActions.Create.ToString(), Common.getPermissionType(SettingCodeDB.USERNAME_Admin, SettingCodeDB.PASSWORD_Admin).ToString(), SettingCodeDB.listScreens.frmCreatNewImport.ToString(), strData);
                        clsSQL.CommitTrans();
                    }
                    #endregion
                }
                else if (rdChangeProduct.Checked)
                {
                    #region Type Change Product Order
                    if (checkAction == 0)
                    {
                        #region// Action Add
                        param.AddOutput("@ImportOrder_ID", SqlDbType.Int, 0);
                        param.Add("@Company_ID", SqlDbType.Int, cboCompany.EditValue);
                        param.Add("@OrderCompany_ID", SqlDbType.VarChar, txtOrderCompany_ID.Text.Trim());
                        param.Add("@CastPromotion", SqlDbType.Decimal, Convert.ToDecimal(txtCast.Text));
                        param.Add("@TypeImportOrder", SqlDbType.Int, 0);// Order
                        string outParmater = string.Empty;
                        clsSQL.ExecStore("spIO_Ins", param, out outParmater);
                        strData = strData + " " + outParmater;
                        int iIOIDOutput = (int)param.GetValue("@ImportOrder_ID");

                        foreach (DataRow row in tbProducts.Rows)
                        {

                            param.Clear();
                            param.Add("@ImportOrder_ID", SqlDbType.Int, iIOIDOutput);

                            param.Add("@Company_ID", SqlDbType.Int, cboCompany.EditValue);
                            param.Add("@ProductName", SqlDbType.NVarChar, row["ProductName"].ToString());
                            param.Add("@Quantity", SqlDbType.Int, Common.ParseInt(row["Quantity"]));
                            param.Add("@QuantityPromotion", SqlDbType.Int, Common.ParseInt(row["QuantityPromotion"]));
                            param.Add("@PercentPromotion", SqlDbType.SmallInt, Common.ParseInt(row["PercentPromotion"]));
                            param.Add("@Discount", SqlDbType.Decimal, Common.ParseDecimal(row["Discount"]));
                            param.Add("@Price", SqlDbType.Decimal, Common.ParseDecimal(row["Price"]));
                            param.Add("@PriceSell", SqlDbType.Decimal, Common.ParseDecimal(row["PriceSell"]));

                            string outParmater1 = string.Empty;
                            clsSQL.ExecStore("spIOD_Ins_Option2", param, out outParmater1);
                            strData = strData + " " + outParmater1;
                        }
                        #endregion
                        //insert LogData
                        clsSQL.InsertLogData("spPro_InsertLogData", SettingCodeDB.listActions.Create.ToString(), Common.getPermissionType(SettingCodeDB.USERNAME_Admin, SettingCodeDB.PASSWORD_Admin).ToString(), SettingCodeDB.listScreens.frmCreatNewImport.ToString(), "Hóa đơn đổi trả " + strData);
                        clsSQL.CommitTrans();
                        Program.MessagerInfo("Thêm Hóa Đơn Mới Thành Công", "TRA HANG");

                    }
                    #endregion
                }
                this.Close();
            }
            catch (Exception ex)
            {
                clsSQL.RollBackTrans();
                Program.MessagerErr(ex.ToString(), "HOA DON NHAP");
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cboCompany_EditValueChanged(object sender, EventArgs e)
        {

            try
            {
                DataTable tbPro = new DataTable();
                clsSQL = new QryData(Program.config.ConnectionString);
                param = new QryParam();
                string sQueryProduct = "SElect pro.Product_ID, pro.ProductName  From tbl_Products pro where pro.Company_ID=@Company_ID ";
                param.Add("@Company_ID", SqlDbType.Int, cboCompany.EditValue);
                tbPro = clsSQL.GetTableSQL(sQueryProduct, param);
                col_IOProductName_Edit.DataSource = tbPro;
                col_IOProductName_Edit.DisplayMember = "ProductName";
                col_IOProductName_Edit.ValueMember = "ProductName";


            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "HOA DON NHAP");
            }


        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboCompany.ItemIndex >= 0)
                {

                    if (txtOrderCompany_ID.Text.Trim() != "")
                    {
                        if (checkOrderCompany(txtOrderCompany_ID.Text.Trim()))
                        {
                            Boolean iEr = false;
                            if (rdOrder.Checked)
                            {
                                rdChangeProduct.Enabled = false;
                                iEr = true;
                            }
                            else if (rdChangeProduct.Checked)
                            {
                                rdOrder.Enabled = false;
                                iEr = true;
                            }
                            if (iEr)
                            {
                                gvImportOrder.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
                                gvPayment.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
                                cboCompany.Enabled = false;
                                txtOrderCompany_ID.Enabled = false;
                                txtCast.Enabled = false;
                                btnCreate.Enabled = false;
                            }
                            else
                            {
                                Program.MessagerErr("Vui lòng chọn loại hóa đơn", "HOA DON NHAP");
                            }
                        }
                        else
                        {
                            Program.MessagerErr("Mã hóa đơn này đã tồn tại.", "HOA DON NHAP");
                        }
                    }
                    else
                    { Program.MessagerErr("Vui lòng điền Mã Hóa Đơn Nhập.", "HOA DON NHAP"); }
                }
                else
                {
                    Program.MessagerErr("Vui lòng chọn công ty muốn nhập sản phẩm.", "HOA DON NHAP");

                }
            }
            catch (Exception ex)
            {
                Program.MessagerErr(ex.ToString(), "HOA DON NHAP");

            }


        }
        private void btnReturnProduct_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    frmVendorReturnProduct obj = new frmVendorReturnProduct();
            //    obj.GetSetImportOrder_ID = this.GetSetImportOrder_ID;
            //    obj.GetTotalAmount = this.GetTotalAmount;
            //    obj.getHaveAmount = this.getHaveAmount;
            //    obj.GetTotalpayment = this.GetTotalpayment;
            //    //obj.Form_Closing += frmCreatNewImport_Load;
            //    //this.Hide();
            //    obj.updateData = new frmVendorReturnProduct.CapNhatDuLieu(Update);
            //    obj.ShowDialog();
            //    this.Close();

            //}
            //catch (Exception ex)
            //{

            //    Program.MessagerErr(ex.ToString(), "TRA SAN PHAM");
            //}
        }
        private void gcPayment_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                string outParmater = string.Empty;
                if (e.KeyCode == Keys.Delete && gvPayment.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing && gvPayment.FocusedRowHandle >= 0)
                {
                    if (this.GetSetImportOrder_ID == 0)
                    {
                        tbPaymentTemps.Rows.RemoveAt(gvPayment.FocusedRowHandle);
                    }
                    else
                    {
                        if (!bIsLock)
                        {
                            if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa???", "CHI TRA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                clsSQL = new QryData(Program.config.ConnectionString);
                                param = new QryParam();
                                param.Add("@PaymentInput_ID", SqlDbType.Int, (int)gvPayment.GetRowCellValue(gvPayment.FocusedRowHandle, "PaymentIntput_ID"));

                                string outData = string.Empty;
                                clsSQL.ExecStore("spPI_Del", param, out outData);
                                outParmater = outParmater + outData;
                                if (this.GetSetImportOrder_ID == 0)
                                {
                                    tbPaymentTemps.Rows.RemoveAt(gvPayment.FocusedRowHandle);
                                }
                                else
                                {
                                    tbPayments.Rows.RemoveAt(gvPayment.FocusedRowHandle);
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "HOA DON NHAP");
            }
        }
        #endregion
        #region Gv ImportOrder

        private void gvImportOrder_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                // gvImportOrder.SetRowCellValue(e.RowHandle, "ProductName", "CHỌN SẢN PHẨM");
                gvImportOrder.SetRowCellValue(e.RowHandle, "Quantity", DBNull.Value);
                gvImportOrder.SetRowCellValue(e.RowHandle, "QuantityPromotion", DBNull.Value);
                gvImportOrder.SetRowCellValue(e.RowHandle, "PercentPromotion", DBNull.Value);
                gvImportOrder.SetRowCellValue(e.RowHandle, "Discount", DBNull.Value);
                gvImportOrder.SetRowCellValue(e.RowHandle, "Price", DBNull.Value);
                gvImportOrder.SetRowCellValue(e.RowHandle, "PriceSell", DBNull.Value);


            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "HOA DON NHAP");
            }
        }
        private void gvImportOrder_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
        private void gvImportOrder_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //try
            //{
            //    if (e.Column.Name == "col_IOProductName")
            //    {
            //        LookUpEdit cboTemp;
            //        cboTemp = (LookUpEdit)sender;
            //        iProduct_ID = (int)cboTemp.EditValue;
            //        Program.MessagerInfo(iProduct_ID.ToString(), "HOA DON NHAP");

            //    }
            //}
            //catch (Exception ex)
            //{

            //    Program.MessagerErr(ex.ToString(), "HOA DON NHAP");
            //}

            try
            {
                //clsSQL = new QryData(Program.config.ConnectionString);

                //spSelect_Number_Promotion
                if (e.Column.FieldName == "ProductName")
                {
                    addProduct = 1;
                    ItemProductName = Common.ParseString(e.Value);

                    string sErr = "";
                    string col0 = "";
                    string col1 = "";
                    bool bVali = true;
                    // string ItemProductName =  gvImportOrder.GetRowCellValue(e.RowHandle, "ProductName").ToString();
                    int checkOverlap = 0;
                    for (int i = 0; i < gvImportOrder.RowCount; i++)
                    {
                        col0 = gvImportOrder.GetDataRow(i).ItemArray[0].ToString();// Ten SP
                        col1 = gvImportOrder.GetDataRow(i).ItemArray[1].ToString();// Ten SP
                        if (ItemProductName.Trim() == col0.Trim() || ItemProductName.Trim() == col1.Trim())
                        {
                            checkExist = 1;
                            sErr = ItemProductName.Trim() + " đã có trong hóa đơn này";
                            strMsg = sErr;
                            //bVali = false;
                            //Program.MessagerErr(sErr, "HOA DON NHAP");
                            break;
                        }
                        else
                        {
                            checkExist = 0;
                            sErr = "";
                        }
                    }
                }
                if (e.Column.Name == "col_IODPrice")
                {


                    decimal number_Product = 0;

                    if (gvImportOrder.GetRowCellValue(e.RowHandle, "Quantity").ToString() != "")
                    {
                        number_Product = Common.ParseDecimal(gvImportOrder.GetRowCellValue(e.RowHandle, "Quantity"));
                    }

                    decimal Set_Price = 0;
                    if (gvImportOrder.GetRowCellValue(e.RowHandle, "Price").ToString() != "")
                    {
                        Set_Price = Common.ParseDecimal(gvImportOrder.GetRowCellValue(e.RowHandle, "Price"));
                    }

                    if (number_Product > 0 && Set_Price > 0)
                    {
                        decimal Product_Price = Common.ParseDecimal(gvImportOrder.GetRowCellValue(e.RowHandle, "Price"));
                        decimal total = number_Product * Product_Price;
                        gvImportOrder.SetRowCellValue(e.RowHandle, "Amount", total);
                        // col_IODAmount
                        //   Amount
                    }
                }
                if (e.Column.Name == "col_IOQuantity")
                {

                    decimal number_Product = 0;

                    if (gvImportOrder.GetRowCellValue(e.RowHandle, "Quantity").ToString() != "")
                    {
                        number_Product = Common.ParseDecimal(gvImportOrder.GetRowCellValue(e.RowHandle, "Quantity"));
                    }

                    decimal Set_Price = 0;
                    if (gvImportOrder.GetRowCellValue(e.RowHandle, "Price").ToString() != "")
                    {
                        Set_Price = Common.ParseDecimal(gvImportOrder.GetRowCellValue(e.RowHandle, "Price"));
                    }
                    if (number_Product > 0 && Set_Price > 0)
                    {
                        decimal Product_Price = Common.ParseDecimal(gvImportOrder.GetRowCellValue(e.RowHandle, "Price"));
                        decimal total = number_Product * Product_Price;
                        gvImportOrder.SetRowCellValue(e.RowHandle, "Amount", total);
                        // col_IODAmount
                        //   Amount
                    }

                }

            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "HOA DON");
            }



        }
        private void gvImportOrder_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                string sErr = "";
                string col0 = "";
                bool bVali = true;
                if (checkExist == 1)
                {

                    sErr = strMsg;
                    bVali = false;
                }
                else
                {

                    if (Common.IsNullOrEmpty(gvImportOrder.GetRowCellValue(e.RowHandle, "ProductName")))
                    {
                        sErr = sErr + Environment.NewLine + "Vui lòng chọn Sản Phẩm.";
                        bVali = false;
                    }
                    else
                    {
                        if (gvImportOrder.GetRowCellValue(e.RowHandle, "ProductName").ToString() == "" || gvImportOrder.GetRowCellValue(e.RowHandle, "ProductName").ToString() == "CHỌN SẢN PHẨM")
                        {
                            sErr = sErr + Environment.NewLine + "Vui lòng chọn Sản Phẩm.";
                            bVali = false;
                        }
                    }
                    if (!string.IsNullOrEmpty(gvImportOrder.GetRowCellValue(e.RowHandle, "Price").ToString()) == true)
                    {
                        if (Common.ParseDecimal(gvImportOrder.GetRowCellValue(e.RowHandle, "Price")) <= 0)
                        {
                            sErr = sErr + Environment.NewLine + "Vui lòng nhập đơn giá nhập phải > 0.";
                            bVali = false;
                        }
                    }
                    else
                    {
                        sErr = sErr + Environment.NewLine + "Vui lòng nhập đơn giá nhập.";
                        bVali = false;
                    }
                    if (gvImportOrder.GetRowCellValue(e.RowHandle, "PriceSell").ToString() == "")
                    {
                        sErr = sErr + Environment.NewLine + "Vui lòng nhập đơn giá bán";
                        bVali = false;
                    }
                    else
                    {
                        if (Common.ParseDecimal(gvImportOrder.GetRowCellValue(e.RowHandle, "PriceSell")) <= 0)
                        {
                            sErr = sErr + Environment.NewLine + "Vui lòng nhập đơn giá bán phải > 0";
                            bVali = false;
                        }
                    }
                    if (!string.IsNullOrEmpty(gvImportOrder.GetRowCellValue(e.RowHandle, "Quantity").ToString()) == true)
                    {
                        if (Common.ParseDecimal(gvImportOrder.GetRowCellValue(e.RowHandle, "Quantity")) <= 0)
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


                    if (!string.IsNullOrEmpty(gvImportOrder.GetRowCellValue(e.RowHandle, "QuantityPromotion").ToString()) == true)
                    {
                        if (Common.ParseDecimal(gvImportOrder.GetRowCellValue(e.RowHandle, "QuantityPromotion")) < 0)
                        {
                            sErr = sErr + Environment.NewLine + "Vui lòng nhập số lượng khuyến mại phải lớn hơn 0.";
                            bVali = false;
                        }

                    }

                    if (!string.IsNullOrEmpty(gvImportOrder.GetRowCellValue(e.RowHandle, "PercentPromotion").ToString()) == true)
                    {
                        if (Common.ParseDecimal(gvImportOrder.GetRowCellValue(e.RowHandle, "PercentPromotion")) < 0)
                        {

                            sErr = sErr + Environment.NewLine + "Vui lòng nhập % khuyến mại phải lớn hơn 0.";
                            bVali = false;
                        }

                    }

                    if (!string.IsNullOrEmpty(gvImportOrder.GetRowCellValue(e.RowHandle, "Discount").ToString()) == true)
                    {
                        if (Common.ParseDecimal(gvImportOrder.GetRowCellValue(e.RowHandle, "Discount")) < 0)
                        {

                            sErr = sErr + Environment.NewLine + "Vui Lòng Nhập % Chiết Khấu Phải > 0";
                            bVali = false;
                        }
                        if (Common.ParseDecimal(gvImportOrder.GetRowCellValue(e.RowHandle, "Discount")) >= 100)
                        {

                            sErr = sErr + Environment.NewLine + "Vui Lòng Nhập % Chiết Khấu Phải < 100";
                            bVali = false;
                        }
                    }
                }
                if (bVali)
                {
                    if (this.GetSetImportOrder_ID != 0)
                    {
                        decimal dAmount = 0;
                        decimal QuantityTemp = Common.ParseDecimal(gvImportOrder.GetRowCellValue(e.RowHandle, "Quantity"));
                        decimal QuantityPromotionTemp = Common.ParseDecimal(gvImportOrder.GetRowCellValue(e.RowHandle, "QuantityPromotion"));
                        decimal PriceTemp = Common.ParseDecimal(gvImportOrder.GetRowCellValue(e.RowHandle, "Price"));
                        decimal DiscountTemp = Common.ParseDecimal(gvImportOrder.GetRowCellValue(e.RowHandle, "Discount"));


                        if (DiscountTemp > 0)
                        {
                            dAmount = (QuantityTemp * PriceTemp) - ((QuantityTemp * PriceTemp) * (DiscountTemp) / 100);
                        }
                        else
                        {
                            dAmount = (QuantityTemp * PriceTemp);
                        }
                        gvImportOrder.SetRowCellValue(e.RowHandle, "Amount", dAmount);
                    }
                    else// Neu day la Tao moi hoa don col_IOQuantity_Edit
                    {
                        decimal dAmount = 0;
                        decimal QuantityTemp = Common.ParseDecimal(gvImportOrder.GetRowCellValue(e.RowHandle, "Quantity"));
                        decimal QuantityPromotionTemp = Common.ParseDecimal(gvImportOrder.GetRowCellValue(e.RowHandle, "QuantityPromotion"));
                        decimal PriceTemp = Common.ParseDecimal(gvImportOrder.GetRowCellValue(e.RowHandle, "Price"));
                        decimal DiscountTemp = Common.ParseDecimal(gvImportOrder.GetRowCellValue(e.RowHandle, "Discount"));


                        if (DiscountTemp > 0)
                        {
                            dAmount = (QuantityTemp * PriceTemp) - ((QuantityTemp * PriceTemp) * (DiscountTemp) / 100);
                        }
                        else
                        {
                            dAmount = (QuantityTemp * PriceTemp);
                        }
                        gvImportOrder.SetRowCellValue(e.RowHandle, "Amount", dAmount);

                    }

                }
                else
                {
                    e.Valid = false;
                    Program.MessagerErr(sErr, "HOA DON NHAP");
                }
                addProduct = 0;
            }
            catch (Exception ex)
            {
                clsSQL.RollBackTrans();
                Program.MessagerErr(ex.ToString(), "HOA DON NHAP");
            }
        }
        private void gvImportOrder_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {

                e.Info.DisplayText = (e.RowHandle + 1).ToString();

            }
        }
        private void gcImportOrder_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                string sErr = "";
                if (e.KeyCode == Keys.Delete && gvImportOrder.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing && gvImportOrder.FocusedRowHandle >= 0)
                {
                    if (this.GetSetImportOrder_ID == 0)
                    {
                        tbProducts.Rows.RemoveAt(gvImportOrder.FocusedRowHandle);
                    }
                    else
                    {
                        if (!bIsLock)// Không khóa thì dc xóa
                        {
                            if (tbImportOrderDetails.Rows.Count == 1)
                            {
                                Program.MessagerErr("Không thể xóa tất cả sản phẩm trong Hóa Đơn Nhập." + Environment.NewLine + "Nếu bạn muốn xóa Hóa Đơn này vui lòng trong phần Danh sách Hóa Đơn nhập và bấm nút Delete trên bàn phím ", "HOA DON NHAP");
                            }
                            else
                            {
                                if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa?", "CHI TIET HOA DON", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    clsSQL = new QryData(Program.config.ConnectionString);
                                    param = new QryParam();
                                    QryParam paramCheckOrder = new QryParam();
                                    int IdImportOrderCurrent = (int)gvImportOrder.GetRowCellValue(gvImportOrder.FocusedRowHandle, "ImportOrderDetail_ID");


                                    #region Check xem co Delete dc hay ko ? neu ko thi bao message
                                    string strQry = "select Product_ID,Quantity,QuantityPromotion,PriceActual,PriceSell  from tbl_ImportOrderDetails where ImportOrderDetail_ID =" + IdImportOrderCurrent;
                                    DataTable CheckDataImportOrderDetail = clsSQL.GetTableSQL(strQry);
                                    // co nhieu nhat la 1 dong
                                    // cot thu 0 : Product_ID
                                    // cot thu 1 : so luong nhap vao
                                    // cot thu 2 : so luong khuyen mai khi nhap
                                    // cot thu 3 : gia ban
                                    if (Common.ParseInt(CheckDataImportOrderDetail.Rows[0]["Product_ID"]) != 0)
                                    {
                                        int Product_ID = Common.ParseInt(CheckDataImportOrderDetail.Rows[0]["Product_ID"].ToString());
                                        int QtyImportOrderDetail = Common.ParseInt(CheckDataImportOrderDetail.Rows[0]["Quantity"].ToString());
                                        int QtyPromotionImportOrderDetail = Common.ParseInt(CheckDataImportOrderDetail.Rows[0]["QuantityPromotion"].ToString());
                                        decimal PriceSale = Common.ParseDecimal(CheckDataImportOrderDetail.Rows[0]["PriceSell"].ToString());
                                        decimal PriceActual = Common.ParseDecimal(CheckDataImportOrderDetail.Rows[0]["PriceActual"].ToString());


                                        string strQryVal = "select Quantity,QuantityPromotion from tbl_ProductPrices where  Product_Id=" + Product_ID + "And Price=" + PriceSale;
                                        DataTable CheckData = clsSQL.GetTableSQL(strQryVal);

                                        int QtyWareHouse = Common.ParseInt(CheckData.Rows[0][0].ToString());
                                        int QtyPromotionWareHouse = Common.ParseInt(CheckData.Rows[0][1].ToString());

                                        //decimal totalMoneyDaTra = Common .ParseDecimal ( getHaveAmount);
                                        decimal TotalMoney_Delete = QtyImportOrderDetail * PriceActual;

                                        if (Common.ParseDecimal(this.GetTotalpayment) < TotalMoney_Delete)
                                        {
                                            sErr = "Không thể xóa sản phẩm này ! Gì đã vượt quá số tiền bạn còn nợ.";
                                            Program.MessagerErr(sErr, "HOA DON XUAT");
                                            return;
                                        }
                                        else
                                        {
                                            totalNO.Text = String.Format("{0:N0}", (Common.ParseDecimal(totalNO.Text) - TotalMoney_Delete));
                                            if (QtyWareHouse >= QtyImportOrderDetail && QtyWareHouse >= QtyPromotionImportOrderDetail)
                                            {
                                                tbImportOrderDetails.Rows.RemoveAt(gvImportOrder.FocusedRowHandle);
                                                DataTable dtNewDelete = new DataTable();
                                                dtNewDelete.Columns.Add("ImportOrderDetail_ID");
                                                dtNewDelete.Rows.Add(IdImportOrderCurrent);

                                                DataTable dtNewDelete_AddRow = new DataTable();
                                                if (GetDelete_ImportOrder != null)
                                                {
                                                    dtNewDelete_AddRow = GetDelete_ImportOrder;
                                                    dtNewDelete_AddRow.Rows.Add(IdImportOrderCurrent);
                                                    GetDelete_ImportOrder = dtNewDelete_AddRow;
                                                }
                                                else
                                                {
                                                    GetDelete_ImportOrder = dtNewDelete;
                                                }

                                            }
                                            else
                                            {
                                                sErr = "Không Thể Xóa Sản Phẩm Trong Hóa Đơn Này";
                                                Program.MessagerErr(sErr, "HOA DON NHAP");
                                            }
                                        }

                                    }
                                    else
                                    {
                                        sErr = "Không Thể Xóa Sản Phẩm Trong Hóa Đơn Này";
                                        Program.MessagerErr(sErr, "HOA DON NHAP");
                                    }
                                    #endregion

                                }

                            }
                        }

                    }
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    checkExist = 0;
                    strMsg = "";
                }
            }
            catch (Exception ex)
            {
                clsSQL.RollBackTrans();
                Program.MessagerErr(ex.ToString(), "HOA DON NHAP");
            }
        }
        private void gvImportOrder_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            try
            {
                if (this.GetSetImportOrder_ID != 0)
                {

                    col_IOProductName.OptionsColumn.AllowEdit = e.FocusedRowHandle == Program.NEW_ROW;
                    //string arrID = "";
                    //for (int i = 0; i < gvImportOrder.RowCount; i++)
                    //{
                    //    string col2 = gvImportOrder.GetDataRow(i).ItemArray[2].ToString();// ma sp
                    //    arrID += col2 + ",";
                    //}

                    //DataTable tbPro = new DataTable();
                    //clsSQL = new QryData(Program.config.ConnectionString);
                    //QryParam paramForColProductName;
                    //paramForColProductName = new QryParam();
                    //string sQueryProduct = "SElect pro.Product_ID, pro.ProductName  From tbl_Products pro where pro.Product_ID not in (@arrProductID) and pro.Company_ID=@Company_ID ";
                    //paramForColProductName.Add("@arrProductID", SqlDbType.Int, arrID.Substring(0, arrID.Length - 1));
                    //paramForColProductName.Add("@Company_ID", SqlDbType.Int, cboCompany.EditValue);
                    //tbPro = clsSQL.GetTableSQL(sQueryProduct, paramForColProductName);
                    //col_IOProductName_Edit.DataSource = tbPro;
                    //col_IOProductName_Edit.DisplayMember = "ProductName";
                    //col_IOProductName_Edit.ValueMember = "ProductName";

                    DataTable tbPro = new DataTable();
                    clsSQL = new QryData(Program.config.ConnectionString);
                    param = new QryParam();
                    string sQueryProduct = "SElect pro.Product_ID, pro.ProductName  From tbl_Products pro where pro.Company_ID=@Company_ID ";
                    param.Add("@Company_ID", SqlDbType.Int, cboCompany.EditValue);
                    tbPro = clsSQL.GetTableSQL(sQueryProduct, param);
                    col_IOProductName_Edit.DataSource = tbPro;
                    col_IOProductName_Edit.DisplayMember = "ProductName";
                    col_IOProductName_Edit.ValueMember = "ProductName";
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                Program.MessagerErr(ex.ToString(), "HOA DON NHAP");

            }
        }

        #endregion

        #region Property Gv payment
        private void gvPayment_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
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
        private void gvPayment_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                gvPayment.SetRowCellValue(e.RowHandle, "DatePayment", DateTime.Now);
                //gvPayment.SetRowCellValue(e.RowHandle, "Note", "");
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "HOA DON NHAP");
            }
        }
        private void gvPayment_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                string sErr = "";
                bool bValid = true;

                if (Convert.ToDouble(gvPayment.GetRowCellValue(e.RowHandle, "PaymentAmount")) <= 0)
                {
                    sErr = Environment.NewLine + "Số tiền phải lớn hơn 0.";
                    bValid = false;
                }
                else
                {
                    double PayAmount = 0;
                    if (e.RowHandle == Program.NEW_ROW)
                    {

                        foreach (DataRow row in tbPayments.Rows)
                        {
                            PayAmount = PayAmount + Convert.ToDouble(row["PaymentAmount"]);
                        }

                        if ((Convert.ToDouble(gvPayment.GetRowCellValue(e.RowHandle, "PaymentAmount")) + PayAmount) > (Convert.ToDouble(col_IODAmount.SummaryItem.SummaryValue) - Convert.ToDouble(txtCast.Text)))
                        {
                            sErr = Environment.NewLine + "Số tiền nhập phải nhỏ hơn :" + ((Convert.ToDouble(col_IODAmount.SummaryItem.SummaryValue) - Convert.ToDouble(txtCast.Text)) - PayAmount).ToString();
                            bValid = false;
                        }
                    }
                    else
                    {
                        foreach (DataRow row in tbPayments.Select("PaymentIntput_ID " + gvPayment.GetRowCellValue(e.RowHandle, "PaymentIntput_ID").ToString()))
                        {
                            PayAmount = PayAmount + Convert.ToDouble(row["PaymentAmount"]);
                        }
                        if ((Convert.ToDouble(gvPayment.GetRowCellValue(e.RowHandle, "PaymentAmount")) + PayAmount) > (Convert.ToDouble(col_IODAmount.SummaryItem.SummaryValue) - Convert.ToDouble(txtCast.Text)))
                        {
                            sErr = Environment.NewLine + "Số tiền nhập phải nhỏ hơn :" + (Commons.Common.ConVertToNumber((Convert.ToDouble(col_IODAmount.SummaryItem.SummaryValue) - Convert.ToDouble(txtCast.Text)) - PayAmount)).ToString();
                            bValid = false;
                        }
                    }

                }

                if (!bValid)
                {
                    e.Valid = false;
                    Program.MessagerErr(sErr, "HOA DON NHAP");
                }
                else
                {
                    //clsSQL = new QryData(Program.config.ConnectionString);
                    //param = new QryParam();
                    if (this.GetSetImportOrder_ID != 0) // Sua hoa don
                    {

                        GetTotalpayment = (Convert.ToDecimal(totalNO.Text) - Convert.ToDecimal(gvPayment.GetRowCellValue(e.RowHandle, "PaymentAmount"))).ToString();
                        totalNO.Text = String.Format("{0:N0}", Common.ParseDecimal(GetTotalpayment));
                        if (e.RowHandle != Program.NEW_ROW)
                        {
                        }
                        else
                        {
                        }
                    }
                    else // Tao moi hoa don
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                clsSQL.RollBackTrans();
                Program.MessagerErr(ex.ToString(), "HOA DON NHAP");
            }
        }
        private void gvPayment_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                col_PIDate.OptionsColumn.AllowEdit = e.FocusedRowHandle == Program.NEW_ROW;
                if (e.FocusedRowHandle < 0 || e.FocusedRowHandle == Program.NEW_ROW)
                {
                    gvPayment.OptionsBehavior.Editable = true;
                }
                else
                {
                    gvPayment.OptionsBehavior.Editable = false;
                    // col_IOProductName.OptionsColumn.AllowEdit = e.FocusedRowHandle == Program.NEW_ROW;
                    // col_PIDate.OptionsColumn.AllowEdit = e.FocusedRowHandle == Program.NEW_ROW;
                    //col_PIAmount.OptionsColumn.AllowEdit = e.FocusedRowHandle == Program.NEW_ROW;
                    //col_PINote.OptionsColumn.AllowEdit = e.FocusedRowHandle == Program.NEW_ROW;

                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "CHI TRA");
            }
        }
        #endregion

        private void txtCast_EditValueChanged(object sender, EventArgs e)
        {

        }

    }
}