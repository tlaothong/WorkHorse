using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.Colors.Models;
using Rhino.Mocks;
using TheS.Casinova.Colors.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks.Constraints;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.Colors.WebExecutors.Specs.Steps
{
    [Binding]
    public class ListGamePlayInfoSteps : ColorsGameStepsBase
    {
        private ListGamePlayInfoCommand _cmd;
        private IEnumerable<GamePlayInformation> _listGamePlayInfo;
        private IEnumerable<GamePlayInformation> _resultGamePlayInfo;

        [Given(@"Server has game play information as:")]
        public void GivenServerHasGamePlayInformationAs(Table table)
        {
            _listGamePlayInfo = from item in table.Rows
                                select new GamePlayInformation { 
                                    UserName = Convert.ToString(item["UserName"]),
                                    RoundID = Convert.ToInt32(item["RoundID"]),
                                    TotalBetBlack = Convert.ToDouble(item["TotalBetBlack"]),
                                    TotalBetWhite = Convert.ToDouble(item["TotalBetWhite"]),
                                    Winner = Convert.ToString(item["Winner"]),
                                    TrackingID = Guid.Parse(item["TrackingID"]),
                                    OnGoingTrackingID = Guid.Parse(item["OnGoingTrackingID"]),
                                    WinnerLastUpdate = DateTime.Parse(item["WinnerLastUpdate"])
                                };
        }

        [Given(@"Sent userName'(.*)' for list game play information")]
        public void GivenSentUserNameForListGamePlayInformation(string userName)
        {
            _resultGamePlayInfo = (from item in _listGamePlayInfo
                                   where item.UserName == userName
                                   select item);

            SetupResult.For(Dqr_ListGamePlayInformation.List(new ListGamePlayInfoCommand()))
                .IgnoreArguments().Return(_resultGamePlayInfo);

            _cmd = new ListGamePlayInfoCommand {
                GamePlayInfo = new GamePlayInformation {
                    UserName = userName
                }
            };
        }

        //Test function
        [When(@"Call ListGamePlayInfoExecutor\(\)")]
        public void WhenCallListGamePlayInfoExecutorX()
        {
                ListGamePlayInfo.Execute(_cmd, (x) => { });
        }

        //Validation
        [When(@"Call ListGamePlayInfoExecutor\(\) for validate username")]
        public void WhenCallListGamePlayInfoExecutorBoyForValidateUsername()
        {
            try {
                ListGamePlayInfo.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        [Then(@"The game play information should be :")]
        public void ThenTheGamePlayInformationShouldBe(Table table)
        {
            var expect = from item in table.Rows
                         select new {
                             UserName = Convert.ToString(item["UserName"]),
                             RoundID = Convert.ToInt32(item["RoundID"]),
                             TotalBetBlack = Convert.ToDouble(item["TotalBetBlack"]),
                             TotalBetWhite = Convert.ToDouble(item["TotalBetWhite"]),
                             Winner = Convert.ToString(item["Winner"]),
                             TrackingID = Guid.Parse(item["TrackingID"]),
                             OnGoingTrackingID = Guid.Parse(item["OnGoingTrackingID"]),
                             WinnerLastUpdate = DateTime.Parse(item["WinnerLastUpdate"])
                         };
            var actual = from item in _resultGamePlayInfo
                         select new {
                            UserName = item.UserName,
                            RoundID = item.RoundID,
                            TotalBetBlack = item.TotalBetBlack,
                            TotalBetWhite = item.TotalBetWhite,
                            Winner = item.Winner,
                            TrackingID = item.TrackingID,
                            OnGoingTrackingID = item.OnGoingTrackingID,
                            WinnerLastUpdate = item.WinnerLastUpdate
                         };

            CollectionAssert.AreEqual(expect.ToArray(), actual.ToArray(),"Game play information");
        }

        [Then(@"The game play information should be throw exception")]
        public void ThenTheGamePlayInformationShouldBeThrowException()
        {
            Assert.IsTrue(true, "Exception has been verified in the end of block When.");
            
        }
    }
}
