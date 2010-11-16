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
    public class AccountInformationViewModel : INotifyPropertyChanged
    {
        #region Fields
        
        private PerfEx.Infrastructure.PropertyChangedNotifier _notify;
        private string _name;
        private string _email;
        private string _gender;
        private string _newPassword;
        private string _confirmPassword;
        private string _currentPassword; 

        #endregion Fields

        #region Properties

        public string CurrentPassword
        {
            get { return _currentPassword; }
            set
            {
                if (_currentPassword != value)
                {
                    _currentPassword = value;
                    _notify.Raise(() => CurrentPassword);
                }
            }
        }

        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                if (_confirmPassword != value)
                {
                    _confirmPassword = value;
                    _notify.Raise(() => ConfirmPassword);
                }
            }
        }

        public string NewPassword
        {
            get { return _newPassword; }
            set
            {
                if (_newPassword != value)
                {
                    _newPassword = value;
                    _notify.Raise(() => NewPassword);
                }
            }
        }

        public string Gender
        {
            get { return _gender; }
            set
            {
                if (_gender != value)
                {
                    _gender = value;
                    _notify.Raise(() => Gender);
                }
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    _notify.Raise(() => Email);
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    _notify.Raise(() => Name);
                }
            }
        }

        #endregion Properties

        public AccountInformationViewModel()
        {
            _notify = new PerfEx.Infrastructure.PropertyChangedNotifier(this, () => PropertyChanged);

            if (DesignerProperties.IsInDesignTool)
            {
                _name = "Miolynet";
                _email = "miolynet@test.com";
                _gender = "Men";
                _newPassword = "helloworld";
                _confirmPassword = "helloworld";
                _currentPassword = "helloworld";
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
