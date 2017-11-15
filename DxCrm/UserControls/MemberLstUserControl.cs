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
        

        public MemberLstUserControl()
        {

            InitializeComponent();
            this.Dock = DockStyle.Fill;
            

            //gridView.GetDetailView().

            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;

            this.Load += (sender, e) =>
            {
                gridControl.DataSource = dataSource = null;
                if (!bw.IsBusy)
                    bw.RunWorkerAsync();
            };

            //this.gridView.EditFormPrepared += (sender, e) =>
            //{
            //    var a = (Member)gridView.GetRow(e.RowHandle);
            //    //a.Phones = new BindingList<Telephone>();


            //    //a.Phones = new List<Telephone>();

            //    //(gridView.OptionsEditForm.CustomEditFormLayout as MemberUserControl).SetModel(new List<Member>() {
            //    //a
            //    //});
            //};
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

        #endregion

#region Methods

        private void Refresh_Datasource()
        {
            try
            {
                //dataSource = new BindingList<Member>(DbManager.Instance.FindAsync(FilterDefinition<Member>.Empty));


                dataSource = new BindingList<Member>() {
                    new Member()
                    {
                        Addresses = new BindingList<Address> (){ new Address() {
                            PostalCode = 14545,
                            Region = "Asdasd",
                            Street = "Street",
                            StreetNo ="7"
                        } },
                        Age = 18,
                        Birthdate = DateTime.Now,
                        Emails = new BindingList<string> () {"myEmail@email.com", "myEmail2@email.com"},
                        ExpirationDate = DateTime.Now,
                        Birthplace = "BirthPlace",
                        FatherName = "FathernName",
                        IsActive = true,
                        Job = "Job",
                        MotherName = "MotherName",
                         Name= " Name:",
                         Notes = "Notes",
                         Phones = new BindingList<Telephone>() {new Telephone() { Number = "6944757940", Type=TelephoneType.Mobile} },
                         SubscriptionDate = DateTime.Now,
                         Surname = "Surname555",
                         Type = new MemberType () {Description="Type", Id = new MongoDB.Bson.ObjectId()},
                         Id = new MongoDB.Bson.ObjectId(),
                         AM = 1233,
SubscriptionYear = 2107                         
                    }
                };
            }
            catch (Exception ex)
            {
                Log.Instance.Error(ex, "Error selecting Members");
                gridControl.DataSource = dataSource = null;

            }
            finally
            {
                //bsiRecordsCount.Caption = "RECORDS : " + (dataSource != null ? dataSource.Count : 0);
                
                
            }
        }


        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.dataSource != null)
            {
                gridControl.DataSource = dataSource;
                gridView.OptionsBehavior.EditingMode = GridEditingMode.EditForm;
                gridView.OptionsEditForm.CustomEditFormLayout = new MemberUserControl();
                //gridView.Columns[2].Visible = false;
                //gridView.Columns["MotherName"].Visible = false;
            }

        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Refresh_Datasource();
        }

        #endregion

        //private void gridView_DoubleClick(object sender, EventArgs e)
        //{
        //    GridView view = (GridView)sender;
        //    Point pt = view.GridControl.PointToClient(Control.MousePosition);

        //    DoRowClick(view, pt);
        //}

        private void DoRowClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                var row = view.GetRow(info.RowHandle);
                Program.MainForm.SetContentOfPage(MainForm.PageTitle.Member_Edit, (Member)row);
            }
        }
    }
}
