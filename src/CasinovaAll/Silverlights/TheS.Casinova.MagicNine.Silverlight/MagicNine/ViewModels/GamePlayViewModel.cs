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
        private IMagicNineServiceAdapter _svc;
        private IScheduler _scheduler;
        private IStatusTracker _statusTracker;

        private double _amount;
        private int _intervalSelected;
        private int _roundID;
        private ObservableCollection<string> _intervals;
        private ObservableCollection<BetLog> _betLogs;
        private ObservableCollection<GameTable> _tables;
        private bool _isAutobetStart;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Game table list
        /// </summary>
        public ObservableCollection<GameTable> Tables
        {
            get { return _tables; }
            set
            {
                if (_tables != value)
                {
                    _tables = value;
                    _notify.Raise(() => Tables);
                }
            }
        }

        /// <summary>
        /// ข้อมูลการ Bet ที่ผ่านมา
        /// </summary>
        public ObservableCollection<BetLog> BetLogs
        {
            get { return _betLogs; }
            set
            {
                if (_betLogs != value)
                {
                    _betLogs = value;
                    _notify.Raise(() => BetLogs);
                }
            }
        }

        /// <summary>
        /// Intervals ที่มีให้เลือก
        /// </summary>
        public ObservableCollection<string> Intervals
        {
            get { return _intervals; }
            set
            {
                if (_intervals != value)
                {
                    _intervals = value;
                    _notify.Raise(() => Intervals);
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
                }
            }
        }

        /// <summary>
        /// Interval ที่เลือก
        /// </summary>
        public int IntervalSelected
        {
            get { return _intervalSelected; }
            set
            {
                if (_intervalSelected != value)
                {
                    _intervalSelected = value;
                }
            }
        }

        /// <summary>
        /// จำนวนเงินที่ใช้ Auto bet
        /// </summary>
        public double Amount
        {
            get { return _amount; }
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    _notify.Raise(() => Amount);
                }
            }
        }

        /// <summary>
        /// Magic 9 Service
        /// </summary>
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
            _betLogs = new ObservableCollection<BetLog>();
            _intervals = new ObservableCollection<string>();
            _tables = new ObservableCollection<GameTable>();

            if (DesignerProperties.IsInDesignTool)
            {
                // Sample interval time
                Intervals.Add("1 second");
                Intervals.Add("2 second");
                Intervals.Add("5 second");
                Intervals.Add("10 second");
                Intervals.Add("30 second");

                Intervals.Add("1 minute");
                Intervals.Add("2 minute");
                Intervals.Add("5 minute");
                Intervals.Add("10 minute");
                Intervals.Add("30 minute");

                Intervals.Add("1 hours");
                Intervals.Add("2 hours");
                Intervals.Add("3 hours");
                Intervals.Add("5 hours");
                Intervals.Add("12 hours");
                Intervals.Add("24 hours");

                // Sample tables
                Tables.Add(new GameTable
                {
                    Name = "9",
                });
                Tables.Add(new GameTable
                {
                    Name = "99",
                    Amount = 200,
                    IsPlaying = true
                });
                Tables.Add(new GameTable
                {
                    Name = "999",
                    Amount = 73,
                    IsPlaying = true
                });
                Tables.Add(new GameTable
                {
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
                    Tables.Clear();
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

                            const double MaximumPlaying = 1;
                            if (table.Amount >= MaximumPlaying) query.IsPlaying = true;
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
                    BetLogs.Clear();
                    foreach (var table in next.BetInformations)
                    {
                        BetLogs.Add(new BetLog
                         {
                             Round = table.RoundID,
                             BetOrder = table.BetOrder,
                             BetDateTime = table.BetDateTime
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
                    Amount = _amount,
                    Interval = _intervalSelected,
                    RoundID = _roundID
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
