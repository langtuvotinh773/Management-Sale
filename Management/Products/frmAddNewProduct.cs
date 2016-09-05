using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Windows;
using Management.Commons.SQL;
using Management.Commons.SQL;
namespace Management.Products
{
    public partial class frmAddNewProduct : DevExpress.XtraEditors.XtraForm
    {
        #region VARIABLES
        public event EventHandler Form_Closing;
        QryData clsSQl;
        QryParam param;

        DataTable tbCompany,  tbUnit, tbProduct;

        private int iProduct_ID, iCompany_ID, iUnit_ID, iQuantity, iDiscount, iQuantityPromotion;
        private string sProductName, sWeight;

       
        private decimal dPrice;

       
       

        #endregion

        #region SUB AND FUNCTION

       

        public decimal GetSetPrice
        {
            get { return dPrice; }
            set { dPrice = value; }
        }

        public int GetSetIQuantityPromotion
        {
            get { return iQuantityPromotion; }
            set { iQuantityPromotion = value; }
        }

        public string GetSetSWeight
        {
            get { return sWeight; }
            set { sWeight = value; }
        }

        public string GetSetSProductName
        {
            get { return sProductName; }
            set { sProductName = value; }
        }

        public int GetSetIDiscount
        {
            get { return iDiscount; }
            set { iDiscount = value; }
        }

        public int GetSetIQuantity
        {
            get { return iQuantity; }
            set { iQuantity = value; }
        }

        public int GetSetIUnit_ID
        {
            get { return iUnit_ID; }
            set { iUnit_ID = value; }
        }

        public int GetSetICompany_ID
        {
            get { return iCompany_ID; }
            set { iCompany_ID = value; }
        }

        public int GetSetProduct_ID
        {
            get { return iProduct_ID; }
            set { iProduct_ID = value; }
        }

        bool checkProStyle(string sStyle)
        {
            bool t = true;
            try
            {
                
                string sQueryProductStyle = "Select Style From tbl_Products";
                clsSQl = new QryData(Program.config.ConnectionString);
               
                DataTable dtTemp = new DataTable();
                dtTemp = clsSQl.GetTableSQL(sQueryProductStyle);
                foreach (DataRow row in dtTemp.Rows )
                {
                    if (row["Style"].ToString()==sStyle )
                    {
                        t= false;
                       
                    }
                }
               
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "SAN PHAM");
            }
            return t;
        }

        #endregion

        #region EVENTS

        public frmAddNewProduct()
        {
            InitializeComponent();
        }

