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

namespace TheS.Casinova.MLN.ViewModels
{
    public class AnotherPlayerInformationModel : INotifyPropertyChanged
    {
        #region Fields

        private PerfEx.Infrastructure.PropertyChangedNotifier _notify;
        private double _currentBunusAvailable;
        private int _firstLevel;
        private int _secondLevel;
        private int _thirdLevel;
        private double _thisMonth;
        private double _lastMonth;
        private double _lifeTime;

        #endregion Fields

        #region Properties

        public double LifeTime
        {
            get { return _lifeTime; }
            set
            {
                if (_lifeTime != value)
                {
                    _lifeTime = value;
                    _notify.Raise(() => LifeTime);
                }
            }
        }

        public double LastMonth
        {
            get { return _lastMonth; }
            set
            {
                if (_lastMonth != value)
                {
                    _lastMonth = value;
                    _notify.Raise(() => LastMonth);
                }
            }
        }

        public double ThisMonth
        {
            get { return _thisMonth; }
            set
            {
                if (_thisMonth != value)
                {
                    _thisMonth = value;
                    _notify.Raise(() => ThisMonth);
                }
            }
        }

        public int ThirdLevel
        {
            get { return _thirdLevel; }
            set
            {
                if (_thirdLevel!=value) {
                    _thirdLevel = value;
                    _notify.Raise(() => ThirdLevel);
                }
            }
        }

        public int SecondLevel
        {
            get { return _secondLevel; }
            set
            {
                if (_secondLevel!=value) {
                    _secondLevel = value;
                    _notify.Raise(() => SecondLevel);
                }
            }
        }

        public int FirstLevel
        {
            get { return _firstLevel; }
            set
            {
                if (_firstLevel!=value) {
                    _firstLevel = value;
                    _notify.Raise(() => FirstLevel);
                }
            }
        }

        public double CurrentBunusAvailable
        {
            get { return _currentBunusAvailable; }
            set
            {
                if (_currentBunusAvailable!=value) {
                    _currentBunusAvailable = value;
                    _notify.Raise(() => CurrentBunusAvailable);
                }
            }
        }

        #endregion Properties

        #region Constructors
        
        public AnotherPlayerInformationModel()
        {
            _notify = new PerfEx.Infrastructure.PropertyChangedNotifier(this, () => PropertyChanged);

            if (DesignerProperties.IsInDesignTool)
            {
                CurrentBunusAvailable = 1332;
                FirstLevel = 555;
                SecondLevel = 666;
                ThirdLevel = 111;
                ThisMonth = 100;
                LastMonth = 999;
                LifeTime = 100000;
            }
        }

        #endregion Constructors

        #region Methods

        public void RaisePropertyChanged(string propertyName)
        {
            var temp = PropertyChanged;
            if (temp != null) {
                temp(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion Methods

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged members
    }
}
