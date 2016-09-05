namespace Management.Products
{
    partial class uctLiabilitiesCompany
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uctLiabilitiesCompany));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnGetData = new DevExpress.XtraEditors.SimpleButton();
            this.gcNoCongTy = new DevExpress.XtraGrid.GridControl();
            this.gvNoCongTy = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_CompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Total = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcNoCongTy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNoCongTy)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnGetData);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(616, 42);
            this.panelControl1.TabIndex = 0;
            // 
            // btnGetData
            // 
            this.btnGetData.Image = ((System.Drawing.Image)(resources.GetObject("btnGetData.Image")));
            this.btnGetData.Location = new System.Drawing.Point(19, 7);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(92, 26);
            this.btnGetData.TabIndex = 0;
            this.btnGetData.Text = "Lấy Dữ Liệu";
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // gcNoCongTy
            // 
            this.gcNoCongTy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcNoCongTy.Location = new System.Drawing.Point(0, 42);
            this.gcNoCongTy.MainView = this.gvNoCongTy;
            this.gcNoCongTy.Name = "gcNoCongTy";
            this.gcNoCongTy.Size = new System.Drawing.Size(616, 416);
            this.gcNoCongTy.TabIndex = 1;
            this.gcNoCongTy.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNoCongTy});
            // 
            // gvNoCongTy
            // 
            this.gvNoCongTy.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_CompanyName,
            this.col_Address,
            this.col_Total});
            this.gvNoCongTy.GridControl = this.gcNoCongTy;
            this.gvNoCongTy.Name = "gvNoCongTy";
            this.gvNoCongTy.OptionsBehavior.Editable = false;
            this.gvNoCongTy.OptionsPrint.AutoWidth = false;
            this.gvNoCongTy.OptionsView.ColumnAutoWidth = false;
            this.gvNoCongTy.OptionsView.EnableAppearanceOddRow = true;
            this.gvNoCongTy.OptionsView.ShowAutoFilterRow = true;
            this.gvNoCongTy.OptionsView.ShowFooter = true;
            this.gvNoCongTy.OptionsView.ShowGroupPanel = false;
            // 
            // col_CompanyName
            // 
            this.col_CompanyName.Caption = "Tên Công Ty";
            this.col_CompanyName.FieldName = "CompanyName";
            this.col_CompanyName.Name = "col_CompanyName";
            this.col_CompanyName.Visible = true;
            this.col_CompanyName.VisibleIndex = 0;
            this.col_CompanyName.Width = 143;
            // 
            // col_Address
            // 
            this.col_Address.Caption = "Địa Chỉ";
            this.col_Address.FieldName = "Address";
            this.col_Address.Name = "col_Address";
            this.col_Address.Visible = true;
            this.col_Address.VisibleIndex = 1;
            this.col_Address.Width = 319;
            // 
            // col_Total
            // 
            this.col_Total.Caption = "Tiền Nợ";
            this.col_Total.DisplayFormat.FormatString = "{0:c0}";
            this.col_Total.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Total.FieldName = "TotalAmount";
            this.col_Total.GroupFormat.FormatString = "{0:c0}";
            this.col_Total.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_Total.Name = "col_Total";
            this.col_Total.SummaryItem.DisplayFormat = "Tổng:{0:c0}";
            this.col_Total.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.col_Total.Visible = true;
            this.col_Total.VisibleIndex = 2;
            this.col_Total.Width = 117;
            // 
            // uctLiabilitiesCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcNoCongTy);
            this.Controls.Add(this.panelControl1);
            this.Name = "uctLiabilitiesCompany";
            this.Size = new System.Drawing.Size(616, 458);
            this.Load += new System.EventHandler(this.uctLiabilitiesCompany_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcNoCongTy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNoCongTy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnGetData;
        private DevExpress.XtraGrid.GridControl gcNoCongTy;
        private DevExpress.XtraGrid.Views.Grid.GridView gvNoCongTy;
        private DevExpress.XtraGrid.Columns.GridColumn col_CompanyName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Address;
        private DevExpress.XtraGrid.Columns.GridColumn col_Total;
    }
}
