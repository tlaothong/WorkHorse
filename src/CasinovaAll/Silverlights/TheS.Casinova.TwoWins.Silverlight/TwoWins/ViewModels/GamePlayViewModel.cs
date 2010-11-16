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
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.ViewModels
{
    public class GamePlayViewModel : INotifyPropertyChanged
    {
        #region Fields

        private PropertyChangedNotifier _notify;
        private string _winnerHighName;
        private string _winnerHighRange;
        private string _winnerLowName;
        private string _winnerLowRange;
        private string _gameHandsRange;
        private string _gameStatus;
        private DateTime _gameTime;
        private ObservableCollection<Object> _betLog;
        private ObservableCollection<GameTable> _tables;

        #endregion Fields

        #region Properties

        public ObservableCollection<GameTable> Tables
        {
            get { return _tables; }
            set
            {
                _tables = value;
                _notify.Raise(() => Tables);
            }
        }

        public ObservableCollection<Object> BetLog
        {
            get { return _betLog; }
            set
            {
                _betLog = value;
                _notify.Raise(() => BetLog);
            }
        }

        public DateTime GameTime
        {
            get { return _gameTime; }
            set
            {
                if (_gameTime!=value) {
                    _gameTime = value;
                    _notify.Raise(() => GameTime); 
                }
            }
        }

        public string GameStatus
        {
            get { return _gameStatus; }
            set
            {
                if (_gameStatus!=value) {
                    _gameStatus = value;
                    _notify.Raise(() => GameStatus); 
                }
            }
        }

        public string GameHandsRange
        {
            get { return _gameHandsRange; }
            set
            {
                if (_gameHandsRange!=value) {
                    _gameHandsRange = value;
                    _notify.Raise(() => GameHandsRange); 
                }
            }
        }

        public string WinnerLowRange
        {
            get { return _winnerLowRange; }
            set
            {
                if (_winnerLowRange!=value) {
                    _winnerLowRange = value;
                    _notify.Raise(() => WinnerLowRange); 
                }
            }
        }

        public string WinnerHighRange
        {
            get { return _winnerHighRange; }
            set
            {
                if (_winnerHighRange!=value) {
                    _winnerHighRange = value;
                    _notify.Raise(() => WinnerHighRange); 
                }
            }
        }

        public string WinnerLowName
        {
            get { return _winnerLowName; }
            set
            {
                if (_winnerLowName!=value) {
                    _winnerLowName = value;
                    _notify.Raise(() => WinnerLowName); 
                }
            }
        }

        public string WinnerHighName
        {
            get { return _winnerHighName; }
            set
            {
                if (_winnerHighName!=value) {
                    _winnerHighName = value;
                    _notify.Raise(() => WinnerHighName); 
                }
            }
        }

        #endregion Properties

        #region Constructor

        public GamePlayViewModel()
        {
            _notify = new PropertyChangedNotifier(this, () => PropertyChanged);
            _betLog = new ObservableCollection<object>();
            _tables = new ObservableCollection<GameTable>();

            if (DesignerProperties.IsInDesignTool) {
                Tables.Add(new GameTable {
                    Name = "Two wins",
                    Round = 1,
                    GameTime = new TimeSpan(01,42,35),
                    Pot = 8541234,
                    Amount = 35122,
                    IsPlaying = true
                });
                Tables.Add(new GameTable {
                    Name = "Two wins",
                    Round = 2,
                    GameTime = new TimeSpan(02, 42, 35),
                    Pot = 45923,
                    Amount = 0,
                    IsPlaying = false
                });
                Tables.Add(new GameTable {
                    Name = "Two wins",
                    Round = 3,
                    GameTime = new TimeSpan(03, 42, 35),
                    Pot = 550,
                    IsPlaying = true
                });
                Tables.Add(new GameTable {
                    Name = "Two wins",
                    Round = 4,
                    GameTime = new TimeSpan(04, 42, 35),
                    Pot = 302,
                    IsPlaying = false
                });
                Tables.Add(new GameTable {
                    Name = "Two wins",
                    Round = 5,
                    GameTime = new TimeSpan(05, 42, 35),
                    Pot = 17,
                    Amount = 2,
                    IsPlaying = true
                });
            }
        }

        #endregion Constructor

        #region Methods

        public void Bet()
        {
            //TODO: Create method for Bet 
        }

        #endregion Methods

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged members
    }
}
