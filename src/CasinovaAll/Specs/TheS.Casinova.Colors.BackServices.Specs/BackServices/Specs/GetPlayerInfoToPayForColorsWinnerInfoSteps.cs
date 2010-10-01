using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.Colors.Models;
using Rhino.Mocks;
using TheS.Casinova.Colors.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.Colors.BackServices.Specs
{
    [Binding]
    public class GetPlayerInfoToPayForColorsWinnerInfoSteps 
        : ColorsGameStepsBase
    {
        private IEnumerable<PlayerInformation> _userInformations;
        private PayForColorsWinnerInfoCommand _cmd;
        private double _expected;
        private double _result;

        [Given(@"server has user information as:")]
        public void GivenServerHasUserInformationAs(Table table)
        {
            _userInformations = (from item in table.Rows
                                select new PlayerInformation {
                                    UserName = item["UserName"],
                                    Balance = Convert.ToDouble(item["Balance"]),
                                });
        }

        [Given(@"sent userName: '(.*)' and expected player's balance should be '(.*)'")]
        public void GivenSentUserNameXAndExpectedPlayerSBalanceShouldBeX(string userName, double balance)
        {
            var result = (from item in _userInformations
                          where item.UserName == userName
                          select item).FirstOrDefault();

            _expected = balance;
            SetupResult.For(Dqr_GetPlayerInfo.Get(new PayForColorsWinnerInfoCommand()))
                .IgnoreArguments().Return(result.Balance);
        }

        [When(@"call Get\(PayForColorsWinnerInfoCommand\), UserName: '(.*)'")]
        public void WhenCallGetPayForColorsWinnerInfoCommandUserNameX(string userName)
        {
            _cmd = new PayForColorsWinnerInfoCommand { 
                PlayerInfo = new PlayerInformation { 
                    UserName = userName 
                } 
            };

            _result = Dqr_GetPlayerInfo.Get(_cmd);
        }

        [Then(@"the result should be same as expected balance")]
        public void ThenTheResultShouldBeSameAsExpectedBalance()
        {
            Assert.AreEqual(_expected, _result);
        }
    }
}
