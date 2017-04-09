using AppStudio.Uwp.Navigation;
using LinusForumTips.Extra_Classes.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LinusForumTips.Pages.ForFrames
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Settings : Page
    {
        public static ShellPage Current { get; private set; }
        Config c = new Config();

        public Settings()
        {
            this.InitializeComponent();
            init();
        }

        bool canDoStuff = false;
        public void init()
        {
            try
            {
                Toggle_LinusTechTips.IsOn = Boolean.Parse(c.getString("Show_LinusTechTips"));
                Toggle_WanShowArchive.IsOn = Boolean.Parse(c.getString("Show_WanShowArchive"));
                Toggle_Techquicky.IsOn = Boolean.Parse(c.getString("Show_Techquicky"));
                Toggle_ChannelSuperFun.IsOn = Boolean.Parse(c.getString("Show_ChannelSuperFun"));
                Toggle_BuildGuides.IsOn = Boolean.Parse(c.getString("Show_BuildGuides"));
                Toggle_BuildLogs.IsOn = Boolean.Parse(c.getString("Show_BuildLogs"));
                Toggle_GuidesAndTutorials.IsOn = Boolean.Parse(c.getString("Show_GuidesAndTutorials"));
            }
            catch (NullReferenceException ex) { initAllSaves(); }   
            canDoStuff = true;
            int OldRange = (100 - 0);
            int NewRange = (1 - 0);
            float val = (float)(((c.getFloat("background_opacity") - 0) * NewRange) / OldRange) + 0;
            HomePage.getGrid().Background.Opacity = val;
            try { LinusTechTipsVideosListPage.getGrid().Background.Opacity = val; } catch (NullReferenceException ex) { NavigationService.NavigateToPage<LinusTechTipsVideosListPage>(); }
            try { TechquickieVideosListPage.getGrid().Background.Opacity = val; } catch (NullReferenceException ex) { NavigationService.NavigateToPage<TechquickieVideosListPage>(); }
            try { WanShowArchiveListPage.getGrid().Background.Opacity = val; } catch (NullReferenceException ex) { NavigationService.NavigateToPage<WanShowArchiveListPage>(); }
            try { ChannelSuperFunVideosListPage.getGrid().Background.Opacity = val; } catch (NullReferenceException ex) { NavigationService.NavigateToPage<ChannelSuperFunVideosListPage>(); }
            try { BuildGuidesListPage.getGrid().Background.Opacity = val; } catch (NullReferenceException ex) { NavigationService.NavigateToPage<BuildGuidesListPage>(); }
            try { BuildLogsListPage.getGrid().Background.Opacity = val; } catch (NullReferenceException ex) { NavigationService.NavigateToPage<BuildLogsListPage>(); }
            try { GuidesAndTutorialsListPage.getGrid().Background.Opacity = val; } catch (NullReferenceException ex) { NavigationService.NavigateToPage<GuidesAndTutorialsListPage>(); }
            //update
        }

        public void initAllSaves()
        {
            c.addDefault("Show_LinusTechTips", "" + true);
            c.addDefault("Show_WanShowArchive", "" + true);
            c.addDefault("Show_Techquicky", "" + true);
            c.addDefault("Show_ChannelSuperFun", "" + true);
            c.addDefault("Show_BuildGuides", "" + true);
            c.addDefault("Show_BuildLogs", "" + true);
            c.addDefault("Show_GuidesAndTutorials", "" + true);
        }

        /*
         *
         *NOTE:
         * The onclicks are called on startup!
         * DO NOT remove the canDoStuff boolean and it's surroundings!!
         * 
         */

        private void LinusTechTips(object sender, RoutedEventArgs e)
        {
            if (canDoStuff)
            {
                c.addDefault("Show_LinusTechTips", "" + Toggle_LinusTechTips.IsOn);
                ShellPage.Current.showLTTV = Toggle_LinusTechTips.IsOn;
                ShellPage.Current.Refresh();
            }
        }

        private void WanShowArchive(object sender, RoutedEventArgs e)
        {
            if (canDoStuff)
            {
                c.addDefault("Show_WanShowArchive", "" + Toggle_WanShowArchive.IsOn);
                ShellPage.Current.showWSA = Toggle_WanShowArchive.IsOn;
                ShellPage.Current.Refresh();
            }
        }

        private void Techquicky(object sender, RoutedEventArgs e)
        {
            if (canDoStuff)
            {
                c.addDefault("Show_Techquicky", "" + Toggle_Techquicky.IsOn);
                ShellPage.Current.showTech = Toggle_Techquicky.IsOn;
                ShellPage.Current.Refresh();
            }
        }

        private void ChannelSuperFun(object sender, RoutedEventArgs e)
        {
            if (canDoStuff)
            {
                c.addDefault("Show_ChannelSuperFun", "" + Toggle_ChannelSuperFun.IsOn);
                ShellPage.Current.showCSFV = Toggle_ChannelSuperFun.IsOn;
                ShellPage.Current.Refresh();
            }
        }

        private void BuildGuides(object sender, RoutedEventArgs e)
        {
            if (canDoStuff)
            {
                c.addDefault("Show_BuildGuides", "" + Toggle_BuildGuides.IsOn);
                ShellPage.Current.showBG = Toggle_BuildGuides.IsOn;
                ShellPage.Current.Refresh();
            }
        }

        private void BuildLogs(object sender, RoutedEventArgs e)
        {
            if (canDoStuff)
            {
                c.addDefault("Show_BuildLogs", "" + Toggle_BuildLogs.IsOn);
                ShellPage.Current.showBL = Toggle_BuildLogs.IsOn;
                ShellPage.Current.Refresh();
            }
        }

        private void GuidesAndTutorials(object sender, RoutedEventArgs e)
        {
            if (canDoStuff)
            {
                c.addDefault("Show_GuidesAndTutorials", "" + Toggle_GuidesAndTutorials.IsOn);
                ShellPage.Current.showGAT = Toggle_GuidesAndTutorials.IsOn;
                ShellPage.Current.Refresh();
            }
        }
    }
}
