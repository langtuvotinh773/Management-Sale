using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using AddTab;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Helpers;
using Management.Human;
using Management.Products;
using Management.Partner;
using Management.Custommer;
using Management.UnitManager;
using Management.Commons;


namespace Management
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public void UpdatebtnLogOn()
        {
            this.btnLogIn_ItemClick(null, null);
        }

        TabAdd tabMenu = new TabAdd();
        public frmMain()
        {

            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            SkinHelper.InitSkinPopupMenu(cmdSkin);
            SkinHelper.InitSkinGallery(gallSkin);
            tstName.Caption = " Made By NguyenQuoc";
            stsDesignBy.Caption = "Phần Mềm Quản Lý Mỹ Phẩm";
            //timer1.Start();


        }

        private void btnNewStaff_ItemClick(object sender, ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in tabMain.TabPages)
            {
                if (tab.Text == "Quản Lý Nhân Viên")
                {
                    tabMain.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {

            }
            else
            {// Nếu chưa có TAb này thì gọi hàm Addtab xây dựng ở trên để Add Tab con vào
                tabMenu.AddTab(tabMain, "Employee.png", "Quản Lý Nhân Viên", new uctHumanManager());
            }

        }

        private void btnPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                tabMenu.PrintTab(tabMain, tabMain.SelectedTabPageIndex);
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.ToString(), "APPLICATION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnAppPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                tabMenu.PrintTab(tabMain, tabMain.SelectedTabPageIndex);
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.ToString(), "APPLICATION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!System.IO.File.Exists(Application.StartupPath + @"\" + "Config.ini"))
                    return;
                Program.config.SaveSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName);
            }
            catch (Exception ex)
            {
                e.Cancel = true;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //stsDate.Caption =  DateTime.Now.Day.ToString() +" / "+ DateTime.Now.Month.ToString() + " / " + DateTime.Now.Year.ToString() ;
            //stsTime.Caption = DateTime.Now.ToLongTimeString();
        }

        private void btnProduct_ItemClick(object sender, ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in tabMain.TabPages)
            {
                if (tab.Text == "Quản Lý Sản Phẩm")
                {
                    tabMain.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {

            }
            else
            {// Nếu chưa có TAb này thì gọi hàm Addtab xây dựng ở trên để Add Tab con vào
                tabMenu.AddTab(tabMain, "Product.png", "Quản Lý Sản Phẩm", new uctProducts());

            }
        }

        private void btnProType_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnPtoductCreateInput_ItemClick(object sender, ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in tabMain.TabPages)
            {
                if (tab.Text == "Danh Sách Phiếu Nhập Hàng")
                {
                    tabMain.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {

            }
            else
            {// Nếu chưa có TAb này thì gọi hàm Addtab xây dựng ở trên để Add Tab con vào
                tabMenu.AddTab(tabMain, "ImportOrder.png", "Danh Sách Phiếu Nhập Hàng", new uctImportOrder());
            }
        }

        private void btnInputOrder_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                new frmCreatNewImport().ShowDialog();
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "SYSTEM");
            }
        }

        private void btnProductOut_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnPromotion_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                int t = 0;
                foreach (DevExpress.XtraTab.XtraTabPage tab in tabMain.TabPages)
                {
                    if (tab.Text == "Danh Sách Khuyến Mại")
                    {
                        tabMain.SelectedTabPage = tab;
                        t = 1;
                    }
                }
                if (t == 1)
                {

                }
                else
                {// Nếu chưa có TAb này thì gọi hàm Addtab xây dựng ở trên để Add Tab con vào
                    tabMenu.AddTab(tabMain, "Promotion.png", "Danh Sách Khuyến Mại", new uctPromotionAddEdit());
                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "SYSTEM");
            }
        }

        private void btnCreateProductOut_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                int t = 0;
                foreach (DevExpress.XtraTab.XtraTabPage tab in tabMain.TabPages)
                {
                    if (tab.Text == "Danh Sách Hóa Đơn Xuất")
                    {
                        tabMain.SelectedTabPage = tab;
                        t = 1;
                    }
                }
                if (t == 1)
                {

                }
                else
                {// Nếu chưa có TAb này thì gọi hàm Addtab xây dựng ở trên để Add Tab con vào
                    tabMenu.AddTab(tabMain, "Order.png", "Danh Sách Hóa Đơn Xuất", new uctOrders());
                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "HOA DON XUAT");
            }
        }

        private void btnOutOrder_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmNewOrders obj = new frmNewOrders();
            obj.ShowDialog();
        }

        private void btnCompany_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                int t = 0;
                foreach (DevExpress.XtraTab.XtraTabPage tab in tabMain.TabPages)
                {
                    if (tab.Text == "Danh Sách Công Ty")
                    {
                        tabMain.SelectedTabPage = tab;
                        t = 1;
                    }
                }
                if (t == 1)
                {

                }
                else
                {// Nếu chưa có TAb này thì gọi hàm Addtab xây dựng ở trên để Add Tab con vào
                    tabMenu.AddTab(tabMain, "Company.png", "Danh Sách Công Ty", new uctPartnerManager());
                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "SYSTEM");
            }
        }

        private void btnCustomer_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                int t = 0;
                foreach (DevExpress.XtraTab.XtraTabPage tab in tabMain.TabPages)
                {
                    if (tab.Text == "Danh Sách Khách Hàng")
                    {
                        tabMain.SelectedTabPage = tab;
                        t = 1;
                    }
                }
                if (t == 1)
                {

                }
                else
                {// Nếu chưa có TAb này thì gọi hàm Addtab xây dựng ở trên để Add Tab con vào
                    tabMenu.AddTab(tabMain, "Customers.png", "Danh Sách Khách Hàng", new uctCustommerManager());
                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "SYSTEM");
            }
        }

        private void btnSalariesReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                int t = 0;
                foreach (DevExpress.XtraTab.XtraTabPage tab in tabMain.TabPages)
                {
                    if (tab.Text == "Báo Cáo Xuất Lương")
                    {
                        tabMain.SelectedTabPage = tab;
                        t = 1;
                    }
                }
                if (t == 1)
                {

                }
                else
                {// Nếu chưa có TAb này thì gọi hàm Addtab xây dựng ở trên để Add Tab con vào
                    tabMenu.AddTab(tabMain, "SalariesReport.png", "Báo Cáo Xuất Lương", new uctExportSalary());
                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "SYSTEM");
            }
        }

        private void btnProductInput_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                int t = 0;
                foreach (DevExpress.XtraTab.XtraTabPage tab in tabMain.TabPages)
                {
                    if (tab.Text == "Báo Cáo Nhập Hàng")
                    {
                        tabMain.SelectedTabPage = tab;
                        t = 1;
                    }
                }
                if (t == 1)
                {

                }
                else
                {// Nếu chưa có TAb này thì gọi hàm Addtab xây dựng ở trên để Add Tab con vào
                    tabMenu.AddTab(tabMain, "Report.ico", "Báo Cáo Nhập Hàng", new uctImportReport());
                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "SYSTEM");
            }
        }

        private void btnTonKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                int t = 0;
                foreach (DevExpress.XtraTab.XtraTabPage tab in tabMain.TabPages)
                {
                    if (tab.Text == "Báo Cáo Công Nợ")
                    {
                        tabMain.SelectedTabPage = tab;
                        t = 1;
                    }
                }
                if (t == 1)
                {

                }
                else
                {// Nếu chưa có TAb này thì gọi hàm Addtab xây dựng ở trên để Add Tab con vào
                    tabMenu.AddTab(tabMain, "Liabilities.png", "Báo Cáo Công Nợ", new uctLiabilities());
                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "SYSTEM");
            }
        }

        private void btnUnit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                int t = 0;
                foreach (DevExpress.XtraTab.XtraTabPage tab in tabMain.TabPages)
                {
                    if (tab.Text == "Đơn Vị Tính")
                    {
                        tabMain.SelectedTabPage = tab;
                        t = 1;
                    }
                }
                if (t == 1)
                {

                }
                else
                {// Nếu chưa có TAb này thì gọi hàm Addtab xây dựng ở trên để Add Tab con vào
                    tabMenu.AddTab(tabMain, "Unit.png", "Đơn Vị Tính", new frmUnit());
                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "SYSTEM");
            }
        }

        private void btnNocongTy_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                int t = 0;
                foreach (DevExpress.XtraTab.XtraTabPage tab in tabMain.TabPages)
                {
                    if (tab.Text == "Nợ Công Ty")
                    {
                        tabMain.SelectedTabPage = tab;
                        t = 1;
                    }
                }
                if (t == 1)
                {

                }
                else
                {// Nếu chưa có TAb này thì gọi hàm Addtab xây dựng ở trên để Add Tab con vào
                    tabMenu.AddTab(tabMain, "ComNo.png", "Nợ Công Ty", new uctLiabilitiesCompany());
                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "SYSTEM");
            }
        }

        private void btnInventory_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmInventory obj = new frmInventory();
            obj.Show();
        }

        public void showUctReportRevenue()
        {
            try
            {
                int t = 0;
                foreach (DevExpress.XtraTab.XtraTabPage tab in tabMain.TabPages)
                {
                    if (tab.Text == "Báo Cáo Doanh Thu")
                    {
                        tabMain.SelectedTabPage = tab;
                        t = 1;
                    }
                }
                if (t != 1)
                {// Nếu chưa có TAb này thì gọi hàm Addtab xây dựng ở trên để Add Tab con vào
                    tabMenu.AddTab(tabMain, "SalariesReport.png", "Báo Cáo Doanh Thu", new uctReportRevenue());
                }


            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "SYSTEM");
            }
        }

        private void btnProductInventory_ItemClick(object sender, ItemClickEventArgs e)
        {
            //uctReportRevenue obj = new frmInventory();
            try
            {
                int iPermission = Commons.Common.getPermissionType(SettingCodeDB.USERNAME_User, SettingCodeDB.PASSWORD_User);
                if (iPermission == 2)
                {
                    showUctReportRevenue();
                }
                else
                {
                    //frmLogon obj = new frmLogon();
                    //obj.ShowDialog();
                    btnLogIn_ItemClick(null, null);
                    if (Commons.Common.getPermissionType(SettingCodeDB.USERNAME_User, SettingCodeDB.PASSWORD_User) == 2)
                    {
                        showUctReportRevenue();
                    }
                    //Program.MessagerErr("Vui lòng liên hệ Administrator", "SYSTEM");
                }

            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "SYSTEM");
            }
        }

        private void btnHumanReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                int t = 0;
                foreach (DevExpress.XtraTab.XtraTabPage tab in tabMain.TabPages)
                {
                    if (tab.Text == "Báo Cáo Doanh Thu Cho Nhân Viên")
                    {
                        tabMain.SelectedTabPage = tab;
                        t = 1;
                    }
                }
                if (t == 1)
                {

                }
                else
                {// Nếu chưa có TAb này thì gọi hàm Addtab xây dựng ở trên để Add Tab con vào
                    tabMenu.AddTab(tabMain, "SalariesReport.png", "Báo Cáo Doanh Thu Cho Nhân Viên", new uctReportRevenueEmp());
                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "SYSTEM");
            }
        }
        //public void uctViewLog()
        //{
        //    try
        //    {
        //        int t = 0;
        //        foreach (DevExpress.XtraTab.XtraTabPage tab in tabMain.TabPages)
        //        {
        //            if (tab.Text == "View Log")
        //            {
        //                tabMain.SelectedTabPage = tab;
        //                t = 1;
        //            }
        //        }
        //        if (t == 1)
        //        {

        //        }
        //        else
        //        {// Nếu chưa có TAb này thì gọi hàm Addtab xây dựng ở trên để Add Tab con vào
        //            tabMenu.AddTab(tabMain, null, "View Log", new uctViewLog());
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Program.MessagerErr(ex.ToString(), "SYSTEM");
        //    }
        //}
        public void btnViewLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                int t = 0;
                foreach (DevExpress.XtraTab.XtraTabPage tab in tabMain.TabPages)
                {
                    if (tab.Text == "View Log")
                    {
                        tabMain.SelectedTabPage = tab;
                        t = 1;
                    }
                }
                if (t == 1)
                {

                }
                else
                {// Nếu chưa có TAb này thì gọi hàm Addtab xây dựng ở trên để Add Tab con vào
                    int iPermission = Commons.Common.getPermissionType(SettingCodeDB.USERNAME_Admin, SettingCodeDB.PASSWORD_Admin);
                    if (iPermission == 1)
                    {
                        frmLogon obj = new frmLogon();
                        obj.ShowDialog();
                        if (Commons.Common.getPermissionType(SettingCodeDB.USERNAME_Admin, SettingCodeDB.PASSWORD_Admin) == 2)
                        { 
                        tabMenu.AddTab(tabMain, null, "View Log", new uctViewLog());
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {

                Program.MessagerErr(ex.ToString(), "SYSTEM");
            }
        }

        private void ribbon_Click(object sender, EventArgs e)
        {
            string strAdmin = ribbon.SelectedPage.Text.ToLower().Trim();
            if (strAdmin == "administrator")
            {
                //int iPermission = Commons.Common.getPermissionType(SettingCodeDB.USERNAME_Admin, SettingCodeDB.PASSWORD_Admin);
                //if (iPermission == 1)
                //{
                //    frmLogon obj = new frmLogon();
                //    obj.ShowDialog();
                //}
            }
        }

        private void btnLogIn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (btnLogIn.Caption == "Đăng Xuất")
            {
                Common.updatePermissionType(SettingCodeDB.USERNAME_Admin, SettingCodeDB.PASSWORD_Admin, 1);
                Common.updatePermissionType(SettingCodeDB.USERNAME_User, SettingCodeDB.PASSWORD_User, 1);
                btnLogIn.Caption = "Đăng Nhập";
                Commons.Common.iPermission = 1;
            }
            else
            {
                if (Commons.Common.iPermission > 1)
                {
                    btnLogIn.Caption = "Đăng Xuất";
                }
                else
                {
                    btnLogIn.Caption = "Đăng Nhập";
                    frmLogon obj = new frmLogon();
                    obj.updateData = new frmLogon.iPermission(UpdatebtnLogOn);
                    obj.ShowDialog();
                }
            }
        }
    }
}