using System;

namespace TheS.Casinova.Common
{
    /// <summary>
    /// Provides a convenience way to access the meatadata of the PopupContent in MEF.
    /// </summary>
    public interface IPopupContentMetadata
    {
        /// <summary>
        /// Text representation of the content to display in the menu.
        /// </summary>
        string DisplayText { get; }
        /// <summary>
        /// The group name distinguish the intention of the content.
        /// So the application can arragne this content to the proper area on the UI.
        /// </summary>
        string GroupName { get; }
        /// <summary>
        /// The ordering number use to sort the content in the menu in ascending order.
        /// </summary>
        int Order { get; }
    }
}
