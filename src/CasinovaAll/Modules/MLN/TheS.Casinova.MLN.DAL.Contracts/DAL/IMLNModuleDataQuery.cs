using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MLN.Models;
using TheS.Casinova.MLN.Commands;
using PerfEx.Infrastructure.Data;

namespace TheS.Casinova.MLN.DAL
{
    public interface IMLNModuleDataQuery :
        IListMLNInfo,
        IListDownLineByLevel
    {}

    /// <summary>
    /// ดึงข้อมูลจำนวนโบนัสและจำนวน dowline ที่มี
    /// </summary>
    public interface IListMLNInfo
         : IFetchSingleData<MLNInformation, ListMLNInfoCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลสมาชิกที่เป็น downline ในแต่ละ level
    /// </summary>
    public interface IListDownLineByLevel
        : IFetchData<MLNInformation, ListDownLineByLevelCommand>
    { }

}
