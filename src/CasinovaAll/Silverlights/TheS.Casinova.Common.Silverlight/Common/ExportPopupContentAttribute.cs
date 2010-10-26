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
    /// Export the <see cref=" System.Windows.Controls.ChildWindow"/> content in MEF.
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportPopupContentAttribute : ExportAttribute, IPopupContentMetadata
    {
        /// <summary>
        /// Initializes a new instance of the attribute.
        /// </summary>
        public ExportPopupContentAttribute()
            : base(typeof(ChildWindow))
        { }

        /// <summary>
        /// Text representation of the content to display in the menu.
        /// </summary>
        public string DisplayText { get; set; }
        /// <summary>
        /// The group name distinguish the intention of the content.
        /// So the application can arragne this content to the proper area on the UI.
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// The ordering number use to sort the content in the menu in ascending order.
        /// </summary>
        public int Order { get; set; }
    }
}
