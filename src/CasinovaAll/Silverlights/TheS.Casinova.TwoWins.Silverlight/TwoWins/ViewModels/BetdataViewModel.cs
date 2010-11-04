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
using TheS.Casinova.TwoWins.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace TheS.Casinova.TwoWins.ViewModels
{
    public class BetdataViewModel : INotifyPropertyChanged
    {
        #region Fields
        
        private PerfEx.Infrastructure.PropertyChangedNotifier _notify;
        private ObservableCollection<BetdataInfo> _informations;

        #endregion Fields

        #region Properties
        
        public ObservableCollection<BetdataInfo> Informations
        {
            get { return _informations; }
            set
            {
                _informations = value;
                _notify.Raise(() => Informations);
            }
        }

        #endregion Properties

        #region Constructors

        public BetdataViewModel()
        {
            _notify = new PerfEx.Infrastructure.PropertyChangedNotifier(this, () => PropertyChanged);
            _informations = new ObservableCollection<BetdataInfo>();

            if (DesignerProperties.IsInDesignTool) {
                Informations.Add(new BetdataInfo {
                    Player = "John",
                    State = "Normal",
                    Time = new DateTime(2010, 11, 3, 11, 42, 21),
                    Bet = 70000,
                    Getback = 123456,
                    HandID = 11,
                    Change = true,
                    OldBet = 1,
                    Pot = 1234567,
                    Status = "High"
                    ,
                    Round = 1
                });
                Informations.Add(new BetdataInfo {
                    Player = "John",
                    State = "Critical",
                    Time = new DateTime(2010, 11, 3, 12, 52, 21),
                    Bet = 70000,
                    Getback = 12345600,
                    HandID = 351,
                    Pot = 1234567,
                    Status = "High"
                    ,
                    Round = 1
                });
                Informations.Add(new BetdataInfo {
                    Player = "Donal",
                    State = "Critical",
                    Time = new DateTime(2010, 11, 3, 11, 50, 32),
                    Bet = 12,
                    Getback = 4521,
                    HandID = 4563,
                    Pot = 32561,
                    Status = "Low"
                    ,
                    Round = 1
                });
                Informations.Add(new BetdataInfo {
                    Player = "Carry",
                    State = "Critical",
                    Time = new DateTime(2010, 11, 3, 12, 52, 21),
                    Bet = 70000,
                    Getback = 12345600,
                    HandID = 351,
                    Change = true,
                    OldBet = 123,
                    Pot = 1234567,
                    Status = "High"
                    ,
                    Round = 2
                });
                Informations.Add(new BetdataInfo {
                    Player = "ABC",
                    State = "Critical",
                    Time = new DateTime(2010, 11, 3, 12, 52, 21),
                    Bet = 70000,
                    Getback = 12345600,
                    HandID = 351,
                    OldBet = 5523,
                    Change = true,
                    Pot = 1234567,
                    Status = "Low"
                    ,
                    Round = 2
                });
            }
        } 

        #endregion Constructors

        #region INotifyPropertyChanged member
        
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged member
    }
}
