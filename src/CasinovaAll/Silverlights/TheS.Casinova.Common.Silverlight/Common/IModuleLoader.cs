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
    /// <summary>
    /// The loader of MEF contents for the application.
    /// </summary>
    public interface IModuleLoader
    {
        /// <summary>
        /// List of games and their information and links.
        /// </summary>
        ReadOnlyObservableCollection<IGameApplicationInformation> Games { get; }
        /// <summary>
        /// List of <see cref="System.Windows.Controls.ChildWindow"/> for popup contents.
        /// </summary>
        ReadOnlyObservableCollection<Lazy<ChildWindow, IPopupContentMetadata>> PopupContents { get; }
        /// <summary>
        /// List of <see cref="System.Windows.Controls.UserControl"/> for statistics contents.
        /// </summary>
        ReadOnlyObservableCollection<Lazy<UserControl, IStatisticsContentMetadata>> StatisticsContents { get; }
        /// <summary>
        /// List of game statistics user controls.
        /// </summary>
        ReadOnlyObservableCollection<Lazy<UserControl, IGameStatContentMetadata>> GameStatContents { get; }

        /// <summary>
        /// Get the <see cref="System.Windows.Controls.UserControl"/> from the specified navigation code.
        /// </summary>
        /// <param name="naviationCode">The navigation code.</param>
        /// <returns>The <see cref="System.Windows.Controls.UserControl"/> of the associated navigation code or null.</returns>
        UserControl GetNavigableContent(string naviationCode);
    }
}
