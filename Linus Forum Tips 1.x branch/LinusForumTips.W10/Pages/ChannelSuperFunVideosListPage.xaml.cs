//---------------------------------------------------------------------------
//
// <copyright file="ChannelSuperFunVideosListPage.xaml.cs" company="Microsoft">
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
using System;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Media;

namespace LinusForumTips.Pages
{
    public sealed partial class ChannelSuperFunVideosListPage : Page
    {
        Config c = new Config();
        private static ChannelSuperFunVideosListPage page;

        public ListViewModel ViewModel { get; set; }
        public ChannelSuperFunVideosListPage()
        {
			ViewModel = ViewModelFactory.NewList(new ChannelSuperFunVideosSection());

            this.InitializeComponent();
			commandBar.DataContext = ViewModel;
			NavigationCacheMode = NavigationCacheMode.Enabled;
            page = this;
            init();
        }

        //leave public
        public static Grid getGrid()
        {
            return page.grid;
        }

        private void init()
        {
            BitmapImage image = new BitmapImage(new Uri(c.getString("background"), UriKind.Absolute));
            getGrid().Background = new ImageBrush { ImageSource = image, Stretch = Stretch.None };
        }

        public static void setBackgroundImage(BitmapImage img)
        {
            getGrid().Background = new ImageBrush { ImageSource = img, Stretch = Stretch.None };
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
			ShellPage.Current.ShellControl.SelectItem("5c707716-fb7e-4986-8c3b-6dc9d09ce700");
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
