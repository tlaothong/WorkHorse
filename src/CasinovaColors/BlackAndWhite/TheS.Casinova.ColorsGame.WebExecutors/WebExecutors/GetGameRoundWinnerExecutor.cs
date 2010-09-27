using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ColorsGame.Models;
using TheS.Casinova.ColorsGame.DAL;

namespace TheS.Casinova.ColorsGame.WebExecutors
{
    public class GetGameRoundWinnerExecutor
    {
        private IColorsGameDataQuery _dac;

        public GetGameRoundWinnerExecutor(IColorsGameDataQuery dac)
        {
            this._dac = dac;
        }

        public IEnumerable<GamePlayInformation> GetGameRoundWinnerExe(string username)
        {

            var lstGameRoundWinner = _dac.Get(new Commands.GetGamePlayInfoCommand {
                UserName = username,
            });

            return lstGameRoundWinner.ToArray();

        }
    }
}
