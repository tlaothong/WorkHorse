using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rhino.Mocks;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Demo.SimpleGame.Models;

namespace PerfEx.Demo.SimpleGame.Specs.Steps
{
    [Binding]
    public class SaveTableConfigurationSteps : GameTableConfiguratorStepsBase
    {
        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        [Given(@"Expect the tables should be saved by calling ICreateGameTableConfiguration\.Create\(\)")]
        public void GivenExpectTheTablesShouldBeSavedByCallingICreateGameTableConfiguration_Create()
        {
            Dac.Create(null);
            LastCall.IgnoreArguments();
        }

        [When(@"call SaveTableConfiguration\(name: '(.*)', tables: as follows\)")]
        public void WhenCallSaveTableConfigurationNameConfig1TablesAsFollows(string name, Table table)
        {
            var qry = (from it in table.Rows
                       select new GameTable {
                           GameDuration = Convert.ToInt32(it["GameDuration"]),
                           Interval = Convert.ToInt32(it["Interval"]),
                       });
            TableCfgtor.SaveTableConfiguration(name, qry);
        }

        [Then(@"the tables should be saved by calling ICreateGameTableConfiguration\.Create\(\)")]
        public void ThenTheTablesShouldBeSavedByCallingICreateGameTableConfiguration_Create()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
    }
}
