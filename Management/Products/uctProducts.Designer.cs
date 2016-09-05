namespace Management.Products
{
    partial class uctProducts
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uctProducts));
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.col_ProQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ProQuantity_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colProQuantityPromotion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.cboCompany = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnGetData = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddNewProduct = new DevExpress.XtraEditors.SimpleButton();
            this.gcProducts = new DevExpress.XtraGrid.GridControl();
            this.cmdMenuPro = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmdEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdDel = new System.Windows.Forms.ToolStripMenuItem();
            this.gvProducts = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Col_PriceActual = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ProID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ProName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ProName_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.col_ProCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ProUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ProPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ProPriceBuy_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.col_ProDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ProDateEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ProDateEdit_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.col_Weight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ProTotalQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ProCompany_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_ProUnit_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_ProProductType_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.col_ProQuantity_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProducts)).BeginInit();
            this.cmdMenuPro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_ProName_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_ProPriceBuy_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_ProDateEdit_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_ProDateEdit_Edit.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_ProCompany_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_ProUnit_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_ProProductType_Edit)).BeginInit();
            this.SuspendLayout();
            // 
            // col_ProQuantity
            // 
            this.col_ProQuantity.Caption = "Số Lượng";
            this.col_ProQuantity.ColumnEdit = this.col_ProQuantity_Edit;
            this.col_ProQuantity.FieldName = "Quantity";
            this.col_ProQuantity.Name = "col_ProQuantity";
            this.col_ProQuantity.Visible = true;
            this.col_ProQuantity.VisibleIndex = 6;
            this.col_ProQuantity.Width = 68;
            // 
            // col_ProQuantity_Edit
            // 
            this.col_ProQuantity_Edit.AutoHeight = false;
            this.col_ProQuantity_Edit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.col_ProQuantity_Edit.Name = "col_ProQuantity_Edit";
            // 
            // colProQuantityPromotion
            // 
            this.colProQuantityPromotion.Caption = "Số Lượng Khuyến Mại";
            this.colProQuantityPromotion.FieldName = "QuantityPromotion";
            this.colProQuantityPromotion.Name = "colProQuantityPromotion";
            this.colProQuantityPromotion.Width = 115;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnImport);
            this.panelControl1.Controls.Add(this.chkAll);
            this.panelControl1.Controls.Add(this.cboCompany);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.btnGetData);
            this.panelControl1.Controls.Add(this.btnAddNewProduct);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(800, 44);
            this.panelControl1.TabIndex = 0;
            // 
            // btnImport
            // 
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.Location = new System.Drawing.Point(594, 10);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(104, 26);
            this.btnImport.TabIndex = 5;
            this.btnImport.Text = "Import Dữ Liệu";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // chkAll
            // 
            this.chkAll.Location = new System.Drawing.Point(253, 14);
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Caption = "Tất Cả";
            this.chkAll.Size = new System.Drawing.Size(75, 19);
            this.chkAll.TabIndex = 4;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // cboCompany
            // 
            this.cboCompany.Location = new System.Drawing.Point(66, 13);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCompany.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyName", "Tên Công Ty"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Address", "Địa Chỉ")});
            this.cboCompany.Properties.NullText = "CHỌN.......";
            this.cboCompany.Properties.PopupWidth = 350;
            this.cboCompany.Size = new System.Drawing.Size(180, 20);
            this.cboCompany.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(19, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Công Ty";
            // 
            // btnGetData
            // 
            this.btnGetData.Image = ((System.Drawing.Image)(resources.GetObject("btnGetData.Image")));
            this.btnGetData.Location = new System.Drawing.Point(336, 10);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(94, 26);
            this.btnGetData.TabIndex = 1;
            this.btnGetData.Text = "Lấy Dữ Liệu";
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // btnAddNewProduct
            // 
            this.btnAddNewProduct.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewProduct.Image")));
            this.btnAddNewProduct.Location = new System.Drawing.Point(460, 10);
            this.btnAddNewProduct.Name = "btnAddNewProduct";
            this.btnAddNewProduct.Size = new System.Drawing.Size(111, 26);
            this.btnAddNewProduct.TabIndex = 0;
            this.btnAddNewProduct.Text = "Thêm Sản Phẩm";
            this.btnAddNewProduct.Visible = false;
            this.btnAddNewProduct.Click += new System.EventHandler(this.btnAddNewProduct_Click);
            // 
            // gcProducts
            // 
            this.gcProducts.ContextMenuStrip = this.cmdMenuPro;
            this.gcProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcProducts.Location = new System.Drawing.Point(0, 44);
            this.gcProducts.MainView = this.gvProducts;
            this.gcProducts.Name = "gcProducts";
            this.gcProducts.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.col_ProName_Edit,
            this.col_ProCompany_Edit,
            this.col_ProUnit_Edit,
            this.col_ProQuantity_Edit,
            this.col_ProPriceBuy_Edit,
            this.col_ProDateEdit_Edit,
            this.col_ProProductType_Edit});
            this.gcProducts.Size = new System.Drawing.Size(800, 556);
            this.gcProducts.TabIndex = 1;
            this.gcProducts.UseEmbeddedNavigator = true;
            this.gcProducts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProducts});
            this.gcProducts.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gcProducts_ProcessGridKey);
            // 
            // cmdMenuPro
            // 
            this.cmdMenuPro.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdEdit,
            this.cmdDel});
            this.cmdMenuPro.Name = "cmdMenuPro";
            this.cmdMenuPro.Size = new System.Drawing.Size(151, 48);
            this.cmdMenuPro.Opening += new System.ComponentModel.CancelEventHandler(this.cmdMenuPro_Opening);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Image = ((System.Drawing.Image)(resources.GetObject("cmdEdit.Image")));
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(150, 22);
            this.cmdEdit.Text = "Sửa Sản Phẩm";
            this.cmdEdit.Visible = false;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdDel
            // 
            this.cmdDel.Image = ((System.Drawing.Image)(resources.GetObject("cmdDel.Image")));
            this.cmdDel.Name = "cmdDel";
            this.cmdDel.Size = new System.Drawing.Size(150, 22);
            this.cmdDel.Text = "Xóa Sản Phẩm";
            this.cmdDel.Click += new System.EventHandler(this.cmdDel_Click);
            // 
            // gvProducts
            // 
            this.gvProducts.BestFitMaxRowCount = 10;
            this.gvProducts.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Col_PriceActual,
            this.col_ProID,
            this.col_ProName,
            this.col_ProCompany,
            this.col_ProUnit,
            this.col_ProQuantity,
            this.col_ProPrice,
            this.col_ProDiscount,
            this.col_ProDateEdit,
            this.col_Weight,
            this.colProQuantityPromotion,
            this.col_ProTotalQty});
            styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.Red;
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.Column = this.col_ProQuantity;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.LessOrEqual;
            styleFormatCondition1.Value1 = 200;
            styleFormatCondition2.Appearance.ForeColor = System.Drawing.Color.Red;
            styleFormatCondition2.Appearance.Options.UseForeColor = true;
            styleFormatCondition2.Column = this.colProQuantityPromotion;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.LessOrEqual;
            styleFormatCondition2.Value1 = 100;
            this.gvProducts.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2});
            this.gvProducts.GridControl = this.gcProducts;
            this.gvProducts.GroupCount = 1;
            this.gvProducts.IndicatorWidth = 35;
            this.gvProducts.Name = "gvProducts";
            this.gvProducts.NewItemRowText = "* Bấm Vào Đây Để Thêm Sản Phẩm Mới";
            this.gvProducts.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvProducts.OptionsBehavior.Editable = false;
            this.gvProducts.OptionsPrint.AutoWidth = false;
            this.gvProducts.OptionsView.ColumnAutoWidth = false;
            this.gvProducts.OptionsView.ShowAutoFilterRow = true;
            this.gvProducts.OptionsView.ShowGroupPanel = false;
            this.gvProducts.RowHeight = 10;
            this.gvProducts.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.col_ProCompany, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvProducts.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvProducts_CustomDrawRowIndicator);
            this.gvProducts.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvProducts_RowStyle);
            this.gvProducts.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvProducts_FocusedRowChanged);
            this.gvProducts.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gvProducts_InvalidRowException);
            this.gvProducts.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvProducts_ValidateRow);
            // 
            // Col_PriceActual
            // 
            this.Col_PriceActual.Caption = "Giá Nhập";
            this.Col_PriceActual.DisplayFormat.FormatString = "{0:c0}";
            this.Col_PriceActual.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Col_PriceActual.FieldName = "PriceActual_Import";
            this.Col_PriceActual.Name = "Col_PriceActual";
            this.Col_PriceActual.Visible = true;
            this.Col_PriceActual.VisibleIndex = 3;
            // 
            // col_ProID
            // 
            this.col_ProID.Caption = "Mã SP";
            this.col_ProID.FieldName = "Product_ID";
            this.col_ProID.Name = "col_ProID";
            this.col_ProID.OptionsColumn.AllowEdit = false;
            this.col_ProID.OptionsColumn.AllowFocus = false;
            this.col_ProID.Visible = true;
            this.col_ProID.VisibleIndex = 0;
            this.col_ProID.Width = 56;
            // 
            // col_ProName
            // 
            this.col_ProName.Caption = "Tên Sản Phẩm";
            this.col_ProName.ColumnEdit = this.col_ProName_Edit;
            this.col_ProName.FieldName = "ProductName";
            this.col_ProName.Name = "col_ProName";
            this.col_ProName.Visible = true;
            this.col_ProName.VisibleIndex = 1;
            this.col_ProName.Width = 165;
            // 
            // col_ProName_Edit
            // 
            this.col_ProName_Edit.Appearance.Options.UseTextOptions = true;
            this.col_ProName_Edit.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.col_ProName_Edit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.col_ProName_Edit.Name = "col_ProName_Edit";
            // 
            // col_ProCompany
            // 
            this.col_ProCompany.Caption = "Tên Công Ty";
            this.col_ProCompany.FieldName = "CompanyName";
            this.col_ProCompany.Name = "col_ProCompany";
            this.col_ProCompany.OptionsColumn.AllowEdit = false;
            this.col_ProCompany.OptionsColumn.AllowFocus = false;
            this.col_ProCompany.Width = 122;
            // 
            // col_ProUnit
            // 
            this.col_ProUnit.Caption = "Đơn Vị Tính";
            this.col_ProUnit.FieldName = "UnitName";
            this.col_ProUnit.Name = "col_ProUnit";
            this.col_ProUnit.Visible = true;
            this.col_ProUnit.VisibleIndex = 2;
            this.col_ProUnit.Width = 73;
            // 
            // col_ProPrice
            // 
            this.col_ProPrice.Caption = "Đơn Giá";
            this.col_ProPrice.ColumnEdit = this.col_ProPriceBuy_Edit;
            this.col_ProPrice.DisplayFormat.FormatString = "{0:c0}";
            this.col_ProPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_ProPrice.FieldName = "Price";
            this.col_ProPrice.Name = "col_ProPrice";
            this.col_ProPrice.Visible = true;
            this.col_ProPrice.VisibleIndex = 4;
            this.col_ProPrice.Width = 81;
            // 
            // col_ProPriceBuy_Edit
            // 
            this.col_ProPriceBuy_Edit.AutoHeight = false;
            this.col_ProPriceBuy_Edit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.col_ProPriceBuy_Edit.Name = "col_ProPriceBuy_Edit";
            // 
            // col_ProDiscount
            // 
            this.col_ProDiscount.Caption = "Chiết Khấu (%)";
            this.col_ProDiscount.ColumnEdit = this.col_ProPriceBuy_Edit;
            this.col_ProDiscount.FieldName = "Discount";
            this.col_ProDiscount.Name = "col_ProDiscount";
            this.col_ProDiscount.Visible = true;
            this.col_ProDiscount.VisibleIndex = 7;
            this.col_ProDiscount.Width = 93;
            // 
            // col_ProDateEdit
            // 
            this.col_ProDateEdit.Caption = "Ngày Sửa";
            this.col_ProDateEdit.ColumnEdit = this.col_ProDateEdit_Edit;
            this.col_ProDateEdit.FieldName = "DataEdit";
            this.col_ProDateEdit.Name = "col_ProDateEdit";
            this.col_ProDateEdit.OptionsColumn.AllowEdit = false;
            this.col_ProDateEdit.OptionsColumn.AllowFocus = false;
            this.col_ProDateEdit.Visible = true;
            this.col_ProDateEdit.VisibleIndex = 8;
            this.col_ProDateEdit.Width = 80;
            // 
            // col_ProDateEdit_Edit
            // 
            this.col_ProDateEdit_Edit.AutoHeight = false;
            this.col_ProDateEdit_Edit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.col_ProDateEdit_Edit.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.col_ProDateEdit_Edit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_ProDateEdit_Edit.Name = "col_ProDateEdit_Edit";
            this.col_ProDateEdit_Edit.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // col_Weight
            // 
            this.col_Weight.Caption = "Trọng Lượng";
            this.col_Weight.FieldName = "Weight";
            this.col_Weight.Name = "col_Weight";
            this.col_Weight.Visible = true;
            this.col_Weight.VisibleIndex = 5;
            // 
            // col_ProTotalQty
            // 
            this.col_ProTotalQty.Caption = "Tổng Số Lượng";
            this.col_ProTotalQty.FieldName = "TotalQuantity";
            this.col_ProTotalQty.Name = "col_ProTotalQty";
            this.col_ProTotalQty.OptionsColumn.AllowEdit = false;
            this.col_ProTotalQty.OptionsColumn.AllowFocus = false;
            this.col_ProTotalQty.Width = 102;
            // 
            // col_ProCompany_Edit
            // 
            this.col_ProCompany_Edit.AutoHeight = false;
            this.col_ProCompany_Edit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.col_ProCompany_Edit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyName", "Tên Công Ty"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Address", "Địa Chỉ")});
            this.col_ProCompany_Edit.Name = "col_ProCompany_Edit";
            this.col_ProCompany_Edit.NullText = "Chọn Công Ty";
            // 
            // col_ProUnit_Edit
            // 
            this.col_ProUnit_Edit.AutoHeight = false;
            this.col_ProUnit_Edit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.col_ProUnit_Edit.Name = "col_ProUnit_Edit";
            this.col_ProUnit_Edit.NullText = "Đơn Vị Tính";
            // 
            // col_ProProductType_Edit
            // 
            this.col_ProProductType_Edit.AutoHeight = false;
            this.col_ProProductType_Edit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.col_ProProductType_Edit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductTypeName", "Loại Sản Phẩm")});
            this.col_ProProductType_Edit.Name = "col_ProProductType_Edit";
            this.col_ProProductType_Edit.NullText = "Loại Sản Phẩm";
            // 
            // uctProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcProducts);
            this.Controls.Add(this.panelControl1);
            this.Name = "uctProducts";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.uctProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.col_ProQuantity_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProducts)).EndInit();
            this.cmdMenuPro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_ProName_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_ProPriceBuy_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_ProDateEdit_Edit.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_ProDateEdit_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_ProCompany_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_ProUnit_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_ProProductType_Edit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gcProducts;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProducts;
        private DevExpress.XtraGrid.Columns.GridColumn col_ProID;
        private DevExpress.XtraGrid.Columns.GridColumn col_ProName;
        private DevExpress.XtraGrid.Columns.GridColumn col_ProCompany;
        private DevExpress.XtraGrid.Columns.GridColumn col_ProUnit;
        private DevExpress.XtraGrid.Columns.GridColumn col_ProQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn col_ProPrice;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit col_ProName_Edit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit col_ProCompany_Edit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit col_ProUnit_Edit;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit col_ProQuantity_Edit;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit col_ProPriceBuy_Edit;
        private DevExpress.XtraGrid.Columns.GridColumn col_ProDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn col_ProDateEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit col_ProDateEdit_Edit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit col_ProProductType_Edit;
        private DevExpress.XtraEditors.SimpleButton btnAddNewProduct;
        private System.Windows.Forms.ContextMenuStrip cmdMenuPro;
        private System.Windows.Forms.ToolStripMenuItem cmdEdit;
        private System.Windows.Forms.ToolStripMenuItem cmdDel;
        private DevExpress.XtraGrid.Columns.GridColumn col_Weight;
        private DevExpress.XtraGrid.Columns.GridColumn colProQuantityPromotion;
        private DevExpress.XtraEditors.SimpleButton btnGetData;
        private DevExpress.XtraEditors.CheckEdit chkAll;
        private DevExpress.XtraEditors.LookUpEdit cboCompany;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn col_ProTotalQty;
        private DevExpress.XtraEditors.SimpleButton btnImport;
        private DevExpress.XtraGrid.Columns.GridColumn Col_PriceActual;
    }
}
