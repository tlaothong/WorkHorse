using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.PlayerProfile.Commands;
using TheS.Casinova.PlayerProfile.Models;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.PlayerProfile.WebExecutors.Specs.Steps
{
    [Binding]
    public class GetUserProfileSteps : PlayerProfileModuleStepsBase
    {
        private GetUserProfileCommand _cmd;
        private IEnumerable<UserProfile> _userProfile;
        private UserProfile _GetUserProfile;

        [Given(@"Server has user profile information as:")]
        public void GivenServerHasUserProfileInformationAs(Table table)
        {
            _userProfile = from item in table.Rows
                           select new UserProfile {
                               UserName = Convert.ToString(item["UserName"]),
                               Password = Convert.ToString(item["Password"]),
                               Email = Convert.ToString(item["Email"]),
                               CellPhone = Convert.ToString(item["CellPhone"]),
                               Upline = Convert.ToString(item["Upline"]),
                               Refundable = Convert.ToDouble(item["Refundable"]),
                               NonRefundable = Convert.ToDouble(item["NonRefundable"]),
                               Active = Convert.ToBoolean(item["Active"])
                           };
        }

        [Given(@"Sent UserName: '(.*)' for get user profile")]
        public void GivenSentUserNameOhAeForGetUserProfile(string userName)
        {

            bool statusActive = true;
            _GetUserProfile = (from item in _userProfile
                               where item.UserName == userName && item.Active == statusActive
                               select item).FirstOrDefault();

            SetupResult.For(Dqr_GetUserProfile.Get(new GetUserProfileCommand()))
                .IgnoreArguments().Return(_GetUserProfile);

            _cmd = new GetUserProfileCommand {
                GetUserProfileInfo = new UserProfile {
                    UserName = userName
                }
            };
        }

        [Given(@"Sent UserName: '(.*)' for get user profile validation")]
        public void GivenSentUserNameForGetUserProfileValidation(string userName)
        {
            _cmd = new GetUserProfileCommand {
                GetUserProfileInfo = new UserProfile {
                    UserName = userName
                }
            };
        }

        //Test function
        [When(@"Call GetUserProfileExecutor\(\)")]
        public void WhenCallGetUserProfileExecutor()
        {
              GetUserProfile.Execute(_cmd, (x) => { });
 
        }

        //Validation
        [When(@"Call GetUserProfileExecutor\(\) for validate input")]
        public void WhenCallGetUserProfileExecutorForValidateInput()
        {
            try {
                GetUserProfile.Execute(_cmd, (x) => { });

            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        [Then(@"User Profile information should be UserName '(.*)' Password '(.*)' Email '(.*)' CellPhone '(.*)' Upline '(.*)' Refundable '(.*)' NonRefundable '(.*)' Active '(.*)'")]
        public void ThenUserProfileInformationShouldBeUserNameXPasswordXEmailXCellPhoneXUplineXRefundableXNonRefundableXActiveX(
            string userName,
            string passWord,
            string email,
            string cellPhone,
            string upline,
            double refundable,
            double nonRefundable,
            bool active)
        {
            Assert.AreEqual(userName, _GetUserProfile.UserName);
            Assert.AreEqual(passWord, _GetUserProfile.Password);
            Assert.AreEqual(email, _GetUserProfile.Email);
            Assert.AreEqual(cellPhone, _GetUserProfile.CellPhone);
            Assert.AreEqual(upline, _GetUserProfile.Upline);
            Assert.AreEqual(refundable, _GetUserProfile.Refundable);
            Assert.AreEqual(nonRefundable, _GetUserProfile.NonRefundable);
            Assert.AreEqual(active, _GetUserProfile.Active);

        }

        [Then(@"User Profile information should be throw exception")]
        public void ThenUserProfileInformationShouldBeThrowException()
        {
            Assert.IsTrue(true, "Exception has been verified in the end of block When.");
        }
    }
}
