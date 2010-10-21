using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.PlayerProfile.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.PlayerProfile.BackServices.Specs.Steps
{
    [Binding]
    public class RegisterUserSteps
        : PlayerProfileStepsBase
    {
        private IEnumerable<UserProfile> _userProfiles;

        [Given(@"server has user profile information as:")]
        public void GivenServerHasUserProfileInformationAs(Table table)
        {
            _userProfiles = (from item in table.Rows
                             select new UserProfile {
                                 UserName = item["UserName"],
                             });
        }

        [Given(@"the upline should be avaliable\(UserName: '(.*)'\)")]
        public void GivenTheUplineShouldBeAvaliableUserNameX(string userName)
        {
            var qry = (from item in _userProfiles
                       where item.UserName == userName
                       select item).FirstOrDefault();

            SetupResult.For(Dqr_GetUserProfile.Get(new GetUserProfileCommand()))
                .IgnoreArguments().Return(qry);
        }

        [Given(@"the user profile should be create\(UserName: '(.*)', Password: '(.*)', E-mail: '(.*)', CellPhone: '(.*)', Upline: '(.*)', VeriflyCode: '(.*)'\)")]
        public void GivenTheUserProfileShouldBeCreateUserNameXPasswordXE_MailXCellPhoneXUplineXVeriflyCodeX(string userName, string password, string email, string cellPhone, string upline, string veriflyCode)
        {
            Func<UserProfile, RegisterUserCommand, UserProfile> checkData = (userProfile, cmd) => 
            {
                Assert.AreEqual(userName, userProfile.UserName, "UserName");
                Assert.AreEqual(password, userProfile.Password, "Password");
                Assert.AreEqual(email, userProfile.Email, "Email");
                Assert.AreEqual(cellPhone, userProfile.CellPhone, "CellPhone");
                Assert.AreEqual(upline, userProfile.Upline, "Upline");
                Assert.AreEqual(veriflyCode, userProfile.VeriflyCode, "VeriflyCode");
                return userProfile;
            };

            Dac_RegisterUser.Create(new Models.UserProfile(), new Commands.RegisterUserCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [When(@"call RegisterUserExecutor\(UserName: '(.*)', Password: '(.*)', E-mail: '(.*)', CellPhone: '(.*)', Upline: '(.*)', VeriflyCode: '(.*)'\)")]
        public void WhenCallRegisterUserExecutorUserNameXPasswordXE_MailXCellPhoneXUplineXVeriflyCodeX(string userName, string password, string email, string cellPhone, string upline, string veriflyCode)
        {
            RegisterUserCommand cmd = new RegisterUserCommand {
                UserName = userName,
                Password = password,
                Email = email,
                CellPhone = cellPhone,
                Upline = upline,
                VeriflyCode = veriflyCode,
            };

            RegisterUserExecutor.Execute(cmd, (x) => { });
        }
 
        [Then(@"the result should be create")]
        public void ThenTheResultShouldBeCreate()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
   }
}
