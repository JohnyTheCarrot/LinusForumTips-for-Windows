﻿#pragma checksum "C:\Users\alast\Documents\GitHub\Linus-Forum-Tips\Windows Universal Apps\Windows 10 Universal\LinusForumTips.W10\Pages\LinusTechTipsVideosDetailPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CB6D7CEDB578BB147D661498D3ADB0FE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LinusForumTips.Pages
{
    partial class LinusTechTipsVideosDetailPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        internal class XamlBindingSetters
        {
            public static void Set_LinusForumTips_Layouts_Detail_BaseDetailLayout_ViewModel(global::LinusForumTips.Layouts.Detail.BaseDetailLayout obj, global::LinusForumTips.ViewModels.DetailViewModel value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::LinusForumTips.ViewModels.DetailViewModel) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::LinusForumTips.ViewModels.DetailViewModel), targetNullValue);
                }
                obj.ViewModel = value;
            }
        };

        private class LinusTechTipsVideosDetailPage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            ILinusTechTipsVideosDetailPage_Bindings
        {
            private global::LinusForumTips.Pages.LinusTechTipsVideosDetailPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::LinusForumTips.Layouts.Detail.YouTubeDetailLayout obj3;

            public LinusTechTipsVideosDetailPage_obj1_Bindings()
            {
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 3:
                        this.obj3 = (global::LinusForumTips.Layouts.Detail.YouTubeDetailLayout)target;
                        break;
                    default:
                        break;
                }
            }

            // ILinusTechTipsVideosDetailPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            // LinusTechTipsVideosDetailPage_obj1_Bindings

            public void SetDataRoot(global::LinusForumTips.Pages.LinusTechTipsVideosDetailPage newDataRoot)
            {
                this.dataRoot = newDataRoot;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::LinusForumTips.Pages.LinusTechTipsVideosDetailPage obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel(obj.ViewModel, phase);
                    }
                }
            }
            private void Update_ViewModel(global::LinusForumTips.ViewModels.DetailViewModel obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    XamlBindingSetters.Set_LinusForumTips_Layouts_Detail_BaseDetailLayout_ViewModel(this.obj3, obj, null);
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.root = (global::Windows.UI.Xaml.Controls.Page)(target);
                }
                break;
            case 2:
                {
                    this.commandBar = (global::AppStudio.Uwp.Actions.ActionsCommandBar)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    LinusTechTipsVideosDetailPage_obj1_Bindings bindings = new LinusTechTipsVideosDetailPage_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            }
            return returnValue;
        }
    }
}

