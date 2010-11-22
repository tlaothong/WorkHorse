using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.MagicNine.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.MagicNine.BackServices.Specs.Steps
{
    [Binding]
    public class StopAutoBetSteps
        : MagicNineStepsBase
    {
        [Given(@"the StopAutoBet shoule be call as: \(UserName: '(.*)', RoundID: '(.*)', BetTrackingID: '(.*)'\)")]
        public void GivenTheStopAutoBetShouleBeCallAsUserNameXRoundIDXTrackingIDX(string userName, int roundID, string trackingID)
        {
            Action<StopAutoBetCommand> checkData = (cmd) => {
                Assert.AreEqual(userName, cmd.UserName, "UserName");
                Assert.AreEqual(roundID, cmd.RoundID, "RoundID");
                Assert.AreEqual(Guid.Parse(trackingID), cmd.StopTrackingID, "BetTrackingID");
            };

            Svc_AutoBetEngine.StopAutoBet(new Commands.StopAutoBetCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [When(@"call StopAutoBetExecutor\(UserName: '(.*)', RoundID: '(.*)', BetTrackingID: '(.*)'\)")]
        public void WhenCallStopAutoBetExecutorUserNameXRoundIDXTrackingIDX(string userName, int roundID, string trackingID)
        {
            StopAutoBetCommand cmd = new StopAutoBetCommand {
                UserName = userName,
                RoundID = roundID,
                StopTrackingID = Guid.Parse(trackingID),
            };

            StopAutoBetExecutor.Execute(cmd, (x) => { });
        }

        [Then(@"server should call StopAutoBet")]
        public void ThenServerShouldCallStopAutoBet()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
    }
}
