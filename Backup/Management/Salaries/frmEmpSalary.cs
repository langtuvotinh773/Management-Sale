using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Management.Commons.SQL;
using DevExpress.XtraEditors;
using Management.Commons;

namespace Management.Salaries
{
    public partial class frmEmpSalary : Form
    {

        QryData clsSQL;
        QryParam param;
        public event EventHandler Form_Closing;
        DataTable tbSalaryPer;
        public frmEmpSalary()
        {
            InitializeComponent();
            clsSQL = new QryData(Program.config.ConnectionString);
        }

        private void frmEmpSalary_Load(object sender, EventArgs e)
        {
            try
            {
                tbSalaryPer = new DataTable();
                string sQryEmpSource = "Select Emp_ID ,Address, EmpName,IsDefault From tbl_Employees where Status=0 Order by IsDefault DESC,EmpName ASC";
                cboTarget.Properties.DataSource = clsSQL.GetTableSQL(sQryEmpSource);
                cboTarget.Properties.ValueMember = "Emp_ID";
                cboTarget.Properties.DisplayMember = "EmpName";
                cboTarget.ItemIndex = 0;
                string sQueryCompany = "Select Company_ID, CompanyName, Address From tbl_Companies Order by CompanyName";
                cboCompany.Properties.DataSource = clsSQL.GetTableSQL(sQueryCompany);
                cboCompany.Properties.DisplayMember = "CompanyName";
                cboCompany.Properties.ValueMember = "Company_ID";
                cboCompany.ItemIndex = 0;

            }
            catch (Exception ex)
            {
                Program.MessagerErr(ex.ToString(), "PHAN TRAM TINH LUONG");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                getDataProduct();
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "SAN PHAM");
            }
        }
        public void getDataProduct()
        {
            try
            {
                DataTable tbResult = new DataTable();
                if (ckbCheckAll.Checked)
                {
                    tbResult.Clear();
                    param = new QryParam();
                    param.Add("@Emp_ID", SqlDbType.Int, cboTarget.EditValue);
                    param.Add("@Company_ID", SqlDbType.Int, 0);
                    param.Add("@ProductName", SqlDbType.NVarChar, txtProductName.Text.Trim());
                    tbResult = clsSQL.GetTableStore("spSelect_EmpSalaryList", param);
                }
                else
                {
                    tbResult.Clear();
                    param = new QryParam();
                    param.Add("@Emp_ID", SqlDbType.Int, cboTarget.EditValue);
                    param.Add("@Company_ID", SqlDbType.Int, cboCompany.EditValue);
                    param.Add("@ProductName", SqlDbType.NVarChar, txtProductName.Text.Trim());
                    tbResult = clsSQL.GetTableStore("spSelect_EmpSalaryList", param);
                }
                grcSalary.DataSource = tbResult;
            }
            catch (Exception e)
            {
                Program.MessagerErr(e.ToString(), "SAN PHAM");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Tất cả sản phẩm trên lưới sẽ được cập nhật lại % tính lương !", "Cập Nhật Lương", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int iRows = gvSalary.RowCount;
                    if (iRows == 0)
                    {
                        MessageBox.Show("Chưa có sản phẩm nào trên lưới", "Cập Nhật Phần Trăm Tính Lương");
                    }
                    else
                    {
                        if (Common.ParseDecimal(txtPersent.Text.Trim()) > 0)
                        {
                            clsSQL.BeginTrans();
                            for (int i = 0; i < gvSalary.RowCount; i++)
                            {
                                int SalaryPercent_ID = Common.ParseInt(gvSalary.GetRowCellValue(i, "SalaryPercent_ID"));
                                param.Clear();
                                param.Add("@Percent", SqlDbType.SmallInt, txtPersent.Text.Trim());
                                param.Add("@Note", SqlDbType.NVarChar, "Cập Nhật Nhanh");
                                param.Add("@SalaryPercent_ID", SqlDbType.Int, SalaryPercent_ID);
                                clsSQL.ExecStore("spSalPer_Edit", param);
                            }
                            clsSQL.CommitTrans();
                            MessageBox.Show("Cập Nhật Thành Công !", "Cập Nhật Nhanh");
                            btnSearch_Click(null, null);
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập % tính lương.", "Cập Nhật Nhanh");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsSQL.RollBackTrans();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
