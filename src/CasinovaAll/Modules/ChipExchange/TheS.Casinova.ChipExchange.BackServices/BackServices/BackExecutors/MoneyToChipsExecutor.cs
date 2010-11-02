﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.Commands;
using PerfEx.Infrastructure.CommandPattern;
using TheS.Casinova.ChipExchange.DAL;
using TheS.Casinova.ChipExchange.BackServices.Commands;
using TheS.Casinova.ChipExchange.Models;

namespace TheS.Casinova.ChipExchange.BackServices.BackExecutors
{
    public class MoneyToChipsExecutor
        : SynchronousCommandExecutorBase<MoneyToChipsCommand>
    {
        private IGetExchangeSetting _iGetExchangeSetting;
        private IGetPlayerAccountInfo _iGetPlayerAccountInfo;
        private IIncreasePlayerChipsByMoney _iIncreasePlayerChipsByMoney;
        private IPayExchangeEngine _iPayExchangeEngine;

        public MoneyToChipsExecutor(IPayExchangeEngine svc, IChipExchangeDataAccess dac, IChipExchangeDataBackQuery dqr)
        {
            _iPayExchangeEngine = svc;
            _iGetExchangeSetting = dqr;
            _iGetPlayerAccountInfo = dqr;
            _iIncreasePlayerChipsByMoney = dac;
        }

        protected override void ExecuteCommand(MoneyToChipsCommand command)
        {
            //Get exchange setting
            GetExchangeSettingCommand getExchangeSettingCmd = new GetExchangeSettingCommand { Name = "Exchange1" };
            getExchangeSettingCmd.ExchangeSetting = _iGetExchangeSetting.Get(getExchangeSettingCmd);

            //Get player account information
            GetPlayerAccountInfoCommand getPlayerAccountInfoCmd = new GetPlayerAccountInfoCommand { UserName = command.UserName, AccountType = command.AccountType };
            getPlayerAccountInfoCmd.PlayerAccountInfo = _iGetPlayerAccountInfo.Get(getPlayerAccountInfoCmd);

            ExchangeInformation exchangeInfo = new ExchangeInformation{ 
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
            //Pay exchange to bank
            _iPayExchangeEngine.PayExchange(payExchangeCmd);

            //Update player chips by exchange rate
            exchangeInfo.Amount = getExchangeSettingCmd.ExchangeSetting.MoneyToChipRate * exchangeInfo.Amount;
            _iIncreasePlayerChipsByMoney.ApplyAction(exchangeInfo, command);
        }
    }
}
