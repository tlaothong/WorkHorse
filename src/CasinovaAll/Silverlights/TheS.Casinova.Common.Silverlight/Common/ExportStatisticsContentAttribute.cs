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
using System.ComponentModel.Composition;

namespace TheS.Casinova.Common
{
    /// <summary>
    /// Export the <see cref=" System.Windows.Controls.UserControl"/> content in MEF.
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportStatisticsContentAttribute : ExportAttribute, IStatisticsContentMetadata
    {
        /// <summary>
        /// Initializes a new instance of the attribute.
        /// </summary>
        public ExportStatisticsContentAttribute()
            : base(typeof(UserControl))
        { }

        #region IStatisticsContentMetadata Members

        /// <summary>
        /// Text representation of the content to display in the menu.
        /// </summary>
        public string DisplayText { get; set; }
        /// <summary>
        /// The ordering number use to sort the content in the menu in ascending order.
        /// </summary>
        public int Order { get; set; }

        #endregion IStatisticsContentMetadata Members
    }
}