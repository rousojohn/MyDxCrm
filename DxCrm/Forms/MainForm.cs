using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Navigation;
using DxCrm.UserControls;
using DxCrm.Classes;

namespace DxCrm
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private enum PageType { List, Edit}
        public enum PageTitle
        {
            Member_List = 0,
            Member_New = 1,
            Member_Edit = 2,
            Supplier_List = 10,
            Supplier_New = 11,
            Incomes_List = 20,
            Outcomes_List = 21,
            Acc_Summary = 22,
            Params_MemberType = 30,
            Params_IncomeType = 31,
            Params_OutcomeType = 32,
            Params_Variables = 33
        }

        private Dictionary<PageTitle, Func<object, UserControl>> mapPagesToUserControls = new Dictionary<PageTitle, Func<object, UserControl>> {
            {PageTitle.Member_List, (object o)=>{return new MemberLstUserControl(); } },
            {PageTitle.Member_New, (object o) => {return new MemberUserControl(); } },
            {PageTitle.Member_Edit, (object o) =>{return new MemberUserControl((Member)o); } },
            {PageTitle.Supplier_List, (object o) => {return new SuppliersLstUserControl(); } },
            {PageTitle.Supplier_New, null },
            {PageTitle.Params_MemberType, (object o) => {return new MemberTypeLstUserControl(); } },
            {PageTitle.Params_IncomeType, (object o) => {return new IncomeTypeLstUserControl(); } },
            {PageTitle.Params_OutcomeType, (object o) => {return new OutcomeTypeLstUserControl(); } },
            {PageTitle.Params_Variables, (object o) => {return new VariablesUserControl(); } },
            {PageTitle.Incomes_List, (object o) => {return new AccIncomeLstUserControl(); } },
            {PageTitle.Outcomes_List, (object o) => {return new AccOutcomeLstUserControl(); } }
        };


#region Constructors
        public MainForm()
        {
            InitializeComponent();
        }

#endregion

#region Control_events

        void navBarControl_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            navigationFrame.SelectedPageIndex = navBarControl.Groups.IndexOf(e.Group);
        }

        void barButtonNavigation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int barItemIndex = barSubItemNavigation.ItemLinks.IndexOf(e.Link);
            navBarControl.ActiveGroup = navBarControl.Groups[barItemIndex];
        }

        private void ribbonControl_Click(object sender, EventArgs e)
        {

        }

        private void skinRibbonGalleryBarItem_GalleryItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            Program.AppSettings.Theme = e.Item.Caption;
            Program.AppSettings.Save();
        }

        private void linkNavigation_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            int linkItemIndex = navBarControl.ActiveGroup.ItemLinks.IndexOf(e.Link);
            (navigationFrame.SelectedPage as NavigationPage).Controls.Clear();

            // find page title with the following algorithm
            // Members --> 0    |   Suppliers --> 1     |     SelectedPageIndex  * 10
            //  List --> 0      |       List --> 0      |       + linkItemIndex ( 0 )
            //  New  --> 1      |       New -->  1      |       + linkItemIndex ( 1 )
            SetContentOfPage((PageTitle)(navigationFrame.SelectedPageIndex * 10 + linkItemIndex), null);
        }

        #endregion

#region Public Methods
        public void SetContentOfPage(PageTitle page, object model)
        {
            (navigationFrame.SelectedPage as NavigationPage).Controls.Clear();
            (navigationFrame.SelectedPage as NavigationPage).Controls.Add(
                mapPagesToUserControls[page](model)
                );
        }
#endregion

    }
}