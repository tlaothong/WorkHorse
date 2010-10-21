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
using System.Collections.ObjectModel;
using TheS.Casinova.Common;
using System.ComponentModel.Composition;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;

namespace CasinovaAllStars.ViewModels
{
    public class Page1ViewModel : INotifyPropertyChanged
    {
        public Page1ViewModel()
        {
            if (App.SupportContentDownloaded == false)
            {
                App.SupportContentDownloadCompleted += new EventHandler(App_SupportDownloadedCompleted);
            }
        }

        void App_SupportDownloadedCompleted(object sender, EventArgs e)
        {
            PropertyChangedEventHandler temp = PropertyChanged;
            if (temp != null)
            {
                temp(this, new PropertyChangedEventArgs("Popups"));
            }
        }

        public ObservableCollection<Lazy<ChildWindow, IPopupContentMetadata>> Popups
        {
            get
            {
                return App.ModuleLoader.PopupContents;
            }
        }

        public Lazy<ChildWindow, IPopupContentMetadata> SelectedWindow
        {
            get;
            set;
        }

        public void ShowWindow()
        {
            SelectedWindow.Value.Show();
        }

        public ObservableCollection<IGameApplicationInformation> Games { get { return App.ModuleLoader.Games; } }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
