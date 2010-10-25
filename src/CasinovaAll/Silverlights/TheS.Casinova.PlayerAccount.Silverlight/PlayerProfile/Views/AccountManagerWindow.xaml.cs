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

namespace TheS.Casinova.PlayerProfile.Views
{
    public partial class AccountManagerWindow : ChildWindow
    {
        public AccountManagerWindow()
        {
            InitializeComponent();
            AccountInformationContentPresenter.Content= new AccountManagerInformationPage();
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
            ChipExchange.Views.DepositWindow dw = new ChipExchange.Views.DepositWindow();
            dw.MenuTabControl.SelectedIndex = menuTablSelected;
            dw.Show();
        }

        private void MLNDepositButton_Click(object sender, RoutedEventArgs e)
        {
            showChipExchangWindow();
        }
    }
}

