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
using TheS.Casinova.Fortune.ViewModels;
using PerfEx.Infrastructure.Mvvm;
using TheS.Casinova.Common;

namespace TheS.Casinova.Fortune.Views
{
    [ExportPopupContent(DisplayText = "Fortune", GroupName = "buttom", Order = 4)]
    public partial class FortuneWindow : ChildWindow
    {
        public FortuneWindow()
        {
            InitializeComponent();
            MvvmBinder.Bind(this, DataContext);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CardButton_Click(object sender, RoutedEventArgs e)
        {
            ((FortuneViewModel)DataContext).GetCardInformation();
        }
    }
}

