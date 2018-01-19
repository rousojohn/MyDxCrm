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
    public partial class VariablesUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        BindingList<VarValues> dataSource = null;
        BindingList<Variables> variableDatasource = null;
        BackgroundWorker bw = new BackgroundWorker();

        public VariablesUserControl()
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
                if (variableDatasource != null)
                {
                    if (variableDatasource.SingleOrDefault().Id == new MongoDB.Bson.ObjectId())
                        DbManager.Instance.InsertOne(variableDatasource.SingleOrDefault());
                    else
                        DbManager.Instance.UpdateOneAsync(Builders<Variables>.Filter.Eq(m => m.Id, variableDatasource.First().Id), variableDatasource.First());
                }
            };
        }

        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }


        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.dataSource != null)
            {
                gridControl.DataSource = dataSource;
                gridControl.RefreshDataSource();
            }
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Refresh_Datasource();
        }

        private void Refresh_Datasource()
        {
            try
            {
                variableDatasource = new BindingList<Variables>(DbManager.Instance.FindAsync(FilterDefinition<Variables>.Empty));

                if (variableDatasource.Count < 1)
                    variableDatasource = new BindingList<Variables>() { new Variables() };

                dataSource = new BindingList<VarValues>(variableDatasource.SingleOrDefault().Values.ToList());
            }
            catch (Exception ex)
            {
                Log.Instance.Error(ex, "Error selecting AccIncomes");
                gridControl.DataSource = dataSource = null;
            }
            finally
            {
                bsiRecordsCount.Caption = "RECORDS : " + (dataSource != null ? dataSource.Count : 0);
            }
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}
