namespace Management.Products
{
    partial class uctViewLog
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uctViewLog));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gcViewLog = new DevExpress.XtraGrid.GridControl();
            this.gvViewLog = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_Type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_InsertBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ScreenName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Data = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemRichTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.col_ODISLock_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ButtonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.button_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.GroupOrther = new DevExpress.XtraEditors.GroupControl();
            this.txtFromDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnGetData = new DevExpress.XtraEditors.SimpleButton();
            this.dateEnd = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcViewLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_ODISLock_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupOrther)).BeginInit();
            this.GroupOrther.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcViewLog
            // 
            this.gcViewLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcViewLog.Location = new System.Drawing.Point(0, 80);
            this.gcViewLog.MainView = this.gvViewLog;
            this.gcViewLog.Name = "gcViewLog";
            this.gcViewLog.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.col_ODISLock_Edit,
            this.ButtonEdit,
            this.repositoryItemDateEdit1,
            this.button_Edit,
            this.repositoryItemRichTextEdit1});
            this.gcViewLog.Size = new System.Drawing.Size(800, 520);
            this.gcViewLog.TabIndex = 1;
            this.gcViewLog.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvViewLog});
            // 
            // gvViewLog
            // 
            this.gvViewLog.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_Type,
            this.col_InsertBy,
            this.col_ScreenName,
            this.col_Data,
            this.gridColumn1});
            this.gvViewLog.CustomizationFormBounds = new System.Drawing.Rectangle(604, 382, 216, 178);
            this.gvViewLog.GridControl = this.gcViewLog;
            this.gvViewLog.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gvViewLog.Name = "gvViewLog";
            this.gvViewLog.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvViewLog.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gvViewLog.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvViewLog.OptionsView.ColumnAutoWidth = false;
            this.gvViewLog.OptionsView.EnableAppearanceOddRow = true;
            this.gvViewLog.OptionsView.RowAutoHeight = true;
            this.gvViewLog.OptionsView.ShowAutoFilterRow = true;
            this.gvViewLog.OptionsView.ShowGroupPanel = false;
            // 
            // col_Type
            // 
            this.col_Type.Caption = "Actions";
            this.col_Type.FieldName = "Type";
            this.col_Type.Name = "col_Type";
            this.col_Type.OptionsColumn.AllowEdit = false;
            this.col_Type.OptionsColumn.AllowFocus = false;
            this.col_Type.Visible = true;
            this.col_Type.VisibleIndex = 1;
            this.col_Type.Width = 69;
            // 
            // col_InsertBy
            // 
            this.col_InsertBy.Caption = "Insert By";
            this.col_InsertBy.FieldName = "InsertBy";
            this.col_InsertBy.Name = "col_InsertBy";
            this.col_InsertBy.OptionsColumn.AllowEdit = false;
            this.col_InsertBy.OptionsColumn.AllowFocus = false;
            this.col_InsertBy.Visible = true;
            this.col_InsertBy.VisibleIndex = 2;
            this.col_InsertBy.Width = 53;
            // 
            // col_ScreenName
            // 
            this.col_ScreenName.Caption = "Screen Name";
            this.col_ScreenName.FieldName = "ScreenName";
            this.col_ScreenName.Name = "col_ScreenName";
            this.col_ScreenName.OptionsColumn.AllowEdit = false;
            this.col_ScreenName.OptionsColumn.AllowFocus = false;
            this.col_ScreenName.Visible = true;
            this.col_ScreenName.VisibleIndex = 3;
            this.col_ScreenName.Width = 99;
            // 
            // col_Data
            // 
            this.col_Data.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.col_Data.AppearanceCell.Options.UseFont = true;
            this.col_Data.AppearanceCell.Options.UseTextOptions = true;
            this.col_Data.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.col_Data.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.col_Data.AppearanceHeader.Options.UseFont = true;
            this.col_Data.Caption = "String data";
            this.col_Data.ColumnEdit = this.repositoryItemRichTextEdit1;
            this.col_Data.FieldName = "Data";
            this.col_Data.Name = "col_Data";
            this.col_Data.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.col_Data.Visible = true;
            this.col_Data.VisibleIndex = 4;
            this.col_Data.Width = 480;
            // 
            // repositoryItemRichTextEdit1
            // 
            this.repositoryItemRichTextEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemRichTextEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.repositoryItemRichTextEdit1.Name = "repositoryItemRichTextEdit1";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Insert Date";
            this.gridColumn1.ColumnEdit = this.repositoryItemDateEdit1;
            this.gridColumn1.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn1.FieldName = "InsertDate";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.Date;
            this.gridColumn1.OptionsFilter.ShowEmptyDateFilter = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 117;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.repositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.repositoryItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.Mask.EditMask = "dd/MM/yyyy HH:mm:ss";
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // col_ODISLock_Edit
            // 
            this.col_ODISLock_Edit.AutoHeight = false;
            this.col_ODISLock_Edit.Name = "col_ODISLock_Edit";
            // 
            // ButtonEdit
            // 
            this.ButtonEdit.AutoHeight = false;
            this.ButtonEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)), serializableAppearanceObject1, "", null, null, true)});
            this.ButtonEdit.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.ButtonEdit.Name = "ButtonEdit";
            this.ButtonEdit.NullText = "Cap";
            // 
            // button_Edit
            // 
            this.button_Edit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("button_Edit.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Cập nhật lại lương", null, null, true)});
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.NullText = "Cập Nhật Lương";
            this.button_Edit.ReadOnly = true;
            this.button_Edit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.button_Edit.UseParentBackground = true;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.GroupOrther);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(800, 80);
            this.panelControl1.TabIndex = 0;
            // 
            // GroupOrther
            // 
            this.GroupOrther.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupOrther.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.GroupOrther.AppearanceCaption.Options.UseFont = true;
            this.GroupOrther.AppearanceCaption.Options.UseForeColor = true;
            this.GroupOrther.Controls.Add(this.txtFromDate);
            this.GroupOrther.Controls.Add(this.labelControl1);
            this.GroupOrther.Controls.Add(this.labelControl2);
            this.GroupOrther.Controls.Add(this.btnGetData);
            this.GroupOrther.Controls.Add(this.dateEnd);
            this.GroupOrther.Location = new System.Drawing.Point(5, 5);
            this.GroupOrther.Name = "GroupOrther";
            this.GroupOrther.Size = new System.Drawing.Size(790, 65);
            this.GroupOrther.TabIndex = 12;
            this.GroupOrther.Text = "Nhân Viên - Khách Hàng";
            // 
            // txtFromDate
            // 
            this.txtFromDate.EditValue = null;
            this.txtFromDate.Location = new System.Drawing.Point(70, 24);
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtFromDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.txtFromDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtFromDate.Size = new System.Drawing.Size(100, 20);
            this.txtFromDate.TabIndex = 11;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(41, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Từ Ngày";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(197, 28);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Đến Ngày";
            // 
            // btnGetData
            // 
            this.btnGetData.Image = ((System.Drawing.Image)(resources.GetObject("btnGetData.Image")));
            this.btnGetData.Location = new System.Drawing.Point(393, 25);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(92, 26);
            this.btnGetData.TabIndex = 10;
            this.btnGetData.Text = "Lấy Dữ Liệu";
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // dateEnd
            // 
            this.dateEnd.EditValue = null;
            this.dateEnd.Location = new System.Drawing.Point(250, 24);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEnd.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEnd.Size = new System.Drawing.Size(100, 20);
            this.dateEnd.TabIndex = 4;
            // 
            // uctViewLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcViewLog);
            this.Controls.Add(this.panelControl1);
            this.Name = "uctViewLog";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.uctViewLog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcViewLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvViewLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.col_ODISLock_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GroupOrther)).EndInit();
            this.GroupOrther.ResumeLayout(false);
            this.GroupOrther.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.DateEdit dateEnd;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnGetData;
        private DevExpress.XtraGrid.GridControl gcViewLog;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit col_ODISLock_Edit;
        private DevExpress.XtraEditors.GroupControl GroupOrther;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ButtonEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit button_Edit;
        private DevExpress.XtraGrid.Views.Grid.GridView gvViewLog;
        private DevExpress.XtraGrid.Columns.GridColumn col_Type;
        private DevExpress.XtraGrid.Columns.GridColumn col_InsertBy;
        private DevExpress.XtraGrid.Columns.GridColumn col_ScreenName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Data;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit repositoryItemRichTextEdit1;
        private DevExpress.XtraEditors.DateEdit txtFromDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}
