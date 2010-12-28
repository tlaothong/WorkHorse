using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheS.Casinova.TwoWins.Models
{
    public class SettingInformation
    {
        /// <summary>
        /// ระยะห่างเพื่อคำนวน range ของการลงเดิมพัน
        /// </summary>
        public int BetInterval { get; set; }

        /// <summary>
        /// ระยะห่างเพื่อคำนวน range ของมือที่ลงเดิมพัน
        /// </summary>
        public int HandCountInterval { get; set; }

        //////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// ชื่อของการตั้งค่า
        /// </summary>
        public string SettingName { get; set; }

        /// <summary>
        /// เปอร์เซ็นของเงินรางวัลทั้งหมดที่ผู้ชนะสูงสุดช่วงปกติจะได้รับ
        /// </summary>
        public double WinnerHightNormalReturnRate { get; set; }

        /// <summary>
        /// เปอร์เซ็นของเงินรางวัลทั้งหมดที่ผู้ชนะต่ำสุดช่วงปกติจะได้รับ
        /// </summary>
        public double WinnerLowNormalReturnRate { get; set; }

        /// <summary>
        /// เปอร์เซ็นของเงินรางวัลทั้งหมดที่ผู้ชนะสูงสุดช่วงวิกฤตจะได้รับ
        /// </summary>
        public double WinnerHightCriticalReturnRate { get; set; }

        /// <summary>
        /// เปอร์เซ็นของเงินรางวัลทั้งหมดที่ผู้ชนะต่ำสุดช่วงวิกฤตจะได้รับ
        /// </summary>
        public double WinnerLowCriticalReturnRate { get; set; }
    }
}
