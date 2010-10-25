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

namespace TheS.Casinova.Colors.ViewModels
{
    public class GamePlayPageViewModel : INotifyPropertyChanged
    {
        private PropertyChangedNotifier _notify;
        private TimeSpan _gameTime;
        private string _winner;
        private string _winnerInformation;
        private string _totalAmountOfBlack;
        private string _totalAmountOfWhite;

        public string TotalAmountOfWhite
        {
            get { return _totalAmountOfWhite; }
            set
            {
                if (_totalAmountOfWhite!=value) {
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
                if (_totalAmountOfBlack!=value) {
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
                if (_winnerInformation!=value) {
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
                if (_winner!=value) {
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

        public GamePlayPageViewModel()
        {
            _notify = new PropertyChangedNotifier(this, () => PropertyChanged);
        }

        public void BetBlack()
        {
            // TODO : BetBlack clicked
            MessageBox.Show("A");
        }

        public void BetWhite()
        {
            // TODO : BetWhite clicked
        }

        #region INotifyPropertyChanged member

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged member
    }
}
