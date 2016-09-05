namespace Management.Human
{
    partial class uctExportSalary
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSort = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lbToDate = new DevExpress.XtraEditors.LabelControl();
            this.cbAllEmployee = new DevExpress.XtraEditors.CheckEdit();
            this.cboEmp = new DevExpress.XtraEditors.LookUpEdit();
            this.fromDate = new DevExpress.XtraEditors.DateEdit();
            this.toDate = new DevExpress.XtraEditors.DateEdit();
            this.gcShowInformation = new DevExpress.XtraGrid.GridControl();
            this.gvShowInformation = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EmpName_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colToDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMoney = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbAllEmployee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcShowInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvShowInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpName_Edit)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnSort);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.lbToDate);
            this.panelControl1.Controls.Add(this.cbAllEmployee);
            this.panelControl1.Controls.Add(this.cboEmp);
            this.panelControl1.Controls.Add(this.fromDate);
            this.panelControl1.Controls.Add(this.toDate);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(800, 35);
            this.panelControl1.TabIndex = 1;
            this.panelControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl1_Paint);
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(708, 5);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(75, 23);
            this.btnSort.TabIndex = 7;
            this.btnSort.Text = "Lấy Dữ Liệu";
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(355, 10);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(76, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Chọn Nhân Viên";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(176, 10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Đến Ngày";
            // 
            // lbToDate
            // 
            this.lbToDate.Location = new System.Drawing.Point(10, 10);
            this.lbToDate.Name = "lbToDate";
            this.lbToDate.Size = new System.Drawing.Size(41, 13);
            this.lbToDate.TabIndex = 4;
            this.lbToDate.Text = "Từ Ngày";
            // 
            // cbAllEmployee
            // 
            this.cbAllEmployee.Location = new System.Drawing.Point(618, 7);
            this.cbAllEmployee.Name = "cbAllEmployee";
            this.cbAllEmployee.Properties.Caption = "Chọn tất cả";
            this.cbAllEmployee.Size = new System.Drawing.Size(84, 19);
            this.cbAllEmployee.TabIndex = 3;
            this.cbAllEmployee.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // cboEmp
            // 
            this.cboEmp.Location = new System.Drawing.Point(435, 6);
            this.cboEmp.Name = "cboEmp";
            this.cboEmp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEmp.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmpName", "TÊN NHÂN VIÊN"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Address", "ĐỊA CHỈ")});
            this.cboEmp.Properties.NullText = "CHỌN NHÂN VIÊN";
            this.cboEmp.Size = new System.Drawing.Size(177, 20);
            this.cboEmp.TabIndex = 2;
            // 
            // fromDate
            // 
            this.fromDate.EditValue = null;
            this.fromDate.Location = new System.Drawing.Point(226, 6);
            this.fromDate.Name = "fromDate";
            this.fromDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.fromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.fromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.fromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fromDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.fromDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.fromDate.Size = new System.Drawing.Size(100, 20);
            this.fromDate.TabIndex = 1;
            // 
            // toDate
            // 
            this.toDate.EditValue = null;
            this.toDate.Location = new System.Drawing.Point(57, 6);
            this.toDate.Name = "toDate";
            this.toDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.toDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.toDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.toDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.toDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.toDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.toDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.toDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.toDate.Size = new System.Drawing.Size(100, 20);
            this.toDate.TabIndex = 0;
            this.toDate.EditValueChanged += new System.EventHandler(this.toDate_EditValueChanged);
            // 
            // gcShowInformation
            // 
            this.gcShowInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcShowInformation.Location = new System.Drawing.Point(0, 35);
            this.gcShowInformation.MainView = this.gvShowInformation;
            this.gcShowInformation.Name = "gcShowInformation";
            this.gcShowInformation.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.EmpName_Edit});
            this.gcShowInformation.Size = new System.Drawing.Size(800, 565);
            this.gcShowInformation.TabIndex = 2;
            this.gcShowInformation.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvShowInformation});
            this.gcShowInformation.Click += new System.EventHandler(this.gcShowInformation_Click);
            // 
            // gvShowInformation
            // 
            this.gvShowInformation.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colToDate,
            this.colMoney,
            this.colNote});
            this.gvShowInformation.GridControl = this.gcShowInformation;
            this.gvShowInformation.GroupCount = 1;
            this.gvShowInformation.Name = "gvShowInformation";
            this.gvShowInformation.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvShowInformation.OptionsBehavior.Editable = false;
            this.gvShowInformation.OptionsView.ColumnAutoWidth = false;
            this.gvShowInformation.OptionsView.ShowFooter = true;
            this.gvShowInformation.OptionsView.ShowGroupPanel = false;
            this.gvShowInformation.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colName, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colName
            // 
            this.colName.Caption = "Tên Nhân Viên";
            this.colName.ColumnEdit = this.EmpName_Edit;
            this.colName.FieldName = "EmpName";
            this.colName.Name = "colName";
            // 
            // EmpName_Edit
            // 
            this.EmpName_Edit.AutoHeight = false;
            this.EmpName_Edit.Name = "EmpName_Edit";
            // 
            // colToDate
            // 
            this.colToDate.Caption = "Ngày Nhận Lương";
            this.colToDate.ColumnEdit = this.EmpName_Edit;
            this.colToDate.FieldName = "DateExport";
            this.colToDate.Name = "colToDate";
            this.colToDate.Visible = true;
            this.colToDate.VisibleIndex = 0;
            this.colToDate.Width = 162;
            // 
            // colMoney
            // 
            this.colMoney.Caption = "Số Tiền";
            this.colMoney.ColumnEdit = this.EmpName_Edit;
            this.colMoney.DisplayFormat.FormatString = "{0:c0}";
            this.colMoney.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMoney.FieldName = "Amount";
            this.colMoney.GroupFormat.FormatString = "{0:c0}";
            this.colMoney.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMoney.Name = "colMoney";
            this.colMoney.SummaryItem.DisplayFormat = "Tổng: {0:c0}";
            this.colMoney.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colMoney.Visible = true;
            this.colMoney.VisibleIndex = 1;
            this.colMoney.Width = 125;
            // 
            // colNote
            // 
            this.colNote.Caption = "Ghi Chú";
            this.colNote.ColumnEdit = this.EmpName_Edit;
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 2;
            this.colNote.Width = 195;
            // 
            // uctExportSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcShowInformation);
            this.Controls.Add(this.panelControl1);
            this.Name = "uctExportSalary";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.uctExportSalary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbAllEmployee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcShowInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvShowInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpName_Edit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckEdit cbAllEmployee;
        private DevExpress.XtraEditors.LookUpEdit cboEmp;
        private DevExpress.XtraEditors.DateEdit fromDate;
        private DevExpress.XtraEditors.DateEdit toDate;
        private DevExpress.XtraGrid.GridControl gcShowInformation;
        private DevExpress.XtraGrid.Views.Grid.GridView gvShowInformation;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colToDate;
        private DevExpress.XtraGrid.Columns.GridColumn colMoney;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lbToDate;
        private DevExpress.XtraEditors.SimpleButton btnSort;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit EmpName_Edit;

    }
}
