using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TheS.Casinova.TwoWins.Models
{
    [MetadataType(typeof(MD))]
    partial class RoundInformation
    {
        public class MD
        {
            [Range(0,int.MaxValue)]
            public int RoundID { get; set; }

            public DateTime FromDateTime { get; set; }

            public DateTime ThruDateTime { get; set; }

            public DateTime CriticalDateTime { get; set; }

            public string WinnerHightNameNormal { get; set; }

            public string WinnerLowNameNormal { get; set; }

            public string WinnerHightRange { get; set; }

            public string WinnerLowRange { get; set; }

            public string WinnerHightNameCritical { get; set; }

            public string WinnerLowNameCritical { get; set; }

            public double Pot { get; set; }

            public int HandsCount { get; set; }

            public string HandRange { get; set; }
        }
    }
}
