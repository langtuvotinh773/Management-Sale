using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Management.Commons.SQL;
using Management.Reports;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.Data;
using Management.Commons;

namespace Management.Products
{
    public partial class uctOrders : DevExpress.XtraEditors.XtraUserControl
    {
        public void UpdateFormOrdered()
        {
            // uctImportOrder_Load(null, null);
            this.btnGetData_Click(null, null);
            // uctImportOrder_Load(null,null);
        }
        public uctOrders()
        {
            InitializeComponent();
        }
        QryData clsSQL;
        QryParam param;
        string moneyPayment = "";
        DataTable tbCust, tbEmp, tbOrders, tbOrderDetails, tbPayments, tbProductChanges, dataTabletemp;

        private void uctOrders_Load(object sender, EventArgs e)
        {
            try
            {
                dateBegin.EditValue = DateTime.Now.AddMonths(-1);
                dateEnd.EditValue = DateTime.Now;
                clsSQL = new QryData(Program.config.ConnectionString);
                string sQueryCust = "SElect Cust_ID, CustName, Address From tbl_Customers Order By CustName";
                string sQueryEmp = "SElect Emp_ID, EmpName , Address From tbl_Employees where IsDefault != 1 AND Status = 0 Order By EmpName";
                tbCust = new DataTable();
                tbEmp = new DataTable();
                tbCust = clsSQL.GetTableSQL(sQueryCust);
                tbEmp = clsSQL.GetTableSQL(sQueryEmp);
                //
                cboCust.Properties.DataSource = tbCust;
                cboCust.Properties.DisplayMember = "CustName";
                cboCust.Properties.ValueMember = "Cust_ID";
                cboCust.ItemIndex = 0;
                //
                cboEmp.Properties.DataSource = tbEmp;
                cboEmp.Properties.ValueMember = "Emp_ID";
                cboEmp.Properties.DisplayMember = "EmpName";
                cboEmp.ItemIndex = 0;
                GroupOrther.Enabled = Convert.ToBoolean(radOption.EditValue);
                groupOrder_ID.Enabled = !Convert.ToBoolean(radOption.EditValue);

                //

            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "HOA DON XUAT");
            }
        }

        private void chkAllCust_CheckedChanged(object sender, EventArgs e)
        {
            cboCust.Enabled = !chkAllCust.Checked;
        }

