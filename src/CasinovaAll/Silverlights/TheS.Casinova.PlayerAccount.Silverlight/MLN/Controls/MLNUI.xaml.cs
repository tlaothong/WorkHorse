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

namespace TheS.Casinova.MLN.Controls
{
    public partial class MLNUI : UserControl
    {
        public MLNUI()
        {
            InitializeComponent();
        }

        private void DepositButton_Click(object sender, RoutedEventArgs e)
        {
            ChipExchange.Views.DepositWindow dw = new ChipExchange.Views.DepositWindow();
            dw.Show();
        }

        private void FirstView_Click(object sender, RoutedEventArgs e)
        {
            ViewDownlineDetail();
        }

        private void SecondView_Click(object sender, RoutedEventArgs e)
        {
            const int LevelSelect = 1;
            ViewDownlineDetail(LevelSelect);
        }

        private void ThirdView_Click(object sender, RoutedEventArgs e)
        {
            const int LevelSelect = 2;
            ViewDownlineDetail(LevelSelect);
        }

        private void ViewDownlineDetail(int levelSelect = 0)
        {
            Views.DownlineDetailWindow ddw = new Views.DownlineDetailWindow();
            ddw.LevelTabControl.SelectedIndex = levelSelect;
            ddw.Show();
        }
    }
}
