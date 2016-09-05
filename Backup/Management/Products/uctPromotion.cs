using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Management.Commons.SQL;
using Management.Commons;
namespace Management.Products
{
    public partial class uctPromotion : DevExpress.XtraEditors.XtraUserControl
    {
        public uctPromotion()
        {
            InitializeComponent();
        }
        #region     VARIABLES

        QryData clsSQL;
        QryParam param;

        DataTable tbPromotion,tbProduct;

        #endregion

        #region     VOID & FUNCTION
        public void Print()
        {
            gcPromotion.ShowPrintPreview();
        }

        public bool checkPromotion(int iProduct_ID,decimal dPrice, DateTime dBeginDate)
        {
            bool iValid = true;
            try
            {
                clsSQL = new QryData(Program.config.ConnectionString);
                param = new QryParam();
                param.Add("@Product_ID", SqlDbType.Int, iProduct_ID);
                param.Add("@Price", SqlDbType.Decimal , dPrice );
                param.Add("@BeginDate", SqlDbType.DateTime, Convert.ToDateTime(dBeginDate.ToShortDateString ()));
                int iRowCount=0;
                iRowCount = Convert.ToInt32(clsSQL.ExecScalarStore("spPromo_checkPromotion", param));
                if (iRowCount>0)
                {
                    iValid =false ;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
            return iValid;
        }
        #endregion

        #region     EVENTS
        
        private void uctPromotion_Load(object sender, EventArgs e)
        {
            try
            {
                
                chkAllCom.Checked = true;
                chkCerruntDate.Checked = true;
                dateBegin.EditValue = DateTime.Now;
                dateEnd.EditValue = DateTime.Now;
                //Company
                clsSQL = new QryData(Program.config.ConnectionString);
                string sQueryCompany = "Select Company_ID, CompanyName, Address From tbl_Companies Order by CompanyName";
                cboCompany.Properties.DataSource = clsSQL.GetTableSQL(sQueryCompany);
                cboCompany.Properties.DisplayMember = "CompanyName";
                cboCompany.Properties.ValueMember = "Company_ID";
                cboCompany.ItemIndex = 0;
                //
                string sQueryProduct = "spPromo_cboProduct";
                tbProduct = new DataTable();
                tbProduct = clsSQL.GetTableStore(sQueryProduct);
                col_KMProductName_Edit.DataSource = tbProduct;
                col_KMProductName_Edit.DisplayMember = "ProductName";
                col_KMProductName_Edit.ValueMember = "Product_ID";
                
                // Add Hinh Thuc vao Combobox
                col_KMForm_Edit.Items.Clear();
               // col_KMForm_Edit.Items.Add(SettingCodeDB.TypePromotion_Discount);
               //col_KMForm_Edit.Items.Add(SettingCodeDB.TypePromotion_Product);
               //col_KMForm_Edit.Items.Add(SettingCodeDB.TypePromotion_Product_Discount);
                col_KMForm_Edit.Items.Add(SettingCodeDB.TypePromotion_No);
                col_KMForm_Edit.Items.Add(SettingCodeDB.TypePromotion_Discount);
                col_KMForm_Edit.Items.Add(SettingCodeDB.TypePromotion_Product);
                col_KMForm_Edit.Items.Add(SettingCodeDB.TypePromotion_Product_Discount);
               
                btnGetData_Click(null, null);
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "KHUYEN MAI");
            }

        }

        private void chkAllCom_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cboCompany.Enabled = !chkAllCom.Checked;
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "KHUYEN MAI");
            }
        }

        private void chkCerruntDate_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dateBegin.Enabled = !chkCerruntDate.Checked;
                dateEnd.Enabled = !chkCerruntDate.Checked;
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "KHUYEN MAI");
            }
        }

       
        private void gvPromotion_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                string sErr = "";
                bool bValid = true;
                if (gvPromotion.GetRowCellValue(e.RowHandle ,"Product_ID")==null )
                {
                    sErr = sErr + Environment.NewLine + "Vui lòng chọn Sản Phẩm.";
                    bValid = false;
                }
                else
                {
                    if (gvPromotion.GetRowCellValue(e.RowHandle, "Product_ID").ToString() == "CHỌN SẢN PHẨM" || gvPromotion.GetRowCellValue(e.RowHandle, "Product_ID").ToString() == "")
                    {
                        sErr = sErr + Environment.NewLine + "Vui lòng chọn Sản Phẩm.";
                        bValid = false;
                    }
                    else
                    {
                        if (e.RowHandle == Program.NEW_ROW && !checkPromotion(Convert.ToInt32(gvPromotion.GetRowCellValue(e.RowHandle, "Product_ID")), Convert.ToDecimal(gvPromotion.GetRowCellValue(e.RowHandle, "Price")), Convert.ToDateTime(gvPromotion.GetRowCellValue(e.RowHandle, "BeginDate"))))
                        {
                              sErr = sErr + Environment.NewLine + "Sản Phẩm này đang nằm trong một đợt khuyến mại khác." + Environment.NewLine + "Vui lòng xóa đợt khuyến mại gần nhất của Sản Phẩm này trước khi thêm đợt khuyến mại mới";
                                bValid = false;
                        }
                    }
                }

                if (gvPromotion.GetRowCellValue(e.RowHandle, "BeginDate")==null )
                {
                    sErr = sErr + Environment.NewLine + "Vui lòng chọn Ngày Bắt Đầu.";
                    bValid = false;
                }

                if (gvPromotion.GetRowCellValue(e.RowHandle, "EndDate") == null)
                {
                    sErr = sErr + Environment.NewLine + "Vui lòng chọn Ngày Kết Thúc.";
                    bValid = false;
                }

                if (Convert.ToDateTime(gvPromotion.GetRowCellValue(e.RowHandle, "EndDate"))<=Convert.ToDateTime(gvPromotion.GetRowCellValue(e.RowHandle, "BeginDate")))
                {
                    sErr = sErr + Environment.NewLine + "Ngày bắt đầu phải nhỏ hơn ngày Kết Thúc.";
                    bValid = false;
                }

                //////////if (gvPromotion.GetRowCellValue(e.RowHandle, "Percent") == null)
                //////////{
                //////////    //sErr = sErr + Environment.NewLine + "Vui lòng nhập % khuyến mại.";
                //////////    //bValid = false;
                //////////}
                //////////else
                //////////{
                //////////    if (Convert.ToInt32(gvPromotion.GetRowCellValue(e.RowHandle, "PercentDiscount"))< 0 )
                //////////    {
                //////////        sErr = sErr + Environment.NewLine + "% Khuyến Mại phải lớn hơn 0";
                //////////        bValid = false;
                //////////    }
                //////////}
                /////////////////////////////////////////////////////////////////////////////////////////////////////////
                //////////if (gvPromotion.GetRowCellValue(e.RowHandle, "Number_buy") == null)
                //////////{
                  
                //////////}
                //////////else
                //////////{
                //////////    if (Convert.ToInt32(gvPromotion.GetRowCellValue(e.RowHandle, "Number_buy")) < 0)
                //////////    {
                //////////        sErr = sErr + Environment.NewLine + "Số Lượng Mua Phải Lớn Hơn 0";
                //////////        bValid = false;
                //////////    }
                //////////}
                //////////if (gvPromotion.GetRowCellValue(e.RowHandle, "Number_Promotions") == null)
                //////////{



                //////////}
                //////////else {
                //////////    if (Convert.ToInt32(gvPromotion.GetRowCellValue(e.RowHandle, "Number_Promotions")) < 0)
                //////////    {
                //////////        sErr = sErr + Environment.NewLine + "Số Lượng Tặng Phải Lớn Hơn 0";
                //////////        bValid = false;
                //////////    }
                //////////}
                if (gvPromotion.GetRowCellValue(e.RowHandle, "Form") == SettingCodeDB.TypePromotion_Discount)
                {
                    #region Validation % khuyến mãi
                    if (gvPromotion.GetRowCellValue(e.RowHandle, "PercentDiscount") == null)
                    {
                        //sErr = sErr + Environment.NewLine + "Vui lòng nhập % khuyến mại.";
                        //bValid = false;
                    }
                    else
                    {
                        int PercentDiscount = 0;
                        if (gvPromotion.GetRowCellValue(e.RowHandle, "PercentDiscount").ToString() != "")
                        {
                            PercentDiscount = Convert.ToInt32(gvPromotion.GetRowCellValue(e.RowHandle, "PercentDiscount"));
                        }
                        if (PercentDiscount <= 0)
                        {
                            sErr = sErr + Environment.NewLine + "% Khuyến Mại phải lớn hơn 0";
                            bValid = false;
                        }
                    }
                    #endregion
                }
                else if (gvPromotion.GetRowCellValue(e.RowHandle, "Form") == SettingCodeDB.TypePromotion_Product)
                {
                    int Number_buy222 = 0;
                    if (gvPromotion.GetRowCellValue(e.RowHandle, "Number_buy").ToString() != "")
                    {
                        Number_buy222 = Convert.ToInt32(gvPromotion.GetRowCellValue(e.RowHandle, "Number_buy"));
                    }
                    int Number_Promotions222 = 0;
                    if (gvPromotion.GetRowCellValue(e.RowHandle, "Number_Promotions").ToString() != "")
                    {
                        Number_Promotions222 = Convert.ToInt32(gvPromotion.GetRowCellValue(e.RowHandle, "Number_Promotions"));
                    }

                    if (Number_buy222 < Number_Promotions222)
                    {
                        //sErr = sErr + Environment.NewLine + "Số Lượng khuyến mãi phải nhỏ hơn số lượng mua";
                        //bValid = false;
                    }
                    else
                    {
                        #region Validation số lượng mua
                        if (gvPromotion.GetRowCellValue(e.RowHandle, "Number_buy") == null)
                        {

                        }
                        else
                        {
                            int Number_buy333 = 0;
                            if (gvPromotion.GetRowCellValue(e.RowHandle, "Number_buy").ToString() != "")
                            {
                                Number_buy333 = Convert.ToInt32(gvPromotion.GetRowCellValue(e.RowHandle, "Number_buy"));
                            }

                            if (Number_buy333 <= 0)
                            {
                                sErr = sErr + Environment.NewLine + "Số Lượng Mua Phải Lớn Hơn 0";
                                bValid = false;
                            }
                        }
                        #endregion
                        #region Validation số lượng khuyến mại
                        if (gvPromotion.GetRowCellValue(e.RowHandle, "Number_Promotions") == null)
                        {



                        }
                        else
                        {
                            int Number_Promotions333 = 0;
                            if (gvPromotion.GetRowCellValue(e.RowHandle, "Number_Promotions").ToString() != "")
                            {
                                Number_Promotions333 = Convert.ToInt32(gvPromotion.GetRowCellValue(e.RowHandle, "Number_Promotions"));
                            }
                            if (Number_Promotions333 <= 0)
                            {
                                sErr = sErr + Environment.NewLine + "Số Lượng Tặng Phải Lớn Hơn 0";
                                bValid = false;
                            }
                        }
                        #endregion
                    }
                }
                else if (gvPromotion.GetRowCellValue(e.RowHandle, "Form") == SettingCodeDB.TypePromotion_Product_Discount)
                {

                    int Number_buy222 = 0;
                    if (gvPromotion.GetRowCellValue(e.RowHandle, "Number_buy").ToString() != "")
                    {
                        Number_buy222 = Convert.ToInt32(gvPromotion.GetRowCellValue(e.RowHandle, "Number_buy"));
                    }
                    int Number_Promotions222 = 0;
                    if (gvPromotion.GetRowCellValue(e.RowHandle, "Number_Promotions").ToString() != "")
                    {
                        Number_Promotions222 = Convert.ToInt32(gvPromotion.GetRowCellValue(e.RowHandle, "Number_Promotions"));
                    }


                    if (Number_buy222 < Number_Promotions222)
                    {
                        sErr = sErr + Environment.NewLine + "Số Lượng khuyến mãi phải nhỏ hơn số lượng mua";
                        bValid = false;
                    }
                    else
                    {
                        #region Validation % khuyến mãi
                        int PercentDiscount333 = 0;
                        if (gvPromotion.GetRowCellValue(e.RowHandle, "PercentDiscount").ToString() != "")
                        {
                            PercentDiscount333 = Convert.ToInt32(gvPromotion.GetRowCellValue(e.RowHandle, "PercentDiscount"));
                        }

                        if (PercentDiscount333 <= 0)
                            {
                                sErr = sErr + Environment.NewLine + "% Khuyến Mại phải lớn hơn 0";
                                bValid = false;
                            }
                        
                        #endregion
                        #region Validation số lượng mua
                        if (gvPromotion.GetRowCellValue(e.RowHandle, "Number_buy") == null)
                        {

                        }
                        else
                        {
                            int Number_buy333 = 0;
                            if (gvPromotion.GetRowCellValue(e.RowHandle, "Number_buy").ToString() != "")
                            {
                                Number_buy333 = Convert.ToInt32(gvPromotion.GetRowCellValue(e.RowHandle, "Number_buy"));
                            }

                            if (Number_buy333 <= 0)
                            {
                                sErr = sErr + Environment.NewLine + "Số Lượng Mua Phải Lớn Hơn 0";
                                bValid = false;
                            }
                        }
                        #endregion
                        #region Validation số lượng khuyến mại
                        if (gvPromotion.GetRowCellValue(e.RowHandle, "Number_Promotions") == null)
                        {



                        }
                        else
                        {
                            int Number_Promotions333 = 0;
                            if (gvPromotion.GetRowCellValue(e.RowHandle, "Number_Promotions").ToString() != "")
                            {
                                Number_Promotions333 = Convert.ToInt32(gvPromotion.GetRowCellValue(e.RowHandle, "Number_Promotions"));
                            }
                            if (Number_Promotions333 <= 0)
                            {
                                sErr = sErr + Environment.NewLine + "Số Lượng Tặng Phải Lớn Hơn 0";
                                bValid = false;
                            }
                        }
                        #endregion
                       
                    }
                }
                    
                
                /////////////////////////////////////////////////////////////////////////////////////////////////

                if (gvPromotion.GetRowCellValue(e.RowHandle, "Form") == null)
                {
                    sErr = sErr + Environment.NewLine + "Vui lòng chọn Hình Thức Khuyến Mại.";
                    bValid = false;
                }
                else
                {
                    if (gvPromotion.GetRowCellValue(e.RowHandle, "Form").ToString () == "")
                    {
                        sErr = sErr + Environment.NewLine + "Vui lòng chọn Hình Thức Khuyến Mại.";
                        bValid = false;
                    }
                }
                

                if (bValid )
                {
                    e.Valid = true;
                    if (e.RowHandle==Program.NEW_ROW )
                    {
                        string number_Promotion = Convert.ToString(gvPromotion.GetRowCellValue(e.RowHandle, "col_number_promotion"));
                        string number_buy = Convert.ToString(gvPromotion.GetRowCellValue(e.RowHandle, "col_buy"));

                        clsSQL = new QryData(Program.config.ConnectionString);
                        param = new QryParam();
                        param.Add("@BeginDate", SqlDbType.DateTime, Convert.ToDateTime(gvPromotion.GetRowCellValue(e.RowHandle, "BeginDate")));
                        param.Add("@EndDate", SqlDbType.DateTime, Convert.ToDateTime(gvPromotion.GetRowCellValue(e.RowHandle, "EndDate")));
                        param.Add("@Product_ID", SqlDbType.Int, Convert.ToInt32(gvPromotion.GetRowCellValue(e.RowHandle, "Product_ID")));
                        int PercentDiscount222 = 0;
                        if (gvPromotion.GetRowCellValue(e.RowHandle, "PercentDiscount").ToString() != "")
                        {
                            PercentDiscount222 = Convert.ToInt32(gvPromotion.GetRowCellValue(e.RowHandle, "PercentDiscount"));
                        }
                        param.Add("@PercentDiscount", SqlDbType.Int, PercentDiscount222);
                        param.Add("@Form", SqlDbType.NVarChar, gvPromotion.GetRowCellValue(e.RowHandle, "Form").ToString());
                        param.Add("@Note", SqlDbType.NVarChar, gvPromotion.GetRowCellValue(e.RowHandle, "Note").ToString());

                        int Number_buy222 = 0, Number_Promotions222 =0;
                        if (gvPromotion.GetRowCellValue(e.RowHandle, "Number_buy").ToString() != "")
                        {
                            Number_buy222 = Convert.ToInt32(gvPromotion.GetRowCellValue(e.RowHandle, "Number_buy"));
                        }
                        if (gvPromotion.GetRowCellValue(e.RowHandle, "Number_Promotions").ToString() != "")
                        {
                            Number_Promotions222 = Convert.ToInt32(gvPromotion.GetRowCellValue(e.RowHandle, "Number_Promotions"));
                        }
                        param.Add("@Number_buy", SqlDbType.Int, Number_buy222);
                        param.Add("@Number_Promotions", SqlDbType.Int, Number_Promotions222);
                        param.Add("@Price", SqlDbType.Decimal , Convert.ToDecimal (gvPromotion.GetRowCellValue(e.RowHandle, "Price")));
                        clsSQL.ExecStore("spPromo_Ins", param);
                        col_KMPrice_Edit.Items.Clear();
                    }
                    else
                    {
                        clsSQL = new QryData(Program.config.ConnectionString);
                        param = new QryParam();
                        param.Add("@BeginDate", SqlDbType.DateTime, Convert.ToDateTime(gvPromotion.GetRowCellValue(e.RowHandle, "BeginDate")));
                        param.Add("@EndDate", SqlDbType.DateTime, Convert.ToDateTime(gvPromotion.GetRowCellValue(e.RowHandle, "EndDate")));
                        param.Add("@Product_ID", SqlDbType.Int, Convert.ToInt32(gvPromotion.GetRowCellValue(e.RowHandle, "Product_ID")));
                        int PercentDiscount222 = 0;
                        if (gvPromotion.GetRowCellValue(e.RowHandle, "PercentDiscount").ToString() != "")
                        {
                            PercentDiscount222 = Convert.ToInt32(gvPromotion.GetRowCellValue(e.RowHandle, "PercentDiscount"));
                        }
                        param.Add("@PercentDiscount", SqlDbType.Int, PercentDiscount222);
                        param.Add("@Form", SqlDbType.NVarChar, gvPromotion.GetRowCellValue(e.RowHandle, "Form").ToString());
                        param.Add("@Note", SqlDbType.NVarChar, gvPromotion.GetRowCellValue(e.RowHandle, "Note").ToString());
                        param.Add("@Promotion_ID", SqlDbType.Int, Convert.ToInt32(gvPromotion.GetRowCellValue(e.RowHandle, "Promotion_ID")));

                        int Number_buy222 = 0, Number_Promotions222 = 0;
                        if (gvPromotion.GetRowCellValue(e.RowHandle, "Number_buy").ToString() != "")
                        {
                            Number_buy222 = Convert.ToInt32(gvPromotion.GetRowCellValue(e.RowHandle, "Number_buy"));
                        }
                        if (gvPromotion.GetRowCellValue(e.RowHandle, "Number_Promotions").ToString() != "")
                        {
                            Number_Promotions222 = Convert.ToInt32(gvPromotion.GetRowCellValue(e.RowHandle, "Number_Promotions"));
                        }

                        param.Add("@Number_buy", SqlDbType.Int,Number_buy222 );
                        param.Add("@Number_Promotions", SqlDbType.Int, Number_Promotions222);
                        param.Add("@Price", SqlDbType.Decimal, Convert.ToDecimal(gvPromotion.GetRowCellValue(e.RowHandle, "Price")));
                        clsSQL.ExecStore("spPromo_Edit", param);
                    }
                    btnGetData_Click(null, null);

                }
                else
                {
                    e.Valid = false;
                    Program.MessagerErr(sErr, "KHUYEN MAI");
                }
    
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "KHUYEN MAI");
            }
        }

        private void gvPromotion_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            try
            {
                e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "KHUYEN MAI");
            }
        }

        private void gvPromotion_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                
                    col_KMProductName.OptionsColumn.AllowEdit =(e.FocusedRowHandle==Program.NEW_ROW );
                    col_KMBegin .OptionsColumn.AllowEdit = (e.FocusedRowHandle == Program.NEW_ROW);
                    col_KMEndDate .OptionsColumn.AllowEdit = (e.FocusedRowHandle == Program.NEW_ROW);
                    if (e.FocusedRowHandle >= 0)
                    {
                        col_KMPrice.OptionsColumn.AllowEdit = false;
                        if (Convert.ToDateTime(gvPromotion.GetRowCellValue(e.FocusedRowHandle, "EndDate")) < DateTime.Now)
                        {
                            col_KMForm.OptionsColumn.AllowEdit = false;
                            col_KMPercent.OptionsColumn.AllowEdit = false;
                            
                        }
                        else
                        {
                            col_KMForm.OptionsColumn.AllowEdit = true;
                            col_KMPercent.OptionsColumn.AllowEdit = true;
                        }
                    }
                    else
                    {
                        col_KMForm.OptionsColumn.AllowEdit = true;
                        col_KMPercent.OptionsColumn.AllowEdit = true;
                        col_KMPrice.OptionsColumn.AllowEdit = true ;
                    }
               
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "KHUYEN MAI");
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            try
            {
                clsSQL = new QryData(Program.config.ConnectionString);
               
                tbPromotion = new DataTable();
                if (chkAllCom.Checked)
                {
                    if (chkCerruntDate.Checked )
                    {
                        tbPromotion = clsSQL.GetTableStore("spPromo_ListNew");
                    }
                    else
                    {
                        param = new QryParam();
                        param.Add("@BeginDate", SqlDbType.DateTime, Convert.ToDateTime(Convert.ToDateTime(dateBegin.EditValue).ToShortDateString()));
                        param.Add("@EndDate", SqlDbType.DateTime, Convert.ToDateTime(Convert.ToDateTime(dateEnd.EditValue).ToShortDateString()));
                        tbPromotion = clsSQL.GetTableStore("spPromo_ListAsDate", param);
                    }

                }
                else
                {
                    if (chkCerruntDate.Checked)
                    {
                        param = new QryParam();
                        param.Add("@Company_ID", SqlDbType.Int, Convert.ToInt32(cboCompany.EditValue));
                        tbPromotion = clsSQL.GetTableStore("spPromo_ListAsCompanyNew", param);
                    }
                    else
                    {
                        param = new QryParam();
                        param.Add("@Company_ID", SqlDbType.Int, Convert.ToInt32(cboCompany.EditValue));
                        param.Add("@BeginDate", SqlDbType.DateTime, Convert.ToDateTime(Convert.ToDateTime(dateBegin.EditValue).ToShortDateString()));
                        param.Add("@EndDate", SqlDbType.DateTime, Convert.ToDateTime(Convert.ToDateTime(dateEnd.EditValue).ToShortDateString()));
                        tbPromotion = clsSQL.GetTableStore("spPromo_ListAsCompanyDate", param);
                    }
                }

                gcPromotion.DataSource = tbPromotion;
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "KHUYEN MAI");
            }
        }

        private void gvPromotion_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvPromotion.SetRowCellValue(e.RowHandle, "PercentDiscount", DBNull.Value);
            gvPromotion.SetRowCellValue(e.RowHandle, "Form", SettingCodeDB.TypePromotion_Discount);
            gvPromotion.SetRowCellValue(e.RowHandle, "BeginDate", DateTime.Now);
            gvPromotion.SetRowCellValue(e.RowHandle, "EndDate", DateTime.Now);
            gvPromotion.SetRowCellValue(e.RowHandle, "Number_buy", DBNull.Value);
            gvPromotion.SetRowCellValue(e.RowHandle, "Number_Promotions", DBNull.Value);
            
            
        }

        private void gcPromotion_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && gvPromotion.State != DevExpress.XtraGrid.Views.Grid.GridState.Editing && gvPromotion.FocusedRowHandle >= 0)
                {
                    if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa??? " + Environment.NewLine + "Lưu ý: Khi bạn xóa, Các hóa đơn xuất sẽ không bị ảnh hưởng.", "KHUYEN MAI", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        clsSQL = new QryData(Program.config.ConnectionString);
                        param = new QryParam();
                        param.Add("@Promotion_ID", SqlDbType.Int, Convert.ToInt32(gvPromotion.GetRowCellValue(gvPromotion.FocusedRowHandle, "Promotion_ID")));
                        clsSQL.ExecStore("spPromo_Del", param);
                        foreach (DataRow item in tbPromotion.Select("Promotion_ID=" + gvPromotion.GetRowCellValue(gvPromotion.FocusedRowHandle, "Promotion_ID").ToString()))
                        {
                            tbPromotion.Rows.Remove(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "KHUYEN MAI");
            }
        }

        #endregion

        private void gvPromotion_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName=="Form")
                {
                    if (e.Value==SettingCodeDB.TypePromotion_Discount)
                    {
                        col_KMPercent.OptionsColumn.AllowEdit = true ;
                        buy_product.OptionsColumn.AllowEdit = false;
                        number_promotion.OptionsColumn.AllowEdit = false;

                        col_KMPercent.OptionsColumn.AllowFocus = true;
                        buy_product.OptionsColumn.AllowFocus = false;
                        number_promotion.OptionsColumn.AllowFocus = false;

                    }
                    else if (e.Value==SettingCodeDB.TypePromotion_Product)
                    {
                        buy_product.OptionsColumn.AllowEdit = true ;
                        number_promotion.OptionsColumn.AllowEdit = true;
                        col_KMPercent.OptionsColumn.AllowEdit = false;
                        buy_product.OptionsColumn.AllowFocus = true;
                        number_promotion.OptionsColumn.AllowFocus = true;
                        col_KMPercent.OptionsColumn.AllowFocus = false;
                    }
                    else
                    {
                        buy_product.OptionsColumn.AllowEdit = true;
                        number_promotion.OptionsColumn.AllowEdit = true;
                        col_KMPercent.OptionsColumn.AllowEdit = true ;
                        buy_product.OptionsColumn.AllowFocus = true;
                        number_promotion.OptionsColumn.AllowFocus = true;
                        col_KMPercent.OptionsColumn.AllowFocus = true;
                    }
                }
                if (e.Column.FieldName=="Product_ID")
                {
                    string sQryPrice = "SElect convert(Float,Price) as Price From tbl_ProductPrices Where Product_ID = @Product_ID And Quantity>0 Order by Price";
                    param = new QryParam();
                    param.Add("@Product_ID", SqlDbType.Int, e.Value);
                    DataTable tbPrice = new DataTable();
                    tbPrice = clsSQL.GetTableSQL(sQryPrice, param);
                    col_KMPrice_Edit.Items.Clear();
                    foreach (DataRow row in tbPrice.Rows)
                    {
                        col_KMPrice_Edit.Items.Add(Convert.ToInt32(row[0]).ToString());
                    }
                    gvPromotion.SetRowCellValue(e.RowHandle, "Price", col_KMPrice_Edit.Items[0]);

                }
            }
            catch (Exception ex)
            {
                
                Program.MessagerErr(ex.ToString(),"KHUYEN MAI");
            }
        }

        private void btnAddEditPromotion_Click(object sender, EventArgs e)
        {

        }
      
     
        
    }
}
