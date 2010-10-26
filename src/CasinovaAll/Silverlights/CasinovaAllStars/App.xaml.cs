using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel.Composition;
using TheS.Casinova.Common;

namespace CasinovaAllStars
{
    public partial class App : Application, IPartImportsSatisfiedNotification
    {
        private static System.ComponentModel.Composition.Hosting.CompositionContainer _compositionContainer;
        private static bool _supportDownloaded = false;
        private static IModuleLoader _ModuleLoader = new NullModuleLoader();

        public static IModuleLoader ModuleLoader
        {
            get { return App._ModuleLoader; }
        }

        public static bool SupportContentDownloaded
        {
            get { return App._supportDownloaded; }
        }

        public static event EventHandler SupportContentDownloadCompleted;

        [Import]
        public IModuleLoader _instanceModuleLoader;

        public App()
        {
            this.Startup += this.Application_Startup;
            this.UnhandledException += this.Application_UnhandledException;

            InitializeComponent();

            var cat = new System.ComponentModel.Composition.Hosting.DeploymentCatalog("TheS.Casinova.SupportContent.Silverlight.xap");
            var acat = new System.ComponentModel.Composition.Hosting.AggregateCatalog(cat, new System.ComponentModel.Composition.Hosting.DeploymentCatalog());
            _compositionContainer = new System.ComponentModel.Composition.Hosting.CompositionContainer(acat);
            cat.DownloadCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(catalog_DownloadCompleted);
            cat.DownloadAsync();
        }

        public void OnImportsSatisfied()
        {
            _ModuleLoader = _instanceModuleLoader;
            _supportDownloaded = true;
            OnSupportContentDownloadCompleted();
        }

        private void catalog_DownloadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("The content downloading has been cancelled.", "Application Initialization Error", MessageBoxButton.OK);
                return;
            }
            if (e.Error != null)
            {
                ChildWindow errorWin = new ErrorWindow(e.Error);
                errorWin.Show();
                return;
            }
            _compositionContainer.ComposeParts(this);
        }

        protected virtual void OnSupportContentDownloadCompleted()
        {
            EventHandler temp = SupportContentDownloadCompleted;
            if (temp != null)
            {
                temp(this, EventArgs.Empty);
            }
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            this.RootVisual = new MainPage();
        }

        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            // If the app is running outside of the debugger then report the exception using
            // a ChildWindow control.
            if (!System.Diagnostics.Debugger.IsAttached)
            {
                // NOTE: This will allow the application to continue running after an exception has been thrown
                // but not handled. 
                // For production applications this error handling should be replaced with something that will 
                // report the error to the website and stop the application.
                e.Handled = true;
                ChildWindow errorWin = new ErrorWindow(e.ExceptionObject);
                errorWin.Show();
            }
        }

        private class NullModuleLoader : IModuleLoader
        {
            private static readonly System.Collections.ObjectModel.ReadOnlyObservableCollection<IGameApplicationInformation> _emptyGames =
                new System.Collections.ObjectModel.ReadOnlyObservableCollection<IGameApplicationInformation>(
                    new System.Collections.ObjectModel.ObservableCollection<IGameApplicationInformation>());
            private static readonly System.Collections.ObjectModel.ReadOnlyObservableCollection<Lazy<ChildWindow, IPopupContentMetadata>> _emptyPopups =
                new System.Collections.ObjectModel.ReadOnlyObservableCollection<Lazy<ChildWindow, IPopupContentMetadata>>(
                    new System.Collections.ObjectModel.ObservableCollection<Lazy<ChildWindow, IPopupContentMetadata>>());
            private static readonly System.Collections.ObjectModel.ReadOnlyObservableCollection<Lazy<UserControl, IGameStatContentMetadata>> _emptyStats =
                new System.Collections.ObjectModel.ReadOnlyObservableCollection<Lazy<UserControl, IGameStatContentMetadata>>(
                    new System.Collections.ObjectModel.ObservableCollection<Lazy<UserControl, IGameStatContentMetadata>>());

            #region IModuleLoader Members

            public System.Collections.ObjectModel.ReadOnlyObservableCollection<IGameApplicationInformation> Games
            {
                get { return _emptyGames; }
            }

            public System.Collections.ObjectModel.ReadOnlyObservableCollection<Lazy<ChildWindow, IPopupContentMetadata>> PopupContents
            {
                get { return _emptyPopups; }
            }

            public System.Collections.ObjectModel.ReadOnlyObservableCollection<Lazy<UserControl, IGameStatContentMetadata>> GameStatContents
            {
                get { return _emptyStats; }
            }

            public UserControl GetNavigableContent(string naviationCode)
            {
                return null;
            }

            #endregion
        }

    }
}