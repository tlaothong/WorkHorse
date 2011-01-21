using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TheS.Casinova.MLN.Models
{
    [MetadataType(typeof(MD))]
    partial class BonusLogInformation
    {
        public class MD
        {
            public string UserName { get; set; }

            public double BonusAmount { get; set; }

            public string RecieverName { get; set; }

            public DateTime DateTime { get; set; }

            public int RecieverLevel { get; set; }
        }
    }
}
