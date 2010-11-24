using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Demo.SimpleGame.Models;
using PerfEx.Demo.SimpleGame.Commands;

namespace PerfEx.Demo.SimpleGame.DAL {
    public interface IColorGameDataAccess
        :IGetGameResult
    {
    }

    public interface IGetGameResult {
        GameResult Get(GetGameResultCommand cmd);
    }
}
