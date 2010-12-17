using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.PlayerAccount.Models;
using TheS.Casinova.PlayerProfile.Models;
using Rhino.Mocks;
using TheS.Casinova.PlayerAccount.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.PlayerAccount.BackServices.Specs.Steps
{
    [Binding]
    public class ActivatePlayerAccountSteps
        : PlayerAccountStepsBase
    {
        private IEnumerable<PlayerAccountInformation> _playerAccountInfos;
        private IEnumerable<UserProfile> _userProfiles;
        private PlayerAccountInformation _expectPlayerAccountInfo;
        private UserProfile _expectUserProfile;
        
        [Given(@"\(ActivatePlayerAccount\)server has player account information as:")]
        public void GivenActivatePlayerAccountServerHasPlayerAccountInformationAs(Table table)
        {
            _playerAccountInfos = (from item in table.Rows
                                   select new PlayerAccountInformation {
                                       UserName = item["UserName"],
                                       AccountType = item["AccountType"],
                                       CardType = item["CardType"],
                                       Active = Convert.ToBoolean(item["Active"]),
                                   });
        }

        [Given(@"\(ActivatePlayerAccount\)server has user profile information as:")]
        public void GivenActivatePlayerAccountServerHasUserProfileInformationAs(Table table)
        {
            _userProfiles = (from item in table.Rows
                             select new UserProfile {
                                 UserName = item["UserName"],
                                 Password = item["Password"],
                             });
        }

        [Given(@"\(ActivatePlayerAccount\)sent UserName: '(.*)' player profile should recieved")]
        public void GivenActivatePlayerAccountSentUserNameXPlayerProfileShouldRecieved(string userName)
        {
            _expectUserProfile = (from item in _userProfiles
                                  where item.UserName == userName
                                  select item).FirstOrDefault();

            SetupResult.For(Dqr_GetUserProfile.Get(new Commands.GetUserProfileCommand()))
                .IgnoreArguments().Return(_expectUserProfile);
        }

        [Given(@"\(ActivatePlayerAccount\)sent UserName: '(.*)', AccountType: '(.*)' the player account informaiton should recieved")]
        public void GivenActivatePlayerAccountSentUserNameXAccountTypeXThePlayerAccountInformaitonShouldRecieved(string userName, string accType)
        {
            _expectPlayerAccountInfo = (from item in _playerAccountInfos
                                        where item.UserName == userName && item.AccountType == accType
                                        select item).FirstOrDefault();

            SetupResult.For(Dqr_GetPlayerAccountInfoByAccountType.Get(new Commands.GetPlayerAccountInfoByAccountTypeCommand()))
                .IgnoreArguments().Return(_expectPlayerAccountInfo);
        }

        [When(@"call ActivatePlayerAccount\(UserName: '(.*)', AccountType: '(.*)', Password: '(.*)'\)")]
        public void WhenCallActivatePlayerAccountUserNameXAccountTypeXPasswordX(string userName, string accType, string password)
        {
            ActivatePlayerAccountCommand cmd = new ActivatePlayerAccountCommand{
                PlayerAccountInfo = new PlayerAccountInformation {
                    UserName = userName,
                    AccountType = accType,
                },

                Password = password,
            };

            ActivatePlayerAccountExecutor.Execute(cmd, (x) => { });
        }

        [When(@"Expected exception and call ActivatePlayerAccount\(UserName: '(.*)', AccountType: '(.*)', Password: '(.*)'\)")]
        public void WhenExpectedExceptionAndCallActivatePlayerAccountUserNameXAccountTypeXPasswordX(string userName, string accType, string password)
        {
            try {
                ActivatePlayerAccountCommand cmd = new ActivatePlayerAccountCommand {
                    PlayerAccountInfo = new PlayerAccountInformation {
                        UserName = userName,
                        AccountType = accType,
                    },

                    Password = password,
                };

                ActivatePlayerAccountExecutor.Execute(cmd, (x) => { });
                Assert.Fail("Shouldn't be here!");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex, typeof(ValidationErrorException));
            }
        }
    }
}
