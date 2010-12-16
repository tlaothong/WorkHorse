using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TheS.Casinova.TwoWins.Models
{
     [MetadataType(typeof(MD))]
	partial class RangeBetInformation
	{
         public class MD
         {
             [Required]
             [Range(0,int.MaxValue)]
             public int RoundID { get; set; }

             [Required]
             public string UserName { get; set; }

             [Required]
             [Range(1, double.MaxValue)]
             public double FromAmount { get; set; }

             [Required]
             [Range(1, double.MaxValue)]
             public double ThruAmount { get; set; }

             public DateTime RangeBetDateTime { get; set; }

             public Guid BetTrackingID { get; set; }
         }
	}
}
