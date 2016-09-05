using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Management.Commons.SQL;

namespace Management
{
    public partial class frmLogon : Form
    {
        QryData clsSQL;
        QryParam param;
        #region Delegate load Ipermission
        public delegate void iPermission();
        public iPermission updateData;
        #endregion

        public frmLogon()
        {
            InitializeComponent();
        }

        private void frmLogon_Load(object sender, EventArgs e)
        {
            clsSQL = new QryData(Program.config.ConnectionString);
        }

        private void btnLogon_Click(object sender, EventArgs e)
        {
            try
            {
                string Pass = Commons.Common.GetMd5Hash(txtPass.Text.ToString().ToLower().Trim());
                param = new QryParam();
                param.Add("@UserName", SqlDbType.VarChar, txtUser.Text.ToString().ToLower().Trim());
                param.Add("@PassWord", SqlDbType.VarChar, Pass);
                DataTable dtResult = new DataTable();
                dtResult = clsSQL.GetTableStore("spGet_PermissionType", param);
                int iCountUser = Commons.Common.ParseInt(dtResult.Rows[0][0]);
                
                if (iCountUser == 1)// Bao cao doanh thu
                {
                    clsSQL.BeginTrans();
                    param.Clear();
                    param.Add("@UserName", SqlDbType.VarChar, txtUser.Text.ToString().ToLower().Trim());
                    param.Add("@PassWord", SqlDbType.VarChar, Pass);
                    param.Add("@PermissionType", SqlDbType.TinyInt, 2);
                    clsSQL.ExecStore("spUpdate_PermissionType", param);
                    clsSQL.CommitTrans();
                    Program.MessagerInfo("Đăng Nhập Thành Công !", "LOGON");
                    Commons.Common.iPermission = 2;
                    updateData();
                    this.Close();
                    //showUctReportRevenue
                    //frmMain obj = new frmMain();
                    //obj.showUctReportRevenue();
                }
                else if (iCountUser == 2)
                {
                }
                else
                {
                    Program.MessagerErr("LogOn UnSuccess", "LOGON");
                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr("LogOn UnSuccess", "LOGON");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
          //  updateData();
            this.Close();
        }
    }
}
