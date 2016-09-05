using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Management.Salaries;
using Management.Commons.SQL;
namespace Management.Human
{
    public partial class uctHumanManager : DevExpress.XtraEditors.XtraUserControl
    {
        QryData clsSQL;
        QryParam clsParam;
        public uctHumanManager()
        {
            InitializeComponent();
        }

        public void Print()
        {
            gcHuman.ShowPrintPreview();
        }
        private void uctHumanManager_Load(object sender, EventArgs e)
        {
            try
            {
               
                    //EntryDate
                btnGetData_Click(null, null);
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "HUMAN MANAGER");
            }
        }

        private void gvHuman_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                clsParam = new QryParam();
                string sErr = "";
                bool bValid = true;
                if (gvHuman.GetRowCellValue(e.RowHandle, "EmpName").ToString() == "")
                {
                    sErr = sErr + "Vui lòng nhập Tên Nhân Viên." + Environment.NewLine;
                    bValid = false;
                }

                if (gvHuman.GetRowCellValue(e.RowHandle, "Address").ToString() == "")
                {
                    sErr = sErr + "Vui lòng nhập Địa chỉ." + Environment.NewLine;
                    bValid = false;
                }

                if (gvHuman.GetRowCellValue(e.RowHandle, "PeopleID").ToString() == "")
                {
                    sErr = sErr + "Vui lòng nhập số CMND." + Environment.NewLine;
                    bValid = false;

                }
                else
                {
                    int iCheckCM = 0;
                    for (int i = 0; i < gvHuman.RowCount ; i++)
                    {
                        if (gvHuman.GetRowCellValue(i, "PeopleID").ToString() == gvHuman.GetRowCellValue(e.RowHandle, "PeopleID").ToString())
                        {
                            iCheckCM = iCheckCM + 1;
                            
                        }
                    }
                    if (iCheckCM > 1)
                    {
                        bValid = false;
                        sErr = sErr + "Đã tồn tại số CMND";
                    }
                }
                if (gvHuman.GetRowCellValue(e.RowHandle, "Phone").ToString () == "")
                {
                    sErr = sErr + "Vui lòng nhập SĐT." + Environment.NewLine;
                    bValid = false;
                }

                if (gvHuman.GetRowCellValue(e.RowHandle, "EntryDate").ToString() == "")
                {
                    sErr = sErr + "Vui lòng nhập Ngày Vào.";
                    bValid = false;
                }
                if (!bValid)
                {

                    XtraMessageBox.Show(sErr, "QUAN LY  NHAN VIEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Valid = false;
                }
                else
                {
                    if (e.RowHandle < 0)
                    {
                        clsSQL = new QryData(Program.config.ConnectionString);
                       
                        clsParam.Add("@EmpName", SqlDbType.NVarChar, gvHuman.GetRowCellValue(e.RowHandle, "EmpName"));
                        clsParam.Add("@Address", SqlDbType.NVarChar, gvHuman.GetRowCellValue(e.RowHandle, "Address"));
                        clsParam.Add("@PeopleID", SqlDbType.VarChar, gvHuman.GetRowCellValue(e.RowHandle, "PeopleID"));
                        clsParam.Add("@Phone", SqlDbType.VarChar, gvHuman.GetRowCellValue(e.RowHandle, "Phone"));
                        clsParam.Add("@EntryDate", SqlDbType.DateTime, gvHuman.GetRowCellValue(e.RowHandle, "EntryDate"));
                        clsParam.Add("@Status", SqlDbType.Bit, gvHuman.GetRowCellValue(gvHuman.FocusedRowHandle, "Status"));
                        clsSQL.ExecStore("spEmp_Ins", clsParam);
                    }
                    else
                    {
                        clsParam = new QryParam();
                        clsParam.Add("@EmpName", SqlDbType.NVarChar, gvHuman.GetRowCellValue(e.RowHandle, "EmpName"));
                        clsParam.Add("@Address", SqlDbType.NVarChar, gvHuman.GetRowCellValue(e.RowHandle, "Address"));
                        clsParam.Add("@PeopleID", SqlDbType.VarChar, gvHuman.GetRowCellValue(e.RowHandle, "PeopleID"));
                        clsParam.Add("@Phone", SqlDbType.VarChar, gvHuman.GetRowCellValue(e.RowHandle, "Phone"));
                        clsParam.Add("@EntryDate", SqlDbType.DateTime, gvHuman.GetRowCellValue(e.RowHandle, "EntryDate"));
                        clsParam.Add("@EmpID", SqlDbType.Int, gvHuman.GetRowCellValue(gvHuman.FocusedRowHandle, "Emp_ID"));
                        clsParam.Add("@Status", SqlDbType.Bit, gvHuman.GetRowCellValue(gvHuman.FocusedRowHandle, "Status"));
                        clsSQL.ExecStore("spEmp_Update", clsParam);
                    }

                }
                
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.ToString(), "QUAN LI NHAN VIEN");
            }      
                   
        }

        private void gvHuman_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gcHuman_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && gvHuman.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                {
                   
                    //if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa???", "QUAN LY NHAN VIEN", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    //{
                        
                    //    //clsSQL = new QryData(Program.config.ConnectionString);
                    //    //clsParam=new QryParam ();
                    //    //clsParam.Add("@EmpID",SqlDbType.Int,gvHuman.GetRowCellValue(gvHuman.FocusedRowHandle ,"Emp_ID"));
                    //    //clsSQL.ExecStore("spEmp_Del",clsParam );
                    //    //gvHuman.DeleteRow(gvHuman.FocusedRowHandle);
                    //}
                }
            }
            catch (Exception ex)
            {
                
                XtraMessageBox.Show(ex.ToString(), "QUAN LI NHAN VIEN",MessageBoxButtons.OK,MessageBoxIcon.Error );
            }
        }

        private void gvHuman_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                 gvHuman.SetRowCellValue(e.RowHandle, "Status",false  );
            }
            catch (Exception ex)
            {
                
                Program.MessagerErr(ex.ToString(),"Quan Ly Nhan Vien");
            }
        }

        private void gcHuman_Click(object sender, EventArgs e)
        {
           
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            try
            {
                clsSQL = new QryData(Program.config.ConnectionString);
                clsParam = new QryParam();
                clsParam.Add("@Status", SqlDbType.SmallInt, radOption.EditValue);
                gcHuman.DataSource = clsSQL.GetTableStore("spEmp_List",clsParam );

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "QUAN LI NHAN VIEN");
            }
        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
            try
            {
                frmSalary frmSal = new frmSalary();
                frmSal.Form_Closing += btnGetData_Click;
                frmSal.ShowDialog();
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "XUAT HOA DON");
            }
        }

        private void btnSalaryPercents_Click(object sender, EventArgs e)
        {
            try
            {
                //frmSalaryPercents obj = new frmSalaryPercents();
                //obj.ShowDialog();
                frmEmpSalary obj = new frmEmpSalary();
                obj.ShowDialog();
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "NHAN VIEN");
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                frmImportSalaryPercents obj = new frmImportSalaryPercents();
                obj.ShowDialog();
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "QUAN LY NHAN VIEN");
            }
        }

    }
}
