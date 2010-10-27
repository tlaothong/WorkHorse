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
using TheS.Casinova.Common;
using System.Collections.Specialized;

namespace CasinovaAllStars.ViewModels
{
    // TODO : Error navigation when using this viewmodel
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Lazy<ChildWindow, IPopupContentMetadata>> _popups;
        private ReadOnlyObservableCollection<Lazy<ChildWindow, IPopupContentMetadata>> _readOnlyPopups;

        public MainViewModel()
        {
            if (App.SupportContentDownloaded == false)
            {
                App.SupportContentDownloadCompleted += new EventHandler(App_SupportContentDownloadCompleted);
            }
            _popups = new ObservableCollection<Lazy<ChildWindow, IPopupContentMetadata>>();
            _readOnlyPopups = new ReadOnlyObservableCollection<Lazy<ChildWindow, IPopupContentMetadata>>(_popups);
        }

        void App_SupportContentDownloadCompleted(object sender, EventArgs e)
        {
            ((INotifyCollectionChanged)App.ModuleLoader.PopupContents).CollectionChanged += new NotifyCollectionChangedEventHandler(MainViewModel_CollectionChanged);
            PropertyChangedEventHandler temp = PropertyChanged;
            if (temp != null) {
                temp(this, new PropertyChangedEventArgs("Popups"));
            }
        }

        void MainViewModel_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            _popups.Clear();
            foreach (var item in App.ModuleLoader.PopupContents) {
                _popups.Add(item);
            }
        }

        public ReadOnlyObservableCollection<Lazy<ChildWindow, IPopupContentMetadata>> Popups
        {
            get { return _readOnlyPopups; }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
