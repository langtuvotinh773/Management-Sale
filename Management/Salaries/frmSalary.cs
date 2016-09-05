using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Management.Commons.SQL;
using Management.Commons;
namespace Management
{
    public partial class frmSalary : DevExpress.XtraEditors.XtraForm
    {
        QryData clsSQL;
        QryParam param;
        QryParam clsParam;
        public event EventHandler Form_Closing;

        DataTable tbCust, tbEmp, tbOrders, tbOrderDetails, tbPayments,tbSalary;

        public frmSalary()
        {
            InitializeComponent();
            clsSQL = new QryData(Program.config.ConnectionString);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void XtraForm1_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    clsSQL = new QryData(Program.config.ConnectionString);
                    string sQueryEmp = "SElect Emp_ID, EmpName , Address From tbl_Employees where  IsDefault != 1 Order By EmpName";
                
                    tbEmp = new DataTable();
                    tbEmp = clsSQL.GetTableSQL(sQueryEmp);
                    //
                 
                    cboEmp.Properties.DataSource = tbEmp;
                    cboEmp.Properties.ValueMember = "Emp_ID";
                    cboEmp.Properties.DisplayMember = "EmpName";
                    cboEmp.ItemIndex = 0;

                    //string Id = cboEmp.EditValue.ToString();
                    //string sQuerySalary = "SElect TotalSalary From tbl_Salaries where Emp_ID =" + Common.ParseInt(Id);
                    //tbEmp = clsSQL.GetTableSQL(sQuerySalary);
                    //cboEmp.Properties.DisplayMember = "txtTotalSalary";
                    
                }
                catch (Exception ex)
                {

                    Program.MessagerErr(ex.ToString(), "HOA DON XUAT");
                }


            }
            catch (Exception ex)
            {
                Program.MessagerErr(ex.ToString(), "XUAT LUONG");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void cboEmp_EditValueChanged(object sender, EventArgs e)
        {
               QryParam clsParam;

            tbSalary = new DataTable();
            clsParam = new QryParam();
          //  int Id = Common.ParseInt(cboEmp.EditValue.ToString());

            string Id = cboEmp.EditValue.ToString();
            string sQuerySalary = "SElect (TotalSalary - ReturnMoney) as TotalSalary  From tbl_TotalSalary where Emp_ID =" + Common.ParseInt(Id);
            tbSalary = clsSQL.GetTableSQL(sQuerySalary);

            try
            {
            
              TotalSalary.Text = tbSalary.Rows[0]["TotalSalary"].ToString();

              double ConvertMoney = double.Parse(tbSalary.Rows[0]["TotalSalary"].ToString());
                ShowSalary.Text = String.Format("{0:0,0}", ConvertMoney);
            }
            catch
            {

                TotalSalary.Text = "0";
            }
            

           // cboEmp.Properties.DataSource = tbSalary;
           // cboEmp.Properties.DisplayMember = "TotalSalary";

            //TotalSalary.EditValue = tbSalary;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

           
            int iIndex;
            iIndex =(int) cboEmp.EditValue;
            string Id = cboEmp.EditValue.ToString();
            if (TotalSalary.Text == "")
            {
                return;
            }
            if (txtAmount.Text == "")
            {
                return;
            }
            
            string GetTotalSalary = TotalSalary.Text;
            string GetAmount = txtAmount.Text;
            double number1 = Commons .Common .ParseDouble (GetTotalSalary);
            double number2 = Commons.Common.ParseDouble(GetAmount);
            if (number2 > number1)
            {
                Program.MessagerErr("Lương Bạn Không Đủ", "");
            }
            else
            {
                clsSQL = new QryData(Program.config.ConnectionString);

                param = new QryParam();
                param.Add("@Emp_ID", SqlDbType.Int, Id);
                param.Add("@Amount", SqlDbType.Decimal, number2);
                param.Add("@Note", SqlDbType.NVarChar, txtNote.Text);
                clsSQL.BeginTrans();
                clsSQL.ExecStore("spExportSalary_Ins", param);
                clsSQL.CommitTrans();
                cboEmp.EditValue = 0;
                cboEmp.EditValue = iIndex;
                txtAmount.Text = "0";
            }
            if (Form_Closing != null)
            {
                Form_Closing(sender, e);
            }
            }
            catch (Exception ex)
            {
                clsSQL.RollBackTrans();
                Program.MessagerErr(ex.ToString(), "TRA LUONG");
              
            }
            


        }

       

    }
}