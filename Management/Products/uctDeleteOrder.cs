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
    public partial class uctDeleteOrder : DevExpress.XtraEditors.XtraUserControl
    {


        public uctDeleteOrder()
        {
            InitializeComponent();
        }
        QryData clsSQL;
        QryParam param;
        string moneyPayment = "";
        DataTable tbDetails;
        DataTable tbSalary,tbCurrentSalary;
        public DataTable GetDelete_Order
        {
            get { return tbDetails; }
            set { tbDetails = value; }
        }
        private void uctDeleteOrder_Load(object sender, EventArgs e)
        {
            try
            {
                clsSQL = new QryData(Program.config.ConnectionString);
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "HOA DON XUAT");
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            param = new QryParam();
            param.Add("@Order_ID", SqlDbType.Int, Common.ParseInt(txtOrder.Text));
            tbDetails = new DataTable();
            GetDelete_Order = clsSQL.GetTableStore("spOD_frmEdit_ListDetail", param);
            if (GetDelete_Order != null && GetDelete_Order.Rows.Count == 0)
            {
                Program.MessagerInfo("Hóa Đơn Không Tồn Tại", "Delete Order");
            }else{
                param = param.Copy();
                tbSalary = new DataTable();
                tbSalary = clsSQL.GetTableStore("spGetSalaryFromOrder", param);
                if (tbSalary != null && tbSalary.Rows.Count > 0)
                {
                    txtSalary.Text = Common.ConvertStrMoney(tbSalary.Rows[0][0]);
                }
                else
                {
                    txtSalary.Text = "0";
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa Hóa Đơn :" + Common.ParseInt(txtOrder.Text), "Delete Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    #region xoa san pham trong Hoa Don
                    if (GetDelete_Order != null && GetDelete_Order.Rows.Count > 0)
                    {
                        string strData = string.Empty;
                        clsSQL.BeginTrans();
                        param = new QryParam();
                        Decimal totalSalary = 0;
                        string sQuerySalary = "SElect (TotalSalary - ReturnMoney) as TotalSalary  From tbl_TotalSalary where Emp_ID =" + Common.ParseInt(GetDelete_Order.Rows[0]["Emp_ID"]);
                        tbCurrentSalary = new DataTable();
                        tbCurrentSalary = clsSQL.GetTableSQL(sQuerySalary);
                        if (tbCurrentSalary != null && tbCurrentSalary.Rows.Count > 0)
                        {
                            totalSalary = Common.ParseDecimal(tbCurrentSalary.Rows[0]["TotalSalary"]);
                        }
                        else
                        {
                            totalSalary = 0;
                        }
                        //update Lương
                        sQuerySalary = "UPDATE tbl_totalsalary SET TotalSalary =  (TotalSalary - " +
                            Common.ParseDecimal(txtSalary.Text) + ") WHERE Emp_ID = " + Common.ParseInt(GetDelete_Order.Rows[0]["Emp_ID"]);
                        clsSQL.ExecSQL(sQuerySalary);
                        strData = strData + " " + sQuerySalary;

                        foreach (DataRow dr in GetDelete_Order.Rows)
                        {
                            param.Clear();
                            param.Add("@OrderID", SqlDbType.Int, Common.ParseInt(dr["Order_ID"]));
                            param.Add("@OrderDetail_ID", SqlDbType.Int, Common.ParseInt(dr["OrderDetail_ID"]));
                            param.Add("@Product_ID", SqlDbType.Int, Common.ParseInt(dr["Product_ID"]));
                            param.Add("@PriceImport", SqlDbType.Decimal, Common.ParseDecimal(dr["Price_Import"]));
                            param.Add("@Price", SqlDbType.Decimal, Common.ParseDecimal(dr["Price"]));
                            param.Add("@Quantity", SqlDbType.Int, Common.ParseInt(dr["Quantity"]));
                            param.Add("@QuantityPromotion", SqlDbType.Int, Common.ParseInt(dr["QuantityPromotion"]));
                            string outParmater = string.Empty;
                            clsSQL.ExecStore("spDelete_OrderDetails", param, out outParmater);
                            strData = strData + " " + outParmater;
                        }
                        #region DELETE replaytionship
                        String sQuery = string.Empty;

                        // DELETE
                        sQuery = "DELETE FROM tbl_Salaries WHERE Order_ID =" + Common.ParseInt(txtOrder.Text);
                        clsSQL.ExecSQL(sQuery);

                        sQuery = string.Empty;
                        sQuery = "DELETE FROM tbl_PaymentOrders WHERE Order_ID =" + Common.ParseInt(txtOrder.Text);
                        clsSQL.ExecSQL(sQuery);

                        sQuery = string.Empty;
                        sQuery = "DELETE FROM tbl_ChangeProducts WHERE Order_ID =" + Common.ParseInt(txtOrder.Text);
                        clsSQL.ExecSQL(sQuery);

                        //delete Order 
                        sQuery = string.Empty;
                        sQuery = "DELETE FROM tbl_Orders WHERE Order_ID =" + Common.ParseInt(txtOrder.Text);
                        clsSQL.ExecSQL(sQuery);
                        #endregion
                        

                        if (strData.Trim().Length > 0)
                        {
                            clsSQL.InsertLogData("spPro_InsertLogData", "XOA HĐ Admin action", Common.getPermissionType(SettingCodeDB.USERNAME_Admin, SettingCodeDB.PASSWORD_Admin).ToString(), "uctDeleteOrder", strData);
                        }
                        clsSQL.CommitTrans();
                        txtOrder.Text = string.Empty;
                        txtSalary.Text = string.Empty;

                        Program.MessagerInfo("Xóa Hóa Đơn Xuất Thành Công", "Delete Order");
                    }
                    else
                    {
                        Program.MessagerInfo("Vui lòng bấm lấy Data", "Delete Order");
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                clsSQL.RollBackTrans();
                Program.MessagerErr(ex.ToString(), "Delete Order");
            }
            
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {

                if (XtraMessageBox.Show("Bạn có chắc chắn muốn làm mới HĐ :" + Common.ParseInt(txtOrder.Text), "Change Order Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {


                    param = new QryParam();
                    param.Add("@Order_ID", SqlDbType.Int, Common.ParseInt(txtOrder.Text));
                    tbDetails = new DataTable();
                    GetDelete_Order = clsSQL.GetTableStore("spOD_frmEdit_ListDetail", param);
                    if (GetDelete_Order != null && GetDelete_Order.Rows.Count == 0)
                    {
                        Program.MessagerInfo("Hóa Đơn Không Tồn Tại", "Delete Order");
                    }
                    else
                    {

                        string strData = string.Empty;
                        clsSQL.BeginTrans();
                        param.Clear();
                        #region Copy New Order
                        int iOrder_ID = 0;
                        string outData = string.Empty;
                        //  Insert moi Hoa Don

                        param.Add("@OrderIdOld", SqlDbType.Int, Common.ParseInt(txtOrder.Text));
                        param.AddOutput("@Order_ID", SqlDbType.Int, 0);
                        clsSQL.ExecStore("spOD_Copy", param, out outData);
                        strData = strData + outData;
                        iOrder_ID = Common.ParseInt(param.GetValue("@Order_ID"));

                        // Inser moi Chi Tiet Hoa Don
                        param.Clear();
                        outData = string.Empty;
                        param.Add("@OrderIdOld", SqlDbType.Int, Common.ParseInt(txtOrder.Text));
                        param.Add("@Order_ID", SqlDbType.Int, iOrder_ID);
                        clsSQL.ExecStore("spODD_Copy", param, out outData);
                        strData = strData + outData;
                        #endregion

                        #region xoa san pham trong Hoa Don
                        if (GetDelete_Order != null)
                        {


                            // get tong luong con lai hien tai
                            Decimal totalSalary = 0;
                            string sQuerySalary = "SElect (TotalSalary - ReturnMoney) as TotalSalary  From tbl_TotalSalary where Emp_ID =" + Common.ParseInt(GetDelete_Order.Rows[0]["Emp_ID"]);
                            tbCurrentSalary = new DataTable();
                            tbCurrentSalary = clsSQL.GetTableSQL(sQuerySalary);
                            if (tbCurrentSalary != null && tbCurrentSalary.Rows.Count > 0)
                            {
                                totalSalary = Common.ParseDecimal(tbCurrentSalary.Rows[0]["TotalSalary"]);
                            }
                            else
                            {
                                totalSalary = 0;
                            }

                            //update Lương
                            sQuerySalary = "UPDATE tbl_totalsalary SET TotalSalary =  (TotalSalary - " +
                                Common.ParseDecimal(txtSalary.Text) + ") WHERE Emp_ID = " + Common.ParseInt(GetDelete_Order.Rows[0]["Emp_ID"]);
                            clsSQL.ExecSQL(sQuerySalary);
                            strData = strData + " " + sQuerySalary;

                            // Delete chi tiết HĐ
                            foreach (DataRow dr in GetDelete_Order.Rows)
                            {
                                param.Clear();
                                param.Add("@OrderID", SqlDbType.Int, Common.ParseInt(dr["Order_ID"]));
                                param.Add("@OrderDetail_ID", SqlDbType.Int, Common.ParseInt(dr["OrderDetail_ID"]));
                                param.Add("@Product_ID", SqlDbType.Int, Common.ParseInt(dr["Product_ID"]));
                                param.Add("@PriceImport", SqlDbType.Decimal, Common.ParseDecimal(dr["Price_Import"]));
                                param.Add("@Price", SqlDbType.Decimal, Common.ParseDecimal(dr["Price"]));
                                param.Add("@Quantity", SqlDbType.Int, Common.ParseInt(dr["Quantity"]));
                                param.Add("@QuantityPromotion", SqlDbType.Int, Common.ParseInt(dr["QuantityPromotion"]));
                                string outParmater = string.Empty;
                                clsSQL.ExecStore("spDelete_OrderDetails", param, out outParmater);
                                strData = strData + " " + outParmater;
                            }

                            if (strData.Trim().Length > 0)
                            {
                                clsSQL.InsertLogData("spPro_InsertLogData", "Change Order Error", Common.getPermissionType(SettingCodeDB.USERNAME_Admin, SettingCodeDB.PASSWORD_Admin).ToString(), "uctDeleteOrder", strData);
                            }

                        }
                        #endregion

                        #region DELETE replaytionship
                        String sQuery = string.Empty;

                        // DELETE
                        sQuery = "DELETE FROM tbl_Salaries WHERE Order_ID =" + Common.ParseInt(txtOrder.Text);
                        clsSQL.ExecSQL(sQuery);

                        sQuery = string.Empty;
                        sQuery = "DELETE FROM tbl_PaymentOrders WHERE Order_ID =" + Common.ParseInt(txtOrder.Text);
                        clsSQL.ExecSQL(sQuery);

                        sQuery = string.Empty;
                        sQuery = "DELETE FROM tbl_ChangeProducts WHERE Order_ID =" + Common.ParseInt(txtOrder.Text);
                        clsSQL.ExecSQL(sQuery);

                        //delete Order 
                        sQuery = string.Empty;
                        sQuery = "DELETE FROM tbl_Orders WHERE Order_ID =" + Common.ParseInt(txtOrder.Text);
                        clsSQL.ExecSQL(sQuery);
                        #endregion

                        clsSQL.CommitTrans();
                        txtOrder.Text = string.Empty;
                        txtSalary.Text = string.Empty;
                        Program.MessagerInfo("Làm mới hóa đơn thành công !", "Change Order Error");
                    }
                }
            }
            catch (Exception ex)
            {
                clsSQL.RollBackTrans();
                Program.MessagerErr(ex.ToString(), "Delete Order");
            }
            
        }


    }
}
