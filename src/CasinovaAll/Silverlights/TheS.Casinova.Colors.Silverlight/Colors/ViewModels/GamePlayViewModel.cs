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
using TheS.Casinova.Colors.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using TheS.Casinova.ColorsSvc;
using TheS.Casinova.Colors.Services;
using System.Concurrency;
using PerfEx.Infrastructure.LotUpdate;
using TheS.Casinova.Colors.Views;

namespace TheS.Casinova.Colors.ViewModels
{
    /// <summary>
    /// ViewModel ของหน้า Game rooms
    /// </summary>
    public class GamePlayViewModel : INotifyPropertyChanged
    {
        #region Fields

        private int _selectedGameRoundID;
        private double _betAmount;
        private IScheduler _scheduler;
        private IColorsServiceAdapter _svc;
        private IStatusTracker _statusTracker;
        private PropertyChangedNotifier _notify;
        private GameStatisticsViewModel _gameResult;
        private ObservableCollection<GamePlayUIViewModel> _activeGameRoundTables;
        private ObservableCollection<PayLog> _payLogs;

        #endregion Fields

        #region Properties

        /// <summary>
        /// เกมที่สามารถร่วมเล่นได้
        /// </summary>
        public ObservableCollection<GamePlayUIViewModel> ActiveGameRoundTables
        {
            get { return _activeGameRoundTables; }
            set
            {
                if (_activeGameRoundTables!=value)
                {
                    _activeGameRoundTables = value;
                    _notify.Raise(() => ActiveGameRoundTables);
                }
            }
        }

