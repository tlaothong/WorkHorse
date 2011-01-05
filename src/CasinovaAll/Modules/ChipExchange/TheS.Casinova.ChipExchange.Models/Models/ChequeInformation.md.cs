using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TheS.Casinova.ChipExchange.Models
{
    [MetadataType(typeof(MD))]
    partial class ChequeInformation
    {
        public class MD
        {
            [Required]
            public string UserName { get; set; }

            public string Address { get; set; }

            [Range(1,int.MaxValue)]
            public int Amount { get; set; }
        }
    }
}
