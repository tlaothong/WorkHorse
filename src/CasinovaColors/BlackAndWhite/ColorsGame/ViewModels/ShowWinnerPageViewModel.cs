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

namespace ColorsGame.ViewModels
{
    public class ShowWinnerPageViewModel:INotifyPropertyChanged
    {
        private PropertyChangedNotifier _notif;

        public event PropertyChangedEventHandler PropertyChanged;

        public ShowWinnerPageViewModel()
        {
            _notif = new PropertyChangedNotifier(this, () => PropertyChanged);
        }
    }
}
