using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    /// <summary>
    /// ดึงข้อมูลการตั้งค่า
    /// </summary>
    public class GetSettingInfoCommand
    {
        //input
        /// <summary>
        /// ชื่อของการตั้งค่า
        /// </summary>
        public string SettingName { get; set; }

        //output
        /// <summary>
        /// ข้อมูลการตั้งค่าที่ได้รับ
        /// </summary>
        public SettingInformation SettingInfo { get; set; }
    }
}
