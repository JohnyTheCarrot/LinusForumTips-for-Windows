using System;
using System.Collections.Generic;
using AppStudio.Uwp;
using AppStudio.Uwp.Commands;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LinusForumTips.Sections;
namespace LinusForumTips.ViewModels
{
    public class SearchViewModel : PageViewModelBase
    {
        public SearchViewModel() : base()
        {
			Title = "Linus Forum Tips";
            LinusTechTipsVideos = ViewModelFactory.NewList(new LinusTechTipsVideosSection());
            WanShowArchive = ViewModelFactory.NewList(new WanShowArchiveSection());
            TechquickieVideos = ViewModelFactory.NewList(new TechquickieVideosSection());
            ChannelSuperFunVideos = ViewModelFactory.NewList(new ChannelSuperFunVideosSection());
            BuildGuides = ViewModelFactory.NewList(new BuildGuidesSection());
            BuildLogs = ViewModelFactory.NewList(new BuildLogsSection());
            GuidesAndTutorials = ViewModelFactory.NewList(new GuidesAndTutorialsSection());
                        
        }

        private string _searchText;
        private bool _hasItems = true;

        public string SearchText
        {
            get { return _searchText; }
            set { SetProperty(ref _searchText, value); }
        }

        public bool HasItems
        {
            get { return _hasItems; }
            set { SetProperty(ref _hasItems, value); }
        }

		public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand<string>(
                async (text) =>
                {
                    await SearchDataAsync(text);
                }, SearchViewModel.CanSearch);
            }
        }      
        public ListViewModel LinusTechTipsVideos { get; private set; }
        public ListViewModel WanShowArchive { get; private set; }
        public ListViewModel TechquickieVideos { get; private set; }
        public ListViewModel ChannelSuperFunVideos { get; private set; }
        public ListViewModel BuildGuides { get; private set; }
        public ListViewModel BuildLogs { get; private set; }
        public ListViewModel GuidesAndTutorials { get; private set; }
        public async Task SearchDataAsync(string text)
        {
            this.HasItems = true;
            SearchText = text;
            var loadDataTasks = GetViewModels()
                                    .Select(vm => vm.SearchDataAsync(text));

            await Task.WhenAll(loadDataTasks);
			this.HasItems = GetViewModels().Any(vm => vm.HasItems);
        }

        private IEnumerable<ListViewModel> GetViewModels()
        {
            yield return LinusTechTipsVideos;
            yield return WanShowArchive;
            yield return TechquickieVideos;
            yield return ChannelSuperFunVideos;
            yield return BuildGuides;
            yield return BuildLogs;
            yield return GuidesAndTutorials;
        }
		private void CleanItems()
        {
            foreach (var vm in GetViewModels())
            {
                vm.CleanItems();
            }
        }
		public static bool CanSearch(string text) { return !string.IsNullOrWhiteSpace(text) && text.Length >= 3; }
    }
}
