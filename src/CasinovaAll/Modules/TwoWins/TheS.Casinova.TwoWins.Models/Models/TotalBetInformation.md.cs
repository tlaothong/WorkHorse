using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TheS.Casinova.TwoWins.Models
{
    [MetadataType(typeof(MD))]
    partial class TotalBetInformation
    {
        public class MD
        {
            public int RoundID { get; set; }
            
            [Required]
            public string UserName { get; set; }

            public double TotalBet { get; set; }
        }
    }
}
