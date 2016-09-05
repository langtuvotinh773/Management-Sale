namespace Management.Salaries
{
    partial class frmEmpSalary
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.grcSalary = new DevExpress.XtraGrid.GridControl();
            this.gvSalary = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalaryPercent_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckbCheckAll = new DevExpress.XtraEditors.CheckEdit();
            this.cboCompany = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboTarget = new DevExpress.XtraEditors.LookUpEdit();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtPersent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grcSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSalary)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckbCheckAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTarget.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên NV :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Sản Phẩm :";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(113, 64);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(201, 20);
            this.txtProductName.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(379, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 47);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Tìm Kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // grcSalary
            // 
            this.grcSalary.Location = new System.Drawing.Point(9, 90);
            this.grcSalary.MainView = this.gvSalary;
            this.grcSalary.Name = "grcSalary";
            this.grcSalary.Size = new System.Drawing.Size(470, 312);
            this.grcSalary.TabIndex = 5;
            this.grcSalary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSalary});
            // 
            // gvSalary
            // 
            this.gvSalary.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProductName,
            this.colPercent,
            this.colNote,
            this.colSalaryPercent_ID,
            this.colCompany});
            this.gvSalary.GridControl = this.grcSalary;
            this.gvSalary.GroupCount = 1;
            this.gvSalary.Name = "gvSalary";
            this.gvSalary.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvSalary.OptionsBehavior.Editable = false;
            this.gvSalary.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCompany, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colProductName
            // 
            this.colProductName.Caption = "Tên Sản Phẩm";
            this.colProductName.FieldName = "ProductName";
            this.colProductName.Name = "colProductName";
            this.colProductName.Visible = true;
            this.colProductName.VisibleIndex = 0;
            this.colProductName.Width = 204;
            // 
            // colPercent
            // 
            this.colPercent.Caption = "Phần Trăm";
            this.colPercent.FieldName = "Percents";
            this.colPercent.Name = "colPercent";
            this.colPercent.Visible = true;
            this.colPercent.VisibleIndex = 1;
            this.colPercent.Width = 71;
            // 
            // colNote
            // 
            this.colNote.Caption = "Note";
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 2;
            this.colNote.Width = 177;
            // 
            // colSalaryPercent_ID
            // 
            this.colSalaryPercent_ID.Caption = "SalaryPercent_ID";
            this.colSalaryPercent_ID.FieldName = "SalaryPercent_ID";
            this.colSalaryPercent_ID.Name = "colSalaryPercent_ID";
            // 
            // colCompany
            // 
            this.colCompany.Caption = "Công ty";
            this.colCompany.FieldName = "CompanyName";
            this.colCompany.Name = "colCompany";
            this.colCompany.Visible = true;
            this.colCompany.VisibleIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckbCheckAll);
            this.groupBox1.Controls.Add(this.cboCompany);
            this.groupBox1.Controls.Add(this.labelControl3);
            this.groupBox1.Controls.Add(this.cboTarget);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.grcSalary);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtProductName);
            this.groupBox1.Location = new System.Drawing.Point(12, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 408);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Nhân Viên";
            // 
            // ckbCheckAll
            // 
            this.ckbCheckAll.Location = new System.Drawing.Point(321, 45);
            this.ckbCheckAll.Name = "ckbCheckAll";
            this.ckbCheckAll.Properties.Caption = "Tất cả";
            this.ckbCheckAll.Size = new System.Drawing.Size(52, 19);
            this.ckbCheckAll.TabIndex = 11;
            // 
            // cboCompany
            // 
            this.cboCompany.Location = new System.Drawing.Point(113, 42);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCompany.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyName", 60, "Tên Công Ty"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Address", 120, "Địa Chỉ")});
            this.cboCompany.Properties.NullText = "Chọn Công Ty";
            this.cboCompany.Properties.PopupFormMinSize = new System.Drawing.Size(180, 0);
            this.cboCompany.Properties.PopupWidth = 350;
            this.cboCompany.Size = new System.Drawing.Size(201, 20);
            this.cboCompany.TabIndex = 10;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 49);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(40, 13);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "Công Ty";
            // 
            // cboTarget
            // 
            this.cboTarget.Location = new System.Drawing.Point(113, 19);
            this.cboTarget.Name = "cboTarget";
            this.cboTarget.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTarget.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmpName", "Tên NV"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Address", "Địa Chỉ")});
            this.cboTarget.Properties.NullText = "CHỌN NHÂN VIÊN";
            this.cboTarget.Size = new System.Drawing.Size(201, 20);
            this.cboTarget.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.txtPersent);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(509, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 100);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cập Nhật Phần Trăm Tính Lương";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(129, 47);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 47);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Cập Nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtPersent
            // 
            this.txtPersent.Location = new System.Drawing.Point(153, 25);
            this.txtPersent.Name = "txtPersent";
            this.txtPersent.Size = new System.Drawing.Size(76, 20);
            this.txtPersent.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "% nhân viên được hưởng :";
            // 
            // frmEmpSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 434);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmEmpSalary";
            this.Text = "Thông Tin Nhân Viên Được Hưởng Lương";
            this.Load += new System.EventHandler(this.frmEmpSalary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grcSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSalary)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckbCheckAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTarget.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Button btnSearch;
        private DevExpress.XtraGrid.GridControl grcSalary;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSalary;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPersent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUpdate;
        private DevExpress.XtraGrid.Columns.GridColumn colProductName;
        private DevExpress.XtraGrid.Columns.GridColumn colPercent;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraEditors.LookUpEdit cboTarget;
        private DevExpress.XtraEditors.LookUpEdit cboCompany;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.Columns.GridColumn colSalaryPercent_ID;
        private DevExpress.XtraEditors.CheckEdit ckbCheckAll;
        private DevExpress.XtraGrid.Columns.GridColumn colCompany;
    }
}