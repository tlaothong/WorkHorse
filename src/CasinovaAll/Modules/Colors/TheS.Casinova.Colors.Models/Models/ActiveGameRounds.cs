﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TheS.Casinova.Colors.Models
{
    /// <summary>
    /// ข้อมูลโต๊ะเกมที่ active
    /// </summary>
   public partial class ActiveGameRounds
    {
        /// <summary>
        /// หมายเลขโต๊ะเกมที่ active
        /// </summary>
        public int TableID { get; set; }

       /// <summary>
       /// หมายเลข round ที่ active
       /// </summary>
        public int RoundID { get; set; }

       /// <summary>
       /// เวลาเริ่มต้นของแต่ละห้องเกมที่ active
       /// </summary>
        public DateTime StartTime { get; set; }

       /// <summary>
       /// เวลาจบเกมของแต่ละห้องเกมที่ active
       /// </summary>
        public DateTime EndTime { get; set; }
    }

    [MetadataType(typeof(MD))]
   partial class ActiveGameRounds
   {
        public class MD
        {
            public int TableID { get; set; }

            public int RoundID { get; set; }

            public DateTime StartTime { get; set; }

            public DateTime EndTime { get; set; }
        }
   }
}
