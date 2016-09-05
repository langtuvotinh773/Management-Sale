using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Management.Commons.SQL;
namespace Management.Products
{
    public partial class uctProducts : DevExpress.XtraEditors.XtraUserControl
    {
        #region VARIABLES
        QryData clsSQl;
        QryParam param;

        DataTable tbProducts,tbCompany;
        
        #endregion

        #region VOID AND FUNCTION

        public void Print()
        {
            gcProducts.ShowPrintPreview();
        }

        #endregion

        #region EVENTS

        public uctProducts()
        {
            InitializeComponent();
        }

        public void getDataProduct()
        {
            try
            {
                // Lấy lên công ty và tên loại sản phẩm để add vào cbo
                clsSQl = new QryData(Program.config.ConnectionString);
                tbProducts = new DataTable();
                if (chkAll.Checked )
                {
                    tbProducts = clsSQl.GetTableStore("spPro_List_NoParam");
                }
                else
                {
                    if (cboCompany.EditValue == null) return;
                    param = new QryParam();
                    param.Add("@Company_ID", SqlDbType.Int, cboCompany.EditValue);
                    tbProducts = clsSQl.GetTableStore("spPro_List_Com",param );
                }
              
                gcProducts.DataSource = tbProducts;
            }
            catch (Exception e)
            {

                Program.MessagerErr(e.ToString(), "SAN PHAM");
            }
        }



        private void uctProducts_Load(object sender, EventArgs e)
        {
            try
            {
                clsSQl = new QryData(Program.config.ConnectionString);
                string sQryCompany = "SElect Company_ID, CompanyName, Address From tbl_Companies Order by CompanyName";
                tbCompany = new DataTable();
                tbCompany = clsSQl.GetTableSQL(sQryCompany);
                cboCompany.Properties.DataSource = tbCompany;
                cboCompany.Properties.DisplayMember = "CompanyName";
                cboCompany.Properties.ValueMember = "Company_ID";
                cboCompany.ItemIndex = 0;


            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "QUAN LY SAN PHAM");
            }
        }

        private void gvProducts_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "QUAN LY SAN PHAM");
            }
        }

        private void gvProducts_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gvProducts_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
           // Program.MessagerInfo(e.FocusedRowHandle.ToString(),"");
        }

        private void btnAddNewProduct_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddNewProduct frmAddProduct = new frmAddNewProduct();
                frmAddProduct.Form_Closing += btnGetData_Click ;
                frmAddProduct.ShowDialog();


            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "QUAN LY SAN PHAM");
            }
        }

        private void cmdMenuPro_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = !(gvProducts.FocusedRowHandle >= 0);

                cmdDel.Enabled = (gvProducts.FocusedRowHandle >= 0);
                cmdEdit.Enabled = (gvProducts.FocusedRowHandle >= 0);
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "SYSTEM");
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            frmAddNewProduct frmModify = new frmAddNewProduct();
            frmModify.GetSetProduct_ID = (int)gvProducts.GetRowCellValue(gvProducts.FocusedRowHandle, "Product_ID");
            frmModify.GetSetPrice = Convert.ToDecimal(gvProducts.GetRowCellValue(gvProducts.FocusedRowHandle, "Price"));
            frmModify.Form_Closing += btnGetData_Click;
            frmModify.ShowDialog();
        }

        private void cmdDel_Click(object sender, EventArgs e)
        {
            try
            {
                int isCheckDel = Convert.ToInt32(clsSQl.ExecScalarSQL("SElect dbo.func_CheckDelProduct (" + gvProducts.GetRowCellValue(gvProducts.FocusedRowHandle, "Product_ID").ToString() +")"));
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa???","Question",MessageBoxButtons.YesNo,MessageBoxIcon.Question )==DialogResult.Yes )
                {
                    if (isCheckDel == 0)
                    {
                        param = new QryParam();
                        param.Add("@Product_ID", SqlDbType.Int, Convert.ToInt32(gvProducts.GetRowCellValue(gvProducts.FocusedRowHandle, "Product_ID")));
                        clsSQl.ExecStore("spPro_Del", param);
                        btnGetData.PerformClick();
                    }
                    else
                    {
                        Program.MessagerErr("Không thể xóa sản phẩm này", "CAP NHAT SAN PHAM");
                    }
                }
                
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "CAP NHAT SAN PHAM");
            }
        }

        private void gcProducts_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (gvProducts.FocusedRowHandle >= 0)
                {
                    if (e.KeyCode == Keys.Delete && gvProducts.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                    {
                        if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa?", "XOA SAN PHAM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string sProduct_ID = gvProducts.GetRowCellValue(gvProducts.FocusedRowHandle, "Product_ID").ToString();
                            int isCheckDel = Convert.ToInt32(clsSQl.ExecScalarSQL("SElect dbo.func_CheckDelProduct (" + sProduct_ID + ")"));
                               
                                    if (isCheckDel == 0)
                                    {
                                        param = new QryParam();
                                        param.Add("@Product_ID", SqlDbType.Int, Convert.ToInt32(gvProducts.GetRowCellValue(gvProducts.FocusedRowHandle, "Product_ID")));
                                        clsSQl.ExecStore("spPro_Del", param);
                                        btnGetData.PerformClick();
                                    }
                                    else
                                    {
                                        Program.MessagerErr("Không thể xóa sản phẩm này", "CAP NHAT SAN PHAM");
                                    }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "SYSTEM");
            }
        }

        private void gvProducts_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            try
            {
                getDataProduct();
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "SAN PHAM");
            }
        }

        #endregion

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            cboCompany.Enabled = !chkAll.Checked;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                frmImportFromExcel obj = new frmImportFromExcel();
                obj.ShowDialog();
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "QUAN LY SAN PHAM");
            }
        }

        private void gvProducts_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string sax = gvProducts.GetRowCellValue(e.RowHandle, "Quantity").ToString();
                int checkColor = (int)gvProducts.GetRowCellValue(e.RowHandle, "Quantity");
               // int checkColor = Commons.Common.ParseInt(View.GetRowCellDisplayText(e.RowHandle, View.Columns["Quantity"].ToString()));
                if (checkColor < 10)
                {
                    e.Appearance.BackColor = Color.Salmon;
                    e.Appearance.BackColor2 = Color.SeaShell;
                }
            }
            //else
            //{
            //    e.Appearance.BackColor = Color.Salmon;
            //    e.Appearance.BackColor2 = Color.SeaShell;
            //}
            
        }

       
    
    }
}
