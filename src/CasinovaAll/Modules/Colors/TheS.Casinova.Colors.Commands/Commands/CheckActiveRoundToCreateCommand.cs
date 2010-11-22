using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.Commands
{
    /// <summary>
    /// command ตรวจสอบจำนวนโต๊ะเกมที่ active
    /// </summary>
   public class CheckActiveRoundToCreateCommand
    {
       //input
       /// <summary>
        /// ชื่อโต๊ะเกมที่ต้องการตรวจสอบจำนวน round ที่ active
        /// 1. TableName ชื่อโต๊ะเกมที่ต้องการตรวจสอบจำนวน round ที่ active
       /// </summary>
        public GameRoundConfiguration GameRoundConfigName { get; set; }
    }
}
