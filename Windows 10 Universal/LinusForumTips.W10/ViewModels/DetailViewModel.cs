using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;

using AppStudio.Uwp;
using AppStudio.DataProviders;
using AppStudio.Uwp.Actions;
using AppStudio.Uwp.Cache;
using AppStudio.Uwp.Commands;
using AppStudio.Uwp.DataSync;
using AppStudio.Uwp.Navigation;

using LinusForumTips.Sections;
using LinusForumTips.Services;
using LinusForumTips.Navigation;
using LinusForumTips.Pages;


namespace LinusForumTips.ViewModels
{
    public abstract class DetailViewModel : PageViewModelBase
    {
        private bool _showInfoLastValue;

        public abstract Task LoadStateAsync(NavDetailParameter detailParameter);

        public DetailViewModel(string title, string sectionName)
        {
            Title = title;
            SectionName = sectionName;

            ShowInfo = true;
        }

        public ObservableCollection<ComposedItemViewModel> Items { get; protected set; } = new ObservableCollection<ComposedItemViewModel>();

        #region ShowInfo
        private bool _showInfo;

        public bool ShowInfo
        {
            get { return _showInfo; }
            set { SetProperty(ref _showInfo, value); }
        }
        #endregion


        #region Commands

        public ICommand ShowInfoCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    ShowInfo = !ShowInfo;
                });
            }
        }


        #endregion

        public void ShareContent(DataRequest dataRequest, bool supportsHtml = true)
        {
            //     ShareContent(dataRequest, SelectedItem, supportsHtml);
        }

        public static double GetFontSize()
        {
            if (!ApplicationData.Current.LocalSettings.Values.ContainsKey("DescriptionFontSize"))
            {
                SetFontSize((double)"DescriptionTextSizeNormal".Resource());
            }
            return (double)ApplicationData.Current.LocalSettings.Values["DescriptionFontSize"];
        }

        public static void SetFontSize(double fontsize)
        {
            ApplicationData.Current.LocalSettings.Values["DescriptionFontSize"] = fontsize;
        }

        private void OnEnterFullScreen(object sender, EventArgs e)
        {
            _showInfoLastValue = this.ShowInfo;
            ShowInfo = false;
        }
        /*
                public class DetailViewModel<TSchema> : DetailViewModel where TSchema : SchemaBase
                {
                    public DetailViewModel(Section<TSchema> section) : base(section.DetailPage.Title, section.Name)
                    {
                        _Section = section;
                    }

                    public override async Task LoadStateAsync(NavDetailParameter detailParameter)
                    {
                        try
                        {
                            HasLoadDataErrors = false;
                            IsBusy = true;

                            if (detailParameter != null)
                            {
                                //avoid warning
                                await Task.Run(() => { });

                                ParseItems(detailParameter.Items.OfType<TSchema>(), detailParameter.SelectedId);
                            }
                        }
                        catch (Exception ex)
                        {
                            HasLoadDataErrors = true;
                            Debug.WriteLine(ex.ToString());
                        }
                        finally
                        {
                            IsBusy = false;
                        }
                    }

                    private void ParseItems(IEnumerable<TSchema> items, string selectedId)
                    {
                        foreach (var item in items)
                        {
                            var composedItem = new ComposedItemViewModel
                            {
                                Id = item._id
                            };

                            foreach (var binding in _section.DetailPage.LayoutBindings)
                            {
                                var parsedItem = new ItemViewModel
                                {
                                    Id = item._id
                                };
                                binding(parsedItem, item);

                                composedItem.Add(parsedItem);
                            }

                            composedItem.Actions = _section.DetailPage.Actions
                                                                        .Select(a => new ActionInfo
                                                                        {
                                                                            Command = a.Command,
                                                                            CommandParameter = a.CommandParameter(item),
                                                                            Style = a.Style,
                                                                            Text = a.Text,
                                                                            ActionType = ActionType.Primary
                                                                        })
                                                                        .ToList();

                            Items.Add(composedItem);
                        }
                        if (!string.IsNullOrEmpty(selectedId))
                        {

                        }
                    }
                }
            
            */
    }
}