//---------------------------------------------------------------------------
//
// <copyright file="BuildLogsListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>1/7/2017 1:17:08 AM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml;
using AppStudio.DataProviders.YouTube;
using LinusForumTips.Sections;
using LinusForumTips.ViewModels;
using AppStudio.Uwp;
using LinusForumTips.Extra_Classes.Settings;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Media;
using System;

namespace LinusForumTips.Pages
{
    public sealed partial class BuildLogsListPage : Page
    {
        private static BuildLogsListPage page;
        Config c = new Config();

        public ListViewModel ViewModel { get; set; }
        public BuildLogsListPage()
        {
			ViewModel = ViewModelFactory.NewList(new BuildLogsSection());

            this.InitializeComponent();
			commandBar.DataContext = ViewModel;
			NavigationCacheMode = NavigationCacheMode.Enabled;
            page = this;
            init();
        }


        private void init()
        {
            BitmapImage image = new BitmapImage(new Uri(c.getString("background"), UriKind.Absolute));
            getGrid().Background = new ImageBrush { ImageSource = image, Stretch = Stretch.None };
        }

        public static Grid getGrid()
        {
            return page.grid;
        }

        public static void setBackgroundImage(BitmapImage img)
        {
            getGrid().Background = new ImageBrush { ImageSource = img, Stretch = Stretch.None };
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
			ShellPage.Current.ShellControl.SelectItem("c4cea27e-34d3-4a23-b659-d0fa31bec5f2");
			ShellPage.Current.ShellControl.SetCommandBar(commandBar);
			if (e.NavigationMode == NavigationMode.New)
            {			
				await this.ViewModel.LoadDataAsync();
                this.ScrollToTop();
			}			
            base.OnNavigatedTo(e);
        }

    }
}
