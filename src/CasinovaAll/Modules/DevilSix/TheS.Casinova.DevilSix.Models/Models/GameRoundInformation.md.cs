using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TheS.Casinova.DevilSix.Models
{
    [MetadataType(typeof(MD))]
    partial class GameRoundInformation
    {
        public class MD
        {
            public int RoundID { get; set; }

            public int WinnerPoint { get; set; }

            public bool Active { get; set; }
        }
    }
}
