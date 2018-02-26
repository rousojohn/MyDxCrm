using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Helpers;
using System.ComponentModel.DataAnnotations;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;
using DxCrm.Classes;
using DevExpress.XtraGrid;
using MongoDB.Driver;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;

namespace DxCrm.UserControls
{
    public partial class MemberUserControl : EditFormUserControl
    {
       
        #region Constructors

        public MemberUserControl()
            {
                InitializeComponent();
                var list =  new BindingList<MemberType>(DbManager.Instance.FindAsync(FilterDefinition<MemberType>.Empty));
            this.txtTypeEdit.Properties.DataSource = list;
            this.txtTypeEdit.Properties.DropDownRows = list.Count;
            
            //this.txtTypeEdit.Properties.Se
            this.txtTypeEdit.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.txtTypeEdit.Properties.ValueMember = "Id";
            this.txtTypeEdit.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description"));
            this.txtTypeEdit.CustomDisplayText += TxtTypeEdit_CustomDisplayText;

            //this.addressGridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Name", FieldName = "Name", Caption = "Όνομα", Visible = true });


        }



        public MemberUserControl(Member m)
            {
                InitializeComponent();
            }

        #endregion

        public void SetModel(List<Member> m)
        {
            dataLayoutControl1.DataSource = m;
        }

        #region Control_Events
            private void gridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
            {
                UpdateMemberVersion();
            }

            private void UpdateMemberVersion()
            {
                textEdit1.EditValue = (int)textEdit1.EditValue + 1;
            }

            private void gridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
            {
                UpdateMemberVersion();
            }
        #endregion


        private void TxtTypeEdit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            RepositoryItemLookUpEdit props;
            if (sender is LookUpEdit)
                props = (sender as LookUpEdit).Properties;
            else
                props = sender as RepositoryItemLookUpEdit;
            if (props != null && e.Value != null && !String.IsNullOrWhiteSpace(e.Value.ToString()))
            {
                MemberType row = (props.DataSource as BindingList<MemberType>).Where(m => m.Id == new MongoDB.Bson.ObjectId(e.Value.ToString())).SingleOrDefault();
                if (row != null)
                {
                    e.DisplayText = String.Format("{0}", row.Description);
                }
            }

        }
    }
}