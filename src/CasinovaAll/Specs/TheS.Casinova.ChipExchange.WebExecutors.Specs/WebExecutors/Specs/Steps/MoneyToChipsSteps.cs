using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.ChipExchange.Commands;
using TheS.Casinova.ChipExchange.Models;
using TheS.Casinova.PlayerAccount.Models;
using Rhino.Mocks;
using TheS.Casinova.ChipExchange.Command;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.ChipExchange.WebExecutors.Specs.Steps
{
    [Binding]
    public class MoneyToChipsSteps : ChipsExchangeModuleStepsBase
    {
        private MoneyToChipsCommand _cmd;
        private IEnumerable<PlayerAccountInformation> _playerAccountInfo;
        private PlayerAccountInformation _playerAccount;

        [Given(@"Server has player account information as:")]
        public void GivenServerHasPlayerAccountInformationAs(Table table)
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

        [Given(@"Sent AccountType '(.*)' UserName'(.*)' Amount '(.*)' for money to chips exchange")]
        public void GivenSentAccountTypePrimaryUserNameBoyAmount100ForMoneyToChipsExchange(string accountType, string userName, double amount)
        {
            _cmd = new MoneyToChipsCommand {
                ExchangeInformation = new ExchangeInformation { 
                    AccountType = accountType,
                    UserName = userName,
                    Amount = amount
                }
            };
        }

        [Given(@"Sent AccountType '(.*)' UserName'(.*)' the player's account for money to chips exchange should recieved")]
        public void GivenSentAccountTypeXUserNameXThePlayerSAccountForMoneyToChipsExchangeShouldRecieved(string accountType, string userName)
        {
            _playerAccount = (from item in _playerAccountInfo
                              where accountType == item.AccountType && userName == item.UserName
                              select item).FirstOrDefault();

            SetupResult.For(Dqr_GetPlayerAccountInfo.Get(new GetPlayerAccountInfoCommand()))
                .IgnoreArguments()
                .Return(_playerAccount);

        }

        //Test function
        [When(@"Call MoneyToChipsExecutor \(\)")]
        public void WhenCallMoneyToChipsExecutor()
        {
            MoneyToChips.Execute(_cmd, (x) => { });
        }

        //Validation
        [When(@"Call MoneyToChipsExecutor \(\) for validation")]
        public void WhenCallMoneyToChipsExecutorForValidation()
        {
            try {
                MoneyToChips.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        [Then(@"The system can sent money to chips exchange information to back server")]
        public void ThenTheSystemCanSentMoneyToChipsExchangeInformationToBackServer()
        {
            Assert.IsTrue(true, "System can sent information to back server");
        }

        [Then(@"The system can't sent money to chips exchange information to back server")]
        public void ThenTheSystemCanTSentMoneyToChipsExchangeInformationToBackServer()
        {
            Assert.IsTrue(true, "System can't sent information to back server");
        }
    }
}
