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

namespace CasinovaAllStars.Views
{
    public partial class StatisticsWindow : ChildWindow
    {
        public StatisticsWindow()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            infoContentPresenter.Content = null;
            this.DialogResult = false;
        }
    }
}

