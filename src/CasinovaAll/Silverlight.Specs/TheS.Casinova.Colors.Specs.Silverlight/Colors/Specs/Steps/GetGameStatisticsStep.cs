using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TheS.Casinova.Colors.Specs.Steps
{
    [Binding]
    public class GetGameStatisticsStep
    {
        #region Background
        
        [Given(@"Web server have game results are")]
        public void GivenWebServerHaveGameResultsAre(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        #endregion Background

        [When(@"Request GetGameResult\( roundID = '(.*)' \)")]
        public void WhenRequestGetGameResultRoundID1(int roundID)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Game has display game result roundID='(.*)', Winner='(.*)', BlackPot='(.*)', WhitePot='(.*)', Hands='(.*)'")]
        public void ThenGameHasDisplayGameResultRoundID1WinnerBlackBlackPot1523WhitePot4526Hands452(int roundID,string winner,double blackPot,double whitePot,int handsCount)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
