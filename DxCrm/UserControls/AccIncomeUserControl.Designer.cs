namespace DxCrm.UserControls
{
    partial class AccIncomeUserControl
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
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.txtTypeEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.txtMemberEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.txtDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.txtAAEdit = new DevExpress.XtraEditors.TextEdit();
            this.txtAmountEdit = new DevExpress.XtraEditors.TextEdit();
            this.txtNotesEdit = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.txtDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtAA = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtMember = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtAmount = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtNotes = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtType = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTypeEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAAEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotesEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtType)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.AllowCustomization = false;
            this.SetBoundPropertyName(this.dataLayoutControl1, "");
            this.dataLayoutControl1.Controls.Add(this.txtTypeEdit);
            this.dataLayoutControl1.Controls.Add(this.txtMemberEdit);
            this.dataLayoutControl1.Controls.Add(this.txtDateEdit);
            this.dataLayoutControl1.Controls.Add(this.txtAAEdit);
            this.dataLayoutControl1.Controls.Add(this.txtAmountEdit);
            this.dataLayoutControl1.Controls.Add(this.txtNotesEdit);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(566, 211, 450, 400);
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(800, 600);
            this.dataLayoutControl1.TabIndex = 0;
            // 
            // txtTypeEdit
            // 
            this.SetBoundFieldName(this.txtTypeEdit, "Type");
            this.SetBoundPropertyName(this.txtTypeEdit, "EditValue");
            this.txtTypeEdit.Location = new System.Drawing.Point(234, 12);
            this.txtTypeEdit.Name = "txtTypeEdit";
            this.txtTypeEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTypeEdit.Size = new System.Drawing.Size(250, 20);
            this.txtTypeEdit.StyleController = this.dataLayoutControl1;
            this.txtTypeEdit.TabIndex = 10;
            // 
            // txtMemberEdit
            // 
            this.SetBoundFieldName(this.txtMemberEdit, "Member");
            this.SetBoundPropertyName(this.txtMemberEdit, "EditValue");
            this.txtMemberEdit.Location = new System.Drawing.Point(62, 36);
            this.txtMemberEdit.Name = "txtMemberEdit";
            this.txtMemberEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtMemberEdit.Size = new System.Drawing.Size(373, 20);
            this.txtMemberEdit.StyleController = this.dataLayoutControl1;
            this.txtMemberEdit.TabIndex = 4;
            // 
            // txtDateEdit
            // 
            this.SetBoundFieldName(this.txtDateEdit, "Date");
            this.SetBoundPropertyName(this.txtDateEdit, "EditValue");
            this.txtDateEdit.EditValue = null;
            this.txtDateEdit.Location = new System.Drawing.Point(538, 12);
            this.txtDateEdit.Name = "txtDateEdit";
            this.txtDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDateEdit.Size = new System.Drawing.Size(250, 20);
            this.txtDateEdit.StyleController = this.dataLayoutControl1;
            this.txtDateEdit.TabIndex = 5;
            // 
            // txtAAEdit
            // 
            this.SetBoundFieldName(this.txtAAEdit, "AA");
            this.SetBoundPropertyName(this.txtAAEdit, "EditValue");
            this.txtAAEdit.Location = new System.Drawing.Point(62, 12);
            this.txtAAEdit.Name = "txtAAEdit";
            this.txtAAEdit.Size = new System.Drawing.Size(118, 20);
            this.txtAAEdit.StyleController = this.dataLayoutControl1;
            this.txtAAEdit.TabIndex = 6;
            // 
            // txtAmountEdit
            // 
            this.SetBoundFieldName(this.txtAmountEdit, "Amount");
            this.SetBoundPropertyName(this.txtAmountEdit, "EditValue");
            this.txtAmountEdit.Location = new System.Drawing.Point(489, 36);
            this.txtAmountEdit.Name = "txtAmountEdit";
            this.txtAmountEdit.Size = new System.Drawing.Size(299, 20);
            this.txtAmountEdit.StyleController = this.dataLayoutControl1;
            this.txtAmountEdit.TabIndex = 8;
            // 
            // txtNotesEdit
            // 
            this.SetBoundFieldName(this.txtNotesEdit, "Notes");
            this.SetBoundPropertyName(this.txtNotesEdit, "EditValue");
            this.txtNotesEdit.Location = new System.Drawing.Point(62, 84);
            this.txtNotesEdit.Name = "txtNotesEdit";
            this.txtNotesEdit.Size = new System.Drawing.Size(726, 504);
            this.txtNotesEdit.StyleController = this.dataLayoutControl1;
            this.txtNotesEdit.TabIndex = 9;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.txtDate,
            this.txtAA,
            this.txtMember,
            this.txtAmount,
            this.txtNotes,
            this.txtType});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(800, 600);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(780, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // txtDate
            // 
            this.txtDate.Control = this.txtDateEdit;
            this.txtDate.Location = new System.Drawing.Point(476, 0);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(304, 24);
            this.txtDate.Text = "rsDate";
            this.txtDate.TextSize = new System.Drawing.Size(47, 13);
            // 
            // txtAA
            // 
            this.txtAA.Control = this.txtAAEdit;
            this.txtAA.Location = new System.Drawing.Point(0, 0);
            this.txtAA.Name = "txtAA";
            this.txtAA.Size = new System.Drawing.Size(172, 24);
            this.txtAA.Text = "rsAA";
            this.txtAA.TextSize = new System.Drawing.Size(47, 13);
            // 
            // txtMember
            // 
            this.txtMember.Control = this.txtMemberEdit;
            this.txtMember.Location = new System.Drawing.Point(0, 24);
            this.txtMember.Name = "txtMember";
            this.txtMember.Size = new System.Drawing.Size(427, 24);
            this.txtMember.Text = "rsMember";
            this.txtMember.TextSize = new System.Drawing.Size(47, 13);
            // 
            // txtAmount
            // 
            this.txtAmount.Control = this.txtAmountEdit;
            this.txtAmount.Location = new System.Drawing.Point(427, 24);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(353, 24);
            this.txtAmount.Text = "rsAmount";
            this.txtAmount.TextSize = new System.Drawing.Size(47, 13);
            // 
            // txtNotes
            // 
            this.txtNotes.Control = this.txtNotesEdit;
            this.txtNotes.Location = new System.Drawing.Point(0, 72);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(780, 508);
            this.txtNotes.Text = "rsNotes";
            this.txtNotes.TextSize = new System.Drawing.Size(47, 13);
            // 
            // txtType
            // 
            this.txtType.Control = this.txtTypeEdit;
            this.txtType.Location = new System.Drawing.Point(172, 0);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(304, 24);
            this.txtType.Text = "rsType";
            this.txtType.TextSize = new System.Drawing.Size(47, 13);
            // 
            // AccIncomeUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "AccIncomeUserControl";
            this.Size = new System.Drawing.Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTypeEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAAEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotesEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LookUpEdit txtMemberEdit;
        private DevExpress.XtraEditors.DateEdit txtDateEdit;
        private DevExpress.XtraEditors.TextEdit txtAAEdit;
        private DevExpress.XtraEditors.TextEdit txtAmountEdit;
        private DevExpress.XtraEditors.MemoEdit txtNotesEdit;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem txtDate;
        private DevExpress.XtraLayout.LayoutControlItem txtAA;
        private DevExpress.XtraLayout.LayoutControlItem txtMember;
        private DevExpress.XtraLayout.LayoutControlItem txtAmount;
        private DevExpress.XtraLayout.LayoutControlItem txtNotes;
        private DevExpress.XtraEditors.LookUpEdit txtTypeEdit;
        private DevExpress.XtraLayout.LayoutControlItem txtType;
    }
}