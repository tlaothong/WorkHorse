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

        private double _currentBunusAvailable;
        private int _firstLevel;
        private int _secondLevel;
        private int _thirdLevel;
        private object _informations;

        #endregion Fields

        #region Properties

        public object Informations
        {
            get { return _informations; }
            set
            {
                _informations = value;
                RaisePropertyChanged("Informations");
            }
        }

        public int ThirdLevel
        {
            get { return _thirdLevel; }
            set
            {
                _thirdLevel = value; RaisePropertyChanged("ThirdLevel");
            }
        }

        public int SecondLevel
        {
            get { return _secondLevel; }
            set
            {
                _secondLevel = value; RaisePropertyChanged("SecondLevel");
            }
        }

        public int FirstLevel
        {
            get { return _firstLevel; }
            set
            {
                _firstLevel = value; RaisePropertyChanged("FirstLevel");
            }
        }

        public double CurrentBunusAvailable
        {
            get { return _currentBunusAvailable; }
            set
            {
                _currentBunusAvailable = value;
                RaisePropertyChanged("CurrentBunusAvailable");
            }
        }

        #endregion Properties

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
