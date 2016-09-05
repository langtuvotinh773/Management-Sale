using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.UserSkins;
using AddTab;
using DevExpress.XtraEditors;
//using Management.Commons.SQL;
using System.Data.SqlClient;
using System.Data;
using Management.Commons;
using Management.Commons.SQL;
using System.IO;
namespace Management
{
    
    static class Program
    {
       
        public static Config config;
        
       public  const int  NEW_ROW = (-2147483647);
 
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
       public  static void MessagerErr(string ex,string Caption)
        {
            XtraMessageBox.Show(ex.ToString(), Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        public static void MessagerWarning(string ex, string Caption)
        {
            XtraMessageBox.Show(ex.ToString(), Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning );
        }
        public static void MessagerInfo(string ex, string Caption)
        {
            XtraMessageBox.Show(ex.ToString(), Caption, MessageBoxButtons.OK, MessageBoxIcon.Information );
        }
        [STAThread]
        static void Main()
        {
           

            string sServer,sDatabase,sUserName, sPassWord,sSkinName;
            BonusSkins.Register();
            OfficeSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Office 2010 Silver";
            string FileXMLName = Application.StartupPath + @"\" + "Config.ini";
            
            if (System.IO.File.Exists(FileXMLName))
            {
                try
                {
                    config = new Config(FileXMLName);
                    sServer = config.GetValue("SERVER");
                    sDatabase = config.GetValue("DATABASE");
                    sUserName = Encryption.Decrypt(config.GetValue("USERNAME"), "CARAVEN", true);
                    sPassWord = Encryption.Decrypt(config.GetValue("PASSWORD"), "JET", true);
                    config.ConnectionString = "Data Source="+ sServer.Trim()+ ";Initial Catalog="+ sDatabase .Trim() +";User ID="+ sUserName.Trim () + ";Password=" + sPassWord.Trim()  ;
                    sSkinName = config.GetValue("SKINNAME");
                    DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = sSkinName ;
                    SqlConnection con = new SqlConnection(config.ConnectionString);
                    con.Open();
                    QryData clsSQL;
                    QryParam param;
                    param = new QryParam();
                    clsSQL = new QryData(Program.config.ConnectionString);
                    clsSQL.BeginTrans();

                    Common.updatePermissionType(SettingCodeDB.USERNAME_Admin, SettingCodeDB.PASSWORD_Admin, 1);
                    Common.updatePermissionType(SettingCodeDB.USERNAME_User, SettingCodeDB.PASSWORD_User, 1);

                    // insert LogData
                   /// clsSQL.InsertLogData("spPro_InsertLogData", SettingCodeDB.listActions.Logon.ToString(), "1", SettingCodeDB.listScreens.frmMain.ToString(), strData);
                    clsSQL.CommitTrans();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Không kết nối được với Cơ Sở Dữ Liệu." + Environment.NewLine + "Vui lòng cấu hình lại hệ thống ở cửa sổ sau!", "APPLICATION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    frmConfig configForm = new frmConfig();
                    configForm.ShowDialog();

                }
                
                // sẽ kiểm tra chuỗi kết nối có đúng hay không ở đây
            }
            else
            {
                XtraMessageBox.Show("Không kết nối được với Cơ Sở Dữ Liệu." + Environment.NewLine + "Vui lòng cấu hình lại hệ thống ở cửa sổ sau!","APPLICATION",MessageBoxButtons.OK,MessageBoxIcon.Error );
                frmConfig configForm = new frmConfig();
                configForm.ShowDialog();
            }

            // Backup Data
            string sPath = System.AppDomain.CurrentDomain.BaseDirectory + "BackupDataBase\\";
            string fileName = DateTime.Now.ToString("yyyyMMdd") + ".bak";
            if (!File.Exists(sPath + fileName))
            {
                if (!Directory.Exists(sPath))
                {
                    Directory.CreateDirectory(sPath);
                }
                bool iResult = clsBackupDataBase.BackupDataBase(sPath + fileName);
            }
            Application.Run(new frmMain());
            }
           
        }
    }

