using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppStudio.Common;
using AppStudio.Common.Actions;
using AppStudio.Common.Commands;
using AppStudio.Common.Navigation;
using AppStudio.DataProviders;
using AppStudio.DataProviders.YouTube;
using AppStudio.DataProviders.LocalStorage;
using LinusForumTipsWP8.Sections;


namespace LinusForumTipsWP8.ViewModels
{
    public class MainViewModel : ObservableBase
    {
        public MainViewModel(int visibleItems)
        {
            PageTitle = "Linus Forum Tips WP8";
            LinusTechTipsVideos = new ListViewModel<YouTubeDataConfig, YouTubeSchema>(new LinusTechTipsVideosConfig(), visibleItems);
            WanShowArchive = new ListViewModel<YouTubeDataConfig, YouTubeSchema>(new WanShowArchiveConfig(), visibleItems);
            TechquickieVideos = new ListViewModel<YouTubeDataConfig, YouTubeSchema>(new TechquickieVideosConfig(), visibleItems);
            YouTube = new ListViewModel<YouTubeDataConfig, YouTubeSchema>(new YouTubeConfig(), visibleItems);
            Actions = new List<ActionInfo>();

            if (GetViewModels().Any(vm => !vm.HasLocalData))
            {
                Actions.Add(new ActionInfo
                {
                    Command = new RelayCommand(Refresh),
                    Style = ActionKnownStyles.Refresh,
                    Name = "RefreshButton",
                    ActionType = ActionType.Primary
                });
            }
        }

        public string PageTitle { get; set; }
        public ListViewModel<YouTubeDataConfig, YouTubeSchema> LinusTechTipsVideos { get; private set; }
        public ListViewModel<YouTubeDataConfig, YouTubeSchema> WanShowArchive { get; private set; }
        public ListViewModel<YouTubeDataConfig, YouTubeSchema> TechquickieVideos { get; private set; }
        public ListViewModel<YouTubeDataConfig, YouTubeSchema> YouTube { get; private set; }

        public RelayCommand<INavigable> SectionHeaderClickCommand
        {
            get
            {
                return new RelayCommand<INavigable>(item =>
                    {
                        NavigationService.NavigateTo(item);
                    });
            }
        }

        public DateTime? LastUpdated
        {
            get
            {
                return GetViewModels().Select(vm => vm.LastUpdated)
                            .OrderByDescending(d => d).FirstOrDefault();
            }
        }

        public List<ActionInfo> Actions { get; private set; }

        public bool HasActions
        {
            get
            {
                return Actions != null && Actions.Count > 0;
            }
        }

        public async Task LoadDataAsync()
        {
            var loadDataTasks = GetViewModels().Select(vm => vm.LoadDataAsync());

            await Task.WhenAll(loadDataTasks);

            OnPropertyChanged("LastUpdated");
        }

        private async void Refresh()
        {
            var refreshDataTasks = GetViewModels()
                                        .Where(vm => !vm.HasLocalData)
                                        .Select(vm => vm.LoadDataAsync(true));

            await Task.WhenAll(refreshDataTasks);

            OnPropertyChanged("LastUpdated");
        }

        private IEnumerable<DataViewModelBase> GetViewModels()
        {
            yield return LinusTechTipsVideos;
            yield return WanShowArchive;
            yield return TechquickieVideos;
            yield return YouTube;
        }
    }
}
