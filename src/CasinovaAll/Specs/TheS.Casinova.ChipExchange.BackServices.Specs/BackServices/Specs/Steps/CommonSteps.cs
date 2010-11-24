﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.ChipExchange.DAL;
using TheS.Casinova.ChipExchange.BackServices.BackExecutors;

namespace TheS.Casinova.ChipExchange.BackServices.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {
        public const string Key_Dac_IncreasePlayerChipsByMoney = "mockDac_IncreasePlayerChipsByMoney";
        public const string Key_Dac_IncreasePlayerBonusChipsByMoney = "mockDac_IncreasePlayerBonusChipsByMoney";
        public const string Key_Dac_IncreasePlayerBonusChipsByVoucher = "mockDac_IncreasePlayerBonusChipsByVoucher";
        public const string Key_Dac_UpdateUsedVoucher = "mockDac_UpdateUsedVoucher";

        public const string Key_Dqr_GetExchangeSetting = "mockDqr_GetExchangeSetting";
        public const string Key_Dqr_GetPlayerAccountInfo = "mockDqr_GetPlayerAccountInfo";
        public const string Key_Dqr_GetMLNInfo = "mockDqr_GetMLNInfo";
        public const string Key_Dqr_GetVoucherInfo = "mockDqr_GetVoucherInfo";

        public const string Key_PayExchangeEngine = "PayExchangeEngine";
        public const string Key_MoneyToChips = "MoneyToChips";
        public const string Key_MoneyToBonusChips = "MoneyToBonusChips";
        public const string Key_VoucherToBonusChips = "VoucherToBonusChips";

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        [Given(@"The MoneyToChipsExecutor has been created and initialized")]
        public void GivenTheMoneyToChipsExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IChipExchangeDataAccess>();
            var dqr = Mocks.DynamicMock<IChipExchangeDataBackQuery>();
            var svc = Mocks.DynamicMock<IPayExchangeEngine>();

            ScenarioContext.Current[Key_Dac_IncreasePlayerChipsByMoney] = dac;

            ScenarioContext.Current[Key_Dqr_GetExchangeSetting] = dqr;
            ScenarioContext.Current[Key_Dqr_GetPlayerAccountInfo] = dqr;

            ScenarioContext.Current[Key_PayExchangeEngine] = svc;
            ScenarioContext.Current[Key_MoneyToChips] = new MoneyToChipsExecutor(svc, dac, dqr);
        }

        [Given(@"The MoneyToBonusChipsExecutor has been created and initialized")]
        public void GivenTheMoneyToBonusChipsExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IChipExchangeDataAccess>();
            var dqr = Mocks.DynamicMock<IChipExchangeDataBackQuery>();
            var svc = Mocks.DynamicMock<IPayExchangeEngine>();

            ScenarioContext.Current[Key_Dac_IncreasePlayerBonusChipsByMoney] = dac;

            ScenarioContext.Current[Key_Dqr_GetExchangeSetting] = dqr;
            ScenarioContext.Current[Key_Dqr_GetPlayerAccountInfo] = dqr;
            ScenarioContext.Current[Key_Dqr_GetMLNInfo] = dqr;

            ScenarioContext.Current[Key_PayExchangeEngine] = svc;
            ScenarioContext.Current[Key_MoneyToBonusChips] = new MoneyToBonusChipsExecutor(svc, dac, dqr);
        }

        [Given(@"The VoucherToBounusChipsExecutor has been created and initialized")]
        public void GivenTheVoucherToBounusChipsExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IChipExchangeDataAccess>();
            var dqr = Mocks.DynamicMock<IChipExchangeDataBackQuery>();

            ScenarioContext.Current[Key_Dqr_GetVoucherInfo] = dqr;
            ScenarioContext.Current[Key_Dqr_GetExchangeSetting] = dqr;

            ScenarioContext.Current[Key_Dac_UpdateUsedVoucher] = dac;
            ScenarioContext.Current[Key_Dac_IncreasePlayerBonusChipsByVoucher] = dac;
            ScenarioContext.Current[Key_VoucherToBonusChips] = new VoucherToBonusChipsExecutor(dac, dqr);
        }
    }
}
