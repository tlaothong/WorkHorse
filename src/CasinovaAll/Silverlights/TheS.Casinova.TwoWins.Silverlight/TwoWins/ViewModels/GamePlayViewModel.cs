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

namespace TheS.Casinova.TwoWins.ViewModels
{
    public class GamePlayViewModel : INotifyPropertyChanged
    {
        #region Fields

        public event PropertyChangedEventHandler PropertyChanged;
        private PropertyChangedNotifier _notify;
        private string _winnerHigh;
        private string _winnerLow;
        private int _handRange;
        private double _pot;
        private DateTime _gameTime;
        private ObservableCollection<DateTime> _handTime;
        private ObservableCollection<double> _hand;
        private ObservableCollection<bool> _status;

        #endregion Fields

        #region Properties

        public string WinnerHigh
        {
            get { return _winnerHigh; }
            set
            {
                _winnerHigh = value;
                _notify.Raise(() => WinnerHigh);
            }
        }

        public string WinnerLow
        {
            get { return _winnerLow; }
            set
            {
                _winnerLow = value;
                _notify.Raise(() => WinnerLow);
            }
        }

        public DateTime GameTime
        {
            get { return _gameTime; }
            set
            {
                _gameTime = value;
                _notify.Raise(() => GameTime);
            }
        }

        public int HandRange
        {
            get { return _handRange; }
            set
            {
                _handRange = value;
                _notify.Raise(() => HandRange);

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


        public ObservableCollection<DateTime> HandTime
        {
            get { return _handTime; }
            set
            {
                _handTime = value;
                _notify.Raise(() => HandTime);
            }
        }


        public ObservableCollection<double> Hand
        {
            get { return _hand; }
            set
            {
                _hand = value;
                _notify.Raise(() => Hand);
            }
        }


        public ObservableCollection<bool> Status
        {
            get { return _status; }
            set
            {
                _status = value;
                _notify.Raise(() => Status);
            }
        }

        #endregion Properties

        public GamePlayViewModel()
        {
            _notify = new PropertyChangedNotifier(this, () => PropertyChanged);
        }

        public void Bet()
        {
            //TODO: Create method for Bet 
        }
    }
}
