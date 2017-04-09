using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace LinusForumTips.Extra_Classes
{
    class ExceptionAlert
    {
        public ExceptionAlert(String message)
        {
            showAlert(message);
        }

        public async void showAlert(String message)
        {
            var dialog = new MessageDialog("An error occurred, please contact the developers and issue a bug report, be sure to include the following: " + message);
            dialog.Title = "Linus Forum Tips";
            await dialog.ShowAsync();
        }

    }
}
