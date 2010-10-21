using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;
using PerfEx.Infrastructure;

namespace Devil6Game.ViewModels
{
    public class MainPage6666ViewModel : MainPage666ViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// กำหนดค่าเริ่มต้นของ Main page view model
        /// </summary>
        public MainPage6666ViewModel()
        {
            _notify = new PropertyChangedNotifier(this, () => PropertyChanged);
        }
        
        /// <summary>
        /// Bet หมายเลข 50
        /// </summary>
        public void BetFifty()
        {
            //TODO :
        }

        /// <summary>
        /// Bet หมายเลข 100
        /// </summary>
        public void BetOneHundred()
        {
            //TODO :
        }

        /// <summary>
        /// Bet หมายเลข 500
        /// </summary>
        public void BetFifHundred()
        {
            //TODO :
        }
    }
}
