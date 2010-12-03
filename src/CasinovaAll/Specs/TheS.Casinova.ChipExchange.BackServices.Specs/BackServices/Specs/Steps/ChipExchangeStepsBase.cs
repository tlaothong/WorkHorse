using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheS.Casinova.ChipExchange.DAL;
using TechTalk.SpecFlow;
using TheS.Casinova.ChipExchange.BackServices.BackExecutors;
using SpecFlowAssist;

namespace TheS.Casinova.ChipExchange.BackServices.Specs.Steps
{
    public class ChipExchangeStepsBase
    {
        protected IIncreasePlayerChipsByMoney Dac_IncreasePlayerChipsByMoney
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_IncreasePlayerChipsByMoney] as IIncreasePlayerChipsByMoney;
            }
        }

        protected IIncreasePlayerBonusChipsByMoney Dac_IncreasePlayerBonusChipsByMoney
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_IncreasePlayerBonusChipsByMoney] as IIncreasePlayerBonusChipsByMoney;
            }
        }

        protected IIncreasePlayerBonusChipsByVoucher Dac_IncreasePlayerBonusChipsByVoucher
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_IncreasePlayerBonusChipsByVoucher] as IIncreasePlayerBonusChipsByVoucher;
            }
        }

        protected IUpdateUsedVoucher Dac_UpdateUsedVoucher
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_UpdateUsedVoucher] as IUpdateUsedVoucher;
            }
        }

        protected IUpdateUserProfile Dac_UpdateUserProfile
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_UpdateUserProfile] as IUpdateUserProfile;
            }
        }

        protected ICreateVoucherInformation Dac_CreateVoucherInfo
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac_CreateVoucherInfo] as ICreateVoucherInformation;
            }
        }

        protected ICreateChequeInformation Dac_CreateChequeInformation
        {
            get
            {
                return ScenarioContext.Current.Get<ICreateChequeInformation>();
            }
        }

        protected IGetExchangeSetting Dqr_GetExchangeSetting
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr_GetExchangeSetting] as IGetExchangeSetting;
            }
        }

        protected IGetPlayerAccountInfo Dqr_GetPlayerAccountInfo
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr_GetPlayerAccountInfo] as IGetPlayerAccountInfo;
            }
        }

        protected IGetMLNInfo Dqr_GetMLNInfo
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr_GetMLNInfo] as IGetMLNInfo;
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

        protected IGetUserProfile Dqr_GetUserProfile
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dqr_GetUserProfile] as IGetUserProfile;
            }
        }

        protected IPayExchangeEngine Svc_PayExchangeEngine
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_PayExchangeEngine] as IPayExchangeEngine;
            }
        }

        protected IGenerateVoucherCode Svc_GenerateVoucherCode
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_GenerateVoucherCode] as IGenerateVoucherCode;
            }
        }

        protected MoneyToChipsExecutor MoneyToChipsExecutor
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_MoneyToChips] as MoneyToChipsExecutor;
            }
        }

        protected MoneyToBonusChipsExecutor MoneyToBonusChipsExecutor
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_MoneyToBonusChips] as MoneyToBonusChipsExecutor;
            }
        }

        protected VoucherToBonusChipsExecutor VoucherToBonusChipsExecutor
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_VoucherToBonusChips] as VoucherToBonusChipsExecutor;
            }
        }

        protected PayVoucherExecutor PayVoucherExecutor 
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_PayVoucher] as PayVoucherExecutor;
            }
        }
    }
}
