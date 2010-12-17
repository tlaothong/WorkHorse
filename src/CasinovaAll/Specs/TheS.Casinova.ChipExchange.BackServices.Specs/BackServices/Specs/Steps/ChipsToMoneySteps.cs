using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.ChipExchange.Models;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.ChipExchange.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace TheS.Casinova.ChipExchange.BackServices.Specs.Steps
{
    [Binding]
    public class ChipsToMoneySteps
        : ChipExchangeStepsBase
    {
        private IEnumerable<ExchangeSettingInformation> _exchangeSettingInfos;
        private ExchangeSettingInformation _exchangeSettingInfo;
        private IEnumerable<UserProfile> _userProfiles;
        private UserProfile _userProfile;

        [Given(@"\(ChipsToMoney\)server has exchange setting information as:")]
        public void GivenChipsToMoneyServerHasExchangeSettingInformationAs(Table table)
        {
            _exchangeSettingInfos = (from item in table.Rows
                                     select new ExchangeSettingInformation {
                                         Name = item["Name"],
                                         MinChipToMoneyExchange = Convert.ToDouble(item["MinChipToMoneyExchange"]),
                                         MinMoneyToChipExchange = Convert.ToDouble(item["MinMoneyToChipExchange"]),
                                         MoneyToChipRate = Convert.ToDouble(item["MoneyToChipRate"]),
                                         MoneyToBonusChipRate = Convert.ToDouble(item["MoneyToBonusChipRate"]),
                                         ChipToBonusChipRate = Convert.ToDouble(item["ChipToBonusChipRate"]),
                                         VoucherToBonusChipRate = Convert.ToDouble(item["VoucherToBonusChipRate"]),
                                     });
        }

        [Given(@"\(ChipsToMoney\)server has player information as:")]
        public void GivenChipsToMoneyServerHasPlayerInformationAs(Table table)
        {
            _userProfiles = (from item in table.Rows
                             select new UserProfile {
                                 UserName = item["UserName"],
                                 Refundable = Convert.ToDouble(item["Refundable"]),
                                 NonRefundable = Convert.ToDouble(item["NonRefundable"]),
                             });
        }

        [Given(@"\(ChipsToMoney\)player balance information should be update\(UserName: '(.*)', chips: '(.*)', bonus chips: '(.*)'\)")]
        public void GivenChipsToMoneyPlayerBalanceInformationShouldBeUpdateUserNameXChipsXBonusChipsX(string userName, double chips, double bonusChips)
        {
            Action<UserProfile, UpdateUserProfileCommand> checkData = (userProfile, cmd) => {
                Assert.AreEqual(userName, userProfile.UserName, "UserName");
                Assert.AreEqual(chips, userProfile.Refundable, "Chips");
                Assert.AreEqual(bonusChips, userProfile.NonRefundable, "Bonus Chips");
            };

            Dac_UpdateUserProfile.ApplyAction(new UserProfile(), new UpdateUserProfileCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [Given(@"\(ChipsToMoney\)sent UserName: '(.*)' the player profile information should recieved")]
        public void GivenChipsToMoneySentUserNameXThePlayerProfileInformationShouldRecieved(string userName)
        {
            _userProfile = (from item in _userProfiles
                            where item.UserName == userName
                            select item).FirstOrDefault();

            SetupResult.For(Dqr_GetUserProfile.Get(new ChipExchange.Commands.GetUserProfileCommand()))
                .IgnoreArguments().Return(_userProfile);
        }

        [Given(@"Cheque information should be create\(UserName: 'OhAe', Address: '12 Road Srijun SubDistrict Naimueng District MuengKhonKaen 40000', Amount: '500'\)")]
        public void GivenChequeInformationShouldBeCreateUserNameOhAeAddress12RoadSrijunSubDistrictNaimuengDistrictMuengKhonKaen40000Amount500()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"call ChipsToMoneyExecutor\(UsserName: 'OhAe', Address: '12 Road Srijun SubDistrict Naimueng District MuengKhonKaen 40000', Amount: '500'\)")]
        public void WhenCallChipsToMoneyExecutorUsserNameOhAeAddress12RoadSrijunSubDistrictNaimuengDistrictMuengKhonKaen40000Amount500()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the player profile should be update and cheque information should be create")]
        public void ThenThePlayerProfileShouldBeUpdateAndChequeInformationShouldBeCreate()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
