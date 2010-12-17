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
    public class CancelPlayerAccoutSteps
        : PlayerAccountStepsBase
    {
        private IEnumerable<PlayerAccountInformation> _playerAccountInfos;
        private IEnumerable<UserProfile> _userProfiles;
        private PlayerAccountInformation _expectPlayerAccountInfo;
        private UserProfile _expectUserProfile;

        [Given(@"\(CancelPlayerAccount\)server has player account information as:")]
        public void GivenCancelPlayerAccountServerHasPlayerAccountInformationAs(Table table)
        {
            _playerAccountInfos = (from item in table.Rows
                                   select new PlayerAccountInformation {
                                       UserName = item["UserName"],
                                       AccountType = item["AccountType"],
                                       CardType = item["CardType"],
                                       Active = Convert.ToBoolean(item["Active"]),
                                   });
        }

        [Given(@"\(CancelPlayerAccount\)server has user profile information as:")]
        public void GivenCancelPlayerAccountServerHasUserProfileInformationAs(Table table)
        {
            _userProfiles = (from item in table.Rows
                             select new UserProfile {
                                 UserName = item["UserName"],
                                 Password = item["Password"],
                             });
        }

        [Given(@"sent UserName: '(.*)', AccountType: '(.*)' the player account informaiton should recieved")]
        public void GivenSentUserNameXAccountTypeXThePlayerAccountInformaitonShouldRecieved(string userName, string accType)
        {
            _expectPlayerAccountInfo = (from item in _playerAccountInfos
                                        where item.UserName == userName && item.AccountType == accType
                                        select item).FirstOrDefault();

            SetupResult.For(Dqr_GetPlayerAccountInfoByAccountType.Get(new Commands.GetPlayerAccountInfoByAccountTypeCommand()))
                .IgnoreArguments().Return(_expectPlayerAccountInfo);
        }

        [Given(@"\(CancelPlayerAccount\)sent UserName: '(.*)' player profile should recieved")]
        public void GivenCancelPlayerAccountSentUserNameXPlayerProfileShouldRecieved(string userName)
        {
            _expectUserProfile = (from item in _userProfiles
                                  where item.UserName == userName
                                  select item).FirstOrDefault();

            SetupResult.For(Dqr_GetUserProfile.Get(new Commands.GetUserProfileCommand()))
                .IgnoreArguments().Return(_expectUserProfile);
        }

        [Given(@"the player account information should be create\(UserName: '(.*)', AccountType: '(.*)'\)")]
        public void GivenThePlayerAccountInformationShouldBeCreateUserNameOhAeAccountTypePrimary(string userName, string accType)
        {
            Action<PlayerAccountInformation, CancelPlayerAccountCommand> checkData = (playerAccoount, command) => {
                Assert.AreEqual(userName, playerAccoount.UserName, "UserName");
                Assert.AreEqual(accType, playerAccoount.AccountType, "AccountType");
                Assert.AreEqual(false, playerAccoount.Active, "Active");
            };

            Dac_CancelPlayerAccount.ApplyAction(new PlayerAccountInformation(), new Commands.CancelPlayerAccountCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [When(@"call CancelPlayerAccountExecutor\(UserName: '(.*)', AccountType: '(.*)', Password: '(.*)'\)")]
        public void WhenCallCancelPlayerAccountExecutorUserNameXAccountTypeXPasswordX(string userName, string accType, string password)
        {
            CancelPlayerAccountCommand cmd = new CancelPlayerAccountCommand {
                PlayerAccountInfo = new PlayerAccountInformation {
                    UserName = userName,
                    AccountType = accType,
                },

                Password = password,
            };

            CancelPlayerAccountExecutor.Execute(cmd, (x) => { });
        }

        [When(@"Expected exception and call CancelPlayerAccountExecutor\(UserName: '(.*)', AccountType: '(.*)', Password: '(.*)'\)")]
        public void WhenExpectedExceptionAndCallCancelPlayerAccountExecutorUserNameXAccountTypeXPasswordX(string userName, string accType, string password)
        {
            try {
                CancelPlayerAccountCommand cmd = new CancelPlayerAccountCommand {
                    PlayerAccountInfo = new PlayerAccountInformation {
                        UserName = userName,
                        AccountType = accType,
                    },

                    Password = password,
                };

                CancelPlayerAccountExecutor.Execute(cmd, (x) => { });
                Assert.Fail("Shouldn't be here!");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex, typeof(ValidationErrorException));
            }
        }
    }
}
