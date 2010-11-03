using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.ChipExchange.DAL;
using TheS.Casinova.ChipExchange.BackServices;

namespace TheS.Casinova.ChipExchange.WebExecutors.Specs.Steps
{
    [Binding]
    public class ChipsExchangeModuleStepsBase
    {
        protected IGetPlayerAccountInfo Dqr_GetPlayerAccountInfo
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr_GetPlayerAccountInfo] as IGetPlayerAccountInfo;
            }
        }

        protected IMoneyToChips Dac_MoneyToChips
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_MoneyToChips] as IMoneyToChips;
            }
        }

        protected IMoneyToBonusChips Dac_MoneyToBonusChips
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_MoneyToBonusChips] as IMoneyToBonusChips;
            }
        }

        protected IGetMultiLevelNetworkInfo Dqr_GetMultiLevelNetworkInfo
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr_GetMultiLevelNetworkInfo] as IGetMultiLevelNetworkInfo;
            }
        }

        protected IVoucherToBonusChips Dac_VoucherToBonusChips
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_VoucherToBonusChips] as IVoucherToBonusChips;
            }
        }

        protected IGetVoucherInfo Dqr_GetVoucherInfo
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr_GetVoucherInfo] as IGetVoucherInfo;
            }
        }

        protected VoucherToBonusChipsExecutor VoucherToBonusChips
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_VoucherToBonusChips] as VoucherToBonusChipsExecutor;
            }
        }


        protected MoneyToChipsExecutor MoneyToChips
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_MoneyToChips] as MoneyToChipsExecutor;
            }
        }

        protected MoneyToBonusChipsExecutor MoneyToBonusChips
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_MoneyToChips] as MoneyToBonusChipsExecutor;
            }
        }
    }
}
