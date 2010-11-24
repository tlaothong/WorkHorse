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

namespace DemoSpecFlow.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private PropertyChangedNotifier _notif;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel()
        {
            _notif = new PropertyChangedNotifier(this, () => PropertyChanged);
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                _notif.Raise(() => Name);
            }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                _notif.Raise(() => Message);
            }
        }

        public void Submit()
        {
            Message = string.Format("Hello, {0}.", Name);
        }
    }
}
