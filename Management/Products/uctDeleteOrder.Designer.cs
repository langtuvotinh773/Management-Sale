namespace Management.Products
{
    partial class uctDeleteOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uctDeleteOrder));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.GroupOrther = new DevExpress.XtraEditors.GroupControl();
            this.btnCopy = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnGetData = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupOrther)).BeginInit();
            this.GroupOrther.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.GroupOrther);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(800, 107);
            this.panelControl1.TabIndex = 0;
            // 
            // GroupOrther
            // 
            this.GroupOrther.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupOrther.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.GroupOrther.AppearanceCaption.Options.UseFont = true;
            this.GroupOrther.AppearanceCaption.Options.UseForeColor = true;
            this.GroupOrther.Controls.Add(this.btnCopy);
            this.GroupOrther.Controls.Add(this.btnDelete);
            this.GroupOrther.Controls.Add(this.txtSalary);
            this.GroupOrther.Controls.Add(this.label1);
            this.GroupOrther.Controls.Add(this.txtOrder);
            this.GroupOrther.Controls.Add(this.labelControl1);
            this.GroupOrther.Controls.Add(this.btnGetData);
            this.GroupOrther.Location = new System.Drawing.Point(5, 5);
            this.GroupOrther.Name = "GroupOrther";
            this.GroupOrther.Size = new System.Drawing.Size(790, 97);
            this.GroupOrther.TabIndex = 12;
            this.GroupOrther.Text = "Nhân Viên - Khách Hàng";
            // 
            // btnCopy
            // 
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.Location = new System.Drawing.Point(586, 66);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(92, 26);
            this.btnCopy.TabIndex = 15;
            this.btnCopy.Text = "Copy - Delete";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(693, 66);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(92, 26);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Xóa HĐ";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtSalary
            // 
            this.txtSalary.Enabled = false;
            this.txtSalary.Location = new System.Drawing.Point(376, 28);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(82, 21);
            this.txtSalary.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(283, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Số nv phải trả lại";
            // 
            // txtOrder
            // 
            this.txtOrder.Location = new System.Drawing.Point(86, 28);
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(82, 21);
            this.txtOrder.TabIndex = 11;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Số Hóa Đơn";
            // 
            // btnGetData
            // 
            this.btnGetData.Image = ((System.Drawing.Image)(resources.GetObject("btnGetData.Image")));
            this.btnGetData.Location = new System.Drawing.Point(174, 25);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(92, 26);
            this.btnGetData.TabIndex = 10;
            this.btnGetData.Text = "Lấy Dữ Liệu";
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // uctDeleteOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "uctDeleteOrder";
            this.Size = new System.Drawing.Size(800, 111);
            this.Load += new System.EventHandler(this.uctDeleteOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GroupOrther)).EndInit();
            this.GroupOrther.ResumeLayout(false);
            this.GroupOrther.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnGetData;
        private DevExpress.XtraEditors.GroupControl GroupOrther;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOrder;
        private DevExpress.XtraEditors.SimpleButton btnCopy;
    }
}
