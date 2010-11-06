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
        private string _creditCardCardType;
        private string _cardNumber;
        private DateTime _expireDate;
        private string _ownerName;
        private string _cardValidationNumber;
        private string _otherCardType;
        private string _paymentEmailAddress;
        private string _identityNumber;
        private bool _otherRequire;

        #endregion Fields

        #region Properties

        /// <summary>
        /// ชนิดของบัตรเครดิต
        /// </summary>
        public string CreditCardCardType
        {
            get { return _creditCardCardType; }
            set
            {
                if (_creditCardCardType!=value)
                {
                    _creditCardCardType = value;
                    _notify.Raise(() => CreditCardCardType); 
                }
            }
        }

        /// <summary>
        /// รหัสบัตรเครดิต
        /// </summary>
        public string CardNumber
        {
            get { return _cardNumber; }
            set
            {
                if (_cardNumber!=value)
                {
                    _cardNumber = value;
                    _notify.Raise(() => CardNumber); 
                }
            }
        }

        /// <summary>
        /// วันหมดอายุ
        /// </summary>
        public DateTime ExpireDate
        {
            get { return _expireDate; }
            set
            {
                if (_expireDate!=value)
                {
                    _expireDate = value;
                    _notify.Raise(() => ExpireDate); 
                }
            }
        }

        /// <summary>
        /// ชื่อผู้ถือบัตร
        /// </summary>
        public string OwnerName
        {
            get { return _ownerName; }
            set
            {
                if (_ownerName!=value)
                {
                    _ownerName = value;
                    _notify.Raise(() => OwnerName); 
                }
            }
        }


        public string CardValidationNumber
        {
            get { return _cardValidationNumber; }
            set
            {
                if (_cardValidationNumber!=value)
                {
                    _cardValidationNumber = value;
                    _notify.Raise(() => CardValidationNumber); 
                }
            }
        }

        /// <summary>
        /// ชื่อชนิดบัตรอื่นๆ
        /// </summary>
        public string OtherCardType
        {
            get { return _otherCardType; }
            set
            {
                if (_otherCardType!=value)
                {
                    _otherCardType = value;
                    _notify.Raise(() => OtherCardType); 
                }
            }
        }

        /// <summary>
        /// Email ของ paypal
        /// </summary>
        public string PaymentEmailAddress
        {
            get { return _paymentEmailAddress; }
            set
            {
                if (_paymentEmailAddress!=value)
                {
                    _paymentEmailAddress = value;
                    _notify.Raise(() => PaymentEmailAddress); 
                }
            }
        }

        /// <summary>
        /// หมายเลขบัตรประชาชน
        /// </summary>
        public string IdentityNumber
        {
            get { return _identityNumber; }
            set
            {
                if (_identityNumber!=value)
                {
                    _identityNumber = value;
                    _notify.Raise(() => IdentityNumber); 
                }
            }
        }

        /// <summary>
        /// Require immediate payment when buyer use buy it now.
        /// </summary>
        public bool OtherRequire
        {
            get { return _otherRequire; }
            set
            {
                if (_otherRequire!=value)
                {
                    _otherRequire = value;
                    _notify.Raise(() => OtherRequire); 
                }
            }
        }

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
                CurrentTotal = 533;
                NonRefundable = 433;
                Refundable = 100;
                CreditCardCardType = "Master card";
                CardNumber = "123-56598-556";
                ExpireDate = DateTime.Now;
                OwnerName = "Miolynet";
                CardValidationNumber = "774-55-666";
                OtherCardType = "American express";
                PaymentEmailAddress = "paypal@paypal.com";
                IdentityNumber = "1-155-663-3-487-3";
                OtherRequire = true;
            }

        }
        #endregion Constructors

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}