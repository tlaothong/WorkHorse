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
        private DateTime _firstDateTime;
        private DateTime _secondDateTime;
        private int _firstRoundID;
        private int _secondRoundID;
        private GameResult _result;

        #endregion Fields

        #region Properties

        /// <summary>
        /// ผมสรุปการเล่นเกม
        /// </summary>
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
                        BlackPot = "456781",
                        WhitePot = "12314",
                        Hands = 1254 
                };
            }

            #endregion Designer view
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// เรียกดูข้อมูลผลสรุปการเล่นเกมที่กำหนด
        /// </summary>
        public void GetGameResult()
        {
            // TODO: Colors get game result
        }

        #endregion Methods

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged members
    }
}
