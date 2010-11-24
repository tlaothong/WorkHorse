using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.PlayerProfile.Models;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheS.Casinova.PlayerProfile.Commands;

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
                                 Email = item["E-mail"],
                             });
        }

        [Given(@"the old email should be correct\(UserName: '(.*)', OldE-mail: '(.*)'\)")]
        public void GivenTheOldEmailShouldBeCorrectUserNameXOldE_MailX(string userName, string oldEmail)
        {
            var qry = (from item in _userProfiles
                       where item.UserName == userName 
                       select item).FirstOrDefault();

            SetupResult.For(Dqr_GetUserProfile.Get(new Commands.GetUserProfileCommand()))
                .IgnoreArguments().Return(qry);

            Assert.AreEqual(qry.Email, oldEmail, "OldEmail");
        }

        [Given(@"the new email should be unique\(NewE-mail: '(.*)'\)")]
        public void GivenTheNewEmailShouldBeUniqueNewE_MailX(string newEmail)
        {
            var qry = (from item in _userProfiles
                       where item.Email == newEmail
                       select item).FirstOrDefault();

            SetupResult.For(Dqr_GetUserProfile.Get(new Commands.GetUserProfileCommand()))
                .IgnoreArguments().Return(qry);

            Assert.IsNull(qry, "Is unique email");
        }

        [Given(@"the user profile should be update\(UserName: '(.*)', OldE-mail: '(.*)', NewE-mail: '(.*)'\)")]
        public void GivenTheUserProfileShouldBeUpdateUserNameXOldE_MailXNewE_MailX(string userName, string oldEmail, string newEmail)
        {
            Action<UserProfile, ChangeEmailCommand> checkData = (userProfile, cmd) => {
                Assert.AreEqual(userName, userProfile.UserName, "UserName");
                Assert.AreEqual(newEmail, userProfile.Email, "Email");
            };

            Dac_ChangeEmail.ApplyAction(new UserProfile(), new ChangeEmailCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [When(@"call ChangeEmailExecutor\(UserName: '(.*)', OldE-mail: '(.*)', NewE-mail: '(.*)'\)")]
        public void WhenCallChangeEmailExecutorUserNameXOldE_MailXNewE_MailX(string userName, string oldEmail, string newEmail)
        {
            ChangeEmailCommand cmd = new ChangeEmailCommand {
                UserName = userName,
                OldEmail = oldEmail,
                NewEmail = newEmail,
            };

            ChangeEmailExecutor.Execute(cmd, (x) => { });
        }

        [Then(@"the e-mail should be update in user profile")]
        public void ThenTheE_MailShouldBeUpdateInUserProfile()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
    }
}
