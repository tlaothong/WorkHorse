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
using TheS.Casinova.Common;
using System.Collections.ObjectModel;

namespace CasinovaAllStars.ViewModels
{
    public class StatisticsModel : INotifyPropertyChanged
    {
        public ReadOnlyObservableCollection<Lazy<UserControl, IGameStatContentMetadata>> StatContents
        {
            get { return App.ModuleLoader.GameStatContents; }
        }

        public StatisticsModel()
        {
            if (App.SupportContentDownloaded == false) {
                App.SupportContentDownloadCompleted += new EventHandler(App_SupportContentDownloadCompleted);
            }
        }

        private void App_SupportContentDownloadCompleted(object sender, EventArgs e)
        {
            PropertyChangedEventHandler temp = PropertyChanged;
            if (temp != null) {
                temp(this, new PropertyChangedEventArgs("StatContents"));
            }
        }

        #region INotifyPropertyChanged member

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged member
    }
}