        private void chkAllEmp_CheckedChanged(object sender, EventArgs e)
        {
            cboEmp.Enabled = !chkAllEmp.Checked;
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            try
            {
                clsSQL = new QryData(Program.config.ConnectionString);

                //string sQuerySelect = "select Product_ID,Price,PriceActual_Import from tbl_ProductPrices";
                //DataTable dtNew = new DataTable();
                //dtNew = clsSQL.GetTableSQL(sQuerySelect);
                //foreach (DataRow dr in dtNew.Rows)
                //{
                //    string strInsert = "insert into tbl_PriceHistory(Product_ID,PriceSell,PriceActual) values ";
                //    strInsert += "(" + Common.ParseInt(dr[0]) + "," + Common.ParseDecimal(dr[1]) + "," + Common.ParseDecimal(dr[2]) + ")";
                //    clsSQL.ExecSQL(strInsert);

                //}
                //Program.MessagerErr("Update xong", "HOA DON XUAT");
                tbOrders = new DataTable(); tbOrderDetails = new DataTable(); tbPayments = new DataTable(); tbProductChanges = new DataTable();

                DataSet dsOrders = new DataSet();
                if (Convert.ToBoolean(radOption.EditValue) == false)
                {
                    #region Input number Order
                    if (txtOrder_ID.Text == "")
                    {
                        return;
                    }
                    else
                    {

                        param = new QryParam();
                        param.Add("@Order_ID", SqlDbType.Int, Common.ParseInt(txtOrder_ID.Text));
                        tbOrders = clsSQL.GetTableStore("spOD_List_ID", param);

                        param = param.Copy();
                        tbOrderDetails = clsSQL.GetTableStore("spOD_Detail_ID", param);

                        param = param.Copy();
                        tbPayments = clsSQL.GetTableStore("spOD_Payment_ID", param);
                        param = param.Copy();
                        tbProductChanges = clsSQL.GetTableStore("spOD_ListProductChanges_ID", param);

                    }
                    #endregion
                }
                else
                {
                    if (rdOrder.Checked)
                    {
                        // cmdMenuOrder.Enabled = true;
                        sửaHóaĐơnXuấtToolStripMenuItem.Enabled = true;
                        cmdReturnProduct.Enabled = true;
                        cmdChangeProduct.Enabled = true;
                        // inHóaĐơnToolStripMenuItem.Enabled = true;

                        #region check Order
                        if (chkAllCust.Checked)
                        {

                            if (chkAllEmp.Checked)
                            {
                                #region check all Emp
                                param = new QryParam();
                                param.Add("@Begin", SqlDbType.DateTime, Convert.ToDateTime(Convert.ToDateTime(dateBegin.EditValue).ToShortDateString()));
                                param.Add("@End", SqlDbType.DateTime, Convert.ToDateTime(Convert.ToDateTime(dateEnd.EditValue).ToShortDateString()));
                                tbOrders = clsSQL.GetTableStore("spOD_List", param);

                                param = param.Copy();
                                tbOrderDetails = clsSQL.GetTableStore("spOD_Detail", param);

                                param = param.Copy();
                                tbPayments = clsSQL.GetTableStore("spOD_Payment", param);

                                param = param.Copy();
                                tbProductChanges = clsSQL.GetTableStore("spOD_ListProductChanges", param);
                                #endregion
                            }

                            else
                            {
                                #region Uncheck all Emp
                                param = new QryParam();
                                param.Add("@Begin", SqlDbType.DateTime, Convert.ToDateTime(Convert.ToDateTime(dateBegin.EditValue).ToShortDateString()));
                                param.Add("@End", SqlDbType.DateTime, Convert.ToDateTime(Convert.ToDateTime(dateEnd.EditValue).ToShortDateString()));
                                param.Add("@Emp_ID", SqlDbType.Int, Common.ParseInt(cboEmp.EditValue));
                                tbOrders = clsSQL.GetTableStore("spOD_List_Emp", param);

                                param = param.Copy();
                                tbOrderDetails = clsSQL.GetTableStore("spOD_Detail_Emp", param);

                                param = param.Copy();
                                tbPayments = clsSQL.GetTableStore("spOD_Payment_Emp", param);

                                param = param.Copy();
                                tbProductChanges = clsSQL.GetTableStore("spOD_ListProductChanges_Emp", param);
                                #endregion
                            }
                        }
                        else
                        {
                            if (chkAllEmp.Checked)
                            {
                                #region check all emp
                                param = new QryParam();
                                param.Add("@Begin", SqlDbType.DateTime, Convert.ToDateTime(Convert.ToDateTime(dateBegin.EditValue).ToShortDateString()));
                                param.Add("@End", SqlDbType.DateTime, Convert.ToDateTime(Convert.ToDateTime(dateEnd.EditValue).ToShortDateString()));
                                param.Add("@Cust_ID", SqlDbType.Int, Common.ParseInt(cboCust.EditValue));
                                tbOrders = clsSQL.GetTableStore("spOD_List_Cust", param);

                                param = param.Copy();
                                tbOrderDetails = clsSQL.GetTableStore("spOD_Detail_Cust", param);

                                param = param.Copy();
                                tbPayments = clsSQL.GetTableStore("spOD_Payment_Cust", param);

                                param = param.Copy();
                                tbProductChanges = clsSQL.GetTableStore("spOD_ListProductChanges_Cust", param);

                                #endregion
                            }
                            else
                            {
                                #region Uncheck all emp
                                param = new QryParam();
                                param.Add("@Begin", SqlDbType.DateTime, Convert.ToDateTime(Convert.ToDateTime(dateBegin.EditValue).ToShortDateString()));
                                param.Add("@End", SqlDbType.DateTime, Convert.ToDateTime(Convert.ToDateTime(dateEnd.EditValue).ToShortDateString()));
                                param.Add("@Cust_ID", SqlDbType.Int, Common.ParseInt(cboCust.EditValue));
                                param.Add("@Emp_ID", SqlDbType.Int, Common.ParseInt(cboEmp.EditValue));
                                tbOrders = clsSQL.GetTableStore("spOD_List_CustEmp", param);

                                param = param.Copy();
                                tbOrderDetails = clsSQL.GetTableStore("spOD_Detail_CustEmp", param);

                                param = param.Copy();
                                tbPayments = clsSQL.GetTableStore("spOD_Payment_CustEmp", param);

                                param = param.Copy();
                                tbProductChanges = clsSQL.GetTableStore("spOD_ListProductChanges_CustEmp", param);
                                #endregion
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        //cmdMenuOrder.Enabled  = false;
                        sửaHóaĐơnXuấtToolStripMenuItem.Enabled = false;
                        cmdReturnProduct.Enabled = false;
                        cmdChangeProduct.Enabled = false;
                        //inHóaĐơnToolStripMenuItem.Enabled = false;

                        #region check change Order

                        if (chkAllCust.Checked)
                        {

                            if (chkAllEmp.Checked)
                            {
                                #region check all Emp
                                param = new QryParam();
                                param.Add("@Begin", SqlDbType.DateTime, Convert.ToDateTime(Convert.ToDateTime(dateBegin.EditValue).ToShortDateString()));
                                param.Add("@End", SqlDbType.DateTime, Convert.ToDateTime(Convert.ToDateTime(dateEnd.EditValue).ToShortDateString()));
                                tbOrders = clsSQL.GetTableStore("spOD_List_Option2", param);

                                param = param.Copy();
                                tbOrderDetails = clsSQL.GetTableStore("spOD_Detail_Option2", param);

                                param = param.Copy();
                                tbPayments = clsSQL.GetTableStore("spOD_Payment_Option2", param);

                                param = param.Copy();
                                tbProductChanges = clsSQL.GetTableStore("spOD_ListProductChanges_Option2", param);
                                #endregion
                            }

                            else
                            {
                                #region Uncheck all Emp
                                param = new QryParam();
                                param.Add("@Begin", SqlDbType.DateTime, Convert.ToDateTime(Convert.ToDateTime(dateBegin.EditValue).ToShortDateString()));
                                param.Add("@End", SqlDbType.DateTime, Convert.ToDateTime(Convert.ToDateTime(dateEnd.EditValue).ToShortDateString()));
                                param.Add("@Emp_ID", SqlDbType.Int, Common.ParseInt(cboEmp.EditValue));
                                tbOrders = clsSQL.GetTableStore("spOD_List_Emp_Option2", param);

                                param = param.Copy();
                                tbOrderDetails = clsSQL.GetTableStore("spOD_Detail_Emp_Option2", param);

                                param = param.Copy();
                                tbPayments = clsSQL.GetTableStore("spOD_Payment_Emp_Option2", param);

                                param = param.Copy();
                                tbProductChanges = clsSQL.GetTableStore("spOD_ListProductChanges_Emp_Option2", param);
                                #endregion
                            }
                        }
                        else
                        {
                            if (chkAllEmp.Checked)
                            {
                                #region check all emp
                                param = new QryParam();
                                param.Add("@Begin", SqlDbType.DateTime, Convert.ToDateTime(Convert.ToDateTime(dateBegin.EditValue).ToShortDateString()));
                                param.Add("@End", SqlDbType.DateTime, Convert.ToDateTime(Convert.ToDateTime(dateEnd.EditValue).ToShortDateString()));
                                param.Add("@Cust_ID", SqlDbType.Int, Common.ParseInt(cboCust.EditValue));
                                tbOrders = clsSQL.GetTableStore("spOD_List_Cust_Option2", param);

                                param = param.Copy();
                                tbOrderDetails = clsSQL.GetTableStore("spOD_Detail_Cust_Option2", param);

                                param = param.Copy();
                                tbPayments = clsSQL.GetTableStore("spOD_Payment_Cust_Option2", param);

                                param = param.Copy();
                                tbProductChanges = clsSQL.GetTableStore("spOD_ListProductChanges_Cust_Option2", param);

                                #endregion
                            }
                            else
                            {
                                #region Uncheck all emp
                                param = new QryParam();
                                param.Add("@Begin", SqlDbType.DateTime, Convert.ToDateTime(Convert.ToDateTime(dateBegin.EditValue).ToShortDateString()));
                                param.Add("@End", SqlDbType.DateTime, Convert.ToDateTime(Convert.ToDateTime(dateEnd.EditValue).ToShortDateString()));
                                param.Add("@Cust_ID", SqlDbType.Int, Common.ParseInt(cboCust.EditValue));
                                param.Add("@Emp_ID", SqlDbType.Int, Common.ParseInt(cboEmp.EditValue));
                                tbOrders = clsSQL.GetTableStore("spOD_List_CustEmp_Option2", param);

                                param = param.Copy();
                                tbOrderDetails = clsSQL.GetTableStore("spOD_Detail_CustEmp_Option2", param);

                                param = param.Copy();
                                tbPayments = clsSQL.GetTableStore("spOD_Payment_CustEmp_Option2", param);

                                param = param.Copy();
                                tbProductChanges = clsSQL.GetTableStore("spOD_ListProductChanges_CustEmp_Option2", param);
                                #endregion
                            }
                        }
                        #endregion
                    }
                }
                //Add to DataSet
                dsOrders.Tables.Add(tbOrders.Copy());
                dsOrders.Tables["NoTableName"].TableName = "Orders";

                dsOrders.Tables.Add(tbOrderDetails.Copy());
                dsOrders.Tables["NoTableName"].TableName = "OrderDetails";

                dsOrders.Tables.Add(tbPayments.Copy());
                dsOrders.Tables["NoTableName"].TableName = "Payments";

                dsOrders.Tables.Add(tbProductChanges.Copy());
                dsOrders.Tables["NoTableName"].TableName = "ProductChanges";
                //Add Relate
                DataColumn keyColumn = dsOrders.Tables["Orders"].Columns["Order_ID"];
                DataColumn foreignKeyColumn = dsOrders.Tables["OrderDetails"].Columns["Order_ID"];
                dsOrders.Relations.Add("Chi Tiết Hóa Đơn Xuất", keyColumn, foreignKeyColumn);

                DataColumn keyColumnPay = dsOrders.Tables["Orders"].Columns["Order_ID"];
                DataColumn foreignKeyColumnPay = dsOrders.Tables["Payments"].Columns["Order_ID"];
                dsOrders.Relations.Add("Chi Tiết Chi Trả", keyColumnPay, foreignKeyColumnPay);

                DataColumn keyColumnProChange = dsOrders.Tables["Orders"].Columns["Order_ID"];
                DataColumn foreignKeyColumnProchange = dsOrders.Tables["ProductChanges"].Columns["Order_ID"];
                dsOrders.Relations.Add("Chi Tiết Đổi Hàng", keyColumnProChange, foreignKeyColumnProchange);
                //UserName

                //  moneyPayment = dsOrders.Tables["Orders"].Rows[0][7].ToString();
                ////////dataTabletemp = new DataTable();
                ////////dataTabletemp.Columns.Add("TienConNo", typeof(String));
                ////////dataTabletemp.Rows.Add(moneyPayment);
                //GetTotalpayment();
                gcOrders.DataSource = dsOrders.Tables["Orders"];
                gcOrders.ForceInitialize();
                gcOrders.LevelTree.Nodes.Add("Chi Tiết Hóa Đơn Xuất", gvOrderDetails);
                //gcOrders.LevelTree.Nodes.Add("Chi Tiết Chi Trả", gvPaymentOrders);
                //gcOrders.LevelTree.Nodes.Add("Chi Tiết Đổi Hàng", vProchanges);
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "HOA DON XUAT");
            }
        }
        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            frmNewOrders obj = new frmNewOrders();
            obj.ShowDialog();
        }

