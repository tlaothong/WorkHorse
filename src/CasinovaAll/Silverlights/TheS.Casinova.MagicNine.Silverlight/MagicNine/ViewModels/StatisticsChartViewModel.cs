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
using System.Collections.Generic;

namespace TheS.Casinova.MagicNine.ViewModels
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

                ChartName = "Magic9 (1-956)";

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

               
            }
        }

        #endregion Constructors

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged members
    }
}
