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
using MongoDB.Driver;

namespace DxCrm.UserControls
{
    public partial class AccSummaryUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        private const string INIT_INCOME_TXT = "Initial Income: ";
        private const string INIT_OUTCOME_TXT = "Initial Outcome: ";
        private const string TOTAL_SUM_TXT = "Total Summary: ";


        private BindingList<AccIncome> datasourceIncomes = null;
        private BindingList<AccOutcome> datasourceOutcomes = null;
        private string datasourceInitIncome = string.Empty;
        private string datasourceInitOutcome = string.Empty;

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
            this.gridView1.Columns["Amount"].SummaryItem.DisplayFormat = "Total: {0:2}";

            this.gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Type", FieldName = "TypeDescr", Caption = "Type", Visible = true });
            this.gridView2.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { Name = "Amount", FieldName = "Amount", Caption = "Amount", Visible = true });
            this.gridView2.Columns["Amount"].SummaryItem.FieldName = "Amount";
            this.gridView2.Columns["Amount"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridView2.Columns["Amount"].SummaryItem.DisplayFormat = "Total: {0:2}";
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

            this.txtInitIncomeLbl.Text = INIT_INCOME_TXT + ((this.datasourceInitIncome != string.Empty) ? this.datasourceInitIncome : "0") ;
            this.txtInitOutcomeLbl.Text = INIT_OUTCOME_TXT + ((this.datasourceInitOutcome != string.Empty) ? this.datasourceInitOutcome : "0");

            this.simpleLabelItem1.Text = TOTAL_SUM_TXT + (
                (double.Parse(this.datasourceInitIncome) + (double)this.gridView1.Columns["Amount"].SummaryItem.SummaryValue ) -
                (double.Parse(this.datasourceInitOutcome) + (double)this.gridView2.Columns["Amount"].SummaryItem.SummaryValue)
                ).ToString();

        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Refresh_Datasources();
        }

        private void Refresh_Datasources()
        {
            try
            {
                this.datasourceIncomes = new BindingList<AccIncome>(DbManager.Instance.GetAccSummaryByType<AccIncome>());
            }
            catch (Exception ex)
            {
                Log.Instance.Error(ex, "Error selecting Income Summary");
                gridControl1.DataSource = datasourceIncomes = null;
                gridControl2.DataSource = datasourceOutcomes = null;
            }

            try
            {
                this.datasourceOutcomes = new BindingList<AccOutcome>(DbManager.Instance.GetAccSummaryByType<AccOutcome>());
            }
            catch (Exception ex)
            {
                Log.Instance.Error(ex, "Error selecting Outcome Summary");
                gridControl2.DataSource = datasourceOutcomes = null;
            }

            try
            {
                var list = (new List<Variables>(DbManager.Instance.FindAsync(FilterDefinition<Variables>.Empty))).SingleOrDefault().Values.ToList();

                datasourceInitIncome = list.Where(l => l.Description.Equals("IncomeInitialValue")).SingleOrDefault().Value;
                datasourceInitOutcome = list.Where(l => l.Description.Equals("OutcomeInitialValue")).SingleOrDefault().Value;
            }
            catch (Exception ex)
            {
                Log.Instance.Error(ex, "Error selecting Outcome Summary");
                gridControl2.DataSource = datasourceOutcomes = null;

            }
        }
    }
}