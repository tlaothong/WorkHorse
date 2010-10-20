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

namespace TheS.Casinova.Common
{
    public interface IModuleLoader
    {
        ObservableCollection<IGameApplicationInformation> Games { get; }
        ObservableCollection<Lazy<ChildWindow, IPopupContentMetadata>> PopupContents { get; }

        UserControl GetNavigableContent(string naviationCode);
    }
}
