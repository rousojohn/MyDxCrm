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

namespace DxCrm.UserControls
{
    public partial class MemberLstUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        BindingList<Member> dataSource = null;
        int editedRowHandle = -123123;
        private MemberUserControl memberEditForm = new MemberUserControl();

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

            
        }


#region Control_events

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
            Refresh_Datasource();
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            DoRowClick(view, pt);
        }

        #endregion

        #region Methods

        private void Refresh_Datasource()
        {
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
                bsiRecordsCount.Caption = "RECORDS : " + (dataSource != null ? dataSource.Count : 0);
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

      
    }
}
