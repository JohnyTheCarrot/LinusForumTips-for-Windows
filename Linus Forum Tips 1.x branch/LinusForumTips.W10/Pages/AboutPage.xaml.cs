using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using LinusForumTips.ViewModels;

namespace LinusForumTips.Pages
{
    public sealed partial class AboutPage : Page
    {
        public AboutPage()
        {
            AboutThisAppModel = new AboutThisAppViewModel();

            this.InitializeComponent();
        }

        public AboutThisAppViewModel AboutThisAppModel { get; private set; }
		
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ShellPage.Current.ShellControl.SelectItem("About");
            base.OnNavigatedTo(e);
        }
    }
}
