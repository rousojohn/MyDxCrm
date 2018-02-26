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
using System.IO;
using DevExpress.XtraGrid.Views.Base;

namespace DxCrm.UserControls
{
    public partial class SuppliersLstUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        BindingList<Supplier> dataSource = null;
        int editedRowHandle = -123123;
        private SupplierUserControl SupplierEditForm = new SupplierUserControl();
        BackgroundWorker bw = new BackgroundWorker();

        private const string GRID_LAYOUT = Program.GRID_LAYOUTS_DIR + @"\" + "SUPPLIERS_LST.xml";

        #region Constructors

        public SuppliersLstUserControl()
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

                if (File.Exists(GRID_LAYOUT))
                {
                    gridControl.ForceInitialize();
                    // Restore the previously saved layout
                    gridControl.MainView.RestoreLayoutFromXml(GRID_LAYOUT);
                }
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

            this.gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Name", FieldName = "Name", Caption = "Όνομα", Visible = true });
            this.gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
            {
                Name = "Surname",
                FieldName = "Surname",
                Caption = "Επώνυμο",
                Visible = true
            });
            this.gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Email", FieldName = "Emails", Caption = "Email", Visible = true });
            this.gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
            {
                Name = "Phone",
                FieldName = "Phones",
                Caption = "Τηλέφωνο",
                Visible = true
            });
            this.gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Job", FieldName = "Job", Caption = "Επάγγελμα", Visible = true });
            this.gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Address", FieldName = "Addresses", Caption = "Διεύθυνση", Visible = true });
            this.gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Notes", FieldName = "Notes", Caption = "Σχόλια", Visible = false });

            this.gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;


        }

        #endregion

        #region Control_Events

        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            if (e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                if (e.Column.FieldName == "Emails")
                {
                    e.DisplayText = String.Empty;

                    if (view.GetListSourceRowCellValue(e.ListSourceRowIndex, "Emails") != null)
                    {
                        BindingList<SupplierEmail> emails = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "Emails") as BindingList<SupplierEmail>;
                        if (emails != null && emails.Count > 0)
                            e.DisplayText = emails[0].Email;
                    }
                }
                else if (e.Column.FieldName == "Phones")
                {
                    e.DisplayText = String.Empty;
                    if (view.GetListSourceRowCellValue(e.ListSourceRowIndex, "Phones") != null)
                    {
                        BindingList<Telephone> phones = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "Phones") as BindingList<Telephone>;
                        if (phones != null && phones.Count > 0)
                            e.DisplayText = phones[0].Number;
                    }
                }
                else if (e.Column.FieldName == "Addresses")
                {
                    e.DisplayText = String.Empty;
                    if (view.GetListSourceRowCellValue(e.ListSourceRowIndex, "Emails") != null)
                    {
                        BindingList<Address> addresses = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "Addresses") as BindingList<Address>;
                        if (addresses != null && addresses.Count > 0)
                            e.DisplayText = string.Format("{0}, {1}, {2}, {3}", addresses[0].Street, addresses[0].StreetNo, addresses[0].Region, addresses[0].PostalCode);
                    }
                }
            }
        }

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
            this.gridView.ShowEditForm();
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.gridView.AddNewRow();
            this.gridView.ShowEditForm();
        }
        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
            {
                var selected = this.gridView.GetSelectedRows();
                Supplier toDelete = (Supplier)gridView.GetRow(selected[0]);

                var result = DbManager.Instance.DeleteOneAsync(Builders<Supplier>.Filter.Where(u => u.Id.Equals(toDelete.Id)));

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

        #endregion

        #region Methods

        public void SaveGridLayout()
        {
            gridControl.MainView.SaveLayoutToXml(GRID_LAYOUT);
        }

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

        #endregion

      
    }
}
