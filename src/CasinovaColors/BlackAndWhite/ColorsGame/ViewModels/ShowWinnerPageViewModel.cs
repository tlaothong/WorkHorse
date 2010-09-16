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
using ColorsGame.ColorsGameSvc;
using System.Linq;
using System.Text;

namespace ColorsGame.ViewModels
{
    public class ShowWinnerPageViewModel : INotifyPropertyChanged
    {
        #region Fields
        
        private const int FirstGetWinner = 1;
        private const double SecondGetWinner = 0.25;
        private PropertyChangedNotifier _notif;
        private ColorsGameServiceSoapClient _svc;
        private string _trackingID;
        private double _balance;
        private bool _isSecond;
        private int _tableID;
        private int _roundID;
        private string _winnerTrick;
        private string _winner;

        #endregion

        #region For testing

        public ColorsGameServiceSoapClient Svc
        {
            get { return _svc; }
            set { _svc = value; }
        }

        #endregion For testing

        #region Properties

        /// <summary>
        /// ยอดเงินคงเหลือ
        /// </summary>
        public double Balance
        {
            get { return _balance; }
            set
            {
                _balance = value;
                _notif.Raise(() => Balance);
            }
        }

        /// <summary>
        /// ข้อความจากเซิฟเวอร์
        /// </summary>
        public string TrackingID
        {
            get { return _trackingID; }
            set
            {
                _trackingID = value;
                _notif.Raise(() => TrackingID);
            }
        }

        /// <summary>
        /// หมายเลขโต๊ะ
        /// </summary>
        public int TableID
        {
            get { return _tableID; }
            set
            {
                _tableID = value;
                _notif.Raise(() => TableID);
            }
        }

        /// <summary>
        /// รอบของเกม
        /// </summary>
        public int RoundID
        {
            get { return _roundID; }
            set
            {
                _roundID = value;
                _notif.Raise(() => RoundID);
            }
        }

        /// <summary>
        /// ข้อความปุ่ม Get winner
        /// </summary>
        public string WinnerTrick
        {
            get { return _winnerTrick; }
            set
            {
                _winnerTrick = value;
                _notif.Raise(() => WinnerTrick);
            }
        }

        /// <summary>
        /// ชื่อผู้ชนะ
        /// </summary>
        public string Winner
        {
            get { return _winner; }
            set
            {
                _winner = value;
                _notif.Raise(() => Winner);
            }
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Constructor

        /// <summary>
        /// Initialize show winner page view model
        /// </summary>
        public ShowWinnerPageViewModel()
        {
            _notif = new PropertyChangedNotifier(this, () => PropertyChanged);
            _svc = new ColorsGameServiceSoapClient();

            Balance = 100;
            WinnerTrick = "One dollar to show information.";

            initialEvents();
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// On click Get winner button
        /// </summary>
        public void GetWinner()
        {
            // หักเงินในส่วนของ UI
            if (_isSecond) Balance -= SecondGetWinner;
            else {
                Balance -= FirstGetWinner;
                _isSecond = true;
                WinnerTrick = "25 cent to update information.";
            }

            var svc = _svc;
            svc.PayForWinnerInformationAsync(_tableID, _roundID); 
        }

        // On page start initialize view movdel handle events
        private void initialEvents()
        {
            var svc = _svc;

            // Dispaly server respond pay from winner information
            var payForWinnerInformationObserver = Observable.FromEvent<PayForWinnerInformationCompletedEventArgs>(svc, "PayForWinnerInformationCompleted");
            IDisposable payForWinnerInfoDisable = null;
            payForWinnerInfoDisable = payForWinnerInformationObserver.Subscribe(
                next => {
                    TrackingID = next.EventArgs.Result;
                    svc.GetMyGamePlayInfoAsync();
                },
                error => TrackingID = error.Message,
                () => payForWinnerInfoDisable.Dispose()
                );

            // Display server respond get my game play information
            var getMyGamePlayInformationObserver = Observable.FromEvent<GetMyGamePlayInfoCompletedEventArgs>(svc, "GetMyGamePlayInfoCompleted");
            IDisposable getMyGamePlayInfoDisposable = getMyGamePlayInformationObserver.Subscribe(
                next => {
                    var winner = next.EventArgs.Result.FirstOrDefault(c => c.TableID.Equals(_tableID) && c.RoundID.Equals(_roundID));
                    if (winner != null) {
                        StringBuilder message = new StringBuilder();
                        message.Append(string.Format("Winner: {0}", winner.Winner))
                            .Append(string.Format("\nTrackingID: {0}", winner.TrackingID))
                            .Append(string.Format("\nOnGoingTrackingID: {0}", winner.OnGoingTrackingID));
                        Winner = message.ToString();
                    }
                    else Winner = string.Format("Don't any match TableID: {0}, RoundID: {1}.", _tableID, _roundID);
                },
                error => TrackingID = error.Message,
                () => payForWinnerInfoDisable.Dispose()
                );
        }

        #endregion Methods
    }
}