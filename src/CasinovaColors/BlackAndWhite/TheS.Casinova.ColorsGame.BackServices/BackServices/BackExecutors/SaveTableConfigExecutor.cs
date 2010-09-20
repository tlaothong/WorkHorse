using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ColorsGame.DAL;
using TheS.Casinova.ColorsGame.Commands;

namespace TheS.Casinova.ColorsGame.BackServices.BackExecutors
{
    public class SaveTableConfigurationExecutor
        : SynchronousCommandExecutorBase<SaveTableConfigurationCommand>
    {
        private IColorsGameDataAccess _dac;

        public SaveTableConfigurationExecutor(IColorsGameDataAccess dac)
        {
            _dac = dac;
        }

        protected override void ExecuteCommand(SaveTableConfigurationCommand command)
        {
            _dac.Create(command.TableConfig, command);
        }
    }
}
