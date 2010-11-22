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
using TheS.Casinova.TwoWins.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace TheS.Casinova.TwoWins.ViewModels
{
    public class StatisticsChartViewModel : INotifyPropertyChanged
    {
        #region Fields
        
        private PerfEx.Infrastructure.PropertyChangedNotifier _notify;
        private ObservableCollection<BetdataInfo> _informations;
        private ObservableCollection<KeyValuePair<DateTime, double>> _lineInformations;
        private ObservableCollection<KeyValuePair<DateTime, double>> _barInformations;
        private string _chartName;
        private double _maximum;
        private double _interval;

        #endregion Fields

        #region Properties

        public double Interval
        {
            get { return _interval; }
            set
            {
                _interval = value;
                _notify.Raise(() => Interval);
            }
        }

        public double Maximum
        {
            get { return _maximum; }
            set
            {
                _maximum = value;
                _notify.Raise(() => Maximum);
            }
        }

        public string ChartName
        {
            get { return _chartName; }
            set
            {
                _chartName = value;
                _notify.Raise(() => ChartName);
            }
        }

        public ObservableCollection<KeyValuePair<DateTime, double>> BarInformations
        {
            get { return _barInformations; }
            set
            {
                _barInformations = value;
                _notify.Raise(() => BarInformations);
            }
        }

        public ObservableCollection<KeyValuePair<DateTime, double>> LineInformations
        {
            get { return _lineInformations; }
            set
            {
                _lineInformations = value;
                _notify.Raise(() => LineInformations);
            }
        }

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

        public StatisticsChartViewModel()
        {
            _notify = new PerfEx.Infrastructure.PropertyChangedNotifier(this, () => PropertyChanged);
            _informations = new ObservableCollection<BetdataInfo>();
            _lineInformations = new ObservableCollection<KeyValuePair<DateTime, double>>();
            _barInformations = new ObservableCollection<KeyValuePair<DateTime, double>>();

            if (DesignerProperties.IsInDesignTool) {

                ChartName = "TwoWins (102-351)";

                Random random = new Random();
                DateTime time = DateTime.Now;
                double pot = 0;
                for (int count = 0; count < 40; count++)
                {
                    var data = new KeyValuePair<DateTime, double>(time, pot);
                    LineInformations.Add(data);
                    BarInformations.Add(data);

                    if (Maximum < pot)
                    {
                        Maximum = pot;
                    }
                    pot += count * random.Next(1, 53);
                    time = time.Add(TimeSpan.FromMinutes(18));
                }
                Interval = (int)(Maximum / 5);

                Informations.Add(new BetdataInfo {
                    Player = "John",
                    GameState = "Normal",
                    Time = new DateTime(2010, 11, 3, 11, 42, 21),
                    Bet = 70000,
                    Getback = 123456,
                    HandID = 11,
                    Change = true,
                    OldBet = 1,
                    Pot = 1234567,
                    WinState = "High"
                    ,
                    Round = 1
                });
                Informations.Add(new BetdataInfo {
                    Player = "John",
                    GameState = "Critical",
                    Time = new DateTime(2010, 11, 3, 12, 52, 21),
                    Bet = 70000,
                    Getback = 12345600,
                    HandID = 351,
                    Pot = 1234567,
                    WinState = "High"
                    ,
                    Round = 1
                });
                Informations.Add(new BetdataInfo {
                    Player = "Donal",
                    GameState = "Critical",
                    Time = new DateTime(2010, 11, 3, 11, 50, 32),
                    Bet = 12,
                    Getback = 4521,
                    HandID = 4563,
                    Pot = 32561,
                    WinState = "Low"
                    ,
                    Round = 1
                });
                Informations.Add(new BetdataInfo {
                    Player = "Carry",
                    GameState = "Critical",
                    Time = new DateTime(2010, 11, 3, 12, 52, 21),
                    Bet = 70000,
                    Getback = 12345600,
                    HandID = 351,
                    Change = true,
                    OldBet = 123,
                    Pot = 1234567,
                    WinState = "High"
                    ,
                    Round = 2
                });
                Informations.Add(new BetdataInfo {
                    Player = "ABC",
                    GameState = "Critical",
                    Time = new DateTime(2010, 11, 3, 12, 52, 21),
                    Bet = 70000,
                    Getback = 12345600,
                    HandID = 351,
                    OldBet = 5523,
                    Change = true,
                    Pot = 1234567,
                    WinState = "Low"
                    ,
                    Round = 2
                });
            }
        } 

        #endregion Constructors

        #region INotifyPropertyChanged member
        
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged member
    }
}
