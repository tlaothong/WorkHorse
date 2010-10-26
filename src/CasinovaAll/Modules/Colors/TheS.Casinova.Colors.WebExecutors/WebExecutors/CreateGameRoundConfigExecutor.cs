using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.TwoWins.Commands;
using TheS.Casinova.TwoWins.BackServices;

namespace TheS.Casinova.TwoWins.WebExecutors
{
    /// <summary>
    /// สร้าง active round
    /// </summary>
    public class CreateGameRoundConfigExecutor
        : SynchronousCommandExecutorBase<CreateGameRoundConfigurationCommand>
    {
        private ICreateGameTableConfigurations _iCreateRoundConfig;
        public CreateGameRoundConfigExecutor(IGameTableBackService dac)
        {
            _iCreateRoundConfig = dac;
        }
 
        protected override void ExecuteCommand(CreateGameRoundConfigurationCommand command)
        {
            _iCreateRoundConfig.Create(command);
        }
    }
}
