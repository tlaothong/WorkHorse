using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Demo.SimpleGame.DAL;
using PerfEx.Demo.SimpleGame.Models;
using PerfEx.Demo.SimpleGame.Commands;

namespace PerfEx.Demo.SimpleGame {
   public class ColorGameService {

       private IColorGameDataAccess _dac;

       public ColorGameService(IColorGameDataAccess dac) {
           _dac = dac;
       }

       public GameResult GetGameResult(int tableId, int roundId) {

           var gameResult = _dac.Get(new Commands.GetGameResultCommand {
               TableID = tableId,
               RoundID = roundId
           });


           return gameResult;
       }
    }
}
