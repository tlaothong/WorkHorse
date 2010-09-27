using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.Commands
{
    /// <summary>
    /// command ดึงข้อมูลสีที่ชนะเมื่อชำระเงิน
    /// </summary>
    public class PayForColorsWinnerInfoCommand       
    {
        public PlayerInformation PlayerInfo { get; set; }

        public GamePlayInformation GamePlayInfo { get; set; }
    }
}