        private void cmdMenuOrder_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (gvOrders.FocusedRowHandle < 0)
                {
                    e.Cancel = true;

                }
                else
                {
                    e.Cancel = false;
                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "HOA DON XUAT");
            }
        }

        private void sửaHóaĐơnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                if (gvOrders.GetRowCellValue(gvOrders.FocusedRowHandle, "IsLock").ToString().ToLower() != "true")
                {

                    //TotalAmount
                    frmEditOrders obj = new frmEditOrders();
                    // obj.Form_Closing += btnGetData_Click;
                    obj.GetSetOrder_ID = (int)gvOrders.GetRowCellValue(gvOrders.FocusedRowHandle, "Order_ID");
                    double ConvertString = Convert.ToDouble(gvOrders.GetRowCellValue(gvOrders.FocusedRowHandle, "TotalPay"));
                    double TotalAmount = Convert.ToDouble(gvOrders.GetRowCellValue(gvOrders.FocusedRowHandle, "TotalAmount"));
                    obj.GetTotalAmount = Convert.ToString(TotalAmount);
                    obj.GetTotalpayment = Convert.ToString(ConvertString);

                    obj.updateData = new frmEditOrders.CapNhatDuLieu(UpdateFormOrdered);
                    obj.ShowDialog();
                }
                else
                {
                    Program.MessagerErr("Đã Khóa HĐ Này !", "THONG BAO");
                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "HOA DON XUAT");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {


        }

        private void inHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                param = new QryParam();
                param.Add("Order_ID", SqlDbType.Int, (int)gvOrders.GetRowCellValue(gvOrders.FocusedRowHandle, "Order_ID"));
                //rptOrders rptOrder = new rptOrders();
                DataTable dtResult = new DataTable();

                Installer1 rptOrder_ok = new Installer1();
                if (rdOrder.Checked)
                {
                    dtResult = clsSQL.GetTableStore("spRpt_Orders_Details", param);
                    // rptOrder.DataSource = clsSQL.GetTableStore("spRpt_Orders_Details", param);
                }
                else
                {
                    dtResult = clsSQL.GetTableStore("spRpt_Orders_Details", param);
                    // rptOrder.DataSource = clsSQL.GetTableStore("spRpt_Orders_Details_Option2", param);
                }
                //rptOrder.DataMember = "Table";
                // rptOrder.ShowPreview();
                rptOrder_ok.DataSource = dtResult;

                frmShowPrint frmShow = new frmShowPrint();
                frmShow.getSetDataSource = dtResult;
                frmShow.MyTitle = "HOA DON XUAT";
                frmShow.MyReport = rptOrder_ok;
                frmShow.ShowDialog();
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "HOA DON XUAT");
            }
        }

        private void col_ODISLock_Edit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                string outParmater = string.Empty;
                if (XtraMessageBox.Show("Bạn có chắc chắn muốn Khóa Hóa Đơn này?", "HOA DON XUAT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    e.Cancel = false;
                    clsSQL = new QryData(Program.config.ConnectionString);
                    param = new QryParam();
                    param.Add("@Order_ID", SqlDbType.Int, (int)gvOrders.GetRowCellValue(gvOrders.FocusedRowHandle, "Order_ID"));
                    clsSQL.BeginTrans();
                    string outData = string.Empty;
                    clsSQL.ExecStore("spOD_IsLock", param, out outData);
                    outParmater = outParmater + outData;
                    clsSQL.InsertLogData("spPro_InsertLogData", "IsLock", Common.getPermissionType(SettingCodeDB.USERNAME_User, SettingCodeDB.PASSWORD_User).ToString(), SettingCodeDB.listScreens.uctOrders.ToString(), outParmater);
                    clsSQL.CommitTrans();
                    btnGetData_Click(null, null);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                clsSQL.RollBackTrans();
                Program.MessagerErr(ex.ToString(), "HOA DON NHAP");
            }
        }

        private void gvOrders_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            col_ODIsLock1.OptionsColumn.AllowFocus = !Convert.ToBoolean(gvOrders.GetRowCellValue(e.FocusedRowHandle, "IsLock"));
        }

        private void radOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            GroupOrther.Enabled = Convert.ToBoolean(radOption.EditValue);
            groupOrder_ID.Enabled = !Convert.ToBoolean(radOption.EditValue);

        }

        private void txtOrder_ID_KeyPress(object sender, KeyPressEventArgs e)
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

                Program.MessagerErr(ex.ToString(), "HOA DON XUAT");
            }
        }
        private Boolean checkPermission()
        {
            try
            {
                int PermissionType = Commons.Common.getPermissionType(SettingCodeDB.PASSWORD_Admin, SettingCodeDB.PASSWORD_Admin);
                if (PermissionType == 1)
                {
                    return false;
                }
                else if (PermissionType == 2)
                {
                    return true;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private Boolean DeleteOrderLocked(int Order_ID)
        {
            try
            {
                string outParmater = string.Empty;
                clsSQL.BeginTrans();
                param.Clear();
                param = new QryParam();
                param.Add("@Order_ID", SqlDbType.Int, Order_ID);
                string outData = string.Empty;
                clsSQL.ExecStore("spOrder_DeleteAllLocked", param, out outData);
                outParmater = outParmater + outData;
                clsSQL.InsertLogData("spPro_InsertLogData", "DeleteOrderLocked", Common.getPermissionType(SettingCodeDB.USERNAME_User, SettingCodeDB.PASSWORD_User).ToString(), SettingCodeDB.listScreens.uctOrders.ToString(), outParmater);
                clsSQL.CommitTrans();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private void gcOrders_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && gvOrders.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing && gvOrders.FocusedRowHandle >= 0)
                {
                    int OrderID = Commons.Common.ParseInt(gvOrders.GetRowCellValue(gvOrders.FocusedRowHandle, "Order_ID"));
                    Decimal TotalPayment = Commons.Common.ParseDecimal(gvOrders.GetRowCellValue(gvOrders.FocusedRowHandle, "TotalPayment"));
                    if (gvOrders.GetRowCellValue(gvOrders.FocusedRowHandle, "IsLock").ToString().ToLower() != "true")
                    {
                        if (TotalPayment > 0)
                        {
                            if (checkPermission())
                            {
                                if (e.KeyCode == Keys.Delete && gvOrders.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing && gvOrders.FocusedRowHandle >= 0)
                                {
                                    if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa?", "CHI HOA DON", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        if (DeleteOrderLocked(OrderID))
                                        {
                                            gvOrders.DeleteRow(gvOrders.FocusedRowHandle);
                                            Program.MessagerErr("Xóa hóa đơn đã khóa", "THONG BAO");
                                        }
                                        else
                                        {
                                            Program.MessagerErr("Không thể xóa hóa đơn này", "THONG BAO");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Program.MessagerErr("Không thể xóa hóa đơn này", "THONG BAO");
                            }
                        }
                        else
                        {

                            if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa?", "CHI HOA DON", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                param.Clear();
                                param = new QryParam();
                                clsSQL.BeginTrans();
                                param.Add("@Order_ID", SqlDbType.Int, OrderID);
                                gvOrders.DeleteRow(gvOrders.FocusedRowHandle);
                                string strData = string.Empty;
                                clsSQL.ExecStore("spOrder_DeleteAll", param, out strData);
                                clsSQL.InsertLogData("spPro_InsertLogData", SettingCodeDB.listActions.Delete.ToString(), Common.getPermissionType(SettingCodeDB.USERNAME_Admin, SettingCodeDB.PASSWORD_Admin).ToString(), SettingCodeDB.listScreens.uctOrders.ToString(), strData);
                                clsSQL.CommitTrans();
                            }
                        }
                    }
                    else
                    {
                        if (checkPermission())
                        {
                            if (e.KeyCode == Keys.Delete && gvOrders.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing && gvOrders.FocusedRowHandle >= 0)
                            {
                                if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa?", "CHI HOA DON", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    if (DeleteOrderLocked(OrderID))
                                    {
                                        gvOrders.DeleteRow(gvOrders.FocusedRowHandle);
                                        Program.MessagerErr("Xóa hóa đơn đã khóa", "THONG BAO");
                                    }
                                    else
                                    {
                                        Program.MessagerErr("Không thể xóa hóa đơn này", "THONG BAO");
                                    }
                                }
                            }
                        }
                        else
                        {
                            Program.MessagerErr("Đã Khóa HĐ Này !", "THONG BAO");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "HOA DON XUAT");
            }
        }



        private void cmdChangeProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvOrders.GetRowCellValue(gvOrders.FocusedRowHandle, "IsLock").ToString().ToLower() != "true")
                {
                    //frmChangeProduct obj = new frmChangeProduct();
                    //obj.GetSetOrder_ID = (int)gvOrders.GetRowCellValue(gvOrders.FocusedRowHandle, "Order_ID");
                    //obj.GetTotalAmount = Convert.ToString(gvOrders.GetRowCellValue(gvOrders.FocusedRowHandle, "TotalAmount"));

                    //obj.updateData = new frmChangeProduct.CapNhatDuLieu(UpdateFormOrdered);
                    //obj.ShowDialog();
                    Program.MessagerErr("Chức năng này tạm thời ko hoạt động", "QUAN LY SAN PHAM");
                }
                else
                {
                    Program.MessagerErr("Đã Khóa HĐ Này !", "THONG BAO");
                }

            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "DOI HANG");
            }
        }

        private void cmdReturnProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvOrders.GetRowCellValue(gvOrders.FocusedRowHandle, "IsLock").ToString().ToLower() != "true")
                {
                    frmReturnProduct obj = new frmReturnProduct();
                    obj.GetSetOrder_ID = (int)gvOrders.GetRowCellValue(gvOrders.FocusedRowHandle, "Order_ID");
                    obj.GetTotalAmount = Common.ParseDecimal(gvOrders.GetRowCellValue(gvOrders.FocusedRowHandle, "TotalAmount"));

                    obj.updateData = new frmReturnProduct.CapNhatDuLieu(UpdateFormOrdered);
                    obj.ShowDialog();
                }
                else
                {
                    Program.MessagerErr("Đã Khóa HĐ Này !", "THONG BAO");
                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "DOI HANG");
            }
        }
        private void gvOrders_MouseUp(object sender, MouseEventArgs e)
        {
            //GridView View = gcOrders.FocusedView as GridView;

            //gvOrders.SortInfo.ClearAndAddRange(new GridColumnSortInfo[] {
            //      new GridColumnSortInfo(View.Columns["OrderDate"], ColumnSortOrder.Descending)
            //});
        }

        private void button_Edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                string outParmater = string.Empty;
                string CustomerName = gvOrders.GetRowCellValue(gvOrders.FocusedRowHandle, "CustName").ToString().ToUpper();
                if (XtraMessageBox.Show("Bạn muốn cập nhật lại hóa đơn " + CustomerName + " ?", "CHI HOA DON", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    double ConvertString = Convert.ToDouble(gvOrders.GetRowCellValue(gvOrders.FocusedRowHandle, "TotalPay"));
                    double TotalAmount = Convert.ToDouble(gvOrders.GetRowCellValue(gvOrders.FocusedRowHandle, "TotalAmount"));

                    clsSQL = new QryData(Program.config.ConnectionString);
                    param = new QryParam();
                    clsSQL.BeginTrans();
                    int OrderID = Commons.Common.ParseInt(gvOrders.GetRowCellValue(gvOrders.FocusedRowHandle, "Order_ID"));
                    DataTable dtDetailOrder = new DataTable();
                    string getOrderDetail = "select * from tbl_OrderDetails where Order_ID = " + OrderID;
                    dtDetailOrder = clsSQL.GetTableSQL(getOrderDetail);
                    foreach (DataRow row in dtDetailOrder.Rows)
                    {
                        int OrderDetail_ID = Common.ParseInt(row["OrderDetail_ID"]);

                        int Product_ID = Common.ParseInt(row["Product_ID"]);
                        int Quantity = Common.ParseInt(row["Quantity"]);
                        int QuantityPromotion = Common.ParseInt(row["QuantityPromotion"]);
                        int DisCount = Common.ParseInt(row["Discount"]);
                        int PercentDiscount = 0;
                        decimal Price = Common.ParseDecimal(row["Price"]);
                        string Form = Common.ParseString(row["Form"]);

                        param.Clear();

                        param.Add("@OrderDetail_ID", SqlDbType.Int, OrderDetail_ID);
                        param.Add("@Order_ID", SqlDbType.Int, OrderID);
                        param.Add("@Product_ID", SqlDbType.Int, Product_ID);
                        param.Add("@Quantity", SqlDbType.Int, Quantity);
                        param.Add("@QuantityPromotion", SqlDbType.Int, QuantityPromotion);
                        param.Add("@DisCount", SqlDbType.SmallInt, DisCount);
                        param.Add("@PercentDiscount", SqlDbType.SmallInt, 0); // cot nay khong hien thi ra nua
                        param.Add("@Price", SqlDbType.Decimal, Price);
                        param.Add("@Form", SqlDbType.NVarChar, Form);


                        param.Add("@Price_Import", SqlDbType.Decimal, Common.ParseDecimal(row["Price_Import"]));
                        string outData = string.Empty;
                        clsSQL.ExecStore("spODD_Edit", param, out outData);
                        outParmater = outParmater + " ---Refresh--- " + outData;

                    }
                    if (ConvertString < TotalAmount)
                    {
                        #region // Check Value Gridview Payment
                        param.Clear();
                        param.Add("@Order_ID", SqlDbType.Int, OrderID);
                        param.Add("@OrderDate", SqlDbType.DateTime, DateTime.Now);
                        param.Add("@Note", SqlDbType.NVarChar, "Refresh lai data");
                        param.Add("@CheckInsertSalaries", SqlDbType.Int, 1);
                        string outData1 = string.Empty;
                        clsSQL.ExecStore("spPaymentOrder_Refresh", param, out outData1);
                        outParmater = outParmater + outData1;

                        param = new QryParam();
                        param.Add("@Order_ID", SqlDbType.Int, OrderID);
                        string outData2 = string.Empty;
                        clsSQL.ExecStore("spCheckLockOrder", param, out outData2);
                        outParmater = outParmater + outData2;


                        #endregion
                    }
                    clsSQL.InsertLogData("spPro_InsertLogData", SettingCodeDB.listActions.Refresh.ToString(), Common.getPermissionType(SettingCodeDB.USERNAME_User, SettingCodeDB.PASSWORD_User).ToString(), SettingCodeDB.listScreens.uctOrders.ToString(), outParmater);
                    clsSQL.CommitTrans();
                    Program.MessagerInfo("Cập Nhật Hóa Đơn Xuất Thành Công", "CHỈNH SỬA HÓA ĐƠN XUẤT");
                    //frmEditOrders_Load(null, null);

                }

            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "HOA DON XUAT");
            }
        }

        private void xóaHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int OrderID = Commons.Common.ParseInt(gvOrders.GetRowCellValue(gvOrders.FocusedRowHandle, "Order_ID"));
            Decimal TotalPayment = Commons.Common.ParseDecimal(gvOrders.GetRowCellValue(gvOrders.FocusedRowHandle, "TotalPayment"));
            if (gvOrders.GetRowCellValue(gvOrders.FocusedRowHandle, "IsLock").ToString().ToLower() != "true")
            {
                if (TotalPayment > 0)
                {
                    if (checkPermission())
                    {
                        if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa?", "CHI HOA DON", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (DeleteOrderLocked(OrderID))
                            {
                                gvOrders.DeleteRow(gvOrders.FocusedRowHandle);
                                Program.MessagerErr("Xóa hóa đơn đã khóa", "THONG BAO");
                            }
                            else
                            {
                                Program.MessagerErr("Không thể xóa hóa đơn này", "THONG BAO");
                            }
                        }
                    }
                    else
                    {
                        Program.MessagerErr("Không thể xóa hóa đơn này", "THONG BAO");
                    }
                }
                else
                {

                    if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa?", "CHI HOA DON", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        param.Clear();
                        param = new QryParam();
                        clsSQL.BeginTrans();
                        param.Add("@Order_ID", SqlDbType.Int, OrderID);
                        gvOrders.DeleteRow(gvOrders.FocusedRowHandle);
                        string strData = string.Empty;
                        clsSQL.ExecStore("spOrder_DeleteAll", param, out strData);
                        clsSQL.InsertLogData("spPro_InsertLogData", SettingCodeDB.listActions.Delete.ToString(), Common.getPermissionType(SettingCodeDB.USERNAME_Admin, SettingCodeDB.PASSWORD_Admin).ToString(), SettingCodeDB.listScreens.uctOrders.ToString(), strData);
                        clsSQL.CommitTrans();
                    }
                }
            }
            else
            {
                if (checkPermission())
                {
                    if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa?", "CHI HOA DON", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (DeleteOrderLocked(OrderID))
                        {
                            gvOrders.DeleteRow(gvOrders.FocusedRowHandle);
                            Program.MessagerErr("Xóa hóa đơn đã khóa", "THONG BAO");
                        }
                        else
                        {
                            Program.MessagerErr("Không thể xóa hóa đơn này", "THONG BAO");
                        }
                    }
                }
                else
                {
                    Program.MessagerErr("Đã Khóa HĐ Này !", "THONG BAO");
                }
            }
        }

    }
}
