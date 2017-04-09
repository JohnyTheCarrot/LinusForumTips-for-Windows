//---------------------------------------------------------------------------
//
// <copyright file="LinusTechTipsVideosListPage.xaml.cs" company="Microsoft">
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
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using LinusForumTips.Extra_Classes.Settings;
using System;

namespace LinusForumTips.Pages
{
    public sealed partial class LinusTechTipsVideosListPage : Page
    {
        public static LinusTechTipsVideosListPage page;
	    public ListViewModel ViewModel { get; set; }
        public LinusTechTipsVideosListPage()
        {
			ViewModel = ViewModelFactory.NewList(new LinusTechTipsVideosSection());

            this.InitializeComponent();
			commandBar.DataContext = ViewModel;
			NavigationCacheMode = NavigationCacheMode.Enabled;
            page = this;
            init();
        }

        Config c = new Config();
        
        //load the background image and it's settings
        public void init()
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
			ShellPage.Current.ShellControl.SelectItem("d6dd521d-7ebf-474f-9578-547618d29d8b");
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
