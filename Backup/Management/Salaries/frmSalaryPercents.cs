using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Management.Commons.SQL;
namespace Management.Salaries
{
    public partial class frmSalaryPercents : DevExpress.XtraEditors.XtraForm
    {
        QryData clsSQL;
        QryParam param;
        public event EventHandler Form_Closing;
        DataTable tbSalaryPer;
        public frmSalaryPercents()
        {
            InitializeComponent();
        }

        private void frmSalaryPercents_Load(object sender, EventArgs e)
        {
            try
            {
                clsSQL = new QryData(Program.config.ConnectionString);
                tbSalaryPer = new DataTable();

                tbSalaryPer = clsSQL.GetTableStore("spSalPer_List");
                gcSalaryPercent.DataSource = tbSalaryPer;

                string sQryEmpSource = "Select Emp_ID ,Address, EmpName,IsDefault From tbl_Employees where Status=0 Order by IsDefault DESC,EmpName ASC";
                cboSource.Properties.DataSource = clsSQL.GetTableSQL(sQryEmpSource);
                cboSource.Properties.ValueMember = "Emp_ID";
                cboSource.Properties.DisplayMember  = "EmpName";
                cboSource.ItemIndex = 0;
               
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "PHAN TRAM TINH LUONG");
            }
        }

        private void gvSalaryPercent_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                if (gvSalaryPercent.GetRowCellValue(e.RowHandle,"Percents")==null )
                {
                    e.Valid = false;
                      Program.MessagerErr("Vui lòng nhập giá trị vào cột Phần Trăm.","PHAN TRAM TINH LUONG");
                }
                else
                {
                    if (gvSalaryPercent.GetRowCellValue(e.RowHandle, "Percents").ToString().Trim() == "")
                    {
                        e.Valid = false;
                        Program.MessagerErr("Vui lòng nhập giá trị vào cột Phần Trăm.", "PHAN TRAM TINH LUONG");
                    }
                    else
                    {
                        if (Convert.ToInt32(gvSalaryPercent.GetRowCellValue(e.RowHandle, "Percents")) < 0)
                        {
                            e.Valid = false;
                            Program.MessagerErr("Vui lòng nhập % >0 hoặc =0.", "PHAN TRAM TINH LUONG");


                        }
                        else
                        {
                            param = new QryParam();
                            param.Add("@Percent", SqlDbType.SmallInt, Convert.ToInt32(gvSalaryPercent.GetRowCellValue(e.RowHandle, "Percents")));
                            param.Add("@Note", SqlDbType.NVarChar, gvSalaryPercent.GetRowCellValue(e.RowHandle, "Note"));
                            param.Add("@SalaryPercent_ID", SqlDbType.SmallInt, Convert.ToInt32(gvSalaryPercent.GetRowCellValue(e.RowHandle, "SalaryPercent_ID")));
                            clsSQL.ExecStore("spSalPer_Edit", param);
                        }
                    }
                    
                }
                
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "PHAN TRAM TINH LUONG");
            }
        }

        private void gvSalaryPercent_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gcSalaryPercent_Click(object sender, EventArgs e)
        {

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn có chắc chắn muốn sao chép?","CHU Y",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes )
                {
                    param = new QryParam();
                    param.Add("@Emp_IDSource", SqlDbType.Int, Convert.ToInt32( cboSource.EditValue));
                    param.Add("@Emp_IDTarget", SqlDbType.Int, Convert.ToInt32(cboTarget .EditValue));
                    clsSQL.ExecStore("spSalary_CopyPercent", param);
                    Program.MessagerInfo("Sao chép thành công!", "TINH LUONG");
                }
                frmSalaryPercents_Load(null,null);
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "TINH LUONG");
            }
        }

        private void cboSource_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sQryEmpTarget = "Select Emp_ID ,Address , EmpName From tbl_Employees where Status=0 And IsDefault=0 And Emp_ID <>" + Convert.ToInt32(cboSource.EditValue).ToString() + " Order by EmpName";
                 cboTarget.Properties.DataSource = clsSQL.GetTableSQL(sQryEmpTarget);
                 cboTarget.Properties.ValueMember = "Emp_ID";
                 cboTarget.Properties.DisplayMember = "EmpName";
                 cboTarget.ItemIndex = 0;
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "TINH LUONG");
            }
        }

        private void btnUpdateFast_Click(object sender, EventArgs e)
        {
            frmEmpSalary obj = new frmEmpSalary();
            obj.Show();
        }

       
    }
}