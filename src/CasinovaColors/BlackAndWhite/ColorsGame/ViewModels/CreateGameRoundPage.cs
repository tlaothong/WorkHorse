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
using ColorsGame.ColorsGameSvc;
using System.Collections.ObjectModel;

namespace ColorsGame.ViewModels
{
    public class CreateGameRoundPage: INotifyPropertyChanged
    {
        #region Fields
        
        private PropertyChangedNotifier _notif;
        //private ColorsGameServiceSoapClient _svc;
        private int _tableCount;
        private int _durationTime;
        private int _intervalTime;
        private string _configurationName;
        private ObservableCollection<Models.GameTable> _sampleTable;
        private ObservableCollection<Models.GameRound> _gameTable;

        #endregion

        #region Properties

        public string ConfigurationName
        {
            get { return _configurationName; }
            set
            {
                _configurationName = value;
                _notif.Raise(()=>ConfigurationName);
            }
        }

        public ObservableCollection<Models.GameTable> SampleTable
        {
            get { return _sampleTable; }
            set
            {
                _sampleTable = value;
                _notif.Raise(() => SampleTable);
            }
        }

        public ObservableCollection<Models.GameRound> GameTable
        {
            get { return _gameTable; }
            set
            {
                _gameTable = value;
                _notif.Raise(()=>GameTable);
            }
        }

        public int IntervalTime
        {
            get { return _intervalTime; }
            set
            {
                _intervalTime = value;
                _notif.Raise(() => IntervalTime);
            }
        }

        public int DurationTime
        {
            get { return _durationTime; }
            set
            {
                _durationTime = value;
                _notif.Raise(() => DurationTime);
            }
        }

        public int TableCount
        {
            get { return _tableCount; }
            set
            {
                _tableCount = value;
                _notif.Raise(() => TableCount);
            }
        } 

        #endregion

        #region Events
        
        public event PropertyChangedEventHandler PropertyChanged; 

        #endregion

        #region Constructors
        
        public CreateGameRoundPage()
        {
            _notif = new PropertyChangedNotifier(this, () => PropertyChanged);
            //_svc = new ColorsGameServiceSoapClient();
            _sampleTable = new ObservableCollection<Models.GameTable>();
            _gameTable = new ObservableCollection<Models.GameRound>();
        } 

        #endregion

        #region Methods

        public void Save()
        {
            const int AcceptValue = 0;
            if (DurationTime >= AcceptValue && IntervalTime >= AcceptValue)
                for (int count = 1; count <= _tableCount; count++) {
                    SampleTable.Add(new Models.GameTable {
                        TableID = count,
                        GameDuration = _durationTime,
                        Interval = _intervalTime
                    });
                }
        }

        public void Generate()
        {
            var time = DateTime.Now;
            int roundID = 1;
            foreach (var tableConfig in SampleTable) {
                GameTable.Add(new Models.GameRound {
                    TableID = tableConfig.TableID,
                     StartTime = time,
                     RoundID = roundID++,
                     EndTime = time.Add(TimeSpan.FromMinutes( tableConfig.GameDuration))
                });
                time = time.Add(TimeSpan.FromMinutes(tableConfig.Interval));
            }
        } 

        #endregion
    }
}
