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
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.ViewModels
{
    /// <summary>
    /// Game result view model
    /// </summary>
    public class GameResultViewModel : INotifyPropertyChanged
    {
        private PerfEx.Infrastructure.PropertyChangedNotifier _notify;
        private GameResult _result;

        public GameResult Result
        {
            get { return _result; }
            set
            {
                if (_result!=value)
                {
                    _result = value;
                    _notify.Raise(() => Result); 
                }
            }
        }

        /// <summary>
        /// Initialize game result view model
        /// </summary>
        public GameResultViewModel()
        {
            _notify = new PerfEx.Infrastructure.PropertyChangedNotifier(this, () => PropertyChanged);
            _result = new GameResult();
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
