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
using System.Collections.ObjectModel;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.ViewModels
{
    /// <summary>
    /// ViewModel ของหน้าสถิติ
    /// </summary>
    public class GameStatisticsViewModel : INotifyPropertyChanged
    {
        #region Fields

        private PerfEx.Infrastructure.PropertyChangedNotifier _notify;
        private DateTime _firstData;
        private DateTime _secondData;
        private GameResult _result;

        #endregion Fields

        #region Properties

        public DateTime SecondData
        {
            get { return _secondData; }
            set
            {
                if (_secondData!=value) {
                    _secondData = value;
                    _notify.Raise(() => SecondData); 
                }
            }
        }

        public DateTime FirstData
        {
            get { return _firstData; }
            set
            {
                if (_firstData!=value) {
                    _firstData = value;
                    _notify.Raise(() => FirstData); 
                }
            }
        }

        public GameResult GameResult
        {
            get { return _result; }
            set
            {
                if (_result!=value)
                {
                    _result = value;
                    _notify.Raise(() => GameResult); 
                }
            }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initialize game statistics view model
        /// </summary>
        public GameStatisticsViewModel()
        {
            _notify = new PerfEx.Infrastructure.PropertyChangedNotifier(this, () => PropertyChanged);
            _result = new GameResult();

            #region Designer view
            
            if (DesignerProperties.IsInDesignTool)
            {
                GameResult = new GameResult
                {
                        Winner = "Balck",
                        BlackPot = 456781,
                        WhitePot = 12314,
                        Hands = 1254 
                };
            }

            #endregion Designer view
        }

        #endregion Constructors

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged members
    }
}
