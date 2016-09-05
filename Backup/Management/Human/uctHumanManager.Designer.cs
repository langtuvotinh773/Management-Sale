namespace Management.Human
{
    partial class uctHumanManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uctHumanManager));
            this.gcHuman = new DevExpress.XtraGrid.GridControl();
            this.gvHuman = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_EmpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_EmpName_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.col_Address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PeoleID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PeoleID_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.col_Phone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_EntryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_EntryDate_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.col_EmpID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_empStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_EmpSalary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSalaryPercents = new DevExpress.XtraEditors.SimpleButton();
            this.btnSalary = new DevExpress.XtraEditors.SimpleButton();
            this.btnGetData = new DevExpress.XtraEditors.SimpleButton();
            this.radOption = new DevExpress.XtraEditors.RadioGroup();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcHuman)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHuman)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_EmpName_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_PeoleID_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_EntryDate_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_EntryDate_Edit.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radOption.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcHuman
            // 
            this.gcHuman.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcHuman.Location = new System.Drawing.Point(0, 37);
            this.gcHuman.MainView = this.gvHuman;
            this.gcHuman.Name = "gcHuman";
            this.gcHuman.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.col_EmpName_Edit,
            this.col_PeoleID_Edit,
            this.col_EntryDate_Edit});
            this.gcHuman.Size = new System.Drawing.Size(800, 563);
            this.gcHuman.TabIndex = 0;
            this.gcHuman.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvHuman});
            this.gcHuman.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gcHuman_ProcessGridKey);
            this.gcHuman.Click += new System.EventHandler(this.gcHuman_Click);
            // 
            // gvHuman
            // 
            this.gvHuman.Appearance.TopNewRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gvHuman.Appearance.TopNewRow.Options.UseForeColor = true;
            this.gvHuman.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_EmpName,
            this.col_Address,
            this.col_PeoleID,
            this.col_Phone,
            this.col_EntryDate,
            this.col_EmpID,
            this.col_empStatus,
            this.col_EmpSalary});
            this.gvHuman.GridControl = this.gcHuman;
            this.gvHuman.Name = "gvHuman";
            this.gvHuman.NewItemRowText = "Nhập Nhân Viên Mới Tại Đây";
            this.gvHuman.OptionsPrint.UsePrintStyles = true;
            this.gvHuman.OptionsView.ColumnAutoWidth = false;
            this.gvHuman.OptionsView.EnableAppearanceOddRow = true;
            this.gvHuman.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gvHuman.OptionsView.ShowAutoFilterRow = true;
            this.gvHuman.OptionsView.ShowFooter = true;
            this.gvHuman.OptionsView.ShowGroupPanel = false;
            this.gvHuman.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gvHuman_InitNewRow);
            this.gvHuman.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gvHuman_InvalidRowException);
            this.gvHuman.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvHuman_ValidateRow);
            // 
            // col_EmpName
            // 
            this.col_EmpName.Caption = "Tên Nhân Viên";
            this.col_EmpName.ColumnEdit = this.col_EmpName_Edit;
            this.col_EmpName.DisplayFormat.FormatString = "{0:c0}";
            this.col_EmpName.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_EmpName.FieldName = "EmpName";
            this.col_EmpName.Name = "col_EmpName";
            this.col_EmpName.Visible = true;
            this.col_EmpName.VisibleIndex = 0;
            this.col_EmpName.Width = 144;
            // 
            // col_EmpName_Edit
            // 
            this.col_EmpName_Edit.AutoHeight = false;
            this.col_EmpName_Edit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.col_EmpName_Edit.Name = "col_EmpName_Edit";
            // 
            // col_Address
            // 
            this.col_Address.Caption = "Địa Chỉ";
            this.col_Address.ColumnEdit = this.col_EmpName_Edit;
            this.col_Address.FieldName = "Address";
            this.col_Address.Name = "col_Address";
            this.col_Address.Visible = true;
            this.col_Address.VisibleIndex = 1;
            this.col_Address.Width = 175;
            // 
            // col_PeoleID
            // 
            this.col_PeoleID.Caption = "CMND";
            this.col_PeoleID.ColumnEdit = this.col_PeoleID_Edit;
            this.col_PeoleID.FieldName = "PeopleID";
            this.col_PeoleID.Name = "col_PeoleID";
            this.col_PeoleID.Visible = true;
            this.col_PeoleID.VisibleIndex = 2;
            this.col_PeoleID.Width = 115;
            // 
            // col_PeoleID_Edit
            // 
            this.col_PeoleID_Edit.AutoHeight = false;
            this.col_PeoleID_Edit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.col_PeoleID_Edit.Name = "col_PeoleID_Edit";
            // 
            // col_Phone
            // 
            this.col_Phone.Caption = "SĐT";
            this.col_Phone.ColumnEdit = this.col_PeoleID_Edit;
            this.col_Phone.FieldName = "Phone";
            this.col_Phone.Name = "col_Phone";
            this.col_Phone.Visible = true;
            this.col_Phone.VisibleIndex = 3;
            this.col_Phone.Width = 131;
            // 
            // col_EntryDate
            // 
            this.col_EntryDate.Caption = "Ngày Vào";
            this.col_EntryDate.ColumnEdit = this.col_EntryDate_Edit;
            this.col_EntryDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.col_EntryDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_EntryDate.FieldName = "EntryDate";
            this.col_EntryDate.Name = "col_EntryDate";
            this.col_EntryDate.OptionsFilter.AllowFilter = false;
            this.col_EntryDate.Visible = true;
            this.col_EntryDate.VisibleIndex = 4;
            // 
            // col_EntryDate_Edit
            // 
            this.col_EntryDate_Edit.AutoHeight = false;
            this.col_EntryDate_Edit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.col_EntryDate_Edit.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.col_EntryDate_Edit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_EntryDate_Edit.EditFormat.FormatString = "dd/MM/yyyy";
            this.col_EntryDate_Edit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_EntryDate_Edit.Mask.EditMask = "dd/MM/yyyy";
            this.col_EntryDate_Edit.Name = "col_EntryDate_Edit";
            this.col_EntryDate_Edit.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // col_EmpID
            // 
            this.col_EmpID.Caption = "EmpID";
            this.col_EmpID.FieldName = "Emp_ID";
            this.col_EmpID.Name = "col_EmpID";
            this.col_EmpID.OptionsColumn.AllowEdit = false;
            this.col_EmpID.OptionsColumn.AllowFocus = false;
            // 
            // col_empStatus
            // 
            this.col_empStatus.Caption = "Trạng Thái";
            this.col_empStatus.FieldName = "Status";
            this.col_empStatus.Name = "col_empStatus";
            this.col_empStatus.Visible = true;
            this.col_empStatus.VisibleIndex = 5;
            // 
            // col_EmpSalary
            // 
            this.col_EmpSalary.Caption = "Tổng Lương";
            this.col_EmpSalary.DisplayFormat.FormatString = "{0:c0}";
            this.col_EmpSalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_EmpSalary.FieldName = "TotalSalary";
            this.col_EmpSalary.Name = "col_EmpSalary";
            this.col_EmpSalary.OptionsColumn.AllowEdit = false;
            this.col_EmpSalary.OptionsColumn.AllowFocus = false;
            this.col_EmpSalary.SummaryItem.DisplayFormat = "{0:c0}";
            this.col_EmpSalary.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col_EmpSalary.Visible = true;
            this.col_EmpSalary.VisibleIndex = 6;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnImport);
            this.panelControl1.Controls.Add(this.btnSalaryPercents);
            this.panelControl1.Controls.Add(this.btnSalary);
            this.panelControl1.Controls.Add(this.btnGetData);
            this.panelControl1.Controls.Add(this.radOption);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(800, 37);
            this.panelControl1.TabIndex = 1;
            // 
            // btnSalaryPercents
            // 
            this.btnSalaryPercents.Image = ((System.Drawing.Image)(resources.GetObject("btnSalaryPercents.Image")));
            this.btnSalaryPercents.Location = new System.Drawing.Point(494, 6);
            this.btnSalaryPercents.Name = "btnSalaryPercents";
            this.btnSalaryPercents.Size = new System.Drawing.Size(143, 26);
            this.btnSalaryPercents.TabIndex = 3;
            this.btnSalaryPercents.Text = "Phần Trăm Tính Lương";
            this.btnSalaryPercents.Click += new System.EventHandler(this.btnSalaryPercents_Click);
            // 
            // btnSalary
            // 
            this.btnSalary.Image = ((System.Drawing.Image)(resources.GetObject("btnSalary.Image")));
            this.btnSalary.Location = new System.Drawing.Point(398, 6);
            this.btnSalary.Name = "btnSalary";
            this.btnSalary.Size = new System.Drawing.Size(90, 26);
            this.btnSalary.TabIndex = 2;
            this.btnSalary.Text = "Xuất Lương";
            this.btnSalary.Click += new System.EventHandler(this.btnSalary_Click);
            // 
            // btnGetData
            // 
            this.btnGetData.Image = ((System.Drawing.Image)(resources.GetObject("btnGetData.Image")));
            this.btnGetData.Location = new System.Drawing.Point(293, 6);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(99, 26);
            this.btnGetData.TabIndex = 1;
            this.btnGetData.Text = "Lấy Dữ Liệu";
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // radOption
            // 
            this.radOption.EditValue = 0F;
            this.radOption.Location = new System.Drawing.Point(11, 5);
            this.radOption.Name = "radOption";
            this.radOption.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radOption.Properties.Appearance.Options.UseBackColor = true;
            this.radOption.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radOption.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0F, "Đang Làm Việc"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1F, "Đã Nghỉ"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2F, "Tất Cả")});
            this.radOption.Size = new System.Drawing.Size(313, 28);
            this.radOption.TabIndex = 0;
            // 
            // btnImport
            // 
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.Location = new System.Drawing.Point(655, 6);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(131, 26);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "Import % Tính Lương";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // uctHumanManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcHuman);
            this.Controls.Add(this.panelControl1);
            this.Name = "uctHumanManager";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.uctHumanManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcHuman)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHuman)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_EmpName_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_PeoleID_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_EntryDate_Edit.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_EntryDate_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radOption.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcHuman;
        private DevExpress.XtraGrid.Views.Grid.GridView gvHuman;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmpName;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit col_EmpName_Edit;
        private DevExpress.XtraGrid.Columns.GridColumn col_Address;
        private DevExpress.XtraGrid.Columns.GridColumn col_PeoleID;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit col_PeoleID_Edit;
        private DevExpress.XtraGrid.Columns.GridColumn col_Phone;
        private DevExpress.XtraGrid.Columns.GridColumn col_EntryDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit col_EntryDate_Edit;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmpID;
        private DevExpress.XtraGrid.Columns.GridColumn col_empStatus;
        private DevExpress.XtraGrid.Columns.GridColumn col_EmpSalary;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnGetData;
        private DevExpress.XtraEditors.RadioGroup radOption;
        private DevExpress.XtraEditors.SimpleButton btnSalary;
        private DevExpress.XtraEditors.SimpleButton btnSalaryPercents;
        private DevExpress.XtraEditors.SimpleButton btnImport;
    }
}
