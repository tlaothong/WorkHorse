using System;
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
            [Range(0, int.MaxValue)]
            public int Round { get; set; }

            [Required]
            public string UserName { get; set; }

            public DateTime BetDateTime { get; set; }
            
            public int BetOrder { get; set; }

            public Guid BetTrackingID { get; set; }
        }
    }
}
