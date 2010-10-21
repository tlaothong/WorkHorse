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

namespace TheS.Casinova.Colors
{
<<<<<<< HEAD
    //[ExportContentNavigation(GameApplicationInformation.GameInfoNavigationCode)]
    public partial class Page1 : Page
=======
    [ExportContentNavigation(GameApplicationInformation.GameInfoNavigationCode)]
    public partial class Page1 : Page, INavigablePage
>>>>>>> b333ceabf9e9d2d4016704ba05f4bacda2c78794
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page1", UriKind.Relative));
        }

        #region INavigablePage Members

        public new NavigationService NavigationService
        { get; set; }

        public new void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        public new void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
        }

        public new void OnNavigatedFrom(NavigationEventArgs e)
        {
        }

        #endregion
    }
}