        private void frmAddNewProduct_Load(object sender, EventArgs e)
        {
            try
            {
                // Gán source cho 3 cbo 
                clsSQl = new QryData(Program.config.ConnectionString);
                if (this.GetSetProduct_ID != 0)
                {
                    tbProduct = new DataTable();
                    param = new QryParam();
                    param.Add("@Product_ID", SqlDbType.Int, this.GetSetProduct_ID);
                    param.Add("@Price", SqlDbType.Decimal, this.GetSetPrice);
                    tbProduct = clsSQl.GetTableStore("spPro_List_Product_ID", param);
                    this.GetSetICompany_ID = (int)tbProduct.Rows[0]["Company_ID"];
                   
                    this.GetSetIUnit_ID = (int)tbProduct.Rows[0]["Unit_ID"];
                    this.GetSetSProductName = tbProduct.Rows[0]["ProductName"].ToString();
                    this.GetSetSWeight = tbProduct.Rows[0]["Weight"].ToString();
                    this.GetSetPrice = (decimal)tbProduct.Rows[0]["Price"];
                    this.GetSetIQuantity = (int )tbProduct.Rows[0]["Quantity"];
                    this.GetSetIDiscount = Convert.ToInt32(tbProduct.Rows[0]["Discount"]);
                    this.GetSetIQuantityPromotion  = (int )tbProduct.Rows[0]["QuantityPromotion"];
                   
                    btnClose.Enabled = false;
                }


                string sQueryCompany,  sQueryUnit;
                sQueryCompany = "Select Company_ID, CompanyName, Address From tbl_Companies Order by CompanyName";
                sQueryUnit = "SElect Unit_ID, UnitName From tbl_Units Order by UnitName";
                // Company
                tbCompany = new DataTable();
                tbCompany = clsSQl.GetTableSQL(sQueryCompany);
                cboCompany.Properties.DataSource = tbCompany;
                cboCompany.Properties.DisplayMember = "CompanyName";
                cboCompany.Properties.ValueMember = "Company_ID";
                if (this.GetSetICompany_ID != 0)
                    cboCompany.EditValue = this.GetSetICompany_ID;
               

                //Unit
                tbUnit = new DataTable();
                tbUnit = clsSQl.GetTableSQL(sQueryUnit);
                cboUnitName.Properties.DataSource = tbUnit;
                cboUnitName.Properties.DisplayMember = "UnitName";
                cboUnitName.Properties.ValueMember = "Unit_ID";
                if (this.GetSetIUnit_ID != 0) 
                cboUnitName.EditValue = this.GetSetIUnit_ID;
                // SEt cac textbox
                txtProductName.Text = this.GetSetSProductName;
                txtQuantity.Value = this.GetSetIQuantity;
                txtPrice.Value = this.GetSetPrice ;
                txtQuantityPromotion.Value  = this.GetSetIQuantityPromotion;
                txtDiscount.Value = this.GetSetIDiscount; 
                txtWeight.Text = this.GetSetSWeight;
                

            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "THEM SAN PHAM");
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string sErr = "";
                bool bValid = true;
                if (cboCompany.EditValue == null)
                {
                    sErr = sErr +  Environment.NewLine +"Vui lòng chọn Công Ty." ;
                    bValid = false;
                }

                if (cboUnitName.EditValue == null)
                {
                    sErr = sErr + Environment.NewLine + "Vui lòng chọn Đơn Vị Tính." ;
                    bValid = false;
                }

                if (txtProductName.Text.Trim() == "")
                {
                    sErr = sErr + Environment.NewLine + "Vui lòng nhập Tên Sản Phẩm." ;
                    bValid = false;
                }

                if (txtPrice.Value == 0 && txtQuantity.Value == 0 && txtQuantityPromotion.Value == 0 && txtDiscount.Value == 0)
                { 
                
                }else
                {
                    
                   
                   
                        if (txtQuantity.Value <= 0)
                        {
                            sErr = sErr + Environment.NewLine + "Vui lòng nhập số lượng phải > 0";
                            bValid = false;
                        }
                        if (txtPrice.Value <= 0)
                        {
                            sErr = sErr + Environment.NewLine + "Vui lòng nhập đơn giá . Đơn giá phải > 0";
                            bValid = false;
                        }
                        if (txtQuantityPromotion.Value < 0)
                        {
                            sErr = sErr + Environment.NewLine + "Số lượng khuyến mãi phải >= 0";
                            bValid = false;
                        }
                       
                       if (txtDiscount.Value < 0)
                        {
                            sErr = sErr + Environment.NewLine + "% chiết khấu phải lớn >= 0!";
                             bValid = false;
                        }
                        if (txtPrice.Value == 0 && txtQuantity.Value == 0)
                        {
                            if (txtDiscount.Value < 0)
                            {
                                sErr = sErr + Environment.NewLine + "Sản phẩm này đơn giá= 0 và số lưọng = 0 không thể nhập chiết khấu.";
                                bValid = false;
                            }
                        }
                   
                  
                  
                }
                //if (txtDiscount.Value == 0)
                //{
                //    sErr = sErr + Environment.NewLine + "Vui lòng nhập đơn giá . Đơn giá phải > 0";
                //    bValid = false;
                //}



                if (bValid)
                {
                    if (this.GetSetProduct_ID == 0) // neu la Them moi
                    {

                        int isCheckProduct = Convert.ToInt32( clsSQl.ExecScalarSQL("SElect dbo.func_CheckProduct ( N'" + txtProductName.Text.Trim() + "'," + cboCompany.EditValue.ToString() + "," + txtPrice.Value.ToString() + ")"));
                        if (isCheckProduct==0)// Chưa tồn tại
                        {
                            param = new QryParam();
                            param.Add("@ProductName", SqlDbType.NVarChar, txtProductName.Text.Trim());
                            param.Add("@Company_ID", SqlDbType.Int, cboCompany.EditValue);
                            param.Add("@Unit_ID", SqlDbType.Int, cboUnitName.EditValue);
                            param.Add("@Quantity", SqlDbType.Int, txtQuantity.Value);
                            param.Add("@Price", SqlDbType.Decimal, txtPrice.Value);
                            param.Add("@Discount", SqlDbType.SmallInt, txtDiscount.Value);
                            param.Add("@QuantityPromotion", SqlDbType.Int, txtQuantityPromotion.Value);
                            param.Add("@Weight", SqlDbType.VarChar, txtWeight.Text.Trim());

                            clsSQl.ExecStore("spPro_Ins", param);
                            Program.MessagerInfo("Đã thêm mới một sản phẩm.", "QUAN LY SAN PHAM");
                            foreach (Control item in this.Controls)
                            {
                                if (item is LookUpEdit)
                                {
                                    LookUpEdit cboSender;
                                    cboSender = (LookUpEdit)item;
                                    cboSender.EditValue = null;
                                }
                                if (item is TextEdit)
                                {
                                    TextEdit txtSender;
                                    txtSender = (TextEdit)item;
                                    txtSender.Text = "";
                                }
                                if (item is SpinEdit)
                                {
                                    SpinEdit spSender;
                                    spSender = (SpinEdit)item;
                                    spSender.Value = 0;
                                }

                            }  
                        }
                        else
                        {
                            Program.MessagerErr("Công ty " + cboCompany.Text + ". Đã tồn tại sản phẩm:" + txtProductName.Text + Environment.NewLine + "với đơn giá là : " + txtPrice.Value.ToString()+".Vui lòng kiểm tra lại.", "CAP NHAT SAN PHAM");
                        }
                       
                    }// Ket thuc them moi
                    else
                    {
                        int isCheckProduct = Convert.ToInt32(clsSQl.ExecScalarSQL("SElect dbo.func_CheckProduct ( N'" + txtProductName.Text.Trim() + "'," + cboCompany.EditValue.ToString() + "," + txtPrice.Value.ToString() + ")"));
                        if (isCheckProduct == 0)
                        {
                            param = new QryParam();
                            param.Add("@Product_ID", SqlDbType.Int, this.GetSetProduct_ID);
                            param.Add("@ProductName", SqlDbType.NVarChar, txtProductName.Text.Trim());
                            param.Add("@Company_ID", SqlDbType.Int, cboCompany.EditValue);
                            param.Add("@Unit_ID", SqlDbType.Int, cboUnitName.EditValue);
                            param.Add("@Quantity", SqlDbType.Int, txtQuantity.Value);
                            param.Add("@Price", SqlDbType.Decimal, txtPrice.Value);
                            param.Add("@Discount", SqlDbType.SmallInt, txtDiscount.Value);
                            param.Add("@QuantityPromotion", SqlDbType.Int, txtQuantityPromotion.Value);
                            param.Add("@Weight", SqlDbType.VarChar, txtWeight.Text.Trim());

                            clsSQl.ExecStore("spPro_Update", param);
                            Program.MessagerInfo("Sửa thông tin sản phẩm thành công.", "QUAN LY SAN PHAM");
                            this.Close();
                        }
                        else
                        {
                            Program.MessagerErr("Công ty " + cboCompany.Text + ". Đã tồn tại sản phẩm:" + txtProductName.Text + Environment.NewLine + "với đơn giá là : " + txtPrice.Value.ToString() +".Vui lòng kiểm tra lại.", "CAP NHAT SAN PHAM");
                        }
                        
                    }
                    if (Form_Closing != null)
                    {
                        Form_Closing(sender, e);
                    }
                }
                else
                {
                    Program.MessagerErr(sErr, "QUAN LY SAN PHAM");
                }


            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "QUAN LY SAN PHAM");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void frmAddNewProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
        
        }

        

       

        
    }
}