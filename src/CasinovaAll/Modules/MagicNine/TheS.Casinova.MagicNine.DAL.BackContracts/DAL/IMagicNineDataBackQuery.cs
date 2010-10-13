using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.Models;
using TheS.Casinova.MagicNine.Commands;
using PerfEx.Infrastructure.Data;

namespace TheS.Casinova.MagicNine.DAL
{
    public interface IMagicNineDataBackQuery :
        IListBetLog
    { }

    /// <summary>
    /// ดึงข้อมูลการลงพนันทั้งหมดในโต๊ะเกมที่ผู้เล่นลงพนันไว้    
    /// </summary>
    public interface IListBetLog
        : IFetchData<BetInformation, ListBetLogCommand>
    { }
}
