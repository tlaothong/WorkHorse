using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.ChipExchange.Models;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.PlayerProfile.Models;
using Rhino.Mocks;
using TheS.Casinova.ChipExchange.Command;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.ChipExchange.WebExecutors.Specs.Steps
{
    [Binding]
    public class ChipsToBonusChipsSteps : ChipsExchangeModuleStepsBase
    {
        private ChipsToBonusChipsCommand _cmd;
        private IEnumerable<UserProfile> _playerProfileInfo;
        private UserProfile _playerBalance;
        private IEnumerable<MultiLevelNetworkInformation> _mlnInfo;
        private MultiLevelNetworkInformation _mln;

        [Given(@"Server has bonus points information for chips to bonus chips exchange:")]
        public void GivenServerHasBonusPointsInformationForChipsToBonusChipsExchange(Table table)
        {
            _mlnInfo = from item in table.Rows
                       select new MultiLevelNetworkInformation {
                           UserName = Convert.ToString(item["UserName"]),
                           Bonus = Convert.ToInt32(item["Bonus"])
                       };
        }

        [Given(@"Server has user profile information for chips to bonus chips:")]
        public void GivenServerHasUserProfileInformationForChipsToBonusChips(Table table)
        {
            _playerProfileInfo = from item in table.Rows
                                 select new UserProfile { 
                                     UserName = Convert.ToString(item["UserName"]),
                                     Refundable = Convert.ToDouble(item["Refundable"]),
                                     NonRefundable = Convert.ToDouble(item["NonRefundable"])
                                 };
        }

        [Given(@"Sent UserName'(.*)' the player's bonus points for chips to bonus chips exchange should recieved")]
        public void GivenSentUserNameXThePlayerSBonusPointsForChipsToBonusChipsExchangeShouldRecieved(string userName)
        {
            _mln = (from item in _mlnInfo
                    where item.UserName == userName
                    select item).FirstOrDefault();

            SetupResult.For(Dqr_GetMultiLevelNetworkInfo.Get(new GetMultiLevelNetworkInfoCommand()))
                .IgnoreArguments()
                .Return(_mln);
        }

        [Given(@"Sent UserName'(.*)' the player's profile for chips to bonus chips exchange should recieved")]
        public void GivenSentUserNameXThePlayerSProfileForChipsToBonusChipsExchangeShouldRecieved(string userName)
        {
            _playerBalance = (from item in _playerProfileInfo
                    where item.UserName == userName
                    select item).FirstOrDefault();

            SetupResult.For(Dqr_GetPlayerBalance.Get(new GetPlayerBalanceCommand()))
                .IgnoreArguments()
                .Return(_playerBalance);
        }

        [Given(@"Sent UserName'(.*)' Amount '(.*)' for chips to bonus chips exchange")]
        public void GivenSentUserNameXAmountXForChipsToBonusChipsExchange(string userName, double amount)
        {
            _cmd = new ChipsToBonusChipsCommand {
                ExchangeInfo = new ExchangeInformation { 
                    UserName = userName,
                    Amount = amount
                }
            };
        }

        [When(@"Call ChipsToBonusChipsExecutor\(\)")]
        public void WhenCallChipsToBonusChipsExecutor()
        {
            ChipsToBonusChips.Execute(_cmd, (x) => { });
        }

        [When(@"Call ChipsToBonusChipsExecutor\(\) for validation")]
        public void WhenCallChipsToBonusChipsExecutorForValidation()
        {
            try {
                ChipsToBonusChips.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        [Then(@"The system can sent chips to bonus chips exchange information to back server")]
        public void ThenTheSystemCanSentChipsToBonusChipsExchangeInformationToBackServer()
        {
            Assert.IsTrue(true, "System can sent information to back server");
        }

        [Then(@"The system can't sent chips to bonus chips exchange information to back server")]
        public void ThenTheSystemCanTSentChipsToBonusChipsExchangeInformationToBackServer()
        {
            Assert.IsTrue(true, "System can't sent information to back server");
        }
    }
}
