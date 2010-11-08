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
using TheS.Casinova.Common;
using TheS.Casinova.PlayerAccount.Views;

namespace TheS.Casinova.ChipExchange.Views
{
    [ExportPopupContent(DisplayText = "Deposit", GroupName = "top", Order = 1)]
    public partial class DepositWindow : ChildWindow
    {
        public DepositWindow()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void DepositEditButton_Click(object sender, RoutedEventArgs e)
        {
            var cw = new PaymentWindow();
            cw.Show();
        }

        private void CashbackOKButton_Click(object sender, RoutedEventArgs e)
        {
            showAmountConfirmation();
        }

        private void VoucherOKButton_Click(object sender, RoutedEventArgs e)
        {
            showAmountConfirmation();
        }

        private void showAmountConfirmation()
        {
            var cw = new AmountConfirmationWindow();
            cw.Show();
        }
    }
}

