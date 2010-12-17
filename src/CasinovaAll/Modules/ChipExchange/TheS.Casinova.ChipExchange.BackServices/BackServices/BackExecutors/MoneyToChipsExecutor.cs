using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ChipExchange.DAL;
using TheS.Casinova.ChipExchange.BackServices.Commands;
using TheS.Casinova.ChipExchange.Models;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure;

namespace TheS.Casinova.ChipExchange.BackServices.BackExecutors
{
    public class MoneyToChipsExecutor
        : SynchronousCommandExecutorBase<MoneyToChipsCommand>
    {
        private IGetExchangeSetting _iGetExchangeSetting;
        private IGetPlayerAccountInfo _iGetPlayerAccountInfo;
        private IIncreasePlayerChipsByMoney _iIncreasePlayerChipsByMoney;
        private IPayExchangeEngine _iPayExchangeEngine;
        private IDependencyContainer _container;

        public MoneyToChipsExecutor(IDependencyContainer container, IPayExchangeEngine svc, IChipExchangeDataAccess dac, IChipExchangeDataBackQuery dqr)
        {
            _iPayExchangeEngine = svc;
            _iGetExchangeSetting = dqr;
            _iGetPlayerAccountInfo = dqr;
            _iIncreasePlayerChipsByMoney = dac;
            _container = container;
        }

        protected override void ExecuteCommand(MoneyToChipsCommand command)
        {
            ValidationErrorCollection errorValidations = new ValidationErrorCollection();

            //Request amount should more than minimum exchange rate
            ExchangeSettingInformation exchangeSettingInfo = new ExchangeSettingInformation { Name = "Exchange1" };
            ValidationHelper.Validate(_container, exchangeSettingInfo, command, errorValidations);
            
            if (errorValidations.Any()) {
                throw new ValidationErrorException(errorValidations);
            }

            //Get exchange setting
            GetExchangeSettingCommand getExchangeSettingCmd = new GetExchangeSettingCommand { ExchangeSettingInput = exchangeSettingInfo };
            getExchangeSettingCmd.ExchangeSetting = _iGetExchangeSetting.Get(getExchangeSettingCmd);

            GetPlayerAccountInfoCommand getPlayerAccountInfoCmd = new GetPlayerAccountInfoCommand { 
                UserName = command.ExchangeInformation.UserName, 
                AccountType = command.ExchangeInformation.AccountType 
            };
            getPlayerAccountInfoCmd.PlayerAccountInfo = _iGetPlayerAccountInfo.Get(getPlayerAccountInfoCmd);

            command.ExchangeInformation.FirstName = getPlayerAccountInfoCmd.PlayerAccountInfo.FirstName;
            command.ExchangeInformation.LastName = getPlayerAccountInfoCmd.PlayerAccountInfo.LastName;
            command.ExchangeInformation.CardType = getPlayerAccountInfoCmd.PlayerAccountInfo.CardType;
            command.ExchangeInformation.AccountNo = getPlayerAccountInfoCmd.PlayerAccountInfo.AccountNo;
            command.ExchangeInformation.CVV = getPlayerAccountInfoCmd.PlayerAccountInfo.CVV;
            command.ExchangeInformation.ExpireDate = getPlayerAccountInfoCmd.PlayerAccountInfo.ExpireDate;

            PayExchangeCommand payExchangeCmd = new PayExchangeCommand {
                ExchangeInfo = command.ExchangeInformation
            };

            if (_iPayExchangeEngine.PayExchange(payExchangeCmd)) { //Pay exchange to bank
                //Update player chips by exchange rate
                command.ExchangeInformation.Amount = getExchangeSettingCmd.ExchangeSetting.MoneyToChipRate * command.ExchangeInformation.Amount;
                _iIncreasePlayerChipsByMoney.ApplyAction(command.ExchangeInformation, command);
            }
            else {
                throw new InvalidOperationException("ทำรายการไม่สำเร็จ ข้อมูลบัตรเครดิตอาจผิดพลาด");
            }
        }
    }
}
