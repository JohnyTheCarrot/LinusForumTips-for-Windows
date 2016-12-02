using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.YouTube;
using LinusForumTipsWP8;
using LinusForumTipsWP8.Sections;
using LinusForumTipsWP8.ViewModels;

namespace LinusForumTipsWP8.Views
{
    public sealed partial class TechquickieVideosListPage : PageBase
    {
        public ListViewModel<YouTubeDataConfig, YouTubeSchema> ViewModel { get; set; }

        public TechquickieVideosListPage()
        {
            this.ViewModel = new ListViewModel<YouTubeDataConfig, YouTubeSchema>(new TechquickieVideosConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
