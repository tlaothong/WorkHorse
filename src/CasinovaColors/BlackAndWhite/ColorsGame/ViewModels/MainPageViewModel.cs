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

namespace ColorsGame.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private PropertyChangedNotifier _notif;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel()
        {
            _notif = new PropertyChangedNotifier(this, () => PropertyChanged);
        }
    }
}
