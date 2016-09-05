using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Management.Commons.SQL;
namespace Management.Products
{
    public partial class uctLiabilities : DevExpress.XtraEditors.XtraUserControl
    {
        QryData clsSQL;
        QryParam param;
        public uctLiabilities()
        {
            InitializeComponent();
            clsSQL = new QryData(Program.config.ConnectionString);
        }

        public void Print()
        {
            try
            {
                gcLiabilities.ShowPrintPreview();
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "CONG NO");
            }
        }
        private void uctLiabilities_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable tbSalaryPer = new DataTable();
                string sQryEmpSource = "Select Emp_ID ,Address, EmpName,IsDefault From tbl_Employees where Status=0 Order by IsDefault DESC,EmpName ASC";
                cboTarget.Properties.DataSource = clsSQL.GetTableSQL(sQryEmpSource);
                cboTarget.Properties.ValueMember = "Emp_ID";
                cboTarget.Properties.DisplayMember = "EmpName";
                cboTarget.ItemIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            try
            {
                if (ckbCheckAll.Checked)
                {
                    param = new QryParam();
                    param.Add("@Emp_ID", SqlDbType.Int, 0);
                    gcLiabilities.DataSource = clsSQL.GetTableStore("sp_Liabilities", param);
                }
                else
                {
                    param = new QryParam();
                    param.Add("@Emp_ID", SqlDbType.Int, cboTarget.EditValue);
                    gcLiabilities.DataSource = clsSQL.GetTableStore("sp_Liabilities", param);
                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "CON NO");
            }
        }
    }
}
