using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TheS.Casinova.Colors.Models
{
    /// <summary>
    /// ข้อมูลเงินของผู้เล่น
    /// </summary>
    public partial class PlayerInformation
    {
        /// <summary>
        /// ชื่อผู้เล่นเจ้าของเงิน
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// เงินที่ผ้เล่นใช้ในเกม
        /// </summary>
        public double Balance { get; set; }
    }

    [MetadataType(typeof(MD))]
    partial class PlayerInformation
    {
        public class MD
        {
            [Required]
            public string UserName { get; set; }

            public double Balance { get; set; }
        }
    }
}
