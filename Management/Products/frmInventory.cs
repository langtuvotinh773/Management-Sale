using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using Management.Commons.SQL;
using Management.Commons.SQL;
namespace Management.Products
{
    
    public partial class frmInventory : DevExpress.XtraEditors.XtraForm
    {
        QryData clsSql;
        QryParam param;
        public frmInventory()
        {
            InitializeComponent();
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {
            try
            {
                clsSql = new QryData(Program.config.ConnectionString);
                dtEnd.EditValue = DateTime.Now;
                dtBegin.EditValue = DateTime.Now.AddMonths(-1);




                string sQryCompany = "Select Company_ID,Address, CompanyName From tbl_Companies Order By CompanyName";
                cboCompany.Properties.DataSource = clsSql.GetTableSQL(sQryCompany);
                cboCompany.Properties.DisplayMember = "CompanyName";
                cboCompany.Properties.ValueMember = "Company_ID";
            }
            catch (Exception ex)
            {
                
                Program.MessagerErr(ex.ToString(),"BAO CAO NHAP XUAT TON");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
           // gcMain.ShowPrintPreview();

            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());

            link.Component = gcMain;

            link.Landscape = true;

            link.ShowPreview();
            //gcMain.ShowPrintPreview();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            try
            {

                if (Commons.Common.ParseInt(cboCompany.EditValue) == 0 && ckbAll.Checked == false)
                {
                    string sErr = "Vui Lòng Chọn Công Ty Cần Tìm Kiếm";
                    Program.MessagerErr(sErr, "BAO CAO NHAP XUAT TON");
                }
                else if (ckbAll.Checked == true)
                {
                    DataTable tbMain = new DataTable();
                    param = new QryParam();
                    param.Add("@BeginDate", SqlDbType.DateTime, dtBegin.EditValue);
                    param.Add("@EndDate", SqlDbType.DateTime, dtEnd.EditValue);
                    tbMain = clsSql.GetTableStore("spReport_InventoryUpdate_All", param);
                    gcMain.DataSource = tbMain;
                }
                else if (Commons.Common.ParseInt(cboCompany.EditValue) != 0 && ckbAll.Checked == false)
                {
                    DataTable tbMain = new DataTable();
                    param = new QryParam();
                    param.Add("@CompanyID", SqlDbType.Int, Commons.Common.ParseInt(cboCompany.EditValue));
                    param.Add("@ProductName", SqlDbType.NVarChar, txtProductName.Text.Trim());
                    param.Add("@BeginDate", SqlDbType.DateTime, dtBegin.EditValue);
                    param.Add("@EndDate", SqlDbType.DateTime, dtEnd.EditValue);
                    tbMain = clsSql.GetTableStore("spReport_InventoryUpdate_16042013", param);
                    gcMain.DataSource = tbMain;
                }
            }
            catch (Exception ex)
            {
                
                Program.MessagerErr(ex.ToString(),"BAO CAO NHAP XUAT TON");
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string filepath = System.IO.Path.GetTempFileName();
            filepath = filepath.Remove(filepath.LastIndexOf('.') + 1);
            filepath = String.Concat(filepath, "xls");

            gcMain.ExportToXls(filepath);

            System.Diagnostics.ProcessStartInfo startInfo =
                 new System.Diagnostics.ProcessStartInfo("Excel.exe", String.Format("/r \"{0}\"", filepath));
            System.Diagnostics.Process.Start(startInfo);
        }

        private void btnExportexcel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ckbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbAll.Checked)
            {
                cboCompany.Enabled = false;
            }
            else { cboCompany.Enabled = true; }
        }

        
    }
}