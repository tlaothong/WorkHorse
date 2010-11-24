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
using System.Linq;
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
        private ObservableCollection<BetLog> _betLogData;
        private ObservableCollection<GameTable> _tables;

        private IMagicNineServiceAdapter _svc;
        private IScheduler _scheduler;
        private IStatusTracker _statusTracker;
        private int _roundID;
        private int _intervalSelect;
        private bool _isAutobetStart;

        #endregion Fields

        #region Properties

        /// <summary>
        /// ค่าของ Interval ที่เลือกอยู่
        /// </summary>
        public int IntervalSelect
        {
            get { return _intervalSelect; }
            set
            {
                if (_intervalSelect!=value)
                {
                    _intervalSelect = value; 
                }
            }
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
        public ObservableCollection<BetLog> BetLogData
        {
            get
            {
                var result = _betLogData.Where(c => c.Round.Equals(_roundID));
                return new ObservableCollection<BetLog>(result);
            }
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

        internal IMagicNineServiceAdapter GameService
        {
            get
            {
                if (_svc == null)
                {
                    _svc = new MagicNineServiceAdapter();
                }
                return _svc;
            }
            set { _svc = value; }
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

        #endregion Properties

        #region Constructor

        /// <summary>
        /// กำหนดค่าเริ่มต้นของ Main page view model
        /// </summary>
        public GamePlayViewModel()
        {
            _notify = new PropertyChangedNotifier(this, () => PropertyChanged);
            _betLogData = new ObservableCollection<BetLog>();
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
        
        public void GetListActiveGameRoundInformation()
        {
            var svc = _svc;
            IDisposable dispostActive = null;
            dispostActive = svc.GetListActiveGameRound().ObserveOn(Scheduler).Subscribe(
                next =>
                {
                    foreach (var table in next.GameRoundInfos)
                    {
                        Tables.Add(new GameTable
                        {
                            Round = table.RoundID,
                            Name = table.WinnerPoint.ToString(),
                        });
                    }
                },
                error =>
                {
                    // TODO: Magic9 Get list active game round information
                },
                () => dispostActive.Dispose()
                );
        }

        public void GetLisGamePlayAutoBetInformation()
        {
            var svc = _svc;
            IDisposable disposeAutoBet = null;
            disposeAutoBet = svc.GetListGamePlayAutoBetInformation(new MagicNineSvc.ListGamePlayAutoBetInfoCommand())
                .ObserveOn(Scheduler).Subscribe(
                next =>
                {
                    foreach (var table in next.GamePlayAutoBet)
                    {
                        if (Tables.Any(c => c.Round.Equals(table.RoundID)))
                        {
                            var query = Tables.First(c => c.Round.Equals(table.RoundID));
                            query.Amount = table.Amount;
                            query.IsPlaying = true;
                        }
                    }
                },
                error =>
                {
                    // TODO: Magic9 Get list gameplay auto bet information
                },
                () => disposeAutoBet.Dispose()
                );
        }

        public void GetListBetLog()
        {
            var svc = _svc;
            IDisposable disposeGetBetLog = null;
            disposeGetBetLog = svc.GetListBetLog(new MagicNineSvc.ListBetLogCommand { RoundID = RoundID })
                .ObserveOn(Scheduler).Subscribe(
                next =>
                {
                    foreach (var table in next.BetInformations)
                    {
                        BetLogData.Add(new BetLog
                        {
                            Round = table.RoundID,
                            BetOrder = table.BetOrder
                        });
                    }
                },
                error =>
                {
                    // TODO: Magic9 Get list bet log error
                },
                () => disposeGetBetLog.Dispose()
                );
        }

        /// <summary>
        /// ลงเงินพนัน
        /// </summary>
        public void Bet()
        {
            var svc = _svc;
            IDisposable disposeBet = null;
            disposeBet = svc.BetSingle(new MagicNineSvc.SingleBetCommand { RoundID = RoundID })
                .ObserveOn(Scheduler).Subscribe(
                next =>
                {
                    // TODO: Magic9 Bet
                    // Get trackingID and sent to observer follow this trackingID
                },
                error =>
                {
                    // TODO: Magic9 Bet error
                },
                () => disposeBet.Dispose()
                );
        }

        /// <summary>
        /// ปิด/เปิด การเล่นอัตโนมัติ
        /// </summary>
        public void StartStop()
        {
            _isAutobetStart = !_isAutobetStart;
            var svc = _svc;
            IDisposable disposeStartAndStop = null;

            if (_isAutobetStart)
            {
                // Start
                disposeStartAndStop = svc.AutoBetOn(new MagicNineSvc.StartAutoBetCommand
                {
                    Amount = Amount,
                    Interval = IntervalSelect,
                    RoundID = RoundID
                }).ObserveOn(Scheduler).Subscribe(
                next =>
                {
                    // TODO: Magic9 Autobet start 
                    // Get trackingID and sent to observer follow this trackingID
                },
                error =>
                {
                    // TODO: Magic9 Autobet start error
                },
                () => disposeStartAndStop.Dispose()
                );
            }
            else
            {
                // Stop
                disposeStartAndStop = svc.AutoBetOff(new MagicNineSvc.StopAutoBetCommand { RoundID = RoundID })
                    .ObserveOn(Scheduler).Subscribe(
                    onNext =>
                    {
                        // TODO: Magic9 Stop
                        // Get trackingID and sent to observer follow this trackingID
                    },
                    error =>
                    {
                        // TODO: Magic9 Stop error
                    },
                    () => disposeStartAndStop.Dispose()
                    );
            }

        }

        #endregion Methods

        #region INotifyPropertyChanged members
        
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged members
    }
}
