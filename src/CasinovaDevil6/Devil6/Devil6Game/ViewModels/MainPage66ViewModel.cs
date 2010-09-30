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
using PerfEx.Infrastructure;
using System.ComponentModel;

namespace Devil6Game.ViewModels
{
    public class MainPage66ViewModel : MainPageViewModel
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public MainPage66ViewModel()
        {
            _notify = new PropertyChangedNotifier(this, () => PropertyChanged);
        }

        public void BetTen()
        {
            //TODO :
        }

        
    }
}
