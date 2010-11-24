using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.Colors.Commands;
using TheS.Casinova.Colors.DAL;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;

namespace TheS.Casinova.Colors.WebExecutors
{
    /// <summary>
    /// ดึงข้อมูลผลการเล่นเกมของ round
    /// </summary>
    public class GetGameResultExecutor
        : SynchronousCommandExecutorBase<GetGameResultCommand>
    {
         private IGetGameResult _iGameResult;
         private IDependencyContainer _container;

         public GetGameResultExecutor(IColorsGameDataQuery dac, IDependencyContainer container)
        {
            _iGameResult = dac;
            _container = container;
        }

         protected override void ExecuteCommand(GetGameResultCommand command)
         {
             //Validation
             var errors = ValidationHelper.Validate(_container, command.GameResultGameRoundInfo, command);
             if (errors.Any()) {
                 throw new ValidationErrorException(errors);
             }

             command.GameResultGameRoundInfo = _iGameResult.Get(command);                 
         }
    }
}
