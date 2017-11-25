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
    public partial class SupplierUserControl : EditFormUserControl
    {
        public SupplierUserControl()
        {
            InitializeComponent();
        }

        public SupplierUserControl(Supplier m)
        {
            InitializeComponent();
        }

        public void SetModel(List<Supplier> m)
        {
            dataLayoutControl1.DataSource = m;
        }

             
    }
}