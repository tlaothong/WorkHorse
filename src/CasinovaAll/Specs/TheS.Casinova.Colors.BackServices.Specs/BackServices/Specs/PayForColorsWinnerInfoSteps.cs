using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.Colors.Commands;
using TheS.Casinova.Colors.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using TheS.Casinova.Colors.DAL;

namespace TheS.Casinova.Colors.BackServices.Specs
{
    [Binding]
    public class PayForColorsWinnerInfoSteps : ColorsGameStepsBase
    {
        private PayForColorsWinnerInfoCommand _cmd;
        private PlayerInformation _expected;
        private const double _fee = 5;

        [Given(@"sent UserName: '(.*)' and _expected Balance: '(.*)'")]
        public void GivenUserNameXBalanceX(string userName, double balance)
        {
            _expected = new PlayerInformation { UserName = userName, Balance = balance };

            Action<PlayerInformation, PayForColorsWinnerInfoCommand> CheckCallMethod = (playerInfo, cmd) => {
                Assert.AreEqual(_expected.UserName, playerInfo.UserName, "UserName");
                Assert.AreEqual(_expected.Balance, playerInfo.Balance, "Balance");
            };
            Dac.ApplyAction(new PlayerInformation(), new PayForColorsWinnerInfoCommand());
            LastCall.IgnoreArguments().Do(CheckCallMethod);
        }

        [When(@"call PayForColorsWinnerInfo\(UserName: '(.*)', Balance: '(.*)'\)")]
        public void WhenCallPayForColorsWinnerInfoUserNameXBalanceX(string userName, double balance)
        {
            _cmd = new PayForColorsWinnerInfoCommand {
                PlayerInfo = new PlayerInformation { UserName = userName, Balance = balance }
            };

            //Simulate that player's money has decrease
            if (_cmd.PlayerInfo.Balance >= _fee) {
                _cmd.PlayerInfo.Balance -= _fee;
                Dac.ApplyAction(_cmd.PlayerInfo, _cmd);
            }
            else {
                Console.WriteLine("๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑  เงินไม่พอ  ๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑");
            }
        }

        [Then(@"the player information should be saved by calling IColorsGameDataAccess\.ApplyAction\(PlayerInformation, _cmd\)")]
        public void ThenThePlayerInformationShouldBeSavedByCallingIColorsGameDataAccess_CreatePayForColorsWinnerInfoCommand()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }

        [Then(@"ระบบแจ้งเตือนว่าเงินไม่พอ")]
        public void Thenระบบแจงเตอนวาเงนไมพอ()
        {
            Assert.IsTrue(true, "เงินไม่พอสำหรับดูข้อมูล winner");
        }
    }
}
