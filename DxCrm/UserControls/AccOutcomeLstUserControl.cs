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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;

namespace DxCrm.UserControls
{
    public partial class AccOutcomeLstUserControl : DevExpress.XtraEditors.XtraUserControl
    {

        BindingList<AccOutcome> dataSource = null;
        int editedRowHandle = -123123;
        private AccOutcomeUserControl AccOutcomeEditForm = new AccOutcomeUserControl();
        BackgroundWorker bw = new BackgroundWorker();



        public AccOutcomeLstUserControl()
        {

            InitializeComponent();
            this.Dock = DockStyle.Fill;

            this.bw.DoWork += Bw_DoWork;
            this.bw.RunWorkerCompleted += Bw_RunWorkerCompleted;

            this.Load += (sender, e) =>
            {
                gridControl.DataSource = dataSource = null;
                if (!bw.IsBusy)
                    bw.RunWorkerAsync();
            };

            this.gridView.RowUpdated += (sender, ex) =>
            {
                var newAccOutcome = (gridView.DataSource as BindingList<AccOutcome>).Where(m => m.Id == new MongoDB.Bson.ObjectId()).ToList();
                if (newAccOutcome.Count > 0)
                    DbManager.Instance.InsertMany(newAccOutcome);
                else
                {
                    if (editedRowHandle != -123123)
                    {
                        var toEdit = (AccOutcome)gridView.GetRow(editedRowHandle);
                        DbManager.Instance.UpdateOneAsync(Builders<AccOutcome>.Filter.Eq(m => m.Id, toEdit.Id), toEdit);
                    }
                }
            };

            this.gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "AA", FieldName = "AA", Caption = "AA", Visible = true });
            this.gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
            {
                Name = "Type",
                FieldName = "Type",
                Caption = "Type",
                Visible = true
            });

            this.gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Date", FieldName = "Date", Caption = "Date", Visible = true });
            this.gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
            {
                Name = "Supplier",
                FieldName = "Supplier",
                Caption = "Supplier",
                Visible = true
            });
            this.gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Amount", FieldName = "Amount", Caption = "Amount", Visible = true });
            this.gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Notes", FieldName = "Notes", Caption = "Notes", Visible = false });

            this.gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
        }

        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            if (e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                if (e.Column.FieldName == "Supplier")
                {
                    if (view.GetListSourceRowCellValue(e.ListSourceRowIndex, "SupplierName") != null)
                        e.DisplayText = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "SupplierName").ToString();
                }
                else if (e.Column.FieldName == "Type")
                {
                    if (view.GetListSourceRowCellValue(e.ListSourceRowIndex, "TypeDescr") != null)
                        e.DisplayText = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "TypeDescr").ToString();
                }
            }
        }

        private void gridView_ShowingPopupEditForm(object sender, ShowingPopupEditFormEventArgs e)
        {
            e.EditForm.StartPosition = FormStartPosition.CenterScreen;
        }

        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {

        }


        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selected = this.gridView.GetSelectedRows();
            AccOutcome toDelete = (AccOutcome)gridView.GetRow(selected[0]);

            var result = DbManager.Instance.DeleteOneAsync(Builders<AccOutcome>.Filter.Where(u => u.Id.Equals(toDelete.Id)));

            this.bw.RunWorkerAsync();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.bw.RunWorkerAsync();
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            DoRowClick(view, pt);
        }

        private void Refresh_Datasource()
        {
            try
            {
                dataSource = new BindingList<AccOutcome>(DbManager.Instance.FindAsync(FilterDefinition<AccOutcome>.Empty));
            }
            catch (Exception ex)
            {
                Log.Instance.Error(ex, "Error selecting AccOutcomes");
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
                gridView.OptionsEditForm.CustomEditFormLayout = AccOutcomeEditForm;
                gridControl.RefreshDataSource();
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

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.gridView.AddNewRow();
            this.gridView.ShowEditForm();
        }

    }
}
