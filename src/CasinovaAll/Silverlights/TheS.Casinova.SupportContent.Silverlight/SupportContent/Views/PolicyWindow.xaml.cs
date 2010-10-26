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

namespace TheS.Casinova.SupportContent.Views
{
    [ExportPopupContent(DisplayText = "Policy", GroupName = "buttom", Order = 2)]
    public partial class PolicyWindow : ChildWindow
    {
        public PolicyWindow()
        {
            InitializeComponent();
        }
        
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

