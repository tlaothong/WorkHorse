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
using System.Linq;
using System.Collections.Generic;

namespace CasinovaAllStars.ViewModels
{
    // TODO : Error navigation when using this viewmodel
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Fields
        
        private ObservableCollection<Lazy<ChildWindow, IPopupContentMetadata>> _popups;

        private PerfEx.Infrastructure.PropertyChangedNotifier _notif;

        #endregion Fields

        #region Properties

        public IEnumerable<Lazy<ChildWindow, IPopupContentMetadata>> PopupsTop
        {
            get { return _popups.Where(p => p.Metadata.GroupName == "top"); }
        }

        public IEnumerable<Lazy<ChildWindow, IPopupContentMetadata>> PopupsBottom
        {
            get { return _popups.Where(p => p.Metadata.GroupName == "bottom"); }
        }

        #endregion Properties

        #region Constructors

        public MainViewModel()
        {
            _notif = new PerfEx.Infrastructure.PropertyChangedNotifier(this, () => PropertyChanged);
            if (App.SupportContentDownloaded == false) {
                App.SupportContentDownloadCompleted += new EventHandler(App_SupportContentDownloadCompleted);
            }
            _popups = new ObservableCollection<Lazy<ChildWindow, IPopupContentMetadata>>();
        } 

        #endregion Constructors

        #region Methods

        private void App_SupportContentDownloadCompleted(object sender, EventArgs e)
        {
            ((INotifyCollectionChanged)App.ModuleLoader.PopupContents).CollectionChanged += new NotifyCollectionChangedEventHandler(MainViewModel_CollectionChanged);
        }

        private void MainViewModel_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            _popups.Clear();
            foreach (var item in App.ModuleLoader.PopupContents) {
                _popups.Add(item);
            }

            _notif.Raise(() => PopupsTop);
            _notif.Raise(() => PopupsBottom);
        }

        #endregion Methods

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
