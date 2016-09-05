using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.OleDb;
using Management.Commons.SQL;
namespace Management.Customers
{
    public partial class frmImportCustomers : DevExpress.XtraEditors.XtraForm
    {
        QryData clsSQL;
        QryParam param;
        DataTable tbImport;
        bool ischeck = true;
        string CustomerName = "";
        int Condition = 0;
        public frmImportCustomers()
        {
            InitializeComponent();
            clsSQL = new QryData(Program.config.ConnectionString);
        }

        public DataTable LoadImportFile(string strFileName, string strQuery)
        {
            DataTable tbReturn = new DataTable();

            OleDbConnection excelConnection = default(OleDbConnection);

            OleDbDataAdapter excelDa = default(OleDbDataAdapter);
            try
            {
                excelConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFileName + "; Extended Properties=\"Excel 8.0; HDR=Yes; IMEX=1\"");
                excelDa = new OleDbDataAdapter(strQuery, excelConnection);
                excelConnection.Open();
                excelDa.Fill(tbReturn);
                excelConnection.Close();
            }
            catch (OleDbException A)
            {
                if (A.ErrorCode == -2147217904)
                {
                    throw new Exception("Column Name invalid." + Environment.NewLine + A.Message);
                }
                else if (A.ErrorCode == -2147467259)
                {
                    throw new Exception("Sheet Name invalid.(Sheet name is \"IMPORT\")." + Environment.NewLine + A.Message);
                }
                else
                {
                    throw new Exception(A.ErrorCode.ToString() + ":" + A.ToString());
                }

            }
            catch (NullReferenceException exNull)
            {
                throw new Exception("Load File Failed." + Environment.NewLine + exNull.Message);

            }
            catch (Exception ex)
            {
                throw new Exception("Load File Failed." + Environment.NewLine + ex.Message);
            }
            return tbReturn;
        }

