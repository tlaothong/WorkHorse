using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.PlayerProfile.Commands;
using TheS.Casinova.PlayerProfile.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;
using Rhino.Mocks;
using TheS.Casinova.PlayerProfile.Command;

namespace TheS.Casinova.PlayerProfile.WebExecutors.Specs.Steps
{
    [Binding]
    public class RegisterUserSteps : PlayerProfileModuleStepsBase
    {
        private RegisterUserCommand _cmd;
        private string _trackingID;

        [Given(@"Sent register user information : UserName '(.*)' Password'(.*)' Email'(.*)' CellPhone'(.*)' Upline'(.*)'")]
        public void GivenSentRegisterUserInformationUserNameXPasswordXEmailXCellPhoneXUplineX(string userName, string password, string email, string cellPhone, string upline)
        {
            _cmd = new RegisterUserCommand {
                RegisterUserInfo = new UserProfile {
                    UserName = userName,
                    Password = password,
                    Email = email,
                    CellPhone = cellPhone,
                    Upline = upline
                }
            };

        }

        [Given(@"The system generated TrackingID for register user:'(.*)'")]
        public void GivenTheSystemGeneratedTrackingIDForRegisterUserX(string trackingID)
        {
            _trackingID = trackingID;
        }
      
        //Test function
        [When(@"Call RegisterUserExecutor\(\)")]
        public void WhenCallRegisterUserExecutor()
        {
           
             RegisterUser.Execute(_cmd, (x) => { });          
        }

        //validation input
        [When(@"Call RegisterUserExecutor\(\) for validate register user input")]
        public void WhenCallRegisterUserExecutorForValidateRegisterUserInput()
        {
            try {
                RegisterUser.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        [Then(@"Get null and skip checking trackingID for register user")]
        public void ThenGetNullAndSkipCheckingTrackingIDForRegisterUser()
        {
            Assert.IsTrue(true, "Exception has been verified in the end of block When.");
        }

        [Then(@"TrackingID for register user should be :'(.*)'")]
        public void ThenTrackingIDForRegisterUserShouldBeX(string expectTrackingID)
        {
            Assert.AreEqual(expectTrackingID, _trackingID, "Get trackingID accept");
        }
    }
}
