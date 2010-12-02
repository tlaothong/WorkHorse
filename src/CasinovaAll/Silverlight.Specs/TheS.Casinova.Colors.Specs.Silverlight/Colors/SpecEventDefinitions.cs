using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rhino.Mocks;
using TechTalk.SpecFlow;
using SpecFlowAssist;

namespace TheS.Casinova.Colors.Specs.Silverlight.Colors
{
    [Binding]
    public class SpecEventDefinitions
    {
        [BeforeScenarioBlock("record_mock")]
        public void BeforeScenarioBlock()
        {
            switch (ScenarioContext.Current.CurrentScenarioBlock) 
            {
                case ScenarioBlock.Given:
                    var mocks = new MockRepository();
                    ScenarioContext.Current.Set(mocks);
                    ScenarioContext.Current.Set(mocks.Record(), "MocksRecord");
                    break;
                default:
                    break;
            }
        }

        [AfterScenarioBlock("record_mock")]
        public void AfterScenarioBlock()
        {
            switch (ScenarioContext.Current.CurrentScenarioBlock) 
            {
                case ScenarioBlock.Given:
                    ScenarioContext.Current.Get<IDisposable>("MocksRecord").Dispose();
                    break;
                default:
                    break;
            }
        }
    }
}
