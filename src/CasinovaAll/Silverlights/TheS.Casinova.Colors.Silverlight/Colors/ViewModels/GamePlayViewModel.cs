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
using TheS.Casinova.Colors.Models;
using System.Collections.ObjectModel;

namespace TheS.Casinova.TwoWins.ViewModels
{
    public class GamePlayPageViewModel : INotifyPropertyChanged
    {
        #region Fields
        
        private PropertyChangedNotifier _notify;
        private TimeSpan _gameTime;
        private string _winner;
        private string _winnerInformation;
        private string _totalAmountOfBlack;
        private string _totalAmountOfWhite;

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

        public string TotalAmountOfWhite
        {
            get { return _totalAmountOfWhite; }
            set
            {
                if (_totalAmountOfWhite != value) {
                    _totalAmountOfWhite = value;
                    _notify.Raise(() => TotalAmountOfWhite);
                }
            }
        }

        public string TotalAmountOfBlack
        {
            get { return _totalAmountOfBlack; }
            set
            {
                if (_totalAmountOfBlack != value) {
                    _totalAmountOfBlack = value;
                    _notify.Raise(() => TotalAmountOfBlack);
                }
            }
        }

        public string WinnerInformation
        {
            get { return _winnerInformation; }
            set
            {
                if (_winnerInformation != value) {
                    _winnerInformation = value;
                    _notify.Raise(() => WinnerInformation);
                }
            }
        }


        public string Winner
        {
            get { return _winner; }
            set
            {
                if (_winner != value) {
                    _winner = value;
                    _notify.Raise(() => Winner);
                }
            }
        }

        public TimeSpan GameTime
        {
            get { return _gameTime; }
            set
            {
                _gameTime = value;
                _notify.Raise(() => GameTime);
            }
        }

        #endregion Properties

        #region Constructors
        
        public GamePlayPageViewModel()
        {
            _notify = new PropertyChangedNotifier(this, () => PropertyChanged);
            _tables = new ObservableCollection<GameTable>();

            if (DesignerProperties.IsInDesignTool) {
                // Sample tables
                Tables.Add(new GameTable {
                    Name = "Colors",
                    Round = 1,
                    Amount = 0,
                    GameTime = new TimeSpan(0, 17, 7),
                    TotalBetBlack = 0,
                    TotalBetWhite = 0,
                    IsPlaying = false
                });
                Tables.Add(new GameTable {
                    Name = "Colors",
                    Round = 2,
                    Amount = 1,
                    GameTime = new TimeSpan(0, 32, 7),
                    TotalBetBlack = 0,
                    TotalBetWhite = 1,
                    IsPlaying = true
                });
                Tables.Add(new GameTable {
                    Name = "Colors",
                    Round = 3,
                    Amount = 8200,
                    GameTime = new TimeSpan(0, 47, 7),
                    TotalBetBlack = 620,
                    TotalBetWhite = 7580,
                    IsPlaying = true
                });
                Tables.Add(new GameTable {
                    Name = "Colors",
                    Round = 4,
                    Amount = 0,
                    GameTime = new TimeSpan(1, 02, 7),
                    TotalBetBlack = 0,
                    TotalBetWhite = 0,
                    IsPlaying = false
                });
                Tables.Add(new GameTable {
                    Name = "Colors",
                    Round = 5,
                    Amount = 450,
                    GameTime = new TimeSpan(1, 17, 7),
                    TotalBetBlack = 10,
                    TotalBetWhite = 440,
                    IsPlaying = true
                });
            }
        }

        #endregion Constructors

        #region Methods

        public void BetBlack()
        {
            // TODO : BetBlack clicked
            MessageBox.Show("A");
        }

        public void BetWhite()
        {
            // TODO : BetWhite clicked
        }

        #endregion Methods

        #region INotifyPropertyChanged member

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged member
    }
}
