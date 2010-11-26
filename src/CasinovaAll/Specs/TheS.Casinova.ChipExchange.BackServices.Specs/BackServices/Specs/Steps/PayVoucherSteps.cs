using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.PlayerProfile.Models;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.ChipExchange.Models;

namespace TheS.Casinova.ChipExchange.BackServices.Specs.Steps
{
    [Binding]
    public class PayVoucherSteps
        : ChipExchangeStepsBase
    {
        private IEnumerable<UserProfile> _userProfiles;
        private UserProfile _userProfile;

        [Given(@"\(PayVoucher\)server has player information as:")]
        public void GivenPayVoucherServerHasPlayerInformationAs(Table table)
        {
            _userProfiles = (from item in table.Rows
                             select new UserProfile {
                                 UserName = item["UserName"],
                                 Refundable = Convert.ToDouble(item["Refundable"]),
                                 NonRefundable = Convert.ToDouble(item["NonRefundable"]),
                             });
        }

        [Given(@"\(PayVoucher\)sent UserName: '(.*)' the player profile information should recieved")]
        public void GivenPayVoucherSentUserNameXThePlayerProfileInformationShouldRecieved(string userName)
        {
            _userProfile = (from item in _userProfiles
                            where item.UserName == userName
                            select item).FirstOrDefault();

            SetupResult.For(Dqr_GetUserProfile.Get(new ChipExchange.Commands.GetUserProfileCommand()))
                .IgnoreArguments().Return(_userProfile);
        }

        [Given(@"player balance\(chips, bonus chips\) should more than or equal request voucher\(Amount: '(.*)'\)")]
        public void GivenPlayerBalanceChipsBonusChipsShouldMoreThanOrEqualRequestVoucherAmountX(double amount)
        {
            Assert.IsTrue((_userProfile.NonRefundable + _userProfile.Refundable) >= amount, "Amount");
        }

        [Given(@"player balance\(bonus chips\) more than or equal request voucher\(Amount: '(.*)'\)")]
        public void GivenPlayerBalanceBonusChipsMoreThanOrEqualRequestVoucher(double amount)
        {
            Assert.IsTrue((_userProfile.NonRefundable) >= amount, "Amount");
        }

        [Given(@"player balance information should be update\(UserName: '(.*)', chips: '(.*)', bonus chips: '(.*)'\)")]
        public void GivenPlayerBalanceInformationShouldBeUpdateUserNameXChipsXBonusChipsX(string userName, double chips, double bonusChips)
        {
            Action<UserProfile, PayVoucherCommand> checkData = (userProfile, cmd) => {
                Assert.AreEqual(userName, userProfile.UserName, "UserName");
                Assert.AreEqual(chips, userProfile.Refundable, "Chips");
                Assert.AreEqual(bonusChips, userProfile.NonRefundable, "Bonus Chips");
            };

            Dac_UpdateUserProfile.ApplyAction(new UserProfile(), new PayVoucherCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [Given(@"voucher code should be generate new code\(VoucherCode: '(.*)'\)")]
        public void GivenVoucherCodeShouldBeGenerateNewCodeVoucherCodeX(string voucherCode)
        {
            SetupResult.For(Svc_GenerateVoucherCode.GenerateVoucherCode())
                .IgnoreArguments().Return(voucherCode);
        }

        [Given(@"voucher information should be create\(VoucherCode: '(.*)', Amount: '(.*)', UserName: '(.*)', CanUse: '(.*)'\)")]
        public void GivenVoucherInformationShouldBeCreateVoucherCodeXAmountXUserNameXCanUseX(string voucherCode, double amount, string userName, bool canUse)
        {
            Func<VoucherInformation, PayVoucherCommand, VoucherInformation> checkData = (voucherInfo, cmd) => {
                Assert.AreEqual(voucherCode, voucherInfo.VoucherCode, "VoucherCode");
                Assert.AreEqual(userName, voucherInfo.UserName, "UserName");
                Assert.AreEqual(amount, voucherInfo.Amount, "Amount");
                Assert.AreEqual(canUse, voucherInfo.CanUse, "CanUse");
                return voucherInfo;
            };

            Dac_CreateVoucherInfo.Create(new Models.VoucherInformation(), new PayVoucherCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [When(@"call PayVoucherExecutor\(UserName: '(.*)', Amount: '(.*)'\)")]
        public void WhenCallPayVoucherExecutorUserNameXAmountX(string userName, double amount)
        {
            PayVoucherCommand cmd =new PayVoucherCommand{ UserName = userName, Amount = amount};
            PayVoucherExecutor.Execute(cmd, (x) => { });
        }

        [Then(@"the player profile should be update and voucher information should be create")]
        public void ThenThePlayerProfileShouldBeUpdateAndVoucherInformationShouldBeCreate()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
    }
}
