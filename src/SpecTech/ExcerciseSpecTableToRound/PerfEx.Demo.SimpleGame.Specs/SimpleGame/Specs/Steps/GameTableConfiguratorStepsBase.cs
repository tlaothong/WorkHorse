using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using PerfEx.Demo.SimpleGame.DAL;

namespace PerfEx.Demo.SimpleGame.Specs.Steps
{
    public class GameTableConfiguratorStepsBase
    {
        protected GameTableConfigurator TableCfgtor
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_TableConfigurator] as GameTableConfigurator;
            }
        }

        protected IGameTableDataAccess Dac
        {
            get
            {
                return ScenarioContext.Current[
                    CommonSteps.Key_Dac] as IGameTableDataAccess;
            }
        }
    }
}
