﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TheS.Casinova.MagicNine.Models
{
    [MetadataType(typeof(MD))]
    partial class BetInformation
    {
        public class MD
        {
            [Required]
            public string UserName { get; set; }

            [Range(0, int.MaxValue)]
            public int RoundID { get; set; }

            public DateTime BetDateTime { get; set; }
            
            public int BetOrder { get; set; }

            public Guid BetTrackingID { get; set; }
        }
    }
}
