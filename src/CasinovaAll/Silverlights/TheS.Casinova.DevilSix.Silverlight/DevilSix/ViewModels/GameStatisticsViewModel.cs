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
using TheS.Casinova.DevilSix.Models;

namespace TheS.Casinova.DevilSix.ViewModels
{
    public class GameStatisticsViewModel : INotifyPropertyChanged
    {
        #region Fields

        private PerfEx.Infrastructure.PropertyChangedNotifier _notify;
        private ObservableCollection<WinnerInfo> _informations;
        private ObservableCollection<string> _games;
        private DateTime _firstData;
        private DateTime _secondData;

        #endregion Fields

        #region Properties

        public DateTime SecondData
        {
            get { return _secondData; }
            set
            {
                _secondData = value;
                _notify.Raise(() => SecondData);
            }
        }

        public DateTime FirstData
        {
            get { return _firstData; }
            set
            {
                _firstData = value;
                _notify.Raise(() => FirstData);
            }
        }

        public ObservableCollection<WinnerInfo> Informations
        {
            get { return _informations; }
            set
            {
                _informations = value;
                _notify.Raise(() => Informations);
            }
        }

        public ObservableCollection<string> Games
        {
            get { return _games; }
            set
            {
                _games = value;
                _notify.Raise(() => Games);
            }
        }

        #endregion Properties

        #region Constructors
        
        public GameStatisticsViewModel()
        {
            _notify = new PerfEx.Infrastructure.PropertyChangedNotifier(this, () => PropertyChanged);
            _informations = new ObservableCollection<WinnerInfo>();
            _games = new ObservableCollection<string>();

            if (DesignerProperties.IsInDesignTool) {
                Informations.Add(new WinnerInfo {
                    Pot = 72,
                    Round = 55,
                    Time = new DateTime(2010,11,3,10,22,53),
                    Winner ="Fake"
                });
                Informations.Add(new WinnerInfo {
                    Pot = 69,
                    Round = 54,
                    Time = new DateTime(2010,11,3,10, 24, 03),
                    Winner = "Hola"
                });

                Games.Add("9");
                Games.Add("99");
                Games.Add("999");
                Games.Add("9999");
            }
        }

        #endregion Constructors

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged members
    }
}
