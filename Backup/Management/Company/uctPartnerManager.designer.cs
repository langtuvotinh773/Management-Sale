namespace Management.Partner
{
    partial class uctPartnerManager
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
            this.gcPartner = new DevExpress.XtraGrid.GridControl();
            this.gvPartner = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Address_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Phone_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gcCompanyID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcPartner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPartner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_Address_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_Phone_Edit)).BeginInit();
            this.SuspendLayout();
            // 
            // gcPartner
            // 
            this.gcPartner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPartner.Location = new System.Drawing.Point(0, 0);
            this.gcPartner.MainView = this.gvPartner;
            this.gcPartner.Name = "gcPartner";
            this.gcPartner.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.col_Address_Edit,
            this.col_Phone_Edit});
            this.gcPartner.Size = new System.Drawing.Size(800, 600);
            this.gcPartner.TabIndex = 0;
            this.gcPartner.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPartner});
            this.gcPartner.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gcPartner_ProcessGridKey);
            this.gcPartner.Click += new System.EventHandler(this.gcPartner_Click);
            // 
            // gvPartner
            // 
            this.gvPartner.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCompanyName,
            this.gcAddress,
            this.gcPhone,
            this.gcCompanyID});
            this.gvPartner.CustomizationFormBounds = new System.Drawing.Rectangle(627, 560, 216, 178);
            this.gvPartner.GridControl = this.gcPartner;
            this.gvPartner.Name = "gvPartner";
            this.gvPartner.NewItemRowText = "Thêm đối tác";
            this.gvPartner.OptionsFind.AlwaysVisible = true;
            this.gvPartner.OptionsPrint.UsePrintStyles = true;
            this.gvPartner.OptionsView.ColumnAutoWidth = false;
            this.gvPartner.OptionsView.EnableAppearanceOddRow = true;
            this.gvPartner.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gvPartner.OptionsView.ShowGroupPanel = false;
            this.gvPartner.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gvPartner_InitNewRow);
            this.gvPartner.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gvPartner_InvalidRowException);
            this.gvPartner.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvPartner_ValidateRow);
            // 
            // gcCompanyName
            // 
            this.gcCompanyName.Caption = "Tên Công Ty";
            this.gcCompanyName.ColumnEdit = this.col_Address_Edit;
            this.gcCompanyName.FieldName = "CompanyName";
            this.gcCompanyName.Name = "gcCompanyName";
            this.gcCompanyName.Visible = true;
            this.gcCompanyName.VisibleIndex = 1;
            this.gcCompanyName.Width = 140;
            // 
            // col_Address_Edit
            // 
            this.col_Address_Edit.AutoHeight = false;
            this.col_Address_Edit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.col_Address_Edit.Name = "col_Address_Edit";
            // 
            // gcAddress
            // 
            this.gcAddress.Caption = "Địa Chỉ";
            this.gcAddress.ColumnEdit = this.col_Address_Edit;
            this.gcAddress.FieldName = "Address";
            this.gcAddress.Name = "gcAddress";
            this.gcAddress.Visible = true;
            this.gcAddress.VisibleIndex = 2;
            this.gcAddress.Width = 237;
            // 
            // gcPhone
            // 
            this.gcPhone.Caption = "Số Điện Thoại";
            this.gcPhone.ColumnEdit = this.col_Phone_Edit;
            this.gcPhone.FieldName = "Phone";
            this.gcPhone.Name = "gcPhone";
            this.gcPhone.Visible = true;
            this.gcPhone.VisibleIndex = 3;
            this.gcPhone.Width = 151;
            // 
            // col_Phone_Edit
            // 
            this.col_Phone_Edit.AutoHeight = false;
            this.col_Phone_Edit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.col_Phone_Edit.Name = "col_Phone_Edit";
            // 
            // gcCompanyID
            // 
            this.gcCompanyID.Caption = "Mã Số Công Ty";
            this.gcCompanyID.FieldName = "Company_ID";
            this.gcCompanyID.Name = "gcCompanyID";
            this.gcCompanyID.OptionsColumn.AllowEdit = false;
            this.gcCompanyID.OptionsColumn.ReadOnly = true;
            this.gcCompanyID.Visible = true;
            this.gcCompanyID.VisibleIndex = 0;
            // 
            // uctPartnerManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcPartner);
            this.Name = "uctPartnerManager";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.uctPartnerManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcPartner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPartner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_Address_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_Phone_Edit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcPartner;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPartner;
        private DevExpress.XtraGrid.Columns.GridColumn gcCompanyName;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit col_Address_Edit;
        private DevExpress.XtraGrid.Columns.GridColumn gcAddress;
        private DevExpress.XtraGrid.Columns.GridColumn gcPhone;
        private DevExpress.XtraGrid.Columns.GridColumn gcCompanyID;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit col_Phone_Edit;

    }
}
