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
    /// Provides a convenience way to access the meatadata of the StatisticsContent in MEF.
    /// </summary>
    public interface IStatisticsContentMetadata
    {
        /// <summary>
        /// Text representation of the content to display in the menu.
        /// </summary>
        string DisplayText { get; }
    }
}
