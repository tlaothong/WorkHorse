using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TheS.Casinova.ChipExchange.WebExecutors.Specs.Steps
{
    [Binding]
    public class GetVoucherCodeSteps
    {
        [Given(@"Server has voucher information for get voucher code :")]
        public void GivenServerHasVoucherInformationForGetVoucherCode(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call GetVoucherCodeExecutor \(UserName '(.*)'\)")]
        public void WhenCallGetVoucherCodeExecutorUserNameBoy(string userName)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The result should be Username'Boy' VoucherCode '6690A' Amount '500' Active 'True'")]
        public void ThenTheResultShouldBeUsernameBoyVoucherCode6690AAmount500ActiveTrue()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The result should be null \#GetVoucherCode")]
        public void ThenTheResultShouldBeNullGetVoucherCode()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
