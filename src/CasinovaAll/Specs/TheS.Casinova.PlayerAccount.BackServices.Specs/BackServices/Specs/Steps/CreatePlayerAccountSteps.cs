using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SpecFlowAssist;
using TheS.Casinova.PlayerAccount.Models;
using Rhino.Mocks;
using TheS.Casinova.PlayerAccount.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.PlayerAccount.BackServices.Specs.Steps
{
    [Binding]
    public class CreatePlayerAccountSteps
        : PlayerAccountStepsBase
    {
        private IEnumerable<PlayerAccountInformation> _playerAccountInfos;
        private PlayerAccountInformation _expectPlayAccoutnInfo;


        [Given(@"\(CreatePlayerAccountInfo\) server has player account information as:")]
        public void GivenCreatePlayerAccountInfoServerHasPlayerAccountInformationAs(Table table)
        {
            _playerAccountInfos = (from item in table.Rows
                                   select new PlayerAccountInformation {
                                       UserName = item["UserName"],
                                       AccountType = item["AccountType"],
                                   });
        }

        [Given(@"sent UserName: '(.*)' player account information should recieved")]
        public void GivenSentUserNameOhAePlayerAccountInformationShouldRecieved(string userName)
        {
            _expectPlayAccoutnInfo = (from item in _playerAccountInfos
                                      where item.UserName == userName
                                      select item).FirstOrDefault();

            SetupResult.For(Dqr_GetPlayerAccountInfo.Get(new GetPlayerAccountCommand()))
                .IgnoreArguments().Return(_expectPlayAccoutnInfo);
        }

        [Given(@"the player account information should be create\(UserName: '(.*)', CardType:'(.*)', AccountNo: '(.*)', CVV: '(.*)', ExpireDate: '(.*)', FirstName: '(.*)', LastName: '(.*)'\)")]
        public void GivenThePlayerAccountInformationShouldBeCreateUserNameXCardTypeXAccountNoXCVVXExpireDateXFirstNameXLastNameX(string userName, string cardType, string accNo, string cvv, string expireDate, string firstName, string lastName)
        {
            List<PlayerAccountInformation> qry = new List<PlayerAccountInformation>();
            PlayerAccountInformation primary = new PlayerAccountInformation {
                UserName = userName,
                AccountType = "Primary",
                AccountNo = accNo,
                CardType = cardType,
                CVV = cvv,
                ExpireDate = DateTime.Parse(expireDate),
                FirstName = firstName,
                LastName = lastName,
                Active = true,
            };

            PlayerAccountInformation secondary = new PlayerAccountInformation {
                UserName = userName,
                AccountType = "Secondary",
                Active = false,
            };

            qry.Add(primary);
            qry.Add(secondary);

            Queue<PlayerAccountInformation> expect = new Queue<PlayerAccountInformation>(qry);
            Func<PlayerAccountInformation, CreatePlayerAccountCommand, PlayerAccountInformation> checkData = (playerAccountInfo, cmd) => {
                var exp = expect.Dequeue();
                switch (exp.AccountType) {
                    case "Primary":
                        Assert.AreEqual(userName, playerAccountInfo.UserName, "UserName");
                        Assert.AreEqual("Primary", playerAccountInfo.AccountType, "AccountTypePrimary");
                        Assert.AreEqual(cardType, playerAccountInfo.CardType, "CardType");
                        Assert.AreEqual(accNo, playerAccountInfo.AccountNo, "AccountNo");
                        Assert.AreEqual(cvv, playerAccountInfo.CVV, "CVV");
                        Assert.AreEqual(DateTime.Parse(expireDate), playerAccountInfo.ExpireDate, "ExpireDate");
                        Assert.AreEqual(firstName, playerAccountInfo.FirstName, "FirstName");
                        Assert.AreEqual(lastName, playerAccountInfo.LastName, "LastName");
                        Assert.AreEqual(true, playerAccountInfo.Active, "Active");
                        break;
                    case "Secondary":
                        Assert.AreEqual(userName, playerAccountInfo.UserName, "UserName");
                        Assert.AreEqual("Secondary", playerAccountInfo.AccountType, "AccountTypeSecondary");
                        Assert.AreEqual(false, playerAccountInfo.Active, "Active");
                        break;
                    default:
                        break;
                }
                return playerAccountInfo;
            };

            Dac_CreatePlayerAccount.Create(new PlayerAccountInformation(), new CreatePlayerAccountCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [When(@"call CreatePlayerAcoountExecutor\(UserName: '(.*)', CardType:'(.*)', AccountNo: '(.*)', CVV: '(.*)', ExpireDate: '(.*)', FirstName: '(.*)', LastName: '(.*)'\)")]
        public void WhenCallCreatePlayerAcoountExecutorUserNameXCardTypeXAccountNoXCVVXExpireDateXFirstNameXLastNameX(string userName, string cardType, string accNo, string cvv, string expireDate, string firstName, string lastName)
        {
            CreatePlayerAccountCommand cmd = new CreatePlayerAccountCommand {
                PlayerAccountInfo = new PlayerAccountInformation {
                    UserName = userName,
                    AccountNo = accNo,
                    CardType = cardType,
                    CVV = cvv,
                    ExpireDate = DateTime.Parse(expireDate),
                    FirstName = firstName,
                    LastName = lastName,
                },
            };

            CreatePlayerAccountExecutor.Execute(cmd, x => { });
        }

        [When(@"Expected exception and call CreatePlayerAcoountExecutor\(UserName: '(.*)', CardType:'(.*)', AccountNo: '(.*)', CVV: '(.*)', ExpireDate: '(.*)', FirstName: '(.*)', LastName: '(.*)'\)")]
        public void WhenExpectedExceptionAndCallCreatePlayerAcoountExecutorUserNameXCardTypeXAccountNoXCVVXExpireDateXFirstNameXLastNameX(string userName, string cardType, string accNo, string cvv, string expireDate, string firstName, string lastName)
        {
            try {
            CreatePlayerAccountCommand cmd = new CreatePlayerAccountCommand {
                PlayerAccountInfo = new PlayerAccountInformation {
                    UserName = userName,
                    AccountNo = accNo,
                    CardType = cardType,
                    CVV = cvv,
                    ExpireDate = DateTime.Parse(expireDate),
                    FirstName = firstName,
                    LastName = lastName,
                },
            };

            CreatePlayerAccountExecutor.Execute(cmd, x => { });
                Assert.Fail("Shouldn't be here!");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex, typeof(ValidationErrorException));
            }
        }

        [Then(@"the result should be create")]
        public void ThenTheResultShouldBeCreate()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
        [Then(@"the result should be throw exception")]
        public void ThenTheResultShouldBeThrowException()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
    }
}
