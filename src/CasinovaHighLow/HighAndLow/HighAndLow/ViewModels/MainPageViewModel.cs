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

namespace HighAndLow.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        #region Fields
        
        public event PropertyChangedEventHandler PropertyChanged;
        private string _winnerHighName;
        private string _winnerHighRange;
        private string _winnerLowName;
        private string _winnerLowRange;
        private string _gameHandsRange;
        private string _gameStatus;
        private DateTime _gameTime;
        private double _pot;
        private PropertyChangedNotifier _notify;
        private ObservableCollection<Models.BetDefinition> _bets; 

        #endregion

        #region Properties

        public string WinnerHighName
        {
            get { return _winnerHighName; }
            set
            {
                _winnerHighName = value;
                _notify.Raise(() => WinnerHighName);
            }
        }
        public string WinnerHighRange
        {
            get { return _winnerHighRange; }
            set
            {
                _winnerHighRange = value;
                _notify.Raise(() => WinnerHighRange);
            }
        }
        public string WinnerLowName
        {
            get { return _winnerLowName; }
            set
            {
                _winnerLowName = value;
                _notify.Raise(() => WinnerLowName);
            }
        }
        public string WinnerLowRange
        {
            get { return _winnerLowRange; }
            set
            {
                _winnerLowRange = value;
                _notify.Raise(() => WinnerLowRange);
            }
        }
        public string GameHandsRange
        {
            get { return _gameHandsRange; }
            set
            {
                _gameHandsRange = value;
                _notify.Raise(() => GameHandsRange);
            }
        }
        public string GameStatus
        {
            get { return _gameStatus; }
            set
            {
                _gameStatus = value;
                _notify.Raise(() => GameStatus);
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
        public double Pot
        {
            get { return _pot; }
            set
            {
                _pot = value;
                _notify.Raise(() => Pot);
            }
        }

        public ObservableCollection<Models.BetDefinition> Bets
        {
            get { return _bets; }
            set
            {
                _bets = value;
                _notify.Raise(() => Bets);
            }
        } 

        #endregion Properties

        #region Constructor

        public MainPageViewModel()
        {
            _notify = new PropertyChangedNotifier(this, () => PropertyChanged);
            _bets = new ObservableCollection<Models.BetDefinition>();
        } 

        #endregion Constructor

        #region Methods

        public void Bet()
        {
            // TODO : Bet action
        }

        #endregion
    }
}
