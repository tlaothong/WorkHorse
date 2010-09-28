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
    public class ListActiveGameRoundsSteps : ListActiveGameRoundsStepsBase
    {
        private IEnumerable<ActiveGameRounds> _result;
        private ListActiveGameRoundsCommand cmd;

        [Given(@"The active game rounds are :")]
        public void GivenTheActiveGameRoundsAre(Table table)
        {
            var qry = (from it in table.Rows
                       select new ActiveGameRounds {
                           TableID = Convert.ToInt32(it["TableId"]),
                           RoundID = Convert.ToInt32(it["RoundId"]),
                           StartTime = DateTime.Today + TimeSpan.Parse(it["StartTime"]),
                           EndTime = DateTime.Today + TimeSpan.Parse(it["EndTime"]),
                       });

            SetupResult.For(Dac.List(new Commands.ListActiveGameRoundsCommand()))
                .IgnoreArguments()
                .Return(qry);

        }

        [When(@"Call ListActiveGameRoundsExecutor")]
        public void WhenCallListActiveGameRoundsExecutor()
        {
            cmd = new ListActiveGameRoundsCommand();
            ActiveGameRoundsExecutor.Execute(cmd, x => {});
        }

        [Then(@"The result should be:")]
        public void ThenTheResultShouldBe(Table table)
        {
            var qryExpected = (from it in table.Rows
                               select new {
                                   TableID = Convert.ToInt32(it["TableId"]),
                                   RoundID = Convert.ToInt32(it["RoundId"]),
                                   StartTime = DateTime.Today + TimeSpan.Parse(it["StartTime"]),
                                   EndTime = DateTime.Today + TimeSpan.Parse(it["EndTime"]),
                               });
            var result = (from it in cmd.ActiveRounds
                          select new {
                              it.TableID,
                              it.RoundID,
                              it.StartTime,
                              it.EndTime,
                          });

            CollectionAssert.AreEqual(qryExpected.ToArray(), result.ToArray());
        }

       
    }
}
