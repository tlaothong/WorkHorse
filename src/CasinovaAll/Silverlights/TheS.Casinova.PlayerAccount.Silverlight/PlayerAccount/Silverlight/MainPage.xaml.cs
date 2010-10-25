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
using TheS.Casinova.PlayerAccount.Views;

namespace TheS.Casinova.PlayerAccount.Silverlight
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void AccountManagerButton_Click(object sender, RoutedEventArgs e)
        {
            PlayerAccountManagerWindow pcm = new PlayerAccountManagerWindow();
            pcm.Show();
        }
    }
}
