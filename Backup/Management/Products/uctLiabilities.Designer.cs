namespace Management.Products
{
    partial class uctLiabilities
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uctLiabilities));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnGetData = new DevExpress.XtraEditors.SimpleButton();
            this.gcLiabilities = new DevExpress.XtraGrid.GridControl();
            this.gvLiabilities = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_PayCustName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PayAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PayTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboTarget = new DevExpress.XtraEditors.LookUpEdit();
            this.ckbCheckAll = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcLiabilities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLiabilities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTarget.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbCheckAll.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.ckbCheckAll);
            this.panelControl1.Controls.Add(this.cboTarget);
            this.panelControl1.Controls.Add(this.btnGetData);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(685, 40);
            this.panelControl1.TabIndex = 0;
            // 
            // btnGetData
            // 
            this.btnGetData.Image = ((System.Drawing.Image)(resources.GetObject("btnGetData.Image")));
            this.btnGetData.Location = new System.Drawing.Point(293, 9);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(86, 26);
            this.btnGetData.TabIndex = 3;
            this.btnGetData.Text = "Lấy Dữ Liệu";
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // gcLiabilities
            // 
            this.gcLiabilities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcLiabilities.Location = new System.Drawing.Point(0, 40);
            this.gcLiabilities.MainView = this.gvLiabilities;
            this.gcLiabilities.Name = "gcLiabilities";
            this.gcLiabilities.Size = new System.Drawing.Size(685, 384);
            this.gcLiabilities.TabIndex = 1;
            this.gcLiabilities.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLiabilities});
            // 
            // gvLiabilities
            // 
            this.gvLiabilities.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_PayCustName,
            this.col_PayAddress,
            this.col_PayTotal});
            this.gvLiabilities.GridControl = this.gcLiabilities;
            this.gvLiabilities.Name = "gvLiabilities";
            this.gvLiabilities.OptionsBehavior.Editable = false;
            this.gvLiabilities.OptionsView.ColumnAutoWidth = false;
            this.gvLiabilities.OptionsView.EnableAppearanceOddRow = true;
            this.gvLiabilities.OptionsView.ShowAutoFilterRow = true;
            this.gvLiabilities.OptionsView.ShowFooter = true;
            this.gvLiabilities.OptionsView.ShowGroupPanel = false;
            // 
            // col_PayCustName
            // 
            this.col_PayCustName.Caption = "Tên Khách Hàng";
            this.col_PayCustName.FieldName = "CustName";
            this.col_PayCustName.Name = "col_PayCustName";
            this.col_PayCustName.Visible = true;
            this.col_PayCustName.VisibleIndex = 0;
            this.col_PayCustName.Width = 128;
            // 
            // col_PayAddress
            // 
            this.col_PayAddress.Caption = "Địa Chỉ";
            this.col_PayAddress.FieldName = "Address";
            this.col_PayAddress.Name = "col_PayAddress";
            this.col_PayAddress.Visible = true;
            this.col_PayAddress.VisibleIndex = 1;
            this.col_PayAddress.Width = 272;
            // 
            // col_PayTotal
            // 
            this.col_PayTotal.Caption = "Tổng Nợ";
            this.col_PayTotal.DisplayFormat.FormatString = "{0:c0}";
            this.col_PayTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_PayTotal.FieldName = "TotalPayment";
            this.col_PayTotal.Name = "col_PayTotal";
            this.col_PayTotal.SummaryItem.DisplayFormat = "Tổng Nợ : {0:c0}";
            this.col_PayTotal.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col_PayTotal.Visible = true;
            this.col_PayTotal.VisibleIndex = 2;
            this.col_PayTotal.Width = 143;
            // 
            // cboTarget
            // 
            this.cboTarget.Location = new System.Drawing.Point(5, 14);
            this.cboTarget.Name = "cboTarget";
            this.cboTarget.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTarget.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmpName", "Tên NV"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Address", "Địa Chỉ")});
            this.cboTarget.Properties.NullText = "CHỌN NHÂN VIÊN";
            this.cboTarget.Size = new System.Drawing.Size(201, 20);
            this.cboTarget.TabIndex = 9;
            // 
            // ckbCheckAll
            // 
            this.ckbCheckAll.Location = new System.Drawing.Point(222, 14);
            this.ckbCheckAll.Name = "ckbCheckAll";
            this.ckbCheckAll.Properties.Caption = "Tất cả";
            this.ckbCheckAll.Size = new System.Drawing.Size(52, 19);
            this.ckbCheckAll.TabIndex = 12;
            // 
            // uctLiabilities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcLiabilities);
            this.Controls.Add(this.panelControl1);
            this.Name = "uctLiabilities";
            this.Size = new System.Drawing.Size(685, 424);
            this.Load += new System.EventHandler(this.uctLiabilities_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcLiabilities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLiabilities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTarget.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbCheckAll.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnGetData;
        private DevExpress.XtraGrid.GridControl gcLiabilities;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLiabilities;
        private DevExpress.XtraGrid.Columns.GridColumn col_PayCustName;
        private DevExpress.XtraGrid.Columns.GridColumn col_PayAddress;
        private DevExpress.XtraGrid.Columns.GridColumn col_PayTotal;
        private DevExpress.XtraEditors.LookUpEdit cboTarget;
        private DevExpress.XtraEditors.CheckEdit ckbCheckAll;
    }
}
