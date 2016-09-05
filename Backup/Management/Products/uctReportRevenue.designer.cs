namespace Management.Human
{
    partial class uctReportRevenue
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
            this.cbAllEmployee = new DevExpress.XtraEditors.CheckEdit();
            this.cboEmp = new DevExpress.XtraEditors.LookUpEdit();
            this.fromDate = new DevExpress.XtraEditors.DateEdit();
            this.toDate = new DevExpress.XtraEditors.DateEdit();
            this.gcShowInformation = new DevExpress.XtraGrid.GridControl();
            this.gvShowInformation = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_TonKho = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_CompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_cast = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_totalMoneyImport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FormatNumber_Money = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.col_totalMoney_Order = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_totalTotalMoneySalary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Order_Import = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_totalProductImport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EmpName_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAllEmployee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcShowInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvShowInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormatNumber_Money)).BeginInit();
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
            this.panelControl1.Controls.Add(this.cbAllEmployee);
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
            this.cboCompany.Location = new System.Drawing.Point(398, 39);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCompany.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyName", "Tên Công Ty"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Address", "Địa Chỉ")});
            this.cboCompany.Properties.NullText = "Chọn Tên Công Ty";
            this.cboCompany.Size = new System.Drawing.Size(184, 20);
            this.cboCompany.TabIndex = 9;
            this.cboCompany.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(318, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(75, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Chọn Công Ty :";
            this.labelControl1.Visible = false;
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
            this.labelControl3.Visible = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(318, 15);
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
            // cbAllEmployee
            // 
            this.cbAllEmployee.Location = new System.Drawing.Point(618, 7);
            this.cbAllEmployee.Name = "cbAllEmployee";
            this.cbAllEmployee.Properties.Caption = "Chọn tất cả";
            this.cbAllEmployee.Size = new System.Drawing.Size(84, 19);
            this.cbAllEmployee.TabIndex = 3;
            this.cbAllEmployee.Visible = false;
            this.cbAllEmployee.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
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
            this.cboEmp.Visible = false;
            // 
            // fromDate
            // 
            this.fromDate.EditValue = null;
            this.fromDate.Location = new System.Drawing.Point(398, 12);
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
            this.EmpName_Edit,
            this.FormatNumber_Money});
            this.gcShowInformation.Size = new System.Drawing.Size(800, 530);
            this.gcShowInformation.TabIndex = 2;
            this.gcShowInformation.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvShowInformation});
            this.gcShowInformation.Click += new System.EventHandler(this.gcShowInformation_Click);
            // 
            // gvShowInformation
            // 
            this.gvShowInformation.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_TonKho,
            this.col_CompanyName,
            this.col_cast,
            this.col_totalMoneyImport,
            this.col_totalMoney_Order,
            this.col_totalTotalMoneySalary,
            this.col_Order_Import,
            this.col_totalProductImport});
            this.gvShowInformation.GridControl = this.gcShowInformation;
            this.gvShowInformation.Name = "gvShowInformation";
            this.gvShowInformation.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvShowInformation.OptionsBehavior.Editable = false;
            this.gvShowInformation.OptionsView.ColumnAutoWidth = false;
            this.gvShowInformation.OptionsView.ShowFooter = true;
            // 
            // col_TonKho
            // 
            this.col_TonKho.Caption = "Tiền Trong Kho";
            this.col_TonKho.DisplayFormat.FormatString = "{0:c0}";
            this.col_TonKho.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_TonKho.FieldName = "TotalHangTonKho";
            this.col_TonKho.Name = "col_TonKho";
            this.col_TonKho.SummaryItem.DisplayFormat = "{0:n0}";
            this.col_TonKho.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col_TonKho.Visible = true;
            this.col_TonKho.VisibleIndex = 4;
            this.col_TonKho.Width = 87;
            // 
            // col_CompanyName
            // 
            this.col_CompanyName.Caption = "Công Ty";
            this.col_CompanyName.FieldName = "CompanyName";
            this.col_CompanyName.Name = "col_CompanyName";
            this.col_CompanyName.Visible = true;
            this.col_CompanyName.VisibleIndex = 0;
            this.col_CompanyName.Width = 220;
            // 
            // col_cast
            // 
            this.col_cast.Caption = "Tổng Tiền Được Tặng";
            this.col_cast.DisplayFormat.FormatString = "n0";
            this.col_cast.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_cast.FieldName = "totalCastPromotion";
            this.col_cast.Name = "col_cast";
            this.col_cast.SummaryItem.DisplayFormat = "{0:n0}";
            this.col_cast.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col_cast.Visible = true;
            this.col_cast.VisibleIndex = 1;
            this.col_cast.Width = 113;
            // 
            // col_totalMoneyImport
            // 
            this.col_totalMoneyImport.Caption = "Tổng Tiền Đã Nhập Hàng";
            this.col_totalMoneyImport.ColumnEdit = this.FormatNumber_Money;
            this.col_totalMoneyImport.FieldName = "totalTotalMoney_Import";
            this.col_totalMoneyImport.Name = "col_totalMoneyImport";
            this.col_totalMoneyImport.SummaryItem.DisplayFormat = " {0:n0}";
            this.col_totalMoneyImport.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col_totalMoneyImport.Visible = true;
            this.col_totalMoneyImport.VisibleIndex = 2;
            this.col_totalMoneyImport.Width = 128;
            // 
            // FormatNumber_Money
            // 
            this.FormatNumber_Money.AutoHeight = false;
            this.FormatNumber_Money.Mask.EditMask = "c0";
            this.FormatNumber_Money.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.FormatNumber_Money.Name = "FormatNumber_Money";
            // 
            // col_totalMoney_Order
            // 
            this.col_totalMoney_Order.Caption = "Tổng Tiền Đã Xuất Hàng";
            this.col_totalMoney_Order.DisplayFormat.FormatString = "###,###.00";
            this.col_totalMoney_Order.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_totalMoney_Order.FieldName = "totalTotalMoney_Order";
            this.col_totalMoney_Order.Name = "col_totalMoney_Order";
            this.col_totalMoney_Order.SummaryItem.DisplayFormat = "{0:n0}";
            this.col_totalMoney_Order.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col_totalMoney_Order.Visible = true;
            this.col_totalMoney_Order.VisibleIndex = 5;
            this.col_totalMoney_Order.Width = 134;
            // 
            // col_totalTotalMoneySalary
            // 
            this.col_totalTotalMoneySalary.Caption = "Tiền Trả Cho NV";
            this.col_totalTotalMoneySalary.DisplayFormat.FormatString = "{0:n0}";
            this.col_totalTotalMoneySalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_totalTotalMoneySalary.FieldName = "totalTotalMoney_Salary";
            this.col_totalTotalMoneySalary.Name = "col_totalTotalMoneySalary";
            this.col_totalTotalMoneySalary.SummaryItem.DisplayFormat = " {0:n0}";
            this.col_totalTotalMoneySalary.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col_totalTotalMoneySalary.Visible = true;
            this.col_totalTotalMoneySalary.VisibleIndex = 6;
            this.col_totalTotalMoneySalary.Width = 93;
            // 
            // col_Order_Import
            // 
            this.col_Order_Import.Caption = "Tiền Nhập Hàng Cho HĐ Xuất";
            this.col_Order_Import.FieldName = "TotalOrder_Import";
            this.col_Order_Import.Name = "col_Order_Import";
            this.col_Order_Import.SummaryItem.DisplayFormat = "{0:n0}";
            this.col_Order_Import.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col_Order_Import.Visible = true;
            this.col_Order_Import.VisibleIndex = 3;
            this.col_Order_Import.Width = 148;
            // 
            // col_totalProductImport
            // 
            this.col_totalProductImport.Caption = "Tổng Tiền Lời Còn Lại";
            this.col_totalProductImport.DisplayFormat.FormatString = "{0:n0}";
            this.col_totalProductImport.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_totalProductImport.FieldName = "totalTienNhapHang";
            this.col_totalProductImport.Name = "col_totalProductImport";
            this.col_totalProductImport.SummaryItem.DisplayFormat = "Tiền lời : {0:n0}";
            this.col_totalProductImport.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col_totalProductImport.Visible = true;
            this.col_totalProductImport.VisibleIndex = 7;
            this.col_totalProductImport.Width = 113;
            // 
            // EmpName_Edit
            // 
            this.EmpName_Edit.AutoHeight = false;
            this.EmpName_Edit.Name = "EmpName_Edit";
            // 
            // uctReportRevenue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcShowInformation);
            this.Controls.Add(this.panelControl1);
            this.Name = "uctReportRevenue";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.uctReportRevenue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAllEmployee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcShowInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvShowInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormatNumber_Money)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn col_CompanyName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lbToDate;
        private DevExpress.XtraEditors.SimpleButton btnSort;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit EmpName_Edit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit cboCompany;
        private DevExpress.XtraGrid.Columns.GridColumn col_cast;
        private DevExpress.XtraGrid.Columns.GridColumn col_totalMoneyImport;
        private DevExpress.XtraGrid.Columns.GridColumn col_totalMoney_Order;
        private DevExpress.XtraGrid.Columns.GridColumn col_totalTotalMoneySalary;
        private DevExpress.XtraGrid.Columns.GridColumn col_totalProductImport;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit FormatNumber_Money;
        private DevExpress.XtraGrid.Columns.GridColumn col_TonKho;
        private DevExpress.XtraGrid.Columns.GridColumn col_Order_Import;

    }
}
