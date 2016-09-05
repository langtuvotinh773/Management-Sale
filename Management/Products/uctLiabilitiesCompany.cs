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
    public partial class uctLiabilitiesCompany : DevExpress.XtraEditors.XtraUserControl
    {
        QryData clsSQL;
        DataTable tbCongNoCongTy;
        public uctLiabilitiesCompany()
        {
            InitializeComponent();
        }

        public void Print()
        {
            try
            {
                gcNoCongTy.ShowPrintPreview();
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "CONG NO");
            }
        }
        private void uctLiabilitiesCompany_Load(object sender, EventArgs e)
        {
            try
            {
                clsSQL = new QryData(Program.config.ConnectionString);
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "CONG NO");
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            try
            {
                tbCongNoCongTy = new DataTable();
                tbCongNoCongTy = clsSQL.GetTableStore("spReport_CongNoCongTy");
                gcNoCongTy.DataSource = tbCongNoCongTy;
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "CONG NO");
            }
        }
    }
}
