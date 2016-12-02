using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using AppStudio.Common;
using AppStudio.Common.Commands;
using AppStudio.Common.Navigation;
#if WINDOWS_APP
using LinusForumTipsWP8.AppFlyouts;
#endif
using LinusForumTipsWP8.ViewModels;

namespace LinusForumTipsWP8.Commands
{
    public class PlatformCommands
    {

        public static ICommand Privacy
        {
            get
            {
                return new RelayCommand(() =>
                {
#if WINDOWS_APP
                    var flyout = new PrivacyFlyout();
                    flyout.Show();
#endif
#if WINDOWS_PHONE_APP
                    PrivacyViewModel vm = new PrivacyViewModel();
                    NavigationService.NavigateTo(vm.Url).RunAndForget();
#endif

                });
            }
        }
    }
}
