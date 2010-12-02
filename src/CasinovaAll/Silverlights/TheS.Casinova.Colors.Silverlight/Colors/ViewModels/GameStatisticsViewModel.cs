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
        private GameResult _result;
        private DateTime _singleDateTime;
        private DateTime _rangeDateTime;
        private int _singleRoundID;
        private int _rangeRoundID;

        #endregion Fields

        #region Properties

        /// <summary>
        /// ช่วงเวลาของ Single
        /// </summary>
        public DateTime SingleDateTime
        {
            get { return _singleDateTime; }
            set
            {
                if (_singleDateTime != value)
                {
                    _singleDateTime = value;
                    _notify.Raise(() => SingleDateTime);
                }
            }
        }

        /// <summary>
        /// ช่วงเวลาของ Range
        /// </summary>
        public DateTime RangeDateTime
        {
            get { return _rangeDateTime; }
            set
            {
                if (_rangeDateTime != value)
                {
                    _rangeDateTime = value;
                    _notify.Raise(() => RangeDateTime);
                }
            }
        }

        /// <summary>
        /// รอบของ Single
        /// </summary>
        public int SingleRoundID
        {
            get { return _singleRoundID; }
            set
            {
                if (_singleRoundID != value)
                {
                    _singleRoundID = value;
                    _notify.Raise(() => SingleRoundID);
                }
            }
        }

        /// <summary>
        /// รอบของ Range
        /// </summary>
        public int RangeRoundID
        {
            get { return _rangeRoundID; }
            set
            {
                if (_rangeRoundID != value)
                {
                    _rangeRoundID = value;
                    _notify.Raise(() => RangeRoundID);
                }
            }
        }

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
