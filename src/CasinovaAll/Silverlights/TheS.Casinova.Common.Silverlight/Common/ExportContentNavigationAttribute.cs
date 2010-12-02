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
    /// Export the <see cref="System.Windows.Controls.UserControl"/> with NavigationCode metadata.
    /// For using with the dynamic navigation.
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportContentNavigationAttribute : ExportAttribute, IContentNavigationMetadata
    {
        /// <summary>
        /// Initializes a new instance of ExportContentNavigationAttribute.
        /// Sets its navigation code for lookup later.
        /// </summary>
        /// <param name="navigationCode">The code to use with dynamic navigation for lookin up the content.</param>
        public ExportContentNavigationAttribute(string navigationCode)
            : base(typeof(System.Windows.Controls.UserControl))
        {
            NavigationCode = navigationCode;
        }

        /// <summary>
        /// The navigation code used by the application to lookup the content.
        /// </summary>
        public string NavigationCode { get; set; }
    }
}
