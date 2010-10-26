using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.TwoWins.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.TwoWins.DAL;

namespace TheS.Casinova.TwoWins.BackServices.BackExecutors
{
    public class CreateGameRoundConfigurationExecutor
        : SynchronousCommandExecutorBase<CreateGameRoundConfigurationCommand>
    {
        private ICreateGameRoundConfigurations _iCreateGameTable;

        public CreateGameRoundConfigurationExecutor(IColorsGameDataAccess dac)
        {
            _iCreateGameTable = dac;
        }

        protected override void ExecuteCommand(CreateGameRoundConfigurationCommand command)
        {
            _iCreateGameTable.Create(command.Tables, command);
        }
    }
}
