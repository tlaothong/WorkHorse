using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.Commands
{
    /// <summary>
    /// อัพเดทข้อมูล TrackingID 
    /// </summary>
    public class UpdateOnGoingTrackingIDCommand 
        : PayForColorsWinnerInfoCommand
    {
        //input
        /// <summary>
        /// ข้อมูลผู้เล่นที่จะบันทึก trackingID
        /// </summary>
        public GamePlayInformation GamePlayInformation { get; set; }
    }
}
