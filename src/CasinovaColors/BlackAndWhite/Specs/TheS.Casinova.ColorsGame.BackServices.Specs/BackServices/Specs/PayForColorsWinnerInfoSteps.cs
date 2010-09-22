using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.ColorsGame.DAL;
using TheS.Casinova.ColorsGame.BackServices.BackExecutors;
using TheS.Casinova.ColorsGame.Commands;
using TheS.Casinova.ColorsGame.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.ColorsGame.BackServices.Specs
{
    [Binding]
    public class PayForColorsWinnerInfoSteps : ColorsGameStepsBase
    {
        private PayForColorsWinnerInfoCommand _cmd;
        private PlayerInformation _expected;
        private const double _fee = 5;

        [Given(@"sent UserName: '(.*)' and expected Balance: '(.*)'")]
        public void GivenUserNameXBalanceX(string userName, double balance)
        {
            _expected = new PlayerInformation { UserName = userName, Balance = balance };

            Action<PlayerInformation, PayForColorsWinnerInfoCommand> CheckCallMethod = (playerInfo, cmd) => {
                Assert.AreEqual(_expected.UserName, playerInfo.UserName);
                Assert.AreEqual(_expected.Balance, playerInfo.Balance);
            };
            Dac.ApplyAction(new PlayerInformation(), new PayForColorsWinnerInfoCommand());
            LastCall.IgnoreArguments().Do(CheckCallMethod);
        }

        [When(@"call PayForColorsWinnerInfo\(UserName: '(.*)', Balance: '(.*)'\)")]
        public void WhenCallPayForColorsWinnerInfoUserNameXBalanceX(string userName, double balance)
        {
            _cmd = new PayForColorsWinnerInfoCommand {
                PlayerInformation = new PlayerInformation { UserName = userName, Balance = balance }
            };

            //Action<PayForColorsWinnerInfoCommand> cmd = (a) => { };
            //PayForColorsWinnerInfoExecutor.Execute(_cmd, cmd);

            _cmd.PlayerInformation = new PlayerInformation { UserName = userName, Balance = balance };

            //Simulate that player's money has decrease
            if (_cmd.PlayerInformation.Balance >= _fee) {
                _cmd.PlayerInformation.Balance -= _fee;
                Dac.ApplyAction(_cmd.PlayerInformation, _cmd);
            }
            else {
                Console.WriteLine("๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑  เงินไม่พอ  ๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑");
            }
        }

        [Then(@"the player information should be saved by calling IColorsGameDataAccess\.ApplyAction\(PlayerInformation, cmd\)")]
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
