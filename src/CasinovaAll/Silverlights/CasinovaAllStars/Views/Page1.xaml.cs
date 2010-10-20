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
using CasinovaAllStars.ViewModels;

namespace CasinovaAllStars.Views
{
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //txt.Text = ((Page1ViewModel)DataContext).Popups.Count.ToString();
        }

        private void ShowWindow_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            ((Page1ViewModel)DataContext).ShowWindow();
        }

    }
}
