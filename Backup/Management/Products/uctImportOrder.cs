using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using Management.Commons;
using Management.Commons.SQL;
namespace Management.Products
{
    public partial class uctImportOrder : DevExpress.XtraEditors.XtraUserControl
    {
       

        public void Update()
        {
           // uctImportOrder_Load(null, null);
            this.btnGetData_Click(null, null);
            // uctImportOrder_Load(null,null);
        }

        #region GLOBAL VARIABLES
        QryData clsSQl;
        QryParam param;
        QryParam param1;
        DataSet dsImportOrder;
        DataTable dtShow = new DataTable();
        public static bool getset_rdOrder { get; set; }
        #endregion
        string moneyPayment = "";
        int IdCompany = 0;
        public uctImportOrder()
        {
            InitializeComponent();
        }

        public void Print()
        { gcImportOrder.ShowPrintPreview(); }

        #region     EVENTS

        private void uctImportOrder_Load(object sender, EventArgs e)
        {
            try
            {
                
                groupOrderNo.Enabled = false;
                groupDate.Enabled = true;
                //txtOrderNo.Focus();
                chkAllCompany.Focus();
                dateBeginDate.EditValue = DateTime.Now.AddMonths(-1);
                dateEndDate.EditValue = DateTime.Now;
                cboCompany.Enabled = !chkAllCompany.Checked;
                clsSQl = new QryData(Program.config.ConnectionString);
                string sQueryCompany = "Select Company_ID, CompanyName, Address From tbl_Companies Order by CompanyName";
                cboCompany.Properties.DataSource = clsSQl.GetTableSQL(sQueryCompany);
                cboCompany.Properties.DisplayMember = "CompanyName";
                cboCompany.Properties.ValueMember = "Company_ID";
                cboCompany.ItemIndex = 0;

            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "PHIEU NHAP HANG");
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tbIO;//= new DataTable("ImportOrders");
                DataTable tbIODetail;// = new DataTable("ImportOrderDetails");
                DataTable tbIOPayment;// = new DataTable("ImportOrderPayments");
                clsSQl = new QryData(Program.config.ConnectionString);
                param = new QryParam();
                dsImportOrder = new DataSet();
                // Dataset
                if (rdOrder.Checked)
                {
                    cmdReturnProductVendor.Enabled = true;
                    cmdImportOrderDetail.Enabled = true;  
                }
                else
                { 
                    cmdReturnProductVendor.Enabled = false;
                    cmdImportOrderDetail.Enabled = false;
                }
                if (Convert.ToBoolean(radOp.EditValue) != true) // theo so Hoa don nhap
                {

                    if (txtOrderNo.Text.Trim() == "")
                    {
                        return;
                    }
                    else
                    {
                        if (rdOrder.Checked)
                        {
                            param.Add("@OrderNo", SqlDbType.NVarChar, txtOrderNo.Text.Trim());
                            tbIO = clsSQl.GetTableStore("spIO_List_OrderNo", param);

                            param = param.Copy();
                            tbIODetail = clsSQl.GetTableStore("spIO_ListDetail_OrderNo", param);
                            param = param.Copy();
                            tbIOPayment = clsSQl.GetTableStore("spIO_ListPayment_OrderNo", param);
                            dsImportOrder.Tables.Add(tbIO.Copy());
                            dsImportOrder.Tables["NoTableName"].TableName = "ImportOrders";
                            dsImportOrder.Tables.Add(tbIODetail.Copy());
                            dsImportOrder.Tables["NoTableName"].TableName = "ImportOrderDetails";
                            dsImportOrder.Tables.Add(tbIOPayment.Copy());
                            dsImportOrder.Tables["NoTableName"].TableName = "ImportOrderPayments";
                        }
                        else if (rdChangeProduct.Checked)
                        {
                            
                            param.Add("@OrderNo", SqlDbType.NVarChar, txtOrderNo.Text.Trim());
                            tbIO = clsSQl.GetTableStore("spIO_List_OrderNo_Option2", param);

                            param = param.Copy();
                            tbIODetail = clsSQl.GetTableStore("spIO_ListDetail_OrderNo_Option2", param);
                            param = param.Copy();
                            tbIOPayment = clsSQl.GetTableStore("spIO_ListPayment_OrderNo", param);
                            dsImportOrder.Tables.Add(tbIO.Copy());
                            dsImportOrder.Tables["NoTableName"].TableName = "ImportOrders";
                            dsImportOrder.Tables.Add(tbIODetail.Copy());
                            dsImportOrder.Tables["NoTableName"].TableName = "ImportOrderDetails";
                            dsImportOrder.Tables.Add(tbIOPayment.Copy());
                            dsImportOrder.Tables["NoTableName"].TableName = "ImportOrderPayments";
                        }
                    }

                }
                else//Theo ngay va ten Cty
                {
                    DateTime FromDate = Convert.ToDateTime(Convert.ToDateTime(dateBeginDate.EditValue).ToShortDateString());
                    DateTime ToDate = Convert.ToDateTime(Convert.ToDateTime(dateEndDate.EditValue).ToShortDateString());

                    param.Add("@BeginDate", SqlDbType.DateTime, FromDate);
                    param.Add("@EndDate", SqlDbType.DateTime, ToDate);
                    if (rdOrder.Checked)
                    {
                        if (chkAllCompany.Checked == true)
                        {
                            tbIO = clsSQl.GetTableStore("spIO_List", param);
                            param = param.Copy();
                            tbIODetail = clsSQl.GetTableStore("spIO_ListDetail", param);

                            param = param.Copy();
                            tbIOPayment = clsSQl.GetTableStore("spIO_ListPayment", param);

                        }
                        else
                        {
                            
                            IdCompany = Common.ParseInt(cboCompany.EditValue);
                            param.Add("@Company", SqlDbType.Int, IdCompany);
                            tbIO = clsSQl.GetTableStore("spIO_List_Com", param);

                            param = param.Copy();
                            tbIODetail = clsSQl.GetTableStore("spIO_ListDetail_Com", param);

                            param = param.Copy();
                            tbIOPayment = clsSQl.GetTableStore("spIO_ListPayment_Com", param);

                        }
                        dsImportOrder.Tables.Add(tbIO.Copy());

                        dsImportOrder.Tables["NoTableName"].TableName = "ImportOrders";
                        dsImportOrder.Tables.Add(tbIODetail.Copy());
                        dsImportOrder.Tables["NoTableName"].TableName = "ImportOrderDetails";
                        dsImportOrder.Tables.Add(tbIOPayment.Copy());
                        dsImportOrder.Tables["NoTableName"].TableName = "ImportOrderPayments";
                    }
                    else if (rdChangeProduct.Checked)
                    {
                        
                        if (chkAllCompany.Checked == true)
                        {
                            tbIO = clsSQl.GetTableStore("spIO_List_Option2", param);
                            param = param.Copy();
                            tbIODetail = clsSQl.GetTableStore("spIO_ListDetail_Option2", param);

                            param = param.Copy();
                            tbIOPayment = clsSQl.GetTableStore("spIO_ListPayment_Option2", param);

                        }
                        else
                        {
                            IdCompany = Common.ParseInt(cboCompany.EditValue);
                            param.Add("@Company", SqlDbType.Int, IdCompany);
                            tbIO = clsSQl.GetTableStore("spIO_List_Com_Option2", param);

                            param = param.Copy();
                            tbIODetail = clsSQl.GetTableStore("spIO_ListDetail_Com_Option2", param);

                            param = param.Copy();
                            tbIOPayment = clsSQl.GetTableStore("spIO_ListPayment_Com_Option2", param);

                        }
                        dsImportOrder.Tables.Add(tbIO.Copy());

                        dsImportOrder.Tables["NoTableName"].TableName = "ImportOrders";
                        dsImportOrder.Tables.Add(tbIODetail.Copy());
                        dsImportOrder.Tables["NoTableName"].TableName = "ImportOrderDetails";
                        dsImportOrder.Tables.Add(tbIOPayment.Copy());
                        dsImportOrder.Tables["NoTableName"].TableName = "ImportOrderPayments";
                    
                    }
                }


                //Relate  moneyPayment
                DataColumn keyColumn = dsImportOrder.Tables["ImportOrders"].Columns["ImportOrder_ID"];
                DataColumn foreignKeyColumn = dsImportOrder.Tables["ImportOrderDetails"].Columns["ImportOrder_ID"];
                dsImportOrder.Relations.Add("Chi Tiết Hóa Đơn Nhập", keyColumn, foreignKeyColumn);
                //
                DataColumn keyColumnPay = dsImportOrder.Tables["ImportOrders"].Columns["ImportOrder_ID"];
                DataColumn foreignKeyColumnPay = dsImportOrder.Tables["ImportOrderPayments"].Columns["ImportOrder_ID"];
                dsImportOrder.Relations.Add("Chi Tiết Chi Trả", keyColumnPay, foreignKeyColumnPay);
                gcImportOrder.DataSource = dsImportOrder.Tables["ImportOrders"];
                gcImportOrder.ForceInitialize();
                gcImportOrder.LevelTree.Nodes.Add("Chi Tiết Hóa Đơn Nhập", ggvImportOrderDetail);
                gcImportOrder.LevelTree.Nodes.Add("Chi Tiết Chi Trả", gvPaymentImport);

            }
            catch (Exception ex)
            {
                Program.MessagerErr(ex.ToString(), "PHIEU NHAP HANG");
            }
        }

