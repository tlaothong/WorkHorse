using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Models;

namespace TheS.Casinova.TwoWins.Commands
{
    public class GetGameStatusCommand
    {
        //input
        /// <summary>
        /// ข้อมูลเพื่อดึงข้อมูล Game Status
        /// 1. RoundID รหัสโต๊ะเกม
        /// </summary>
        public RoundWinnerInformation RoundWinnerInfo { get; set; }

        //output
        /// <summary>
        /// ข้อมูลผู้ชนะ
        /// </summary>
        public RoundWinnerInformation RoundWinner{ get; set; }

        /// <summary>
        /// ข้อมูลจำนวนเงินและช่วงของจำนวนการลงเดิมพัน
        /// </summary>
        public RoundInformation RoundInfo { get; set; }
    }
}
