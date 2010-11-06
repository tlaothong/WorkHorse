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

namespace TheS.Casinova.PlayerAccount.Controls {
    public partial class InformationUI : UserControl {
        public InformationUI() {
            InitializeComponent();
        }

        private void InformationDepositButton_Click(object sender, RoutedEventArgs e) {
            showChipExchangWindow();
        }

        private void InformationCashbackButton_Click(object sender, RoutedEventArgs e) {
            const int CashBackSelected = 1;
            showChipExchangWindow(CashBackSelected);
        }

        private void showChipExchangWindow(int menuTablSelected = 0) {
            ChipExchange.Views.DepositWindow dw = new ChipExchange.Views.DepositWindow();
            dw.MenuTabControl.SelectedIndex = menuTablSelected;
            dw.Show();
        }

        private void CreditsCardEditHyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            showPayment();
        }

        private void OtherEditHyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            const int OtherEdit = 1;
            showPayment(OtherEdit);
        }

        private void showPayment(int tabSelected = 0)
        {
            var cw = new PaymentWindow();
            cw.PaymentTabControl.SelectedIndex = tabSelected;
            cw.Show();
        }
    }
}
