using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TheS.Casinova.ChipExchange.WebExecutors.Specs.Steps
{
    [Binding]
    public class VoucherToBonusChipsSteps
    {
        [Given(@"Server has voucher information for voucher to bonus chips :")]
        public void GivenServerHasVoucherInformationForVoucherToBonusChips(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Sent UserName'(.*)' VoucherCode '(.*)' the player's voucher information should recieved")]
        public void GivenSentUserNameNitVoucherCode0A15D2C519764BF4B698E31B9F77FE90ThePlayerSVoucherInformationShouldRecieve(string userName, string voucherCode)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Sent UserName'(.*)' VoucherCode '(.*)' the player's voucher information should not recieved")]
        public void GivenSentUserNameAeVoucherCodeDA60FEA34A9D42299B8C066EDC141DC5ThePlayerSVoucherInformationShouldNotRecieve(string userName, string voucherCode)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call VoucherToBonusChipsExecutor \(UserName'(.*)' VoucherCode '(.*)'\)")]
        public void WhenCallVoucherToBonusChipsExecutorUserNameNitVoucherCode0A15D2C519764BF4B698E31B9F77FE90(string userName, string voucherCode)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The system can sent information to back server \#VoucherToBonusChips")]
        public void ThenTheSystemCanSentInformationToBackServerVoucherToBonusChips()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The system can't sent information to back server \#VoucherToBonusChips")]
        public void ThenTheSystemCanTSentInformationToBackServerVoucherToBonusChips()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
