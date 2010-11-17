using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SpecFlowAssist;
using TheS.Casinova.ColorsSvc;

namespace TheS.Casinova.Colors.Specs.Steps
{
    [Binding]
    public class GetListGamePlayInformation
    {
        #region Background

        [Given(@"Web server have game play information are")]
        public void GivenWebServerHaveGamePlayInformationAre(Table table)
        {
            ScenarioContext.Current.Set<IEnumerable<GamePlayInformation>>(
                table.CreateSet<GamePlayInformation>());
        }

        #endregion Background

        [When(@"Send request GetListGamePlayInformation\( '(.*)' \)")]
        public void WhenSendRequestGetListGamePlayInformation(string username)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"TrackingID and OnGoingTrackingID not match repeat request GetListGamePlayInformation until TrackingID and OnGoingTrackingID is match")]
        public void WhenTrackingIDAndOnGoingTrackingIDNotMatchRepeatRequestGetListGamePlayInformationUntilTrackingIDAndOnGoingTrackingIDIsMatch()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Tables in GamePlayViewModel display game play information are")]
        public void ThenTablesInGamePlayViewModelDisplayGamePlayInformationAre(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Display error message")]
        public void ThenDisplayErrorMessage()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
