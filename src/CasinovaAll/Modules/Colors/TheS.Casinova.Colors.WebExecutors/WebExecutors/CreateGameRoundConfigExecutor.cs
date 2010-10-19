using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.Colors.Commands;
using TheS.Casinova.Colors.BackServices;

namespace TheS.Casinova.Colors.WebExecutors
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
