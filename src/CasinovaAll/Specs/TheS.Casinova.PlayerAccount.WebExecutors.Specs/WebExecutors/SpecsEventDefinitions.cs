using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;

namespace TheS.Casinova.PlayerAccount.WebExecutors
{
    [Binding]
    public class SpecEventDefinitions
    {
        public const string Key_Mocks = "mocks";
        public const string Key_DisposbleMocksAction = "disposableMocksAction";

        public static MockRepository Mocks
        {
            get { return ScenarioContext.Current[Key_Mocks] as MockRepository; }
        }

        [BeforeScenarioBlock("record_mock")]
        public void BeforeScenarioBlock()
        {
            var mocks = Mocks;
            switch (ScenarioContext.Current.CurrentScenarioBlock) {
                case ScenarioBlock.Given:
                    ScenarioContext.Current[Key_DisposbleMocksAction] = mocks.Record();
                    break;
                case ScenarioBlock.When:
                    ScenarioContext.Current[Key_DisposbleMocksAction] = mocks.Playback();
                    break;
                default:
                    break;
            }
        }

        [AfterScenarioBlock("record_mock")]
        public void AfterScenarioBlock()
        {
            var mocks = Mocks;
            switch (ScenarioContext.Current.CurrentScenarioBlock) {
                case ScenarioBlock.Given:
                case ScenarioBlock.When:
                    ((IDisposable)ScenarioContext.Current[Key_DisposbleMocksAction]).Dispose();
                    break;
                default:
                    break;
            }
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            ScenarioContext.Current[Key_Mocks] = new MockRepository();
        }
    }
}
