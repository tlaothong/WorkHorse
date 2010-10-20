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
        public MefPage()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Content = App.ModuleLoader.GetNavigableContent(NavigableContentHelper.ParseNavigationCode(e.Uri));
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Content = null;
            base.OnNavigatedFrom(e);
        }

    }
}
