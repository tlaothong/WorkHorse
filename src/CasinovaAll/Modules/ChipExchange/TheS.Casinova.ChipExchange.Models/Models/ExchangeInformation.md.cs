using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TheS.Casinova.ChipExchange.Models
{
    [MetadataType(typeof(MD))]
    partial class ExchangeInformation
    {
        public class MD
        {
            public double Amount { get; set; }

            [Required]
            public string UserName { get; set; }

            public string CardType { get; set; }

            public string AccountType { get; set; }

            public string AccountNo { get; set; }

            public string CVV { get; set; }

            public DateTime ExpireDate { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }
        }
    }
}
