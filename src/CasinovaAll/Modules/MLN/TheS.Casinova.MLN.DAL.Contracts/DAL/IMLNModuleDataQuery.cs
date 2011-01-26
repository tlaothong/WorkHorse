using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MLN.Models;
using TheS.Casinova.MLN.Commands;
using PerfEx.Infrastructure.Data;
using TheS.Casinova.MLN.Command;

namespace TheS.Casinova.MLN.DAL
{
    public interface IMLNModuleDataQuery :
        IListMLNInfo,
        IListDownLineByLevel1,
        IListDownLineByLevel2,
        IListDownLineByLevel3
    {}

    /// <summary>
    /// ดึงข้อมูลจำนวนโบนัสและจำนวน dowline ที่มี
    /// </summary>
    public interface IListMLNInfo
         : IFetchSingleData<MLNInformation, ListMLNInfoCommand>
    { }

    /// <summary>
    /// ดึงข้อมูลสมาชิกที่เป็น downline level1
    /// </summary>
    public interface IListDownLineByLevel1
        : IFetchData<MLNInformation, ListDownLineByLevel1Command>
    { }

    /// <summary>
    /// ดึงข้อมูลสมาชิกที่เป็น downline level2
    /// </summary>
    public interface IListDownLineByLevel2
        : IFetchData<MLNInformation, ListDownLineByLevel2Command>
    { }

    /// <summary>
    /// ดึงข้อมูลสมาชิกที่เป็น downline level3
    /// </summary>
    public interface IListDownLineByLevel3
        : IFetchData<MLNInformation, ListDownLineByLevel3Command>
    { }

}
