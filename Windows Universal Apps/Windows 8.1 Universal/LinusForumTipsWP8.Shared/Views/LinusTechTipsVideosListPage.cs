using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.YouTube;
using LinusForumTipsWP8;
using LinusForumTipsWP8.Sections;
using LinusForumTipsWP8.ViewModels;

namespace LinusForumTipsWP8.Views
{
    public sealed partial class LinusTechTipsVideosListPage : PageBase
    {
        public ListViewModel<YouTubeDataConfig, YouTubeSchema> ViewModel { get; set; }

        public LinusTechTipsVideosListPage()
        {
            this.ViewModel = new ListViewModel<YouTubeDataConfig, YouTubeSchema>(new LinusTechTipsVideosConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
