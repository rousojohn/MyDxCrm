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

            AlertControl alert = new AlertControl();
            AlertInfo info = new AlertInfo("", result.Result.IsAcknowledged ? "Update Successful" : "Update Failed", true);

            alert.Show(Program.MainForm, info);

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
                 //memberEditForm = new MemberUserControl();
                //List<BarButtonItem> controlBtns = memberEditForm.GetRibbonButtons();
                //controlBtns.Where(btn => btn.Name == "bbiSave").FirstOrDefault().ItemClick += (sender1, e1) =>
                //  {
                      
                //  };
                //controlBtns.Where(btn => btn.Name == "bbiClose").FirstOrDefault().ItemClick += (sender1, e1) =>
                //{
                //    //gridView.HideEditForm();
                //    gridView.CancelUpdateCurrentRow();
                //};
                //controlBtns.Where(btn => btn.Name == "bbiDelete").FirstOrDefault().ItemClick += (sender1, e1) =>
                //{
                //    Console.WriteLine("bbiDelete Clicked");
                //};
                //controlBtns.Where(btn => btn.Name == "bbiReset").FirstOrDefault().ItemClick += (sender1, e1) =>
                //{
                //    Console.WriteLine("bbiReset Clicked");
                //};
                //controlBtns.Where(btn => btn.Name == "bbiSaveAndClose").FirstOrDefault().ItemClick += (sender1, e1) =>
                //{
                //    gridView.CloseEditForm();
                    
                //};
                //controlBtns.Where(btn => btn.Name == "bbiSaveAndNew").FirstOrDefault().ItemClick += (sender1, e1) =>
                //{
                //    Console.WriteLine("bbiSaveAndNew Clicked");
                //};

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
            //memberEditForm.EditForm = e.EditForm;


            //List<Control> btns = GetAll(e.EditForm, typeof(BarButtonItem)).ToList();
            //BarButtonItem save = btns.OfType<BarButtonItem>().Where(bbi => bbi.Name != null && bbi.Name == "bbiSave").FirstOrDefault();
            //save.Caption = "asdasdasdasD";
            //SimpleButton updateBtn = btns.OfType<SimpleButton>().Where(sb => sb.Tag != null && sb.Tag.ToString() == "OkButton").FirstOrDefault();
            //updateBtn.Click += updateBtn_Click;

            /* foreach (Control control in e.EditForm.Controls)
             {
                 foreach (Control nestedControl in control.Controls)
                 {
                     if (!(nestedControl is PanelControl))
                     {
                         continue;
                     }
                     foreach (Control button in nestedControl.Controls)
                     {
                         if (!(button is SimpleButton))
                         {
                             continue;
                         }
                         var simpleButton = button as SimpleButton;
                         //simpleButton.Click -= editFormUpdateButton_Click;
                         //simpleButton.Click += editFormUpdateButton_Click;
                     }
                 }
             }*/
        }

        private void EditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
                var a = e;
                var c = 1;
        }
    }
}
