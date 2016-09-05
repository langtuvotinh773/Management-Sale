using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Management.Commons;

using Management.Commons.SQL;
using Management.Commons.SQL;
namespace Management.Human
{
    public partial class uctReportRevenue : DevExpress.XtraEditors.XtraUserControl
    {
        QryData clsSQL;
        QryParam param;
       

        DataTable tbEmp;

        public uctReportRevenue()
        {
            InitializeComponent();
        }
        public void Print()
        {
            gcShowInformation.ShowPrintPreview();
        }
        private void uctReportRevenue_Load(object sender, EventArgs e)
        {
            try
            {
                clsSQL = new QryData(Program.config.ConnectionString);
                toDate.EditValue = DateTime.Now.AddMonths(-1);
                fromDate.EditValue = DateTime.Now;

                //clsSQL.BeginTrans();
                //clsSQL.ExecStore("deleteDoanhThu");
                //clsSQL.CommitTrans();



            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "HOA DON XUAT");
            }
        }

        

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
          //  cboEmp.Enabled = cbAllEmployee.Checked = false;
            cboEmp.Enabled = !cbAllEmployee.Checked;
        }

        private void toDate_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            
            
            try
            {
                string to = Convert.ToDateTime(toDate.EditValue).ToShortDateString() + " 00:00:00";
                string from = Convert.ToDateTime(fromDate.EditValue).ToShortDateString() + " 23:59:59";
            
                
                param = new QryParam();
                param.Add("@FromDate", SqlDbType.DateTime, to);
                param.Add("@ToDate", SqlDbType.DateTime, from);

                DataTable dtOrder = new DataTable();
                dtOrder = clsSQL.GetTableStore("spReportRevenune_SelectOrder", param);
                param = new QryParam();
                param.Add("@FromDate", SqlDbType.DateTime, to);
                param.Add("@ToDate", SqlDbType.DateTime, from);

                DataTable dtImportOrder = new DataTable();
                dtImportOrder = clsSQL.GetTableStore("spReportRevenune_SelectImportOrder", param);
                DataTable tableResult = new DataTable();
                tableResult = createDataTable();
                string col0,col1;
                string col2, col3, col4, col5, col6, col7, col8;
                foreach (DataRow dtRow in dtOrder.Rows)
                {
                    col0 = dtRow["Company_ID"].ToString();
                    col1 = dtRow["CompanyName"].ToString();
                    //col2 = dtRow["TienDuocTang"].ToString();
                    //col3 = dtRow["TongTienNhapHang"].ToString();
                    col4 = Common.ConvertStrMoney(dtRow["TongTienDaXuatHang"].ToString());
                    col5 = Common.ConvertStrMoney(dtRow["TongTienPhaiTraChoNV"].ToString());
                    col6 = Common.ConvertStrMoney(dtRow["LoiTrenPhanTramMaKHDaTra"].ToString());
                    col8 = Common.ConvertStrMoney(dtRow["TongTienDaNhapHang"].ToString());

                    // START Get TongTienDaNhapHang
                    param.Clear();
                    param.Add("@CompanyID", SqlDbType.Int, Common.ParseInt(col0));
                    param.Add("@FromDate", SqlDbType.DateTime, to);
                    param.Add("@ToDate", SqlDbType.DateTime, from);
                    DataTable dtGetTotalImportOrder = new DataTable();
                    dtGetTotalImportOrder = clsSQL.GetTableStore("spGetTongTienDaNhapHang", param);
                    col7 = Common.ParseString(dtGetTotalImportOrder.Rows[0]["TongTienDaNhapHang"]);
                    // END Get TongTienDaNhapHang

                    tableResult.Rows.Add(col0, col1, "", "", col4, col5, col6, col7, Common.ConvertStrMoney(col8));
                }
                foreach (DataRow dtImportOrderRow in dtImportOrder.Rows)
                {
                    int iAddNewRow = 0;
                    col0 = dtImportOrderRow["Company_ID"].ToString();
                    col1 = dtImportOrderRow["CompanyName"].ToString();
                    col2 = Common.ConvertStrMoney(dtImportOrderRow["TienDuocTang"].ToString());
                    col3 = Common.ConvertStrMoney(dtImportOrderRow["TongTienNhapHang"].ToString());
                    for (int i = 0; i < tableResult.Rows.Count; i++)
                    {
                        string strCol = tableResult.Rows [i].ItemArray[0].ToString();
                        if (Common.ParseInt(col0) == Common.ParseInt(strCol))
                        {
                            iAddNewRow =1;
                            tableResult.Rows[i][2] = col2;
                            tableResult.Rows[i][3] = col3;
                            tableResult.Rows[i][7] = Common.ConvertStrMoney(Common.ParseDecimal(col3) - Common.ParseDecimal(tableResult.Rows[i][7]));
                           break;
                        }
                    }
                    if(iAddNewRow ==0)
                    {
                        tableResult.Rows .Add (col0 ,col1 ,col2 ,col3,0,0 ,0);
                    }
                }
                gcShowInformation.DataSource = tableResult;


       

            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "DOANH THU");
            }
        }
        public static DataTable createDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("col_CompanyID");
            table.Columns.Add("CompanyName");
            table.Columns.Add("totalCastPromotion");
            table.Columns.Add("totalTotalMoney_Import");
            table.Columns.Add("totalTotalMoney_Order");
            table.Columns.Add("totalTotalMoney_Salary");
            
            table.Columns.Add("totalTienNhapHang");
            table.Columns.Add("TotalHangTonKho");
            table.Columns.Add("TotalOrder_Import");

            return table;
        }

        private void gcShowInformation_Click(object sender, EventArgs e)
        {

        }
    }
}
