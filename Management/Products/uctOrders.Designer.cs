namespace Management.Products
{
    partial class uctOrders
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uctOrders));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gvOrderDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Col_PriceActual = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ODDID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ODDProName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ODDQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ODDQtyPromo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ODDPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ODDDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ODDPecentPromo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ODDAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ODDPercentSalary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcOrders = new DevExpress.XtraGrid.GridControl();
            this.cmdMenuOrder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sửaHóaĐơnXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inHóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdChangeProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdReturnProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.gvPaymentOrders = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ODPID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ODPIDDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ODPIDAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ODPIDNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.vProchanges = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gcProchange_Date = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gcProchange_Order_ID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcProchange_ProNameOld = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcProchange_QuantityOld = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcProchange_QtyPromotionOld = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcProchange_PriceOld = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gcProchange_PronameNew = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcProchange_QuantityNEw = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcProchange_QtyPromotion = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcProchange_PriceNEw = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gvOrders = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ODID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ODCustName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ODEmpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ODDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.col_ODTotalAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ODTotalPayAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ODPay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ODISLock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ODISLock_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.col_ODIsLock1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Discount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Reset = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btn_RefeshSalary = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.col_ODAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_CastPromotion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ButtonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.rdChangeProduct = new System.Windows.Forms.RadioButton();
            this.rdOrder = new System.Windows.Forms.RadioButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.radOption = new DevExpress.XtraEditors.RadioGroup();
            this.groupOrder_ID = new DevExpress.XtraEditors.GroupControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtOrder_ID = new DevExpress.XtraEditors.TextEdit();
            this.GroupOrther = new DevExpress.XtraEditors.GroupControl();
            this.cboCust = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.chkAllEmp = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboEmp = new DevExpress.XtraEditors.LookUpEdit();
            this.dateBegin = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dateEnd = new DevExpress.XtraEditors.DateEdit();
            this.chkAllCust = new DevExpress.XtraEditors.CheckEdit();
            this.btnNewOrder = new DevExpress.XtraEditors.SimpleButton();
            this.btnGetData = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrderDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcOrders)).BeginInit();
            this.cmdMenuOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPaymentOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vProchanges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_ODISLock_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_RefeshSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radOption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupOrder_ID)).BeginInit();
            this.groupOrder_ID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrder_ID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupOrther)).BeginInit();
            this.GroupOrther.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCust.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllEmp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllCust.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gvOrderDetails
            // 
            this.gvOrderDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Col_PriceActual,
            this.col_ODDID,
            this.col_ODDProName,
            this.col_ODDQuantity,
            this.col_ODDQtyPromo,
            this.col_ODDPrice,
            this.col_ODDDiscount,
            this.col_ODDPecentPromo,
            this.col_ODDAmount,
            this.col_ODDPercentSalary});
            this.gvOrderDetails.GridControl = this.gcOrders;
            this.gvOrderDetails.Name = "gvOrderDetails";
            this.gvOrderDetails.OptionsBehavior.Editable = false;
            this.gvOrderDetails.OptionsView.ColumnAutoWidth = false;
            this.gvOrderDetails.OptionsView.EnableAppearanceOddRow = true;
            this.gvOrderDetails.OptionsView.ShowGroupPanel = false;
            // 
            // Col_PriceActual
            // 
            this.Col_PriceActual.AppearanceHeader.Options.UseTextOptions = true;
            this.Col_PriceActual.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Col_PriceActual.Caption = "Giá Nhập";
            this.Col_PriceActual.DisplayFormat.FormatString = "{0:c2}";
            this.Col_PriceActual.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Col_PriceActual.FieldName = "Price_Import";
            this.Col_PriceActual.Name = "Col_PriceActual";
            this.Col_PriceActual.Visible = true;
            this.Col_PriceActual.VisibleIndex = 1;
            this.Col_PriceActual.Width = 82;
            // 
            // col_ODDID
            // 
            this.col_ODDID.Caption = "Mã Chi Tiết";
            this.col_ODDID.FieldName = "OrderDetail_ID";
            this.col_ODDID.Name = "col_ODDID";
            this.col_ODDID.OptionsColumn.AllowEdit = false;
            this.col_ODDID.OptionsColumn.AllowFocus = false;
            // 
            // col_ODDProName
            // 
            this.col_ODDProName.Caption = "Tên Sản Phẩm";
            this.col_ODDProName.FieldName = "ProductName";
            this.col_ODDProName.Name = "col_ODDProName";
            this.col_ODDProName.OptionsColumn.AllowEdit = false;
            this.col_ODDProName.Visible = true;
            this.col_ODDProName.VisibleIndex = 0;
            this.col_ODDProName.Width = 247;
            // 
            // col_ODDQuantity
            // 
            this.col_ODDQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.col_ODDQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ODDQuantity.Caption = "Số Lượng";
            this.col_ODDQuantity.FieldName = "Quantity";
            this.col_ODDQuantity.Name = "col_ODDQuantity";
            this.col_ODDQuantity.OptionsColumn.AllowEdit = false;
            this.col_ODDQuantity.Visible = true;
            this.col_ODDQuantity.VisibleIndex = 3;
            this.col_ODDQuantity.Width = 58;
            // 
            // col_ODDQtyPromo
            // 
            this.col_ODDQtyPromo.AppearanceHeader.Options.UseTextOptions = true;
            this.col_ODDQtyPromo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ODDQtyPromo.Caption = "Số Lượng KM";
            this.col_ODDQtyPromo.FieldName = "QuantityPromotion";
            this.col_ODDQtyPromo.Name = "col_ODDQtyPromo";
            this.col_ODDQtyPromo.OptionsColumn.AllowEdit = false;
            this.col_ODDQtyPromo.Visible = true;
            this.col_ODDQtyPromo.VisibleIndex = 4;
            // 
            // col_ODDPrice
            // 
            this.col_ODDPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.col_ODDPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ODDPrice.Caption = "Đơn Giá";
            this.col_ODDPrice.DisplayFormat.FormatString = "{0:c0}";
            this.col_ODDPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_ODDPrice.FieldName = "Price";
            this.col_ODDPrice.Name = "col_ODDPrice";
            this.col_ODDPrice.OptionsColumn.AllowEdit = false;
            this.col_ODDPrice.Visible = true;
            this.col_ODDPrice.VisibleIndex = 2;
            this.col_ODDPrice.Width = 80;
            // 
            // col_ODDDiscount
            // 
            this.col_ODDDiscount.AppearanceHeader.Options.UseTextOptions = true;
            this.col_ODDDiscount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ODDDiscount.Caption = "Chiết Khấu";
            this.col_ODDDiscount.FieldName = "Discount";
            this.col_ODDDiscount.Name = "col_ODDDiscount";
            this.col_ODDDiscount.OptionsColumn.AllowEdit = false;
            this.col_ODDDiscount.Visible = true;
            this.col_ODDDiscount.VisibleIndex = 6;
            this.col_ODDDiscount.Width = 64;
            // 
            // col_ODDPecentPromo
            // 
            this.col_ODDPecentPromo.AppearanceHeader.Options.UseTextOptions = true;
            this.col_ODDPecentPromo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ODDPecentPromo.Caption = "% KM";
            this.col_ODDPecentPromo.FieldName = "PercentPromotion";
            this.col_ODDPecentPromo.Name = "col_ODDPecentPromo";
            this.col_ODDPecentPromo.OptionsColumn.AllowEdit = false;
            this.col_ODDPecentPromo.Visible = true;
            this.col_ODDPecentPromo.VisibleIndex = 7;
            this.col_ODDPecentPromo.Width = 49;
            // 
            // col_ODDAmount
            // 
            this.col_ODDAmount.AppearanceHeader.Options.UseTextOptions = true;
            this.col_ODDAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ODDAmount.Caption = "Thành Tiền";
            this.col_ODDAmount.DisplayFormat.FormatString = "{0:c0}";
            this.col_ODDAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_ODDAmount.FieldName = "Amount";
            this.col_ODDAmount.Name = "col_ODDAmount";
            this.col_ODDAmount.OptionsColumn.AllowEdit = false;
            this.col_ODDAmount.SummaryItem.DisplayFormat = "{0:c1}";
            this.col_ODDAmount.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col_ODDAmount.Visible = true;
            this.col_ODDAmount.VisibleIndex = 8;
            this.col_ODDAmount.Width = 94;
            // 
            // col_ODDPercentSalary
            // 
            this.col_ODDPercentSalary.AppearanceHeader.Options.UseTextOptions = true;
            this.col_ODDPercentSalary.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ODDPercentSalary.Caption = "% NV ";
            this.col_ODDPercentSalary.FieldName = "PercentSalary";
            this.col_ODDPercentSalary.Name = "col_ODDPercentSalary";
            this.col_ODDPercentSalary.Visible = true;
            this.col_ODDPercentSalary.VisibleIndex = 5;
            this.col_ODDPercentSalary.Width = 37;
            // 
            // gcOrders
            // 
            this.gcOrders.ContextMenuStrip = this.cmdMenuOrder;
            this.gcOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.gvOrderDetails;
            gridLevelNode1.RelationName = "Level1";
            gridLevelNode2.LevelTemplate = this.gvPaymentOrders;
            gridLevelNode2.RelationName = "Level2";
            gridLevelNode3.LevelTemplate = this.vProchanges;
            gridLevelNode3.RelationName = "Level3";
            this.gcOrders.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2,
            gridLevelNode3});
            this.gcOrders.Location = new System.Drawing.Point(0, 147);
            this.gcOrders.MainView = this.gvOrders;
            this.gcOrders.Name = "gcOrders";
            this.gcOrders.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.col_ODISLock_Edit,
            this.ButtonEdit,
            this.repositoryItemDateEdit1,
            this.btn_RefeshSalary});
            this.gcOrders.Size = new System.Drawing.Size(800, 453);
            this.gcOrders.TabIndex = 1;
            this.gcOrders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPaymentOrders,
            this.vProchanges,
            this.gvOrders,
            this.gvOrderDetails});
            this.gcOrders.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gcOrders_ProcessGridKey);
            // 
            // cmdMenuOrder
            // 
            this.cmdMenuOrder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sửaHóaĐơnXuấtToolStripMenuItem,
            this.inHóaĐơnToolStripMenuItem,
            this.cmdChangeProduct,
            this.cmdReturnProduct,
            this.DeleteOrder});
            this.cmdMenuOrder.Name = "cmdMenuOrder";
            this.cmdMenuOrder.Size = new System.Drawing.Size(171, 114);
            this.cmdMenuOrder.Opening += new System.ComponentModel.CancelEventHandler(this.cmdMenuOrder_Opening);
            // 
            // sửaHóaĐơnXuấtToolStripMenuItem
            // 
            this.sửaHóaĐơnXuấtToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sửaHóaĐơnXuấtToolStripMenuItem.Image")));
            this.sửaHóaĐơnXuấtToolStripMenuItem.Name = "sửaHóaĐơnXuấtToolStripMenuItem";
            this.sửaHóaĐơnXuấtToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.sửaHóaĐơnXuấtToolStripMenuItem.Text = "Sửa Hóa Đơn Xuất";
            this.sửaHóaĐơnXuấtToolStripMenuItem.Click += new System.EventHandler(this.sửaHóaĐơnXuấtToolStripMenuItem_Click);
            // 
            // inHóaĐơnToolStripMenuItem
            // 
            this.inHóaĐơnToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("inHóaĐơnToolStripMenuItem.Image")));
            this.inHóaĐơnToolStripMenuItem.Name = "inHóaĐơnToolStripMenuItem";
            this.inHóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.inHóaĐơnToolStripMenuItem.Text = "In Hóa Đơn";
            this.inHóaĐơnToolStripMenuItem.Click += new System.EventHandler(this.inHóaĐơnToolStripMenuItem_Click);
            // 
            // cmdChangeProduct
            // 
            this.cmdChangeProduct.Image = ((System.Drawing.Image)(resources.GetObject("cmdChangeProduct.Image")));
            this.cmdChangeProduct.Name = "cmdChangeProduct";
            this.cmdChangeProduct.Size = new System.Drawing.Size(170, 22);
            this.cmdChangeProduct.Text = "Đổi Sản Phẩm";
            this.cmdChangeProduct.Click += new System.EventHandler(this.cmdChangeProduct_Click);
            // 
            // cmdReturnProduct
            // 
            this.cmdReturnProduct.Image = ((System.Drawing.Image)(resources.GetObject("cmdReturnProduct.Image")));
            this.cmdReturnProduct.Name = "cmdReturnProduct";
            this.cmdReturnProduct.Size = new System.Drawing.Size(170, 22);
            this.cmdReturnProduct.Text = "Trả Sản Phẩm";
            this.cmdReturnProduct.Click += new System.EventHandler(this.cmdReturnProduct_Click);
            // 
            // DeleteOrder
            // 
            this.DeleteOrder.Image = ((System.Drawing.Image)(resources.GetObject("DeleteOrder.Image")));
            this.DeleteOrder.Name = "DeleteOrder";
            this.DeleteOrder.Size = new System.Drawing.Size(170, 22);
            this.DeleteOrder.Text = "Xóa Hóa Đơn";
            this.DeleteOrder.Click += new System.EventHandler(this.xóaHóaĐơnToolStripMenuItem_Click);
            // 
            // gvPaymentOrders
            // 
            this.gvPaymentOrders.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_ODPID,
            this.col_ODPIDDate,
            this.col_ODPIDAmount,
            this.col_ODPIDNote});
            this.gvPaymentOrders.GridControl = this.gcOrders;
            this.gvPaymentOrders.Name = "gvPaymentOrders";
            this.gvPaymentOrders.OptionsBehavior.Editable = false;
            this.gvPaymentOrders.OptionsView.ColumnAutoWidth = false;
            this.gvPaymentOrders.OptionsView.ShowGroupPanel = false;
            // 
            // col_ODPID
            // 
            this.col_ODPID.Caption = "Mã Chi Trả";
            this.col_ODPID.FieldName = "PaymentOrder_ID";
            this.col_ODPID.Name = "col_ODPID";
            this.col_ODPID.Width = 98;
            // 
            // col_ODPIDDate
            // 
            this.col_ODPIDDate.Caption = "Ngày Chi Trả";
            this.col_ODPIDDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.col_ODPIDDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_ODPIDDate.FieldName = "PaymentOrderDate";
            this.col_ODPIDDate.Name = "col_ODPIDDate";
            this.col_ODPIDDate.Visible = true;
            this.col_ODPIDDate.VisibleIndex = 0;
            this.col_ODPIDDate.Width = 101;
            // 
            // col_ODPIDAmount
            // 
            this.col_ODPIDAmount.Caption = "Số Tiền";
            this.col_ODPIDAmount.DisplayFormat.FormatString = "{0:c0}";
            this.col_ODPIDAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_ODPIDAmount.FieldName = "PaymentAmount";
            this.col_ODPIDAmount.Name = "col_ODPIDAmount";
            this.col_ODPIDAmount.SummaryItem.DisplayFormat = "{0:c1}";
            this.col_ODPIDAmount.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col_ODPIDAmount.Visible = true;
            this.col_ODPIDAmount.VisibleIndex = 1;
            this.col_ODPIDAmount.Width = 127;
            // 
            // col_ODPIDNote
            // 
            this.col_ODPIDNote.Caption = "Ghi Chú";
            this.col_ODPIDNote.FieldName = "Note";
            this.col_ODPIDNote.Name = "col_ODPIDNote";
            this.col_ODPIDNote.Visible = true;
            this.col_ODPIDNote.VisibleIndex = 2;
            // 
            // vProchanges
            // 
            this.vProchanges.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand3,
            this.gridBand1,
            this.gridBand2});
            this.vProchanges.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gcProchange_Order_ID,
            this.gcProchange_Date,
            this.gcProchange_ProNameOld,
            this.gcProchange_QuantityOld,
            this.gcProchange_QtyPromotionOld,
            this.gcProchange_PriceOld,
            this.gcProchange_PronameNew,
            this.gcProchange_QuantityNEw,
            this.gcProchange_QtyPromotion,
            this.gcProchange_PriceNEw});
            this.vProchanges.GridControl = this.gcOrders;
            this.vProchanges.Name = "vProchanges";
            this.vProchanges.OptionsBehavior.Editable = false;
            this.vProchanges.OptionsPrint.AutoWidth = false;
            this.vProchanges.OptionsView.ColumnAutoWidth = false;
            this.vProchanges.OptionsView.EnableAppearanceOddRow = true;
            this.vProchanges.OptionsView.ShowAutoFilterRow = true;
            this.vProchanges.OptionsView.ShowGroupPanel = false;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand3.AppearanceHeader.ForeColor = System.Drawing.Color.Red;
            this.gridBand3.AppearanceHeader.Options.UseFont = true;
            this.gridBand3.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.Caption = "Ngày";
            this.gridBand3.Columns.Add(this.gcProchange_Date);
            this.gridBand3.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.Width = 75;
            // 
            // gcProchange_Date
            // 
            this.gcProchange_Date.Caption = "Ngày";
            this.gcProchange_Date.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gcProchange_Date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcProchange_Date.FieldName = "DateChange";
            this.gcProchange_Date.Name = "gcProchange_Date";
            this.gcProchange_Date.Visible = true;
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand1.AppearanceHeader.ForeColor = System.Drawing.Color.Red;
            this.gridBand1.AppearanceHeader.Options.UseFont = true;
            this.gridBand1.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.Caption = "Sản Phẩm Gốc";
            this.gridBand1.Columns.Add(this.gcProchange_Order_ID);
            this.gridBand1.Columns.Add(this.gcProchange_ProNameOld);
            this.gridBand1.Columns.Add(this.gcProchange_QuantityOld);
            this.gridBand1.Columns.Add(this.gcProchange_QtyPromotionOld);
            this.gridBand1.Columns.Add(this.gcProchange_PriceOld);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 363;
            // 
            // gcProchange_Order_ID
            // 
            this.gcProchange_Order_ID.Caption = "Số Hóa Đơn";
            this.gcProchange_Order_ID.FieldName = "Order_ID";
            this.gcProchange_Order_ID.Name = "gcProchange_Order_ID";
            // 
            // gcProchange_ProNameOld
            // 
            this.gcProchange_ProNameOld.Caption = "Sản Phẩm Gốc";
            this.gcProchange_ProNameOld.FieldName = "ProductNameOld";
            this.gcProchange_ProNameOld.Name = "gcProchange_ProNameOld";
            this.gcProchange_ProNameOld.Visible = true;
            this.gcProchange_ProNameOld.Width = 90;
            // 
            // gcProchange_QuantityOld
            // 
            this.gcProchange_QuantityOld.Caption = "Số Lượng Đổi";
            this.gcProchange_QuantityOld.FieldName = "QuantityOld";
            this.gcProchange_QuantityOld.Name = "gcProchange_QuantityOld";
            this.gcProchange_QuantityOld.Visible = true;
            this.gcProchange_QuantityOld.Width = 91;
            // 
            // gcProchange_QtyPromotionOld
            // 
            this.gcProchange_QtyPromotionOld.Caption = "SL Khuyến Mại";
            this.gcProchange_QtyPromotionOld.FieldName = "QuantityPromotionOld";
            this.gcProchange_QtyPromotionOld.Name = "gcProchange_QtyPromotionOld";
            this.gcProchange_QtyPromotionOld.Visible = true;
            this.gcProchange_QtyPromotionOld.Width = 107;
            // 
            // gcProchange_PriceOld
            // 
            this.gcProchange_PriceOld.Caption = "Giá";
            this.gcProchange_PriceOld.DisplayFormat.FormatString = "{0:c0}";
            this.gcProchange_PriceOld.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcProchange_PriceOld.FieldName = "PriceOld";
            this.gcProchange_PriceOld.Name = "gcProchange_PriceOld";
            this.gcProchange_PriceOld.Visible = true;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand2.AppearanceHeader.ForeColor = System.Drawing.Color.Red;
            this.gridBand2.AppearanceHeader.Options.UseFont = true;
            this.gridBand2.AppearanceHeader.Options.UseForeColor = true;
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "Sản Phẩm Sẽ Đổi Thành";
            this.gridBand2.Columns.Add(this.gcProchange_PronameNew);
            this.gridBand2.Columns.Add(this.gcProchange_QuantityNEw);
            this.gridBand2.Columns.Add(this.gcProchange_QtyPromotion);
            this.gridBand2.Columns.Add(this.gcProchange_PriceNEw);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Width = 427;
            // 
            // gcProchange_PronameNew
            // 
            this.gcProchange_PronameNew.Caption = "Sản Phẩm";
            this.gcProchange_PronameNew.FieldName = "ProductNameNew";
            this.gcProchange_PronameNew.Name = "gcProchange_PronameNew";
            this.gcProchange_PronameNew.Visible = true;
            this.gcProchange_PronameNew.Width = 105;
            // 
            // gcProchange_QuantityNEw
            // 
            this.gcProchange_QuantityNEw.Caption = "Số Lượng Thành";
            this.gcProchange_QuantityNEw.FieldName = "QuantityNew";
            this.gcProchange_QuantityNEw.Name = "gcProchange_QuantityNEw";
            this.gcProchange_QuantityNEw.Visible = true;
            this.gcProchange_QuantityNEw.Width = 116;
            // 
            // gcProchange_QtyPromotion
            // 
            this.gcProchange_QtyPromotion.Caption = "SL Khuyến Mại Thành";
            this.gcProchange_QtyPromotion.FieldName = "QuantityPromotionNew";
            this.gcProchange_QtyPromotion.Name = "gcProchange_QtyPromotion";
            this.gcProchange_QtyPromotion.Visible = true;
            this.gcProchange_QtyPromotion.Width = 131;
            // 
            // gcProchange_PriceNEw
            // 
            this.gcProchange_PriceNEw.Caption = "Giá";
            this.gcProchange_PriceNEw.DisplayFormat.FormatString = "{0:c0}";
            this.gcProchange_PriceNEw.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcProchange_PriceNEw.FieldName = "PriceNew";
            this.gcProchange_PriceNEw.Name = "gcProchange_PriceNEw";
            this.gcProchange_PriceNEw.Visible = true;
            // 
            // gvOrders
            // 
            this.gvOrders.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_ODID,
            this.col_ODCustName,
            this.col_ODEmpName,
            this.col_ODDate,
            this.col_ODTotalAmount,
            this.col_ODTotalPayAmount,
            this.col_ODPay,
            this.col_ODISLock,
            this.col_ODIsLock1,
            this.col_Discount,
            this.col_Reset,
            this.col_ODAddress,
            this.col_CastPromotion});
            this.gvOrders.CustomizationFormBounds = new System.Drawing.Rectangle(604, 382, 216, 178);
            this.gvOrders.GridControl = this.gcOrders;
            this.gvOrders.GroupCount = 1;
            this.gvOrders.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gvOrders.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPay", this.col_ODPay, "{0:c0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPayment", this.col_ODTotalPayAmount, "{0:c0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalAmount", this.col_ODTotalAmount, "{0:c0}")});
            this.gvOrders.Name = "gvOrders";
            this.gvOrders.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvOrders.OptionsView.ColumnAutoWidth = false;
            this.gvOrders.OptionsView.EnableAppearanceOddRow = true;
            this.gvOrders.OptionsView.ShowGroupPanel = false;
            this.gvOrders.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.col_ODISLock, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.col_ODDate, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gvOrders.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvOrders_FocusedRowChanged);
            this.gvOrders.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gvOrders_MouseUp);
            // 
            // col_ODID
            // 
            this.col_ODID.Caption = "Mã HĐ";
            this.col_ODID.FieldName = "Order_ID";
            this.col_ODID.Name = "col_ODID";
            this.col_ODID.OptionsColumn.AllowEdit = false;
            this.col_ODID.OptionsColumn.AllowFocus = false;
            this.col_ODID.Visible = true;
            this.col_ODID.VisibleIndex = 0;
            // 
            // col_ODCustName
            // 
            this.col_ODCustName.Caption = "Tên Khách Hàng";
            this.col_ODCustName.FieldName = "CustName";
            this.col_ODCustName.Name = "col_ODCustName";
            this.col_ODCustName.OptionsColumn.AllowEdit = false;
            this.col_ODCustName.Visible = true;
            this.col_ODCustName.VisibleIndex = 1;
            this.col_ODCustName.Width = 128;
            // 
            // col_ODEmpName
            // 
            this.col_ODEmpName.Caption = "Tên Nhân Viên";
            this.col_ODEmpName.FieldName = "EmpName";
            this.col_ODEmpName.Name = "col_ODEmpName";
            this.col_ODEmpName.OptionsColumn.AllowEdit = false;
            this.col_ODEmpName.Visible = true;
            this.col_ODEmpName.VisibleIndex = 3;
            this.col_ODEmpName.Width = 107;
            // 
            // col_ODDate
            // 
            this.col_ODDate.AppearanceCell.Options.UseTextOptions = true;
            this.col_ODDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_ODDate.Caption = "Ngày Hóa Đơn";
            this.col_ODDate.ColumnEdit = this.repositoryItemDateEdit1;
            this.col_ODDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.col_ODDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_ODDate.FieldName = "OrderDate";
            this.col_ODDate.Name = "col_ODDate";
            this.col_ODDate.OptionsColumn.AllowEdit = false;
            this.col_ODDate.OptionsFilter.AllowFilter = false;
            this.col_ODDate.Visible = true;
            this.col_ODDate.VisibleIndex = 4;
            this.col_ODDate.Width = 94;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // col_ODTotalAmount
            // 
            this.col_ODTotalAmount.Caption = "Tổng Tiền";
            this.col_ODTotalAmount.DisplayFormat.FormatString = "{0:c1}";
            this.col_ODTotalAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_ODTotalAmount.FieldName = "TotalAmount";
            this.col_ODTotalAmount.Name = "col_ODTotalAmount";
            this.col_ODTotalAmount.OptionsColumn.AllowEdit = false;
            this.col_ODTotalAmount.OptionsColumn.AllowFocus = false;
            this.col_ODTotalAmount.Visible = true;
            this.col_ODTotalAmount.VisibleIndex = 5;
            this.col_ODTotalAmount.Width = 100;
            // 
            // col_ODTotalPayAmount
            // 
            this.col_ODTotalPayAmount.Caption = "Đã Trả";
            this.col_ODTotalPayAmount.DisplayFormat.FormatString = "{0:c1}";
            this.col_ODTotalPayAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_ODTotalPayAmount.FieldName = "TotalPayment";
            this.col_ODTotalPayAmount.Name = "col_ODTotalPayAmount";
            this.col_ODTotalPayAmount.OptionsColumn.AllowEdit = false;
            this.col_ODTotalPayAmount.OptionsColumn.AllowFocus = false;
            this.col_ODTotalPayAmount.Visible = true;
            this.col_ODTotalPayAmount.VisibleIndex = 8;
            this.col_ODTotalPayAmount.Width = 78;
            // 
            // col_ODPay
            // 
            this.col_ODPay.Caption = "Còn Lại";
            this.col_ODPay.DisplayFormat.FormatString = "{0:c1}";
            this.col_ODPay.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_ODPay.FieldName = "TotalPay";
            this.col_ODPay.Name = "col_ODPay";
            this.col_ODPay.OptionsColumn.AllowEdit = false;
            this.col_ODPay.OptionsColumn.AllowFocus = false;
            this.col_ODPay.Visible = true;
            this.col_ODPay.VisibleIndex = 9;
            this.col_ODPay.Width = 81;
            // 
            // col_ODISLock
            // 
            this.col_ODISLock.Caption = "Khóa";
            this.col_ODISLock.ColumnEdit = this.col_ODISLock_Edit;
            this.col_ODISLock.FieldName = "IsLock";
            this.col_ODISLock.Name = "col_ODISLock";
            // 
            // col_ODISLock_Edit
            // 
            this.col_ODISLock_Edit.AutoHeight = false;
            this.col_ODISLock_Edit.Name = "col_ODISLock_Edit";
            this.col_ODISLock_Edit.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.col_ODISLock_Edit_EditValueChanging);
            // 
            // col_ODIsLock1
            // 
            this.col_ODIsLock1.Caption = "Khóa";
            this.col_ODIsLock1.ColumnEdit = this.col_ODISLock_Edit;
            this.col_ODIsLock1.FieldName = "IsLock";
            this.col_ODIsLock1.Name = "col_ODIsLock1";
            this.col_ODIsLock1.Visible = true;
            this.col_ODIsLock1.VisibleIndex = 10;
            this.col_ODIsLock1.Width = 38;
            // 
            // col_Discount
            // 
            this.col_Discount.Caption = "Chiết Khấu";
            this.col_Discount.DisplayFormat.FormatString = "c1";
            this.col_Discount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Discount.FieldName = "PercentDiscount";
            this.col_Discount.Name = "col_Discount";
            this.col_Discount.Visible = true;
            this.col_Discount.VisibleIndex = 7;
            this.col_Discount.Width = 62;
            // 
            // col_Reset
            // 
            this.col_Reset.Caption = "Cập Nhật Lương";
            this.col_Reset.ColumnEdit = this.btn_RefeshSalary;
            this.col_Reset.FieldName = "update";
            this.col_Reset.Name = "col_Reset";
            this.col_Reset.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.col_Reset.Visible = true;
            this.col_Reset.VisibleIndex = 11;
            this.col_Reset.Width = 85;
            // 
            // btn_RefeshSalary
            // 
            this.btn_RefeshSalary.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("btn_RefeshSalary.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Cập nhật lại lương", null, null, true)});
            this.btn_RefeshSalary.Name = "btn_RefeshSalary";
            this.btn_RefeshSalary.NullText = "Cập Nhật Lương";
            this.btn_RefeshSalary.ReadOnly = true;
            this.btn_RefeshSalary.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btn_RefeshSalary.UseParentBackground = true;
            this.btn_RefeshSalary.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.button_Edit_ButtonClick);
            // 
            // col_ODAddress
            // 
            this.col_ODAddress.Caption = "Địa Chỉ KH";
            this.col_ODAddress.FieldName = "Address";
            this.col_ODAddress.Name = "col_ODAddress";
            this.col_ODAddress.Visible = true;
            this.col_ODAddress.VisibleIndex = 2;
            this.col_ODAddress.Width = 110;
            // 
            // col_CastPromotion
            // 
            this.col_CastPromotion.Caption = "Tiền KM";
            this.col_CastPromotion.DisplayFormat.FormatString = "{0:c0}";
            this.col_CastPromotion.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_CastPromotion.FieldName = "CastPromotion";
            this.col_CastPromotion.Name = "col_CastPromotion";
            this.col_CastPromotion.Visible = true;
            this.col_CastPromotion.VisibleIndex = 6;
            // 
            // ButtonEdit
            // 
            this.ButtonEdit.AutoHeight = false;
            this.ButtonEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)), serializableAppearanceObject2, "", null, null, true)});
            this.ButtonEdit.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.ButtonEdit.Name = "ButtonEdit";
            this.ButtonEdit.NullText = "Cap";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.rdChangeProduct);
            this.panelControl1.Controls.Add(this.rdOrder);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.radOption);
            this.panelControl1.Controls.Add(this.groupOrder_ID);
            this.panelControl1.Controls.Add(this.GroupOrther);
            this.panelControl1.Controls.Add(this.btnNewOrder);
            this.panelControl1.Controls.Add(this.btnGetData);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(800, 147);
            this.panelControl1.TabIndex = 0;
            // 
            // rdChangeProduct
            // 
            this.rdChangeProduct.AutoSize = true;
            this.rdChangeProduct.Location = new System.Drawing.Point(70, 99);
            this.rdChangeProduct.Name = "rdChangeProduct";
            this.rdChangeProduct.Size = new System.Drawing.Size(87, 17);
            this.rdChangeProduct.TabIndex = 17;
            this.rdChangeProduct.Text = "HĐ Đổi Hàng";
            this.rdChangeProduct.UseVisualStyleBackColor = true;
            // 
            // rdOrder
            // 
            this.rdOrder.AutoSize = true;
            this.rdOrder.Checked = true;
            this.rdOrder.Location = new System.Drawing.Point(70, 76);
            this.rdOrder.Name = "rdOrder";
            this.rdOrder.Size = new System.Drawing.Size(93, 17);
            this.rdOrder.TabIndex = 16;
            this.rdOrder.TabStop = true;
            this.rdOrder.Text = "HĐ Xuất Hàng";
            this.rdOrder.UseVisualStyleBackColor = true;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(19, 86);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(37, 13);
            this.labelControl6.TabIndex = 15;
            this.labelControl6.Text = "Loại HĐ";
            // 
            // radOption
            // 
            this.radOption.EditValue = true;
            this.radOption.Location = new System.Drawing.Point(19, 27);
            this.radOption.Name = "radOption";
            this.radOption.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radOption.Properties.Appearance.Options.UseBackColor = true;
            this.radOption.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radOption.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "Nhân Viên - Khách Hàng"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Số Hóa Đơn")});
            this.radOption.Size = new System.Drawing.Size(144, 43);
            this.radOption.TabIndex = 14;
            this.radOption.SelectedIndexChanged += new System.EventHandler(this.radOption_SelectedIndexChanged);
            // 
            // groupOrder_ID
            // 
            this.groupOrder_ID.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupOrder_ID.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.groupOrder_ID.AppearanceCaption.Options.UseFont = true;
            this.groupOrder_ID.AppearanceCaption.Options.UseForeColor = true;
            this.groupOrder_ID.Controls.Add(this.labelControl5);
            this.groupOrder_ID.Controls.Add(this.txtOrder_ID);
            this.groupOrder_ID.Location = new System.Drawing.Point(185, 5);
            this.groupOrder_ID.Name = "groupOrder_ID";
            this.groupOrder_ID.Size = new System.Drawing.Size(200, 102);
            this.groupOrder_ID.TabIndex = 13;
            this.groupOrder_ID.Text = "Số Hóa Đơn";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(17, 52);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(57, 13);
            this.labelControl5.TabIndex = 1;
            this.labelControl5.Text = "Số Hóa Đơn";
            // 
            // txtOrder_ID
            // 
            this.txtOrder_ID.Location = new System.Drawing.Point(83, 49);
            this.txtOrder_ID.Name = "txtOrder_ID";
            this.txtOrder_ID.Properties.Mask.EditMask = "###############";
            this.txtOrder_ID.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtOrder_ID.Size = new System.Drawing.Size(100, 20);
            this.txtOrder_ID.TabIndex = 0;
            this.txtOrder_ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOrder_ID_KeyPress);
            // 
            // GroupOrther
            // 
            this.GroupOrther.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupOrther.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.GroupOrther.AppearanceCaption.Options.UseFont = true;
            this.GroupOrther.AppearanceCaption.Options.UseForeColor = true;
            this.GroupOrther.Controls.Add(this.cboCust);
            this.GroupOrther.Controls.Add(this.labelControl1);
            this.GroupOrther.Controls.Add(this.labelControl2);
            this.GroupOrther.Controls.Add(this.chkAllEmp);
            this.GroupOrther.Controls.Add(this.labelControl3);
            this.GroupOrther.Controls.Add(this.cboEmp);
            this.GroupOrther.Controls.Add(this.dateBegin);
            this.GroupOrther.Controls.Add(this.labelControl4);
            this.GroupOrther.Controls.Add(this.dateEnd);
            this.GroupOrther.Controls.Add(this.chkAllCust);
            this.GroupOrther.Location = new System.Drawing.Point(404, 5);
            this.GroupOrther.Name = "GroupOrther";
            this.GroupOrther.Size = new System.Drawing.Size(380, 102);
            this.GroupOrther.TabIndex = 12;
            this.GroupOrther.Text = "Nhân Viên - Khách Hàng";
            // 
            // cboCust
            // 
            this.cboCust.Location = new System.Drawing.Point(83, 49);
            this.cboCust.Name = "cboCust";
            this.cboCust.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCust.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustName", "Tên Khách Hàng"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Address", "Địa Chỉ")});
            this.cboCust.Properties.NullText = "Chọn Khách Hàng";
            this.cboCust.Properties.PopupWidth = 350;
            this.cboCust.Size = new System.Drawing.Size(159, 20);
            this.cboCust.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(41, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Từ Ngày";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(197, 28);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Đến Ngày";
            // 
            // chkAllEmp
            // 
            this.chkAllEmp.Location = new System.Drawing.Point(244, 75);
            this.chkAllEmp.Name = "chkAllEmp";
            this.chkAllEmp.Properties.Caption = "Tất Cả";
            this.chkAllEmp.Size = new System.Drawing.Size(75, 19);
            this.chkAllEmp.TabIndex = 9;
            this.chkAllEmp.CheckedChanged += new System.EventHandler(this.chkAllEmp_CheckedChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(23, 53);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(57, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Khách Hàng";
            // 
            // cboEmp
            // 
            this.cboEmp.Location = new System.Drawing.Point(83, 74);
            this.cboEmp.Name = "cboEmp";
            this.cboEmp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEmp.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmpName", "Tên Nhân Viên"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Address", "Địa Chỉ")});
            this.cboEmp.Properties.NullText = "Chọn Nhân Viên";
            this.cboEmp.Properties.PopupWidth = 350;
            this.cboEmp.Size = new System.Drawing.Size(159, 20);
            this.cboEmp.TabIndex = 8;
            // 
            // dateBegin
            // 
            this.dateBegin.EditValue = null;
            this.dateBegin.Location = new System.Drawing.Point(83, 24);
            this.dateBegin.Name = "dateBegin";
            this.dateBegin.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dateBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBegin.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateBegin.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateBegin.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateBegin.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateBegin.Size = new System.Drawing.Size(100, 20);
            this.dateBegin.TabIndex = 3;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(23, 78);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 13);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Nhân Viên";
            // 
            // dateEnd
            // 
            this.dateEnd.EditValue = null;
            this.dateEnd.Location = new System.Drawing.Point(250, 24);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEnd.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEnd.Size = new System.Drawing.Size(100, 20);
            this.dateEnd.TabIndex = 4;
            // 
            // chkAllCust
            // 
            this.chkAllCust.Location = new System.Drawing.Point(244, 50);
            this.chkAllCust.Name = "chkAllCust";
            this.chkAllCust.Properties.Caption = "Tất Cả";
            this.chkAllCust.Size = new System.Drawing.Size(75, 19);
            this.chkAllCust.TabIndex = 6;
            this.chkAllCust.CheckedChanged += new System.EventHandler(this.chkAllCust_CheckedChanged);
            // 
            // btnNewOrder
            // 
            this.btnNewOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnNewOrder.Image")));
            this.btnNewOrder.Location = new System.Drawing.Point(459, 113);
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.Size = new System.Drawing.Size(76, 26);
            this.btnNewOrder.TabIndex = 11;
            this.btnNewOrder.Text = "Tạo Mới";
            this.btnNewOrder.Click += new System.EventHandler(this.btnNewOrder_Click);
            // 
            // btnGetData
            // 
            this.btnGetData.Image = ((System.Drawing.Image)(resources.GetObject("btnGetData.Image")));
            this.btnGetData.Location = new System.Drawing.Point(348, 113);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(92, 26);
            this.btnGetData.TabIndex = 10;
            this.btnGetData.Text = "Lấy Dữ Liệu";
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // uctOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcOrders);
            this.Controls.Add(this.panelControl1);
            this.Name = "uctOrders";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.uctOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvOrderDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcOrders)).EndInit();
            this.cmdMenuOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvPaymentOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vProchanges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_ODISLock_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_RefeshSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radOption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupOrder_ID)).EndInit();
            this.groupOrder_ID.ResumeLayout(false);
            this.groupOrder_ID.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrder_ID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupOrther)).EndInit();
            this.GroupOrther.ResumeLayout(false);
            this.GroupOrther.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCust.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllEmp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllCust.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.DateEdit dateEnd;
        private DevExpress.XtraEditors.DateEdit dateBegin;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit chkAllCust;
        private DevExpress.XtraEditors.LookUpEdit cboCust;
        private DevExpress.XtraEditors.SimpleButton btnNewOrder;
        private DevExpress.XtraEditors.SimpleButton btnGetData;
        private DevExpress.XtraEditors.CheckEdit chkAllEmp;
        private DevExpress.XtraEditors.LookUpEdit cboEmp;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraGrid.GridControl gcOrders;
        private DevExpress.XtraGrid.Views.Grid.GridView gvOrders;
        private DevExpress.XtraGrid.Views.Grid.GridView gvOrderDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPaymentOrders;
        private DevExpress.XtraGrid.Columns.GridColumn col_ODID;
        private DevExpress.XtraGrid.Columns.GridColumn col_ODCustName;
        private DevExpress.XtraGrid.Columns.GridColumn col_ODEmpName;
        private DevExpress.XtraGrid.Columns.GridColumn col_ODDate;
        private DevExpress.XtraGrid.Columns.GridColumn col_ODTotalAmount;
        private DevExpress.XtraGrid.Columns.GridColumn col_ODTotalPayAmount;
        private DevExpress.XtraGrid.Columns.GridColumn col_ODPay;
        private DevExpress.XtraGrid.Columns.GridColumn col_ODISLock;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit col_ODISLock_Edit;
        private DevExpress.XtraGrid.Columns.GridColumn col_ODIsLock1;
        private DevExpress.XtraGrid.Columns.GridColumn col_ODDID;
        private DevExpress.XtraGrid.Columns.GridColumn col_ODDProName;
        private DevExpress.XtraGrid.Columns.GridColumn col_ODDQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn col_ODDQtyPromo;
        private DevExpress.XtraGrid.Columns.GridColumn col_ODDPrice;
        private DevExpress.XtraGrid.Columns.GridColumn col_ODDDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn col_ODDPecentPromo;
        private DevExpress.XtraGrid.Columns.GridColumn col_ODDAmount;
        private DevExpress.XtraGrid.Columns.GridColumn col_ODPID;
        private DevExpress.XtraGrid.Columns.GridColumn col_ODPIDDate;
        private DevExpress.XtraGrid.Columns.GridColumn col_ODPIDAmount;
        private DevExpress.XtraGrid.Columns.GridColumn col_ODPIDNote;
        private System.Windows.Forms.ContextMenuStrip cmdMenuOrder;
        private System.Windows.Forms.ToolStripMenuItem sửaHóaĐơnXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inHóaĐơnToolStripMenuItem;
        private DevExpress.XtraEditors.GroupControl groupOrder_ID;
        private DevExpress.XtraEditors.GroupControl GroupOrther;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtOrder_ID;
        private DevExpress.XtraEditors.RadioGroup radOption;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView vProchanges;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcProchange_Order_ID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcProchange_Date;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcProchange_ProNameOld;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcProchange_QuantityOld;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcProchange_QtyPromotionOld;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcProchange_PriceOld;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcProchange_PronameNew;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcProchange_QuantityNEw;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcProchange_QtyPromotion;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcProchange_PriceNEw;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private System.Windows.Forms.ToolStripMenuItem cmdChangeProduct;
        private System.Windows.Forms.ToolStripMenuItem cmdReturnProduct;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ButtonEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn col_Reset;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btn_RefeshSalary;
        private System.Windows.Forms.RadioButton rdChangeProduct;
        private System.Windows.Forms.RadioButton rdOrder;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraGrid.Columns.GridColumn Col_PriceActual;
        private DevExpress.XtraGrid.Columns.GridColumn col_ODAddress;
        private DevExpress.XtraGrid.Columns.GridColumn col_CastPromotion;
        private DevExpress.XtraGrid.Columns.GridColumn col_ODDPercentSalary;
        private System.Windows.Forms.ToolStripMenuItem DeleteOrder;
        private DevExpress.XtraGrid.Columns.GridColumn col_Discount;
    }
}
