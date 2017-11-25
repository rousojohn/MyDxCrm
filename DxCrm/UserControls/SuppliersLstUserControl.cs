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
using DevExpress.XtraGrid.Views.Grid;
using DxCrm.Classes;
using MongoDB.Driver;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace DxCrm.UserControls
{
    public partial class SuppliersLstUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        BindingList<Supplier> dataSource = null;
        int editedRowHandle = -123123;
        private SupplierUserControl SupplierEditForm = new SupplierUserControl();

        #region Constructors

        public SuppliersLstUserControl()
        {


            InitializeComponent();
            this.Dock = DockStyle.Fill;

           


            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
            


            this.Load += (sender, e) =>
            {
                gridControl.DataSource = dataSource = null;
                if (!bw.IsBusy)
                    bw.RunWorkerAsync();
            };

            this.gridView.RowUpdated += (sender, e) =>
            {
                var newSupplier = (gridView.DataSource as BindingList<Supplier>).Where(m => m.Id == new MongoDB.Bson.ObjectId()).ToList();
                if (newSupplier.Count > 0)
                    DbManager.Instance.InsertMany(newSupplier);
                else
                {
                    if (editedRowHandle != -123123)
                    {
                        var toEdit = (Supplier)gridView.GetRow(editedRowHandle);
                        DbManager.Instance.UpdateOneAsync(Builders<Supplier>.Filter.Eq(m => m.Id, toEdit.Id), toEdit);
                    }
                }
            };

        }

        #endregion

        #region Control_Events

            private void gridView_ShowingPopupEditForm(object sender, ShowingPopupEditFormEventArgs e)
            {
                e.EditForm.StartPosition = FormStartPosition.CenterParent;
            }

            void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
            {
                gridControl.ShowRibbonPrintPreview();
            }

            private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
            {

            }

        #endregion

        #region Methods

            private void Refresh_Datasource()
            {
                try
                {
                    dataSource = new BindingList<Supplier>(DbManager.Instance.FindAsync(FilterDefinition<Supplier>.Empty));
                }
                catch (Exception ex)
                {
                    Log.Instance.Error(ex, "Error selecting Suppliers");
                    gridControl.DataSource = dataSource = null;

                }
                finally
                {
                    bsiRecordsCount.Caption = "RECORDS : " + (dataSource != null ? dataSource.Count : 0);
                }
            }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.dataSource != null)
            {
                gridControl.DataSource = dataSource;
                gridView.OptionsBehavior.EditingMode = GridEditingMode.EditForm;
                gridView.OptionsEditForm.CustomEditFormLayout = SupplierEditForm;
            }
        }

            private void Bw_DoWork(object sender, DoWorkEventArgs e)
            {
                Refresh_Datasource();
            }

            private void DoRowClick(GridView view, Point pt)
            {
                GridHitInfo info = view.CalcHitInfo(pt);
                if (info.InDataRow && (info.InRow || info.InRowCell))
                    editedRowHandle = info.RowHandle;
            }

        #endregion

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.gridView.AddNewRow();
            this.gridView.ShowEditForm();
        }
    }
}
