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
using TheS.Casinova.Colors.Views;

namespace TheS.Casinova.Colors.Controls
{
    public partial class GameInformationsUI : UserControl
    {
        public GameInformationsUI()
        {
            InitializeComponent();
        }

        private void HowToPlayHyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            HowToPlayWindow htpw = new HowToPlayWindow();
            htpw.Show();
        }
    }
}
