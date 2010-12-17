using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.PlayerProfile.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.PlayerProfile.BackServices.Specs.Steps
{
    [Binding]
    public class RegisterUserSteps
        : PlayerProfileStepsBase
    {
        private IEnumerable<UserProfile> _userProfiles;
        private UserProfile _expectUpline;

        [Given(@"\(RegisterUser\)server has user profile information as:")]
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
            _expectUpline = (from item in _userProfiles
                                 where item.UserName == userName
                                 select item).FirstOrDefault();

            SetupResult.For(Dqr_GetUserProfile.Get(new GetUserProfileCommand()))
                .IgnoreArguments().Return(_expectUpline);           
        }

        [Given(@"the upline should be unvaliable\(UserName: '(.*)'\)")]
        public void GivenTheUplineShouldBeUnvaliableUserNameX(string userName)
        {
            _expectUpline = (from item in _userProfiles
                             where item.UserName == userName
                             select item).FirstOrDefault();

            SetupResult.For(Dqr_GetUserProfile.Get(new GetUserProfileCommand()))
                .IgnoreArguments().Return(_expectUpline);
        }

        [Given(@"the user profile should be create\(UserName: '(.*)', Password: '(.*)', E-mail: '(.*)', CellPhone: '(.*)', Upline: '(.*)', VeriflyCode: '(.*)'\)")]
        public void GivenTheUserProfileShouldBeCreateUserNameXPasswordXE_MailXCellPhoneXUplineXVeriflyCodeX(string userName, string password, string email, int cellPhone, string upline, string verifyCode)
        {
            Func<UserProfile, RegisterUserCommand, UserProfile> checkData = (userProfile, cmd) => 
            {
                Assert.AreEqual(userName, userProfile.UserName, "UserName");
                Assert.AreEqual(password, userProfile.Password, "Password");
                Assert.AreEqual(email, userProfile.Email, "Email");
                Assert.AreEqual(cellPhone, userProfile.CellPhone, "CellPhone");
                Assert.AreEqual(upline, userProfile.Upline, "Upline");
                Assert.AreEqual(verifyCode, userProfile.VerifyCode, "VerifyCode");
                return userProfile;
            };

            Dac_RegisterUser.Create(new Models.UserProfile(), new Commands.RegisterUserCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [When(@"call RegisterUserExecutor\(UserName: '(.*)', Password: '(.*)', E-mail: '(.*)', CellPhone: '(.*)', Upline: '(.*)', VeriflyCode: '(.*)'\)")]
        public void WhenCallRegisterUserExecutorUserNameXPasswordXE_MailXCellPhoneXUplineXVeriflyCodeX(string userName, string password, string email, string cellPhone, string upline, string verifyCode)
        {
            RegisterUserCommand cmd = new RegisterUserCommand {
                RegisterUserInfo  = new UserProfile {
                    UserName = userName,
                    Password = password,
                    Email = email,
                    CellPhone = cellPhone,
                    Upline = upline,
                    VerifyCode = verifyCode,
                }
            };

            RegisterUserExecutor.Execute(cmd, (x) => { });
        }

        [When(@"Expected exception and call RegisterUserExecutor\(UserName: '(.*)', Password: '(.*)', E-mail: '(.*)', CellPhone: '(.*)', Upline: '(.*)', VeriflyCode: '(.*)'\)")]
        public void WhenExpectedExceptionAndCallRegisterUserExecutorUserNameXPasswordXE_MailXCellPhoneXUplineXVeriflyCodeX(string userName, string password, string email, string cellPhone, string upline, string veriflyCode)
        {
            try {
                RegisterUserCommand cmd = new RegisterUserCommand {
                    RegisterUserInfo = new UserProfile {
                        UserName = userName,
                        Password = password,
                        Email = email,
                        CellPhone = cellPhone,
                        Upline = upline,
                        VerifyCode = veriflyCode,
                    }
                };

                RegisterUserExecutor.Execute(cmd, (x) => { });
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
