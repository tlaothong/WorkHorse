using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TheS.Casinova.ChipExchange.Models
{
    [MetadataType(typeof(MD))]
    partial class VoucherInformation
    {
        public class MD
        {
            [Required]
            public string UserName { get; set; }

            public string VoucherCode { get; set; }

            public double Amount { get; set; }

            public bool CanUse { get; set; }
        }
    }
}
