using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MLN.Models;

namespace TheS.Casinova.MLN.Commands
{
    /// <summary>
    /// command สร้างข้อมูลระบบเครือข่าย
    /// </summary>
    public class CreateMLNInfoCommand
    {
        //input
        /// <summary>
        /// ข้อมูลเพื่อสร้างระบบเครือข่าย
        /// 1. UserName ชื่อผู้เล่น
        /// 2. UplineLevel1 ชื่อ upline ระดับชั้นที่ 1
        /// </summary>
        public MLNInformation MLNInfo { get; set; }
    }
}
