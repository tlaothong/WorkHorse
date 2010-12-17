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
            public string ConfigName { get; set; }

            [Range(1, 99)]
            public int TableAmount { get; set; }

            [Range(1, 1440)]
            public int GameDuration { get; set; }

            [Range(1, 1440)]
            public int Interval { get; set; }

            [Range(1, 99)]
            public int BufferRoundsCount { get; set; }
        }
    }
}
