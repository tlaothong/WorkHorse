using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Commands;

namespace TheS.Casinova.Colors.BackServices
{
    /// <summary>
    /// ส่งค่า command ไป back server เพื่อดำเนินการหักเงินและหาข้อมูล winner ต่อไป
    /// </summary>
    public interface IColorsGameBackService
    {
        void PayForWinnerInfo(PayForColorsWinnerInfoCommand cmd);
    }
}
