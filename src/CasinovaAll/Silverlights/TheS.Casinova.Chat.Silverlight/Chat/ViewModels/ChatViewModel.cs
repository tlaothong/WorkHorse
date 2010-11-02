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

namespace TheS.Casinova.Chat.ViewModels
{
    public class ChatViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> _channels;
        private ObservableCollection<string> _players;

        public ObservableCollection<string> Players
        {
            get { return _players; }
            set
            {
                _players = value;
                RaisePropertyChanged("Players");
            }
        }

        public ObservableCollection<string> Channels
        {
            get { return _channels; }
            set
            {
                _channels = value;
                RaisePropertyChanged("Channels");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            var temp = PropertyChanged;
            if (temp != null) {
                temp(this,new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
