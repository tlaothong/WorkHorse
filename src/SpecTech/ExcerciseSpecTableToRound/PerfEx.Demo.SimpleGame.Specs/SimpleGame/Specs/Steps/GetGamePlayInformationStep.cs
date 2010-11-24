using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using PerfEx.Demo.SimpleGame.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PerfEx.Demo.SimpleGame.Specs.Steps {
    [Binding]
    public class GetGamePlayInformationStep : GameTableConfiguratorStepsBase {

        private IEnumerable<Models.GamePlayInfomation> _result;
        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }
        private string _username;



        [Given(@"Sent username '(.*)' Game active formtime '10:00'")]
        public void GivenSentUsernameJohnGameActiveFormtime1000(string username) {
            _username = username;
        }

        [Given(@"server have John's gameInformation as")]
        public void GivenServerHaveJohnSGameInformationAs(Table table) {
            var qry = (from it in table.Rows
                       select new GamePlayInfomation {
                           TableID = Convert.ToInt32(it["TableID"]),
                           RoundID = Convert.ToInt32(it["RoundID"]),
                           TotalBetAmountOfWhite = Convert.ToInt32(it["TotalBetAmountOfWhite"]),
                           TotalBetAmountOfBlack = Convert.ToInt32(it["TotalBetAmountOfBlack"]),
                           LastUpdate = DateTime.Today + TimeSpan.Parse(it["LastUpdate"]),
                           TrackingID = Convert.ToString(it["TrackingID"]),
                           OnGoingTrackingID = Convert.ToString(it["OnGoingTrackingID"]),
                           Winner = Convert.ToString(it["Winner"]),
                       });
            SetupResult.For(Dac.List(new Commands.ListGamePlayInformationCommand()))
                .IgnoreArguments()
                .Return(qry);
        }

        [When(@"Call GetGamePlayInformationForUser\('(.*)'\)")]
        public void WhenCallGetGamePlayInformationForUserJohn(string username) {
            _result= TableCfgtor.GetGamePlayInformationForUser(username);
        }

        [Then(@"the result should be")]
        public void ThenTheResultShouldBe(Table table) {
            var qryExpected = (from it in table.Rows
                               select new {
                                   TableID = Convert.ToInt32(it["TableID"]),
                                   RoundID = Convert.ToInt32(it["RoundID"]),
                                   TotalBetAmountOfWhite = Convert.ToInt32(it["TotalBetAmountOfWhite"]),
                                   TotalBetAmountOfBlack = Convert.ToInt32(it["TotalBetAmountOfBlack"]),
                                   LastUpdate = DateTime.Today + TimeSpan.Parse(it["LastUpdate"]),
                                   TrackingID = Convert.ToString(it["TrackingID"]),
                                   OnGoingTrackingID = Convert.ToString(it["OnGoingTrackingID"]),
                                   Winner = Convert.ToString(it["Winner"]),
                               });
            var result = (from it in _result
                          select new {
                              it.TableID,
                              it.RoundID,
                              it.TotalBetAmountOfWhite,
                              it.TotalBetAmountOfBlack,
                              it.LastUpdate,
                              it.TrackingID,
                              it.OnGoingTrackingID,
                              it.Winner
                          });

            CollectionAssert.AreEqual(qryExpected.ToArray(), result.ToArray());
        }
        #region username unavailble
        [Given(@"server have Yui's gameInformation as")]
        public void GivenServerHaveYuiSGameInformationAs(Table table) {
            var qry = (from it in table.Rows
                       select new GamePlayInfomation {
                           TableID = Convert.ToInt32(it["TableID"]),
                           RoundID = Convert.ToInt32(it["RoundID"]),
                           TotalBetAmountOfWhite = Convert.ToInt32(it["TotalBetAmountOfWhite"]),
                           TotalBetAmountOfBlack = Convert.ToInt32(it["TotalBetAmountOfBlack"]),
                           LastUpdate = DateTime.Today + TimeSpan.Parse(it["LastUpdate"]),
                           TrackingID = Convert.ToString(it["TrackingID"]),
                           OnGoingTrackingID = Convert.ToString(it["OnGoingTrackingID"]),
                           Winner = Convert.ToString(it["Winner"]),
                       });
            SetupResult.For(Dac.List(new Commands.ListGamePlayInformationCommand()))
                .IgnoreArguments()
                .Return(qry);
        }

        [Then(@"the result should be empty")]
        public void ThenTheResultShouldBeEmpty() {
            _result = _result.DefaultIfEmpty();
        }
        #endregion
    }
}
