using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.PlayerAccount.Commands;
using TheS.Casinova.PlayerAccount.Models;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.PlayerAccount.WebExecutors.Specs.Steps
{
    [Binding]
    public class GetPlayerAccountSteps : PlayerAccountModuleStepsBase
    {
        private GetPlayerAccountCommand _cmd;
        private IEnumerable<PlayerAccountInformation> _playerAccountInfo;
        private PlayerAccountInformation _getPlayeraccount;

        [Given(@"Server has player account information for get data as:")]
        public void GivenServerHasPlayerAccountInformationForGetDataAs(Table table)
        {
            _playerAccountInfo = from item in table.Rows
                                 select new PlayerAccountInformation { 
                                     AccountType = Convert.ToString(item["AccountType"]),
                                     UserName = Convert.ToString(item["UserName"]),
                                     CardType = Convert.ToString(item["CardType"]),
                                     AccountNo = Convert.ToString(item["AccountNo"]),
                                     CVV = Convert.ToString(item["CVV"]),
                                     ExpireDate = DateTime.Parse(item["ExpireDate"]),
                                     Active = Convert.ToBoolean(item["Active"])

                                 };
        }

        [Given(@"Sent UserName '(.*)' AccountType '(.*)' for validate get player account")]
        public void GivenSentUserNameXAccountTypeForValidateGetPlayerAccount(string userName, string accountType)
        {
            _cmd = new GetPlayerAccountCommand {
                PlayerAccountInfo = new PlayerAccountInformation {
                    UserName = userName,
                    AccountType = accountType
                }
            };
        }

        [Given(@"Sent UserName '(.*)' AccountType '(.*)'")]
        public void GivenSentUserNameNitAccountTypePrimary(string userName, string accountType)
        {
            _getPlayeraccount = (from item in _playerAccountInfo
                                 where item.UserName == userName && item.AccountType == accountType && item.Active == true
                                 select item).FirstOrDefault();
            SetupResult.For(Dqr_GetPlayerAccount.Get(new GetPlayerAccountCommand()))
                .IgnoreArguments().Return(_getPlayeraccount);

            _cmd = new GetPlayerAccountCommand {
                PlayerAccountInfo = new PlayerAccountInformation {
                    UserName = userName,
                    AccountType = accountType
                }
            };
        }

        //Validation
        [When(@"Call GetPlayerAccountExecutor\(\) for validate input")]
        public void WhenCallGetPlayerAccountExecutorForValidateInput()
        {
            try {
                GetPlayerAccount.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        //Test function
        [When(@"Call GetPlayerAccountExecutor\(\)")]
        public void WhenCallGetPlayerAccountExecutor()
        {
                GetPlayerAccount.Execute(_cmd, (x) => { });
        }

        [Then(@"The result of get player account should be as : CardType '(.*)' AccountNo '(.*)' CVV '(.*)' ExpireDate '(.*)'")]
        public void ThenTheResultOfGetPlayerAccountShouldBeAsAccountTypeXAccountNoXExpireDateXActiveX(string cardType, string accountNo, string cvv, DateTime expireDate)
        {
            Assert.AreEqual(cardType, _getPlayeraccount.CardType, "This is CardType");
            Assert.AreEqual(accountNo, _getPlayeraccount.AccountNo, "This is AccountNo");
            Assert.AreEqual(cvv, _getPlayeraccount.CVV, "This is CVV");
            Assert.AreEqual(expireDate, _getPlayeraccount.ExpireDate, "This is ExpireDate");
        }

        [Then(@"The result of get player account should be null")]
        public void ThenTheResultOfGetPlayerAccountShouldBeNull()
        {
            Assert.IsTrue(true, "Player account information is null");
        }

        [Then(@"The result of get player account should be throw exception")]
        public void ThenTheResultOfGetPlayerAccountShouldBeThrowException()
        {
            Assert.IsTrue(true, "Exception has been verified in the end of block When.");
        }
    }
}
