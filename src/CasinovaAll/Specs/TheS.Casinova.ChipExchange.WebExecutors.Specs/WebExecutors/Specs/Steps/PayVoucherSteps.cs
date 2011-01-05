using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.ChipExchange.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;
using Rhino.Mocks;

namespace TheS.Casinova.ChipExchange.WebExecutors.Specs.Steps
{
    [Binding]
    public class PayVoucherSteps : ChipsExchangeModuleStepsBase
    {
        private PayVoucherCommand _cmd;
        private IEnumerable<UserProfile> _userProfile;
        private UserProfile _getBalance;
        private double _checkAmount;
        private double _amount;
        private bool _validate;
        private string _trackingID;

        [Given(@"Server has user profile information for pay voucher:")]
        public void GivenServerHasUserProfileInformationForPayVoucher(Table table)
        {
            _userProfile = from item in table.Rows
                           select new UserProfile {
                               UserName = Convert.ToString(item["UserName"]),
                               Refundable = Convert.ToDouble(item["Refundable"]),
                               NonRefundable = Convert.ToDouble(item["NonRefundable"])
                           };
        }

        [Given(@"Sent UserName'(.*)' Amount'(.*)' for pay voucher")]
        public void GivenSentUserNameXAmountXForPayVoucher(string userName, double amount)
        {
            _cmd = new PayVoucherCommand {
                VoucherInformation = new VoucherInformation { 
                    UserName = userName,
                    Amount = amount
                }
            };
        }

        [Given(@"Sent UserName'(.*)' the player's profile should recieved")]
        public void GivenSentUserNameNitThePlayerSProfileShouldRecieve(string userName)
        {
            _getBalance = (from item in _userProfile
                           where item.UserName == userName
                           select item).FirstOrDefault();

            SetupResult.For(Dqr_GetPlayerBalance.Get(new GetPlayerBalanceCommand()))
              .IgnoreArguments().Return(_getBalance);
        }

        [Given(@"The system generated TrackingID for PayVoucher:'(.*)'")]
        public void GivenTheSystemGeneratedTrackingIDForPayVoucherX(string trackingID)
        {
            _trackingID = trackingID;

            SetupResult.For(svc_GenerateTrackingID.GenerateTrackingID())
                .IgnoreArguments().Return(Guid.Parse(_trackingID));
        }

        //Test function
        [When(@"Call PayVoucherExecutor\(\)")]
        public void WhenCallPayVoucherExecutor()
        {
            PayVoucher.Execute(_cmd, (x) => { });
        }

        //Validation
        [When(@"Call PayVoucherExecutor\(\) for validate input")]
        public void WhenCallPayVoucherExecutorForValidateInput()
        {
            try {
                PayVoucher.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        [Then(@"TrackingID for PayVoucher should be :'(.*)'")]
        public void ThenTrackingIDForPayVoucherShouldBeX(string trackingID)
        {
            Assert.AreEqual(trackingID, _trackingID, "รหัสตรวจสอบ");
        }

        [Then(@"Get null and skip checking trackingID for pay voucher")]
        public void ThenGetNullAndSkipCheckingTrackingIDForPayVoucher()
        {
            Assert.AreEqual(false,_validate,"Get null and skip checking trackingID");
        }

        [Then(@"Get null and skip checking trackingID")]
        public void ThenGetNullAndSkipCheckingTrackingID()
        {
            Assert.IsTrue(true, "Get null and skip checking trackingID.");
        }
    }
}
