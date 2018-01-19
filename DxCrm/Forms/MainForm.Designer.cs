namespace DxCrm
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabbedView = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.skinRibbonGalleryBarItem = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.barSubItemNavigation = new DevExpress.XtraBars.BarSubItem();
            this.membersBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.suppliersBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.financeBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupNavigation = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.officeNavigationBar = new DevExpress.XtraBars.Navigation.OfficeNavigationBar();
            this.navBarControl = new DevExpress.XtraNavBar.NavBarControl();
            this.employeesNavBarGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.memberLstNavBarItm = new DevExpress.XtraNavBar.NavBarItem();
            this.newMemberNavBarItm = new DevExpress.XtraNavBar.NavBarItem();
            this.customersNavBarGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.suppliersLstNavBarItm = new DevExpress.XtraNavBar.NavBarItem();
            this.suppliersNewNavBarItm = new DevExpress.XtraNavBar.NavBarItem();
            this.financeNavBarGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem3 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.memberTypenavBarItm = new DevExpress.XtraNavBar.NavBarItem();
            this.incomeTypeNavBarItm = new DevExpress.XtraNavBar.NavBarItem();
            this.outcomeTypeNavBarItm = new DevExpress.XtraNavBar.NavBarItem();
            this.navigationFrame = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.membersNavigationPage = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.employeesLabelControl = new DevExpress.XtraEditors.LabelControl();
            this.suppliersNavigationPage = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.customersLabelControl = new DevExpress.XtraEditors.LabelControl();
            this.financeNavigationPage = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.paramsNavigationPage = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.variablesNavBarItm = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeNavigationBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame)).BeginInit();
            this.navigationFrame.SuspendLayout();
            this.membersNavigationPage.SuspendLayout();
            this.suppliersNavigationPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabbedView
            // 
            this.tabbedView.RootContainer.Element = null;
            // 
            // ribbonControl
            // 
            this.ribbonControl.AllowMdiChildButtons = false;
            this.ribbonControl.AllowMinimizeRibbon = false;
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.skinRibbonGalleryBarItem,
            this.barSubItemNavigation,
            this.membersBarButtonItem,
            this.suppliersBarButtonItem,
            this.financeBarButtonItem});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 47;
            this.ribbonControl.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Never;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.Size = new System.Drawing.Size(790, 143);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // skinRibbonGalleryBarItem
            // 
            this.skinRibbonGalleryBarItem.Id = 14;
            this.skinRibbonGalleryBarItem.Name = "skinRibbonGalleryBarItem";
            this.skinRibbonGalleryBarItem.GalleryItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.skinRibbonGalleryBarItem_GalleryItemClick);
            // 
            // barSubItemNavigation
            // 
            this.barSubItemNavigation.Caption = "Navigation";
            this.barSubItemNavigation.Id = 15;
            this.barSubItemNavigation.ImageOptions.ImageUri.Uri = "NavigationBar";
            this.barSubItemNavigation.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.membersBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.suppliersBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.financeBarButtonItem)});
            this.barSubItemNavigation.Name = "barSubItemNavigation";
            // 
            // membersBarButtonItem
            // 
            this.membersBarButtonItem.Caption = "rsMembers";
            this.membersBarButtonItem.Id = 44;
            this.membersBarButtonItem.Name = "membersBarButtonItem";
            this.membersBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonNavigation_ItemClick);
            // 
            // suppliersBarButtonItem
            // 
            this.suppliersBarButtonItem.Caption = "rsSuppliers";
            this.suppliersBarButtonItem.Id = 45;
            this.suppliersBarButtonItem.Name = "suppliersBarButtonItem";
            this.suppliersBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonNavigation_ItemClick);
            // 
            // financeBarButtonItem
            // 
            this.financeBarButtonItem.Caption = "rsFinance";
            this.financeBarButtonItem.Id = 46;
            this.financeBarButtonItem.Name = "financeBarButtonItem";
            this.financeBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonNavigation_ItemClick);
            // 
            // ribbonPage
            // 
            this.ribbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupNavigation,
            this.ribbonPageGroup});
            this.ribbonPage.Name = "ribbonPage";
            this.ribbonPage.Text = "View";
            // 
            // ribbonPageGroupNavigation
            // 
            this.ribbonPageGroupNavigation.ItemLinks.Add(this.barSubItemNavigation);
            this.ribbonPageGroupNavigation.Name = "ribbonPageGroupNavigation";
            this.ribbonPageGroupNavigation.Text = "Module";
            // 
            // ribbonPageGroup
            // 
            this.ribbonPageGroup.AllowTextClipping = false;
            this.ribbonPageGroup.ItemLinks.Add(this.skinRibbonGalleryBarItem);
            this.ribbonPageGroup.Name = "ribbonPageGroup";
            this.ribbonPageGroup.ShowCaptionButton = false;
            this.ribbonPageGroup.Text = "Appearance";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 568);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(790, 31);
            // 
            // officeNavigationBar
            // 
            this.officeNavigationBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.officeNavigationBar.Location = new System.Drawing.Point(0, 523);
            this.officeNavigationBar.Name = "officeNavigationBar";
            this.officeNavigationBar.NavigationClient = this.navBarControl;
            this.officeNavigationBar.Size = new System.Drawing.Size(790, 45);
            this.officeNavigationBar.TabIndex = 1;
            this.officeNavigationBar.Text = "officeNavigationBar";
            // 
            // navBarControl
            // 
            this.navBarControl.ActiveGroup = this.employeesNavBarGroup;
            this.navBarControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.employeesNavBarGroup,
            this.customersNavBarGroup,
            this.financeNavBarGroup,
            this.navBarGroup1});
            this.navBarControl.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.memberLstNavBarItm,
            this.newMemberNavBarItm,
            this.suppliersLstNavBarItm,
            this.suppliersNewNavBarItm,
            this.memberTypenavBarItm,
            this.incomeTypeNavBarItm,
            this.outcomeTypeNavBarItm,
            this.navBarItem1,
            this.navBarItem2,
            this.navBarItem3,
            this.variablesNavBarItm});
            this.navBarControl.Location = new System.Drawing.Point(0, 143);
            this.navBarControl.Name = "navBarControl";
            this.navBarControl.OptionsLayout.StoreAppearance = true;
            this.navBarControl.OptionsNavPane.ExpandedWidth = 165;
            this.navBarControl.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl.Size = new System.Drawing.Size(165, 380);
            this.navBarControl.TabIndex = 0;
            this.navBarControl.Text = "navBarControl";
            this.navBarControl.ActiveGroupChanged += new DevExpress.XtraNavBar.NavBarGroupEventHandler(this.navBarControl_ActiveGroupChanged);
            // 
            // employeesNavBarGroup
            // 
            this.employeesNavBarGroup.Caption = "rsMembers";
            this.employeesNavBarGroup.Expanded = true;
            this.employeesNavBarGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.memberLstNavBarItm),
            new DevExpress.XtraNavBar.NavBarItemLink(this.newMemberNavBarItm)});
            this.employeesNavBarGroup.Name = "employeesNavBarGroup";
            // 
            // memberLstNavBarItm
            // 
            this.memberLstNavBarItm.Caption = "rsList";
            this.memberLstNavBarItm.Name = "memberLstNavBarItm";
            this.memberLstNavBarItm.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.linkNavigation_LinkClicked);
            // 
            // newMemberNavBarItm
            // 
            this.newMemberNavBarItm.Caption = "rsNew";
            this.newMemberNavBarItm.Name = "newMemberNavBarItm";
            this.newMemberNavBarItm.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.linkNavigation_LinkClicked);
            // 
            // customersNavBarGroup
            // 
            this.customersNavBarGroup.Caption = "rsSuppliers";
            this.customersNavBarGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.suppliersLstNavBarItm),
            new DevExpress.XtraNavBar.NavBarItemLink(this.suppliersNewNavBarItm)});
            this.customersNavBarGroup.Name = "customersNavBarGroup";
            // 
            // suppliersLstNavBarItm
            // 
            this.suppliersLstNavBarItm.Caption = "rsList";
            this.suppliersLstNavBarItm.Name = "suppliersLstNavBarItm";
            this.suppliersLstNavBarItm.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.linkNavigation_LinkClicked);
            // 
            // suppliersNewNavBarItm
            // 
            this.suppliersNewNavBarItm.Caption = "rsNew";
            this.suppliersNewNavBarItm.Name = "suppliersNewNavBarItm";
            this.suppliersNewNavBarItm.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.linkNavigation_LinkClicked);
            // 
            // financeNavBarGroup
            // 
            this.financeNavBarGroup.Caption = "rsFinance";
            this.financeNavBarGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem1),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem2),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem3)});
            this.financeNavBarGroup.Name = "financeNavBarGroup";
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "rsIncome";
            this.navBarItem1.Name = "navBarItem1";
            this.navBarItem1.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.linkNavigation_LinkClicked);
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "rsOutcome";
            this.navBarItem2.Name = "navBarItem2";
            this.navBarItem2.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.linkNavigation_LinkClicked);
            // 
            // navBarItem3
            // 
            this.navBarItem3.Caption = "rsSummary";
            this.navBarItem3.Name = "navBarItem3";
            this.navBarItem3.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.linkNavigation_LinkClicked);
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "rsParameters";
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.memberTypenavBarItm),
            new DevExpress.XtraNavBar.NavBarItemLink(this.incomeTypeNavBarItm),
            new DevExpress.XtraNavBar.NavBarItemLink(this.outcomeTypeNavBarItm),
            new DevExpress.XtraNavBar.NavBarItemLink(this.variablesNavBarItm)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // memberTypenavBarItm
            // 
            this.memberTypenavBarItm.Caption = "rsMemberType";
            this.memberTypenavBarItm.Name = "memberTypenavBarItm";
            this.memberTypenavBarItm.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.linkNavigation_LinkClicked);
            // 
            // incomeTypeNavBarItm
            // 
            this.incomeTypeNavBarItm.Caption = "rsIncomeType";
            this.incomeTypeNavBarItm.Name = "incomeTypeNavBarItm";
            this.incomeTypeNavBarItm.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.linkNavigation_LinkClicked);
            // 
            // outcomeTypeNavBarItm
            // 
            this.outcomeTypeNavBarItm.Caption = "rsOutcomeType";
            this.outcomeTypeNavBarItm.Name = "outcomeTypeNavBarItm";
            this.outcomeTypeNavBarItm.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.linkNavigation_LinkClicked);
            // 
            // navigationFrame
            // 
            this.navigationFrame.Appearance.BackColor = System.Drawing.Color.White;
            this.navigationFrame.Appearance.Options.UseBackColor = true;
            this.navigationFrame.Controls.Add(this.membersNavigationPage);
            this.navigationFrame.Controls.Add(this.suppliersNavigationPage);
            this.navigationFrame.Controls.Add(this.financeNavigationPage);
            this.navigationFrame.Controls.Add(this.paramsNavigationPage);
            this.navigationFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationFrame.Location = new System.Drawing.Point(165, 143);
            this.navigationFrame.Name = "navigationFrame";
            this.navigationFrame.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.membersNavigationPage,
            this.suppliersNavigationPage,
            this.financeNavigationPage,
            this.paramsNavigationPage});
            this.navigationFrame.RibbonAndBarsMergeStyle = DevExpress.XtraBars.Docking2010.Views.RibbonAndBarsMergeStyle.Always;
            this.navigationFrame.SelectedPage = this.membersNavigationPage;
            this.navigationFrame.Size = new System.Drawing.Size(625, 380);
            this.navigationFrame.TabIndex = 0;
            this.navigationFrame.Text = "navigationFrame";
            // 
            // membersNavigationPage
            // 
            this.membersNavigationPage.Controls.Add(this.employeesLabelControl);
            this.membersNavigationPage.Name = "membersNavigationPage";
            this.membersNavigationPage.Size = new System.Drawing.Size(625, 380);
            // 
            // employeesLabelControl
            // 
            this.employeesLabelControl.Appearance.Font = new System.Drawing.Font("Tahoma", 25.25F);
            this.employeesLabelControl.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.employeesLabelControl.Appearance.Options.UseFont = true;
            this.employeesLabelControl.Appearance.Options.UseForeColor = true;
            this.employeesLabelControl.Appearance.Options.UseTextOptions = true;
            this.employeesLabelControl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.employeesLabelControl.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.employeesLabelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.employeesLabelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeesLabelControl.Location = new System.Drawing.Point(0, 0);
            this.employeesLabelControl.Name = "employeesLabelControl";
            this.employeesLabelControl.Size = new System.Drawing.Size(161, 41);
            this.employeesLabelControl.TabIndex = 0;
            this.employeesLabelControl.Text = "Employees";
            // 
            // suppliersNavigationPage
            // 
            this.suppliersNavigationPage.Controls.Add(this.customersLabelControl);
            this.suppliersNavigationPage.Name = "suppliersNavigationPage";
            this.suppliersNavigationPage.Size = new System.Drawing.Size(625, 380);
            // 
            // customersLabelControl
            // 
            this.customersLabelControl.Appearance.Font = new System.Drawing.Font("Tahoma", 25.25F);
            this.customersLabelControl.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.customersLabelControl.Appearance.Options.UseFont = true;
            this.customersLabelControl.Appearance.Options.UseForeColor = true;
            this.customersLabelControl.Appearance.Options.UseTextOptions = true;
            this.customersLabelControl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.customersLabelControl.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.customersLabelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.customersLabelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customersLabelControl.Location = new System.Drawing.Point(0, 0);
            this.customersLabelControl.Name = "customersLabelControl";
            this.customersLabelControl.Size = new System.Drawing.Size(157, 41);
            this.customersLabelControl.TabIndex = 1;
            this.customersLabelControl.Text = "Customers";
            // 
            // financeNavigationPage
            // 
            this.financeNavigationPage.Name = "financeNavigationPage";
            this.financeNavigationPage.Size = new System.Drawing.Size(625, 380);
            // 
            // paramsNavigationPage
            // 
            this.paramsNavigationPage.Name = "paramsNavigationPage";
            this.paramsNavigationPage.Size = new System.Drawing.Size(625, 380);
            // 
            // variablesNavBarItm
            // 
            this.variablesNavBarItm.Caption = "rsVariables";
            this.variablesNavBarItm.Name = "variablesNavBarItm";
            this.variablesNavBarItm.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.linkNavigation_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 599);
            this.Controls.Add(this.navigationFrame);
            this.Controls.Add(this.navBarControl);
            this.Controls.Add(this.officeNavigationBar);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbonControl);
            this.Name = "MainForm";
            this.Ribbon = this.ribbonControl;
            this.StatusBar = this.ribbonStatusBar;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeNavigationBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame)).EndInit();
            this.navigationFrame.ResumeLayout(false);
            this.membersNavigationPage.ResumeLayout(false);
            this.membersNavigationPage.PerformLayout();
            this.suppliersNavigationPage.ResumeLayout(false);
            this.suppliersNavigationPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupNavigation;
        private DevExpress.XtraBars.BarSubItem barSubItemNavigation;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem;
        private DevExpress.XtraBars.Navigation.OfficeNavigationBar officeNavigationBar;
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame;
        private DevExpress.XtraNavBar.NavBarControl navBarControl;
        private DevExpress.XtraNavBar.NavBarGroup employeesNavBarGroup;
        private DevExpress.XtraNavBar.NavBarGroup customersNavBarGroup;
        private DevExpress.XtraBars.Navigation.NavigationPage membersNavigationPage;
        private DevExpress.XtraEditors.LabelControl employeesLabelControl;
        private DevExpress.XtraBars.Navigation.NavigationPage suppliersNavigationPage;
        private DevExpress.XtraBars.BarButtonItem membersBarButtonItem;
        private DevExpress.XtraBars.BarButtonItem suppliersBarButtonItem;
        private DevExpress.XtraNavBar.NavBarGroup financeNavBarGroup;
        private DevExpress.XtraBars.Navigation.NavigationPage financeNavigationPage;
        private DevExpress.XtraEditors.LabelControl customersLabelControl;
        private DevExpress.XtraNavBar.NavBarItem memberLstNavBarItm;
        private DevExpress.XtraNavBar.NavBarItem newMemberNavBarItm;
        private DevExpress.XtraBars.BarButtonItem financeBarButtonItem;
        private DevExpress.XtraNavBar.NavBarItem suppliersLstNavBarItm;
        private DevExpress.XtraNavBar.NavBarItem suppliersNewNavBarItm;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraBars.Navigation.NavigationPage paramsNavigationPage;
        private DevExpress.XtraNavBar.NavBarItem memberTypenavBarItm;
        private DevExpress.XtraNavBar.NavBarItem incomeTypeNavBarItm;
        private DevExpress.XtraNavBar.NavBarItem outcomeTypeNavBarItm;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
        private DevExpress.XtraNavBar.NavBarItem navBarItem3;
        private DevExpress.XtraNavBar.NavBarItem variablesNavBarItm;
    }
}