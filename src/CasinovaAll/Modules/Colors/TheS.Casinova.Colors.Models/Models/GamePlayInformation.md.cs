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
            public string UserName { get; set; }

            public int Round { get; set; }

            public Guid TrackingID { get; set; }

            public Guid OnGoingTrackingID { get; set; }

            public double TotalBetBlack { get; set; }

            public double TotalBetWhite { get; set; }

            public string Winner { get; set; }

            public DateTime WinnerLastUpdate { get; set; }
        }
    }
}
