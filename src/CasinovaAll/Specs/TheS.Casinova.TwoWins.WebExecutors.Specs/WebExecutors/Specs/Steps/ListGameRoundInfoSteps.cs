using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.TwoWins.Models;
using TheS.Casinova.TwoWins.Commands;
using Rhino.Mocks;
using SpecFlowAssist;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.TwoWins.WebExecutors.Specs.Steps
{
    [Binding]
    public class ListGameRoundInfoSteps : TwoWinGameStepsBase
    {
        private ListGameRoundInfoCommand _cmd;
        private IEnumerable<RoundInformation> _roundInfo;

        [Given(@"The active game rounds are :")]
        public void GivenTheActiveGameRoundsAre(Table table)
        {
            if (table.RowCount == 0) {
                SetupResult.For(Dqr_ListGameRoundInfo.List(new ListGameRoundInfoCommand()))
               .IgnoreArguments().Return(null);

            }
            else {
                _roundInfo = table.CreateSet<RoundInformation>();
                
                SetupResult.For(Dqr_ListGameRoundInfo.List(new ListGameRoundInfoCommand()))
               .IgnoreArguments().Return(_roundInfo);
            }
        }

        [When(@"Call ListGameRoundInfoExecutor\(\)")]
        public void WhenCallListGameRoundInfoExecutor()
        {
            ListGameRoundInfo.Execute(_cmd, (x) => { });
        }

        [Then(@"The result should be:")]
        public void ThenTheResultShouldBe(Table table)
        {
            var expect = from item in table.Rows
                         select new {
                             RoundID = Convert.ToInt32(item["RoundID"]),
                             FromDateTime = DateTime.Parse(item["FromDateTime"]),
                             ThruDateTime = DateTime.Parse(item["ThruDateTime"]),
                             CriticalDateTime = DateTime.Parse(item["CriticalDateTime"])
                         };
            var actual = from item in _roundInfo
                         select new {
                             RoundID = item.RoundID,
                             FromDateTime = item.FromDateTime,
                             ThruDateTime = item.ThruDateTime,
                             CriticalDateTime = item.CriticalDateTime
                         };

            CollectionAssert.AreEqual(expect.ToArray(), actual.ToArray());
        }

        [Then(@"The active game rounds should be null:")]
        public void ThenTheActiveGameRoundsShouldBeNull()
        {
            Assert.AreEqual(null, _roundInfo);
        }
    }
}
