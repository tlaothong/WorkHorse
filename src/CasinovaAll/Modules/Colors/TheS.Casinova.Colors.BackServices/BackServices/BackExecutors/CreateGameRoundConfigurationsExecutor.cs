﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.Colors.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.Colors.DAL;

namespace TheS.Casinova.Colors.BackServices.BackExecutors
{
    public class CreateGameRoundConfigurationsExecutor
        : SynchronousCommandExecutorBase<CreateGameRoundConfigurationsCommand>
    {
        private ICreateGameRoundConfigurations _iCreateGameTable;

        public CreateGameRoundConfigurationsExecutor(IColorsGameDataAccess dac)
        {
            _iCreateGameTable = dac;
        }

        protected override void ExecuteCommand(CreateGameRoundConfigurationsCommand command)
        {
            _iCreateGameTable.Create(command.Tables, command);
        }
    }
}