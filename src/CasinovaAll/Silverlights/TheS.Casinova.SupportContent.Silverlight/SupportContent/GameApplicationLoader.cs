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
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Collections.ObjectModel;
using System.Linq;

namespace TheS.Casinova.SupportContent
{
    public class GameApplicationLoader
    {
        public static readonly GameApplicationLoader Instance = new GameApplicationLoader();

        public readonly CompositionContainer CompositionContainer;

        private readonly ComposablePartCatalog[] _catalogs;

        private ReadOnlyObservableCollection<IGameApplicationInformation> _games;
        private ReadOnlyObservableCollection<Lazy<ChildWindow, IPopupContentMetadata>> _popups;
        private ReadOnlyObservableCollection<Lazy<UserControl, IGameStatContentMetadata>> _statContents;

        private ObservableCollection<IGameApplicationInformation> __importedGames;
        [ImportMany(typeof(IGameApplicationInformation), AllowRecomposition = true)]
        public ObservableCollection<IGameApplicationInformation> _ImportedGames
        {
            get { return __importedGames; }
            set
            {
                __importedGames = value;
                _games = new ReadOnlyObservableCollection<IGameApplicationInformation>(value);
            }
        }

        private ObservableCollection<Lazy<ChildWindow, IPopupContentMetadata>> __importedPopups;
        [ImportMany(typeof(ChildWindow), AllowRecomposition = true)]
        public ObservableCollection<Lazy<ChildWindow, IPopupContentMetadata>> _ImportedPopups
        {
            get { return __importedPopups; }
            set
            {
                __importedPopups = value;
                _popups = new ReadOnlyObservableCollection<Lazy<ChildWindow, IPopupContentMetadata>>(value);
            }
        }

        private ObservableCollection<Lazy<UserControl, IGameStatContentMetadata>> __importedStatContents;
        [ImportMany(typeof(UserControl), AllowRecomposition = true)]
        public ObservableCollection<Lazy<UserControl, IGameStatContentMetadata>> _ImportedStatContents
        {
            get { return __importedStatContents; }
            set
            {
                __importedStatContents = value;
                _statContents = new ReadOnlyObservableCollection<Lazy<UserControl, IGameStatContentMetadata>>(value);
            }
        }

        [ImportMany(typeof(UserControl), AllowRecomposition = true)]
        public ObservableCollection<Lazy<UserControl, IContentNavigationMetadata>> _ImportedNavigableContents;

        public ReadOnlyObservableCollection<IGameApplicationInformation> Games
        {
            get { return _games; }
        }

        public ReadOnlyObservableCollection<Lazy<ChildWindow, IPopupContentMetadata>> PopupContents
        {
            get { return _popups; }
        }

        public ReadOnlyObservableCollection<Lazy<UserControl, IGameStatContentMetadata>> GameStatContents
        {
            get { return _statContents; }
        }

        private GameApplicationLoader()
        {
            var cats = new ComposablePartCatalog[] {
                new DeploymentCatalog("TheS.Casinova.Chat.Silverlight.xap"),
                new DeploymentCatalog("TheS.Casinova.Colors.Silverlight.xap"),
                new DeploymentCatalog("TheS.Casinova.DevilSix.Silverlight.xap"),
                new DeploymentCatalog("TheS.Casinova.Fortune.Silverlight.xap"),
                new DeploymentCatalog("TheS.Casinova.MagicNine.Silverlight.xap"),
                new DeploymentCatalog("TheS.Casinova.PlayerAccount.Silverlight.xap"),
                new DeploymentCatalog("TheS.Casinova.TwoWins.Silverlight.xap"),
                new DeploymentCatalog("TheS.Casinova.SupportContent.Silverlight.xap"),
            };
            var acat = new AggregateCatalog(cats);
            _catalogs = cats;
            var Container = new CompositionContainer(acat);
            foreach (var cat in cats)
            {
                if (cat is DeploymentCatalog)
                {
                    DeploymentCatalog dcat = (DeploymentCatalog)cat;
                    dcat.DownloadCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(catalog_DownloadCompleted);
                    dcat.DownloadAsync();
                }
            }
            CompositionContainer = Container;
            Container.ComposeParts(this);
        }

        public UserControl GetNavigableContent(string naviationCode)
        {
            if (_ImportedNavigableContents == null)
            {
                return null;
            }
            var qry = (from it in _ImportedNavigableContents
                       where it.Metadata != null && it.Metadata.NavigationCode == naviationCode
                       select it);
            if (qry.Any())
            {
                return qry.First().Value;
            }
            return null;
        }

        private void catalog_DownloadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            // TODO: throw new NotImplementedException();
        }
    }
}
