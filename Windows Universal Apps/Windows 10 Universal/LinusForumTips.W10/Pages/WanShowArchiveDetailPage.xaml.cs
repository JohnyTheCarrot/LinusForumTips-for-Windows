//---------------------------------------------------------------------------
//
// <copyright file="WanShowArchiveDetailPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>11/5/2016 9:04:42 AM</createdOn>
//
//---------------------------------------------------------------------------

using System;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using AppStudio.DataProviders.YouTube;
using LinusForumTips.Sections;
using LinusForumTips.Navigation;
using LinusForumTips.ViewModels;
using AppStudio.Uwp;

namespace LinusForumTips.Pages
{
    public sealed partial class WanShowArchiveDetailPage : Page
    {
        private DataTransferManager _dataTransferManager;

        public WanShowArchiveDetailPage()
        {
            ViewModel = ViewModelFactory.NewDetail(new WanShowArchiveSection());
			this.ViewModel.ShowInfo = false;
            this.InitializeComponent();
			commandBar.DataContext = ViewModel;
        }

        public DetailViewModel ViewModel { get; set; }        

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await ViewModel.LoadStateAsync(e.Parameter as NavDetailParameter);

            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;
            ShellPage.Current.SupportFullScreen = true;

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _dataTransferManager.DataRequested -= OnDataRequested;
            ShellPage.Current.SupportFullScreen = false;

            base.OnNavigatedFrom(e);
        }

        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            ViewModel.ShareContent(args.Request);
        }
    }
}
