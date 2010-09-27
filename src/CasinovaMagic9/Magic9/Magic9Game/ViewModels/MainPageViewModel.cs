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
using System.Collections.ObjectModel;

namespace Magic9Game.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {

        #region Fields
        public event PropertyChangedEventHandler PropertyChanged;
        private PropertyChangedNotifier _notify;
        private double _pot;
        private double _amount;
        private ObservableCollection<string> _interval;
        private ObservableCollection<double> _betLogData;
        #endregion Fields

        #region Properties
        public ObservableCollection<double> BetLogData
        {
            get { return _betLogData; }
            set
            {
                _betLogData = value;
                _notify.Raise(() => BetLogData);
            }
        }

        public ObservableCollection<string> Interval
        {
            get { return _interval; }
            set
            {
                _interval = value;
                _notify.Raise(() => Interval);
            }
        }

        public double Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                _notify.Raise(() => Amount);
            }
        }

        public double Pot
        {
            get { return _pot; }
            set
            {
                _pot = value;
                _notify.Raise(() => Pot);
            }
        }
        #endregion Properties

        #region Constructor
        public MainPageViewModel()
        {
            _notify = new PropertyChangedNotifier(this, () => PropertyChanged);
            _betLogData = new ObservableCollection<double>();
            Interval = new ObservableCollection<string>();
        }
        #endregion Constructor
    }
}
