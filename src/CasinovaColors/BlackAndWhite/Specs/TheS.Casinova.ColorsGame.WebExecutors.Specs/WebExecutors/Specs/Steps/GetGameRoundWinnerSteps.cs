using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.ColorsGame.Models;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.ColorsGame.WebExecutors.Specs.Steps
{
    [Binding]
    public class GetGameRoundWinnerSteps : GetGameRoundWinnerStepsBase
    {
        private IEnumerable<GamePlayInformation> _result;
        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }
        private string _username;


        [Given(@"Sent username '(.*)' Game active formtime '10:00'")]
        public void GivenSentUsernameJohnGameActiveFormtime1000(string username)
        {
            _username = username;
        }

        [Given(@"server have J.Doe's gameRoundWinner as")]
        public void GivenServerHaveJDoeSGameInformationAs(Table table)
        {
            var qry = (from it in table.Rows
                       select new GamePlayInformation {
                           UserName = Convert.ToString(it["Username"]),
                           TableID = Convert.ToInt32(it["TableID"]),
                           RoundID = Convert.ToInt32(it["RoundID"]),
                           TotalBetAmounfOfBlack = Convert.ToDouble(it["TotalBetAmountOfBlack"]),
                           TotalBetAmountOfWhite = Convert.ToDouble(it["TotalBetAmountOfWhite"]),
                           LastUpdate = DateTime.Today + TimeSpan.Parse(it["LastUpdate"]),
                           TrackingID = Guid.Parse(it["TrackingID"]),
                           OnGoingTrackingID = Guid.Parse(it["OnGoingTrackingID"]),
                           Winner = Convert.ToString(it["Winner"]),
                       });
            SetupResult.For(Dac.Get(new Commands.GetGamePlayInfoCommand()))
                .IgnoreArguments()
                .Return(qry);
        }

        [When(@"Call GetGameRoundWinner\('(.*)'\)")]
        public void WhenCallGetGameRoundWinnerJ_Doe(string username)
        {
            _result = GetGameRoundWinner.GetGameRoundWinnerExe(username);
        }

        [Then(@"the result should be")]
        public void ThenTheResultShouldBe(Table table)
        {
            var qryExpected = (from it in table.Rows
                               select new {
                                   UserName = Convert.ToString(it["Username"]),
                                   TableID = Convert.ToInt32(it["TableID"]),
                                   RoundID = Convert.ToInt32(it["RoundID"]),
                                   TotalBetAmounfOfBlack = Convert.ToDouble(it["TotalBetAmountOfBlack"]),
                                   TotalBetAmountOfWhite = Convert.ToDouble(it["TotalBetAmountOfWhite"]),
                                   LastUpdate = DateTime.Today + TimeSpan.Parse(it["LastUpdate"]),
                                   TrackingID = Guid.Parse(it["TrackingID"]),
                                   OnGoingTrackingID = Guid.Parse(it["OnGoingTrackingID"]),
                                   Winner = Convert.ToString(it["Winner"]),
                               });
            var result = (from it in _result
                          select new {
                              it.UserName,
                              it.TableID,
                              it.RoundID,
                              it.TotalBetAmounfOfBlack,
                              it.TotalBetAmountOfWhite,
                              it.LastUpdate,
                              it.TrackingID,
                              it.OnGoingTrackingID,
                              it.Winner
                          });

            CollectionAssert.AreEqual(qryExpected.ToArray(), result.ToArray());
        }
        #region username unavailble
        [Given(@"server have John's gameRoundWinner as")]
        public void GivenServerHaveJohnSGameRoundWinnerAs(Table table)
        {
            var qry = (from it in table.Rows
                       select new GamePlayInformation {
                           UserName = Convert.ToString(it["Username"]),
                           TableID = Convert.ToInt32(it["TableID"]),
                           RoundID = Convert.ToInt32(it["RoundID"]),
                           TotalBetAmounfOfBlack = Convert.ToDouble(it["TotalBetAmountOfBlack"]),
                           TotalBetAmountOfWhite = Convert.ToDouble(it["TotalBetAmountOfWhite"]),
                           LastUpdate = DateTime.Today + TimeSpan.Parse(it["LastUpdate"]),
                           TrackingID = Guid.Parse(it["TrackingID"]),
                           OnGoingTrackingID = Guid.Parse(it["OnGoingTrackingID"]),
                           Winner = Convert.ToString(it["Winner"]),
                       });
            SetupResult.For(Dac.Get(new Commands.GetGamePlayInfoCommand()))
                .IgnoreArguments()
                .Return(qry);
        }

      
        [Then(@"the result should be empty")]
        public void ThenTheResultShouldBeEmpty()
        {
            _result = _result.DefaultIfEmpty();
        }
        #endregion
    }
}
