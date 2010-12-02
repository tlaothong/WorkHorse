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

namespace TheS.Casinova.Common
{
    /// <summary>
    /// Information of the Game Application.
    /// This information links games together.
    /// </summary>
    
    public interface IGameApplicationInformation
    {
        /// <summary>
        /// Game application ID
        /// </summary>
        int GameApplicationID { get; }
        /// <summary>
        /// Name of the game to be displayed on menu.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// The game information user control.
        /// </summary>
        UserControl InformationContent { get; }
        /// <summary>
        /// The URI links to the game play page.
        /// </summary>
        Uri GameUri { get; }
    }
}
