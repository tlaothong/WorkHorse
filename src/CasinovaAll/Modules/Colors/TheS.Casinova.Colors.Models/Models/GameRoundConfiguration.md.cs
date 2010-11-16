using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TheS.Casinova.Colors.Models
{
    [MetadataType(typeof(MD))]
    partial class GameRoundConfiguration
    {
        public class MD
        {
            [Required]
            [StringLength(50, MinimumLength=5)]
            public string Name { get; set; }
            [Range(0, 99)]
            public int TableAmount { get; set; }
            public int GameDuration { get; set; }
            public int Interval { get; set; }
        }
    }
}
