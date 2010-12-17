using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TheS.Casinova.PlayerProfile.Models
{
    [MetadataType(typeof(MD))]
    partial class ActionLog
    {
        public class MD
        {
            [Required]
            public string UserName { get; set; }

            public string Action { get; set; }

            public DateTime DateTime { get; set; }

            public string GameName { get; set; }

            public double Amount { get; set; }
        }
    }
}
