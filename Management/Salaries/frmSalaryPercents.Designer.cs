namespace Management.Salaries
{
    partial class frmSalaryPercents
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalaryPercents));
            this.label1 = new System.Windows.Forms.Label();
            this.gcSalaryPercent = new DevExpress.XtraGrid.GridControl();
            this.gvSalaryPercent = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSalPer_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalPer_EmpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalPer_CompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalPer_ProName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalPer_Percents = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalPEr_Note = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalPEr_Note_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.col_Price = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalPer_Percents_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnCopy = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboTarget = new DevExpress.XtraEditors.LookUpEdit();
            this.cboSource = new DevExpress.XtraEditors.LookUpEdit();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.btnUpdateFast = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gcSalaryPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSalaryPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colSalPEr_Note_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colSalPer_Percents_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTarget.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSource.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(792, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "PHẦN TRĂM TÍNH LƯƠNG THEO SẢN PHẨM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gcSalaryPercent
            // 
            this.gcSalaryPercent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSalaryPercent.Location = new System.Drawing.Point(232, 40);
            this.gcSalaryPercent.MainView = this.gvSalaryPercent;
            this.gcSalaryPercent.Name = "gcSalaryPercent";
            this.gcSalaryPercent.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.colSalPer_Percents_Edit,
            this.colSalPEr_Note_Edit});
            this.gcSalaryPercent.Size = new System.Drawing.Size(560, 526);
            this.gcSalaryPercent.TabIndex = 2;
            this.gcSalaryPercent.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSalaryPercent});
            this.gcSalaryPercent.Click += new System.EventHandler(this.gcSalaryPercent_Click);
            // 
            // gvSalaryPercent
            // 
            this.gvSalaryPercent.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSalPer_ID,
            this.colSalPer_EmpName,
            this.colSalPer_CompanyName,
            this.colSalPer_ProName,
            this.colSalPer_Percents,
            this.colSalPEr_Note,
            this.col_Price});
            this.gvSalaryPercent.GridControl = this.gcSalaryPercent;
            this.gvSalaryPercent.GroupCount = 2;
            this.gvSalaryPercent.Name = "gvSalaryPercent";
            this.gvSalaryPercent.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvSalaryPercent.OptionsView.ColumnAutoWidth = false;
            this.gvSalaryPercent.OptionsView.EnableAppearanceOddRow = true;
            this.gvSalaryPercent.OptionsView.ShowAutoFilterRow = true;
            this.gvSalaryPercent.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colSalPer_EmpName, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colSalPer_CompanyName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvSalaryPercent.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gvSalaryPercent_InvalidRowException);
            this.gvSalaryPercent.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvSalaryPercent_ValidateRow);
            // 
            // colSalPer_ID
            // 
            this.colSalPer_ID.Caption = "Mã Số";
            this.colSalPer_ID.FieldName = "SalaryPercent_ID";
            this.colSalPer_ID.Name = "colSalPer_ID";
            this.colSalPer_ID.OptionsColumn.AllowEdit = false;
            this.colSalPer_ID.OptionsColumn.AllowFocus = false;
            // 
            // colSalPer_EmpName
            // 
            this.colSalPer_EmpName.Caption = "Tên Nhân Viên";
            this.colSalPer_EmpName.FieldName = "EmpName";
            this.colSalPer_EmpName.Name = "colSalPer_EmpName";
            this.colSalPer_EmpName.OptionsColumn.AllowEdit = false;
            this.colSalPer_EmpName.OptionsColumn.AllowFocus = false;
            this.colSalPer_EmpName.Width = 131;
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
            this.colSalPer_Percents.Caption = "Phẩn Trăm";
            this.colSalPer_Percents.DisplayFormat.FormatString = "n0";
            this.colSalPer_Percents.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSalPer_Percents.FieldName = "Percents";
            this.colSalPer_Percents.Name = "colSalPer_Percents";
            this.colSalPer_Percents.Visible = true;
            this.colSalPer_Percents.VisibleIndex = 1;
            this.colSalPer_Percents.Width = 79;
            // 
            // colSalPEr_Note
            // 
            this.colSalPEr_Note.Caption = "Ghi Chú";
            this.colSalPEr_Note.ColumnEdit = this.colSalPEr_Note_Edit;
            this.colSalPEr_Note.FieldName = "Note";
            this.colSalPEr_Note.Name = "colSalPEr_Note";
            this.colSalPEr_Note.Visible = true;
            this.colSalPEr_Note.VisibleIndex = 3;
            this.colSalPEr_Note.Width = 294;
            // 
            // colSalPEr_Note_Edit
            // 
            this.colSalPEr_Note_Edit.AutoHeight = false;
            this.colSalPEr_Note_Edit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colSalPEr_Note_Edit.Name = "colSalPEr_Note_Edit";
            // 
            // col_Price
            // 
            this.col_Price.Caption = "Đơn Giá";
            this.col_Price.DisplayFormat.FormatString = "n0";
            this.col_Price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Price.FieldName = "Price";
            this.col_Price.Name = "col_Price";
            this.col_Price.OptionsColumn.AllowEdit = false;
            this.col_Price.OptionsColumn.AllowFocus = false;
            this.col_Price.Visible = true;
            this.col_Price.VisibleIndex = 2;
            // 
            // colSalPer_Percents_Edit
            // 
            this.colSalPer_Percents_Edit.AutoHeight = false;
            this.colSalPer_Percents_Edit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.colSalPer_Percents_Edit.HideSelection = false;
            this.colSalPer_Percents_Edit.Name = "colSalPer_Percents_Edit";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnUpdateFast);
            this.groupControl1.Controls.Add(this.btnCopy);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.cboTarget);
            this.groupControl1.Controls.Add(this.cboSource);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 40);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(227, 526);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Sao Chép % Tính Lương";
            // 
            // btnCopy
            // 
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.Location = new System.Drawing.Point(44, 90);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(133, 23);
            this.btnCopy.TabIndex = 6;
            this.btnCopy.Text = "Sao Chép (1) Qua (2)";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(6, 63);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 13);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "Nhân Viên";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(6, 37);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Nhân Viên";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(202, 63);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(14, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "(2)";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(201, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(14, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "(1)";
            // 
            // cboTarget
            // 
            this.cboTarget.Location = new System.Drawing.Point(70, 59);
            this.cboTarget.Name = "cboTarget";
            this.cboTarget.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTarget.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmpName", "Tên NV"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Address", "Địa Chỉ")});
            this.cboTarget.Properties.NullText = "CHỌN NHÂN VIÊN";
            this.cboTarget.Size = new System.Drawing.Size(125, 20);
            this.cboTarget.TabIndex = 1;
            // 
            // cboSource
            // 
            this.cboSource.Location = new System.Drawing.Point(71, 33);
            this.cboSource.Name = "cboSource";
            this.cboSource.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSource.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmpName", "Tên NV")});
            this.cboSource.Properties.NullText = "CHỌN NHÂN VIÊN";
            this.cboSource.Size = new System.Drawing.Size(125, 20);
            this.cboSource.TabIndex = 0;
            this.cboSource.EditValueChanged += new System.EventHandler(this.cboSource_EditValueChanged);
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(227, 40);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 526);
            this.splitterControl1.TabIndex = 4;
            this.splitterControl1.TabStop = false;
            // 
            // btnUpdateFast
            // 
            this.btnUpdateFast.Location = new System.Drawing.Point(44, 120);
            this.btnUpdateFast.Name = "btnUpdateFast";
            this.btnUpdateFast.Size = new System.Drawing.Size(133, 33);
            this.btnUpdateFast.TabIndex = 7;
            this.btnUpdateFast.Text = "Cập Nhật Nhanh";
            this.btnUpdateFast.UseVisualStyleBackColor = true;
            this.btnUpdateFast.Click += new System.EventHandler(this.btnUpdateFast_Click);
            // 
            // frmSalaryPercents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.gcSalaryPercent);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmSalaryPercents";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PHAN TRAM TINH LUONG";
            this.Load += new System.EventHandler(this.frmSalaryPercents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcSalaryPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSalaryPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colSalPEr_Note_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colSalPer_Percents_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTarget.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSource.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl gcSalaryPercent;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSalaryPercent;
        private DevExpress.XtraGrid.Columns.GridColumn colSalPer_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colSalPer_EmpName;
        private DevExpress.XtraGrid.Columns.GridColumn colSalPer_CompanyName;
        private DevExpress.XtraGrid.Columns.GridColumn colSalPer_ProName;
        private DevExpress.XtraGrid.Columns.GridColumn colSalPer_Percents;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit colSalPer_Percents_Edit;
        private DevExpress.XtraGrid.Columns.GridColumn colSalPEr_Note;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit colSalPEr_Note_Edit;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.LookUpEdit cboTarget;
        private DevExpress.XtraEditors.LookUpEdit cboSource;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnCopy;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraGrid.Columns.GridColumn col_Price;
        private System.Windows.Forms.Button btnUpdateFast;

    }
}