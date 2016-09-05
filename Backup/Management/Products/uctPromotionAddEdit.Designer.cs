namespace Management.Products
{
    partial class uctPromotionAddEdit
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
            this.gcPromotion = new DevExpress.XtraGrid.GridControl();
            this.gvPromotion = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProduct_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalPer_CompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalPer_ProName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalPer_Percents = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalPEr_Note = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Price = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImportPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPromotion_Note_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colSalPer_Percents_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPromotion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPromotion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colPromotion_Note_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colSalPer_Percents_Edit)).BeginInit();
            this.SuspendLayout();
            // 
            // gcPromotion
            // 
            this.gcPromotion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPromotion.Location = new System.Drawing.Point(0, 0);
            this.gcPromotion.MainView = this.gvPromotion;
            this.gcPromotion.Name = "gcPromotion";
            this.gcPromotion.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.colSalPer_Percents_Edit,
            this.colPromotion_Note_Edit});
            this.gcPromotion.Size = new System.Drawing.Size(900, 504);
            this.gcPromotion.TabIndex = 3;
            this.gcPromotion.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPromotion});
            // 
            // gvPromotion
            // 
            this.gvPromotion.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProduct_ID,
            this.colSalPer_CompanyName,
            this.colSalPer_ProName,
            this.colSalPer_Percents,
            this.colSalPEr_Note,
            this.col_Price,
            this.colImportPrice,
            this.colNote});
            this.gvPromotion.GridControl = this.gcPromotion;
            this.gvPromotion.GroupCount = 1;
            this.gvPromotion.Name = "gvPromotion";
            this.gvPromotion.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvPromotion.OptionsView.ColumnAutoWidth = false;
            this.gvPromotion.OptionsView.EnableAppearanceOddRow = true;
            this.gvPromotion.OptionsView.ShowAutoFilterRow = true;
            this.gvPromotion.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colSalPer_CompanyName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvPromotion.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gvPromotion_InvalidRowException);
            this.gvPromotion.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvPromotion_ValidateRow);
            // 
            // colProduct_ID
            // 
            this.colProduct_ID.Caption = "Mã SP";
            this.colProduct_ID.FieldName = "Product_ID";
            this.colProduct_ID.Name = "colProduct_ID";
            this.colProduct_ID.OptionsColumn.AllowEdit = false;
            this.colProduct_ID.OptionsColumn.AllowFocus = false;
            // 
            // colSalPer_CompanyName
            // 
            this.colSalPer_CompanyName.Caption = "Tên Công Ty";
            this.colSalPer_CompanyName.FieldName = "CompanyName";
            this.colSalPer_CompanyName.Name = "colSalPer_CompanyName";
            this.colSalPer_CompanyName.OptionsColumn.AllowEdit = false;
            this.colSalPer_CompanyName.OptionsColumn.AllowFocus = false;
            this.colSalPer_CompanyName.Width = 110;
            // 
            // colSalPer_ProName
            // 
            this.colSalPer_ProName.Caption = "Tên Sản Phẩm";
            this.colSalPer_ProName.FieldName = "ProductName";
            this.colSalPer_ProName.Name = "colSalPer_ProName";
            this.colSalPer_ProName.OptionsColumn.AllowEdit = false;
            this.colSalPer_ProName.OptionsColumn.AllowFocus = false;
            this.colSalPer_ProName.Visible = true;
            this.colSalPer_ProName.VisibleIndex = 0;
            this.colSalPer_ProName.Width = 188;
            // 
            // colSalPer_Percents
            // 
            this.colSalPer_Percents.Caption = "Số Lượng Mua";
            this.colSalPer_Percents.DisplayFormat.FormatString = "n0";
            this.colSalPer_Percents.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSalPer_Percents.FieldName = "Number_buy";
            this.colSalPer_Percents.Name = "colSalPer_Percents";
            this.colSalPer_Percents.Visible = true;
            this.colSalPer_Percents.VisibleIndex = 3;
            this.colSalPer_Percents.Width = 84;
            // 
            // colSalPEr_Note
            // 
            this.colSalPEr_Note.Caption = "Số Lượng KM";
            this.colSalPEr_Note.DisplayFormat.FormatString = "n0";
            this.colSalPEr_Note.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSalPEr_Note.FieldName = "Number_Promotions";
            this.colSalPEr_Note.Name = "colSalPEr_Note";
            this.colSalPEr_Note.Visible = true;
            this.colSalPEr_Note.VisibleIndex = 4;
            this.colSalPEr_Note.Width = 83;
            // 
            // col_Price
            // 
            this.col_Price.Caption = "Giá Bán";
            this.col_Price.DisplayFormat.FormatString = "n0";
            this.col_Price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Price.FieldName = "Price";
            this.col_Price.Name = "col_Price";
            this.col_Price.OptionsColumn.AllowEdit = false;
            this.col_Price.OptionsColumn.AllowFocus = false;
            this.col_Price.Visible = true;
            this.col_Price.VisibleIndex = 2;
            this.col_Price.Width = 87;
            // 
            // colImportPrice
            // 
            this.colImportPrice.Caption = "Giá Nhập";
            this.colImportPrice.DisplayFormat.FormatString = "n0";
            this.colImportPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImportPrice.FieldName = "PriceActual_Import";
            this.colImportPrice.Name = "colImportPrice";
            this.colImportPrice.OptionsColumn.AllowEdit = false;
            this.colImportPrice.OptionsColumn.AllowFocus = false;
            this.colImportPrice.Visible = true;
            this.colImportPrice.VisibleIndex = 1;
            this.colImportPrice.Width = 83;
            // 
            // colNote
            // 
            this.colNote.Caption = "Mô tả";
            this.colNote.ColumnEdit = this.colPromotion_Note_Edit;
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 5;
            this.colNote.Width = 355;
            // 
            // colPromotion_Note_Edit
            // 
            this.colPromotion_Note_Edit.AutoHeight = false;
            this.colPromotion_Note_Edit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colPromotion_Note_Edit.Name = "colPromotion_Note_Edit";
            // 
            // colSalPer_Percents_Edit
            // 
            this.colSalPer_Percents_Edit.AutoHeight = false;
            this.colSalPer_Percents_Edit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.colSalPer_Percents_Edit.HideSelection = false;
            this.colSalPer_Percents_Edit.Name = "colSalPer_Percents_Edit";
            // 
            // uctPromotionAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcPromotion);
            this.Name = "uctPromotionAddEdit";
            this.Size = new System.Drawing.Size(900, 504);
            ((System.ComponentModel.ISupportInitialize)(this.gcPromotion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPromotion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colPromotion_Note_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colSalPer_Percents_Edit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcPromotion;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPromotion;
        private DevExpress.XtraGrid.Columns.GridColumn colProduct_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colSalPer_CompanyName;
        private DevExpress.XtraGrid.Columns.GridColumn colSalPer_ProName;
        private DevExpress.XtraGrid.Columns.GridColumn colSalPer_Percents;
        private DevExpress.XtraGrid.Columns.GridColumn colSalPEr_Note;
        private DevExpress.XtraGrid.Columns.GridColumn col_Price;
        private DevExpress.XtraGrid.Columns.GridColumn colImportPrice;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit colSalPer_Percents_Edit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit colPromotion_Note_Edit;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;

    }
}
