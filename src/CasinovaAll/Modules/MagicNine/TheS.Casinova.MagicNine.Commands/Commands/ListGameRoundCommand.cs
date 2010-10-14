﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.Models;

namespace TheS.Casinova.MagicNine.Commands
{
    /// <summary>
    /// ดึงข้อมูลโต๊ะเกม
    /// </summary>
    public class ListGameRoundCommand
    {
        //output

        /// <summary>
        /// ข้อมูลโต๊ะเกมทั้งหมด
        /// </summary>
        public IEnumerable<GameRoundInformation> GameRoundInfos { get; set; }
    }
}
