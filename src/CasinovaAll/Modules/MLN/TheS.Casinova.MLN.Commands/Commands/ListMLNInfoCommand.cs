using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MLN.Models;

namespace TheS.Casinova.MLN.Commands
{
    public class ListMLNInfoCommand
    {
        //Input
        /// <summary>
        /// ข้อมูลเพื่อดูสถิติจำนวนโบนัสและจำนวน downline
        /// 1. UserName ชื่อผู้เล่น
        /// </summary>
        public MLNInformation MLNInfo { get; set; }

        //Output
        /// <summary>
        /// ข้อมูลจำนวนโบนัสและจำนวน downline
        /// </summary>
        public MLNInformation MLNInformation { get; set; }
    }
}
