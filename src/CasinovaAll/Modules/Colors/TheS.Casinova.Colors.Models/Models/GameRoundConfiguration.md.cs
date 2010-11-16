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

            [Range(0, 1440)]
            public int GameDuration { get; set; }

            [Range(0, 1440)]
            public int Interval { get; set; }

            [Range(0, 99)]
            public int BufferRoundsCount { get; set; }
        }
    }
}
