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
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.IO;
using DevExpress.XtraGrid.Views.Base;

namespace DxCrm.UserControls
{
    public partial class MemberLstUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        BindingList<Member> dataSource = null;
        int editedRowHandle = -123123;
        private MemberUserControl memberEditForm = new MemberUserControl();
        private const string GRID_LAYOUT = Program.GRID_LAYOUTS_DIR + @"\" + "MEMBERS_LST.xml";

        
        #region Constructors 
        public MemberLstUserControl()
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

                    if (File.Exists(GRID_LAYOUT))
                    {
                        gridControl.ForceInitialize();
                        // Restore the previously saved layout
                        gridControl.MainView.RestoreLayoutFromXml(GRID_LAYOUT);
                    }
                };

                this.gridView.RowUpdated += (sender, e) =>
                {
                    var newMember = (gridView.DataSource as BindingList<Member>).Where(m => m.Id == new MongoDB.Bson.ObjectId()).ToList();
                    if (newMember.Count > 0)
                        DbManager.Instance.InsertMany(newMember);
                    else
                    {
                        if (editedRowHandle != -123123)
                        {
                            var toEdit = (Member)gridView.GetRow(editedRowHandle);
                            DbManager.Instance.UpdateOneAsync(Builders<Member>.Filter.Eq(m => m.Id, toEdit.Id), toEdit);
                        }
                    }
                };

            this.gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Name", FieldName = "Name", Caption = "Όνομα", Visible = true });
            this.gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Surname", FieldName = "Surname", Caption = "Επώνυμο", Visible = true });
            this.gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "FatherName", FieldName = "FatherName", Caption = "Πατέρας", Visible = true });
            this.gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "MotherName", FieldName = "MotherName", Caption = "Μητέρα", Visible = true });
            this.gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Birthdate", FieldName = "Birthdate", Caption = "Ημ/νόα Γέννησης", Visible = true });
            this.gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Birthplace", FieldName = "Birthplace", Caption = "Τόπος Γέννησης", Visible = true });
            this.gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Email", FieldName = "Emails", Caption = "Email", Visible = true });
            this.gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Phone", FieldName = "Phones", Caption = "Τηλέφωνο", Visible = true });
            this.gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "AM", FieldName = "AM", Caption = "ΑΜ", Visible = true });
            this.gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Job", FieldName = "Job", Caption = "Επάγγελμα", Visible = true });
            this.gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "SubscriptionDate", FieldName = "SubscriptionDate", Caption = "Ημ/νία Εγγραφής", Visible = true });
            this.gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "ExpirationDate", FieldName = "ExpirationDate", Caption = "Ημ/νία Λήξης", Visible = true });
            this.gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "IsActive", FieldName = "IsActive", Caption = "Ενεργός", Visible = true });
            this.gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "SubscriptionYear", FieldName = "SubscriptionYear", Caption = "Έτος εγγραφής", Visible = true });
            this.gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Address", FieldName = "Addresses", Caption = "Διεύθυνση", Visible = true });
            this.gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "TypeDescr", FieldName = "TypeDescr", Caption = "Τύπος", Visible = true });
            this.gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Notes", FieldName = "Notes", Caption = "Σχόλια", Visible = false });

            this.gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
        }
        #endregion


        #region Control_events

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
                        BindingList<MemberEmail> emails = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "Emails") as BindingList<MemberEmail>;
                        if (emails != null && emails.Count > 0 )
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

        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
            {
                gridControl.ShowRibbonPrintPreview();
            }

            private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
            {
                var selected = this.gridView.GetSelectedRows();
                Member toDelete = (Member) gridView.GetRow(selected[0]);

                var result = DbManager.Instance.DeleteOneAsync(Builders<Member>.Filter.Where(u => u.Id.Equals(toDelete.Id)));

                Refresh_Datasource();
            }

            private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
            {
                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += Bw_DoWork;
                bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
            }

            private void gridView_DoubleClick(object sender, EventArgs e)
            {
                GridView view = (GridView)sender;
                Point pt = view.GridControl.PointToClient(Control.MousePosition);
                DoRowClick(view, pt);
            }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.gridView.AddNewRow();
            this.gridView.ShowEditForm();
        }
        #endregion

        #region Methods

        

        public void SaveGridLayout()
        {
            gridControl.MainView.SaveLayoutToXml(GRID_LAYOUT);
        }

        private void Refresh_Datasource()
        {
            gridControl.DataSource = dataSource = null;
            try
            {
                dataSource = new BindingList<Member>(DbManager.Instance.FindAsync(FilterDefinition<Member>.Empty));
            }
            catch (Exception ex)
            {
                Log.Instance.Error(ex, "Error selecting Members");
                gridControl.DataSource = dataSource = null;

            }
            finally
            {
                bsiRecordsCount.Caption = "Σύνολο Μελών : " + (dataSource != null ? dataSource.Count : 0);
            }
        }


        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.dataSource != null)
            {
                gridControl.DataSource = dataSource;
                gridView.OptionsBehavior.EditingMode = GridEditingMode.EditForm;

                gridView.OptionsEditForm.CustomEditFormLayout = memberEditForm;
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


        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }


        private void gridView_ShowingPopupEditForm(object sender, ShowingPopupEditFormEventArgs e)
        {
            e.EditForm.StartPosition = FormStartPosition.CenterParent;
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {

            this.gridView.ShowEditForm();
        }
    }
}