        public void CheckDataImport(DataTable tableImport)
        {
            try
            {
                foreach (DataRow row in tableImport.Rows )
                {
                
                    for (int i = 0; i < tableImport.Columns.Count; i++)
                    {
                        if (row[i] == DBNull.Value)
                        {
                            ischeck = false;
                        }
                        else if (row[i].ToString() == "")
                        {
                            ischeck = false;
                        }
                        if (i == 0)// kiem tra chuỗi
                        {
                            int Check_CustomerName = row[i].ToString().Trim().Length;

                            string qryCom = "SElect Count(*) From tbl_Customers Where Lower(LTRIM(RTRIM(dbo.fLocDauTiengViet(CustName)))) = @CustName and Lower(LTRIM(RTRIM(dbo.fLocDauTiengViet(Address)))) = @Address";
                            param = new QryParam();
                            param.Add("@CustName", SqlDbType.NVarChar, Commons.Common.locDau(row[i].ToString().Trim()));
                            param.Add("@Address", SqlDbType.NVarChar, Commons.Common.locDau(row[2].ToString().Trim()));
                            int iCount_CheckDatabase = Convert.ToInt32(clsSQL.ExecScalarSQL(qryCom, param));
                            if (iCount_CheckDatabase == 1)
                            {
                                Condition = 2;
                                CustomerName = row[i].ToString().Trim();
                                ischeck = false;
                            }
                            if (Check_CustomerName > 100)
                            {
                                ischeck = false;
                            }
                        }
                        if (i == 1)// kiem tra chuỗi
                        {
                            int Check_Phone = 0;
                            try
                            {
                                Check_Phone = Convert.ToInt32(row[i].ToString().Trim());
                                Check_Phone = row[i].ToString().Trim().Length;
                            }
                            catch
                            {
                                ischeck = false;
                            }
                            if (Check_Phone > 20)
                            {
                                ischeck = false;
                            }
                        }
                        if (i == 2)// kiem tra chuỗi
                        {
                            int Check_CustomerName = row[i].ToString().Trim().Length;
                            if (Check_CustomerName > 200)
                            {
                                ischeck = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception (ex.ToString());
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog frmFile = new OpenFileDialog();
            //Dim tbTemp As DataTable
            this.Cursor = Cursors.WaitCursor;
            try
            {
                
                //frmFile.InitialDirectory = "C:\"
                frmFile.Filter = "Excell file|*.xls|All file|*.*";
                if (frmFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    tbImport = new DataTable();
                    tbImport = LoadImportFile(frmFile.FileName, "SElect * From [IMPORT$]");
                    gcMain.DataSource = tbImport;
                    
                    // Duyet qua tung dong , cho nao null thi gan =""
                    foreach (DataRow  row in tbImport.Rows )
                    {
                        foreach (DataColumn  colum in tbImport.Columns )
                        {
                            if (row[colum]==null )
                            {
                                row[colum] = "";
                            }
                        }
                    }
                    tbImport.AcceptChanges();
                    CheckDataImport(tbImport);
                    if (!ischeck )
                    {
                        if (Condition == 2)
                        {

                            Program.MessagerErr(" Khách hàng " + CustomerName + " đã tồn tại !", "IMPORT");
                        }
                        else
                        {
                            Program.MessagerErr("Vui lòng điều chỉnh dữ liệu trong các ô có màu đỏ. Sau đó tiến hành Import lại", "IMPORT");
                        }
                    }
                    else
                    {
                        clsSQL.BeginTrans();
                        foreach (DataRow  row in tbImport.Rows )
                        {

                            param = new QryParam();
                            param.Add("@CustName", SqlDbType.NVarChar, row[0].ToString());
                            param.Add("@Address", SqlDbType.NVarChar, row[2].ToString().Trim());
                            param.Add("@Phone", SqlDbType.VarChar, row[2].ToString().Trim());
                            clsSQL.ExecStore("spCust_Ins", param);
                        }
                        clsSQL.CommitTrans();
                        Program.MessagerInfo ("Import Thành Công!!!", "IMPORT");
                    }
                    
                }

            }
            catch (System.Data.OleDb.OleDbException A)
            {

                if (A.ErrorCode == -2147217904)
                {
                    XtraMessageBox.Show("Column Name invalid." + Environment.NewLine  + A.Message, "IMPORT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (A.ErrorCode == -2147467259)
                {
                    XtraMessageBox.Show("Sheet Name invalid.(Sheet name is \"IMPORT\")" + Environment.NewLine + A.ToString(), "IMPORT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    XtraMessageBox.Show(A.ErrorCode.ToString() + ":" + A.Message, "IMPORT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (NullReferenceException exNull)
            {

                XtraMessageBox.Show("Load Purchase Note Failed." + Environment.NewLine + exNull.Message, "IMPORT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                clsSQL.RollBackTrans();
                XtraMessageBox.Show(Environment.NewLine + ex.Message, "IMPORT", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void gvMain_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            //if (gcMain.DataSource == null )
            //{
            //    return;
            //}
            //else
            //{
            //    if (gvMain.GetRowCellValue(e.RowHandle)
            //    {
                    
            //    }
            //}
        }

        private void gvMain_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
             if (gcMain.DataSource == null )
            {
                return;
            }
            else
            {
                if (e.RowHandle >=0)
                {
                    if (gvMain.GetRowCellValue(e.RowHandle, e.Column) == null)
                    {
                        e.Appearance.BorderColor = Color.Red;
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.BackColor2 = Color.Red;
                        ischeck = false;

                    }
                    else if (gvMain.GetRowCellValue(e.RowHandle, e.Column).ToString() == "")
                    {
                        e.Appearance.BorderColor = Color.Red;
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.BackColor2 = Color.Red;
                        ischeck = false;
                    }
                    else 
                    {
                        if (e.Column.ColumnHandle == 0)
                        {
                           string CustomerName = Convert.ToString( gvMain.GetRowCellValue(e.RowHandle, e.Column));
                           int Check_CustomerName = CustomerName.Trim().Length;

                           if (Check_CustomerName > 100)
                           {
                               e.Appearance.BorderColor = Color.Red;
                               e.Appearance.BackColor = Color.Red;
                               e.Appearance.BackColor2 = Color.Red;
                               ischeck = false;
                           }
                        }

                       
                       
                        
                             if (e.Column.ColumnHandle == 1)
                        {
                            int Check_Phone = 0;
                            string CustomerPhone = Convert.ToString(gvMain.GetRowCellValue(e.RowHandle, e.Column));
                            try
                            {
                                Check_Phone = Convert.ToInt32(CustomerPhone.Trim());
                                Check_Phone = CustomerPhone.Trim().Length;
                            }
                            catch
                            {
                                ischeck = false;
                                e.Appearance.BorderColor = Color.Red;
                                e.Appearance.BackColor = Color.Red;
                                e.Appearance.BackColor2 = Color.Red;
                            }
                            if (Check_Phone > 20)
                            {
                                ischeck = false;
                            }
                        }
                             if (e.Column.ColumnHandle == 2)
                             {
                                 string CustomerAdd = Convert.ToString(gvMain.GetRowCellValue(e.RowHandle, e.Column));
                                 int Check_CustomerName = CustomerAdd.Trim().Length;
                                 if (Check_CustomerName > 200)
                                 {
                                     ischeck = false;
                                 }
                             }
                      
                    }
                }
                
            }
        }

        private void gvMain_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
           // If e.RowHandle >= 0 Then
          //  e.Info.DisplayText = (e.RowHandle + 1).ToString
       // End If
            if (e.RowHandle>=0   )
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}