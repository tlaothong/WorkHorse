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
using TheS.Casinova.Colors.Models;
using System.Collections.Generic;

namespace TheS.Casinova.Colors.ViewModels
{
    /// <summary>
    /// ViewModel ของหน้าสถิติ (กราฟ)
    /// </summary>
    public class StatisticsChartViewModel : INotifyPropertyChanged
    {
        #region Fields
        
        private PerfEx.Infrastructure.PropertyChangedNotifier _notify;
        private ObservableCollection<BetdataInfo> _informations;
        private ObservableCollection<KeyValuePair<DateTime, double>> _lineInformationsBlack;
        private ObservableCollection<KeyValuePair<DateTime, double>> _barInformationsBlack;
        private ObservableCollection<KeyValuePair<DateTime, double>> _lineInformationsWhite;
        private ObservableCollection<KeyValuePair<DateTime, double>> _barInformationsWhite;
        private string _chartName;
        private double _maximum;
        private double _interval;

        #endregion Fields

        #region Properties

        /// <summary>
        /// ข้อมูลของกราฟเส้นที่เป็นสีดำ
        /// </summary>
        public ObservableCollection<KeyValuePair<DateTime, double>> LineInformationsBlack
        {
            get { return _lineInformationsBlack; }
            set
            {
                _lineInformationsBlack = value;
                _notify.Raise(() => LineInformationsBlack);
            }
        }

        /// <summary>
        /// ข้อมูลของกราฟเส้นที่เป็นสีขาว
        /// </summary>
        public ObservableCollection<KeyValuePair<DateTime, double>> LineInformationsWhite
        {
            get { return _lineInformationsWhite; }
            set
            {
                _lineInformationsWhite = value;
                _notify.Raise(() => LineInformationsWhite);
            }
        }

        /// <summary>
        /// ข้อมูลของกราฟแท่งที่เป็นสีดำ
        /// </summary>
        public ObservableCollection<KeyValuePair<DateTime, double>> BarInformationsBlack
        {
            get { return _barInformationsBlack; }
            set
            {
                _barInformationsBlack = value;
                _notify.Raise(() => BarInformationsBlack);
            }
        }

        /// <summary>
        /// ข้อมูลของกราฟแท่งที่เป็นสีขาว
        /// </summary>
        public ObservableCollection<KeyValuePair<DateTime, double>> BarInformationsWhite
        {
            get { return _barInformationsWhite; }
            set
            {
                _barInformationsWhite = value;
                _notify.Raise(() => BarInformationsWhite);
            }
        }

        /// <summary>
        /// ความถี่
        /// </summary>
        public double Interval
        {
            get { return _interval; }
            set
            {
                _interval = value;
                _notify.Raise(() => Interval);
            }
        }

        /// <summary>
        /// ค่าสูงสุดของความถี่
        /// </summary>
        public double Maximum
        {
            get { return _maximum; }
            set
            {
                _maximum = value;
                _notify.Raise(() => Maximum);
            }
        }

        /// <summary>
        /// ชื่อกราฟ
        /// </summary>
        public string ChartName
        {
            get { return _chartName; }
            set
            {
                _chartName = value;
                _notify.Raise(() => ChartName);
            }
        }

        /// <summary>
        /// ข้อมูลของการลงเงินทั้งหมด
        /// </summary>
        public ObservableCollection<BetdataInfo> Informations
        {
            get { return _informations; }
            set
            {
                _informations = value;
                _notify.Raise(() => Informations);
            }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initialize statistics chart view model
        /// </summary>
        public StatisticsChartViewModel()
        {
            _notify = new PerfEx.Infrastructure.PropertyChangedNotifier(this, () => PropertyChanged);
            _informations = new ObservableCollection<BetdataInfo>();
            _lineInformationsBlack = new ObservableCollection<KeyValuePair<DateTime, double>>();
            _barInformationsBlack = new ObservableCollection<KeyValuePair<DateTime, double>>();
            _lineInformationsWhite = new ObservableCollection<KeyValuePair<DateTime, double>>();
            _barInformationsWhite = new ObservableCollection<KeyValuePair<DateTime, double>>();

            #region Designer view

            if (DesignerProperties.IsInDesignTool)
            {

                ChartName = "Colors 85";

                Random random = new Random();
                DateTime time = DateTime.Now;
                double potBlack = 0, potWhite = 0;
                for (int count = 0; count < 20; count++)
                {
                    var data = new KeyValuePair<DateTime, double>(time, potBlack);
                    LineInformationsBlack.Add(data);
                    BarInformationsBlack.Add(data);
                    data = new KeyValuePair<DateTime, double>(time, potWhite);
                    LineInformationsWhite.Add(data);
                    BarInformationsWhite.Add(data);

                    if (Maximum < potBlack) Maximum = potBlack;
                    if (Maximum < potWhite) Maximum = potWhite;

                    potBlack += random.Next(0, 200);
                    potWhite += random.Next(0, 200);
                    time = time.Add(TimeSpan.FromMinutes(18));
                }
                Interval = (int)(Maximum / 5);
                Maximum += Interval;

                Informations.Add(new BetdataInfo
                {
                    Color = "White",
                    Player = "OhLanla",
                    Round = 123,
                    Time = new DateTime(2010, 11, 3, 12, 32, 50),
                    WinColor = "Black",
                    Bet = 35,
                    WhitePot = 35,
                    BlackPot = 21,
                });
                Informations.Add(new BetdataInfo
                {
                    Color = "White",
                    Player = "Okacho",
                    Round = 123,
                    Time = new DateTime(2010, 11, 3, 12, 32, 54),
                    WinColor = "Black",
                    Bet = 550,
                    WhitePot = 1234,
                    BlackPot = 521,
                });
                Informations.Add(new BetdataInfo
                {
                    Color = "White",
                    Player = "Maximum",
                    Round = 123,
                    Match = true,
                    Time = new DateTime(2010, 11, 3, 12, 32, 55),
                    WinColor = "White",
                    Bet = 1,
                    WhitePot = 456,
                    BlackPot = 789,
                });
            }

            #endregion Designer view
        }

        #endregion Constructors

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged members
    }
}
