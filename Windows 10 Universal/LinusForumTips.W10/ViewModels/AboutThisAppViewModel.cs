using System;
using System.Windows.Input;

using Windows.ApplicationModel;
using Windows.UI.Xaml.Media.Imaging;

using AppStudio.Uwp;
using AppStudio.Uwp.Commands;

namespace LinusForumTips.ViewModels
{
    public class AboutThisAppViewModel : PageViewModelBase
    {
		public AboutThisAppViewModel()
        {
            this.AppName = "Linus Forum Tips";
            this.Title = "NavigationPaneAbout".StringResource();
            this.Publisher = "AluminiumTech";
            this.AppVersion = string.Format("{0}.{1}.{2}.{3}", Package.Current.Id.Version.Major, Package.Current.Id.Version.Minor, Package.Current.Id.Version.Build, Package.Current.Id.Version.Revision);
            this.AboutText = "Experience Linus Tech Tips unlike ever before with the unofficial Linus Forum Tip" +
    "s app for Windows 10.";
            this.AppLogo = new BitmapImage(new Uri("ms-appx:///Assets/ApplicationLogo.png"));
            this.Privacy = "https://appstudio.windows.com/home/appprivacyterms";
            this.NewtonsoftWeb = "http://www.newtonsoft.com/json";
        }

		public string AppName { get; set; }
        public string Publisher { get; set; }
        public string AppVersion { get; set; }
        public string AboutText { get; set; }
        public string Privacy { get; set; }
        public string NewtonsoftWeb { get; set; }
        public BitmapImage AppLogo { get; set; }

		private bool _isMoreInfoVisible;
        public bool IsMoreInfoVisible
        {
            get { return _isMoreInfoVisible; }
            set { SetProperty(ref _isMoreInfoVisible, value); }
        }

        private ICommand _viewMoreInfoCommand;
        public ICommand ViewMoreInfoCommand
        {
            get
            {
                if (_viewMoreInfoCommand == null)
                {
                    _viewMoreInfoCommand = new RelayCommand(() => { IsMoreInfoVisible = !IsMoreInfoVisible; });
                }
                return _viewMoreInfoCommand;
            }
        }
    }
}

