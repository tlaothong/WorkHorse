using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PerfEx.Demo.SimpleGame.Specs.Steps
{
    [Binding]
    public class GenerateGameTableSteps : GameTableConfiguratorStepsBase
    {
        private IEnumerable<Models.GameTable> _result;

        [When(@"call GenerateTableConfiguration\(tableCount: (.*), gameDuration: (.*), gameInterval: (.*)\)")]
        public void WhenCallGenerateTableConfigurationTableCount4GameDuration20GameInterval5(int tableCount, int gameDuration, int gameInterval)
        {
            _result = TableCfgtor.GenerateTableConfiguration(tableCount, gameDuration, gameInterval);
        }

        [Then(@"the result should be equivalent to the following table")]
        public void ThenTheResultShouldBeEquivalentToTheFollowingTable(Table table)
        {
            var qryExpected = (from it in table.Rows
                               select new { GameDuration = Convert.ToInt32(it["GameDuration"]), Interval = Convert.ToInt32(it["Interval"]) });

            var qryResult = (from it in _result
                             select new { it.GameDuration, it.Interval });

            CollectionAssert.AreEqual(qryExpected.ToArray(), qryResult.ToArray());
        }
    }
}
