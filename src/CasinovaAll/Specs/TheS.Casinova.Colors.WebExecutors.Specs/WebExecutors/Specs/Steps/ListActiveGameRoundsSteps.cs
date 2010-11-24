using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.Colors.Models;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheS.Casinova.Colors.Commands;

namespace TheS.Casinova.Colors.WebExecutors.Specs.Steps
{
    [Binding]
    public class ListActiveGameRoundsSteps : ColorsGameStepsBase
    {
        private ListActiveGameRoundCommand _cmd;
        private IEnumerable<GameRoundInformation> _GameRound;
        private IEnumerable<GameRoundInformation> _ActiveGameRound;

        [Given(@"The active game rounds are :")]
        public void GivenTheActiveGameRoundsAre(Table table)
        {
            if (table.RowCount == 0) 
            {
                SetupResult.For(Dqr_ListActiveGameRounds.List(new ListActiveGameRoundCommand()))
               .IgnoreArguments().Return(null);

            }else{
                _GameRound = from item in table.Rows
                      select new GameRoundInformation {
                          RoundID = Convert.ToInt32(item["RoundID"]),
                          StartTime = DateTime.Parse(item["StartTime"]),
                          EndTime = DateTime.Parse(item["EndTime"])
                      };

            SetupResult.For(Dqr_ListActiveGameRounds.List(new ListActiveGameRoundCommand()))
                .IgnoreArguments().Return(_GameRound);
            }
        }

        [When(@"Call ListActiveGameRoundsExecutor\(\)")]
        public void WhenCallListActiveGameRoundsExecutor()
        {
            _ActiveGameRound = Dqr_ListActiveGameRounds.List(_cmd);
        }

        [Then(@"The result should be:")]
        public void ThenTheResultShouldBe(Table table)
        {
            var expect = from item in table.Rows
                         select new {
                             RoundID = Convert.ToInt32(item["RoundID"]),
                             StartTime = DateTime.Parse(item["StartTime"]),
                             EndTime = DateTime.Parse(item["EndTime"])
                         };
            var actual = from item in _ActiveGameRound
                         select new {
                             RoundID = item.RoundID,
                             StartTime = item.StartTime,
                             EndTime = item.EndTime
                         };

            CollectionAssert.AreEqual(expect.ToArray(), actual.ToArray());
        }

        [Then(@"The active game rounds should be null:")]
        public void ThenTheActiveGameRoundsShouldBeNull()
        {
            Assert.AreEqual(null, _ActiveGameRound);
        }

    }
}
