//---------------------------------------------------------------------------
//
// <copyright file="AboutPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>12/20/2016 2:44:50 AM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using LinusForumTips.ViewModels;

namespace LinusForumTips.Pages
{
    public sealed partial class AboutPage : Page
    {
        public AboutPage()
        {
            AboutThisAppModel = new AboutThisAppViewModel();

            this.InitializeComponent();
        }

        public AboutThisAppViewModel AboutThisAppModel { get; private set; }
		
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ShellPage.Current.ShellControl.SelectItem("About");
            base.OnNavigatedTo(e);
        }
    }
}
