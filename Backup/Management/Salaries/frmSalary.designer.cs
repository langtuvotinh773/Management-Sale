namespace Management
{
    partial class frmSalary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalary));
            this.label1 = new System.Windows.Forms.Label();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboEmp = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.TotalSalary = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtAmount = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtNote = new DevExpress.XtraEditors.TextEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.ShowSalary = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalary.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowSalary.Properties)).BeginInit();
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
            this.label1.Size = new System.Drawing.Size(458, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "XUẤT LƯƠNG CHO NHÂN VIÊN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(59, 60);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(69, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Tên Nhân Viên";
            // 
            // cboEmp
            // 
            this.cboEmp.Location = new System.Drawing.Point(194, 56);
            this.cboEmp.Name = "cboEmp";
            this.cboEmp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEmp.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmpName", "TÊN NHÂN VIÊN"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Address", "ĐỊA CHỈ")});
            this.cboEmp.Properties.NullText = "CHỌN NHÂN VIÊN";
            this.cboEmp.Properties.PopupWidth = 350;
            this.cboEmp.Size = new System.Drawing.Size(163, 20);
            this.cboEmp.TabIndex = 2;
            this.cboEmp.EditValueChanged += new System.EventHandler(this.cboEmp_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(59, 99);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Lương Hiện Có";
            // 
            // TotalSalary
            // 
            this.TotalSalary.Enabled = false;
            this.TotalSalary.Location = new System.Drawing.Point(257, 96);
            this.TotalSalary.Name = "TotalSalary";
            this.TotalSalary.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.TotalSalary.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.TotalSalary.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.TotalSalary.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.TotalSalary.Size = new System.Drawing.Size(100, 20);
            this.TotalSalary.TabIndex = 4;
            this.TotalSalary.Visible = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(59, 138);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Số Tiền Xuất";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(194, 134);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 6;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(59, 177);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(37, 13);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Ghi Chú";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(194, 173);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(163, 20);
            this.txtNote.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(142, 224);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 26);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Lưu và Đóng";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(256, 223);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 26);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ShowSalary
            // 
            this.ShowSalary.Enabled = false;
            this.ShowSalary.Location = new System.Drawing.Point(194, 96);
            this.ShowSalary.Name = "ShowSalary";
            this.ShowSalary.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.ShowSalary.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.ShowSalary.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.ShowSalary.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.ShowSalary.Size = new System.Drawing.Size(100, 20);
            this.ShowSalary.TabIndex = 11;
            // 
            // frmSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 268);
            this.Controls.Add(this.ShowSalary);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.TotalSalary);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cboEmp);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSalary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TRA LUONG";
            this.Load += new System.EventHandler(this.XtraForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboEmp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalary.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowSalary.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit cboEmp;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit TotalSalary;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtAmount;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtNote;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.TextEdit ShowSalary;
    }
}