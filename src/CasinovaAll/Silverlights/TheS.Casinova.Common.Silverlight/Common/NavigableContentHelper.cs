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
    public static class NavigableContentHelper
    {
        public const string NavigationUriFormatString = "/mef/nav/{0}";
        private static readonly string _navigationUriPrefix = string.Format(NavigationUriFormatString, string.Empty);

        public static Uri GetNavigationUri(string navigationCode)
        {
            return new Uri(string.Format(NavigationUriFormatString, navigationCode), UriKind.Relative);
        }

        public static string ParseNavigationCode(Uri url)
        {
            return url.OriginalString.Replace(_navigationUriPrefix, string.Empty);
        }
    }
}
