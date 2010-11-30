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

namespace TheS.Casinova.Colors.ViewModels
{
    /// <summary>
    /// ViewModel ของหน้า Game play
    /// </summary>
    public class GamePlayUIViewModel
    {
        #region Properties

        /// <summary>
        /// รอบของเกม
        /// </summary>
        public int RoundID { get; set; }

        /// <summary>
        /// จำนวนเงินทั้งหมดที่ลงในสีดำ
        /// </summary>
        public double TotalAmountOfBlack { get; set; }

        /// <summary>
        /// จำนวนเงินทั้งหมดที่ลงในสีขาว
        /// </summary>
        public double TotalAmountOfWhite { get; set; }

        /// <summary>
        /// จำนวนเงินที่ลงไว้ทั้งหมดในรอบเกมนี้
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// จำนวนเงินที่ต้องใช้ในการดูสีที่ชนะในเวลาขณะนั้น
        /// </summary>
        public double CostWinnerInformation { get; set; }

        /// <summary>
        /// เวลาที่เกมเริ่ม
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// เวลาที่เกมจบ
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// เวลาที่เหลือ
        /// </summary>
        public TimeSpan RemainingGameTime { get; set; }

        /// <summary>
        /// มีการลงเงินในรอบเกมนี้หรือไม่
        /// true: เคยมีการลงเงิน, false: ไม่เคยมีการลงเงิน
        /// </summary>
        public bool IsPlaying { get; set; }

        /// <summary>
        /// เคยมีการขอดูสีที่ชนะแล้วหรือไม่
        /// true: เคย, false: ไม่เคย
        /// </summary>
        public bool IsSecondGetWinnerInformation { get; set; }

        /// <summary>
        /// สีที่ชนะในในเวลาขณะนั้น
        /// </summary>
        public string Winner { get; set; }

        /// <summary>
        /// ข้อความที่แสดงผลของการขอดูสีที่ชนะ
        /// </summary>
        public string GetWinnerInformation { get; set; }

        /// <summary>
        /// หัวเรื่องของเกม
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// TrackingID ที่ทำงานเสร็จตัวสุดท้าย
        /// </summary>
        public Guid TrackingID { get; set; }

        /// <summary>
        /// TrackingID ที่กำลังทำงานล่าสุด
        /// </summary>
        public Guid OnGoingTrackingID { get; set; }

        #endregion Properties
    }
}
