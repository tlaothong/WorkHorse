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
using PerfEx.Infrastructure;
using System.Collections.ObjectModel;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.ViewModels
{
    public class GameStatisticsViewModel : INotifyPropertyChanged
    {
        #region Fields

        private PropertyChangedNotifier _notify;
        private double _pot;
        private double _hands;
        private ObservableCollection<WinnerInfo> _informations;
        private DateTime _firstData;
        private DateTime _secondData;

        #endregion Fields

        #region Properties

        public DateTime SecondData
        {
            get { return _secondData; }
            set
            {
                if (_secondData!=value) {
                    _secondData = value;
                    _notify.Raise(() => SecondData); 
                }
            }
        }

        public DateTime FirstData
        {
            get { return _firstData; }
            set
            {
                if (_firstData!=value) {
                    _firstData = value;
                    _notify.Raise(() => FirstData); 
                }
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

        public double Hands
        {
            get { return _hands; }
            set
            {
                if (_hands != value) {
                    _hands = value;
                    _notify.Raise(() => Hands); 
                }
            }
        }

        public double Pot
        {
            get { return _pot; }
            set
            {
                if (_pot!=value) {
                    _pot = value;
                    _notify.Raise(() => Pot); 
                }
            }
        }

        #endregion Properties

        #region Constructor

        public GameStatisticsViewModel()
        {
            _notify = new PropertyChangedNotifier(this, () => PropertyChanged);
            _informations = new ObservableCollection<WinnerInfo>();

            if (DesignerProperties.IsInDesignTool) {
                Pot = 123456789;
                Hands = 75245;
                Informations.Add(new WinnerInfo {
                    Round = 1,
                    Player = "John",
                    GameState = "Normal",
                    Time = new DateTime(2010, 11, 3, 11, 32, 21),
                    Bet = 70000,
                    Getback = 123456,
                    WinState = "High"
                });
                Informations.Add(new WinnerInfo {
                    Round = 1,
                    Player = "Doe",
                    GameState = "Critical",
                    Time = new DateTime(2010, 11, 3, 11, 42, 51),
                    Bet = 70001,
                    Getback = 87654321,
                    WinState = "High"
                });
               
                Informations.Add(new WinnerInfo {
                    Round = 2,
                    Player = "Thailand",
                    GameState = "Normal",
                    Time = new DateTime(2010, 11, 3, 07, 11, 08),
                    Bet = 523,
                    Getback = 123456,
                    WinState = "Low"
                });
            }
        }

        #endregion Constructor

        #region INotifyPropertyChanged member

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged member
    }
}