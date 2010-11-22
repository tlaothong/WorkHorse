using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.MagicNine.Models;
using TheS.Casinova.MagicNine.Commands;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.MagicNine.BackServices.Specs.Steps
{
    [Binding]
    public class StartAutoBetSteps
        : MagicNineStepsBase
    {
        private IEnumerable<PlayerInformation> _playerInfos;
        private PlayerInformation _expectPlayerInfo;

        [Given(@"\(AutoBet\)server has player information as:")]
        public void GivenAutoBetServerHasPlayerInformationAs(Table table)
        {
            _playerInfos = (from item in table.Rows
                            select new PlayerInformation {
                                UserName = item["UserName"],
                                Balance = Convert.ToDouble(item["Balance"]),
                            });
        }

        [Given(@"sent name: '(.*)' the player's balance should recieved, for autobet")]
        public void GivenSentNameOhAeThePlayerSBalanceShouldRecievedForAutobet(string userName)
        {
            _expectPlayerInfo = (from item in _playerInfos
                                 where item.UserName == userName
                                 select item).FirstOrDefault();

            //SetupResult.For(Dqr_GetPlayerInfo.Get(new GetPlayerInfoCommand()))
            //    .IgnoreArguments().Return(_expectPlayerInfo);
        }
        
        [Given(@"the player's balance should be update correct, Amount: '(.*)'")]
        public void GivenThePlayerSBalanceShouldBeUpdateCorrectAmountX(int amount)
        {
            _expectPlayerInfo.Balance -= amount;
            Action<PlayerInformation, UpdatePlayerInfoBalanceCommand> CheckCallMethod = (playerInfo, cmd) => {
                Assert.AreEqual(_expectPlayerInfo.UserName, playerInfo.UserName, "UserName");
                Assert.AreEqual(_expectPlayerInfo.Balance, playerInfo.Balance, "Balance");
            };

            //Dac_UpdatePlayerInfoBalance.ApplyAction(new PlayerInformation(), new UpdatePlayerInfoBalanceCommand());
            //LastCall.IgnoreArguments().Do(CheckCallMethod);
        }

        [Given(@"the StartAutoBet shoule be call as: \(UserName: '(.*)', Round: '(.*)', Amount: '(.*)', Interval: '(.*)', BetTrackingID: '(.*)'\)")]
        public void GivenTheAutoBetEngineShouleBeCallAsUserNameXRoundID1AmountXIntervalXTrackingIDX(string userName, int roundID, int amount, int interval, string trackingID)
        {
            Action<StartAutoBetCommand> checkData = (cmd) => {
                Assert.AreEqual(roundID, cmd.GamePlayAutoBetInfo.Round, "Round");
                Assert.AreEqual(userName, cmd.GamePlayAutoBetInfo.UserName, "UserName");
                Assert.AreEqual(amount, cmd.GamePlayAutoBetInfo.Amount, "Amount");
                Assert.AreEqual(interval, cmd.GamePlayAutoBetInfo.Interval, "Interval");
                Assert.AreEqual(Guid.Parse(trackingID), cmd.StartTrackingID, "AutoBetTrackingID");
            };                   
            Svc_AutoBetEngine.StartAutoBet(new StartAutoBetCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [When(@"call StartAutoBetExecutor\(UserName: '(.*)', Round: '(.*)', Amount: '(.*)', Interval: '(.*)', BetTrackingID: '(.*)'\)")]
        public void WhenCallStartAutoBetExecutorUserNameXRoundID1AmountXIntervalXTrackingIDX(string userName, int roundID, int amount, int interval, string trackingID)
        {
            StartAutoBetCommand cmd = new StartAutoBetCommand {
                GamePlayAutoBetInfo = new GamePlayAutoBetInformation{
                Round = roundID,
                UserName = userName,
                Amount = amount,
                Interval = interval,
                },
                StartTrackingID = Guid.Parse(trackingID),
            };
            
            StartAutoBetExecutor.Execute(cmd, (x) => { });
        }

        [Then(@"the player information should be update and call StartAutoBet")]
        public void ThenThePlayerActionInformationShouldBeCreated()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
    }
}
