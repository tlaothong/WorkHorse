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
using Magic9Game.Magic9Svc;

namespace Magic9Game.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {

        #region Fields

        public event PropertyChangedEventHandler PropertyChanged;
        private PropertyChangedNotifier _notify;
        private double _pot;
        private double _amount;
        private ObservableCollection<string> _interval;
        private ObservableCollection<double> _betLogData;
        private Magic9GameServiceSoapClient _service;

        #endregion Fields

        #region Properties

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
                _amount = value;
                _notify.Raise(() => Amount);
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
                _pot = value;
                _notify.Raise(() => Pot);
            }
        }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// กำหนดค่าเริ่มต้นของ Main page view model
        /// </summary>
        public MainPageViewModel()
        {
            _notify = new PropertyChangedNotifier(this, () => PropertyChanged);
            _betLogData = new ObservableCollection<double>();
            Interval = new ObservableCollection<string>();
            _service = new Magic9GameServiceSoapClient();

            _service.GetNumberCompleted += new EventHandler<GetNumberCompletedEventArgs>(_service_GetNumberCompleted);

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
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// ลงเงินพนัน
        /// </summary>
        public void Bet()
        {
            _service.GetNumberAsync();
        }


        /// <summary>
        /// ปิด/เปิด การเล่นอัตโนมัติ
        /// </summary>
        public void StartStop()
        {
            // TODO : ปิด/เปิด การเล่นอัตโนมัติ
        }

        // ได้รับค่าของ Pot ณ เวลาขณะนั้น
        private void _service_GetNumberCompleted(object sender, GetNumberCompletedEventArgs e)
        {
            Pot = e.Result;
            BetLogData.Add(e.Result);
        }

        #endregion Methods
    }
}
