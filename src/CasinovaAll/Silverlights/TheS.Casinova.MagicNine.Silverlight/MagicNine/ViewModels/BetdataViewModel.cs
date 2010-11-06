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
using TheS.Casinova.MagicNine.Models;

namespace TheS.Casinova.MagicNine.ViewModels
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
                    Pot = 99,
                    Round = 1,
                    Time = new DateTime(2010, 11, 3, 10, 53, 42),
                    Winner = "Mioylnet"
                });
                Informations.Add(new BetdataInfo {
                    Pot = 199,
                    Round = 2,
                    Time = new DateTime(2010, 11, 3, 10, 53, 52),
                    Winner = "Mioylnet"
                });
                Informations.Add(new BetdataInfo {
                    Pot = 299,
                    Round = 3,
                    Time = new DateTime(2010, 11, 3, 10, 54, 01),
                    Winner = "Quad"
                });
            }
        }

        #endregion Constructors

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged members
    }
}
