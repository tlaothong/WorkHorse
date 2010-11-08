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
using TheS.Casinova.Common;
using System.ComponentModel.Composition;

namespace TheS.Casinova.SupportContent
{
    [Export(typeof(IModuleLoader))]
    public class ModuleLoaderAdapter : IModuleLoader
    {
        private GameApplicationLoader _loader;
        public ModuleLoaderAdapter()
        {
            _loader = GameApplicationLoader.Instance;
        }

        #region IModuleLoader Members

        public System.Collections.ObjectModel.ReadOnlyObservableCollection<IGameApplicationInformation> Games
        {
            get { return _loader.Games; }
        }

        public System.Collections.ObjectModel.ReadOnlyObservableCollection<Lazy<ChildWindow, IPopupContentMetadata>> PopupContents
        {
            get { return _loader.PopupContents; }
        }

        public System.Collections.ObjectModel.ReadOnlyObservableCollection<Lazy<UserControl, IStatisticsContentMetadata>> StatisticsContents
        {
            get { return _loader.StatisticsContents; }
        }

        public System.Collections.ObjectModel.ReadOnlyObservableCollection<Lazy<UserControl, IGameStatContentMetadata>> GameStatContents
        {
            get { return _loader.GameStatContents; }
        }

        public UserControl GetNavigableContent(string naviationCode)
        {
            return _loader.GetNavigableContent(naviationCode);
        }

        #endregion
    }
}
