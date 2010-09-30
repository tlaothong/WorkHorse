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
using PerfEx.Infrastructure.Mvvm;

namespace Magic9Game
{
    public partial class MainPage : UserControl
    {
        #region Fields
        
        private const string AutoBetOn = "Enable";
        private const string AutoBetOff = "Disable";
        private const string AutoBetStart = "Start";
        private const string AutoBetStop = "Stop";
        private bool _autoBetOn;
        private bool _autoBetStart;

        #endregion Fields

        #region Constructor
        
        public MainPage()
        {
            InitializeComponent();
            MvvmBinder.Bind(this, DataContext);

            AutoBet.Click += new RoutedEventHandler(AutoBet_Click);
            StartStop.Click += new RoutedEventHandler(StartStop_Click);
        }

        #endregion Constructor

        #region Methods

        // auto bet show or hide
        private void AutoBet_Click(object sender, RoutedEventArgs e)
        {
            if (!_autoBetStart) {
                _autoBetOn = !_autoBetOn;
                if (_autoBetOn) changeState(AutoBetOn);
                else changeState(AutoBetOff);
            }
        }

        // auto bet start
        private void StartStop_Click(object sender, RoutedEventArgs e)
        {
            _autoBetStart = !_autoBetStart;
            if (_autoBetStart) changeState(AutoBetStop);
            else {
                changeState(AutoBetStart);
                changeState(AutoBetOff);
                _autoBetOn = !_autoBetOn;
            }
        }

        // change game state
        private void changeState(string stateName)
        {
            VisualStateManager.GoToState(this, stateName, false);
        }

        #endregion Methods
    }
}
