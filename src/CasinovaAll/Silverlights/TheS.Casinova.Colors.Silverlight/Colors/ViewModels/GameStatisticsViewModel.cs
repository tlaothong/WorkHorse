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

namespace TheS.Casinova.Colors.ViewModels
{
    public class GameStatisticsViewModel : INotifyPropertyChanged
    {
        #region Fields

        private PerfEx.Infrastructure.PropertyChangedNotifier _notify;
        private string _winner;
        private int _hands;
        private double _blackPot;
        private double _whitePot;
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

        public double WhitePot
        {
            get { return _whitePot; }
            set
            {
                _whitePot = value;
                    _notify.Raise(() => WhitePot);
            }
        }

        public double BlackPot
        {
            get { return _blackPot; }
            set { _blackPot = value;
            _notify.Raise(() => BlackPot);
            }
        }

        public int Hands
        {
            get { return _hands; }
            set { _hands = value;
            _notify.Raise(() => Hands);
            }
        }

        public string Winner
        {
            get { return _winner; }
            set
            {
                _winner = value;
                _notify.Raise(() => Winner);
            }
        }

        #endregion Properties

        #region Constructors
        
        public GameStatisticsViewModel()
        {
            _notify = new PerfEx.Infrastructure.PropertyChangedNotifier(this, () => PropertyChanged);

            if (DesignerProperties.IsInDesignTool) {
                Winner = "Balck";
                BlackPot = 456781;
                WhitePot = 12314;
                Hands = 1254;
            }
        }

        #endregion Constructors

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged members
    }
}
