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

        public MainPage6666ViewModel()
        {
            _notify = new PropertyChangedNotifier(this, () => PropertyChanged);
        }

        public void BetFifty()
        {
            //TODO :
        }

        public void BetOneHundred()
        {
            //TODO :
        }

        public void BetFifHundred()
        {
            //TODO :
        }
    }
}
