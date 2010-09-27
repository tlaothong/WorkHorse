using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ColorsGame.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ColorsGame.DAL;

namespace TheS.Casinova.ColorsGame.BackServices.BackExecutors
{
    public class ListGameTableConfigurationsExecutor
        : SynchronousCommandExecutorBase<ListGameTableConfigurationsCommand>
    {
        private IColorsGameDataBackQuery _dqr;

        public ListGameTableConfigurationsExecutor(IColorsGameDataBackQuery dqr)
        {
            _dqr = dqr;
        }

        protected override void ExecuteCommand(ListGameTableConfigurationsCommand command)
        {
            command.TableConfigurations = _dqr.List(command);
        }
    }
}
