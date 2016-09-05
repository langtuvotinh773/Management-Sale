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
    public partial class uctImportReport : DevExpress.XtraEditors.XtraUserControl
    {
        QryData clsSQL;
        QryParam param;
        public uctImportReport()
        {
            InitializeComponent();
        }
       public  void Print()
        {
            pivImportReport.ShowPrintPreview();
        }
        private void uctImportReport_Load(object sender, EventArgs e)
        {
            dateBegin.EditValue = DateTime.Now;
            dateEnd.EditValue = DateTime.Now;
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            try
            {
                clsSQL = new QryData(Program.config.ConnectionString);
                param = new QryParam();
                param.Add("@BeginDate", SqlDbType.DateTime,Convert.ToDateTime (Convert.ToDateTime( dateBegin.EditValue).ToShortDateString() ));
                param.Add("@EndDate", SqlDbType.DateTime, Convert.ToDateTime (Convert.ToDateTime( dateEnd.EditValue).ToShortDateString() ));
                pivImportReport.DataSource = clsSQL.GetTableStore("spIO_Report", param);
                param = param.Copy();
                pivExport.DataSource = clsSQL.GetTableStore("spOD_Report", param);
            }
            catch (Exception ex)
            {
                Program.MessagerErr(ex.ToString(), "BAO CAO");
                
            }
            
        }
    }
}
