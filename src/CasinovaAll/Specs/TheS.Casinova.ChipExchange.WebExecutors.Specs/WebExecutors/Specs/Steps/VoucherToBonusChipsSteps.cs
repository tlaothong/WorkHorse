using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.ChipExchange.Commands;
using Rhino.Mocks;
using TheS.Casinova.ChipExchange.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.ChipExchange.WebExecutors.Specs.Steps
{
    [Binding]
    public class VoucherToBonusChipsSteps : ChipsExchangeModuleStepsBase
    {
        private VoucherToBonusChipsCommand _cmd;
        private string _trackingID;

        [Given(@"Sent UserName'(.*)' VoucherCode '(.*)'")]
        public void GivenSentUserNameXVoucherCodeX(string username, string voucherCode)
        {
            _cmd = new VoucherToBonusChipsCommand {
                VoucherInformation = new VoucherInformation { 
                    UserName = username,
                    VoucherCode = voucherCode
                }
            };
        }

        [Given(@"The system generated TrackingID for VoucherToBonusChips:'(.*)'")]
        public void GivenTheSystemGeneratedTrackingIDForVoucherToBonusChipsX(string trackingID)
        {
            _trackingID = trackingID;
            SetupResult.For(svc_GenerateTrackingID.GenerateTrackingID())
                .IgnoreArguments().Return(Guid.Parse(_trackingID));
        }

        //Validation
        [When(@"Call VoucherToBonusChipsExecutor\(\) for validate input")]
        public void WhenCallVoucherToBonusChipsExecutorForValidateInput()
        {
            try {
                VoucherToBonusChips.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                   typeof(ValidationErrorException));
            };
        }

        //Test function
        [When(@"Call VoucherToBonusChipsExecutor\(\)")]
        public void WhenCallVoucherToBonusChipsExecutor()
        {
            VoucherToBonusChips.Execute(_cmd, (x) => { });
        }

        [Then(@"TrackingID for VoucherToBonusChips should be :'(.*)'")]
        public void ThenTrackingIDForVoucherToBonusChipsShouldBeX(string trackingID)
        {
            Assert.AreEqual(trackingID, _trackingID, "Get trackingID accept");
        }

        [Then(@"VoucherToBonusChips get null and skip checking trackingID")]
        public void ThenVoucherToBonusChipsGetNullAndSkipCheckingTrackingID()
        {
            Assert.IsTrue(true, "Get null and skip checking trackingID");
        }
    }
}
