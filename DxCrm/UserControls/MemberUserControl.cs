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
                this.txtTypeEdit.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
                this.txtTypeEdit.Properties.AutoSearchColumnIndex = 1;
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

    }
}