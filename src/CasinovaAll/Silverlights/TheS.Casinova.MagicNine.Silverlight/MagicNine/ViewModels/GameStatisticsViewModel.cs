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
using TheS.Casinova.MagicNine.Models;

namespace TheS.Casinova.MagicNine.ViewModels
{
    public class GameStatisticsViewModel : INotifyPropertyChanged
    {
        #region Fields
        
        private PerfEx.Infrastructure.PropertyChangedNotifier _notify;
        private ObservableCollection<WinnerInfo> _informations;
        private ObservableCollection<string> _games;
        private DateTime _singleDateTime;
        private DateTime _rangeDateTime;
        private int _singleRoundID;
        private int _rangeRoundID;

        #endregion Fields

        #region Properties

        /// <summary>
        /// ข้อมูลผู้ชนะ
        /// </summary>
        public ObservableCollection<WinnerInfo> Informations
        {
            get { return _informations; }
            set
            {
                _informations = value;
                _notify.Raise(() => Informations);
            }
        }

        /// <summary>
        /// ช่วงเวลาของ Single
        /// </summary>
        public DateTime SingleDateTime
        {
            get { return _singleDateTime; }
            set
            {
                if (_singleDateTime!=value)
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
                if (_rangeDateTime!=value)
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
                if (_singleRoundID!=value)
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
                if (_rangeRoundID!=value)
                {
                    _rangeRoundID = value;
                    _notify.Raise(() => RangeRoundID);  
                }
            }
        }

        /// <summary>
        /// ห้องเกมที่ต้องการดูข้อมูล
        /// </summary>
        public ObservableCollection<string> Games
        {
            get { return _games; }
            set
            {
                _games = value;
                _notify.Raise(() => Games);
            }
        }

        #endregion Properties

        #region Constructors

        public GameStatisticsViewModel()
        {
            _notify = new PerfEx.Infrastructure.PropertyChangedNotifier(this, () => PropertyChanged);
            _informations = new ObservableCollection<WinnerInfo>();
            _games = new ObservableCollection<string>();

            if (DesignerProperties.IsInDesignTool)
            {

                Informations.Add(new WinnerInfo
                {
                    Round = 1,
                    Time = new DateTime(2010, 11, 3, 11, 23, 52),
                    Winner = "Sakul"
                });
                Informations.Add(new WinnerInfo
                {
                    Round = 2,
                    Time = new DateTime(2010, 11, 3, 11, 23, 52),
                    Winner = "Tester"
                });

                Games.Add("9");
                Games.Add("99");
                Games.Add("999");
                Games.Add("9999");
            }
        }

        #endregion Constructors

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged
    }
}
