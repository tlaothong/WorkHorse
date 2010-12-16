using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.TwoWins.Commands;
using TheS.Casinova.TwoWins.DAL;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.TwoWins.WebExecutors
{
    /// <summary>
    /// ดึงข้อมูลโต๊ะเกมที่ active อยู่
    /// </summary>
    public class ListGameRoundInfoExecutor
    : SynchronousCommandExecutorBase<ListGameRoundInfoCommand>
    {
        private IListGameRoundInfo _iListGameRoundInfo;
        private IDependencyContainer _container;

        public ListGameRoundInfoExecutor(ITwoWinsGameDataQuery dqr, IDependencyContainer container)
        {
            _iListGameRoundInfo = dqr;
            _container = container;
        }

        protected override void ExecuteCommand(ListGameRoundInfoCommand command)
        {
            command = new ListGameRoundInfoCommand {
                FromTime = DateTime.Now
            };
            command.RoundInformation = _iListGameRoundInfo.List(command);
        }
    }
}
