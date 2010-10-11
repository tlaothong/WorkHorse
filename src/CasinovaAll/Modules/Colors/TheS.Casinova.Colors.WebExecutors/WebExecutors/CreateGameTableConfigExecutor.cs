using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.Colors.Commands;
using TheS.Casinova.Colors.BackServices;

namespace TheS.Casinova.Colors.WebExecutors
{
    public class CreateGameTableConfigExecutor
        : SynchronousCommandExecutorBase<CreateGameTableConfigurationsCommand>
    {
        private ICreateGameTableConfigurations _iCreateTableConfig;
        public CreateGameTableConfigExecutor(IGameTableBackService dac)
        {
            _iCreateTableConfig = dac;
        }

        protected override void ExecuteCommand(CreateGameTableConfigurationsCommand command)
        {
            _iCreateTableConfig.Create(command);
        }
    }
}
