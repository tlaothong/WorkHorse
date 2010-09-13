using System;
using System.Linq;
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
using MvvmCollection.MvvmCollectionSvc;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MvvmCollection.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private PropertyChangedNotifier _notif;
        private MvvmCollectionServiceClient _svc;

        private readonly ObservableCollection<Person> _people;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel()
        {
            _notif = new PropertyChangedNotifier(this, () => PropertyChanged);
            _svc = new MvvmCollectionServiceClient();
            _people = new ObservableCollection<Person>();

            _svc.ListPeopleCompleted += new EventHandler<ListPeopleCompletedEventArgs>(_svc_ListPeopleCompleted);
        }

        void _svc_ListPeopleCompleted(object sender, ListPeopleCompletedEventArgs e)
        {
            e.Result.ToList().ForEach(_people.Add);
        }

        public ObservableCollection<Person> People
        {
            get
            {
                return _people;
            }
        }

        public void AppendList()
        {
            _svc.ListPeopleAsync();
        }

        public void Clear()
        {
            _people.Clear();
        }

        public void Remove(int index)
        {
            _people.RemoveAt(index);
        }
    }
}
