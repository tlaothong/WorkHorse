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
    /// Provides a navigation code for using when looking up the content.
    /// </summary>
    public interface IContentNavigationMetadata
    {
        /// <summary>
        /// The navigation code used by the application to lookup the content.
        /// </summary>
        string NavigationCode { get; }
    }
}
