using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MLN.Commands;
using TheS.Casinova.MLN.Models;

namespace TheS.Casinova.MLN.Command
{
    public class ListDownLineByLevel3Command : ListDownLineByLevelCommand
    {
        //output
        /// <summary>
        /// ข้อมูล downline level 3
        /// 1. UserName   ชื่อ downline 
        /// 2. GroupCount  จำนวน downline ที่มีผลต่อเรา
        /// </summary>
        public IEnumerable<MLNInformation> MLNInfoLevel3 { get; set; }

    }
}
