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
using TheS.Casinova.Colors.Views;
using TheS.Casinova.Common;

namespace TheS.Casinova.Colors.Controls
{
    [ExportStatisticsContent(DisplayText="Colors",Order=2)]
    public partial class GameStatisticsUI : UserControl
    {
        private bool _isRange;

        public GameStatisticsUI()
        {
            InitializeComponent();
        }

        private void OptionButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_isRange) changeState(Range);
            else changeState(Single);
            _isRange = !_isRange;
        }

        private void changeState(VisualState state)
        {
            VisualStateManager.GoToState(this, state.Name, false);
        }

        private void BetDataButton_Click(object sender, RoutedEventArgs e)
        {
            showGameStatisticsWindow();
        }

        private void GraphButton_Click(object sender, RoutedEventArgs e)
        {
            const int GraphSelected = 1;
            showGameStatisticsWindow(GraphSelected);
        }

        private void showGameStatisticsWindow(int tabSelected = 0)
        {
            var cw = new StatisticsChartWindow();
            cw.ContentTabControl.SelectedIndex = tabSelected;
            cw.Show();
        }
    }
}
