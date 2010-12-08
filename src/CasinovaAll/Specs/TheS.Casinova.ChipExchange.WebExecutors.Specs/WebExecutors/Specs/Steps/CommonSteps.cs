using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.TwoWins.WebExecutors;
using TheS.Casinova.ChipExchange.DAL;
using TheS.Casinova.ChipExchange.BackServices;
using TheS.Casinova.ChipExchange.Commands;
using PerfEx.Infrastructure.Containers.StructureMapAdapter;
using PerfEx.Infrastructure;
using TheS.Casinova.ChipExchange.Models;
using PerfEx.Infrastructure.CommandPattern;
using PerfEx.Infrastructure.Validation;
using SpecFlowAssist;
using TheS.Casinova.ChipExchange.Validators;

namespace TheS.Casinova.ChipExchange.WebExecutors.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {
        public const string Key_MoneyToChips = "MoneyToChips";
        public const string Key_Dac_MoneyToChips = "mockDac_MoneyToChips";
        public const string Key_Dqr_GetPlayerAccountInfo = "mockDqr_GetPlayerAccountInfo";

        public const string Key_MoneyToBonusChips = "MoneyToBonusChips";
        public const string Key_Dac_MoneyToBonusChips = "mockDac_MoneyToBonusChips";
        public const string Key_Dqr_GetMultiLevelNetworkInfo = "mockDqr_GetMultiLevelNetworkInfo";

        public const string Key_VoucherToBonusChips = "VoucherToBonusChips";
        public const string Key_Dac_VoucherToBonusChips = "mockDac_VoucherToBonusChips";
        public const string Key_Dqr_GetVoucherInfo = "mockDqr_GetVoucherInfo";

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        //Money to chips exchange specs initialized
        [Given(@"The MoneyToChipsExecutor has been created and initialized")]
        public void GivenTheMoneyToChipsExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IChipsExchangeModuleBackService>();
            var dqr = Mocks.DynamicMock<IChipsExchangeModuleDataQuery>();

            ScenarioContext.Current[Key_Dac_MoneyToChips] = dac;
            ScenarioContext.Current[Key_Dqr_GetPlayerAccountInfo] = dqr;
            ScenarioContext.Current[Key_MoneyToChips] = new MoneyToChipsCommand();
        }

        //Money to bonus chips exchange specs initialized
        [Given(@"The MoneyToBonusChipsExecutor has been created and initialized")]
        public void GivenTheMoneyToBonusChipsExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IChipsExchangeModuleBackService>();
            var dqr = Mocks.DynamicMock<IChipsExchangeModuleDataQuery>();

            ScenarioContext.Current[Key_Dac_MoneyToBonusChips] = dac;
            ScenarioContext.Current[Key_Dqr_GetPlayerAccountInfo] = dqr;
            ScenarioContext.Current[Key_Dqr_GetMultiLevelNetworkInfo] = dqr;
            ScenarioContext.Current[Key_MoneyToBonusChips] = new MoneyToBonusChipsCommand();
           
        }

        //Voucher to bonus chips exchange specs initialized
        [Given(@"The VoucherToBonusChipsExecutor has been created and initialized")]
        public void GivenTheVoucherToBonusChipsExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IChipsExchangeModuleBackService>();
            var dqr = Mocks.DynamicMock<IChipsExchangeModuleDataQuery>();

            ScenarioContext.Current[Key_Dac_VoucherToBonusChips] = dac;
            ScenarioContext.Current[Key_Dqr_GetVoucherInfo] = dqr;
            ScenarioContext.Current[Key_VoucherToBonusChips] = new VoucherToBonusChipsCommand();
        }

        //Pay voucher specs initialized
        [Given(@"The PayVoucherExecutor has been created and initialized")]
        public void GivenThePayVoucherExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IChipsExchangeModuleBackService>();
            var dqr = Mocks.DynamicMock<IChipsExchangeModuleDataQuery>();

            IDependencyContainer container;
            setupValidators(out container);

            ScenarioContext.Current.Set<IGetPlayerBalance>(dqr);
            ScenarioContext.Current.Set<IPayVoucher>(dac);
            ScenarioContext.Current.Set<PayVoucherExecutor>(
                new PayVoucherExecutor(dac, container));
        }

        //Get voucher code specs initialized
        [Given(@"The GetVoucherCodeExecutor has been created and initialized")]
        public void GivenTheGetVoucherCodeExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<IChipsExchangeModuleDataQuery>();

            IDependencyContainer container;
            setupValidators(out container);
            ScenarioContext.Current.Set<IGetVoucherCode>(dqr);
            ScenarioContext.Current.Set<GetVoucherCodeExecutor>(
                new GetVoucherCodeExecutor(dqr, container));
        }

        private static void setupValidators(out IDependencyContainer container)
        {
            var fac = new StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<VoucherInformation, NullCommand>
                , DataAnnotationValidator<VoucherInformation, NullCommand>>();

            reg.Register<IValidator<VoucherInformation, PayVoucherCommand>
               , VoucherInformation_PayVoucherValidators>();

            container = fac.CreateContainer(reg);
        }
    }
}
