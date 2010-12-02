using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.Commands
{
    /// <summary>
    /// อัพเดทข้อมูลสีที่ชนะในโต๊ะเกมที่ผู้เล่นลงพนันไว้
    /// </summary>
    public class UpdateRoundWinnerCommand 
        : PayForColorsWinnerInfoCommand
    {
        //input
        /// <summary>
        /// ข้อมูลผู้เล่นที่จะบันทึกสีที่ชนะ
        /// </summary>
        public GamePlayInformation GamePlayInformation { get; set; }
    }
}
