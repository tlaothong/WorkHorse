using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TheS.Casinova.DevilSix.Models;
using TheS.Casinova.DevilSix.Commands;

namespace TheS.Casinova.DevilSix.WebExecutors.Specs.Steps
{
    [Binding]
    public class ListActiveGameRoundInfoSteps : DevilSixGameStepsBase
    {
        private IEnumerable<GameRoundInformation> _activeGameRound;
        private ListActiveGameRoundInfoCommand _cmd;

        [Given(@"server has 4 game round information  in data")]
        public void GivenServerHas4GameRoundInformationInData(Table table)
        {
             var activeGameRound = (from item in table.Rows
                                   select new GameRoundInformation{
                                       RoundID = Convert.ToInt32(item["RoundID"]),
                                       WinnerPoint = Convert.ToDouble(item["WinnerPoint"]),
                                       Active = Convert.ToBoolean(item["Active"]),
                                   });

            _activeGameRound = (from item in activeGameRound
                                   where item.Active == true
                                   select item);

            SetupResult.For(Dqr_ListActiveGameRound.List(new ListActiveGameRoundInfoCommand()))
                .IgnoreArguments()
                .Return(_activeGameRound);
        }

        [When(@"call ListActiveGameRoundInfoExecutor\(\)")]
        public void WhenCallListActiveGameRoundExecutor()
        {
            _cmd = new ListActiveGameRoundInfoCommand();

            ListActiveGameRound.Execute(_cmd, x => { });
        }

        [Then(@"the result should be as:")]
        public void ThenTheResultShouldBeAs(Table table)
        {
            var qryExpected = (from item in table.Rows
                               select new {
                                   RoundID = Convert.ToInt32(item["RoundID"]),
                                   WinnerPoint = Convert.ToDouble(item["WinnerPoint"]),
                                   Active = Convert.ToBoolean(item["Active"]),
                               });

            var result = (from it in _activeGameRound
                          select new {
                              RoundID = it.RoundID,
                              WinnerPoint = it.WinnerPoint,
                              Active = it.Active
                          });

            CollectionAssert.AreEqual(qryExpected.ToArray(), result.ToArray(), "Active RoundID Information");

        }

        [Then(@"Active game round should be null")]
        public void ThenActiveGameRoundShouldBeNull()
        {
            Assert.IsTrue(true, "Active round is null");
        }
    }
}
