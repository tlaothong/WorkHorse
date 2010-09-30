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
        protected double _amount;
        protected DateTime _interval;
        protected int _repetiton;
        protected PropertyChangedNotifier _notify;

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

        public DateTime Interval
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

        #region Method

        public void ShowBetLogData()
        {
            //TODO :
        }
        
        public void BetOne()
        {
            //TODO : Bet No.1 method
        }

        public void BetFive()
        {
            //TODO : Bet No.5 medtod
        }

        public void ShowAutoBet()
        {
            //TODO :
        }
        
        public void StartAutoBet()
        {
            //TODO :
        }

        public void StopAutoBet()
        {
            //TODO :
        }

        #endregion Method
    }
}
