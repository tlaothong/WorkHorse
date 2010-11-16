using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TheS.Casinova.Colors.Models
{
    [MetadataType(typeof(MD))]
    partial class PlayerActionInformation
    {
        public class MD
        {
            public int RoundID { get; set; }

            [Required]
            [StringLength(50, MinimumLength = 5)]
            public string UserName { get; set; }

            [Required]
            [StringLength(50)]
            public string ActionType { get; set; }
      
            public double Amount { get; set; }

            public Guid TrackingID { get; set; }
        }
    }
}
