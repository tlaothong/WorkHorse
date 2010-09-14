using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.ColorsGame.Models
{
    /// <summary>
    /// ข้อมูลผู้เล่น เช่น มีเงินเท่าไร
    /// </summary>
    public class PlayerInformation
    {
        /// <summary>
        /// Player's Username
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Amount which Player can expense in the game
        /// </summary>
        public double Balance { get; set; }
    }
}
