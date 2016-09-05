using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Management.Commons.SQL;
namespace Management.Human
{
    public partial class uctExportSalary : DevExpress.XtraEditors.XtraUserControl
    {
        QryData clsSQL;
        QryParam param;
       

        DataTable tbEmp;

        public uctExportSalary()
        {
            InitializeComponent();
        }
        public void Print()
        {
            gcShowInformation.ShowPrintPreview();
        }
        private void uctExportSalary_Load(object sender, EventArgs e)
        {
            try
            {
                toDate.EditValue = DateTime.Now;
                fromDate.EditValue = DateTime.Now;
                clsSQL = new QryData(Program.config.ConnectionString);
                string sQueryEmp = "SElect Emp_ID, EmpName , Address From tbl_Employees where Emp_ID != 32 Order By EmpName";

                tbEmp = new DataTable();
                tbEmp = clsSQL.GetTableSQL(sQueryEmp);
                //

                cboEmp.Properties.DataSource = tbEmp;
                cboEmp.Properties.ValueMember = "Emp_ID";
                cboEmp.Properties.DisplayMember = "EmpName";
                cboEmp.ItemIndex = 0;

                //string Id = cboEmp.EditValue.ToString();
                //string sQuerySalary = "SElect TotalSalary From tbl_Salaries where Emp_ID =" + Common.ParseInt(Id);
                //tbEmp = clsSQL.GetTableSQL(sQuerySalary);
                //cboEmp.Properties.DisplayMember = "txtTotalSalary";

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
            param = new QryParam();
            try
            {

                string to = Convert.ToDateTime(toDate.EditValue).ToShortDateString() + " 00:00:00";
                string from = Convert.ToDateTime(fromDate.EditValue).ToShortDateString() + " 23:59:59";

            if (cbAllEmployee.Checked)
            {

                param.Add("@toDate", SqlDbType.DateTime, to);
                param.Add("@fromDate", SqlDbType.DateTime, from);
                gcShowInformation.DataSource = clsSQL.GetTableStore("spExportListAll", param);
            }
            else {
                string Id = cboEmp.EditValue.ToString();
                param.Add("@Emp_ID", SqlDbType.Int, Id);
                param.Add("@toDate", SqlDbType.DateTime, to);
                param.Add("@fromDate", SqlDbType.DateTime, from);
                gcShowInformation.DataSource = clsSQL.GetTableStore("spExportList", param);

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
