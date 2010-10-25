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

namespace TheS.Casinova.Colors.Popups
{
    [ExportPopupContent(DisplayText = "Just a Test", GroupName = "top", Order = 1)]
    public partial class ChildWindow1 : ChildWindow
    {
        public ChildWindow1()
        {
            InitializeComponent();
        }

        private void BetDataButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void GraphButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

