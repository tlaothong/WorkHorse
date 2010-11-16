using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TheS.Casinova.Colors.Models
{
    [MetadataType(typeof(MD))]
    partial class GamePlayInformation
    {
        public class MD
        {
            [Required]
            [StringLength(50, MinimumLength = 5)]
            public string UserName { get; set; }

            [Required]
            [Range(0, int.MaxValue)]
            public int RoundID { get; set; }

            public Guid TrackingID { get; set; }

            public Guid OnGoingTrackingID { get; set; }

            public double TotalBetAmountOfBlack { get; set; }

            public double TotalBetAmountOfWhite { get; set; }

            public string Winner { get; set; }

            [Required]
            public DateTime LastUpdate { get; set; }
        }
    }
}
