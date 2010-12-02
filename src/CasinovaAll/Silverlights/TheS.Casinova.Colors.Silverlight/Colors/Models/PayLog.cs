using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace TheS.Casinova.Colors.Models
{
    /// <summary>
    /// ข้อมูลการลงเงินพนันที่ยังไม่สำเร็จ
    /// </summary>
    public class PayLog
    {
        #region Properties

        /// <summary>
        /// รหัสโต๊ะ
        /// </summary>
        public int TableID { get; set; }

        /// <summary>
        /// รอบของเกม
        /// </summary>
        public int RoundID { get; set; }

        /// <summary>
        /// จำนวนเงิน
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Tracking id
        /// </summary>
        public Guid TrackingID { get; set; }

        /// <summary>
        /// สีที่ลงพนัน
        /// </summary>
        public string Colors { get; set; }

        #endregion Properties
    }
}
