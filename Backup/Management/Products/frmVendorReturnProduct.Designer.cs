namespace Management.Products
{
    partial class frmVendorReturnProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVendorReturnProduct));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnReturn = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.txtQtyPromotionNeed = new DevExpress.XtraEditors.TextEdit();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.txtQtyNeed = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtPromotionPercent = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtAmount = new DevExpress.XtraEditors.TextEdit();
            this.txtDisCount = new DevExpress.XtraEditors.TextEdit();
            this.txtForm = new DevExpress.XtraEditors.TextEdit();
            this.txtPrice = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtQuantityPromotion = new DevExpress.XtraEditors.TextEdit();
            this.txtQuantity = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboProduct = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtyPromotionNeed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtyNeed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPromotionPercent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDisCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtForm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantityPromotion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProduct.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl1.Controls.Add(this.btnClose);
            this.groupControl1.Controls.Add(this.btnReturn);
            this.groupControl1.Controls.Add(this.groupControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(523, 256);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "TRẢ HÀNG CHO NHÀ CUNG CẤP";
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(441, 222);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 26);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Image = ((System.Drawing.Image)(resources.GetObject("btnReturn.Image")));
            this.btnReturn.Location = new System.Drawing.Point(348, 222);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 26);
            this.btnReturn.TabIndex = 2;
            this.btnReturn.Text = "Trả Hàng";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl2.Controls.Add(this.txtQtyPromotionNeed);
            this.groupControl2.Controls.Add(this.labelControl18);
            this.groupControl2.Controls.Add(this.txtQtyNeed);
            this.groupControl2.Controls.Add(this.labelControl9);
            this.groupControl2.Controls.Add(this.txtPromotionPercent);
            this.groupControl2.Controls.Add(this.labelControl8);
            this.groupControl2.Controls.Add(this.txtAmount);
            this.groupControl2.Controls.Add(this.txtDisCount);
            this.groupControl2.Controls.Add(this.txtForm);
            this.groupControl2.Controls.Add(this.txtPrice);
            this.groupControl2.Controls.Add(this.labelControl7);
            this.groupControl2.Controls.Add(this.txtQuantityPromotion);
            this.groupControl2.Controls.Add(this.txtQuantity);
            this.groupControl2.Controls.Add(this.labelControl6);
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Controls.Add(this.cboProduct);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(2, 34);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(519, 179);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Sản Phẩm Cần Đổi";
            // 
            // txtQtyPromotionNeed
            // 
            this.txtQtyPromotionNeed.EditValue = "0";
            this.txtQtyPromotionNeed.Location = new System.Drawing.Point(401, 142);
            this.txtQtyPromotionNeed.Name = "txtQtyPromotionNeed";
            this.txtQtyPromotionNeed.Properties.Appearance.Options.UseTextOptions = true;
            this.txtQtyPromotionNeed.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtQtyPromotionNeed.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.txtQtyPromotionNeed.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtQtyPromotionNeed.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtQtyPromotionNeed.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtQtyPromotionNeed.Size = new System.Drawing.Size(100, 20);
            this.txtQtyPromotionNeed.TabIndex = 21;
            this.txtQtyPromotionNeed.Leave += new System.EventHandler(this.txtQtyPromotionNeed_Leave);
            // 
            // labelControl18
            // 
            this.labelControl18.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl18.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl18.Location = new System.Drawing.Point(281, 144);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(110, 16);
            this.labelControl18.TabIndex = 20;
            this.labelControl18.Text = "* Số Lượng K.Mại";
            // 
            // txtQtyNeed
            // 
            this.txtQtyNeed.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtQtyNeed.Location = new System.Drawing.Point(153, 142);
            this.txtQtyNeed.Name = "txtQtyNeed";
            this.txtQtyNeed.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtQtyNeed.Size = new System.Drawing.Size(82, 20);
            this.txtQtyNeed.TabIndex = 17;
            this.txtQtyNeed.EditValueChanged += new System.EventHandler(this.txtQtyNeed_EditValueChanged);
            this.txtQtyNeed.Leave += new System.EventHandler(this.txtQtyNeed_Leave);
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl9.Location = new System.Drawing.Point(17, 144);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(125, 16);
            this.labelControl9.TabIndex = 16;
            this.labelControl9.Text = "* Số Lượng Cần Trả";
            // 
            // txtPromotionPercent
            // 
            this.txtPromotionPercent.Enabled = false;
            this.txtPromotionPercent.Location = new System.Drawing.Point(402, 54);
            this.txtPromotionPercent.Name = "txtPromotionPercent";
            this.txtPromotionPercent.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtPromotionPercent.Properties.Appearance.Options.UseBackColor = true;
            this.txtPromotionPercent.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.MistyRose;
            this.txtPromotionPercent.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtPromotionPercent.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtPromotionPercent.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtPromotionPercent.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.MistyRose;
            this.txtPromotionPercent.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtPromotionPercent.Size = new System.Drawing.Size(100, 20);
            this.txtPromotionPercent.TabIndex = 15;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(308, 57);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(69, 13);
            this.labelControl8.TabIndex = 14;
            this.labelControl8.Text = "% Khuyến Mại";
            // 
            // txtAmount
            // 
            this.txtAmount.Enabled = false;
            this.txtAmount.Location = new System.Drawing.Point(402, 109);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtAmount.Properties.Appearance.Options.UseBackColor = true;
            this.txtAmount.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.MistyRose;
            this.txtAmount.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtAmount.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtAmount.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtAmount.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.MistyRose;
            this.txtAmount.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 13;
            // 
            // txtDisCount
            // 
            this.txtDisCount.Enabled = false;
            this.txtDisCount.Location = new System.Drawing.Point(401, 81);
            this.txtDisCount.Name = "txtDisCount";
            this.txtDisCount.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtDisCount.Properties.Appearance.Options.UseBackColor = true;
            this.txtDisCount.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.MistyRose;
            this.txtDisCount.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtDisCount.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtDisCount.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtDisCount.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.MistyRose;
            this.txtDisCount.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtDisCount.Size = new System.Drawing.Size(100, 20);
            this.txtDisCount.TabIndex = 12;
            // 
            // txtForm
            // 
            this.txtForm.Enabled = false;
            this.txtForm.Location = new System.Drawing.Point(401, 25);
            this.txtForm.Name = "txtForm";
            this.txtForm.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtForm.Properties.Appearance.Options.UseBackColor = true;
            this.txtForm.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.MistyRose;
            this.txtForm.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtForm.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtForm.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtForm.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.MistyRose;
            this.txtForm.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtForm.Size = new System.Drawing.Size(100, 20);
            this.txtForm.TabIndex = 11;
            // 
            // txtPrice
            // 
            this.txtPrice.Enabled = false;
            this.txtPrice.Location = new System.Drawing.Point(153, 110);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtPrice.Properties.Appearance.Options.UseBackColor = true;
            this.txtPrice.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.MistyRose;
            this.txtPrice.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtPrice.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtPrice.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtPrice.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.MistyRose;
            this.txtPrice.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtPrice.Properties.DisplayFormat.FormatString = "{0:c0}";
            this.txtPrice.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPrice.Size = new System.Drawing.Size(100, 20);
            this.txtPrice.TabIndex = 10;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(308, 29);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(55, 13);
            this.labelControl7.TabIndex = 9;
            this.labelControl7.Text = "Khuyến Mại";
            // 
            // txtQuantityPromotion
            // 
            this.txtQuantityPromotion.Enabled = false;
            this.txtQuantityPromotion.Location = new System.Drawing.Point(153, 81);
            this.txtQuantityPromotion.Name = "txtQuantityPromotion";
            this.txtQuantityPromotion.Properties.Appearance.BackColor = System.Drawing.Color.Silver;
            this.txtQuantityPromotion.Properties.Appearance.Options.UseBackColor = true;
            this.txtQuantityPromotion.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.MistyRose;
            this.txtQuantityPromotion.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtQuantityPromotion.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtQuantityPromotion.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtQuantityPromotion.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.MistyRose;
            this.txtQuantityPromotion.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtQuantityPromotion.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtQuantityPromotion.Size = new System.Drawing.Size(100, 22);
            this.txtQuantityPromotion.TabIndex = 8;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Enabled = false;
            this.txtQuantity.Location = new System.Drawing.Point(153, 52);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtQuantity.Properties.Appearance.Options.UseBackColor = true;
            this.txtQuantity.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.MistyRose;
            this.txtQuantity.Properties.AppearanceDisabled.BackColor2 = System.Drawing.Color.Transparent;
            this.txtQuantity.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtQuantity.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtQuantity.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtQuantity.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtQuantity.Properties.Mask.EditMask = "c";
            this.txtQuantity.Size = new System.Drawing.Size(100, 22);
            this.txtQuantity.TabIndex = 7;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(308, 113);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(53, 13);
            this.labelControl6.TabIndex = 6;
            this.labelControl6.Text = "Thành Tiền";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(308, 85);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(52, 13);
            this.labelControl5.TabIndex = 5;
            this.labelControl5.Text = "Chiết Khấu";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(10, 113);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(38, 13);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Đơn Giá";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(10, 85);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(132, 13);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Số Lượng Được Khuyến Mại";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 57);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(90, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Số Lượng Đã Nhập";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(116, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Chọn Sản Phẩm Cần Đổi";
            // 
            // cboProduct
            // 
            this.cboProduct.Location = new System.Drawing.Point(150, 25);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProduct.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyName", "Tên Công Ty"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductName", "Tên Sản Phẩm"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Price", "Đơn Giá", 20, DevExpress.Utils.FormatType.Numeric, "n0", true, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Quantity", "Số Lượng"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Product_ID", "Mã Sản Phẩm", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.cboProduct.Properties.NullText = "CHỌN...";
            this.cboProduct.Properties.PopupWidth = 500;
            this.cboProduct.Size = new System.Drawing.Size(136, 20);
            this.cboProduct.TabIndex = 0;
            this.cboProduct.EditValueChanged += new System.EventHandler(this.cboProduct_EditValueChanged);
            // 
            // frmVendorReturnProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 256);
            this.Controls.Add(this.groupControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(539, 294);
            this.MinimumSize = new System.Drawing.Size(531, 290);
            this.Name = "frmVendorReturnProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TRA HANG";
            this.Load += new System.EventHandler(this.frmVendorReturnProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtyPromotionNeed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtyNeed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPromotionPercent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDisCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtForm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantityPromotion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProduct.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SpinEdit txtQtyNeed;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtPromotionPercent;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtAmount;
        private DevExpress.XtraEditors.TextEdit txtDisCount;
        private DevExpress.XtraEditors.TextEdit txtForm;
        private DevExpress.XtraEditors.TextEdit txtPrice;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtQuantityPromotion;
        private DevExpress.XtraEditors.TextEdit txtQuantity;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit cboProduct;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnReturn;
        private DevExpress.XtraEditors.TextEdit txtQtyPromotionNeed;
        private DevExpress.XtraEditors.LabelControl labelControl18;
    }
}