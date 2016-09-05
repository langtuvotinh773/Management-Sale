using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using Management.Commons.SQL;
namespace Management.Partner
{
    public partial class uctPartnerManager : DevExpress.XtraEditors.XtraUserControl
    {
        QryData clsSQL;
        QryParam clsParam;
        public void Print()
        {
            gcPartner.ShowPrintPreview();
        }

        public uctPartnerManager()
        {
            InitializeComponent();
        }

        private void uctPartnerManager_Load(object sender, EventArgs e)
        {
            try
            {
                clsSQL = new QryData(Program.config.ConnectionString);
                gcPartner.DataSource = clsSQL.GetTableStore("spCompany_List");

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "QUAN LY PARTNER");
            }

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gvPartner_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {

        }

        private void gvPartner_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {

        }

        private void gvPartner_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                clsParam = new QryParam();
                string sErr = "";
                bool bValid = true;
                if (gvPartner.GetRowCellValue(e.RowHandle, "CompanyName").ToString() == "")
                {
                    sErr = sErr + "Vui lòng nhập Tên Khách Hàng." + Environment.NewLine;
                    bValid = false;
                }

                if (gvPartner.GetRowCellValue(e.RowHandle, "Address").ToString() == "")
                {
                    sErr = sErr + "Vui lòng nhập Địa chỉ." + Environment.NewLine;
                    bValid = false;
                }


                if (gvPartner.GetRowCellValue(e.RowHandle, "Phone").ToString() == "")
                {
                    sErr = sErr + "Vui lòng nhập SĐT." + Environment.NewLine;
                    bValid = false;
                }


                if (!bValid)
                {

                    XtraMessageBox.Show(sErr, "QUAN LY  Partner", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Valid = false;
                }
                else
                {
                    if (e.RowHandle < 0)
                    {
                        string strCompanyName = gvPartner.GetRowCellValue(e.RowHandle, "CompanyName").ToString().ToLower();
                        string strAddress = gvPartner.GetRowCellValue(e.RowHandle, "Address").ToString().ToLower();

                        clsSQL = new QryData(Program.config.ConnectionString);
                        string strCheckExist = "SElect Count(*) From tbl_Companies Where Lower(LTRIM(RTRIM(dbo.fLocDauTiengViet(CompanyName)))) = '" + Commons.Common.locDau(strCompanyName) + "' and Lower(LTRIM(RTRIM(dbo.fLocDauTiengViet(Address)))) = '" + Commons.Common.locDau(strAddress) + "'";
                        DataTable  tbCompanies = new DataTable();
                        tbCompanies = clsSQL.GetTableSQL(strCheckExist);
                        if (Commons.Common.ParseInt(tbCompanies.Rows[0][0].ToString()) == 0)
                        {
                            clsParam.Add("@CompanyName", SqlDbType.NVarChar, gvPartner.GetRowCellValue(e.RowHandle, "CompanyName"));
                            clsParam.Add("@Address", SqlDbType.NVarChar, gvPartner.GetRowCellValue(e.RowHandle, "Address"));
                            clsParam.Add("@Phone", SqlDbType.VarChar, gvPartner.GetRowCellValue(e.RowHandle, "Phone"));
                            clsSQL.ExecStore("spCompany_Ins", clsParam);
                            uctPartnerManager_Load(null, null);
                        }
                        else
                        {
                            XtraMessageBox.Show("Công ty " + strCompanyName.ToUpper() + " đã tồn tại !", "QUAN LY  Partner");
                            e.Valid = false;
                        }
                    }
                    else
                    {
                        clsParam = new QryParam();
                        clsParam.Add("@CompanyName", SqlDbType.NVarChar, gvPartner.GetRowCellValue(e.RowHandle, "CompanyName"));
                        clsParam.Add("@Address", SqlDbType.NVarChar, gvPartner.GetRowCellValue(e.RowHandle, "Address"));
                        clsParam.Add("@Phone", SqlDbType.VarChar, gvPartner.GetRowCellValue(e.RowHandle, "Phone"));
                        clsParam.Add("@Company_ID", SqlDbType.Int, gvPartner.GetRowCellValue(gvPartner.FocusedRowHandle, "Company_ID"));
                        clsSQL.ExecStore("spCompany_Update", clsParam);
                        uctPartnerManager_Load(null, null);
                    }

                }

            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.ToString(), "QUAN LY PARTNERT");
            }      
        }

        private void gcPartner_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && gvPartner.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                {
                    //   Print();
                    if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa???", "QUAN LY PARTNER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        clsSQL = new QryData(Program.config.ConnectionString);
                        clsParam = new QryParam();
                        clsParam.Add("@Company_ID", SqlDbType.Int, gvPartner.GetRowCellValue(gvPartner.FocusedRowHandle, "Company_ID"));
                        clsSQL.ExecStore("spCompany_Del", clsParam);
                        gvPartner.DeleteRow(gvPartner.FocusedRowHandle);
                    }
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.ToString(), "QUAN LI PARTNER", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcPartner_Click(object sender, EventArgs e)
        {

        }
    }
}
