using System;

namespace TheS.Casinova.Common
{
    /// <summary>
    /// The metadata for discovering game statistics content in MEF.
    /// </summary>
    public interface IGameStatContentMetadata
    {
        /// <summary>
        /// Name of the game to be displayed on menu.
        /// </summary>
        string GameName { get; }
    }
}
