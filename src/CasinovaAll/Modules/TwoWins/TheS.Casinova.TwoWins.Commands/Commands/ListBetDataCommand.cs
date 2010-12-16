﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    /// <summary>
    /// ดึงข้อมูลสถิติการลงเดิมพันในเกม
    /// </summary>
    public class ListBetDataCommand
    {
        //input
        /// <summary>
        /// ข้อมูลรหัสโต๊ะเกมที่ต้องการดูสถิติ
        /// 1. FromRoundID รหัสโต๊ะเกมเริ่มต้น
        /// 2. ThruRoundID รหัสโต๊ะเกมสุดท้าย
        /// </summary>
        public ActionLogInformation ActionLogInfo { get; set; }

        //output
        /// <summary>
        /// ข้อมูลประวัติการลงพนัน
        /// </summary>
        public IEnumerable<ActionLogInformation> ActionLogInformation { get; set; }
    }
}
