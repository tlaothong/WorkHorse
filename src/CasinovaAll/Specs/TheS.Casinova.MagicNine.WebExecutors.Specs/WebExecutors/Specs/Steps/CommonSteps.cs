using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.MagicNine.WebExecutors;
using TheS.Casinova.MagicNine.DAL;
using TheS.Casinova.MagicNine.BackServices;
using PerfEx.Infrastructure;
using TheS.Casinova.MagicNine.Models;
using PerfEx.Infrastructure.Validation;
using PerfEx.Infrastructure.CommandPattern;
using PerfEx.Infrastructure.Containers.StructureMapAdapter;
using TheS.Casinova.MagicNine.Commands;
using SpecFlowAssist;

namespace TheS.Casinova.MagicNine.WebExecutors.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {
        public const string Key_Dac_StopAutoBet = "mockDac_StopAutoBet";
        public const string Key_StopAutoBet = "StopAutoBet";
        public const string Key_Dac_StartAutoBet = "mockDac_StartAutoBet";
        public const string Key_StartAutoBet = "StartAutoBet";
        public const string Key_Dqr_ListGamePlayAutoBetInfo = "mockDqr_ListGamePlayAutoBetInfo";
        public const string Key_ListGamePlayAutoBetInfo = "ListGamePlayAutoBetInfo";
        public const string Key_Dqr_ListActiveGameRound = "mockDqr_ListActiveGameRound";
        public const string Key_ListActiveGameRound = "ListActiveGameRoundInfo";
        public const string Key_Dqr_ListBetLog = "mockDqr_ListBetLog";
        public const string Key_ListBetLog = "ListBetLog";
  

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        //List bet log specs initialized
        [Given(@"The ListBetLogExecutor has been created and initialized")]
        public void GivenTheListBetLogExecutorHasBeenCreatedAndInitialized()
        {
             var dqr = Mocks.DynamicMock<IMagicNineGameDataQuery>();

             ScenarioContext.Current[Key_Dqr_ListBetLog] = dqr;
             ScenarioContext.Current[Key_ListBetLog] = new ListBetLogExecutor(dqr);
        }

        //Single bet specs initialized
        [Given(@"The SingleBetExecutor has been created and initialized")]
        public void GivenTheSingleBetExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IMagicNineGameBackService>();

            IDependencyContainer container;
            setupValidators(out container);
            ScenarioContext.Current.Set<ISingleBet>(dac);
            ScenarioContext.Current.Set<SingleBetExecutor>(
                new SingleBetExecutor(dac, container));
 
        }

        //List active game round specs initialized
        [Given(@"The ListActiveGameRoundInfoExecutor has been created and initialized")]
        public void GivenTheListActiveGameRoundInfoExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<IMagicNineGameDataQuery>();

            ScenarioContext.Current[Key_Dqr_ListActiveGameRound] = dqr;
            ScenarioContext.Current[Key_ListActiveGameRound] = new ListActiveGameRoundInfoExecutor(dqr);
        }

        //List game play auto bet information specs initialized
        [Given(@"The ListGamePlayAutoBetInfoExecutor has been created and initialized")]
        public void GivenTheListGamePlayAutoBetInfoExecutorHasBeenCreatedAndInitialized()
        {
            var dqr = Mocks.DynamicMock<IMagicNineGameDataQuery>();

            ScenarioContext.Current[Key_Dqr_ListGamePlayAutoBetInfo] = dqr;
            ScenarioContext.Current[Key_ListGamePlayAutoBetInfo] = new ListGamePlayAutoBetInfoExecutor(dqr);
        }

        //Start  auto bet information specs initialized
        [Given(@"The StartAutoBetExecutor has been created and initialized")]
        public void GivenTheStartAutoBetExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IMagicNineGameBackService>();

            ScenarioContext.Current[Key_Dac_StartAutoBet] = dac;
            ScenarioContext.Current[Key_StartAutoBet] = new StartAutoBetExecutor(dac);
        }

        //Stop auto bet information specs initialized
        [Given(@"The StopAutoBetExecutor has been created and initialized")]
        public void GivenTheStopAutoBetExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IMagicNineGameBackService>();

            ScenarioContext.Current[Key_Dac_StopAutoBet] = dac;
            ScenarioContext.Current[Key_StopAutoBet] = new StopAutoBetExecutor(dac);
        }

        private static void setupValidators(out IDependencyContainer container)
        {
            var fac = new StructureMapAbstractFactory();
            var reg = fac.CreateRegistry();

            reg.Register<IValidator<BetInformation, SingleBetCommand>
                , DataAnnotationValidator<BetInformation, SingleBetCommand>>();

            container = fac.CreateContainer(reg);
        }
    }
}
