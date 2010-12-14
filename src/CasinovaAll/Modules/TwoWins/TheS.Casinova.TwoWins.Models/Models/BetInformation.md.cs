using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TheS.Casinova.TwoWins.Models
{
    [MetadataType(typeof(MD))]
    partial class BetInformation
    {
        public class MD
        {
          
            public int RoundID { get; set; }

            [Required]
            public string UserName { get; set; }

            public double BonusChips { get; set; }

            public double Chips { get; set; }

            public double Amount { get; set; }

            public int HandID { get; set; }

            public string HandStatus { get; set; }

            public DateTime BetDateTime { get; set; }

            public Guid BetTrackingID { get; set; }

            public bool CanChange { get; set; }
        }
    }
}
