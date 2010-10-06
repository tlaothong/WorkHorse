using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using ColorsGame.ColorsGameSvc;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColorsGame.Specs.Steps
{
    [Binding]
    public class GetWinnerStep : GetWinnerStepsBase
    {
        private string _trackingID;
        [Given(@"Back server have game play information are:")]
        public void GivenBackServerHaveGamePlayInformationAre(Table table)
        {
            var gameInformation = from c in table.Rows
                           select new GamePlayInformation {
                               TableID = int.Parse(c["TableID"]),
                               RoundID = int.Parse(c["RoundID"]),
                               TrackingID = Guid.Parse(c["TrackingID"])
                           };

            Func<int, int, string> getGameInformation = (tableID, roundID) => {
                const int MinusValue = -1;
                if (tableID <= MinusValue || roundID <= MinusValue) return null;
                if (gameInformation.Any(c => c.TableID.Equals(tableID) && c.RoundID.Equals(roundID)))
                    return gameInformation.FirstOrDefault(c => c.TableID.Equals(tableID) && c.RoundID.Equals(roundID)).TrackingID.ToString();
                else return null;
            };

            Expect.Call(Dac.PayForWinnerInformation(0, 0))
                .IgnoreArguments().Do(getGameInformation);

        }

        [When(@"I press GetWinner\( TableID: (.*), RoundID: (.*) \)")]
        public void WhenIPressGetWinnerTableIDRoundID(int tableID, int roundID)
        {
            _trackingID = Dac.PayForWinnerInformation(tableID, roundID);
        }

        [Then(@"the result should be TrackingID: (.*)")]
        public void ThenTheResultShouldBeTrackingID(string trackingID)
        {
            var expect = Guid.Parse(trackingID).ToString();
            Assert.AreEqual(expect, _trackingID, "TrackingID");
        }

        [Then(@"Get null and skip checking trackingID")]
        public void ThenGetNullAndSkipCheckingTrackingID()
        {
            Assert.IsNull(_trackingID,"Don't have game TableID or RoundID.");
        }
    }
}