        private void chkAllCompany_CheckedChanged(object sender, EventArgs e)
        {
            cboCompany.Enabled = !chkAllCompany.Checked;
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            frmCreatNewImport io = new frmCreatNewImport();
            io.GetSetImportOrder_ID = 0;
            io.Form_Closing += this.btnGetData_Click;
            io.ShowDialog();
        }

        private void cmdImportOrderDetail_Click(object sender, EventArgs e)
        {
            try
            {
                getset_rdOrder = rdOrder.Checked;
                frmCreatNewImport io = new frmCreatNewImport();
                io.GetSetImportOrder_ID = Convert.ToInt32(gvImportOrder.GetRowCellValue(gvImportOrder.FocusedRowHandle, "ImportOrder_ID"));
                io.GetTotalpayment = Convert.ToString(gvImportOrder.GetRowCellValue(gvImportOrder.FocusedRowHandle, "Paymount"));
                io.GetTotalAmount = Convert.ToString(gvImportOrder.GetRowCellValue(gvImportOrder.FocusedRowHandle, "TotalAmount"));
                io.getHaveAmount = Convert.ToString(gvImportOrder.GetRowCellValue(gvImportOrder.FocusedRowHandle, "PaymentAmount")); 
               
                io.updateData = new frmCreatNewImport.CapNhatDuLieu(Update);
                io.ShowDialog();
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "HOA DON NHAP");
            }
        }

     


        private void col_OIIsLock_Edit_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void col_OIIsLock_Edit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                string outParmater = string.Empty;
                if (XtraMessageBox.Show("Bạn có chắc chắn muốn Khóa Hóa Đơn Nhập này?", "HOA DON NHAP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    e.Cancel = false;
                    clsSQl = new QryData(Program.config.ConnectionString);
                    param = new QryParam();
                    param.Add("@ImportOrder_ID", SqlDbType.Int, (int)gvImportOrder.GetRowCellValue(gvImportOrder.FocusedRowHandle, "ImportOrder_ID"));
                    clsSQl.BeginTrans();
                    string outData = string.Empty;
                    clsSQl.ExecStore("spIO_IsLock", param, out outData);
                    
                    outParmater = outParmater + outData;
                    clsSQl.InsertLogData("spPro_InsertLogData", "IsLock", Common.getPermissionType(SettingCodeDB.USERNAME_User, SettingCodeDB.PASSWORD_User).ToString(), SettingCodeDB.listScreens.uctImportOrder.ToString(), outParmater);
                    clsSQl.CommitTrans();
                    btnGetData_Click(null, null);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                clsSQl.RollBackTrans();
                Program.MessagerErr(ex.ToString(), "HOA DON NHAP");
            }
        }

        private void gvImportOrder_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (e.FocusedRowHandle >= 0)
                {
                    col_OIIsLock.OptionsColumn.AllowFocus = !Convert.ToBoolean(gvImportOrder.GetRowCellValue(e.FocusedRowHandle, "IsLock"));
                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "HOA DON NHAP");
            }
        }

        #endregion

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gcImportOrder.ShowPrintPreview();
        }

        private void radOp_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupDate.Enabled = Convert.ToBoolean(radOp.EditValue);
            groupOrderNo.Enabled = !Convert.ToBoolean(radOp.EditValue);
            if (Convert.ToBoolean(radOp.EditValue) == true)
            {
                txtOrderNo.Focus();
            }
        }

        private void txtOrderNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == 13)
                {
                    btnGetData.PerformClick();
                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "HOA DON NHAP");
            }
        }

        private void gcImportOrder_ProcessGridKey(object sender, KeyEventArgs e)
        {
            QryData clsSQL;
            clsSQL = new QryData(Program.config.ConnectionString);
            string sOutData = string.Empty;
            try
            {
                if (e.KeyCode == Keys.Delete && gvImportOrder.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing && gvImportOrder.FocusedRowHandle >= 0)
                {
                    int ImportID = Commons.Common.ParseInt(gvImportOrder.GetRowCellValue(gvImportOrder.FocusedRowHandle, "ImportOrder_ID"));
                    if (ImportID != 0)
                    {

                        if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn nhập " + ImportID + " ?", "CHI TIET HOA DON", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Decimal Payment = Commons.Common.ParseDecimal(gvImportOrder.GetRowCellValue(gvImportOrder.FocusedRowHandle, "PaymentAmount"));
                            if (Payment > 0)
                            {
                                string sErr = "Không Thể Xóa Hóa Đơn Này";
                                Program.MessagerErr(sErr, "HOA DON NHAP");
                                return;
                            }
                            param.Clear();

                            param1 = new QryParam();
                            param = new QryParam();

                            #region Check xem co Delete dc hay ko ? neu ko thi bao message
                            string strQry = "select Product_ID,Price from tbl_ImportOrderDetails where ImportOrder_ID = " + ImportID;
                            DataTable CheckDelete = clsSQL.GetTableSQL(strQry);
                            if (CheckDelete.Rows.Count != 0)
                            {
                                // Neu DelecteAll = 0 thi dc Quyen Xoa, DelecteAll = 1 ko dc xoa
                                int DelecteAll = 0;
                                #region Cap nhat lai so luong đa nhap truoc do
                                string strSelectIdImportOrder = "select ImportOrderDetail_ID from tbl_ImportOrderDetails where ImportOrder_ID =" + ImportID;
                                DataTable intCheckUpdate = clsSQL.GetTableSQL(strSelectIdImportOrder);
                                clsSQL.BeginTrans();
                                for (int Z = 0; Z < intCheckUpdate.Rows.Count; Z++)
                                {
                                    string strCheckDataImportOrderDetail = "select Product_ID,Quantity,QuantityPromotion,PriceSell,PriceActual  from tbl_ImportOrderDetails where ImportOrderDetail_ID =" + Common.ParseInt(intCheckUpdate.Rows[Z][0]);
                                    DataTable CheckDataImportOrderDetail = clsSQL.GetTableSQL(strCheckDataImportOrderDetail);
                                    // co nhieu nhat la 1 dong
                                    // cot thu 0 : Product_ID
                                    // cot thu 1 : so luong nhap vao
                                    // cot thu 2 : so luong khuyen mai khi nhap
                                    // cot thu 3 : gia ban
                                    int Product_ID = Common.ParseInt(CheckDataImportOrderDetail.Rows[0]["Product_ID"].ToString());
                                    int QtyImportOrderDetail = Common.ParseInt(CheckDataImportOrderDetail.Rows[0]["Quantity"].ToString());
                                    int QtyPromotionImportOrderDetail = Common.ParseInt(CheckDataImportOrderDetail.Rows[0]["QuantityPromotion"].ToString());
                                    decimal PriceSale = Common.ParseDecimal(CheckDataImportOrderDetail.Rows[0]["PriceSell"].ToString());
                                    decimal PriceActual = Common.ParseDecimal(CheckDataImportOrderDetail.Rows[0]["PriceActual"].ToString());

                                    string strQryVal = "select Quantity,QuantityPromotion from tbl_ProductPrices where  Product_Id=" + Product_ID + " And Price=" + PriceSale + "AND priceActual_Import =" + PriceActual;
                                    DataTable CheckData = clsSQL.GetTableSQL(strQryVal);
                                    int QtyWareHouse = Common.ParseInt(CheckData.Rows[0]["Quantity"].ToString());

                                    if (QtyWareHouse >= (QtyImportOrderDetail + QtyPromotionImportOrderDetail))
                                    {
                                        param1.Clear();
                                        param1.Add("@ImportOrderDetail_ID", SqlDbType.Int, Common.ParseInt(intCheckUpdate.Rows[Z][0]));
                                        string outData;
                                        clsSQL.ExecStore("spIOD_Del", param1, out outData);
                                        sOutData = sOutData + " " + outData;
                                    }
                                    else
                                    {
                                        DelecteAll = 1;
                                        string sErr = "Không Thể Xóa Hóa Đơn Này";
                                        Program.MessagerErr(sErr, "HOA DON NHAP");
                                        break;
                                    }

                                }
                                #endregion
                                if (DelecteAll != 1)
                                {
                                    param.Clear();
                                    param.Add("@Ordert_ID", SqlDbType.Int, ImportID);
                                    gvImportOrder.DeleteRow(gvImportOrder.FocusedRowHandle);
                                    string outData;
                                    clsSQL.ExecStore("spDeleteImportOrder", param, out outData);
                                    sOutData = sOutData + " " + outData;
                                    clsSQL.InsertLogData("spPro_InsertLogData", SettingCodeDB.listActions.Delete.ToString(), Common.getPermissionType(SettingCodeDB.USERNAME_User, SettingCodeDB.PASSWORD_User).ToString(), SettingCodeDB.listScreens.uctImportOrder.ToString(), sOutData);
                                    clsSQL.CommitTrans();
                                }

                            }
                            #endregion
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsSQL.RollBackTrans();
                Program.MessagerErr(ex.ToString(), "HOA DON NHAP");
            }
        }

        private void gcImportOrder_Click(object sender, EventArgs e)
        {

        }

        private void cmdReturnProductVendor_Click(object sender, EventArgs e)
        {
            try
            {
                frmVendorReturnProduct obj = new frmVendorReturnProduct();
                obj.GetSetImportOrder_ID = Convert.ToInt32(gvImportOrder.GetRowCellValue(gvImportOrder.FocusedRowHandle, "ImportOrder_ID"));
                obj.GetTotalAmount = Convert.ToString(gvImportOrder.GetRowCellValue(gvImportOrder.FocusedRowHandle, "TotalAmount"));
                obj.getHaveAmount = Convert.ToString(gvImportOrder.GetRowCellValue(gvImportOrder.FocusedRowHandle, "PaymentAmount"));
                obj.GetTotalpayment = Convert.ToString(gvImportOrder.GetRowCellValue(gvImportOrder.FocusedRowHandle, "Paymount"));
                obj.updateData = new frmVendorReturnProduct.CapNhatDuLieu(Update);
                obj.ShowDialog();
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "HOA DON NHAP");
            }
        }

        private void rdChangeProduct_CheckedChanged(object sender, EventArgs e)
        {
            btnGetData_Click(null, null);
        }

        private void rdOrder_CheckedChanged(object sender, EventArgs e)
        {
            btnGetData_Click(null, null);
        }

       

        


    }
}
