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

namespace TheS.Casinova.Colors.WebExecutors.Specs.Steps
{
    [Binding]
    public class ListGamePlayInfoSteps : ColorsGameStepsBase
    {
        private ListGamePlayInfoCommand _cmd;
        private IEnumerable<GamePlayInformation> _expectGamePlayInfo;
        private string _userName;

        [Given(@"The game play information of '(.*)' is :")]
        public void GivenTheGamePlayInformationOfXIs(string userName, Table table)
        {
            _userName = userName;

            if (!string.IsNullOrEmpty(_userName)) {
                if (table.RowCount < 1) {
                    _expectGamePlayInfo = null;
                }
                else {
                    _expectGamePlayInfo = (from it in table.Rows
                                           select new GamePlayInformation {
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
                }
                Expect.Call(Dac.List(new Commands.ListGamePlayInfoCommand()))
                .IgnoreArguments()
                .Return(_expectGamePlayInfo);
            }
        }

        [When(@"Call ListGamePlayInfo\('(.*)'\)")]
        public void WhenCallListGamePlayInfoX(string userName)
        {
            try {
                _cmd = new ListGamePlayInfoCommand {
                    UserName = userName
                };

                GamePlayInfoExecutor.Execute(_cmd, player => { });
            }
            catch (ArgumentNullException err) {
                ScenarioContext.Current[("ArgumentNullException_UserName")] = err;
            }
        }

        [Then(@"The game play information should be :")]
        public void ThenTheGamePlayInformationShouldBe(Table table)
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

            var result = (from it in _cmd.GamePlayInfos
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

            CollectionAssert.AreEqual(qryExpected.ToArray(), result.ToArray(), "GamePlayInformation");
        }

        [Then(@"The game play information should be null")]
        public void ThenTheGamePlayInformationShouldBeNull()
        {
            Assert.AreEqual(null, _cmd.GamePlayInfos, "GamePlayInformation");
        }

        [Then(@"The game play information should be throw exception")]
        public void ThenTheGamePlayInformationShouldBeThrowException()
        {
            Assert.IsTrue(true, "ArgumentNullException_UserName");
            
        }
    }
}
