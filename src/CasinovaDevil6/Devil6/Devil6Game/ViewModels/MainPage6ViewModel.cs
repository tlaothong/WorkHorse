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

namespace Devil6Game.ViewModels
{
    public class MainPage6ViewModel : INotifyPropertyChanged
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
        public MainPage6ViewModel()
        {
            _notify = new PropertyChangedNotifier(this, () => PropertyChanged);

        }

        #region Method

        /// <summary>
        /// แสดงผลข้อมูลการ bet
        /// </summary>
        public void ShowBetLogData()
        {
            //TODO :
        }
        
        /// <summary>
        /// Bet หมายเลข 1
        /// </summary>
        public void BetOne()
        {
            //TODO : Bet No.1 method
        }

        /// <summary>
        /// Bet หมายเลข 5
        /// </summary>
        public void BetFive()
        {
            //TODO : Bet No.5 medtod
        }

        /// <summary>
        /// แสดงผลเมนู auto bet
        /// </summary>
        public void ShowAutoBet()
        {
            //TODO :
        }

        /// <summary>
        /// เริ่มการ auto bet
        /// </summary>
        public void StartAutoBet()
        {
            //TODO :
        }

        /// <summary>
        /// หยุดการ auto bet
        /// </summary>
        public void StopAutoBet()
        {
            //TODO :
        }

        #endregion Method
    }
}
