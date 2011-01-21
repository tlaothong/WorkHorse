using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TheS.Casinova.MLN.Models
{
    [MetadataType(typeof(MD))]
    partial class MLNInformation
    {
        public class MD
        {
            public string UserName { get; set; }

            public double UseableBonus { get; set; }

            public string UplineLevel1 { get; set; }

            public string UplineLevel2 { get; set; }

            public string UplineLevel3 { get; set; }

            public double BonusThisMonth { get; set; }

            public double BonusLastMonth { get; set; }

            public int TotalDownLineLevel1 { get; set; }

            public int TotalDownLineLevel2 { get; set; }

            public int TotalDownLineLevel3 { get; set; }

            public double TotalBonus { get; set; }

            public int GroupCount { get; set; }
        }
    }
}
