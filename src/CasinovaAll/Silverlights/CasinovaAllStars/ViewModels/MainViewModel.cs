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

namespace CasinovaAllStars.ViewModels
{
    // TODO : Error navigation when using this viewmodel
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            if (App.SupportContentDownloaded == false)
            {
                //App.SupportContentDownloadCompleted += new EventHandler(App_SupportDownloadedCompleted);
            }
        }

        public ReadOnlyObservableCollection<Lazy<ChildWindow, IPopupContentMetadata>> Popups
        {
            get { return App.ModuleLoader.PopupContents; }
        }

        private void App_SupportDownloadedCompleted(object sender, EventArgs e)
        {
            PropertyChangedEventHandler temp = PropertyChanged;
            if (temp != null) {
                temp(this, new PropertyChangedEventArgs("Popups"));
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
