using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TheS.Casinova.TwoWins.Models
{
    [MetadataType(typeof(MD))]
    partial class RoundWinnerInformation
    {
         public class MD
         {
             public int RoundID { get; set; }

             public double WinnerHightNormalAmount { get; set; }

             public double WinnerLowNormalAmount { get; set; }

             public double WinnerHightCriticalAmount { get; set; }

             public double WinnerLowCriticalAmount { get; set; }
         }
    }
}
