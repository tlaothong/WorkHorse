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
using PerfEx.Infrastructure;

namespace TheS.Casinova.DevilSix.ViewModels
{
    public class GamePlayViewModel : INotifyPropertyChanged
    {
        #region Fields

        private PropertyChangedNotifier _notify;
        private double _pot;
        private double _amount;
        private ObservableCollection<string> _interval;
        private ObservableCollection<string> _reception;
        private ObservableCollection<double> _betLogData;

        #endregion Fields

        #region Properties


        public ObservableCollection<string> Reception
        {
            get { return _reception; }
            set
            {
                _reception = value;
                _notify.Raise(() => Reception);
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
                if (_amount != value) {
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
                if (_pot != value) {
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
            Interval = new ObservableCollection<string>();
            Reception = new ObservableCollection<string>();

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

            // Sample reception options
            Reception.Add("$1");
            Reception.Add("$2");
        }

        #endregion Constructor

        #region Methods


        /// <summary>
        /// ปิด/เปิด การเล่นอัตโนมัติ
        /// </summary>
        public void StartStop(ObservableCollection<string> interval)
        {
        }

        public void BetOne()
        {
            // TODO : Bet $1
        }

        public void BetTwo()
        {
            // TODO : Bet $2
        }

        #endregion Methods

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged members

    }
}
