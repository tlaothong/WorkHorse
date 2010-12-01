using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TheS.Casinova.PlayerProfile.Models
{
    [MetadataType(typeof(MD))]
    partial class UserProfile
    {
        public class MD
        {
            [Required]
            public string UserName { get; set; }

            [Required]
            [StringLength(16, MinimumLength = 5)]
            public string Password { get; set; }

            [Required]
            [StringLength(16, MinimumLength = 5)]
            public string NewPassword { get; set; }

            [Required]
            [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")]
            public string Email { get; set; }

            [Required]
            [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")]
            public string NewEmail { get; set; }

            [Required]
            public string CellPhone { get; set; }

            public string Upline { get; set; }

            public double Refundable { get; set; }

            public double NonRefundable { get; set; }

            public bool Active { get; set; }

            public string VerifyCode { get; set; }

            public Guid TrackingID { get; set; }
        }
    }
}
