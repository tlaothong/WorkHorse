using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.MagicNine.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheS.Casinova.MagicNine.Models;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.MagicNine.BackServices.Specs.Steps
{
    [Binding]
    public class StopAutoBetSteps
        : MagicNineStepsBase
    {
        private IEnumerable<GamePlayAutoBetInformation> _autoBetInfos;
        private GamePlayAutoBetInformation _expectAutoBetInfo;
        private GamePlayAutoBetInformation _autoBetInfo;

        [Given(@"\(StopAutoBet\)server has autobet information as:")]
        public void GivenStopAutoBetServerHasAutobetInformationAs(Table table)
        {
            var qry = (from item in table.Rows
                       select new {
                           UserName = item["UserName"],
                           Round = Convert.ToInt32(item["RoundID"]),
                           ThruDateTime = item["ThruDateTime"],
                       });

            List<GamePlayAutoBetInformation> list = new List<GamePlayAutoBetInformation>();

            foreach (var item in qry) {
                GamePlayAutoBetInformation it = new GamePlayAutoBetInformation {
                    UserName = item.UserName,
                    RoundID = item.Round,                    
                };

                if (item.ThruDateTime == "null") {
                    it.ThruDateTime = null;
                }
                else {
                    it.ThruDateTime = DateTime.Parse(item.ThruDateTime);
                }

                list.Add(it);
            }

            _autoBetInfos = list;
        }

        [Given(@"\(StopAutoBet\)sent name: '(.*)' roundID: '(.*)' the autobet information should recieved")]
        public void GivenStopAutoBetSentNameXRoundIDXTheAutobetInformationShouldRecieved(string userName, int roundID)
        {
            _expectAutoBetInfo = (from item in _autoBetInfos
                                  where item.UserName == userName && item.RoundID == roundID
                                  select item).FirstOrDefault();

            SetupResult.For(Dqr_GetAutoBetInfo.Get(new StopAutoBetCommand()))
                .IgnoreArguments().Return(_expectAutoBetInfo);

            _autoBetInfo = new GamePlayAutoBetInformation {
                UserName = _expectAutoBetInfo.UserName,
                RoundID = _expectAutoBetInfo.RoundID,
                StopTrackingID = _expectAutoBetInfo.StopTrackingID,
            };
        }

        [Given(@"\(StopAutoBet\)the autobet information should be update as\(UserName: '(.*)', RoundID: '(.*)', StopTrackingID: '(.*)'\)")]
        public void GivenStopAutoBetTheAutobetInformationShouldBeUpdateAsUserNameXRoundIDXStopTrackingIDX(string userName, int roundID, string stopTrackigID)
        {
            Action<GamePlayAutoBetInformation, StopAutoBetCommand> checkData = (autoBetInfo, cmd) => {
                Assert.AreEqual(roundID, autoBetInfo.RoundID, "RoundID");                
                Assert.AreEqual(userName, autoBetInfo.UserName, "UserName");
                Assert.AreEqual(Guid.Parse(stopTrackigID), autoBetInfo.StopTrackingID, "StopTrackingID");
            };

            Dac_UpdateAutoBetInfo.ApplyAction(new GamePlayAutoBetInformation(), new StopAutoBetCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [Given(@"the StopAutoBet shoule be call as: \(UserName: '(.*)', RoundID: '(.*)', StopTrackingID: '(.*)'\)")]
        public void GivenTheStopAutoBetShouleBeCallAsUserNameXRoundIDXStopTrackingIDX(string userName, int roundID, string stopTrackingID)
        {
            Action<GamePlayAutoBetInformation, StopAutoBetCommand> checkData = (autoBetInfo, cmd) => {
                Assert.AreEqual(userName, autoBetInfo.UserName, "UserName");
                Assert.AreEqual(roundID, autoBetInfo.RoundID, "RoundID");
                Assert.AreEqual(Guid.Parse(stopTrackingID), autoBetInfo.StopTrackingID, "StopTrackingID");
            };

            Svc_AutoBetEngine.StopAutoBet(new GamePlayAutoBetInformation(), new Commands.StopAutoBetCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [When(@"call StopAutoBetExecutor\(UserName: '(.*)', RoundID: '(.*)', StopTrackingID: '(.*)'\)")]
        public void WhenCallStopAutoBetExecutorUserNameXRoundIDXStopTrackingIDX(string userName, int roundID, string stopTrackingID)
        {
            StopAutoBetCommand cmd = new StopAutoBetCommand {
                GamePlayAutoBetInfo = new GamePlayAutoBetInformation {
                    UserName = userName,
                    RoundID = roundID,
                    StopTrackingID = Guid.Parse(stopTrackingID),
                },
            };

            StopAutoBetExecutor.Execute(cmd, (x) => { });
        }

        [When(@"Expected exeception and call StopAutoBetExecutor\(UserName: '(.*)', RoundID: '(.*)', StopTrackingID: '(.*)'\)")]
        public void WhenExpectedExeceptionAndCallStopAutoBetExecutorUserNameXRoundIDXStopTrackingIDX(string userName, int roundID, string stopTrackingID)
        {
            try {
                StopAutoBetCommand cmd = new StopAutoBetCommand {
                    GamePlayAutoBetInfo = new GamePlayAutoBetInformation {
                        UserName = userName,
                        RoundID = roundID,
                        StopTrackingID = Guid.Parse(stopTrackingID),
                    },
                };

                StopAutoBetExecutor.Execute(cmd, (x) => { });
                Assert.Fail("Shouldn't be here!");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex, typeof(ValidationErrorException));
            }
        }

        [Then(@"server should call StopAutoBet")]
        public void ThenServerShouldCallStopAutoBet()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
    }
}
