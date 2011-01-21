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
        /// 1. UpLineLevelX ชื่อผู้เล่นเอง
        /// </summary>
        public MLNInformation DownLineInfo { get; set; }

        //Output
        /// <summary>
        /// ข้อมูล downline level 1
        /// 1. UserName ชื่อ downline 
        /// 2. GroupCount จำนวน downline ที่มีผลต่อเรา
        /// </summary>
        public IEnumerable<MLNInformation> MLNInfoLevel1 { get; set; }

        /// <summary>
        /// ข้อมูล downline level 2
        /// 1. UserName  ชื่อ downline 
        /// 2. GroupCount จำนวน downline ที่มีผลต่อเรา
        /// </summary>
        public IEnumerable<MLNInformation> MLNInfoLevel2 { get; set; }

        /// <summary>
        /// ข้อมูล downline level 3
        /// 1. UserName   ชื่อ downline 
        /// 2. GroupCount  จำนวน downline ที่มีผลต่อเรา
        /// </summary>
        public IEnumerable<MLNInformation> MLNInfoLevel3 { get; set; }


    }
}
