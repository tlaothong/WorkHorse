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
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private double _amount;
        private DateTime _interval;
        private int _repetiton;
        private PropertyChangedNotifier _notify;

        #region Properties
        
        public double Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                _notify.Raise(() => _amount);
            }
        }

        public int Interval
        {
            get { return _interval; }
            set
            {
                _interval = value;
                _notify.Raise(() => _interval);
            }
        }

        public int Repetiton
        {
            get { return _repetiton; }
            set
            {
                _repetiton = value;
                _notify.Raise(() => _repetiton);
            }
        }

        #endregion Properties

        public MainPageViewModel()
        {
            _notify = new PropertyChangedNotifier(this, () => PropertyChanged);

        }

        public void BetOne()
        {
            //TODO :
        }

        public void BetFive()
        {
            //TODO :
        }

        public void AutoBet()
        {
            //TODO :
        }
    }
}
