using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
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
using TheS.Casinova.Common.Services;

namespace TheS.Casinova.ChipExchange.WebExecutors.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {
        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        //Chips to money exchange specs initialized
        [Given(@"The ChipsToMoneyExecutor has been created and initialized")]
        public void GivenTheChipsToMoneyExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IChipsExchangeModuleBackService>();
            var dqr = Mocks.DynamicMock<IChipsExchangeModuleDataQuery>();

            IDependencyContainer container;

            ScenarioContext.Current.Set<IChipsToMoney>(dac);
            ScenarioContext.Current.Set<IChipsExchangeModuleDataQuery>(dqr);

            setupValidators(out container);
            ScenarioContext.Current.Set<ChipsToMoneyExecutor>(
                new ChipsToMoneyExecutor(dac, container));
        }

        //Money to chips exchange specs initialized
        [Given(@"The MoneyToChipsExecutor has been created and initialized")]
        public void GivenTheMoneyToChipsExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IChipsExchangeModuleBackService>();
            var dqr = Mocks.DynamicMock<IChipsExchangeModuleDataQuery>();

            IDependencyContainer container;

            ScenarioContext.Current.Set<IGetPlayerAccountInfo>(dqr);
            ScenarioContext.Current.Set<IVoucherToBonusChips>(dac);
            ScenarioContext.Current.Set<IChipsExchangeModuleDataQuery>(dqr);
           
            setupValidators(out container);
            ScenarioContext.Current.Set<MoneyToChipsExecutor>(
                new MoneyToChipsExecutor(dac, container));

          
        }

        //Money to bonus chips exchange specs initialized
        [Given(@"The MoneyToBonusChipsExecutor has been created and initialized")]
        public void GivenTheMoneyToBonusChipsExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IChipsExchangeModuleBackService>();
            var dqr = Mocks.DynamicMock<IChipsExchangeModuleDataQuery>();

            IDependencyContainer container;

            ScenarioContext.Current.Set<IMoneyToBonusChips>(dac);
            ScenarioContext.Current.Set<IGetPlayerAccountInfo>(dqr);
            ScenarioContext.Current.Set<IGetMultiLevelNetworkInfo>(dqr);
            ScenarioContext.Current.Set<IChipsExchangeModuleDataQuery>(dqr);

            setupValidators(out container);
            ScenarioContext.Current.Set<MoneyToBonusChipsExecutor>(
                new MoneyToBonusChipsExecutor(dac, container));
           
        }

        //Voucher to bonus chips exchange specs initialized
        [Given(@"The VoucherToBonusChipsExecutor has been created and initialized")]
        public void GivenTheVoucherToBonusChipsExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IChipsExchangeModuleBackService>();
            var svc = Mocks.DynamicMock<IGenerateTrackingID>();
            var dqr = Mocks.DynamicMock<IChipsExchangeModuleDataQuery>();

            IDependencyContainer container;

            ScenarioContext.Current.Set<IVoucherToBonusChips>(dac);
            ScenarioContext.Current.Set<IGenerateTrackingID>(svc);
            ScenarioContext.Current.Set<IChipsExchangeModuleDataQuery>(dqr);

            setupValidators(out container);
            ScenarioContext.Current.Set<VoucherToBonusChipsExecutor>(
                new VoucherToBonusChipsExecutor(dac, container, svc));
        }

        //Pay voucher specs initialized
        [Given(@"The PayVoucherExecutor has been created and initialized")]
        public void GivenThePayVoucherExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IChipsExchangeModuleBackService>();
            var dqr = Mocks.DynamicMock<IChipsExchangeModuleDataQuery>();
            var svc = Mocks.DynamicMock<IGenerateTrackingID>();
            IDependencyContainer container;

            ScenarioContext.Current.Set<IGetPlayerBalance>(dqr);
            ScenarioContext.Current.Set<IPayVoucher>(dac);
            ScenarioContext.Current.Set<IGenerateTrackingID>(svc);

            ScenarioContext.Current.Set<IChipsExchangeModuleDataQuery>(dqr);

            setupValidators(out container);
            ScenarioContext.Current.Set<PayVoucherExecutor>(
                 new PayVoucherExecutor(dac, container, svc));
        }

        //Get voucher code specs initialized
        [Given(@"The GetVoucherCodeExecutor has been created and initialized")]
        public void GivenTheGetVoucherCodeExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<IChipsExchangeModuleDataQuery>();

            IDependencyContainer container;
            
            ScenarioContext.Current.Set<IGetVoucherCode>(dqr);
            ScenarioContext.Current.Set<IChipsExchangeModuleDataQuery>(dqr);

            setupValidators(out container);
            ScenarioContext.Current.Set<GetVoucherCodeExecutor>(
                new GetVoucherCodeExecutor(dqr, container));
        }

        //Chips to bonus chips exchange specs initialized
        [Given(@"The ChipsToBonusChipsExecutor has been created and initialized")]
        public void GivenTheChipsToBonusChipsExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IChipsExchangeModuleBackService>();
            var dqr = Mocks.DynamicMock<IChipsExchangeModuleDataQuery>();

            IDependencyContainer container;

            ScenarioContext.Current.Set<IChipsToBonusChips>(dac);
            ScenarioContext.Current.Set<IGetPlayerBalance>(dqr);
            ScenarioContext.Current.Set<IGetMultiLevelNetworkInfo>(dqr);
            ScenarioContext.Current.Set<IChipsExchangeModuleDataQuery>(dqr);

            setupValidators(out container);
            ScenarioContext.Current.Set<ChipsToBonusChipsExecutor>(
                new ChipsToBonusChipsExecutor(dac, container));
        }

        private static void setupValidators(out IDependencyContainer container)
        {
            var fac = new StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<VoucherInformation, NullCommand>
                , DataAnnotationValidator<VoucherInformation, NullCommand>>();

            reg.Register<IValidator<ExchangeInformation, NullCommand>
                , DataAnnotationValidator<ExchangeInformation, NullCommand>>();

            reg.Register<IValidator<ChequeInformation, NullCommand>
                , DataAnnotationValidator<ChequeInformation, NullCommand>>();

            reg.Register<IValidator<ChequeInformation, ChipsToMoneyCommand>
                , ChequeInformation_ChipsToMoneyValidators>();

            reg.Register<IValidator<VoucherInformation, PayVoucherCommand>
               , VoucherInformation_PayVoucherValidators>();

            reg.Register<IValidator<VoucherInformation, VoucherToBonusChipsCommand>
              , VoucherInformation_VoucherToBonusChipsValidators>();

            reg.Register<IValidator<ExchangeInformation, MoneyToChipsCommand>
             , ExchangeInformation_MoneyToChipsValidators>();

            reg.Register<IValidator<ExchangeInformation, MoneyToBonusChipsCommand>
             , ExchangeInformation_MoneyToBonusChipsValidators>();

            reg.Register<IValidator<ExchangeInformation, ChipsToBonusChipsCommand>
             , ExchangeInformation_ChipsToBonusChipsValidators>();

            reg.RegisterInstance<IChipsExchangeModuleDataQuery>
                (ScenarioContext.Current.Get<IChipsExchangeModuleDataQuery>());
            reg.Register<IServiceObjectProvider<IChipsExchangeModuleDataQuery>,
                DependencyInjectionServiceObjectProviderAdapter<IChipsExchangeModuleDataQuery, IChipsExchangeModuleDataQuery>>();


            container = fac.CreateContainer(reg);
        }
    }
}
