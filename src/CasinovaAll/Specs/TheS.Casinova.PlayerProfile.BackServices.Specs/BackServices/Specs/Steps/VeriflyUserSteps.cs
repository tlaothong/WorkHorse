using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.PlayerProfile.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using TheS.Casinova.PlayerProfile.Commands;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.PlayerProfile.BackServices.Specs.Steps
{
    [Binding]
    public class VeriflyUserSteps
        : PlayerProfileStepsBase
    {
        private IEnumerable<UserProfile> _userProfiles;

        [Given(@"\(VerifyUser\) server has user profile information as:")]
        public void GivenVeriflyUserServerHasUserProfileInformationAs(Table table)
        {
            _userProfiles = (from item in table.Rows
                             select new UserProfile {
                                 UserName = item["UserName"],
                                 VeriflyCode = item["VerifyCode"],
                             });
        }

        [Given(@"sent name: '(.*)' the player profile should recieved")]
        public void GivenSentNameXThePlayerProfileShouldRecieved(string userName)
        {
            var qry = (from item in _userProfiles   
                       where item.UserName == userName
                       select item).FirstOrDefault();

            SetupResult.For(Dqr_GetUserProfile.Get(new Commands.GetUserProfileCommand()))
                .IgnoreArguments().Return(qry);
        }

        [Given(@"the user profile\(UserName: '(.*)'\) should be activate")]
        public void GivenTheUserProfileUserNameXShouldBeActivate(string userName)
        {
            Action<UserProfile, VerifyUserCommand> checkData = (userProfile, cmd) => {
                Assert.AreEqual(userName, userProfile.UserName, "UserName");
                Assert.IsTrue(userProfile.Active, "Active");
            };

            Dac_VeriflyUser.ApplyAction(new UserProfile(), new Commands.VerifyUserCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [When(@"call VeriflyUserExecutor\(UserName: '(.*)', VeriflyCode: '(.*)'\)")]
        public void WhenCallVeriflyUserExecutorUserNameXVeriflyCodeX(string userName, string veriflyCode)
        {
            VerifyUserCommand cmd = new VerifyUserCommand {
                UserProfile = new UserProfile {
                    UserName = userName,
                    VeriflyCode = veriflyCode
                }
            };

            VeriflyUserExecutor.Execute(cmd, (x) => { });
        }

        [When(@"Expected exception and call VeriflyUserExecutor\(UserName: '(.*)', VeriflyCode: '(.*)'\)")]
        public void WhenExpectedExceptionAndCallVeriflyUserExecutorUserNameXVeriflyCodeX(string userName, string veriflyCode)
        {
            try {
                VerifyUserCommand cmd = new VerifyUserCommand {
                    UserProfile = new UserProfile {
                        UserName = userName,
                        VeriflyCode = veriflyCode
                    }
                };

                VeriflyUserExecutor.Execute(cmd, (x) => { });
                Assert.Fail("Shouldn't be here!");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex, typeof(ValidationErrorException));
            }
        }

        [Then(@"the result should be update")]
        public void ThenTheResultShouldBeUpdate()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }

        [Then(@"the server should throw an error")]
        public void ThenTheServerShouldThrowAnError()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
    }
}
