using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using ColorsGame.ColorsGameSvc;
using Rhino.Mocks;

namespace ColorsGame.Specs.Steps
{
    [Binding]
    public class GetWinnerStep : GetWinnerStepsBase
    {
        [Given(@"Back server have game play information are:")]
        public void GivenBackServerHaveGamePlayInformationAre(Table table)
        {
            var gameInfo = from c in table.Rows
                           select new GamePlayInformation {
                               TableID = int.Parse(c["TableID"]),
                               RoundID = int.Parse(c["RoundID"]),
                               UserName = c["UserName"],
                               TrackingID = Guid.Parse(c["TrackingID"]),
                               OnGoingTrackingID = Guid.Parse(c["OnGoingTrackingID"]),
                               LastUpdate = DateTime.Parse(c["LastUpdate"]),
                           };
            
            //SetupResult.For(Dac.PayForWinnerInformationAsync(7, 11)).Return(
            //    gameInfo.FirstOrDefault(c=>c.TableID.Equals(7)&&c.RoundID.Equals
            //    );
        }

        [Given(@"Server respond TrackingID: (.*)")]
        public void GivenServerRespondTrackingID(string trackingID)
        {

        }

        [When(@"I press GetWinner\( TableID: (.*), RoundID: (.*) \)")]
        public void WhenIPressGetWinnerTableID9RoundID11(int tableID,int roundID)
        {
            
        }

        [Then(@"the result should be TrackingID: (.*)")]
        public void ThenTheResultShouldBeTrackingID(string trackingID)
        {
            
        }
    }
}
