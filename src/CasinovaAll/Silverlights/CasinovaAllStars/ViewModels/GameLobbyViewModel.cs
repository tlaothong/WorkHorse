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
    public class GameLobbyViewModel : INotifyPropertyChanged
    {
        public GameLobbyViewModel()
        {
            if (App.SupportContentDownloaded == false)
            {
                App.SupportContentDownloadCompleted += new EventHandler(App_SupportDownloadedCompleted);
            }
        }

        public ReadOnlyObservableCollection<Lazy<ChildWindow, IPopupContentMetadata>> Popups
        {
            get { return App.ModuleLoader.PopupContents; }
        }

        public ReadOnlyObservableCollection<IGameApplicationInformation> Games
        {
            get { return App.ModuleLoader.Games; }
        }

        // TODO: Copy and use wherever you want to use game statistics list.
        public ReadOnlyObservableCollection<Lazy<UserControl, IGameStatContentMetadata>> StatContents
        {
            get { return App.ModuleLoader.GameStatContents; }
        }

        public Lazy<ChildWindow, IPopupContentMetadata> SelectedWindow { get; set; }

        public void ShowWindow()
        {
            SelectedWindow.Value.Show();
        }

        private void App_SupportDownloadedCompleted(object sender, EventArgs e)
        {
            PropertyChangedEventHandler temp = PropertyChanged;
            if (temp != null) {
                temp(this, new PropertyChangedEventArgs("Popups"));
                temp(this, new PropertyChangedEventArgs("Games"));
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
