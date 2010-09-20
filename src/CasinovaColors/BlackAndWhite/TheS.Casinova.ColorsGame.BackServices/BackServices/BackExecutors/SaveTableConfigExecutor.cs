using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ColorsGame.DAL;

namespace TheS.Casinova.ColorsGame.BackServices.BackExecutors
{
    public class SaveTableConfigurationExecutor
        : SynchronousCommandExecutorBase<SaveTableConfigurationExecutor>
    {
        private IColorsGameDataAccess _dac;

        public SaveTableConfigurationExecutor(IColorsGameDataAccess dac)
        {
            _dac = dac;
        }

        protected override void ExecuteCommand(SaveTableConfigurationExecutor command)
        {
            throw new NotImplementedException();
        }
    }
}
