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

namespace TheS.Casinova.PlayerAccount.ViewModels
{
    public class InformationViewModel : INotifyPropertyChanged
    {
        #region Fields
        
        private PerfEx.Infrastructure.PropertyChangedNotifier _notify;
        private double _currentTotal;
        private double _refundable;
        private double _nonRefundable;

        #endregion Fields

        #region Properties

        /// <summary>
        /// เงินที่ไม่สามารถถอนได้
        /// </summary>
        public double NonRefundable
        {
            get { return _nonRefundable; }
            set
            {
                if (_nonRefundable != value)
                {
                    _nonRefundable = value;
                    _notify.Raise(() => NonRefundable);
                }
            }
        }

        /// <summary>
        /// เงินที่สามารถถอนได้
        /// </summary>
        public double Refundable
        {
            get { return _refundable; }
            set
            {
                if (_refundable != value)
                {
                    _refundable = value;
                    _notify.Raise(() => Refundable);
                }
            }
        }

        /// <summary>
        /// เงินที่มีอยู่ทั้งหมด 
        /// ทั้งถอนได้และถอนไม่ได้
        /// </summary>
        public double CurrentTotal
        {
            get { return _currentTotal; }
            set
            {
                if (_currentTotal != value)
                {
                    _currentTotal = value;
                    _notify.Raise(() => CurrentTotal);
                }
            }
        }

        #endregion Properties

        #region Constructors
        
        public InformationViewModel()
        {
            _notify = new PerfEx.Infrastructure.PropertyChangedNotifier(this, () => PropertyChanged);

            if (DesignerProperties.IsInDesignTool)
            {
                _currentTotal = 533;
                _nonRefundable = 433;
                _refundable = 100;
            }

        }

        #endregion Constructors

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
