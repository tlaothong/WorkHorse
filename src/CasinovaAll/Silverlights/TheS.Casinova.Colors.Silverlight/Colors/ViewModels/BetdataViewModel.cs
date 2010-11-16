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
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.ViewModels
{
    public class BetdataViewModel : INotifyPropertyChanged
    {
        #region Fields
        
        private PerfEx.Infrastructure.PropertyChangedNotifier _notify;
        private ObservableCollection<BetdataInfo> _informations;

        #endregion Fields

        #region Properties
        
        /// <summary>
        /// ข้อมูลของการลงเงินทั้งหมด
        /// </summary>
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
                    Color = "White",
                    Player = "OhLanla",
                    Round = 123,
                    Time = new DateTime(2010,11,3,12,32,50),
                    WinColor = "Black",
                    Bet = 35,
                    WhitePot = 35,
                    BlackPot = 21,
                });
                Informations.Add(new BetdataInfo {
                    Color = "White",
                    Player = "Okacho",
                    Round = 123,
                    Time = new DateTime(2010, 11, 3, 12, 32, 54),
                    WinColor = "Black",
                    Bet = 550,
                    WhitePot = 1234,
                    BlackPot = 521,
                });
                Informations.Add(new BetdataInfo {
                    Color = "White",
                    Player = "Maximum",
                    Round = 123,
                    Match = true,
                    Time = new DateTime(2010, 11, 3, 12, 32, 55),
                    WinColor = "White",
                    Bet = 1,
                    WhitePot = 456,
                    BlackPot = 789,
                });
            }
        }

        #endregion Constructors

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged members
    }
}
