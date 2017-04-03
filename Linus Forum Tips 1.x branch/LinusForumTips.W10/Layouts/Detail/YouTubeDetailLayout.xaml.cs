using System;
using Windows.Devices.Input;
using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using LinusForumTips.Services;
using System.Diagnostics;
using System.Collections;

namespace LinusForumTips.Layouts.Detail
{
    public sealed partial class YouTubeDetailLayout : BaseDetailLayout
    {
        public YouTubeDetailLayout()
        {
            InitializeComponent();
        }

        private void WebView_Unloaded(object sender, RoutedEventArgs e)
        {
            WebView webView = sender as WebView;
            if (webView != null) webView.NavigateToString(string.Empty);
        }

        public void fixUpLinks()
        {
            string[] list = this.description.Text.Split(' ');
            foreach(string s in list)
            {
                Debug.WriteLine("Word: " + s + "islink: " + isWordString(s));
            }
            Debug.WriteLine(this.description.Text);
        }

        public bool isWordString(string word) 
        {
            return Uri.IsWellFormedUriString(word, UriKind.Absolute);
        }
    }
}
