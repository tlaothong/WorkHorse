using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TheS.Casinova.TwoWins.Models
{
    [MetadataType(typeof(MD))]
    partial class ActionLogInformation
    {
        public class MD
        {
            [Range(0,int.MaxValue)]
            public int RoundID { get; set; }

            public string UserName { get; set; }

            public int HandID { get; set; }

            public double Amount { get; set; }

            public double OldAmount { get; set; }

            public string HandStatus { get; set; }

            public bool Change { get; set; }

            public string WinState { get; set; }

            public double Pot { get; set; }

            public double Reward { get; set; }

            public DateTime DateTime { get; set; }

            [Range(0, int.MaxValue)]
            public int FromRoundID { get; set; }

            [Range(0, int.MaxValue)]
            public int ThruRoundID { get; set; }
        }
    }
}
