namespace Management.Custommer
{
    partial class uctCustommerManager
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.col_Address_edit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.col_Phone_edit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gvCustommer = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc_CustName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_Address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_Phone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_CustID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCustommer = new DevExpress.XtraGrid.GridControl();
            this.btnImport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.col_Address_edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_Phone_edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustommer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCustommer)).BeginInit();
            this.SuspendLayout();
            // 
            // col_Address_edit
            // 
            this.col_Address_edit.AutoHeight = false;
            this.col_Address_edit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.col_Address_edit.Name = "col_Address_edit";
            // 
            // col_Phone_edit
            // 
            this.col_Phone_edit.AutoHeight = false;
            this.col_Phone_edit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.col_Phone_edit.Name = "col_Phone_edit";
            // 
            // gvCustommer
            // 
            this.gvCustommer.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gc_CustName,
            this.gc_Address,
            this.gc_Phone,
            this.gc_CustID});
            this.gvCustommer.GridControl = this.gcCustommer;
            this.gvCustommer.Name = "gvCustommer";
            this.gvCustommer.NewItemRowText = "Nhập thông tin khách hàng mới";
            this.gvCustommer.OptionsFind.AlwaysVisible = true;
            this.gvCustommer.OptionsPrint.UsePrintStyles = true;
            this.gvCustommer.OptionsView.ColumnAutoWidth = false;
            this.gvCustommer.OptionsView.EnableAppearanceOddRow = true;
            this.gvCustommer.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gvCustommer.OptionsView.ShowGroupPanel = false;
            this.gvCustommer.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gvCustommer_InitNewRow);
            this.gvCustommer.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gvCustommer_InvalidRowException);
            this.gvCustommer.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvCustommer_ValidateRow);
            // 
            // gc_CustName
            // 
            this.gc_CustName.Caption = "Tên Khách Hàng";
            this.gc_CustName.ColumnEdit = this.col_Address_edit;
            this.gc_CustName.FieldName = "CustName";
            this.gc_CustName.Name = "gc_CustName";
            this.gc_CustName.Visible = true;
            this.gc_CustName.VisibleIndex = 0;
            this.gc_CustName.Width = 163;
            // 
            // gc_Address
            // 
            this.gc_Address.Caption = "Địa Chỉ";
            this.gc_Address.ColumnEdit = this.col_Address_edit;
            this.gc_Address.FieldName = "Address";
            this.gc_Address.Name = "gc_Address";
            this.gc_Address.Visible = true;
            this.gc_Address.VisibleIndex = 1;
            this.gc_Address.Width = 163;
            // 
            // gc_Phone
            // 
            this.gc_Phone.Caption = "Số Điện Thoại";
            this.gc_Phone.ColumnEdit = this.col_Phone_edit;
            this.gc_Phone.FieldName = "Phone";
            this.gc_Phone.Name = "gc_Phone";
            this.gc_Phone.Visible = true;
            this.gc_Phone.VisibleIndex = 2;
            this.gc_Phone.Width = 157;
            // 
            // gc_CustID
            // 
            this.gc_CustID.Caption = "Mã Số Khách Hàng";
            this.gc_CustID.FieldName = "Cust_ID";
            this.gc_CustID.Name = "gc_CustID";
            // 
            // gcCustommer
            // 
            this.gcCustommer.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.gcCustommer.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gcCustommer.Location = new System.Drawing.Point(0, 0);
            this.gcCustommer.MainView = this.gvCustommer;
            this.gcCustommer.Name = "gcCustommer";
            this.gcCustommer.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.col_Address_edit,
            this.col_Phone_edit});
            this.gcCustommer.Size = new System.Drawing.Size(800, 600);
            this.gcCustommer.TabIndex = 0;
            this.gcCustommer.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCustommer});
            this.gcCustommer.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gcCustommer_ProcessGridKey);
            this.gcCustommer.Click += new System.EventHandler(this.gcCustommer_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(499, 13);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "Import Customer";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // uctCustommerManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.gcCustommer);
            this.Name = "uctCustommerManager";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.uctCustommerManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.col_Address_edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_Phone_edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustommer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCustommer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit col_Address_edit;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit col_Phone_edit;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCustommer;
        private DevExpress.XtraGrid.Columns.GridColumn gc_CustName;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Address;
        private DevExpress.XtraGrid.Columns.GridColumn gc_Phone;
        private DevExpress.XtraGrid.Columns.GridColumn gc_CustID;
        private DevExpress.XtraGrid.GridControl gcCustommer;
        private System.Windows.Forms.Button btnImport;



    }
}
