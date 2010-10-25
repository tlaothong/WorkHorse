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
using PerfEx.Infrastructure;

namespace TheS.Casinova.Fortune.ViewModels
{
    public class FortuneModel : INotifyPropertyChanged
    {

        private PropertyChangedNotifier _notify;
        private string _subtitle;
        private string _informations;

        public string Subtitle
        {
            get { return _subtitle; }
            set
            {
                _subtitle = value;
                _notify.Raise(() => Subtitle);
            }
        }

        public string Informations
        {
            get { return _informations; }
            set
            {
                _informations = value;
                _notify.Raise(() => Informations);
            }
        }

        public FortuneModel()
        {
            _notify = new PropertyChangedNotifier(this, () => PropertyChanged);
        }

        public void GetCardInformation()
        {
            Subtitle = "Card name: Holanla.";
            Informations = "Information, in its most restricted technical sense, is an ordered sequence of symbols. As a concept, however, information has many meanings.[1] Moreover, the concept of information is closely related to notions of constraint, communication, control, data, form, instruction, knowledge, meaning, mental stimulus, pattern, perception, and representation.";
        }

        #region INotifyPropertyChanged member

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged member
    }
}
