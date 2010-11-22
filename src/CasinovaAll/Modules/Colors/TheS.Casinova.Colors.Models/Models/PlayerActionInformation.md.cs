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
            [Range(0,int.MaxValue)]
            public int Round { get; set; }

            [Required]
            public string UserName { get; set; }

            [Required]
            public string ActionType { get; set; }

            [Range(0, int.MaxValue)]
            public double Amount { get; set; }

            public Guid TrackingID { get; set; }
        }
    }
}
