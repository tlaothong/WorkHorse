using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.PlayerAccount.Models;
using Rhino.Mocks;
using TheS.Casinova.PlayerAccount.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.PlayerAccount.BackServices.Specs.Steps
{
    [Binding]
    public class EditPlayerAccountSteps
        : PlayerAccountStepsBase
    {
        private IEnumerable<PlayerAccountInformation> _playerAccountInfos;
        private PlayerAccountInformation _expectPlayerAccountInfo;

        [Given(@"\(EditPlayerAccount\) server has player account information as:")]
        public void GivenEditPlayerAccountServerHasPlayerAccountInformationAs(Table table)
        {
            _playerAccountInfos = (from item in table.Rows
                                   select new PlayerAccountInformation {
                                       UserName = item["UserName"],
                                       AccountType = item["AccountType"],
                                       Active = Convert.ToBoolean(item["Active"]),
                                   });
        }

        [Given(@"\(EditPlayerAccount\)sent UserName: '(.*)' player account information should recieved")]
        public void GivenEditPlayerAccountSentUserNameXPlayerAccountInformationShouldRecieved(string userName)
        {
            _expectPlayerAccountInfo = (from item in _playerAccountInfos
                                        where item.UserName == userName
                                        select item).FirstOrDefault();

            SetupResult.For(Dqr_GetPlayerAccountInfoByAccountType.Get(new Commands.GetPlayerAccountInfoByAccountTypeCommand()))
                .IgnoreArguments().Return(_expectPlayerAccountInfo);
        }

        [Given(@"the player account information should be update\(UserName: '(.*)', AccountType: '(.*)', AccountNo: '(.*)', CardType: '(.*)', ExpireDate: '(.*)', FirstName: '(.*)', LastName: '(.*)'\)")]
        public void GivenThePlayerAccountInformationShouldBeUpdateUserNameXAccountTypeXAccountNoXCardTypeXExpireDateXFirstNameXLastNameX(string userName, string accType, string accNo, string cardType, string expireDate, string firstName, string lastName)
        {
            Action<PlayerAccountInformation, EditPlayerAccountCommand> checkData = (playerAccountInfo, command) => {
                Assert.AreEqual(userName, playerAccountInfo.UserName, "UserName");
                Assert.AreEqual(accType, playerAccountInfo.AccountType, "AccountType");
                Assert.AreEqual(accNo, playerAccountInfo.AccountNo, "AccountNo");
                Assert.AreEqual(cardType, playerAccountInfo.CardType, "CardType");
                Assert.AreEqual(DateTime.Parse(expireDate), playerAccountInfo.ExpireDate, "ExpireDate");
                Assert.AreEqual(firstName, playerAccountInfo.FirstName, "FirstName");
                Assert.AreEqual(lastName, playerAccountInfo.LastName, "LastName");
            };
            Dac_EditPlayerAccount.ApplyAction(new PlayerAccountInformation(), new EditPlayerAccountCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [When(@"call EditPlayerAccountExecutor\(UserName: '(.*)', AccountType: '(.*)', AccountNo: '(.*)', CardType: '(.*)', ExpireDate: '(.*)', FirstName: '(.*)', LastName: '(.*)'\)")]
        public void WhenCallEditPlayerAccountExecutorUserNameXAccountTypeXAccountNoXCardTypeXExpireDateXFirstNameXLastNameX(string userName, string accType, string accNo, string cardType, string expireDate, string firstName, string lastName)
        {
            EditPlayerAccountCommand cmd = new EditPlayerAccountCommand {
                PlayerAccountInfo = new PlayerAccountInformation {
                    UserName = userName,
                    AccountType = accType,
                    AccountNo = accNo,
                    CardType = cardType,
                    ExpireDate = DateTime.Parse(expireDate),
                    FirstName = firstName,
                    LastName = lastName,
                },
            };

            EditPlayerAccountExecutor.Execute(cmd, (x) => { });
        }

        [When(@"Expected exception and call EditPlayerAccountExecutor\(UserName: '(.*)', AccountType: '(.*)', AccountNo: '(.*)', CardType: '(.*)', ExpireDate: '(.*)', FirstName: '(.*)', LastName: '(.*)'\)")]
        public void WhenExpectedExceptionAndCallEditPlayerAccountExecutorUserNameXAccountTypeXAccountNoXCardTypeXExpireDateXFirstNameXLastNameX(string userName, string accType, string accNo, string cardType, string expireDate, string firstName, string lastName)
        {
            try {
                EditPlayerAccountCommand cmd = new EditPlayerAccountCommand {
                    PlayerAccountInfo = new PlayerAccountInformation {
                        UserName = userName,
                        AccountType = accType,
                        AccountNo = accNo,
                        CardType = cardType,
                        ExpireDate = DateTime.Parse(expireDate),
                        FirstName = firstName,
                        LastName = lastName,
                    },
                };

                EditPlayerAccountExecutor.Execute(cmd, (x) => { });
                Assert.Fail("Shouldn't be here!");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex, typeof(ValidationErrorException));
            }
        }
    }
}
