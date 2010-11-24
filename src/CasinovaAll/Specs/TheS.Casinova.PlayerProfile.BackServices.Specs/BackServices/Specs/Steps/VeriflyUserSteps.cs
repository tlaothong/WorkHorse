using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.PlayerProfile.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using TheS.Casinova.PlayerProfile.Commands;

namespace TheS.Casinova.PlayerProfile.BackServices.Specs.Steps
{
    [Binding]
    public class VeriflyUserSteps
        : PlayerProfileStepsBase
    {
        private IEnumerable<UserProfile> _userProfiles;

        [Given(@"\(VeriflyUser\) server has user profile information as:")]
        public void GivenVeriflyUserServerHasUserProfileInformationAs(Table table)
        {
            _userProfiles = (from item in table.Rows
                             select new UserProfile {
                                 UserName = item["UserName"],
                                 VeriflyCode = item["VeriflyCode"],
                             });
        }

        [Given(@"sent name: '(.*)' and VeriflyCode: '(.*)' the verifly code should be correct")]
        public void GivenSentNameXAndVeriflyCodeXTheVeriflyCodeShouldBeCorrect(string userName, string veriflyCode)
        {
            var qry = (from item in _userProfiles   
                       where item.UserName == userName
                       select item).FirstOrDefault();

            SetupResult.For(Dqr_GetUserProfile.Get(new Commands.GetUserProfileCommand()))
                .IgnoreArguments().Return(qry);

            Assert.AreEqual(veriflyCode, qry.VeriflyCode, "VeriflyCode");
        }

        [Given(@"the user profile\(UserName: '(.*)', VeriflyCode: '(.*)'\) should be activate")]
        public void GivenTheUserProfileUserNameXVeriflyCodeXShouldBeActivate(string userName, string veriflyCode)
        {
            Action<string, VeriflyUserCommand> checkData = (name, cmd) => {
                Assert.AreEqual(userName, name, "UserName");
            };

            Dac_VeriflyUser.ApplyAction(userName, new Commands.VeriflyUserCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [When(@"call VeriflyUserExecutor\(UserName: '(.*)', VeriflyCode: '(.*)'\)")]
        public void WhenCallVeriflyUserExecutorUserNameXVeriflyCodeX(string userName, string veriflyCode)
        {
            VeriflyUserCommand cmd = new VeriflyUserCommand { UserName = userName, VeriflyCode = veriflyCode };

            VeriflyUserExecutor.Execute(cmd, (x) => { });
        }

        [Then(@"the result should be update")]
        public void ThenTheResultShouldBeUpdate()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }

        [Then(@"the server should throw an error")]
        public void ThenTheServerShouldThrowAnError()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
