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
using TheS.Casinova.Common;

namespace TheS.Casinova.MagicNine
{
    [Export(typeof(IGameApplicationInformation))]
    public class GameApplicationInformation : IGameApplicationInformation
    {
        public const string GameInfoNavigationCode = "magicNine_gameInfo";

        private Uri _gameUri = NavigableContentHelper.GetNavigationUri(GameInfoNavigationCode);
        private UserControl _infoContent;

        #region IGameApplicationInformation Members

        public int GameApplicationID
        {
            get { return 3; }
        }

        public string Name
        {
            get { return "Demo Magic9!"; }
        }

        public UserControl InformationContent
        {
            get
            {
                if (_infoContent == null) {
                    _infoContent = new TheS.Casinova.MagicNine.Controls.GameInformationsUI();
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
