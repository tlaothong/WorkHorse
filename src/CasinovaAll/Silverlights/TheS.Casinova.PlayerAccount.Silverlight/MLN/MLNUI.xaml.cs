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
using TheS.Casinova.ChipExchange.Views;

namespace TheS.Casinova.MLN
{
    public partial class MLNUI : UserControl
    {
        public MLNUI()
        {
            InitializeComponent();
        }

        private void MLNDepositButton_Click(object sender, RoutedEventArgs e)
        {
            DepositWindow dw = new DepositWindow();
            dw.Show();
        }

        private void FirstViewButton_Click(object sender, RoutedEventArgs e)
        {
            showMLNLevelInformation();
        }

        private void SecondViewButton_Click(object sender, RoutedEventArgs e)
        {
            const int SecondTablSelect = 1;
            showMLNLevelInformation(SecondTablSelect);
        }

        private void ThirdViewButton_Click(object sender, RoutedEventArgs e)
        {
            const int ThirdTablSelect = 2;
            showMLNLevelInformation(ThirdTablSelect);
        }

        private void showMLNLevelInformation(int menuTablSelected = 0)
        {
            // TODO : showMLNLevelInformation
            MLNDownLineDetailWindow mw = new MLNDownLineDetailWindow();
            mw.Show();
        }

    }
}
