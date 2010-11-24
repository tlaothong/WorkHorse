using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TheS.Casinova.Colors.Models
{
    [MetadataType(typeof(MD))]
    partial class GameRoundInformation
    {
        public class MD
        {
            [Range(0,int.MaxValue)]
            public int Round { get; set; }

            public DateTime StartTime { get; set; }

            public DateTime EndTime { get; set; }

            public double BlackPot { get; set; }

            public double WhitePot { get; set; }

            public int HandCount { get; set; }
        }
    }
}
