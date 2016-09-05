using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Management.Customers;
using Management.Commons.SQL;
using Management.Commons;
namespace Management.Custommer
{
    public partial class uctCustommerManager : DevExpress.XtraEditors.XtraUserControl
    {
        QryData clsSQL;
        QryParam clsParam;

        public uctCustommerManager()
        {
            InitializeComponent();
        }
        public void Print()
        {
            gcCustommer.ShowPrintPreview();
        }

        

        private void gcCustommer_Click(object sender, EventArgs e)
        {

        }

        private void gcCustommer_ProcessGridKey(object sender, KeyEventArgs e)
        
        {
            try
            {
                if (e.KeyCode == Keys.Delete && gvCustommer.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                {
                 //   Print();
                    if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa???", "QUAN LY KHACH HANG", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        clsSQL = new QryData(Program.config.ConnectionString);
                        clsParam = new QryParam();
                        clsParam.Add("@Cust_ID", SqlDbType.Int, gvCustommer.GetRowCellValue(gvCustommer.FocusedRowHandle, "Cust_ID"));
                        clsSQL.ExecStore("spCust_Del", clsParam);
                        gvCustommer.DeleteRow(gvCustommer.FocusedRowHandle);
                    }
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.ToString(), "QUAN LI KHACH HANG", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvCustommer_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
           
            try
            {
                clsParam = new QryParam();
                string sErr = "";
                bool bValid = true;
                if (gvCustommer.GetRowCellValue(e.RowHandle, "CustName").ToString() == "")
                {
                    sErr = sErr + "Vui lòng nhập Tên Khách Hàng." + Environment.NewLine;
                    bValid = false;
                }

                if (gvCustommer.GetRowCellValue(e.RowHandle, "Address").ToString() == "")
                {
                    sErr = sErr + "Vui lòng nhập Địa chỉ." + Environment.NewLine;
                    bValid = false;
                }


                if (gvCustommer.GetRowCellValue(e.RowHandle, "Phone").ToString() == "")
                {
                    sErr = sErr + "Vui lòng nhập SĐT." + Environment.NewLine;
                    bValid = false;
                }


                if (!bValid)
                {

                    XtraMessageBox.Show(sErr, "QUAN LY  KHACH HANG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Valid = false;
                }
                else
                {
                    if (e.RowHandle ==Program.NEW_ROW )
                    {
                        clsSQL = new QryData(Program.config.ConnectionString);

                        clsParam.Add("@CustName", SqlDbType.NVarChar, gvCustommer.GetRowCellValue(e.RowHandle, "CustName"));
                        clsParam.Add("@Address", SqlDbType.NVarChar, gvCustommer.GetRowCellValue(e.RowHandle, "Address"));
                        clsParam.Add("@Phone", SqlDbType.VarChar, gvCustommer.GetRowCellValue(e.RowHandle, "Phone"));
                        clsSQL.ExecStore("spCust_Ins", clsParam);
                    }
                    else
                    {
                        clsParam = new QryParam();
                        clsParam.Add("@Cust_ID", SqlDbType.Int,Common.ParseInt( gvCustommer.GetRowCellValue(e.RowHandle, "Cust_ID")));
                        clsParam.Add("@CustName", SqlDbType.NVarChar, gvCustommer.GetRowCellValue(e.RowHandle, "CustName"));
                        clsParam.Add("@Address", SqlDbType.NVarChar, gvCustommer.GetRowCellValue(e.RowHandle, "Address"));
                        clsParam.Add("@Phone", SqlDbType.VarChar, gvCustommer.GetRowCellValue(e.RowHandle, "Phone"));
                        clsSQL.ExecStore("spCust_Update", clsParam);
                    }

                }

            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.ToString(), "QUAN LI KHACH HANG");
            }      
        }

        private void gvCustommer_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
           // gvCustommer.SetRowCellValue(e.RowHandle, "Address", "Nhập Địa Chỉ");
        }

        private void gvCustommer_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void uctCustommerManager_Load(object sender, EventArgs e)
        {
            try
            {
                clsSQL = new QryData(Program.config.ConnectionString);
                gcCustommer.DataSource = clsSQL.GetTableStore("spCust_List");

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "QUAN LI KHACH HANG");
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                frmImportCustomers obj = new frmImportCustomers();
                obj.ShowDialog();
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "QUAN LY SAN PHAM");
            }
        }

       

       
        
        

       
       
        

      

       

       

     
    }
}
