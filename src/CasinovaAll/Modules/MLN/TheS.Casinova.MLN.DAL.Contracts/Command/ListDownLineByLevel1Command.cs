using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MLN.Commands;
using TheS.Casinova.MLN.Models;

namespace TheS.Casinova.MLN.Command
{
    public class ListDownLineByLevel1Command : ListDownLineByLevelCommand
    {
        //Output
        /// <summary>
        /// ข้อมูล downline level 1
        /// 1. UserName ชื่อ downline 
        /// 2. GroupCount จำนวน downline ที่มีผลต่อเรา
        /// </summary>
        public IEnumerable<MLNInformation> MLNInfoLevel1 { get; set; }
    }
}
