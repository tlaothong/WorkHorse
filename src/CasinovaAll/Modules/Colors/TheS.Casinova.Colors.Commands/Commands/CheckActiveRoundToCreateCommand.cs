using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.Colors.Commands
{
    /// <summary>
    /// command ตรวจสอบจำนวนโต๊ะเกมที่ active
    /// </summary>
   public class CheckActiveRoundToCreateCommand
    {
       //input
       public string Name { get; set; } //ชื่อโต๊ะเกมที่ต้องการตรวจสอบจำนวน round ที่ active
    }
}
