using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Management.Commons.SQL;
using Management.Commons.SQL;
namespace Management.UnitManager
{
    public partial class frmUnit : DevExpress.XtraEditors.XtraUserControl
    {
        QryData clsSQL;
        QryParam clsParam;
        public void Print()
        {
            grcUnit.ShowPrintPreview();
        }
        public frmUnit()
        {
            InitializeComponent();
        }

        private void frmUnit_Load(object sender, EventArgs e)
        {
            try
            {
                clsSQL = new QryData(Program.config.ConnectionString);
                grcUnit.DataSource = clsSQL.GetTableStore("spUnit_List");

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "QUAN LI DON VI TINH");
            }
        }

        private void grcUnit_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && grUnit.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                {
                    //   Print();
                    if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa???", "QUAN LY DON VI TINH", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        clsSQL = new QryData(Program.config.ConnectionString);
                        clsParam = new QryParam();
                        clsParam.Add("@Unit_ID", SqlDbType.Int, grUnit.GetRowCellValue(grUnit.FocusedRowHandle, "Unit_ID"));
                        clsSQL.ExecStore("spUnit_Del", clsParam);
                        grUnit.DeleteRow(grUnit.FocusedRowHandle);
                    }
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.ToString(), "QUAN LY DON VI TINH", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grUnit_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                clsParam = new QryParam();
                string sErr = "";
                bool bValid = true;
                if (grUnit.GetRowCellValue(e.RowHandle, "UnitName").ToString() == "")
                {
                    sErr = sErr + "Vui lòng nhập Đơn Vị Tính" + Environment.NewLine;
                    bValid = false;
                }
                else {

                    int iCheckCM = 0;
                    for (int i = 0; i < grUnit.RowCount; i++)
                    {
                        if (grUnit.GetRowCellValue(i, "UnitName").ToString() == grUnit.GetRowCellValue(e.RowHandle, "UnitName").ToString())
                        {
                            iCheckCM = iCheckCM + 1;

                        }
                    }
                    if (iCheckCM == 1)
                    {
                        bValid = false;
                        sErr = sErr + "Đơn Vị Tính Đã Tồn Tại";
                    }
                }

                //if (grUnit.GetRowCellValue(e.RowHandle, "UnitDesc").ToString() == "")
                //{
                //    sErr = sErr + "Vui lòng nhập Mô Tả." + Environment.NewLine;
                //    bValid = false;
                //}


                


                if (!bValid)
                {

                    XtraMessageBox.Show(sErr, "QUAN LY  DON VI TINH", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Valid = false;
                }
                else
                {
                    if (e.RowHandle < 0)
                    {
                        clsSQL = new QryData(Program.config.ConnectionString);

                        clsParam.Add("@UnitName", SqlDbType.NVarChar, grUnit.GetRowCellValue(e.RowHandle, "UnitName"));
                        clsParam.Add("@UnitDesc", SqlDbType.NVarChar, grUnit.GetRowCellValue(e.RowHandle, "UnitDesc"));
                        clsSQL.ExecStore("spUnit_Ins", clsParam);
                        frmUnit_Load(null, null);
                    }
                    else
                    {
                        clsParam = new QryParam();
                        clsParam.Add("@UnitName", SqlDbType.NVarChar, grUnit.GetRowCellValue(e.RowHandle, "UnitName"));
                        clsParam.Add("@UnitDesc", SqlDbType.NVarChar, grUnit.GetRowCellValue(e.RowHandle, "UnitDesc"));
                        clsSQL.ExecStore("spUnit_Update", clsParam);
                        frmUnit_Load(null, null);
                    }

                }

            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.ToString(), "QUAN LY DON VI TINH");
            }      
        }

        private void grUnit_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
           // grUnit.SetRowCellValue(e.RowHandle, "UnitName", "Nhập Địa Đơn Vị Tính");
        }

        private void grUnit_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grcUnit_Click(object sender, EventArgs e)
        {

        }

        
    }
}
