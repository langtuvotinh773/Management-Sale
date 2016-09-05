using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports;
using DevExpress.XtraEditors;

namespace Management
{
    public partial class frmShowPrint : DevExpress.XtraEditors.XtraForm
    {
        DevExpress.XtraReports.UI.XtraReport reportMain;
        string sTitle = "";
        public string MyTitle
        {
            set { sTitle = value; }
        }
        DataTable dt = new DataTable();
        public DataTable getSetDataSource
        {
            get { return dt; }
            set { dt = value; }
        }
        public DevExpress.XtraReports.UI.XtraReport MyReport
        {
            
            set { reportMain = value; }
        }

       
        public frmShowPrint()
        {
            InitializeComponent();
        }

        private void printControl1_Load(object sender, EventArgs e)
        {

        }

        private void frmShowPrint_Load(object sender, EventArgs e)
        {
            try
            {
               
                DevExpress.XtraReports.UI.XtraReport report = new DevExpress.XtraReports.UI.XtraReport();
                DataTable dtResult = new DataTable();
                dtResult = getSetDataSource;
                ////report.DataSource = dtResult;
                ////report.DataMember = dtResult.TableName;
                ////report.ShowRibbonPreviewDialog();

                //report.DataMember = "InvalidDataMember";
                //report.DataSource = getSetDataSource;
                //report.DataMember = "ValidDataMember";
                //report.ShowPreview();

                rptReportDetail.PrintingSystem = reportMain.PrintingSystem;
                reportMain.CreateDocument();

                //rptReportDetail.PrintingSystem = report.PrintingSystem;
                //var ls = getSetDataSource;
                //report.DataSource = ls;
                //report.CreateDocument();

            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "PRINT SYSTEM");
            }
        }
    }
}