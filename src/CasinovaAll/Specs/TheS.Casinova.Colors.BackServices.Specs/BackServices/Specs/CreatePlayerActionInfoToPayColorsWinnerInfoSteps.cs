using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TheS.Casinova.Colors.BackServices.Specs
{
    [Binding]
    public class CreatePlayerActionInfoToPayColorsWinnerInfoSteps : ColorsGameStepsBase
    {
        [Given(@"Expect result should be add PlayerActionInfo\(RoundID: '(.*)', UserName: '(.*)', ActionType: '(.*)', Amount: '(.*)'\)")]
        public void GivenExpectResultShouldBeAddPlayerActionInfoRoundIDXUserNameXActionTypeXAmountX(int roundID, string userName, string actionType, double amount)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"call CreatePlayerActionInfo\(PlayerActionInfo\(RoundID: '(.*)', UserName: '(.*)', ActionType: '(.*)', Amount: '(.*)'\)\)")]
        public void WhenCallCreatePlayerActionInfoPlayerActionInfoRoundID13UserNameOhAeActionTypeGetWinnerAmount5(int roundID, string userName, string actionType, double amount)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the PlayerActionInfo should be saved to the ICreatePlayerActionInfo\.Create\(PlayerActionInfo, PayForColorsWinnerInfoCommand\) with expected data")]
        public void ThenThePlayerActionInfoShouldBeSavedToTheICreatePlayerActionInfo_CreatePlayerActionInfoPayForColorsWinnerInfoCommandWithExpectedData()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
