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
    /// Export the <see cref="System.Windows.Controls.UserControl"/> with Game metadata.
    /// Use this attribute with Game Statistics Content.
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportGameStatContentAttribute : ExportAttribute, TheS.Casinova.Common.IGameStatContentMetadata
    {
        /// <summary>
        /// Initializes a new instance of ExportContentNavigationAttribute.
        /// </summary>
        public ExportGameStatContentAttribute()
            : base(typeof(UserControl))
        { }

        /// <summary>
        /// The name of the game to be displayed on menu.
        /// </summary>
        public string GameName { get; set; }
    }
}
