﻿using System;
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
    public class GameStatisticsViewModel : INotifyPropertyChanged
    {
        #region Fields
        
        private PerfEx.Infrastructure.PropertyChangedNotifier _notify;
        //private ObservableCollection<WinnerInfo> _informations;
        private ObservableCollection<string> _games;
        private DateTime _firstData;
        private DateTime _secondData;

        #endregion Fields

        #region Properties

        //public ObservableCollection<WinnerInfo> Informations
        //{
        //    get { return _informations; }
        //    set
        //    {
        //        _informations = value;
        //        _notify.Raise(() => Informations);
        //    }
        //}

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
            //_informations = new ObservableCollection<WinnerInfo>();
            _games = new ObservableCollection<string>();

            if (DesignerProperties.IsInDesignTool) {
                //Informations.Add(new WinnerInfo {
                //    Round = 1,
                //    Time = new DateTime(2010, 11, 3, 11, 23, 52),
                //    Winner = "Sakul"
                //});

                Games.Add("9");
                Games.Add("99");
                Games.Add("999");
                Games.Add("9999");
            }
        }

        #endregion Constructors

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged
    }
}
