using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.PlayerProfile.Models;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheS.Casinova.PlayerProfile.Commands;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.PlayerProfile.BackServices.Specs.Steps
{
    [Binding]
    public class ChangeEmailSteps
        : PlayerProfileStepsBase
    {
        private IEnumerable<UserProfile> _userProfiles;

        [Given(@"\(ChangeEmail\)server has user profile information as:")]
        public void GivenChangeEmailServerHasUserProfileInformationAs(Table table)
        {
            _userProfiles = (from item in table.Rows
                             select new UserProfile { 
                                 UserName = item["UserName"],
                                 Password = item["Password"],
                                 Email = item["E-mail"],
                             });
        }

        [Given(@"the player profile should be recieved\(UserName: '(.*)'\)")]
        public void GivenThePlayerProfileShouldBeRecievedUserNameXPasswordXOldE_MailX(string userName)
        {
            var qry = (from item in _userProfiles
                       where item.UserName == userName 
                       select item).FirstOrDefault();

            SetupResult.For(Dqr_GetUserProfile.Get(new Commands.GetUserProfileCommand()))
                .IgnoreArguments().Return(qry);
        }

        [Given(@"the new email should be unique\(NewE-mail: '(.*)'\)")]
        public void GivenTheNewEmailShouldBeUniqueNewE_MailX(string newEmail)
        {
            var qry = (from item in _userProfiles
                       where item.Email == newEmail
                       select item).FirstOrDefault();

            SetupResult.For(Dqr_GetUserProfileByEmail.Get(new GetUserProfileByEmailCommand()))
                .IgnoreArguments().Return(qry);
        }

        [Given(@"the user profile should be update\(UserName: '(.*)', NewE-mail: '(.*)'\)")]
        public void GivenTheUserProfileShouldBeUpdateUserNameXNewE_MailX(string userName, string newEmail)
        {
            Action<UserProfile, ChangeEmailCommand> checkData = (userProfile, cmd) => {
                Assert.AreEqual(userName, userProfile.UserName, "UserName");
                Assert.AreEqual(newEmail, userProfile.Email, "Email");
            };

            Dac_ChangeEmail.ApplyAction(new UserProfile(), new ChangeEmailCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [When(@"call ChangeEmailExecutor\(UserName: '(.*)', Password: '(.*)', OldE-mail: '(.*)', NewE-mail: '(.*)'\)")]
        public void WhenCallChangeEmailExecutorUserNameXPasswordXOldE_MailXNewE_MailX(string userName, string password, string oldEmail, string newEmail)
        {
            ChangeEmailCommand cmd = new ChangeEmailCommand {
                UserProfile = new UserProfile {
                    UserName = userName,
                    Email = oldEmail,
                    Password = password,
                    NewEmail = newEmail
                }
            };

            ChangeEmailExecutor.Execute(cmd, (x) => { });
        }

        [When(@"Expected exception and call ChangeEmailExecutor\(UserName: '(.*)', Password: '(.*)', OldE-mail: '(.*)', NewE-mail: '(.*)'\)")]
        public void WhenExpectedExceptionAndCallChangeEmailExecutorUserNameXPasswordXOldE_MailXNewE_MailX(string userName, string password, string oldEmail, string newEmail)
        {
            try {
                ChangeEmailCommand cmd = new ChangeEmailCommand {
                    UserProfile = new UserProfile {
                        UserName = userName,
                        Email = oldEmail,
                        Password = password,
                        NewEmail = newEmail
                    }
                };

                ChangeEmailExecutor.Execute(cmd, (x) => { });
                Assert.Fail("Shouldn't be here!");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex, typeof(ValidationErrorException));
            }
        }

        [Then(@"the e-mail should be update")]
        public void ThenTheE_MailShouldBeUpdate()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
    }
}
