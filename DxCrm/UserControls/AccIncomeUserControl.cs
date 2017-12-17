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
using MongoDB.Driver;
using DevExpress.XtraEditors.Repository;

namespace DxCrm.UserControls
{
    public partial class AccIncomeUserControl : EditFormUserControl
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.txtTypeEdit.EditValue = txtTypeEdit.Properties.GetKeyValueByDisplayValue((this.dataLayoutControl1.DataSource as AccIncome).TypeDescr);
            this.txtMemberEdit.EditValue = txtMemberEdit.Properties.GetKeyValueByDisplayValue((this.dataLayoutControl1.DataSource as AccIncome).MemberName);
        }

        public AccIncomeUserControl()
        {
            InitializeComponent();

            var list = new BindingList<IncomeType>(DbManager.Instance.FindAsync(FilterDefinition<IncomeType>.Empty));

            this.txtTypeEdit.Properties.DataSource = list;
            this.txtTypeEdit.Properties.DropDownRows = list.Count;
            this.txtTypeEdit.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.txtTypeEdit.Properties.DisplayMember = "Description";
            this.txtTypeEdit.Properties.ValueMember = "Id";
            this.txtTypeEdit.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description"));

            var memberlist = new BindingList<Member>(DbManager.Instance.FindAsync(FilterDefinition<Member>.Empty));
            this.txtMemberEdit.Properties.DataSource = memberlist;
            this.txtMemberEdit.Properties.DropDownRows = memberlist.Count;
            this.txtMemberEdit.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.txtMemberEdit.Properties.DisplayMember = "MemberName";
            this.txtMemberEdit.Properties.ValueMember = "Id";

            this.txtMemberEdit.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AM"));
            this.txtMemberEdit.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Surname"));
            this.txtMemberEdit.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name"));

        }
        
        public void SetDatasource (object _datasource)
        {
            this.dataLayoutControl1.DataSource = _datasource;
        }

        //private void txtMemberEdit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        //{
        //    RepositoryItemLookUpEdit props;
        //    if (sender is LookUpEdit)
        //        props = (sender as LookUpEdit).Properties;
        //    else
        //        props = sender as RepositoryItemLookUpEdit;
        //    if (props != null && e.Value != null)
        //    {
        //        Member row = props.GetDataSourceRowByDisplayValue(e.Value) as Member;
        //        if (row != null)
        //        {
        //            e.DisplayText = String.Format("{0} {1}", row.Surname, row.Name);
        //        }
        //    }

        //}
    }
}