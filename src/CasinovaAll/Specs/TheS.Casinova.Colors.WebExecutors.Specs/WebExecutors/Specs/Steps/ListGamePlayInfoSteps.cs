using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.Colors.Models;
using Rhino.Mocks;
using TheS.Casinova.Colors.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.Colors.WebExecutors.Specs.Steps
{
    [Binding]
    public class ListGamePlayInfoSteps : ColorsGameStepsBase
    {
        private ListGamePlayInfoCommand cmd;

        [Given(@"The game play information of 'Lala' is :")]
        public void GivenTheGamePlayInformationOfLalaIs(Table table)
        {
            var qry = (from it in table.Rows
                       select new GamePlayInformation{
                           TableID = Convert.ToInt32(it["TableID"]),
                           RoundID = Convert.ToInt32(it["RoundID"]),
                           TotalBetAmountOfBlack = Convert.ToDouble(it["TotalBetAmountOfBlack"]),
                           TotalBetAmountOfWhite = Convert.ToDouble(it["TotalBetAmountOfWhite"]),
                           Winner = Convert.ToString(it["Winner"]),
                           LastUpdate = DateTime.Today + TimeSpan.Parse(it["LastUpdate"]),
                           TrackingID = Guid.Parse(it["TrackingID"]),
                           OnGoingTrackingID = Guid.Parse(it["OnGoingTrackingID"]),
                           UserName = Convert.ToString(it["UserName"]),
                       });

            Expect.Call(Dac.List(new Commands.ListGamePlayInfoCommand ()))
                .IgnoreArguments()
                .Return(qry);
        }

        [When(@"Call ListGamePlayInfo\('(.*)'\)")]
        public void WhenCallListGamePlayInfoX(string userName)
        {
            cmd = new ListGamePlayInfoCommand {
                UserName = userName
            };

            GamePlayInfoExecutor.Execute(cmd, player => { });
        }
        
        [Then(@"The result should be :")]
        public void ThenTheResultShouldBe(Table table)
        {
            var qryExpected = (from it in table.Rows
                               select new {
                                   TableID = Convert.ToInt32(it["TableID"]),
                                   RoundID = Convert.ToInt32(it["RoundID"]),
                                   TotalBetAmountOfBlack = Convert.ToDouble(it["TotalBetAmountOfBlack"]),
                                   TotalBetAmountOfWhite = Convert.ToDouble(it["TotalBetAmountOfWhite"]),
                                   Winner = Convert.ToString(it["Winner"]),
                                   LastUpdate = DateTime.Today + TimeSpan.Parse(it["LastUpdate"]),
                                   TrackingID = Guid.Parse(it["TrackingID"]),
                                   OnGoingTrackingID = Guid.Parse(it["OnGoingTrackingID"]),
                                   UserName = Convert.ToString(it["UserName"]),
                               });

            var result = (from it in cmd.GamePlayInfos
                          select new {
                              it.TableID,
                              it.RoundID,
                              it.TotalBetAmountOfBlack,
                              it.TotalBetAmountOfWhite,
                              it.Winner,
                              it.LastUpdate,
                              it.TrackingID,
                              it.OnGoingTrackingID,
                              it.UserName,
                          });

            CollectionAssert.AreEqual(qryExpected.ToArray(), result.ToArray());

        }
    }
}
