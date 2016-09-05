namespace Management.Products
{
    partial class uctImportReport
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uctImportReport));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnGetData = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dateEnd = new DevExpress.XtraEditors.DateEdit();
            this.dateBegin = new DevExpress.XtraEditors.DateEdit();
            this.pivImportReport = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.piv_IOCompanyName = new DevExpress.XtraPivotGrid.PivotGridField();
            this.piv_IOOrderCompany_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            this.piv_IODate = new DevExpress.XtraPivotGrid.PivotGridField();
            this.piv_IOProductName = new DevExpress.XtraPivotGrid.PivotGridField();
            this.piv_IOQuantity = new DevExpress.XtraPivotGrid.PivotGridField();
            this.piv_IOQuantityPromotion = new DevExpress.XtraPivotGrid.PivotGridField();
            this.piv_Price = new DevExpress.XtraPivotGrid.PivotGridField();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabImport = new DevExpress.XtraTab.XtraTabPage();
            this.tabExport = new DevExpress.XtraTab.XtraTabPage();
            this.pivExport = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pivEx_Date = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivEx_CustName = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivEx_EmpName = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivEx_ProductName = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivEx_Quantity = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivEx_QtyPromotion = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivEx_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivEx_companyName = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivOdd_Price = new DevExpress.XtraPivotGrid.PivotGridField();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivImportReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tabImport.SuspendLayout();
            this.tabExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pivExport)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnGetData);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.dateEnd);
            this.panelControl1.Controls.Add(this.dateBegin);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(678, 47);
            this.panelControl1.TabIndex = 0;
            // 
            // btnGetData
            // 
            this.btnGetData.Image = ((System.Drawing.Image)(resources.GetObject("btnGetData.Image")));
            this.btnGetData.Location = new System.Drawing.Point(368, 11);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(98, 26);
            this.btnGetData.TabIndex = 4;
            this.btnGetData.Text = "Lấy Dữ Liệu";
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(174, 18);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Đến Ngày";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(41, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Từ Ngày";
            // 
            // dateEnd
            // 
            this.dateEnd.EditValue = null;
            this.dateEnd.Location = new System.Drawing.Point(228, 14);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEnd.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEnd.Size = new System.Drawing.Size(100, 20);
            this.dateEnd.TabIndex = 1;
            // 
            // dateBegin
            // 
            this.dateBegin.EditValue = null;
            this.dateBegin.Location = new System.Drawing.Point(53, 14);
            this.dateBegin.Name = "dateBegin";
            this.dateBegin.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dateBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBegin.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateBegin.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateBegin.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateBegin.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateBegin.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateBegin.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateBegin.Size = new System.Drawing.Size(100, 20);
            this.dateBegin.TabIndex = 0;
            // 
            // pivImportReport
            // 
            this.pivImportReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivImportReport.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.piv_IOCompanyName,
            this.piv_IOOrderCompany_ID,
            this.piv_IODate,
            this.piv_IOProductName,
            this.piv_IOQuantity,
            this.piv_IOQuantityPromotion,
            this.piv_Price});
            this.pivImportReport.Location = new System.Drawing.Point(0, 0);
            this.pivImportReport.Name = "pivImportReport";
            this.pivImportReport.OptionsView.ShowRowGrandTotals = false;
            this.pivImportReport.OptionsView.ShowRowTotals = false;
            this.pivImportReport.Size = new System.Drawing.Size(672, 269);
            this.pivImportReport.TabIndex = 1;
            // 
            // piv_IOCompanyName
            // 
            this.piv_IOCompanyName.AllowedAreas = ((DevExpress.XtraPivotGrid.PivotGridAllowedAreas)(((DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea | DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea)
                        | DevExpress.XtraPivotGrid.PivotGridAllowedAreas.FilterArea)));
            this.piv_IOCompanyName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.piv_IOCompanyName.AreaIndex = 0;
            this.piv_IOCompanyName.Caption = "Công Ty";
            this.piv_IOCompanyName.FieldName = "CompanyName";
            this.piv_IOCompanyName.Name = "piv_IOCompanyName";
            this.piv_IOCompanyName.Width = 99;
            // 
            // piv_IOOrderCompany_ID
            // 
            this.piv_IOOrderCompany_ID.AllowedAreas = ((DevExpress.XtraPivotGrid.PivotGridAllowedAreas)(((DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea | DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea)
                        | DevExpress.XtraPivotGrid.PivotGridAllowedAreas.FilterArea)));
            this.piv_IOOrderCompany_ID.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.piv_IOOrderCompany_ID.AreaIndex = 1;
            this.piv_IOOrderCompany_ID.Caption = "Mã Hóa Đơn Nhập";
            this.piv_IOOrderCompany_ID.FieldName = "OrderCompany_ID";
            this.piv_IOOrderCompany_ID.Name = "piv_IOOrderCompany_ID";
            this.piv_IOOrderCompany_ID.Width = 130;
            // 
            // piv_IODate
            // 
            this.piv_IODate.AllowedAreas = ((DevExpress.XtraPivotGrid.PivotGridAllowedAreas)(((DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea | DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea)
                        | DevExpress.XtraPivotGrid.PivotGridAllowedAreas.FilterArea)));
            this.piv_IODate.AreaIndex = 0;
            this.piv_IODate.Caption = "Ngày Hóa Đơn";
            this.piv_IODate.CellFormat.FormatString = "dd-MM-yyyy";
            this.piv_IODate.CellFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.piv_IODate.FieldName = "ImportOrderDate";
            this.piv_IODate.Name = "piv_IODate";
            // 
            // piv_IOProductName
            // 
            this.piv_IOProductName.AllowedAreas = ((DevExpress.XtraPivotGrid.PivotGridAllowedAreas)(((DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea | DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea)
                        | DevExpress.XtraPivotGrid.PivotGridAllowedAreas.FilterArea)));
            this.piv_IOProductName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.piv_IOProductName.AreaIndex = 2;
            this.piv_IOProductName.Caption = "Tên Sản Phẩm";
            this.piv_IOProductName.FieldName = "ProductName";
            this.piv_IOProductName.Name = "piv_IOProductName";
            // 
            // piv_IOQuantity
            // 
            this.piv_IOQuantity.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.DataArea;
            this.piv_IOQuantity.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.piv_IOQuantity.AreaIndex = 0;
            this.piv_IOQuantity.Caption = "Số Lượng Nhập";
            this.piv_IOQuantity.CellFormat.FormatString = "{0:n0}";
            this.piv_IOQuantity.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.piv_IOQuantity.FieldName = "Quantity";
            this.piv_IOQuantity.GrandTotalCellFormat.FormatString = "{0:n0}";
            this.piv_IOQuantity.GrandTotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.piv_IOQuantity.Name = "piv_IOQuantity";
            this.piv_IOQuantity.TotalCellFormat.FormatString = "{0:n0}";
            this.piv_IOQuantity.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.piv_IOQuantity.TotalValueFormat.FormatString = "{0:n0}";
            this.piv_IOQuantity.TotalValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.piv_IOQuantity.ValueFormat.FormatString = "{0:n0}";
            this.piv_IOQuantity.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            // 
            // piv_IOQuantityPromotion
            // 
            this.piv_IOQuantityPromotion.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.DataArea;
            this.piv_IOQuantityPromotion.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.piv_IOQuantityPromotion.AreaIndex = 1;
            this.piv_IOQuantityPromotion.Caption = "Số Lượng Khuyến Mại";
            this.piv_IOQuantityPromotion.CellFormat.FormatString = "{0:n0}";
            this.piv_IOQuantityPromotion.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.piv_IOQuantityPromotion.FieldName = "QuantityPromotion";
            this.piv_IOQuantityPromotion.Name = "piv_IOQuantityPromotion";
            this.piv_IOQuantityPromotion.TotalCellFormat.FormatString = "{0:n0}";
            this.piv_IOQuantityPromotion.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.piv_IOQuantityPromotion.ValueFormat.FormatString = "{0:n0}";
            this.piv_IOQuantityPromotion.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.piv_IOQuantityPromotion.Width = 129;
            // 
            // piv_Price
            // 
            this.piv_Price.AllowedAreas = ((DevExpress.XtraPivotGrid.PivotGridAllowedAreas)(((DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea | DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea)
                        | DevExpress.XtraPivotGrid.PivotGridAllowedAreas.FilterArea)));
            this.piv_Price.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.piv_Price.AreaIndex = 3;
            this.piv_Price.Caption = "Giá";
            this.piv_Price.CellFormat.FormatString = "{0:c0}";
            this.piv_Price.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.piv_Price.FieldName = "Price";
            this.piv_Price.Name = "piv_Price";
            this.piv_Price.ValueFormat.FormatString = "{0:c0}";
            this.piv_Price.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 47);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tabImport;
            this.xtraTabControl1.Size = new System.Drawing.Size(678, 295);
            this.xtraTabControl1.TabIndex = 2;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabImport,
            this.tabExport});
            // 
            // tabImport
            // 
            this.tabImport.Controls.Add(this.pivImportReport);
            this.tabImport.Name = "tabImport";
            this.tabImport.Size = new System.Drawing.Size(672, 269);
            this.tabImport.Text = "BÁO CÁO NHẬP HÀNG";
            // 
            // tabExport
            // 
            this.tabExport.Controls.Add(this.pivExport);
            this.tabExport.Name = "tabExport";
            this.tabExport.Size = new System.Drawing.Size(672, 269);
            this.tabExport.Text = "BÁO CÁO XUẤT HÀNG";
            // 
            // pivExport
            // 
            this.pivExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivExport.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.pivEx_Date,
            this.pivEx_CustName,
            this.pivEx_EmpName,
            this.pivEx_ProductName,
            this.pivEx_Quantity,
            this.pivEx_QtyPromotion,
            this.pivEx_ID,
            this.pivEx_companyName,
            this.pivOdd_Price});
            this.pivExport.Location = new System.Drawing.Point(0, 0);
            this.pivExport.Name = "pivExport";
            this.pivExport.OptionsView.ShowRowGrandTotals = false;
            this.pivExport.OptionsView.ShowRowTotals = false;
            this.pivExport.Size = new System.Drawing.Size(672, 269);
            this.pivExport.TabIndex = 0;
            // 
            // pivEx_Date
            // 
            this.pivEx_Date.AllowedAreas = ((DevExpress.XtraPivotGrid.PivotGridAllowedAreas)(((DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea | DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea)
                        | DevExpress.XtraPivotGrid.PivotGridAllowedAreas.FilterArea)));
            this.pivEx_Date.AreaIndex = 0;
            this.pivEx_Date.Caption = "Ngày Hóa Đơn Xuất";
            this.pivEx_Date.FieldName = "OrderDate";
            this.pivEx_Date.Name = "pivEx_Date";
            // 
            // pivEx_CustName
            // 
            this.pivEx_CustName.AllowedAreas = ((DevExpress.XtraPivotGrid.PivotGridAllowedAreas)(((DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea | DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea)
                        | DevExpress.XtraPivotGrid.PivotGridAllowedAreas.FilterArea)));
            this.pivEx_CustName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivEx_CustName.AreaIndex = 0;
            this.pivEx_CustName.Caption = "Khách Hàng";
            this.pivEx_CustName.FieldName = "CustName";
            this.pivEx_CustName.Name = "pivEx_CustName";
            // 
            // pivEx_EmpName
            // 
            this.pivEx_EmpName.AllowedAreas = ((DevExpress.XtraPivotGrid.PivotGridAllowedAreas)(((DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea | DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea)
                        | DevExpress.XtraPivotGrid.PivotGridAllowedAreas.FilterArea)));
            this.pivEx_EmpName.AreaIndex = 1;
            this.pivEx_EmpName.Caption = "Nhân Viên";
            this.pivEx_EmpName.FieldName = "EmpName";
            this.pivEx_EmpName.Name = "pivEx_EmpName";
            // 
            // pivEx_ProductName
            // 
            this.pivEx_ProductName.AllowedAreas = ((DevExpress.XtraPivotGrid.PivotGridAllowedAreas)(((DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea | DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea)
                        | DevExpress.XtraPivotGrid.PivotGridAllowedAreas.FilterArea)));
            this.pivEx_ProductName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivEx_ProductName.AreaIndex = 2;
            this.pivEx_ProductName.Caption = "Sản Phẩm";
            this.pivEx_ProductName.FieldName = "ProductName";
            this.pivEx_ProductName.Name = "pivEx_ProductName";
            // 
            // pivEx_Quantity
            // 
            this.pivEx_Quantity.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.DataArea;
            this.pivEx_Quantity.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivEx_Quantity.AreaIndex = 0;
            this.pivEx_Quantity.Caption = "Số Lượng";
            this.pivEx_Quantity.CellFormat.FormatString = "{0:n0}";
            this.pivEx_Quantity.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivEx_Quantity.FieldName = "Quantity";
            this.pivEx_Quantity.GrandTotalCellFormat.FormatString = "{0:n0}";
            this.pivEx_Quantity.GrandTotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivEx_Quantity.Name = "pivEx_Quantity";
            this.pivEx_Quantity.TotalCellFormat.FormatString = "{0:n0}";
            this.pivEx_Quantity.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivEx_Quantity.TotalValueFormat.FormatString = "{0:n0}";
            this.pivEx_Quantity.TotalValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivEx_Quantity.ValueFormat.FormatString = "{0:n0}";
            this.pivEx_Quantity.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            // 
            // pivEx_QtyPromotion
            // 
            this.pivEx_QtyPromotion.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.DataArea;
            this.pivEx_QtyPromotion.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivEx_QtyPromotion.AreaIndex = 1;
            this.pivEx_QtyPromotion.Caption = "Số Lượng KM";
            this.pivEx_QtyPromotion.CellFormat.FormatString = "{0:n0}";
            this.pivEx_QtyPromotion.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivEx_QtyPromotion.FieldName = "QuantityPromotion";
            this.pivEx_QtyPromotion.GrandTotalCellFormat.FormatString = "{0:n0}";
            this.pivEx_QtyPromotion.GrandTotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivEx_QtyPromotion.Name = "pivEx_QtyPromotion";
            this.pivEx_QtyPromotion.TotalCellFormat.FormatString = "{0:n0}";
            this.pivEx_QtyPromotion.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivEx_QtyPromotion.TotalValueFormat.FormatString = "{0:n0}";
            this.pivEx_QtyPromotion.TotalValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivEx_QtyPromotion.ValueFormat.FormatString = "{0:n0}";
            this.pivEx_QtyPromotion.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            // 
            // pivEx_ID
            // 
            this.pivEx_ID.AreaIndex = 2;
            this.pivEx_ID.Caption = "Mã";
            this.pivEx_ID.FieldName = "Order_ID";
            this.pivEx_ID.Name = "pivEx_ID";
            // 
            // pivEx_companyName
            // 
            this.pivEx_companyName.AllowedAreas = ((DevExpress.XtraPivotGrid.PivotGridAllowedAreas)(((DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea | DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea)
                        | DevExpress.XtraPivotGrid.PivotGridAllowedAreas.FilterArea)));
            this.pivEx_companyName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivEx_companyName.AreaIndex = 1;
            this.pivEx_companyName.Caption = "Công Ty";
            this.pivEx_companyName.FieldName = "CompanyName";
            this.pivEx_companyName.Name = "pivEx_companyName";
            // 
            // pivOdd_Price
            // 
            this.pivOdd_Price.AllowedAreas = ((DevExpress.XtraPivotGrid.PivotGridAllowedAreas)(((DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea | DevExpress.XtraPivotGrid.PivotGridAllowedAreas.ColumnArea)
                        | DevExpress.XtraPivotGrid.PivotGridAllowedAreas.FilterArea)));
            this.pivOdd_Price.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivOdd_Price.AreaIndex = 3;
            this.pivOdd_Price.Caption = "Giá";
            this.pivOdd_Price.CellFormat.FormatString = "{0:c0}";
            this.pivOdd_Price.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivOdd_Price.FieldName = "Price";
            this.pivOdd_Price.Name = "pivOdd_Price";
            this.pivOdd_Price.ValueFormat.FormatString = "{0:c0}";
            this.pivOdd_Price.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            // 
            // uctImportReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "uctImportReport";
            this.Size = new System.Drawing.Size(678, 342);
            this.Load += new System.EventHandler(this.uctImportReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivImportReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tabImport.ResumeLayout(false);
            this.tabExport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pivExport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnGetData;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dateEnd;
        private DevExpress.XtraEditors.DateEdit dateBegin;
        private DevExpress.XtraPivotGrid.PivotGridControl pivImportReport;
        private DevExpress.XtraPivotGrid.PivotGridField piv_IOCompanyName;
        private DevExpress.XtraPivotGrid.PivotGridField piv_IOOrderCompany_ID;
        private DevExpress.XtraPivotGrid.PivotGridField piv_IODate;
        private DevExpress.XtraPivotGrid.PivotGridField piv_IOProductName;
        private DevExpress.XtraPivotGrid.PivotGridField piv_IOQuantity;
        private DevExpress.XtraPivotGrid.PivotGridField piv_IOQuantityPromotion;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tabImport;
        private DevExpress.XtraTab.XtraTabPage tabExport;
        private DevExpress.XtraPivotGrid.PivotGridControl pivExport;
        private DevExpress.XtraPivotGrid.PivotGridField pivEx_Date;
        private DevExpress.XtraPivotGrid.PivotGridField pivEx_CustName;
        private DevExpress.XtraPivotGrid.PivotGridField pivEx_EmpName;
        private DevExpress.XtraPivotGrid.PivotGridField pivEx_ProductName;
        private DevExpress.XtraPivotGrid.PivotGridField pivEx_Quantity;
        private DevExpress.XtraPivotGrid.PivotGridField pivEx_QtyPromotion;
        private DevExpress.XtraPivotGrid.PivotGridField pivEx_ID;
        private DevExpress.XtraPivotGrid.PivotGridField pivEx_companyName;
        private DevExpress.XtraPivotGrid.PivotGridField piv_Price;
        private DevExpress.XtraPivotGrid.PivotGridField pivOdd_Price;
    }
}
