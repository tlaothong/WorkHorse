using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.ChipExchange.DAL;
using TheS.Casinova.ChipExchange.BackServices;
using SpecFlowAssist;
using TheS.Casinova.Common.Services;

namespace TheS.Casinova.ChipExchange.WebExecutors.Specs.Steps
{
    [Binding]
    public class ChipsExchangeModuleStepsBase
    {
        protected IGetPlayerAccountInfo Dqr_GetPlayerAccountInfo
        {
            get
            {
                return ScenarioContext.Current.Get<IGetPlayerAccountInfo>();
            }
        }

        protected IMoneyToChips Dac_MoneyToChips
        {
            get
            {
                return ScenarioContext.Current.Get<IMoneyToChips>();
            }
        }

        protected IMoneyToBonusChips Dac_MoneyToBonusChips
        {
            get
            {
                return ScenarioContext.Current.Get<IMoneyToBonusChips>();
            }
        }

        protected IGetMultiLevelNetworkInfo Dqr_GetMultiLevelNetworkInfo
        {
            get
            {
                return ScenarioContext.Current.Get<IGetMultiLevelNetworkInfo>();
            }
        }

        protected IVoucherToBonusChips Dac_VoucherToBonusChips
        {
            get
            {
                return ScenarioContext.Current.Get<IVoucherToBonusChips>();
            }
        }

        protected IGetPlayerBalance Dqr_GetPlayerBalance
        {
            get
            {
                return ScenarioContext.Current.Get<IGetPlayerBalance>();
            }
        }

        protected IPayVoucher Dac_PayVoucher
        {
            get
            {
                return ScenarioContext.Current.Get<IPayVoucher>();
            }
        }

        protected IGetVoucherCode Dqr_GetVoucherCode
        {
            get
            {
                return ScenarioContext.Current.Get<IGetVoucherCode>();
            }
        }

        protected IChipsToMoney Dac_ChipsToMoney
        {
            get
            {
                return ScenarioContext.Current.Get<IChipsToMoney>();
            }
        }

        protected IChipsToBonusChips Dac_ChipsToBonusChips
        {
            get
            {
                return ScenarioContext.Current.Get<IChipsToBonusChips>();
            }
        }


        protected VoucherToBonusChipsExecutor VoucherToBonusChips
        {
            get
            {
                return ScenarioContext.Current.Get<VoucherToBonusChipsExecutor>();
            }
        }


        protected MoneyToChipsExecutor MoneyToChips
        {
            get
            {
                return ScenarioContext.Current.Get<MoneyToChipsExecutor>();
            }
        }

        protected MoneyToBonusChipsExecutor MoneyToBonusChips
        {
            get
            {
                return ScenarioContext.Current.Get<MoneyToBonusChipsExecutor>();
            }
        }

        protected PayVoucherExecutor PayVoucher
        {
            get
            {
                return ScenarioContext.Current.Get<PayVoucherExecutor>();
            }
        }

        protected GetVoucherCodeExecutor GetVoucherCode
        {
            get
            {
                return ScenarioContext.Current.Get<GetVoucherCodeExecutor>();
            }
        }

        protected ChipsToMoneyExecutor ChipsToMoney
        {
            get
            {
                return ScenarioContext.Current.Get<ChipsToMoneyExecutor>();
            }
        }

        protected ChipsToBonusChipsExecutor ChipsToBonusChips
        {
            get
            {
                return ScenarioContext.Current.Get<ChipsToBonusChipsExecutor>();
            }
        }

        protected IGenerateTrackingID svc_GenerateTrackingID
        {
            get
            {
                return ScenarioContext.Current.Get<IGenerateTrackingID>();
            }
        }
    }
}
