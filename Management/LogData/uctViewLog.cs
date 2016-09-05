using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Management.Commons.SQL;
using Management.Reports;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.Data;
using Management.Commons;

namespace Management.Products
{
    public partial class uctViewLog : DevExpress.XtraEditors.XtraUserControl
    {


        public uctViewLog()
        {
            InitializeComponent();
        }
        QryData clsSQL;
        QryParam param;
        string moneyPayment = "";
        DataTable tbCust, tbEmp, tbOrders, tbOrderDetails, tbPayments, tbProductChanges, dataTabletemp;

        private void uctViewLog_Load(object sender, EventArgs e)
        {
            try
            {
                 //gcViewLog.optionview.RowAutoHeight = true
                txtFromDate.EditValue = DateTime.Now.AddDays(-1);
                dateEnd.EditValue = DateTime.Now;
                clsSQL = new QryData(Program.config.ConnectionString);
               
                
                //

            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "HOA DON XUAT");
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            param = new QryParam();
            param.Add("@BeginDate", SqlDbType.DateTime, Convert.ToDateTime(Convert.ToDateTime(txtFromDate.EditValue).ToShortDateString() + " 00:00:01"));
            param.Add("@EndDate", SqlDbType.DateTime, Convert.ToDateTime(Convert.ToDateTime(dateEnd.EditValue).ToShortDateString() + " 23:59:59"));
           // tbOrders = clsSQL.GetTableStore("sp_GetLogData", param);
            gcViewLog.DataSource = clsSQL.GetTableStore("sp_GetLogData", param);
        }

        


    }
}