        /// <summary>
        /// จำนวนเงินที่ทำการลงพนัน
        /// </summary>
        public double BetAmount
        {
            get { return _betAmount; }
            set
            {
                if (_betAmount != value)
                {
                    _betAmount = value;
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
                if (_payLogs!=value)
                {
                    _payLogs = value; 
                }
            }
        }

        /// <summary>
        /// ผลสรุปสีที่ชนะในรอบเกมนี้
        /// </summary>
        internal GameStatisticsViewModel GameResult
        {
            get { return _gameResult; }
            set
            {
                if (_gameResult != value)
                {
                    _gameResult = value;
                    _notify.Raise(() => GameResult);
                }
            }
        }

        /// <summary>
        /// Service
        /// </summary>
        internal Services.IColorsServiceAdapter GameService
        {
            get
            {
                if (_svc == null)
                {
                    _svc = new ColorsServiceAdapter();
                }
                return _svc;
            }
            set { _svc = value; }
        }

        /// <summary>
        /// Scheduler
        /// </summary>
        internal IScheduler Scheduler
        {
            get { return _scheduler; }
            set { _scheduler = value; }
        }

        /// <summary>
        /// Dispatcher
        /// </summary>
        internal System.Windows.Threading.Dispatcher Dispatcher
        {
            set { _scheduler = new DispatcherScheduler(value); }
        }

        /// <summary>
        /// StatusTracker
        /// </summary>
        internal IStatusTracker StatusTracker
        {
            get { return _statusTracker; }
            set { _statusTracker = value; }
        }

        /// <summary>
        /// รอบของเกมที่ถูกเลือกอยู่
        /// </summary>
        internal int SelectedGameRoundID
        {
            get { return _selectedGameRoundID; }
            set
            {
                if (_selectedGameRoundID!=value)
                {
                    _selectedGameRoundID = value; 
                }
            }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initialize game play
        /// </summary>
        public GamePlayViewModel()
        {
            _notify = new PropertyChangedNotifier(this, () => PropertyChanged);
            _activeGameRoundTables = new ObservableCollection<GamePlayUIViewModel>();
            _payLogs = new ObservableCollection<PayLog>();

            #region Designer properties

            if (DesignerProperties.IsInDesignTool)
            {
                // Sample tables
                ActiveGameRoundTables.Add(new GamePlayUIViewModel
                {
                    Title = "Colors",
                    RoundID = 1,
                    Amount = 0,
                    RemainingGameTime = new TimeSpan(0, 17, 7),
                    TotalAmountOfBlack = 0,
                    TotalAmountOfWhite = 0,
                    IsPlaying = false,
                    Winner = "Black"
                });
                ActiveGameRoundTables.Add(new GamePlayUIViewModel
                {
                    Title = "Colors",
                    RoundID = 2,
                    Amount = 1,
                    RemainingGameTime = new TimeSpan(0, 32, 7),
                    TotalAmountOfBlack = 0,
                    TotalAmountOfWhite = 1,
                    IsPlaying = true,
                    Winner = "Black"
                });
                ActiveGameRoundTables.Add(new GamePlayUIViewModel
                {
                    Title = "Colors",
                    RoundID = 3,
                    Amount = 8200,
                    RemainingGameTime = new TimeSpan(0, 47, 7),
                    TotalAmountOfBlack = 620,
                    TotalAmountOfWhite = 7580,
                    IsPlaying = true,
                    Winner = "White"
                });
                ActiveGameRoundTables.Add(new GamePlayUIViewModel
                {
                    Title = "Colors",
                    RoundID = 4,
                    Amount = 0,
                    RemainingGameTime = new TimeSpan(1, 02, 7),
                    TotalAmountOfBlack = 0,
                    TotalAmountOfWhite = 0,
                    IsPlaying = false,
                    Winner = "Black"
                });
                ActiveGameRoundTables.Add(new GamePlayUIViewModel
                {
                    Title = "Colors",
                    RoundID = 5,
                    Amount = 450,
                    RemainingGameTime = new TimeSpan(1, 17, 7),
                    TotalAmountOfBlack = 10,
                    TotalAmountOfWhite = 440,
                    IsPlaying = true,
                    Winner = "White"
                });
            }

            #endregion Designer properties
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// เรียกดูเกมที่สามารถเข้าเล่นได้
        /// </summary>
        public void GetListActiveGameRounds()
        {
            var svc = _svc;

            // sent command to web service and subscribe
            IDisposable disposeGameRounds = null;
            disposeGameRounds = svc.GetListActiveGameRound().ObserveOn(Scheduler).Subscribe(
                next =>
                {
                    // เคลียรายชื่อห้องเก่า
                    ActiveGameRoundTables.Clear();

                    // เพิ่มรายชื่อห้องที่สามารถเข้าเล่นได้
                    foreach (var table in next.ActiveRounds)
                    {
                        ActiveGameRoundTables.Add(new GamePlayUIViewModel
                        {
                            Title = "Colors",
                            RoundID = table.RoundID,
                            StartTime = table.StartTime,
                            EndTime = table.EndTime
                        });
                    }
                },
                error =>
                {
                    // TODO: Colors RX GetListActiveGameRounds error
                },
                () => disposeGameRounds.Dispose()
                );
        }

        /// <summary>
        /// เรียกขอผลสรุปการเล่นเกมของรอบนี้
        /// </summary>
        public void GetStatistics()
        {
            var svc = _svc;

            // sent command to web service and subscribe
            IDisposable disposeGameResult = null;
            disposeGameResult = svc.GetGameResult(new GetGameResultCommand { RoundID = _selectedGameRoundID })
                .ObserveOn(Scheduler).Subscribe(
                next =>
                {
                    var result = next.GameResult;
                    if (result != null)
                    {
                        // Set up game result
                        string winner = "Black";
                        if (result.WhitePot <= result.BlackPot) winner = "White";
                        _gameResult = new GameStatisticsViewModel
                        {
                            Winner = winner,
                            Hands = result.HandCount,
                            BlackPot = result.BlackPot,
                            WhitePot = result.WhitePot,
                        };

                        // Create and initialize statistics windows
                        var cw = new StatisticsWindow();
                        cw.GameStatisticsUI.DataContext = _gameResult;

                        // Display statistics windows
                        cw.Show();
                    }
                },
                error =>
                {
                    // TODO: Colors RX GetGameResult error
                },
                () => disposeGameResult.Dispose()
                );
        }

        /// <summary>
        /// เรียกข้อมูลการเล่นเกม
        /// </summary>
        public void GetListGamePlayInformation()
        {
            var svc = _svc;

            // sent command to web service and subscribe
            IDisposable disposeGamePlayInformation = null;
            disposeGamePlayInformation = svc.GetListGamePlayInformation(new ListGamePlayInfoCommand()).
                ObserveOn(Scheduler).Subscribe(
                next =>
                {
                    foreach (var table in next.GamePlayInfos)
                    {
                        if (ActiveGameRoundTables.Any(round => round.RoundID.Equals(table.RoundID)))
                        {
                            // Update game round information
                            var update = ActiveGameRoundTables.First(round => round.RoundID.Equals(table.RoundID));
                            var blackPot = table.TotalBetAmountOfBlack - update.TotalAmountOfBlack;
                            var whitePot = table.TotalBetAmountOfWhite - update.TotalAmountOfWhite;

                            update.TotalAmountOfBlack += blackPot;
                            update.TotalAmountOfWhite += whitePot;
                            update.TrackingID = table.TrackingID;
                            update.OnGoingTrackingID = table.OnGoingTrackingID;
                            update.Amount = (table.TotalBetAmountOfBlack + table.TotalBetAmountOfWhite) - update.Amount;
                            update.Winner = table.Winner;
                        }
                        else
                        {
                            // Add new game round information
                            ActiveGameRoundTables.Add(new GamePlayUIViewModel
                            {
                                RoundID = table.RoundID,
                                TrackingID = table.TrackingID,
                                OnGoingTrackingID = table.OnGoingTrackingID,
                                TotalAmountOfBlack = table.TotalBetAmountOfBlack,
                                TotalAmountOfWhite = table.TotalBetAmountOfWhite,
                                Winner = table.Winner
                            });
                        }
                    }

                    // Check TrackingID and OnGoingTrackingID
                    var lastGamePlayInfo = next.GamePlayInfos.LastOrDefault();
                    if (lastGamePlayInfo != null)
                    {
                        if (!lastGamePlayInfo.TrackingID.Equals(lastGamePlayInfo.OnGoingTrackingID))
                        {
                            GetListGamePlayInformation();
                        }
                    }
                    
                    // Check paylog for change game status
                    const int PayLogEmpty = 0;
                    if (_payLogs.Count == PayLogEmpty)
                    {
                        // TODO: if PayLog = empty remove waiting status
                    }
                },
                error =>
                {
                    // TODO: Colors RX GetListGamePlayInformation error
                },
                () => disposeGamePlayInformation.Dispose()
                );
        }

        /// <summary>
        /// เรียกดูสีที่ชนะในเวลาขณะนั้น
        /// </summary>
        public void GetWinnerInformation()
        {
            // TODO: Colors Sub account balance UI
            var svc = _svc;

            // select game request get winner
            var gameSelected = _activeGameRoundTables.FirstOrDefault(c => c.RoundID.Equals(_selectedGameRoundID));
            if (gameSelected != null)
            {
                var getWinnerLog = new PayLog
                {
                    RoundID = _selectedGameRoundID,
                    Amount = gameSelected.CostWinnerInformation
                };

                // initialize tracking observer
                var observer = new ColorsTrackingObserver(() =>
                {
                    PayLogs.Remove(getWinnerLog);
                    GetListGamePlayInformation();
                });
                observer.Initialize(StatusTracker);

                // add pay log
                PayLogs.Add(getWinnerLog);

                // sent command to web service and subscribe
                IDisposable disposeGetWinnerInformation = null;
                disposeGetWinnerInformation = svc.GetWinnerInformation(new PayForColorsWinnerInfoCommand { RoundID = _selectedGameRoundID })
                    .ObserveOn(Scheduler).Subscribe(
                    next => observer.SetTrackingID(next.OnGoingTrackingID),
                    error =>
                    {
                        // TODO: Colors RX GetWinnerInformation error
                    },
                    () => disposeGetWinnerInformation.Dispose()
                    );

                // set game have request get winner information
                gameSelected.IsSecondGetWinnerInformation = true;
            }
        }

        /// <summary>
        /// ลงพนันในสีดำ
        /// </summary>
        public void BetBlack()
        {
            bet();
        }

        /// <summary>
        /// ลงพนันในสีขาว
        /// </summary>
        public void BetWhite()
        {
            const bool betWhite = false;
            bet(betWhite);
        }

        // เริ่มทำการลงพนันในสีที่เลือก
        private void bet(bool betBlack = true)
        {
            // TODO: Colors Sub account balance UI
            var svc = _svc;

            // Select color for bet
            const string BetInBlack = "Black";
            const string BetInWhite = "White";
            string selectColor = BetInWhite;
            if (betBlack) selectColor = BetInBlack;

            var betLog = new PayLog
            {
                Amount = _betAmount,
                RoundID = _selectedGameRoundID,
                Colors = selectColor
            };

            // initialize tracking observer
            ColorsTrackingObserver observer = new ColorsTrackingObserver(() =>
            {
                PayLogs.Remove(betLog);
                GetListGamePlayInformation();
            });
            observer.Initialize(StatusTracker);

            // add pay log
            PayLogs.Add(betLog);

            // sent command to web service and subscribe
            IDisposable disposeBet = null;
            disposeBet = svc.Bet(new BetCommand
            {
                Amount = _betAmount,
                Color = selectColor,
                RoundID = _selectedGameRoundID,
            }).ObserveOn(Scheduler).Subscribe(
                next => observer.SetTrackingID(next.TrackingID),
                error =>
                {
                    // TODO: Colors RX Bet error
                },
                () => disposeBet.Dispose()
                );
        }

        #endregion Methods

        #region INotifyPropertyChanged member

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged member
    }
}
