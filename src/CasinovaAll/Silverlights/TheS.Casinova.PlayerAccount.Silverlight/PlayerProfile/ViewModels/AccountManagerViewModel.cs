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
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.PlayerProfile.ViewModels
{
    public class AccountManagerViewModel : INotifyPropertyChanged
    {
        #region Fields

        private PerfEx.Infrastructure.PropertyChangedNotifier _norify;
        private DateTime _firstSearch;
        private DateTime _secondSearch;
        private ObservableCollection<LogEvent> _logEventInformations;

        #endregion Fields

        #region Properties

        public ObservableCollection<LogEvent> LogEventInformations
        {
            get { return _logEventInformations; }
            set
            {
                if (_logEventInformations != value)
                {
                    _logEventInformations = value;
                    _norify.Raise(() => LogEventInformations);
                }
            }
        }

        public DateTime SecondSearch
        {
            get { return _secondSearch; }
            set
            {
                if (_secondSearch != value)
                {
                    _secondSearch = value;
                    _norify.Raise(() => SecondSearch);
                }
            }
        }

        public DateTime FirstSearch
        {
            get { return _firstSearch; }
            set
            {
                if (_firstSearch != value)
                {
                    _firstSearch = value;
                    _norify.Raise(() => FirstSearch);
                }
            }
        }

        #endregion Properties

        #region Constructors

        public AccountManagerViewModel()
        {
            _norify = new PerfEx.Infrastructure.PropertyChangedNotifier(this, () => PropertyChanged);
            _logEventInformations = new ObservableCollection<LogEvent>();

            if (DesignerProperties.IsInDesignTool)
            {
                LogEventInformations.Add(new LogEvent
                {
                    Time = DateTime.Now,
                    Action = "You bet game TwoWins handID: 563 on critical time",
                    Money = 30
                });
                LogEventInformations.Add(new LogEvent
                {
                    Time = DateTime.Now.Add(TimeSpan.FromMinutes(-5)),
                    Action= "You bet in game Colors, choose White",
                    Money = 5990
                });
                LogEventInformations.Add(new LogEvent
                {
                    Time = DateTime.Now,
                    Action = "You win in game Colors !!",
                    Money = 10000
                });
            }
        }

        #endregion Constructors

        #region Methods

        public void Search()
        {
            // TODO: Search button clicked
        }

        #endregion Methods

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}