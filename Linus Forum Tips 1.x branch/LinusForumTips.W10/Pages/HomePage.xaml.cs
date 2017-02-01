//---------------------------------------------------------------------------
//
// <copyright file="HomePage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>1/7/2017 1:17:08 AM</createdOn>
//
//---------------------------------------------------------------------------

using System.Windows.Input;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml;

using AppStudio.Uwp;
using AppStudio.Uwp.Commands;
using AppStudio.Uwp.Navigation;

using LinusForumTips.ViewModels;

namespace LinusForumTips.Pages
{
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            ViewModel = new MainViewModel(12);            
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
			commandBar.DataContext = ViewModel;
        }		
        public MainViewModel ViewModel { get; set; }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.ViewModel.LoadDataAsync();
			//Page cache requires set commandBar in code
			ShellPage.Current.ShellControl.SetCommandBar(commandBar);
            ShellPage.Current.ShellControl.SelectItem("Home");
        }

    }
}