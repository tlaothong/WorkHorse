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
    public class MainPage666ViewModel : MainPage66ViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainPage666ViewModel()
        {
            _notify = new PropertyChangedNotifier(this, () => PropertyChanged);

        }

        public void BetTwenty()
        {
            //TODO :
        }
    }
}
