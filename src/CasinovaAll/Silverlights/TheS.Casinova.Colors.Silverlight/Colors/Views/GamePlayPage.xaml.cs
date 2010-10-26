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
using System.Windows.Navigation;
using TheS.Casinova.Common;
using PerfEx.Infrastructure.Mvvm;

namespace TheS.Casinova.TwoWins.Views
{
    [ExportContentNavigation(GameApplicationInformation.GameInfoNavigationCode)]
    public partial class GamePlayPage : Page
    {
        public GamePlayPage()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

    }
}
