using AppStudio.Uwp.Navigation;
using LinusForumTips.Extra_Classes;
using LinusForumTips.Extra_Classes.Dialogs;
using LinusForumTips.Extra_Classes.Exceptions;
using LinusForumTips.Extra_Classes.Settings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LinusForumTips.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {

        BitmapImage image = null;
        static Config c = new Config();
        bool canDoStuff = false;

        public SettingsPage()
        {
            this.InitializeComponent();
            init();
        }

        private async void init()
        {
            try {
                if (!c.getBool("isBGOnPC")) imageView.Source = new BitmapImage(new Uri(c.getString("background"), UriKind.Absolute));
                else
                {
                    StorageFile file = await StorageFile.GetFileFromPathAsync(c.getString("background"));
                    loadImageFromFile(file);
                }
            }
            catch(NullReferenceException ex)
            {
                //c.addDefault("background", "/Assets/Square310x310Logo.scale-100.png");
                init();
            }catch(NoSuchSettingException ex)
            {
                c.addDefault("isBGOnPC", false);
            }
            catch (Exception ex)
            {
                new ExceptionAlert(ex.Message);
                Debug.WriteLine(ex.Data);
            }
            try { opaSlider.Value = c.getFloat("background_opacity"); }catch(NullReferenceException ex) { c.addDefault("background_opacity", 80); }
            canDoStuff = true;
        }

        public async void loadImageFromFile(StorageFile f)
        {
            try
            {
                BitmapImage bitmapImage = new BitmapImage();
                FileRandomAccessStream stream = (FileRandomAccessStream)await f.OpenAsync(FileAccessMode.Read);
                bitmapImage.SetSource(stream);
                image = bitmapImage;
                imageView.Source = image;
            }
            catch(Exception ex) { new ExceptionAlert(ex.Message);  }
        }

        private async void openBtn_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".png");
            openPicker.FileTypeFilter.Add(".gif");
            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                loadImageFromFile(file);
                c.addDefault("background", file.Path);
                c.addDefault("isBGOnPC", true);
            }
            else
            {
                //  
            }
        }

        /*
         * When adding a new page, don't forget Setting.xaml.cs, there's page loading code there too.
         */

        public static bool isSaveLink()
        {
            return Uri.IsWellFormedUriString(c.getString("background"), UriKind.Absolute);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (image == null)
            { 
                var dialog = new MessageDialog("Please choose an image.");
                dialog.Title = "Linus Forum Tips";
                await dialog.ShowAsync();
            }else
            {
                HomePage.setBackgroundImage(image);
                try
                {
                    setBackgrounds();
                } catch (NullReferenceException ex1) {
                    NavigationService.NavigateToPage<LinusTechTipsVideosListPage>(e);
                    NavigationService.NavigateToPage<WanShowArchiveListPage>(e);
                    NavigationService.NavigateToPage<TechquickieVideosListPage>(e);
                    NavigationService.NavigateToPage<ChannelSuperFunVideosListPage>(e);
                    NavigationService.NavigateToPage<BuildGuidesListPage>(e);
                    NavigationService.NavigateToPage<BuildLogsListPage>(e);
                    NavigationService.NavigateToPage<GuidesAndTutorialsListPage>(e);

                    //back to home
                    NavigationService.NavigateToPage<HomePage>(e);
                    try
                    {
                        setBackgrounds();
                    } catch(Exception ex2) { new ExceptionAlert(ex2.Message); }
                } catch (Exception ex)
                {
                    new ExceptionAlert(ex.Message);
                }
            }
        }

        public void setBackgrounds()
        {
            LinusTechTipsVideosListPage.setBackgroundImage(image);
            TechquickieVideosListPage.setBackgroundImage(image);
            WanShowArchiveListPage.setBackgroundImage(image);
            ChannelSuperFunVideosListPage.setBackgroundImage(image);
            BuildGuidesListPage.setBackgroundImage(image);
            BuildLogsListPage.setBackgroundImage(image);
            GuidesAndTutorialsListPage.setBackgroundImage(image);
            HomePage.setBackgroundImage(image);
        }

        /*
         * canDoStuff exists because when I've set the value in XAML to 0.8 it already calls and saves that value before it has a chance to load
         * the saved value
         */

        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (canDoStuff)
            { 
                int OldRange = (100 - 0);
                int NewRange = (1 - 0);
                float val = (float)(((opaSlider.Value - 0) * NewRange) / OldRange) + 0;
                HomePage.getGrid().Background.Opacity = val;
                try { LinusTechTipsVideosListPage.getGrid().Background.Opacity = val; } catch (NullReferenceException ex) { NavigationService.NavigateToPage<LinusTechTipsVideosListPage>(e); }
                try { TechquickieVideosListPage.getGrid().Background.Opacity = val; } catch (NullReferenceException ex) { NavigationService.NavigateToPage<TechquickieVideosListPage>(e); }
                try { WanShowArchiveListPage.getGrid().Background.Opacity = val; } catch (NullReferenceException ex) { NavigationService.NavigateToPage<WanShowArchiveListPage>(e); }
                try { ChannelSuperFunVideosListPage.getGrid().Background.Opacity = val; } catch (NullReferenceException ex) { NavigationService.NavigateToPage<ChannelSuperFunVideosListPage>(e); }
                try { BuildGuidesListPage.getGrid().Background.Opacity = val; } catch (NullReferenceException ex) { NavigationService.NavigateToPage<BuildGuidesListPage>(e); }
                try { BuildLogsListPage.getGrid().Background.Opacity = val; } catch (NullReferenceException ex) { NavigationService.NavigateToPage<BuildLogsListPage>(e); }
                try { GuidesAndTutorialsListPage.getGrid().Background.Opacity = val; } catch (NullReferenceException ex) { NavigationService.NavigateToPage<GuidesAndTutorialsListPage>(e); }
                c.addDefault("background_opacity", opaSlider.Value);
            }
        }

        //URL load button
        private async void Loadbtn_Click(object sender, RoutedEventArgs e)
        {
            c.addDefault("isBGOnPC", false);
            InputDialog dlg = new InputDialog("URL:");
            bool result = await dlg.ShowAsync();
            if (result != false)
            {
                string userInput = dlg.TextBox.Text;
                if(userInput=="")
                {
                    var dialog = new MessageDialog("Please enter the URL of the desired image.");
                    dialog.Title = "Linus Forum Tips";
                    await dialog.ShowAsync();
                    return;
                }
                try {
                    image = new BitmapImage(new Uri(userInput, UriKind.Absolute));
                    imageView.Source = image;
                    c.addDefault("background", userInput);
                    //c.addDefault("isBGOnPC", false);
                } catch (UriFormatException ex) {
                    var dialog = new MessageDialog(userInput + " is not a valid URL.");
                    dialog.Title = "Linus Forum Tips";
                    await dialog.ShowAsync();
                }catch(Exception ex)
                {
                    new ExceptionAlert(ex.Message);
                }
            }
        }

    }
}
