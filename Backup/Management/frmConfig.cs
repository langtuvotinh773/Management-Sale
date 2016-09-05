using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AddTab;
using System.Data.SqlClient;
using System.Xml;
using System.IO;

namespace Management
{
    public partial class frmConfig : DevExpress.XtraEditors.XtraForm
    {
        private SqlConnection sql_con;
        public frmConfig()
        {
            InitializeComponent();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {

        }
        // Kiểm tra xem với chuỗi kết nối do người dùng chọn đó có kết nối được hay không
        private void btnTestConnect_Click(object sender, EventArgs e)
        {
            try
            {

                string SeverName = txtServer.Text.Trim();
                string DataBaseName = txtDBName.Text.Trim();
                string UserName = txtUserName.Text.Trim();
                string Pass = txtPass.Text.Trim();
                string Port = txtPort.Text.Trim();
                if (!Commons.Common.IsNullOrEmpty(Port))
                {
                    SeverName = SeverName + "," + Port;
                }
                if (Commons.Common.IsNullOrEmpty(UserName) || Commons.Common.IsNullOrEmpty(Pass))
                {
                    sql_con = new SqlConnection(@"Server=" + SeverName + "; Database=" + DataBaseName + "; Trusted_Connection=true; Integrated Security=True");
                }
                else
                {
                    sql_con = new SqlConnection("Data Source=" + SeverName + ";Initial Catalog=" + DataBaseName + ";Persist Security Info=True;User ID=" + UserName + ";Password=" + Pass + ";MultipleActiveResultSets=True");
                }
                sql_con.Open();
                if (sql_con.State == ConnectionState.Open)
                {
                    XtraMessageBox.Show("Kết nối thành công! ", "CONFIGURATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //string sqlString = "Data Source=" + txtServer.Text.Trim() + ";Initial Catalog=ConsmeticsManagement;User ID=sa;Password=" + txtPass.Text.Trim();
                //SqlConnection conn = new SqlConnection(sqlString);
                //conn.Open();
                //if (conn.State == ConnectionState.Open)
                //{
                //    XtraMessageBox.Show("Kết nối thành công ", "CONFIGURATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message   , "CONFIGURATION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }
        // Tạo File Config
        private void createNode(string sServer, string sDatabase, string sUserName,string sPassWord,string sSkinName, XmlTextWriter writer)
        {
            writer.WriteStartElement("SERVER");
            writer.WriteString(sServer);
            writer.WriteEndElement();
            writer.WriteStartElement("DATABASE");
            writer.WriteString(sDatabase);
            writer.WriteEndElement();
            writer.WriteStartElement("USERNAME");
            writer.WriteString(sUserName );
            writer.WriteEndElement();
            writer.WriteStartElement("PASSWORD");
            writer.WriteString(sPassWord );
            writer.WriteEndElement();
            writer.WriteStartElement("SKINNAME");
            writer.WriteString(sSkinName);
            writer.WriteEndElement();
           
        }
        //  Tạo File Config
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                XmlTextWriter writer = new XmlTextWriter("Config.ini", System.Text.Encoding.UTF8);
                writer.WriteStartDocument(true);
               writer.Formatting = Formatting.Indented;
               writer.WriteStartElement("CONFIGURATIONS");
               createNode(txtServer.Text.Trim(), txtDBName.Text.Trim(), Encryption.Encrypt(txtUserName.Text.Trim(), "CARAVEN", true), Encryption.Encrypt(txtPass.Text.ToLower().Trim(), "JET", true), "Office 2010 Silver", writer);  
               writer.WriteEndElement();
               writer.WriteEndDocument();
               writer.Close();
               this.Close();
            }
            catch (Exception ex)
            {
                 XtraMessageBox.Show(ex.ToString()  , "CONFIGURATION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void frmConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (System.IO.File.Exists(Application.StartupPath + @"\" + "Config.ini"))
            {
                try
                {
                    string sServer, sDatabase, sUserName, sPassWord;
                    Program.config = new Config(Application.StartupPath + @"\" + "Config.ini");
                    sServer = Program.config.GetValue("SERVER");
                    sDatabase = Program.config.GetValue("DATABASE");
                    sUserName = Encryption.Decrypt(Program.config.GetValue("USERNAME"), "CARAVEN", true);
                    sPassWord = Encryption.Decrypt(Program.config.GetValue("PASSWORD"), "JET", true);
                    Program.config.ConnectionString = "Data Source=" + sServer.Trim() + ";Initial Catalog=" + sDatabase.Trim() + ";User ID=" + sUserName.Trim() + ";Password=" + sPassWord.Trim();
                    SqlConnection con = new SqlConnection(Program.config.ConnectionString);
                    con.Open();

                }
                catch 
                {
                    if (XtraMessageBox.Show("Chương trình sẽ tự động đóng vì không tìm thấy File cấu hình." + Environment.NewLine + "Bạn có chắc muốn đóng chương trình?", "CONFIGURATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Environment.Exit(0);
                    }
                    else
                    { e.Cancel = true; }
                    
                }
            }
            else
            {
                if (XtraMessageBox.Show("Chương trình sẽ tự động đóng vì không tìm thấy File cấu hình." + Environment.NewLine + "Bạn có chắc muốn đóng chương trình?", "CONFIGURATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
                else
                { e.Cancel = true; }
                
            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }
    }
}