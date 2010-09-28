using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Commands;
using TheS.Casinova.Colors.Models;

namespace TheS.Casinova.Colors.DAL
{
    public interface IColorsGameDataQuery :
        IListActiveGameRounds
    
    {}

    //List ข้อมูลโต๊ะเกมที่ active
    public interface IListActiveGameRounds
    {
        IEnumerable<ActiveGameRounds> List(ListActiveGameRoundsCommand amd);
    }
}
