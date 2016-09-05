namespace Management.UnitManager
{
    partial class frmUnit
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
            this.grcUnit = new DevExpress.XtraGrid.GridControl();
            this.grUnit = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.UnitName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MoTa_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.UnitDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Unit_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grcUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoTa_Edit)).BeginInit();
            this.SuspendLayout();
            // 
            // grcUnit
            // 
            this.grcUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcUnit.Location = new System.Drawing.Point(0, 0);
            this.grcUnit.MainView = this.grUnit;
            this.grcUnit.Name = "grcUnit";
            this.grcUnit.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.MoTa_Edit});
            this.grcUnit.Size = new System.Drawing.Size(800, 600);
            this.grcUnit.TabIndex = 0;
            this.grcUnit.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grUnit});
            this.grcUnit.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.grcUnit_ProcessGridKey);
            this.grcUnit.Click += new System.EventHandler(this.grcUnit_Click);
            // 
            // grUnit
            // 
            this.grUnit.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.UnitName,
            this.UnitDesc,
            this.Unit_ID});
            this.grUnit.GridControl = this.grcUnit;
            this.grUnit.Name = "grUnit";
            this.grUnit.NewItemRowText = "Nhập Đơn Vị Tính";
            this.grUnit.OptionsFind.AlwaysVisible = true;
            this.grUnit.OptionsPrint.UsePrintStyles = true;
            this.grUnit.OptionsView.ColumnAutoWidth = false;
            this.grUnit.OptionsView.EnableAppearanceOddRow = true;
            this.grUnit.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.grUnit.OptionsView.ShowGroupPanel = false;
            this.grUnit.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grUnit_InitNewRow);
            this.grUnit.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.grUnit_InvalidRowException);
            this.grUnit.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grUnit_ValidateRow);
            // 
            // UnitName
            // 
            this.UnitName.Caption = "Đơn Vị Tính";
            this.UnitName.ColumnEdit = this.MoTa_Edit;
            this.UnitName.FieldName = "UnitName";
            this.UnitName.Name = "UnitName";
            this.UnitName.Visible = true;
            this.UnitName.VisibleIndex = 1;
            this.UnitName.Width = 311;
            // 
            // MoTa_Edit
            // 
            this.MoTa_Edit.AutoHeight = false;
            this.MoTa_Edit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.MoTa_Edit.Name = "MoTa_Edit";
            // 
            // UnitDesc
            // 
            this.UnitDesc.Caption = "Mô Tả Đơn Vị";
            this.UnitDesc.ColumnEdit = this.MoTa_Edit;
            this.UnitDesc.FieldName = "UnitDesc";
            this.UnitDesc.Name = "UnitDesc";
            this.UnitDesc.Visible = true;
            this.UnitDesc.VisibleIndex = 2;
            this.UnitDesc.Width = 280;
            // 
            // Unit_ID
            // 
            this.Unit_ID.Caption = "Mã Đơn Vị";
            this.Unit_ID.FieldName = "Unit_ID";
            this.Unit_ID.Name = "Unit_ID";
            this.Unit_ID.OptionsColumn.AllowEdit = false;
            this.Unit_ID.OptionsColumn.ReadOnly = true;
            this.Unit_ID.Visible = true;
            this.Unit_ID.VisibleIndex = 0;
            // 
            // frmUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grcUnit);
            this.Name = "frmUnit";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.frmUnit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grcUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoTa_Edit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcUnit;
        private DevExpress.XtraGrid.Views.Grid.GridView grUnit;
        private DevExpress.XtraGrid.Columns.GridColumn UnitName;
        private DevExpress.XtraGrid.Columns.GridColumn UnitDesc;
        private DevExpress.XtraGrid.Columns.GridColumn Unit_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit MoTa_Edit;
    }
}
