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

namespace TheS.Casinova.TwoWins.ViewModels
{
    public class GamePlayModel : INotifyPropertyChanged
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
                _totalAmountOfWhite = value;
                _notify.Raise(() => TotalAmountOfWhite);
            }
        }

        public string TotalAmountOfBlack
        {
            get { return _totalAmountOfBlack; }
            set
            {
                _totalAmountOfBlack = value;
                _notify.Raise(() => TotalAmountOfBlack);
            }
        }

        public string WinnerInformation
        {
            get { return _winnerInformation; }
            set
            {
                _winnerInformation = value;
                _notify.Raise(() => WinnerInformation);
            }
        }


        public string Winner
        {
            get { return _winner; }
            set
            {
                _winner = value;
                _notify.Raise(() => Winner);
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

        public GamePlayModel()
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
