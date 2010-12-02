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
using PerfEx.Infrastructure.Validation;

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

        [Given(@"player balance information should be update\(UserName: '(.*)', chips: '(.*)', bonus chips: '(.*)'\)")]
        public void GivenPlayerBalanceInformationShouldBeUpdateUserNameXChipsXBonusChipsX(string userName, double chips, double bonusChips)
        {
            Action<UserProfile, PayVoucherCommand> checkData = (userProfile, cmd) => {
                Assert.AreEqual(userName, userProfile.UserName, "UserName");
                Assert.AreEqual(chips, userProfile.Refundable, "Chips");
                Assert.AreEqual(bonusChips, userProfile.NonRefundable, "Bonus Chips");
            };

            Dac_UpdateUserProfile.ApplyAction(new UserProfile(), new UpdateUserProfileCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [Given(@"voucher code should be generate new code\(VoucherCode: '(.*)'\)")]
        public void GivenVoucherCodeShouldBeGenerateNewCodeVoucherCodeX(string voucherCode)
        {
            SetupResult.For(Svc_GenerateVoucherCode.GenerateVoucherCode())
                .IgnoreArguments().Return(voucherCode);
        }

        [Given(@"voucher information should be create\(VoucherCode: '(.*)', Amount: '(.*)', UserName: '(.*)'\)")]
        public void GivenVoucherInformationShouldBeCreateVoucherCodeXAmountXUserNameX(string voucherCode, double amount, string userName)
        {
            Func<VoucherInformation, PayVoucherCommand, VoucherInformation> checkData = (voucherInfo, cmd) => {
                Assert.AreEqual(voucherCode, voucherInfo.VoucherCode, "VoucherCode");
                Assert.AreEqual(userName, voucherInfo.UserName, "UserName");
                Assert.AreEqual(amount, voucherInfo.Amount, "Amount");
                return voucherInfo;
            };

            Dac_CreateVoucherInfo.Create(new Models.VoucherInformation(), new PayVoucherCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [When(@"call PayVoucherExecutor\(UsserName: '(.*)', Amount: '(.*)'\)")]
        public void WhenCallPayVoucherExecutorUsserNameXAmountX(string userName, double amount)
        {
            PayVoucherCommand cmd = new PayVoucherCommand {
                VoucherInformation = new VoucherInformation {
                    UserName = userName,
                    Amount = amount
                }
            };
            PayVoucherExecutor.Execute(cmd, (x) => { });
        }

        [When(@"Expected exception and call PayVoucherExecutor\(UsserName: '(.*)', Amount: '(.*)'\)")]
        public void WhenExpectedExceptionAndCallPayVoucherExecutorUsserNameXAmountX(string userName, double amount)
        {
            try {
                PayVoucherCommand cmd = new PayVoucherCommand {
                    VoucherInformation = new VoucherInformation {
                        UserName = userName,
                        Amount = amount
                    }
                };
                PayVoucherExecutor.Execute(cmd, (x) => { });
                Assert.Fail("Shouldn't be here!");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex, typeof(ValidationErrorException));
            }
        }

        [Then(@"the player profile should be update and voucher information should be create")]
        public void ThenThePlayerProfileShouldBeUpdateAndVoucherInformationShouldBeCreate()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
    }
}
