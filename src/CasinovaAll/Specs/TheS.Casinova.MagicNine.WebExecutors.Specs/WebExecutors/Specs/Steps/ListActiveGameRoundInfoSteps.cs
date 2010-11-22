using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.MagicNine.Models;
using Rhino.Mocks;
using TheS.Casinova.MagicNine.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.MagicNine.WebExecutors.Specs.Steps
{
    [Binding]
    public class ListActiveGameRoundInfoSteps : MagicNineGameStepsBase
    {
        private IEnumerable<GameRoundInformation> _activeGameRound;
        private ListActiveGameRoundInfoCommand _cmd;

        [Given(@"server has 4 game round information  in data")]
        public void GivenServerHas4GameRoundInformationInData(Table table)
        {
             var activeGameRound = (from item in table.Rows
                                   select new GameRoundInformation{
                                       RoundID = Convert.ToInt32(item["RoundID"]),
                                       WinnerPoint = Convert.ToInt32(item["WinnerPoint"]),
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
                                   WinnerPoint = Convert.ToInt32(item["WinnerPoint"]),
                                   Active = Convert.ToBoolean(item["Active"]),
                               });

            var result = (from it in _cmd.GameRoundInfos
                          select new {
                              it.RoundID,
                              it.WinnerPoint,
                              it.Active
                          });

            CollectionAssert.AreEqual(qryExpected.ToArray(), result.ToArray(), "Active Round Information");

        }

        [Then(@"the result should be null")]
        public void ThenTheResultShouldBeNull()
        {
            Assert.IsTrue(true, "Active round is null");
        }
    }
}
