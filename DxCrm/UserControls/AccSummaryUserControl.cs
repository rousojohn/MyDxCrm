using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Helpers;
using System.ComponentModel.DataAnnotations;
using System.IO;
using DxCrm.Classes;
using MongoDB.Bson;

namespace DxCrm.UserControls
{
    public partial class AccSummaryUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        private BindingList<AccIncome> datasourceIncomes = null;
        private BindingList<AccOutcome> datasourceOutcomes = null;
        private BackgroundWorker bw = new BackgroundWorker();

        public AccSummaryUserControl()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(255, 88, 88, 88);


            this.bw.DoWork += Bw_DoWork;
            this.bw.RunWorkerCompleted += Bw_RunWorkerCompleted;

            this.Load += (sender, e) =>
            {
                gridControl1.DataSource = datasourceIncomes = null;
                gridControl2.DataSource = datasourceOutcomes = null;
                if (!bw.IsBusy)
                    bw.RunWorkerAsync();
            };


            this.gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Type", FieldName = "TypeDescr", Caption = "Type", Visible = true });
            this.gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Amount", FieldName = "Amount", Caption = "Amount", Visible = true });
            this.gridView1.Columns["Amount"].SummaryItem.FieldName = "Amount";
            this.gridView1.Columns["Amount"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridView1.Columns["Amount"].SummaryItem.DisplayFormat = "Total: {0:c2}";

            this.gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Type", FieldName = "TypeDescr", Caption = "Type", Visible = true });
            this.gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Amount", FieldName = "Amount", Caption = "Amount", Visible = true });
            this.gridView2.Columns["Amount"].SummaryItem.FieldName = "Amount";
            this.gridView2.Columns["Amount"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridView2.Columns["Amount"].SummaryItem.DisplayFormat = "Total: {0:c2}";
        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.datasourceIncomes != null)
            {
                this.gridControl1.DataSource = datasourceIncomes;
                this.gridControl1.RefreshDataSource();
            }

            if (this.datasourceOutcomes != null)
            {
                this.gridControl2.DataSource = datasourceOutcomes;
                this.gridControl2.RefreshDataSource();
            }
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Refresh_Datasources();
        }

        private void Refresh_Datasources()
        {
            try
            {
                this.datasourceIncomes = new BindingList<AccIncome>(DbManager.Instance.GetIncomesByType<AccIncome>());
                this.datasourceOutcomes = new BindingList<AccOutcome>(DbManager.Instance.GetIncomesByType<AccOutcome>());
            }
            catch (Exception ex)
            {
                Log.Instance.Error(ex, "Error selecting Summaries");
                gridControl1.DataSource = datasourceIncomes = null;
                gridControl2.DataSource = datasourceOutcomes = null;

            }
        }
    }
}