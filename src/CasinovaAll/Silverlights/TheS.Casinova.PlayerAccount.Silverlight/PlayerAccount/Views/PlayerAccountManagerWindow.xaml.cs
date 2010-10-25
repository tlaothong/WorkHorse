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

namespace TheS.Casinova.PlayerAccount.Views
{
    public partial class PlayerAccountManagerWindow : ChildWindow
    {
        private bool _isSingleSearchOption;

        public PlayerAccountManagerWindow()
        {
            InitializeComponent();
            AccountInformationContentPresenter.Content = new PlayerInformationPage();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void InformationDepositButton_Click(object sender, RoutedEventArgs e)
        {
            showChipExchangWindow();
        }

        private void InformationCashbackButton_Click(object sender, RoutedEventArgs e)
        {
            const int CashBackSelected = 1;
            showChipExchangWindow(CashBackSelected);
        }

        private void showChipExchangWindow(int menuTablSelected = 0)
        {
            ChipExchange.Views.ChipExchangeWindow cew = new ChipExchange.Views.ChipExchangeWindow();
            cew.MenuTabControl.SelectedIndex = menuTablSelected;
            cew.Show();
        }

        private void LogEventOptionButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO : Change search option state
            const string SingleSearchOption = "Single";
            const string RangeSearchOption = "Range";

            if (!_isSingleSearchOption) VisualStateManager.GoToState(this, RangeSearchOption, false);
            else VisualStateManager.GoToState(this, SingleSearchOption, false);

            _isSingleSearchOption = !_isSingleSearchOption;
        }
    }
}

