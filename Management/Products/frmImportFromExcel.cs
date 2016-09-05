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
using Management.Commons;
namespace Management.Products
{
    public partial class frmImportFromExcel : DevExpress.XtraEditors.XtraForm
    {
        QryData clsSQL;
        QryParam param;
        DataTable tbImport;
        bool ischeck = true;
        public frmImportFromExcel()
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
                foreach (DataRow row in tableImport.Rows)
                {
                    // có bik anh đnag làm gì ko hả ku
                    // a đang cốt:))
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
                        else
                        {
                            if (i == 0 || i == 1 || i == 2)
                            {

                                if (i == 0)// kiem tra xem co ma cong ty nay ko
                                {
                                    string qryCom = "SElect Count(*) From tbl_Companies Where Company_ID = @Company_ID";
                                    param = new QryParam();
                                    param.Add("@Company_ID", SqlDbType.Int, Common.ParseInt(row[i].ToString().Trim()));
                                    int iCountCom = Common.ParseInt(clsSQL.ExecScalarSQL(qryCom, param));
                                    if (iCountCom <= 0)
                                    { ischeck = false; }
                                }
                                // Validation Product Name
                                if (i == 1)
                                {
                                    string strCheckExistProductName = "SElect Count(*) From tbl_Products Where Lower(LTRIM(RTRIM(dbo.fLocDauTiengViet(ProductName)))) = '" + Commons.Common.locDau(row[i].ToString().Trim()) + "'";
                                    int iCountProductName = Common.ParseInt(clsSQL.ExecScalarSQL(strCheckExistProductName));
                                    if (iCountProductName > 0)
                                    { ischeck = false; }
                                }
                                if (i == 2)
                                {
                                    string qryUnit = "SElect Count(*) From tbl_Units Where Unit_ID = @Unit_ID";
                                    param = new QryParam();
                                    param.Add("@Unit_ID", SqlDbType.Int, Common.ParseInt(row[i].ToString().Trim()));
                                    int iCountUnit = Common.ParseInt(clsSQL.ExecScalarSQL(qryUnit, param));
                                    if (iCountUnit <= 0)
                                    { ischeck = false; }
                                }


                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
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
                    foreach (DataRow row in tbImport.Rows)
                    {
                        foreach (DataColumn colum in tbImport.Columns)
                        {
                            if (row[colum] == null)
                            {
                                row[colum] = "";
                            }
                        }
                    }
                    tbImport.AcceptChanges();
                    CheckDataImport(tbImport);
                    if (!ischeck)
                    {
                        Program.MessagerErr("Vui lòng điều chỉnh dữ liệu trong các ô có màu đỏ. Sau đó tiến hành Import lại", "IMPORT");
                    }
                    else
                    {
                        clsSQL.BeginTrans();
                        foreach (DataRow row in tbImport.Rows)
                        {

                            param = new QryParam();
                            param.Add("@ProductName", SqlDbType.NVarChar, row[1].ToString());
                            param.Add("@Company_ID", SqlDbType.Int, Common.ParseInt(row[0].ToString().Trim()));
                            param.Add("@Unit_ID", SqlDbType.Int, Common.ParseInt(row[2].ToString().Trim()));
                            param.Add("@Quantity", SqlDbType.Int, Common.ParseInt(0));
                            param.Add("@QuantityPromotion", SqlDbType.Int, Common.ParseInt(0));
                            param.Add("@Price", SqlDbType.Decimal, 0);
                            param.Add("@Discount", SqlDbType.Int, 0);
                            param.Add("@Weight", SqlDbType.NVarChar, row[3].ToString());
                            clsSQL.ExecStore("spPro_Ins", param);
                        }
                        clsSQL.CommitTrans();
                        Program.MessagerInfo("Import Thành Công!!!", "IMPORT");
                    }

                }

            }
            catch (System.Data.OleDb.OleDbException A)
            {

                if (A.ErrorCode == -2147217904)
                {
                    XtraMessageBox.Show("Column Name invalid." + Environment.NewLine + A.Message, "IMPORT", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (gcMain.DataSource == null)
            {
                return;
            }
            else
            {
                if (!ischeck)
                {
                    if (e.RowHandle >= 0)
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
                            if (e.Column.ColumnHandle == 0 || e.Column.ColumnHandle == 1 || e.Column.ColumnHandle == 2)
                            {
                                //int n = 0;
                                //if (!int.TryParse(gvMain.GetRowCellValue(e.RowHandle, e.Column).ToString(), out n))
                                //{
                                //    e.Appearance.BorderColor = Color.Red;
                                //    e.Appearance.BackColor = Color.Red;
                                //    e.Appearance.BackColor2 = Color.Red;
                                //    ischeck = false;
                                //}
                                //else
                                //{
                                if (e.Column.ColumnHandle == 0)
                                {
                                    string qryCom = "SElect Count(*) From tbl_Companies Where Company_ID = @Company_ID";
                                    param = new QryParam();
                                    param.Add("@Company_ID", SqlDbType.Int, Common.ParseInt(gvMain.GetRowCellValue(e.RowHandle, e.Column)));
                                    int iCountCom = Common.ParseInt(clsSQL.ExecScalarSQL(qryCom, param));
                                    if (iCountCom <= 0)
                                    {
                                        e.Appearance.BorderColor = Color.Red;
                                        e.Appearance.BackColor = Color.Red;
                                        e.Appearance.BackColor2 = Color.Red;
                                        ischeck = false;
                                    }
                                }
                                if (e.Column.ColumnHandle == 1)
                                {
                                    string strCheckExistProductName = "SElect Count(*) From tbl_Products Where Lower(LTRIM(RTRIM(dbo.fLocDauTiengViet(ProductName)))) = '" + Commons.Common.locDau(Commons.Common.ParseString(gvMain.GetRowCellValue(e.RowHandle, e.Column)).Trim()) + "'";
                                    int iCountProductName = Common.ParseInt(clsSQL.ExecScalarSQL(strCheckExistProductName));
                                    if (iCountProductName > 0)
                                    { ischeck = false; }
                                    if (iCountProductName > 0)
                                    {
                                        e.Appearance.BorderColor = Color.Red;
                                        e.Appearance.BackColor = Color.Red;
                                        e.Appearance.BackColor2 = Color.Red;
                                        ischeck = false;
                                    }
                                }
                                if (e.Column.ColumnHandle == 2)
                                {
                                    string qryUnit = "SElect Count(*) From tbl_Units Where Unit_ID = @Unit_ID";
                                    param = new QryParam();
                                    param.Add("@Unit_ID", SqlDbType.Int, Common.ParseInt(gvMain.GetRowCellValue(e.RowHandle, e.Column)));
                                    int iCountUnit = Common.ParseInt(clsSQL.ExecScalarSQL(qryUnit, param));
                                    if (iCountUnit <= 0)
                                    {
                                        e.Appearance.BorderColor = Color.Red;
                                        e.Appearance.BackColor = Color.Red;
                                        e.Appearance.BackColor2 = Color.Red;
                                        ischeck = false;
                                    }
                                }



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
            if (e.RowHandle >= 0)
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