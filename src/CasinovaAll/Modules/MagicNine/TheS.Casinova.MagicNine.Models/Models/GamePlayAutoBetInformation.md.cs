using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TheS.Casinova.MagicNine.Models
{
    [MetadataType(typeof(MD))]
    partial class GamePlayAutoBetInformation
    {
        public class MD
        {
            [Required]
            public string UserName { get; set; }

            public int RoundID { get; set; }

            public double Amount { get; set; }

            public int Interval { get; set; }

            public double BonusChips { get; set; }

            public double Chips { get; set; }

            public double MoneyRefund { get; set; }

            public Guid AutoBetTrackingID { get; set; }

            public Guid BetTrackingID { get; set; }

            public DateTime FromDateTime { get; set; }

            public DateTime ?ThruDateTime { get; set; }

            public int LotNo { get; set; }
        }
    }
}
