using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    public class ListSingleActinLog
    {
        //input
        /// <summary>
        /// ข้อมูลเพื่อลิสต์ประวัติการลงพนันของโตีะเกมแบบทีละโต๊ะ
        /// 1. RoundID รหัสโต๊ะเกม
        /// </summary>
        public ActionLogInformation ActionLogInfo { get; set; }

        //output
        /// <summary>
        /// ข้อมูลประวัติการลงพนัน
        /// </summary>
        public IEnumerable<ActionLogInformation> ActionLogInformation { get; set; }

    }
}
