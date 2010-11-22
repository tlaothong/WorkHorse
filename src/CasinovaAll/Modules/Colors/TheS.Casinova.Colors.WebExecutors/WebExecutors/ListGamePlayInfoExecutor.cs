using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.Colors.Commands;
using TheS.Casinova.Colors.DAL;
using TheS.Casinova.Colors.Models;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;

namespace TheS.Casinova.Colors.WebExecutors
{
    /// <summary>
    /// list ข้อมูลโต๊ะเกมทั้งหมดที่ผู้เล่นลงเดิมพันไว้
    /// </summary>
    public class ListGamePlayInfoExecutor
         : SynchronousCommandExecutorBase<ListGamePlayInfoCommand>
    {
        private IListGamePlayInformation _iListGamePlayInfo;
        private IDependencyContainer _container;

        public ListGamePlayInfoExecutor(IColorsGameDataQuery dqr, IDependencyContainer container )
        {
            _iListGamePlayInfo = dqr;
            _container = container;
        }

        protected override void ExecuteCommand(ListGamePlayInfoCommand command)
        {
             //Validation
             var errors = ValidationHelper.Validate(_container, command.GamePlayInfoUserName, command);
             if (errors.Any()) {
                 throw new ValidationErrorException(errors);
             }
            
            command.GamePlayInfos = _iListGamePlayInfo.List(command);
           
        }
    }
}
