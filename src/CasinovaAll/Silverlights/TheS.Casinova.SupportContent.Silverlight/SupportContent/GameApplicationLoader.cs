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

        [ImportMany(typeof(IGameApplicationInformation), AllowRecomposition = true)]
        public ObservableCollection<IGameApplicationInformation> _games;
        [ImportMany(typeof(ChildWindow), AllowRecomposition = true)]
        public ObservableCollection<Lazy<ChildWindow, IPopupContentMetadata>> _popups;
        [ImportMany(typeof(UserControl), AllowRecomposition = true)]
        public ObservableCollection<Lazy<UserControl, IContentNavigationMetadata>> _navigableContents;

        public ObservableCollection<IGameApplicationInformation> Games
        {
            get { return _games; }
        }

        public ObservableCollection<Lazy<ChildWindow, IPopupContentMetadata>> PopupContents
        {
            get { return _popups; }
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
            if (_navigableContents == null)
            {
                return null;
            }
            var qry = (from it in _navigableContents
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
