
using DevExpress.XtraBars;
using DxCrm.Classes;
using MongoDB.Driver;
using System;
using System.ComponentModel;


namespace DxCrm.UserControls
{
    public partial class MemberTypeLstUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        private BindingList<MemberType> dataSource = null;

        public MemberTypeLstUserControl()
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
            MemberType _edit = (MemberType)e.Row;

            if (_edit.Id == new MongoDB.Bson.ObjectId())
                DbManager.Instance.InsertOne(_edit);
            else
                DbManager.Instance.UpdateOneAsync(Builders<MemberType>.Filter.Eq(mt => mt.Id, _edit.Id), _edit);

        }

        private void RefreshDatasource()
        {
            try
            {
                dataSource = new BindingList<MemberType>(DbManager.Instance.FindAsync(FilterDefinition<MemberType>.Empty));
            }
            catch (Exception ex)
            {
                Log.Instance.Error(ex, "Error selecting MemberTypes");
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
            MemberType toDelete = (MemberType)gridView.GetRow(selected[0]);

            DbManager.Instance.DeleteOneAsync(Builders<MemberType>.Filter.Eq(mt => mt.Id, toDelete.Id));

            RefreshDatasource();
        }
    }
}