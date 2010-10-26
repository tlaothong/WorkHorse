using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using TheS.Casinova.Common;

namespace CasinovaAllStars.Views.DynamicViews
{
    public partial class MefPage : Page
    {
        private static readonly NullNavigablePage _NullNavigablePage = new NullNavigablePage();

        private INavigablePage NavigablePage
        {
            get
            {
                if (Content is INavigablePage && Content != null) 
                {
                    return Content as INavigablePage;
                }
                return MefPage._NullNavigablePage;
            }
        } 

        public MefPage()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Content = App.ModuleLoader.GetNavigableContent(NavigableContentHelper.ParseNavigationCode(e.Uri));
            NavigablePage.NavigationService = NavigationService;
            NavigablePage.OnNavigatedTo(e);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            NavigablePage.OnNavigatingFrom(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Content = null;
            base.OnNavigatedFrom(e);
            NavigablePage.OnNavigatedFrom(e);
        }

        private class NullNavigablePage : INavigablePage
        {
            #region INavigablePage Members

            public NavigationService NavigationService
            { get; set; }

            public void OnNavigatedTo(NavigationEventArgs e)
            { }

            public void OnNavigatingFrom(NavigatingCancelEventArgs e)
            { }

            public void OnNavigatedFrom(NavigationEventArgs e)
            { }

            #endregion
        }

    }
}
