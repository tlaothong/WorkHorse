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
using TheS.Casinova.MagicNineSvc;

namespace TheS.Casinova.MagicNine.ViewModels
{
    public class GamePlayViewModel : INotifyPropertyChanged
    {
        #region Fields

        private PropertyChangedNotifier _notify;
        private IMagicNineServiceAdapter _svc;
        private IScheduler _scheduler;
        private IStatusTracker _statusTracker;

        private int _selectedGameRoundID;
        //TODO: GameResult
        private ObservableCollection<GamePlayUIViewModel> _activeGameRoundTables;
        private ObservableCollection<PayLog> _payLogs;

        #endregion Fields

        #region Properties

        /// <summary>
        /// ความถี่ของเวลาที่ใช้ในการลงเงินอัตโนมัติ
        /// </summary>
        public int AutoBetInterval
        {
            get
            {
                return _activeGameRoundTables.First(c =>c.RoundID.Equals(_selectedGameRoundID)).Interval;
            }
        }

        /// <summary>
        /// เกมที่สามารถร่วมเล่นได้
        /// </summary>
        public ObservableCollection<GamePlayUIViewModel> ActiveGameRoundTables
        {
            get { return _activeGameRoundTables; }
            set
            {
                if (_activeGameRoundTables != value)
                {
                    _activeGameRoundTables = value;
                    _notify.Raise(() => ActiveGameRoundTables);
                }
            }
        }

        /// <summary>
        /// ข้อมูลการลงเงินพนันที่ยังไม่สำเร็จ
        /// </summary>
        internal ObservableCollection<PayLog> PayLogs
        {
            get { return _payLogs; }
            set
            {
                if (_payLogs != value)
                {
                    _payLogs = value;
                    _notify.Raise(() => PayLogs);
                }
            }
        }

        /// <summary>
        /// จำนวนเงินที่ทำการลงเงินอัตโนมัติ
        /// </summary>
        internal double AutoBetAmount
        {
            get
            {
                return _activeGameRoundTables.First(c => c.RoundID.Equals(_selectedGameRoundID)).Amount;
            }
        }

