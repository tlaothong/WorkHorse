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
using TheS.Casinova.MLN.Models;

namespace TheS.Casinova.MLN.ViewModels
{
    public class DownlineDetailViewModel : INotifyPropertyChanged
    {
        #region Fields
        
        private int _total;
        private int _level;
        private double _incomePerday;
        private double _includePerday;
        private ObservableCollection<DownlineDetail> _informations;

        #endregion Fields

        #region Properties

        public ObservableCollection<DownlineDetail> Informations
        {
            get { return _informations; }
            set
            {
                _informations = value;
                RaisePropertyChanged("Informations");
            }
        }

        public double IncludePerday
        {
            get { return _includePerday; }
            set
            {
                if (_includePerday!=value) {
                    _includePerday = value;
                    RaisePropertyChanged("IncludePerday"); 
                }
            }
        }

        public double IncomePerday
        {
            get { return _incomePerday; }
            set
            {
                if (_incomePerday!=value) {
                    _incomePerday = value;
                    RaisePropertyChanged("IncomePerday"); 
                }
            }
        }

        public int Level
        {
            get { return _level; }
            set
            {
                if (_level!=value) {
                    _level = value;
                    RaisePropertyChanged("Level"); 
                }
            }
        }

        public int Total
        {
            get { return _total; }
            set
            {
                if (_total!=value) {
                    _total = value;
                    RaisePropertyChanged("Total"); 
                }
            }
        }

        #endregion Properties

        #region Constructors

        public DownlineDetailViewModel()
        {
            _informations = new ObservableCollection<DownlineDetail>();

            if (DesignerProperties.IsInDesignTool) {
                IncomePerday = 30;
                IncludePerday = 1.2;
                Level = 1;
                Total = 42;
                Informations.Add(new DownlineDetail {
                    Name = "John",
                    GroupCount = 45
                });
                Informations.Add(new DownlineDetail {
                    Name = "Doe",
                    GroupCount = 4
                });
                Informations.Add(new DownlineDetail {
                    Name = "Test",
                    GroupCount = 330
                });
            }
        } 

        #endregion Constructors

        #region Methods
        
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler temp = PropertyChanged;
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
