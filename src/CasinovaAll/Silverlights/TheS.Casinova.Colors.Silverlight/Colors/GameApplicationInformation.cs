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
using TheS.Casinova.Common;
using System.ComponentModel.Composition;

namespace TheS.Casinova.TwoWins
{
    [Export(typeof(IGameApplicationInformation))]
    public class GameApplicationInformation : IGameApplicationInformation
    {
        public const string GameInfoNavigationCode = "colors_gameInfo";

        private Uri _gameUri = NavigableContentHelper.GetNavigationUri(GameInfoNavigationCode);
        private UserControl _infoContent;

        #region IGameApplicationInformation Members

        public int GameApplicationID
        {
            get { return 1; }
        }

        public string Name
        {
            get { return "Demo Colors!"; }
        }

        public UserControl InformationContent
        {
            get
            {
                if (_infoContent == null)
                {
                    _infoContent = new TheS.Casinova.TwoWins.Controls.GameInformationsUI();
                }
                return _infoContent;
            }
        }

        public Uri GameUri
        {
            get { return _gameUri; }
        }

        #endregion
    }
}
