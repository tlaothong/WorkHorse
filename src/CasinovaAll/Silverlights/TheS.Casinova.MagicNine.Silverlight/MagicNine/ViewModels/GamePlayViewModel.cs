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
using System.Globalization;
using TheS.Casinova.MagicNine.Models;
using TheS.Casinova.MagicNine.Services;
using System.Concurrency;
using PerfEx.Infrastructure.LotUpdate;

namespace TheS.Casinova.MagicNine.ViewModels
{
    public class GamePlayViewModel : INotifyPropertyChanged
    {
        #region Fields

        private PropertyChangedNotifier _notify;
        private double _pot;
        private double _amount;
        private ObservableCollection<string> _interval;
        private ObservableCollection<double> _betLogData;
        private ObservableCollection<GameTable> _tables;

        private IMagicNineServiceAdapter _sva;
        private IScheduler _scheduler;
        private IStatusTracker _statusTracker;
        private int _roundID;

        #endregion Fields

        #region Properties

        internal IMagicNineServiceAdapter GameService
        {
            get
            {
                if (_sva == null)
                {
                    _sva = new MagicNineServiceAdapter();
                }
                return _sva;
            }
            set { _sva = value; }
        }

        internal IScheduler Scheduler
        {
            get { return _scheduler; }
            set { _scheduler = value; }
        }

        internal System.Windows.Threading.Dispatcher Dispatcher
        {
            set { _scheduler = new DispatcherScheduler(value); }
        }

        internal IStatusTracker StatusTracker
        {
            get { return _statusTracker; }
            set { _statusTracker = value; }
        }

        /// <summary>
        /// Game round id
        /// </summary>
        public int RoundID
        {
            get { return _roundID; }
            set
            {
                if (_roundID != value)
                {
                    _roundID = value;
                    _notify.Raise(() => RoundID);
                }
            }
        }

        /// <summary>
        /// รายชื่อโต๊ะเกมที่สามารถเข้าเล่นได้
        /// </summary>
        public ObservableCollection<GameTable> Tables
        {
            get { return _tables; }
            set
            {
                _tables = value;
                _notify.Raise(() => Tables);
            }
        }

        /// <summary>
        /// ข้อมูลเงินลงพนันที่ได้รับมาทั้งหมด
        /// </summary>
        public ObservableCollection<double> BetLogData
        {
            get { return _betLogData; }
            set
            {
                _betLogData = value;
                _notify.Raise(() => BetLogData);
            }
        }

        /// <summary>
        /// เวลาที่จะทำการลงพนัน Config Auto bet
        /// </summary>
        public ObservableCollection<string> Interval
        {
            get { return _interval; }
            set
            {
                _interval = value;
                _notify.Raise(() => Interval);
            }
        }

        /// <summary>
        /// Config ของ Auto bet
        /// </summary>
        public double Amount
        {
            get { return _amount; }
            set
            {
                if (_amount!=value) {
                    _amount = value;
                    _notify.Raise(() => Amount); 
                }
            }
        }

        /// <summary>
        /// ค่าของ Pot ที่ได้จากการลงพนัน
        /// </summary>
        public double Pot
        {
            get { return _pot; }
            set
            {
                if (_pot!=value) {
                    _pot = value;
                    _notify.Raise(() => Pot); 
                }
            }
        }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// กำหนดค่าเริ่มต้นของ Main page view model
        /// </summary>
        public GamePlayViewModel()
        {
            _notify = new PropertyChangedNotifier(this, () => PropertyChanged);
            _betLogData = new ObservableCollection<double>();
            _interval = new ObservableCollection<string>();
            _tables = new ObservableCollection<GameTable>();

            if (DesignerProperties.IsInDesignTool) {
                // Sample interval time
                Interval.Add("1 second");
                Interval.Add("2 second");
                Interval.Add("5 second");
                Interval.Add("10 second");
                Interval.Add("30 second");

                Interval.Add("1 minute");
                Interval.Add("2 minute");
                Interval.Add("5 minute");
                Interval.Add("10 minute");
                Interval.Add("30 minute");

                Interval.Add("1 hours");
                Interval.Add("2 hours");
                Interval.Add("3 hours");
                Interval.Add("5 hours");
                Interval.Add("12 hours");
                Interval.Add("24 hours"); 

                // Sample tables
                Tables.Add(new GameTable {
                    Name = "9",
                });
                Tables.Add(new GameTable {
                    Name = "99",
                    Amount = 200,
                    IsPlaying = true
                });
                Tables.Add(new GameTable {
                    Name = "999",
                    Amount = 73,
                    IsPlaying = true
                });
                Tables.Add(new GameTable {
                    Name = "9999",
                });
            }
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// ลงเงินพนัน
        /// </summary>
        public void Bet()
        {
            //TODO: Bet
        }

        /// <summary>
        /// ปิด/เปิด การเล่นอัตโนมัติ
        /// </summary>
        public void StartStop()
        {
            // TODO: StartStop
        }

        #endregion Methods

        #region INotifyPropertyChanged members
        
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged members
    }
}
