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

namespace TheS.Casinova.ChipExchange.ViewModels
{
    public class AmountConfirmationViewModel : INotifyPropertyChanged
    {
        #region Fields

        private PerfEx.Infrastructure.PropertyChangedNotifier _notify;
        private string _payBy;
        private string _payType;
        private double _chips;

        #endregion Fields

        #region Properties

        public double Chips
        {
            get { return _chips; }
            set
            {
                if (_chips!=value)
                {
                    _chips = value;
                    _notify.Raise(() => Chips); 
                }
            }
        }

        public string PayType
        {
            get { return _payType; }
            set
            {
                if (_payType!=value)
                {
                    _payType = value;
                    _notify.Raise(() => PayType); 
                }
            }
        }

        public string PayBy
        {
            get { return _payBy; }
            set
            {
                if (_payBy!=value)
                {
                    _payBy = value;
                    _notify.Raise(() => PayBy); 
                }
            }
        }

        #endregion Properties

        #region Constructors
        
        public AmountConfirmationViewModel()
        {
            _notify = new PerfEx.Infrastructure.PropertyChangedNotifier(this, () => PropertyChanged);
            if (DesignerProperties.IsInDesignTool)
            {
                PayBy = "Master card.";
                PayType = "Non-refundable chips.";
                Chips = 7563214;
            }
        }

        #endregion Constructors

        #region Methods

        public void OK()
        {
            // TODO : OK button clicked
        }

        #endregion Methods

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}