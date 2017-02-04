using System;
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
    public sealed partial class ShellPage : Page
    {
        public ShellPage()
        {
            this.InitializeComponent();
            frame.Navigate(typeof(HomePage));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void settings_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(typeof(VideoView));
        }

        private void shows_Click(object sender, RoutedEventArgs e)
        {
            //Change the frame to the Shows frame
            frame.Navigate(typeof(Shows));
            MySplitView.IsPaneOpen = false;
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(typeof(HomePage));
        }
    }
}
