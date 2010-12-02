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
    /// <summary>
    /// ViewModel ของหน้า game play
    /// </summary>
    public class GamePlayUIViewModel : INotifyPropertyChanged
    {
        #region Fields

        private PerfEx.Infrastructure.PropertyChangedNotifier _notify;
        private int _roundID;
        private int _winnerPoint;
        private double _amount;
        private int _interval;
        private Guid _autoBetTrackingID;
        private ObservableCollection<BetLog> _betLogs;
        private double _pot;
        private int _intervaleOptions;

        #endregion Fields

        #region Properties

        /// <summary>
        /// การลงพนันอัตโนมัติถูกเปิดใช้งานไว้
        /// True: เปิดการทำงาน
        /// False: ปิดการทำงาน
        /// </summary>
        public bool IsAutoBetOn
        {
            get
            {
                bool isOn = false;
                const int AutoBetOff = 0;
                if (_amount > AutoBetOff) isOn = true;
                return isOn;
            }
        }

        /// <summary>
        /// ตัวเลือกความถี่ของเวลาในการลงพนันอัตโนมัติ
        /// </summary>
        public int IntervaleOptions
        {
            get { return _intervaleOptions; }
            set
            {
                if (_intervaleOptions != value)
                {
                    _intervaleOptions = value;
                    _notify.Raise(() => IntervaleOptions);
                }
            }
        }

        /// <summary>
        /// เงินที่ถูกลงพนันในเกมนี้ของทุกคน
        /// </summary>
        public double Pot
        {
            get { return _pot; }
            set
            {
                if (_pot != value)
                {
                    _pot = value;
                    _notify.Raise(() => Pot);
                }
            }
        }

        /// <summary>
        /// ผลลัพธ์ที่เคยทำการลงพนันมาแล้วทั้งหมด
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
        /// TrackingID ของการลงพนันอัตโนมัติ
        /// </summary>
        public Guid AutoBetTrackingID
        {
            get { return _autoBetTrackingID; }
            set
            {
                if (_autoBetTrackingID != value)
                {
                    _autoBetTrackingID = value;
                    _notify.Raise(() => AutoBetTrackingID);
                }
            }
        }

        /// <summary>
        /// ความถี่ของเวลาที่ทำการลงพนันอัตโตมัติ 
        /// </summary>
        public int Interval
        {
            get { return _interval; }
            set
            {
                if (_interval != value)
                {
                    _interval = value;
                    _notify.Raise(() => Interval);
                }
            }
        }

        /// <summary>
        /// จำนวนเงินที่นำไปใช้ในการลงพนันอัตโนมัติ
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
        /// จำนวนเงินที่ชนะของห้องนี้
        /// </summary>
        public int WinnerPoint
        {
            get { return _winnerPoint; }
            set
            {
                if (_winnerPoint != value)
                {
                    _winnerPoint = value;
                    _notify.Raise(() => WinnerPoint);
                }
            }
        }

        /// <summary>
        /// รอบของห้องนี้
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

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initialize game play user interface view model
        /// </summary>
        public GamePlayUIViewModel()
        {
            _notify = new PerfEx.Infrastructure.PropertyChangedNotifier(this, () => PropertyChanged);
            _betLogs = new ObservableCollection<BetLog>();
        }

        #endregion Constructors

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
