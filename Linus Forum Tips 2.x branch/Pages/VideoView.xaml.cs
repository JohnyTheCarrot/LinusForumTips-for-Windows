﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Linus_Forum_Tips.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VideoView : Page
    {
        public VideoView()
        {
            this.InitializeComponent();
            setTitle("Title stuff");
            setDescription("Description stuff");
            MySplitView.Visibility = Visibility.Collapsed;
        }

        public void setVideo(String url)
        {
            //TODO: Do stuff
        }

        public void setTitle(String title)
        {
            Title.Text = title;
        }

        public void setDescription(String desc)
        {
            Description.Text = desc;
        }

    }
}
