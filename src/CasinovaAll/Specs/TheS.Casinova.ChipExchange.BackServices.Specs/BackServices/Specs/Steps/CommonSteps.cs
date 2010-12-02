using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.ChipExchange.DAL;
using TheS.Casinova.ChipExchange.BackServices.BackExecutors;
using PerfEx.Infrastructure;
using PerfEx.Infrastructure.Containers.StructureMapAdapter;
using TheS.Casinova.ChipExchange.Models;
using TheS.Casinova.ChipExchange.Commands;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.ChipExchange.BackServices.Validators;
using SpecFlowAssist;
using TheS.Casinova.PlayerProfile.Models;

namespace TheS.Casinova.ChipExchange.BackServices.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {
        public const string Key_Dac_IncreasePlayerChipsByMoney = "mockDac_IncreasePlayerChipsByMoney";
        public const string Key_Dac_IncreasePlayerBonusChipsByMoney = "mockDac_IncreasePlayerBonusChipsByMoney";
        public const string Key_Dac_IncreasePlayerBonusChipsByVoucher = "mockDac_IncreasePlayerBonusChipsByVoucher";
        public const string Key_Dac_UpdateUsedVoucher = "mockDac_UpdateUsedVoucher";
        public const string Key_Dac_UpdateUserProfile = "mockDac_UpdateUserProfile";
        public const string Key_Dac_CreateVoucherInfo = "mockDac_CreateVoucherInfo";

        public const string Key_Dqr_GetExchangeSetting = "mockDqr_GetExchangeSetting";
        public const string Key_Dqr_GetPlayerAccountInfo = "mockDqr_GetPlayerAccountInfo";
        public const string Key_Dqr_GetMLNInfo = "mockDqr_GetMLNInfo";
        public const string Key_Dqr_GetVoucherInfo = "mockDqr_GetVoucherInfo";
        public const string Key_Dqr_GetUserProfile = "mockDqr_GetUserProfile";

        public const string Key_PayExchangeEngine = "PayExchangeEngine";
        public const string Key_MoneyToChips = "MoneyToChips";
        public const string Key_MoneyToBonusChips = "MoneyToBonusChips";
        public const string Key_VoucherToBonusChips = "VoucherToBonusChips";
        public const string Key_GenerateVoucherCode = "GenerateVoucherCode";
        public const string Key_PayVoucher = "PayVoucher";

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        [Given(@"The MoneyToChipsExecutor has been created and initialized")]
        public void GivenTheMoneyToChipsExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IChipExchangeDataAccess>();
            var dqr = Mocks.DynamicMock<IChipExchangeDataBackQuery>();
            var svc = Mocks.DynamicMock<IPayExchangeEngine>();
            var container = Mocks.DynamicMock<IDependencyContainer>();

            ScenarioContext.Current[Key_Dac_IncreasePlayerChipsByMoney] = dac;

            ScenarioContext.Current[Key_Dqr_GetExchangeSetting] = dqr;
            ScenarioContext.Current[Key_Dqr_GetPlayerAccountInfo] = dqr;

            ScenarioContext.Current[Key_PayExchangeEngine] = svc;

            ScenarioContext.Current.Set<IChipExchangeDataBackQuery>(dqr);

