using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.PlayerAccount.DAL;
using TheS.Casinova.PlayerAccount.BackServices.BackExecutors;

namespace TheS.Casinova.PlayerAccount.BackServices.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {
        public const string Key_Dac_CancelPlayerAccount = "mockDac_CancelPlayerAccount";

        public const string Key_CancelPlayerAccount = "CancelPlayerAccount";

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        [Given(@"The CancelPlayerAccountExecutor has been created and initialized")]
        public void GivenTheCancelPlayerAccountExecutorHasBeenCreatedAndInitialized()
        {
            var dac = Mocks.DynamicMock<IPlayerAccountDataAccess>();

            ScenarioContext.Current[Key_Dac_CancelPlayerAccount] = dac;

            ScenarioContext.Current[Key_CancelPlayerAccount] = new CancelPlayerAccountExecutor(dac);
        }
    }
}
