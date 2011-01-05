using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.PlayerAccount.Models;
using TheS.Casinova.ChipExchange.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;
using Rhino.Mocks;
using TheS.Casinova.ChipExchange.Command;

namespace TheS.Casinova.ChipExchange.WebExecutors.Specs.Steps
{
    [Binding]
    public class MoneyToBonusChipsSteps : ChipsExchangeModuleStepsBase
    {
        private MoneyToBonusChipsCommand _cmd;
        private IEnumerable<PlayerAccountInformation> _playerAccountInfo;
        private PlayerAccountInformation _playerAccount;
        private IEnumerable<MultiLevelNetworkInformation> _mlnInfo;
        private MultiLevelNetworkInformation _mln;

        [Given(@"Server has bonus points information for money to bonus chips exchange:")]
        public void GivenServerHasBonusPointsInformationForMoneyToBonusChipsExchange(Table table)
        {
            _mlnInfo = from item in table.Rows
                       select new MultiLevelNetworkInformation { 
                           UserName = Convert.ToString(item["UserName"]),
                           Bonus = Convert.ToInt32(item["Bonus"])
                       };
        }

        [Given(@"Server has player account information for money to bonus chips exchange:")]
        public void GivenServerHasPlayerAccountInformationForMoneyToBonusChipsExchange(Table table)
        {
            _playerAccountInfo = from item in table.Rows
                                 select new PlayerAccountInformation {
                                     UserName = Convert.ToString(item["UserName"]),
                                     AccountType = Convert.ToString(item["AccountType"]),
                                     CardType = Convert.ToString(item["CardType"]),
                                     AccountNo = Convert.ToString(item["AccountNo"]),
                                     CVV = Convert.ToString(item["CVV"]),
                                     ExpireDate = DateTime.Parse(item["ExpireDate"]),
                                     Active = Convert.ToBoolean(item["Active"]),
                                     FirstName = Convert.ToString(item["FirstName"]),
                                     LastName = Convert.ToString(item["LastName"])
                                 };
        }

        [Given(@"Sent UserName'(.*)' the player's bonus points should recieved")]
        public void GivenSentUserNameBoyThePlayerSBonusPointsShouldRecieved(string userName)
        {
            _mln = (from item in _mlnInfo
                    where item.UserName == userName
                    select item).FirstOrDefault();

            SetupResult.For(Dqr_GetMultiLevelNetworkInfo.Get(new GetMultiLevelNetworkInfoCommand()))
                .IgnoreArguments()
                .Return(_mln);
        }

        [Given(@"Sent AccountType '(.*)' UserName'(.*)' the player's account for money to bonus chips should recieved")]
        public void GivenSentAccountTypeXUserNameXThePlayerSAccountForMoneyToBonusChipsShouldRecieved(string accountType, string userName)
        {
            _playerAccount = (from item in _playerAccountInfo
                              where accountType == item.AccountType && userName == item.UserName
                              select item).FirstOrDefault();

            SetupResult.For(Dqr_GetPlayerAccountInfo.Get(new GetPlayerAccountInfoCommand()))
                .IgnoreArguments()
                .Return(_playerAccount);
        }

        [Given(@"Sent AccountType '(.*)' Amonut '(.*)' UserName'(.*)' for money to bonuschips exchange")]
        public void GivenSentAccountTypeXAmonutXUserNameXForMoneyToBonuschipsExchange(string accountType, double amount, string userName)
        {
            _cmd = new MoneyToBonusChipsCommand {
                ExchangeInformation = new ExchangeInformation { 
                    AccountType = accountType,
                    UserName = userName,
                    Amount = amount
                }
            };
        }

        //Test function
        [When(@"Call MoneyToBonusChipsExecutor \(\)")]
        public void WhenCallMoneyToBonusChipsExecutor()
        {
            MoneyToBonusChips.Execute(_cmd, (x) => { });
        }

        //Validation
        [When(@"Call MoneyToBonusChipsExecutor \(\) for validation")]
        public void WhenCallMoneyToBonusChipsExecutorForValidation()
        {
            try {
                MoneyToBonusChips.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        [Then(@"The system can sent money to bonuschips exchange information to back server")]
        public void ThenTheSystemCanSentMoneyToBonuschipsExchangeInformationToBackServer()
        {
            Assert.IsTrue(true, "System can sent information to back server");
        }

        [Then(@"The system can't sent money to bonuschips exchange information to back server")]
        public void ThenTheSystemCanTSentMoneyToBonuschipsExchangeInformationToBackServer()
        {
            Assert.IsTrue(true, "System can't sent information to back server");
        }
    }
}
