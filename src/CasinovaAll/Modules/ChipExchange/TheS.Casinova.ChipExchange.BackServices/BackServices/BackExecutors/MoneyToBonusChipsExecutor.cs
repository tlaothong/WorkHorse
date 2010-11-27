using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ChipExchange.DAL;
using TheS.Casinova.ChipExchange.Models;
using TheS.Casinova.ChipExchange.BackServices.Commands;

namespace TheS.Casinova.ChipExchange.BackServices.BackExecutors
{
    public class MoneyToBonusChipsExecutor
        : SynchronousCommandExecutorBase<MoneyToBonusChipsCommand>
    {
        private IGetMLNInfo _iGetMLNInfo;
        private IGetExchangeSetting _iGetExchangeSetting;
        private IGetPlayerAccountInfo _iGetPlayerAccountInfo;
        private IIncreasePlayerBonusChipsByMoney _iIncreasePlayerBonusChipsByMoney;
        private IPayExchangeEngine _iPayExchangeEngine;

        public MoneyToBonusChipsExecutor(IPayExchangeEngine svc, IChipExchangeDataAccess dac, IChipExchangeDataBackQuery dqr)
        {
            _iGetMLNInfo = dqr;
            _iGetExchangeSetting = dqr;
            _iGetPlayerAccountInfo = dqr;
            _iIncreasePlayerBonusChipsByMoney = dac;
            _iPayExchangeEngine = svc;
        }

        protected override void ExecuteCommand(MoneyToBonusChipsCommand command)
        {
            GetMLNInfoCommand getMLNInfoCmd = new GetMLNInfoCommand { UserName = command.UserName };
            getMLNInfoCmd.MLNInfo = _iGetMLNInfo.Get(getMLNInfoCmd);

            if (getMLNInfoCmd.MLNInfo.Bonus >= command.Amount) { //Request amount should more than bonus
                //Get exchange setting
                GetExchangeSettingCommand getExchangeSettingCmd = new GetExchangeSettingCommand { Name = "Exchange1" };
                getExchangeSettingCmd.ExchangeSetting = _iGetExchangeSetting.Get(getExchangeSettingCmd);

                //Request amount should more than minimum exchange rate
                if (command.Amount >= getExchangeSettingCmd.ExchangeSetting.MinMoneyToChipExchange) {
                    //Get player account information
                    GetPlayerAccountInfoCommand getPlayerAccountInfoCmd = new GetPlayerAccountInfoCommand {
                        UserName = command.UserName,
                        AccountType = command.AccountType
                    };
                    getPlayerAccountInfoCmd.PlayerAccountInfo = _iGetPlayerAccountInfo.Get(getPlayerAccountInfoCmd);

                    ExchangeInformation exchangeInfo = new ExchangeInformation {
                        UserName = command.UserName,
                        FirstName = getPlayerAccountInfoCmd.PlayerAccountInfo.FirstName,
                        LastName = getPlayerAccountInfoCmd.PlayerAccountInfo.LastName,
                        Amount = command.Amount,
                        CardType = getPlayerAccountInfoCmd.PlayerAccountInfo.CardType,
                        AccountNo = getPlayerAccountInfoCmd.PlayerAccountInfo.AccountNo,
                        CVV = getPlayerAccountInfoCmd.PlayerAccountInfo.CVV,
                        ExpireDate = getPlayerAccountInfoCmd.PlayerAccountInfo.ExpireDate,
                    };
                    PayExchangeCommand payExchangeCmd = new PayExchangeCommand {
                        ExchangeInfo = exchangeInfo
                    };

                    if (_iPayExchangeEngine.PayExchange(payExchangeCmd)) { //Pay exchange to bank
                        //Update player bonus chips by exchange rate
                        exchangeInfo.Amount = getExchangeSettingCmd.ExchangeSetting.MoneyToBonusChipRate * exchangeInfo.Amount;
                        _iIncreasePlayerBonusChipsByMoney.ApplyAction(exchangeInfo, command);
                    }
                    else {
                        Console.WriteLine("################ ทำรายการไม่สำเร็จ ###############");
                    }
                }
            }
            else {
                Console.WriteLine("################################### โบนัสไม่พอแลก!!! ##################################");
            }
        }
    }
}