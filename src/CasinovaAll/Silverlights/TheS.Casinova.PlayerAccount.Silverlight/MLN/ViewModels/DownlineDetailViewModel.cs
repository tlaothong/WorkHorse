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
    public class DownlineDetailViewModel : INotifyPropertyChanged
    {
        private int _total;
        private int _level;
        private double _incomePerday;
        private double _includePerday;

        public double IncludePerday
        {
            get { return _includePerday; }
            set
            {
                _includePerday = value;
                OnChange("IncludePerday");
            }
        }

        public double IncomePerday
        {
            get { return _incomePerday; }
            set
            {
                _incomePerday = value;
                OnChange("IncomePerday");
            }
        }

        public int Level
        {
            get { return _level; }
            set
            {
                _level = value;
                OnChange("Level");
            }
        }

        public int Total
        {
            get { return _total; }
            set
            {
                _total = value;
                OnChange("Total");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnChange(string propertyName)
        {
            PropertyChangedEventHandler temp = PropertyChanged;
            if (temp != null) {
                temp(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
