using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Navigation;
using AppStudio.DataProviders.YouTube;
using LinusForumTipsWP8;
using LinusForumTipsWP8.Sections;
using LinusForumTipsWP8.ViewModels;

namespace LinusForumTipsWP8.Views

{
    public sealed partial class YouTubeDetailPage : PageBase
    {
        private DataTransferManager _dataTransferManager;
        public DetailViewModel<YouTubeDataConfig, YouTubeSchema> ViewModel { get; set; }

        public YouTubeDetailPage()
               : base(true)
        {
            this.ViewModel = new DetailViewModel<YouTubeDataConfig, YouTubeSchema>(new YouTubeConfig());
            this.InitializeComponent();            
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync(navParameter as ItemViewModel);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _dataTransferManager.DataRequested -= OnDataRequested;

            base.OnNavigatedFrom(e);
        }

        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            bool supportsHtml = true;
#if WINDOWS_PHONE_APP
            supportsHtml = false;
#endif
            ViewModel.ShareContent(args.Request, supportsHtml);
        }
    }
}
