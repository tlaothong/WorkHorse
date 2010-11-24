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
    public interface INavigablePage
    {
        /// <summary>
        /// Gets the service that the host used to navigate to this page.
        /// The application use this method to set the navigation service from host page.
        /// </summary>
        System.Windows.Navigation.NavigationService NavigationService { get; set; }

        /// <summary>
        /// Executes when the user navigates to this page.
        /// </summary>
        /// <param name="e">An object that contains the event data.</param>
        void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e);
        /// <summary>
        /// Called just before a page is no longer the active page in a frame.
        /// </summary>
        /// <param name="e">An object that contains the event data.</param>
        void OnNavigatingFrom(System.Windows.Navigation.NavigatingCancelEventArgs e);
        /// <summary>
        /// Called when a page is no longer the active page in a frame.
        /// </summary>
        /// <param name="e">An object that contains the event data.</param>
        void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e);
    }
}
