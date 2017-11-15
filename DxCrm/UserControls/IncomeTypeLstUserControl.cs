using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System.ComponentModel.DataAnnotations;
using DxCrm.Classes;
using MongoDB.Driver;

namespace DxCrm.UserControls
{
    public partial class IncomeTypeLstUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        private BindingList<IncomeType> dataSource = null;

        public IncomeTypeLstUserControl()
        {
            InitializeComponent();

            this.Load += (sender, e) =>
            {
                RefreshDatasource();
            };

            gridView.OptionsNavigation.AutoFocusNewRow = true;
            gridView.RowUpdated += GridView_RowUpdated;
        }

        private void GridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            IncomeType _edit = (IncomeType)e.Row;

            if (_edit.Id == new MongoDB.Bson.ObjectId())
                DbManager.Instance.InsertOne(_edit);
            else
                DbManager.Instance.UpdateOneAsync(Builders<IncomeType>.Filter.Eq(mt => mt.Id, _edit.Id), _edit);

        }

        private void RefreshDatasource()
        {
            try
            {
                dataSource = new BindingList<IncomeType>(DbManager.Instance.FindAsync(FilterDefinition<IncomeType>.Empty));
            }
            catch (Exception ex)
            {
                Log.Instance.Error(ex, "Error selecting IncomeTypes");
            }
            finally
            {
                gridControl.DataSource = dataSource;
                bsiRecordsCount.Caption = "RECORDS : " + (dataSource != null ? dataSource.Count : 0);
            }
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshDatasource();
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridView.AddNewRow();
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridView.ShowEditor();
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selected = this.gridView.GetSelectedRows();
            IncomeType toDelete = (IncomeType)gridView.GetRow(selected[0]);

            DbManager.Instance.DeleteOneAsync(Builders<IncomeType>.Filter.Eq(mt => mt.Id, toDelete.Id));

            RefreshDatasource();
        }
    }
}