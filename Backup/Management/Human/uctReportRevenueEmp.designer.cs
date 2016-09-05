namespace Management.Human
{
    partial class uctReportRevenueEmp
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
            this.cboCompany = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnSort = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lbToDate = new DevExpress.XtraEditors.LabelControl();
            this.cbAllCust = new DevExpress.XtraEditors.CheckEdit();
            this.cboEmp = new DevExpress.XtraEditors.LookUpEdit();
            this.fromDate = new DevExpress.XtraEditors.DateEdit();
            this.toDate = new DevExpress.XtraEditors.DateEdit();
            this.gcShowInformation = new DevExpress.XtraGrid.GridControl();
            this.gvShowInformation = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_CustName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_empName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_totalMoneyOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_totalMoney_Order = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TotalSalaryEmp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EmpName_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAllCust.Properties)).BeginInit();
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
            this.panelControl1.Controls.Add(this.cboCompany);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.btnSort);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.lbToDate);
            this.panelControl1.Controls.Add(this.cbAllCust);
            this.panelControl1.Controls.Add(this.cboEmp);
            this.panelControl1.Controls.Add(this.fromDate);
            this.panelControl1.Controls.Add(this.toDate);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(800, 70);
            this.panelControl1.TabIndex = 1;
            this.panelControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl1_Paint);
            // 
            // cboCompany
            // 
            this.cboCompany.Location = new System.Drawing.Point(441, 39);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCompany.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustName", "Tên Khách Hàng"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Address", "Địa Chỉ")});
            this.cboCompany.Properties.NullText = "Chọn Tên Khách Hàng";
            this.cboCompany.Size = new System.Drawing.Size(184, 20);
            this.cboCompany.TabIndex = 9;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(343, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(92, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Chọn Khách Hàng :";
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
            this.labelControl3.Location = new System.Drawing.Point(10, 42);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(83, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Chọn Nhân Viên :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(343, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(55, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Đến Ngày :";
            // 
            // lbToDate
            // 
            this.lbToDate.Location = new System.Drawing.Point(10, 15);
            this.lbToDate.Name = "lbToDate";
            this.lbToDate.Size = new System.Drawing.Size(48, 13);
            this.lbToDate.TabIndex = 4;
            this.lbToDate.Text = "Từ Ngày :";
            // 
            // cbAllCust
            // 
            this.cbAllCust.Location = new System.Drawing.Point(631, 40);
            this.cbAllCust.Name = "cbAllCust";
            this.cbAllCust.Properties.Caption = "Chọn tất cả";
            this.cbAllCust.Size = new System.Drawing.Size(84, 19);
            this.cbAllCust.TabIndex = 3;
            this.cbAllCust.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // cboEmp
            // 
            this.cboEmp.Location = new System.Drawing.Point(104, 39);
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
            this.fromDate.Location = new System.Drawing.Point(441, 12);
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
            this.fromDate.Size = new System.Drawing.Size(184, 20);
            this.fromDate.TabIndex = 1;
            // 
            // toDate
            // 
            this.toDate.EditValue = null;
            this.toDate.Location = new System.Drawing.Point(104, 12);
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
            this.toDate.Size = new System.Drawing.Size(177, 20);
            this.toDate.TabIndex = 0;
            this.toDate.EditValueChanged += new System.EventHandler(this.toDate_EditValueChanged);
            // 
            // gcShowInformation
            // 
            this.gcShowInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcShowInformation.Location = new System.Drawing.Point(0, 70);
            this.gcShowInformation.MainView = this.gvShowInformation;
            this.gcShowInformation.Name = "gcShowInformation";
            this.gcShowInformation.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.EmpName_Edit});
            this.gcShowInformation.Size = new System.Drawing.Size(800, 530);
            this.gcShowInformation.TabIndex = 2;
            this.gcShowInformation.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvShowInformation});
            this.gcShowInformation.Click += new System.EventHandler(this.gcShowInformation_Click);
            // 
            // gvShowInformation
            // 
            this.gvShowInformation.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_CustName,
            this.col_empName,
            this.col_totalMoneyOrder,
            this.col_totalMoney_Order,
            this.col_TotalSalaryEmp});
            this.gvShowInformation.GridControl = this.gcShowInformation;
            this.gvShowInformation.GroupCount = 1;
            this.gvShowInformation.Name = "gvShowInformation";
            this.gvShowInformation.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvShowInformation.OptionsBehavior.Editable = false;
            this.gvShowInformation.OptionsView.ColumnAutoWidth = false;
            this.gvShowInformation.OptionsView.ShowFooter = true;
            this.gvShowInformation.OptionsView.ShowGroupPanel = false;
            this.gvShowInformation.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.col_empName, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // col_CustName
            // 
            this.col_CustName.Caption = "Tên Khách Hàng";
            this.col_CustName.FieldName = "CustName";
            this.col_CustName.Name = "col_CustName";
            this.col_CustName.Visible = true;
            this.col_CustName.VisibleIndex = 0;
            this.col_CustName.Width = 284;
            // 
            // col_empName
            // 
            this.col_empName.Caption = "Tên Nhân Viên";
            this.col_empName.FieldName = "EmpName";
            this.col_empName.Name = "col_empName";
            this.col_empName.Width = 119;
            // 
            // col_totalMoneyOrder
            // 
            this.col_totalMoneyOrder.Caption = "Tổng Xuất Hàng";
            this.col_totalMoneyOrder.DisplayFormat.FormatString = "{0:n0}";
            this.col_totalMoneyOrder.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_totalMoneyOrder.FieldName = "TotalMoney_NotSalary";
            this.col_totalMoneyOrder.Name = "col_totalMoneyOrder";
            this.col_totalMoneyOrder.SummaryItem.DisplayFormat = "Tổng Xuất : {0:n0}";
            this.col_totalMoneyOrder.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col_totalMoneyOrder.Visible = true;
            this.col_totalMoneyOrder.VisibleIndex = 1;
            this.col_totalMoneyOrder.Width = 137;
            // 
            // col_totalMoney_Order
            // 
            this.col_totalMoney_Order.Caption = "Tổng Tiền Đã Tính Lương Cho NV";
            this.col_totalMoney_Order.DisplayFormat.FormatString = "{0:n0}";
            this.col_totalMoney_Order.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_totalMoney_Order.FieldName = "TotalMoney_Salary";
            this.col_totalMoney_Order.Name = "col_totalMoney_Order";
            this.col_totalMoney_Order.SummaryItem.DisplayFormat = "Tổng : {0:n0}";
            this.col_totalMoney_Order.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col_totalMoney_Order.Width = 170;
            // 
            // col_TotalSalaryEmp
            // 
            this.col_TotalSalaryEmp.Caption = "Tổng Tiền Trả Cho Nhân Viên";
            this.col_TotalSalaryEmp.DisplayFormat.FormatString = "{0:n0}";
            this.col_TotalSalaryEmp.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_TotalSalaryEmp.FieldName = "SalaryOfOrder";
            this.col_TotalSalaryEmp.Name = "col_TotalSalaryEmp";
            this.col_TotalSalaryEmp.SummaryItem.DisplayFormat = "Doanh thu : {0:n0}";
            this.col_TotalSalaryEmp.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col_TotalSalaryEmp.Visible = true;
            this.col_TotalSalaryEmp.VisibleIndex = 2;
            this.col_TotalSalaryEmp.Width = 160;
            // 
            // EmpName_Edit
            // 
            this.EmpName_Edit.AutoHeight = false;
            this.EmpName_Edit.Name = "EmpName_Edit";
            // 
            // uctReportRevenueEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcShowInformation);
            this.Controls.Add(this.panelControl1);
            this.Name = "uctReportRevenueEmp";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.uctReportRevenueEmp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAllCust.Properties)).EndInit();
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
        private DevExpress.XtraEditors.CheckEdit cbAllCust;
        private DevExpress.XtraEditors.LookUpEdit cboEmp;
        private DevExpress.XtraEditors.DateEdit fromDate;
        private DevExpress.XtraEditors.DateEdit toDate;
        private DevExpress.XtraGrid.GridControl gcShowInformation;
        private DevExpress.XtraGrid.Views.Grid.GridView gvShowInformation;
        private DevExpress.XtraGrid.Columns.GridColumn col_CustName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lbToDate;
        private DevExpress.XtraEditors.SimpleButton btnSort;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit EmpName_Edit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit cboCompany;
        private DevExpress.XtraGrid.Columns.GridColumn col_empName;
        private DevExpress.XtraGrid.Columns.GridColumn col_totalMoneyOrder;
        private DevExpress.XtraGrid.Columns.GridColumn col_totalMoney_Order;
        private DevExpress.XtraGrid.Columns.GridColumn col_TotalSalaryEmp;

    }
}
