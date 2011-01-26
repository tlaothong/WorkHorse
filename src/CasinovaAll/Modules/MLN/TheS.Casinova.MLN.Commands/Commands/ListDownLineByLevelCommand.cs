using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MLN.Models;

namespace TheS.Casinova.MLN.Commands
{
    public class ListDownLineByLevelCommand
    {
        //Input
        /// <summary>
        /// ข้อมูลเพื่อดึงข้อมูล downline ใน level ต่าง
        /// 1. UserName ชื่อผู้เล่นเอง
        /// </summary>
        public MLNInformation DownLineInfo { get; set; }
    }
}
