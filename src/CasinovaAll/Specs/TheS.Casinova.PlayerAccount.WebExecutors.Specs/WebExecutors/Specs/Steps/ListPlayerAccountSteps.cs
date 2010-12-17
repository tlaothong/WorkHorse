using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.PlayerAccount.Models;
using TheS.Casinova.PlayerAccount.Commands;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.PlayerAccount.WebExecutors.Specs.Steps
{
    [Binding]
    public class ListPlayerAccountSteps : PlayerAccountModuleStepsBase
    {
        private ListPlayerAccountCommand _cmd;
        private IEnumerable<PlayerAccountInformation> _playerAccountInfo;
        private IEnumerable<PlayerAccountInformation> _listPlayerAccount;

        [Given(@"Server has player account information as:")]
        public void GivenServerHasPlayerAccountInformationAs(Table table)
        {
            _playerAccountInfo = from item in table.Rows
                                 select new PlayerAccountInformation{ 
                                     AccountType = Convert.ToString(item["AccountType"]),
                                     UserName = Convert.ToString(item["UserName"]),
                                     CardType = Convert.ToString(item["CardType"]),
                                     AccountNo = Convert.ToString(item["AccountNo"]),
                                     CVV = Convert.ToString(item["CVV"]),
                                     ExpireDate = DateTime.Parse(item["ExpireDate"]),
                                     Active = Convert.ToBoolean(item["Active"])                                     
                                 };
        }

        [Given(@"Sent UserName '(.*)' for validate list player account information")]
        public void GivenSentUserNameForValidateListPlayerAccountInformation(string userName)
        {
            _cmd = new ListPlayerAccountCommand {
                PlayerAccountInfo = new PlayerAccountInformation {
                    UserName = userName
                }
            };
        }

        [Given(@"Sent UserName '(.*)' for list player account")]
        public void GivenSentUserNameMeawForListPlayerAccount(string userName)
        {
            _listPlayerAccount = (from item in _playerAccountInfo
                                  where item.UserName == userName && item.Active == true
                                  select item);

            SetupResult.For(Dqr_ListPlayerAccount.List(new ListPlayerAccountCommand()))
                .IgnoreArguments().Return(_listPlayerAccount);

            _cmd = new ListPlayerAccountCommand {
                PlayerAccountInfo = new PlayerAccountInformation { 
                    UserName = userName
                }
            };
        }

        //Validate
        [When(@"Call ListPlayerAccountExecutor\(\) for validate input")]
        public void WhenCallListPlayerAccountExecutorForValidateInput()
        {
            try {
                ListPlayerAccount.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        //Test function
        [When(@"Call ListPlayerAccountExecutor\(\)")]
        public void WhenCallListPlayerAccountExecutor()
        {
           
              ListPlayerAccount.Execute(_cmd, (x) => { });
        }

        [Then(@"The result of player account should be as:")]
        public void ThenTheResultOfPlayerAccountShouldBeAs(Table table)
        {
            var expected = from item in table.Rows
                           select new {
                               AccountType = Convert.ToString(item["AccountType"]),
                               UserName = Convert.ToString(item["UserName"]),
                               CardType = Convert.ToString(item["CardType"]),
                               AccountNo = Convert.ToString(item["AccountNo"]),
                               CVV = Convert.ToString(item["CVV"]),
                               ExpireDate = DateTime.Parse(item["ExpireDate"]),
                               Active = Convert.ToBoolean(item["Active"])
                           };

            var actual = from item in _listPlayerAccount
                         select new {
                             AccountType = item.AccountType,
                             UserName = item.UserName,
                             CardType = item.CardType,
                             AccountNo = item.AccountNo,
                             CVV = item.CVV,
                             ExpireDate = item.ExpireDate,
                             Active = item.Active
                         };
            CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray(), "Player account");
        }

        [Then(@"The result of player account should be throw exception")]
        public void ThenTheResultOfPlayerAccountShouldBeThrowException()
        {
            Assert.IsTrue(true, "Exception has been verified in the end of block When.");
        }
    
    }
}