        /// <summary>
        /// รอบเกมที่กำลังเล่นอยู่
        /// </summary>
        internal int SelectedGameRoundID
        {
            get { return _selectedGameRoundID; }
            set
            {
                if (_selectedGameRoundID != value)
                {
                    _selectedGameRoundID = value;
                    _notify.Raise(() => SelectedGameRoundID);
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
            _activeGameRoundTables = new ObservableCollection<GamePlayUIViewModel>();
            _payLogs = new ObservableCollection<PayLog>();
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// เรียกดูเกมที่สามารถเข้าเล่นได้
        /// </summary>
        public void GetListActiveGameRoundInformation()
        {
            var svc = _svc;

            IDisposable dispostActive = null;
            dispostActive = svc.GetListActiveGameRound().ObserveOn(Scheduler).Subscribe(
                next =>
                {
                    ActiveGameRoundTables.Clear();
                    foreach (var active in next.GameRoundInfos)
                    {
                        ActiveGameRoundTables.Add(new GamePlayUIViewModel
                        {
                            RoundID = active.RoundID,
                            WinnerPoint = active.WinnerPoint,
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

        /// <summary>
        /// เรียกข้อมูลการลงพนันอัตโนมัติทั้งหมด
        /// </summary>
        public void GetLisGamePlayAutoBetInformation()
        {
            var svc = _svc;

            IDisposable disposeAutoBet = null;
            disposeAutoBet = svc.GetListGamePlayAutoBetInformation(new MagicNineSvc.ListGamePlayAutoBetInfoCommand())
                .ObserveOn(Scheduler).Subscribe(
                next =>
                {
                    foreach (var autoBet in next.GamePlayAutoBet)
                    {
                        if (_activeGameRoundTables.Any(c => c.RoundID.Equals(autoBet.RoundID)))
                        {
                            var activeRound = _activeGameRoundTables.First(c => c.RoundID.Equals(autoBet.RoundID));
                            activeRound.Amount = autoBet.Amount;
                            activeRound.Interval = autoBet.Interval;
                            activeRound.AutoBetTrackingID = autoBet.StratTrackingID;
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

        /// <summary>
        /// เรียกข้อมูลการลงพนันที่ผ่านมาของทุกเกม
        /// </summary>
        public void GetListBetLog()
        {
            var svc = _svc;

            IDisposable disposeGetBetLog = null;
            disposeGetBetLog = svc.GetListBetLog(new MagicNineSvc.ListBetLogCommand { RoundID = _selectedGameRoundID })
                .ObserveOn(Scheduler).Subscribe(
                next =>
                {
                    foreach (var activeRound in _activeGameRoundTables) activeRound.BetLogs.Clear();

                    foreach (var betInfo in next.BetInformations)
                    {
                        var activeRound = _activeGameRoundTables.FirstOrDefault(c => c.RoundID.Equals(betInfo.RoundID));
                        if (activeRound != null)
                        {
                            activeRound.BetLogs.Add(new BetLog
                            {
                                BetOrder = betInfo.BetOrder,
                                BetDateTime = betInfo.BetDateTime
                            });
                        }
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
        /// ทำการลงเงินพนัน
        /// </summary>
        public void Bet()
        {
            // TODO: Sub account balance

            var svc = _svc;

            // Save to PayLogs
            const int BetCost = 1;
            var payLog = new PayLog
            {
                Amount = BetCost,
                RoundID = _selectedGameRoundID,
            };

            PayLogs.Add(payLog);

            // Initialize observer follow tracking ID
            var observer = new MagicNineTrackingObserver(() =>
            {
                PayLogs.Remove(payLog);
                GetListBetLog();
            });
            observer.Initialize(StatusTracker);

            IDisposable disposeBet = null;
            disposeBet = svc.BetSingle(new MagicNineSvc.SingleBetCommand { RoundID = _selectedGameRoundID })
                .ObserveOn(Scheduler).Subscribe(
                next =>
                {
                    observer.SetTrackingID(next.TrackingID);
                },
                error =>
                {
                    // TODO: Magic9 Bet error
                },
                () => disposeBet.Dispose()
                );
        }

        public void AutoBetStart()
        {
            // TODO: Sub account balance

            var svc = _svc;

            IDisposable disposeStartAndStop = null;

            // Payload add
            var paylog = new PayLog
            {
                RoundID = _selectedGameRoundID,
                Amount = AutoBetAmount,
            };
            PayLogs.Add(paylog);

            // Initialize observer follow trackingID
            var observer = new MagicNineTrackingObserver(() =>
            {
                paylog.Amount--;

                const int AutoBetFinish = 0;
                if (paylog.Amount <= AutoBetFinish)
                {
                    PayLogs.Remove(paylog);
                }
                GetListBetLog();
            });
            observer.Initialize(StatusTracker);

            disposeStartAndStop = svc.AutoBetOn(new StartAutoBetCommand
            {
                Amount = AutoBetAmount,
                Interval =  AutoBetInterval,
                RoundID = _selectedGameRoundID
            }).ObserveOn(Scheduler).Subscribe(
            next =>
            {
                observer.SetTrackingID(next.StartTrackingID);
            },
            error =>
            {
                // TODO: Magic9 Autobet start error
            },
            () => disposeStartAndStop.Dispose()
            );
        }

        /// <summary>
        /// ปิดการลงพนันอัตโนมัติ
        /// </summary>
        public void AutoBetStop()
        {
            // TODO: Sub account balance

            var svc = _svc;

            // paylog save
            var paylog = new PayLog
            {
                RoundID = _selectedGameRoundID,
            };
            PayLogs.Add(paylog);

            // initialize observer follow trackingID
            var observer = new MagicNineTrackingObserver(() =>
            {
                PayLogs.Remove(paylog);

                // Turn off auto bet
                const int AutoBetOff = 0;
                var activeRound = ActiveGameRoundTables.FirstOrDefault(c => c.RoundID.Equals(paylog.RoundID));
                if (activeRound != null) activeRound.Amount = AutoBetOff;

                GetListBetLog();
            });
            observer.Initialize(StatusTracker);

            IDisposable disposeStartAndStop = null;
            disposeStartAndStop = svc.AutoBetOff(new MagicNineSvc.StopAutoBetCommand { RoundID = _selectedGameRoundID })
                .ObserveOn(Scheduler).Subscribe(
                onNext =>
                {
                    observer.SetTrackingID(onNext.StopTrackingID);
                    paylog.TrackingID = onNext.StopTrackingID;
                },
                error =>
                {
                    // TODO: Magic9 Stop error
                },
                () => disposeStartAndStop.Dispose()
                );
        }

        #endregion Methods

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged members
    }
}
