﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.Data;
using TheS.Casinova.Colors.Commands;

namespace TheS.Casinova.Colors.DAL
{
    public interface IColorsGameDataBackQuery : 
        IGetRoundWinnerQuery
    { }

    //ดึงข้อมูล Winner ที่ผู้เล่นเสียเงินโต๊ะที่ดู
    public interface IGetRoundWinnerQuery
        : IFetchSingleData<string, PayForColorsWinnerInfoCommand>
    { }
}
