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

        public MemberUserControl()
        {
            InitializeComponent();
            var list =  new BindingList<MemberType>(DbManager.Instance.FindAsync(FilterDefinition<MemberType>.Empty));
            this.txtTypeEdit.Properties.DataSource = list;
            this.txtTypeEdit.Properties.DropDownRows = list.Count;
            this.txtTypeEdit.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.txtTypeEdit.Properties.AutoSearchColumnIndex = 1;
        }

        public List<BarButtonItem> GetRibbonButtons ()
        {
            return new List<BarButtonItem>()
            {
                this.bbiClose,
                this.bbiDelete,
                this.bbiReset,
                this.bbiSave,
                this.bbiSaveAndClose,
                this.bbiSaveAndNew
            };
        }

        public MemberUserControl(Member m)
        {
            InitializeComponent();
        }

        public void SetModel(List<Member> m)
        {
            dataLayoutControl1.DataSource = m;
        }

        private void  Expand_Tables(string _table, ref Member _m)
        {
            if (_table == "Phones")
            {
                var arr = _m.Phones;
                _m.Phones = arr;
            }
        }

      
    }
}