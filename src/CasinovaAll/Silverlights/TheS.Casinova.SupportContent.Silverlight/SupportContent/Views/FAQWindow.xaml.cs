﻿using System;
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
    [ExportPopupContent(DisplayText = "FAQ", GroupName = "bottom", Order = 1)]
    public partial class FAQWindow : ChildWindow
    {
        public FAQWindow()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

