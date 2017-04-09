using LinusForumTips.Pages.ForFrames;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LinusForumTips.Pages.SettingsPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsHolder : Page
    {

        public SettingsHolder()
        {
            this.InitializeComponent();
            frame.Navigate(new Settings().GetType());
        }

        private void BgSettings_Tapped(object sender, TappedRoutedEventArgs e)
        {
            frame.Navigate(new SettingsPage().GetType());
        }

        private void VisibilitySettings_Tapped(object sender, TappedRoutedEventArgs e)
        {
            frame.Navigate(new Settings().GetType());
        }
    }
}
