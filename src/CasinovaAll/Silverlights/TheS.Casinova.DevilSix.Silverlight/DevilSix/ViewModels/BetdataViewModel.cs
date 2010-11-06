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
                    Bet = 5,
                    Pot = 25,
                    Round = 41,
                    Time = new DateTime(2010, 11, 3, 10, 10, 52),
                    Winner = "Miolynet"
                });

                Informations.Add(new BetdataInfo {
                    Bet = 2,
                    Pot = 27,
                    Round = 41,
                    Time = new DateTime(2010, 11, 3, 10, 10, 53),
                    Winner = "Miolynet"
                });
                Informations.Add(new BetdataInfo {
                    Bet = 1,
                    Pot = 26,
                    Round = 41,
                    Time = new DateTime(2010, 11, 3, 10, 10, 52),
                    Winner = "Sakul"
                });
            }
        } 

        #endregion Constructors

        #region INotifyPropertyChanged members
        
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged members
    }
}
