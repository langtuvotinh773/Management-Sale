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
namespace Management.Human
{
    public partial class uctReportRevenueEmp : DevExpress.XtraEditors.XtraUserControl
    {
        QryData clsSQL;
        QryParam param;
       

        DataTable tbEmp;

        public uctReportRevenueEmp()
        {
            InitializeComponent();
        }
        public void Print()
        {
            gcShowInformation.ShowPrintPreview();
        }
        private void uctReportRevenueEmp_Load(object sender, EventArgs e)
        {
            try
            {
                clsSQL = new QryData(Program.config.ConnectionString);
                toDate.EditValue = DateTime.Now.AddMonths(-1);
                fromDate.EditValue = DateTime.Now;




                string sQueryEmp = "Select Emp_ID,EmpName,Address From tbl_Employees where Emp_ID != 32 AND STATUS = 0 Order by EmpName";
                cboEmp.Properties.DataSource = clsSQL.GetTableSQL(sQueryEmp);
                cboEmp.Properties.DisplayMember = "EmpName";
                cboEmp.Properties.ValueMember = "Emp_ID";
                cboEmp.ItemIndex = 0;

                string sQueryCust = "Select Cust_ID,CustName,Address From tbl_Customers Order by CustName";
                cboCompany.Properties.DataSource = clsSQL.GetTableSQL(sQueryCust);
                cboCompany.Properties.DisplayMember = "CustName";
                cboCompany.Properties.ValueMember = "Cust_ID";
                cboCompany.ItemIndex = 0;



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
            cboCompany.Enabled = !cbAllCust.Checked;
        }

        private void toDate_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            
            param = new QryParam();
            try
            {
                //cboCompany
                int Emp_ID = Common.ParseInt(cboEmp.EditValue);
                int Cust_ID = Common.ParseInt( cboCompany.EditValue);
                string to = Convert.ToDateTime(toDate.EditValue).ToShortDateString() + " 00:00:00";
                string from = Convert.ToDateTime(fromDate.EditValue).ToShortDateString() + " 23:59:59";

                if (Cust_ID == 0 || cbAllCust.Checked == true)
                {
                    param.Add("@Emp_ID", SqlDbType.Int, Emp_ID);
                    param.Add("@FromDate", SqlDbType.DateTime, to);
                    param.Add("@ToDate", SqlDbType.DateTime, from);
                    gcShowInformation.DataSource = clsSQL.GetTableStore("spDoanhThuEmp", param);
                }
                else {
                    param.Add("@Emp_ID", SqlDbType.Int, Emp_ID);
                    param.Add("@Cust_ID", SqlDbType.Int, Cust_ID);
                    param.Add("@FromDate", SqlDbType.DateTime, to);
                    param.Add("@ToDate", SqlDbType.DateTime, from);
                    gcShowInformation.DataSource = clsSQL.GetTableStore("spDoanhThuEmp_Detail", param);
                }

              

       

            }
            catch
            {


            }
        }

        private void gcShowInformation_Click(object sender, EventArgs e)
        {

        }
    }
}
