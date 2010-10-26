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
    public class MainPageViewModel : INotifyPropertyChanged
    {
        #region Fields
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected double _amount;
        protected ObservableCollection<string> _repetiton;
        protected ObservableCollection<string> _interval;
        protected ObservableCollection<double> _betLogData;
        protected PropertyChangedNotifier _notify;
        
        #endregion Fields

        #region Properties

        /// <summary>
        /// Config ของ Auto bet
        /// </summary>
        public double Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                _notify.Raise(() => _amount);
            }
        }

        /// <summary>
        /// จำนวนรอบที่ต้องการให้ repeate auto bet
        /// </summary>
        protected ObservableCollection<string> Repetiton
        {
            get { return _repetiton; }
            set
            {
                _repetiton = value;
                _notify.Raise(() => _repetiton);
            }
        }


        /// <summary>
        /// เวลาที่จะทำการลงพนัน Config Auto bet
        /// </summary>
        protected ObservableCollection<string> Interval
        {
            get { return _interval; }
            set
            {
                _interval = value;
                _notify.Raise(() => _interval);
            }
        }
        
        /// <summary>
        /// ข้อมูลเงินลงพนันที่ได้รับมาทั้งหมด
        /// </summary>
        protected ObservableCollection<double> BetLogData
        {
            get { return _betLogData; }
            set
            {
                _betLogData = value;
                _notify.Raise(() => _betLogData);
            }
        }


        #endregion Properties

        /// <summary>
        /// กำหนดค่าเริ่มต้นของ Main page view model
        /// </summary>
        public MainPageViewModel()
        {
            _notify = new PropertyChangedNotifier(this, () => PropertyChanged);

        }

        #region Method

        /// <summary>
        /// แสดงผลข้อมูลการ bet
        /// </summary>
        public void ShowBetLogData()
        {
            //TODO : Create method for show information of bet log
        }
        
        /// <summary>
        /// Bet หมายเลข 1
        /// </summary>
        public void BetOne()
        {
            //TODO : Create method bet for No.1's button
        }

        /// <summary>
        /// Bet หมายเลข 5
        /// </summary>
        public void BetFive()
        {
            //TODO : Create method bet for No.5's button
        }

        /// <summary>
        /// แสดงผลเมนู auto bet
        /// </summary>
        public void ShowAutoBet()
        {
            //TODO : Create method bet for show auto bet menu
        }

        /// <summary>
        /// เริ่มการ auto bet
        /// </summary>
        public void StartAutoBet()
        {
            //TODO : Create method bet for start auto bet feature
        }

        /// <summary>
        /// หยุดการ auto bet
        /// </summary>
        public void StopAutoBet()
        {
            //TODO : Create method bet for stop auto bet feature
        }

        #endregion Method

    }
}
