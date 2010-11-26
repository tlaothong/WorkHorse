using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.MagicNine.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.MagicNine.DAL;
using TheS.Casinova.MagicNine.Models;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.MagicNine.BackServices.BackExecutors
{
    public class StopAutoBetExecutor
        : SynchronousCommandExecutorBase<StopAutoBetCommand>
    {
        private IAutoBetEngine _iAutoBetEngine;
        private IUpdateAutoBetInfo _iUpdateAutoBetInfo;
        private IGetAutoBetInfo _iGetAutoBetInfo;
        private IDependencyContainer _container;

        public StopAutoBetExecutor(IDependencyContainer container, IAutoBetEngine svc, IMagicNineGameDataAccess dac, IMagicNineGameDataBackQuery dqr)
        {
            _container = container;
            _iAutoBetEngine = svc;
            _iUpdateAutoBetInfo = dac;
            _iGetAutoBetInfo = dqr;
        }

        protected override void ExecuteCommand(StopAutoBetCommand command)
        {
            GamePlayAutoBetInformation autoBetInfo;

            //ดึงข้อมูลการลงพนันอัตโนมัติ
             autoBetInfo = _iGetAutoBetInfo.Get(command);

             ValidationErrorCollection errorsValidation = new ValidationErrorCollection();
             ValidationHelper.Validate(_container, autoBetInfo, command, errorsValidation);

             if (errorsValidation.Any()) {
                 throw new ValidationErrorException(errorsValidation);
             }

            //อัพเดท stop trackingID สำหรับตรวจสอบการหยุด autobet
            _iUpdateAutoBetInfo.ApplyAction(command.GamePlayAutoBetInfo, command);

            //ส่งข้อมูลการหยุดลงพนันให้ AutoBet Engine ทำงานต่อ
            _iAutoBetEngine.StopAutoBet(command.GamePlayAutoBetInfo, command);
        }
    }
}