            setupValidators(out container);
            ScenarioContext.Current[Key_MoneyToChips] = new MoneyToChipsExecutor(container, svc, dac, dqr);
        }

        [Given(@"The MoneyToBonusChipsExecutor has been created and initialized")]
        public void GivenTheMoneyToBonusChipsExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IChipExchangeDataAccess>();
            var dqr = Mocks.DynamicMock<IChipExchangeDataBackQuery>();
            var svc = Mocks.DynamicMock<IPayExchangeEngine>();
            var container = Mocks.DynamicMock<IDependencyContainer>();

            ScenarioContext.Current[Key_Dac_IncreasePlayerBonusChipsByMoney] = dac;

            ScenarioContext.Current[Key_Dqr_GetExchangeSetting] = dqr;
            ScenarioContext.Current[Key_Dqr_GetPlayerAccountInfo] = dqr;
            ScenarioContext.Current[Key_Dqr_GetMLNInfo] = dqr;

            ScenarioContext.Current[Key_PayExchangeEngine] = svc;

            ScenarioContext.Current.Set<IChipExchangeDataBackQuery>(dqr);

            setupValidators(out container);
            ScenarioContext.Current[Key_MoneyToBonusChips] = new MoneyToBonusChipsExecutor(container, svc, dac, dqr);
        }

        [Given(@"The VoucherToBounusChipsExecutor has been created and initialized")]
        public void GivenTheVoucherToBounusChipsExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IChipExchangeDataAccess>();
            var dqr = Mocks.DynamicMock<IChipExchangeDataBackQuery>();
            var container = Mocks.DynamicMock<IDependencyContainer>();

            ScenarioContext.Current[Key_Dqr_GetVoucherInfo] = dqr;
            ScenarioContext.Current[Key_Dqr_GetExchangeSetting] = dqr;

            ScenarioContext.Current[Key_Dac_UpdateUsedVoucher] = dac;
            ScenarioContext.Current[Key_Dac_IncreasePlayerBonusChipsByVoucher] = dac;

            ScenarioContext.Current.Set<IChipExchangeDataBackQuery>(dqr);
            
            setupValidators(out container);
            ScenarioContext.Current[Key_VoucherToBonusChips] = new VoucherToBonusChipsExecutor(container, dac, dqr);
        }

        [Given(@"The PayVoucherExecutor has been created and initialized")]
        public void GivenThePayVoucherExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IChipExchangeDataAccess>();
            var dqr = Mocks.DynamicMock<IChipExchangeDataBackQuery>();
            var svc = Mocks.DynamicMock<IGenerateVoucherCode>();
            var container = Mocks.DynamicMock<IDependencyContainer>();

            ScenarioContext.Current[Key_Dqr_GetUserProfile] = dqr;

            ScenarioContext.Current[Key_Dac_UpdateUserProfile] = dac;
            ScenarioContext.Current[Key_Dac_CreateVoucherInfo] = dac;

            ScenarioContext.Current[Key_GenerateVoucherCode] = svc;
            
            ScenarioContext.Current.Set<IChipExchangeDataBackQuery>(dqr);

            setupValidators(out container);
            ScenarioContext.Current[Key_PayVoucher] = new PayVoucherExecutor(container, svc, dac, dqr);
        }

        [Given(@"The ChipsToMoneyExecutor has been created and initialized")]
        public void GivenTheChipsToMoneyExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IChipExchangeDataAccess>();
            var dqr = Mocks.DynamicMock<IChipExchangeDataBackQuery>();
            var container = Mocks.DynamicMock<IDependencyContainer>();

            ScenarioContext.Current.Set<IGetUserProfile>(dqr);
            ScenarioContext.Current.Set<IUpdateUserProfile>(dac);
            ScenarioContext.Current.Set<ICreateChequeInformation>(dac);

            ScenarioContext.Current.Set<IChipExchangeDataBackQuery>(dqr);

            setupValidators(out container);
            ScenarioContext.Current.Set<ChipsToMoneyExecutor>(
                new ChipsToMoneyExecutor(container, dac, dqr));
        }

        private static void setupValidators(out IDependencyContainer container)
        {
            var fac = new StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<MultiLevelNetworkInformation, MoneyToBonusChipsCommand>
                , MLNInfo_MoneyToBonusChipsValidators>();
            reg.Register<IValidator<ExchangeSettingInformation, MoneyToBonusChipsCommand>
                , ExchangeSettingInfo_MoneyToBonusChipsValidators>();
            reg.Register<IValidator<ExchangeSettingInformation, MoneyToChipsCommand>
                , ExchangeSettingInfo_MoneyToChipsValidators>();
            reg.Register<IValidator<UserProfile, PayVoucherCommand>
                , UserProfile_PayVoucherValidators>();
            reg.Register<IValidator<VoucherInformation, VoucherToBonusChipsCommand>
                , VoucherInfo_VoucherToBonusChipsValidators>();

            reg.RegisterInstance<IChipExchangeDataBackQuery>
                (ScenarioContext.Current.Get<IChipExchangeDataBackQuery>());
            reg.Register<IServiceObjectProvider<IChipExchangeDataBackQuery>,
                DependencyInjectionServiceObjectProviderAdapter<IChipExchangeDataBackQuery, IChipExchangeDataBackQuery>>();

            container = fac.CreateContainer(reg);
        }
    }
}
