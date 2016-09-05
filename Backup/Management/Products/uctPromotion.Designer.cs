namespace Management.Products
{
    partial class uctPromotion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uctPromotion));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkCerruntDate = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dateEnd = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateBegin = new DevExpress.XtraEditors.DateEdit();
            this.btnGetData = new DevExpress.XtraEditors.SimpleButton();
            this.chkAllCom = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboCompany = new DevExpress.XtraEditors.LookUpEdit();
            this.gcPromotion = new DevExpress.XtraGrid.GridControl();
            this.gvPromotion = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_KMID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_KMCompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_KMProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_KMProductName_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.col_KMForm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_KMForm_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.col_KMPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_KMPercent_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.buy_product = new DevExpress.XtraGrid.Columns.GridColumn();
            this.number_promotion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_KMBegin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_KMBegin_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.col_KMEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_KMNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_KMPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_KMPrice_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.col_KMCompanyName_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemCalcEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.col_KMForm_Edit1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.btnAddEditPromotion = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkCerruntDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllCom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPromotion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPromotion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_KMProductName_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_KMForm_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_KMPercent_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_KMBegin_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_KMBegin_Edit.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_KMPrice_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_KMCompanyName_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_KMForm_Edit1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnAddEditPromotion);
            this.panelControl1.Controls.Add(this.chkCerruntDate);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.dateEnd);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.dateBegin);
            this.panelControl1.Controls.Add(this.btnGetData);
            this.panelControl1.Controls.Add(this.chkAllCom);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.cboCompany);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1000, 42);
            this.panelControl1.TabIndex = 0;
            // 
            // chkCerruntDate
            // 
            this.chkCerruntDate.Location = new System.Drawing.Point(616, 11);
            this.chkCerruntDate.Name = "chkCerruntDate";
            this.chkCerruntDate.Properties.Caption = "Khuyến Mại Mới Nhất";
            this.chkCerruntDate.Size = new System.Drawing.Size(137, 19);
            this.chkCerruntDate.TabIndex = 8;
            this.chkCerruntDate.CheckedChanged += new System.EventHandler(this.chkCerruntDate_CheckedChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(459, 14);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 13);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Đến Ngày";
            // 
            // dateEnd
            // 
            this.dateEnd.EditValue = null;
            this.dateEnd.Location = new System.Drawing.Point(510, 10);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEnd.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEnd.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEnd.Size = new System.Drawing.Size(100, 20);
            this.dateEnd.TabIndex = 6;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(297, 14);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(41, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Từ Ngày";
            // 
            // dateBegin
            // 
            this.dateBegin.EditValue = null;
            this.dateBegin.Location = new System.Drawing.Point(341, 10);
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
            this.dateBegin.TabIndex = 4;
            // 
            // btnGetData
            // 
            this.btnGetData.Image = ((System.Drawing.Image)(resources.GetObject("btnGetData.Image")));
            this.btnGetData.Location = new System.Drawing.Point(753, 7);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(97, 26);
            this.btnGetData.TabIndex = 3;
            this.btnGetData.Text = "Lấy Dữ Liệu";
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // chkAllCom
            // 
            this.chkAllCom.Location = new System.Drawing.Point(222, 11);
            this.chkAllCom.Name = "chkAllCom";
            this.chkAllCom.Properties.Caption = "Tất Cả";
            this.chkAllCom.Size = new System.Drawing.Size(75, 19);
            this.chkAllCom.TabIndex = 2;
            this.chkAllCom.CheckedChanged += new System.EventHandler(this.chkAllCom_CheckedChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Công Ty";
            // 
            // cboCompany
            // 
            this.cboCompany.Location = new System.Drawing.Point(52, 10);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCompany.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyName", "Tên Công Ty"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Address", "Địa Chỉ")});
            this.cboCompany.Properties.NullText = "CHỌN CÔNG TY";
            this.cboCompany.Properties.PopupWidth = 350;
            this.cboCompany.Size = new System.Drawing.Size(167, 20);
            this.cboCompany.TabIndex = 0;
            // 
            // gcPromotion
            // 
            this.gcPromotion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPromotion.Location = new System.Drawing.Point(0, 42);
            this.gcPromotion.MainView = this.gvPromotion;
            this.gcPromotion.Name = "gcPromotion";
            this.gcPromotion.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.col_KMCompanyName_Edit,
            this.col_KMProductName_Edit,
            this.col_KMForm_Edit,
            this.col_KMPercent_Edit,
            this.col_KMBegin_Edit,
            this.repositoryItemCalcEdit1,
            this.col_KMPrice_Edit,
            this.col_KMForm_Edit1});
            this.gcPromotion.Size = new System.Drawing.Size(1000, 558);
            this.gcPromotion.TabIndex = 1;
            this.gcPromotion.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPromotion});
            this.gcPromotion.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gcPromotion_ProcessGridKey);
            // 
            // gvPromotion
            // 
            this.gvPromotion.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_KMID,
            this.col_KMCompanyName,
            this.col_KMProductName,
            this.col_KMForm,
            this.col_KMPercent,
            this.buy_product,
            this.number_promotion,
            this.col_KMBegin,
            this.col_KMEndDate,
            this.col_KMNote,
            this.col_KMPrice});
            this.gvPromotion.CustomizationFormBounds = new System.Drawing.Rectangle(793, 291, 216, 178);
            this.gvPromotion.GridControl = this.gcPromotion;
            this.gvPromotion.GroupCount = 1;
            this.gvPromotion.Name = "gvPromotion";
            this.gvPromotion.NewItemRowText = "Thêm Mới Tại Đây";
            this.gvPromotion.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvPromotion.OptionsView.ColumnAutoWidth = false;
            this.gvPromotion.OptionsView.EnableAppearanceOddRow = true;
            this.gvPromotion.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gvPromotion.OptionsView.ShowAutoFilterRow = true;
            this.gvPromotion.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.col_KMCompanyName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvPromotion.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvPromotion_FocusedRowChanged);
            this.gvPromotion.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvPromotion_CellValueChanged);
            this.gvPromotion.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gvPromotion_InitNewRow);
            this.gvPromotion.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gvPromotion_InvalidRowException);
            this.gvPromotion.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvPromotion_ValidateRow);
            // 
            // col_KMID
            // 
            this.col_KMID.Caption = "Mã Khuyến Mại";
            this.col_KMID.FieldName = "Promotion_ID";
            this.col_KMID.Name = "col_KMID";
            this.col_KMID.OptionsColumn.AllowEdit = false;
            this.col_KMID.OptionsColumn.AllowFocus = false;
            // 
            // col_KMCompanyName
            // 
            this.col_KMCompanyName.Caption = "Tên Công Ty";
            this.col_KMCompanyName.FieldName = "CompanyName";
            this.col_KMCompanyName.Name = "col_KMCompanyName";
            this.col_KMCompanyName.OptionsColumn.AllowEdit = false;
            // 
            // col_KMProductName
            // 
            this.col_KMProductName.Caption = "Tên Sản Phẩm";
            this.col_KMProductName.ColumnEdit = this.col_KMProductName_Edit;
            this.col_KMProductName.FieldName = "Product_ID";
            this.col_KMProductName.Name = "col_KMProductName";
            this.col_KMProductName.Visible = true;
            this.col_KMProductName.VisibleIndex = 0;
            this.col_KMProductName.Width = 139;
            // 
            // col_KMProductName_Edit
            // 
            this.col_KMProductName_Edit.AutoHeight = false;
            this.col_KMProductName_Edit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.col_KMProductName_Edit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyName", "Tên Công Ty"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductName", "Tên Sản Phẩm")});
            this.col_KMProductName_Edit.Name = "col_KMProductName_Edit";
            this.col_KMProductName_Edit.NullText = "CHỌN SẢN PHẨM";
            this.col_KMProductName_Edit.PopupWidth = 400;
            // 
            // col_KMForm
            // 
            this.col_KMForm.Caption = "Hình Thức";
            this.col_KMForm.ColumnEdit = this.col_KMForm_Edit;
            this.col_KMForm.FieldName = "Form";
            this.col_KMForm.Name = "col_KMForm";
            this.col_KMForm.Visible = true;
            this.col_KMForm.VisibleIndex = 2;
            this.col_KMForm.Width = 101;
            // 
            // col_KMForm_Edit
            // 
            this.col_KMForm_Edit.Appearance.Options.UseTextOptions = true;
            this.col_KMForm_Edit.AutoHeight = false;
            this.col_KMForm_Edit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.col_KMForm_Edit.Name = "col_KMForm_Edit";
            this.col_KMForm_Edit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // col_KMPercent
            // 
            this.col_KMPercent.Caption = "% Khuyến Mại";
            this.col_KMPercent.ColumnEdit = this.col_KMPercent_Edit;
            this.col_KMPercent.FieldName = "PercentDiscount";
            this.col_KMPercent.Name = "col_KMPercent";
            this.col_KMPercent.Visible = true;
            this.col_KMPercent.VisibleIndex = 3;
            this.col_KMPercent.Width = 88;
            // 
            // col_KMPercent_Edit
            // 
            this.col_KMPercent_Edit.AutoHeight = false;
            this.col_KMPercent_Edit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.col_KMPercent_Edit.Name = "col_KMPercent_Edit";
            // 
            // buy_product
            // 
            this.buy_product.Caption = "Số Lượng Mua";
            this.buy_product.ColumnEdit = this.col_KMPercent_Edit;
            this.buy_product.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.buy_product.FieldName = "Number_buy";
            this.buy_product.Name = "buy_product";
            this.buy_product.Visible = true;
            this.buy_product.VisibleIndex = 4;
            this.buy_product.Width = 93;
            // 
            // number_promotion
            // 
            this.number_promotion.Caption = "Số Lượng Tặng";
            this.number_promotion.ColumnEdit = this.col_KMPercent_Edit;
            this.number_promotion.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.number_promotion.FieldName = "Number_Promotions";
            this.number_promotion.Name = "number_promotion";
            this.number_promotion.Visible = true;
            this.number_promotion.VisibleIndex = 5;
            this.number_promotion.Width = 101;
            // 
            // col_KMBegin
            // 
            this.col_KMBegin.Caption = "Ngày Bắt Đầu";
            this.col_KMBegin.ColumnEdit = this.col_KMBegin_Edit;
            this.col_KMBegin.FieldName = "BeginDate";
            this.col_KMBegin.Name = "col_KMBegin";
            this.col_KMBegin.Visible = true;
            this.col_KMBegin.VisibleIndex = 6;
            this.col_KMBegin.Width = 106;
            // 
            // col_KMBegin_Edit
            // 
            this.col_KMBegin_Edit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.col_KMBegin_Edit.AutoHeight = false;
            this.col_KMBegin_Edit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.col_KMBegin_Edit.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.col_KMBegin_Edit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_KMBegin_Edit.Name = "col_KMBegin_Edit";
            this.col_KMBegin_Edit.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // col_KMEndDate
            // 
            this.col_KMEndDate.Caption = "Ngày Kết Thúc";
            this.col_KMEndDate.ColumnEdit = this.col_KMBegin_Edit;
            this.col_KMEndDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.col_KMEndDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_KMEndDate.FieldName = "EndDate";
            this.col_KMEndDate.Name = "col_KMEndDate";
            this.col_KMEndDate.Visible = true;
            this.col_KMEndDate.VisibleIndex = 7;
            this.col_KMEndDate.Width = 103;
            // 
            // col_KMNote
            // 
            this.col_KMNote.Caption = "Ghi Chú";
            this.col_KMNote.FieldName = "Note";
            this.col_KMNote.Name = "col_KMNote";
            this.col_KMNote.Visible = true;
            this.col_KMNote.VisibleIndex = 8;
            this.col_KMNote.Width = 260;
            // 
            // col_KMPrice
            // 
            this.col_KMPrice.Caption = "Đơn Giá";
            this.col_KMPrice.ColumnEdit = this.col_KMPrice_Edit;
            this.col_KMPrice.DisplayFormat.FormatString = "{0:c0}";
            this.col_KMPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_KMPrice.FieldName = "Price";
            this.col_KMPrice.Name = "col_KMPrice";
            this.col_KMPrice.Visible = true;
            this.col_KMPrice.VisibleIndex = 1;
            this.col_KMPrice.Width = 86;
            // 
            // col_KMPrice_Edit
            // 
            this.col_KMPrice_Edit.Appearance.Options.UseTextOptions = true;
            this.col_KMPrice_Edit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_KMPrice_Edit.AutoHeight = false;
            this.col_KMPrice_Edit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.col_KMPrice_Edit.Name = "col_KMPrice_Edit";
            this.col_KMPrice_Edit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // col_KMCompanyName_Edit
            // 
            this.col_KMCompanyName_Edit.AutoHeight = false;
            this.col_KMCompanyName_Edit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.col_KMCompanyName_Edit.Name = "col_KMCompanyName_Edit";
            this.col_KMCompanyName_Edit.NullText = "CHỌN CÔNG TY";
            // 
            // repositoryItemCalcEdit1
            // 
            this.repositoryItemCalcEdit1.AutoHeight = false;
            this.repositoryItemCalcEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCalcEdit1.DisplayFormat.FormatString = "n4";
            this.repositoryItemCalcEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemCalcEdit1.EditFormat.FormatString = "n4";
            this.repositoryItemCalcEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemCalcEdit1.Mask.EditMask = "n4";
            this.repositoryItemCalcEdit1.Name = "repositoryItemCalcEdit1";
            // 
            // col_KMForm_Edit1
            // 
            this.col_KMForm_Edit1.AutoHeight = false;
            this.col_KMForm_Edit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.col_KMForm_Edit1.Name = "col_KMForm_Edit1";
            // 
            // btnAddEditPromotion
            // 
            this.btnAddEditPromotion.Image = ((System.Drawing.Image)(resources.GetObject("btnAddEditPromotion.Image")));
            this.btnAddEditPromotion.Location = new System.Drawing.Point(856, 7);
            this.btnAddEditPromotion.Name = "btnAddEditPromotion";
            this.btnAddEditPromotion.Size = new System.Drawing.Size(139, 26);
            this.btnAddEditPromotion.TabIndex = 9;
            this.btnAddEditPromotion.Text = "QL Khuyến Mại";
            this.btnAddEditPromotion.Click += new System.EventHandler(this.btnAddEditPromotion_Click);
            // 
            // uctPromotion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcPromotion);
            this.Controls.Add(this.panelControl1);
            this.Name = "uctPromotion";
            this.Size = new System.Drawing.Size(1000, 600);
            this.Load += new System.EventHandler(this.uctPromotion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkCerruntDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllCom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPromotion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPromotion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_KMProductName_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_KMForm_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_KMPercent_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_KMBegin_Edit.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_KMBegin_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_KMPrice_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_KMCompanyName_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_KMForm_Edit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gcPromotion;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPromotion;
        private DevExpress.XtraEditors.SimpleButton btnGetData;
        private DevExpress.XtraEditors.CheckEdit chkAllCom;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit cboCompany;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit dateEnd;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dateBegin;
        private DevExpress.XtraEditors.CheckEdit chkCerruntDate;
        private DevExpress.XtraGrid.Columns.GridColumn col_KMID;
        private DevExpress.XtraGrid.Columns.GridColumn col_KMCompanyName;
        private DevExpress.XtraGrid.Columns.GridColumn col_KMProductName;
        private DevExpress.XtraGrid.Columns.GridColumn col_KMForm;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit col_KMCompanyName_Edit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit col_KMProductName_Edit;
        private DevExpress.XtraGrid.Columns.GridColumn col_KMPercent;
        private DevExpress.XtraGrid.Columns.GridColumn col_KMBegin;
        private DevExpress.XtraGrid.Columns.GridColumn col_KMEndDate;
        private DevExpress.XtraGrid.Columns.GridColumn col_KMNote;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox col_KMForm_Edit;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit col_KMPercent_Edit;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit col_KMBegin_Edit;
        private DevExpress.XtraGrid.Columns.GridColumn buy_product;
        private DevExpress.XtraGrid.Columns.GridColumn number_promotion;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repositoryItemCalcEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn col_KMPrice;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox col_KMPrice_Edit;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox col_KMForm_Edit1;
        private DevExpress.XtraEditors.SimpleButton btnAddEditPromotion;
    }
}
