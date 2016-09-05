using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Management.Commons.SQL;

namespace Management.Products
{
    public partial class uctPromotionAddEdit : UserControl
    {
        QryData clsSQL;
        QryParam param;
        public event EventHandler Form_Closing;
        DataTable tblPromotion;
        public uctPromotionAddEdit()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            try
            {
                clsSQL = new QryData(Program.config.ConnectionString);
                tblPromotion = new DataTable();

                tblPromotion = clsSQL.GetTableStore("spProductPromotion");
                gcPromotion.DataSource = tblPromotion;

            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "PHAN TRAM TINH LUONG");
            }
        }

        private void gvPromotion_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                decimal iNumber_buy= Commons.Common.ParseDecimal(gvPromotion.GetRowCellValue(e.RowHandle, "Number_buy"));
                decimal iNumber_Promotions= Commons.Common.ParseDecimal(gvPromotion.GetRowCellValue(e.RowHandle, "Number_Promotions"));

                if (iNumber_buy == 0 && iNumber_Promotions > 0)
                {
                    e.Valid = false;
                    Program.MessagerErr("Vui lòng nhập số lượng cần bán", "QUAN LY KM");
                }
                else if (iNumber_buy > 0 && iNumber_Promotions == 0)
                {
                    e.Valid = false;
                    Program.MessagerErr("Vui lòng nhập số lượng KM", "QUAN LY KM");
                }
                else
                {
                    clsSQL.BeginTrans();
                    param = new QryParam();
                    param.Add("@ProductID", SqlDbType.Int, Commons.Common.ParseInt(gvPromotion.GetRowCellValue(e.RowHandle, "Product_ID")));
                    param.Add("@Number_buy", SqlDbType.Int, Commons.Common.ParseInt(iNumber_buy));
                    param.Add("@Number_Promotions", SqlDbType.Int, Commons.Common.ParseInt(iNumber_Promotions));
                    param.Add("@Price", SqlDbType.Int, Commons.Common.ParseDecimal(gvPromotion.GetRowCellValue(e.RowHandle, "Price")));
                    param.Add("@PriceActual_Import", SqlDbType.Int, Commons.Common.ParseDecimal(gvPromotion.GetRowCellValue(e.RowHandle, "PriceActual_Import")));
                    param.Add("@Note", SqlDbType.NVarChar, gvPromotion.GetRowCellValue(e.RowHandle, "Note"));
                    clsSQL.ExecStore("spInsertPromotions", param);
                    clsSQL.CommitTrans();
                }

            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "QUAN LY KM");
            }
        }

        private void gvPromotion_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
    }
}
