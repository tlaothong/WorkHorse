using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.MagicNine.Models;
using Rhino.Mocks;
using TheS.Casinova.MagicNine.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.MagicNine.BackServices.Specs.Steps
{
    [Binding]
    public class SingleBetSteps
        : MagicNineStepsBase
    {
        private IEnumerable<PlayerInformation> _playerInfos;
        private IEnumerable<GameRoundInformation> _gameRoundInfos;

        [Given(@"server has player information as:")]
        public void GivenServerHasPlayerInformationAs(Table table)
        {
            _playerInfos = (from item in table.Rows
                            select new PlayerInformation { 
                                UserName = item["UserName"],
                                Balance = Convert.ToDouble(item["Balance"]),
                            });
        }

        [Given(@"server has game round information as:")]
        public void GivenServerHasGameRoundInformationAs(Table table)
        {
            _gameRoundInfos = (from item in table.Rows
                               select new GameRoundInformation { 
                                   Round = Convert.ToInt32(item["Round"]),
                                   //StartTime = DateTime.Parse(item["StartTime"]),
                                   //EndTime = DateTime.Parse(item["EndTime"]), null value
                                   //GamePot = Convert.ToInt32(item["GamePot"]),
                                   WinnerPoint = Convert.ToInt32(item["WinnerPoint"]),
                                   Active = Convert.ToBoolean(item["Active"]),
                               });
        }

        [Given(@"sent Round: '(.*)' the round pot should recieved")]
        public void GivenSentRoundIDXTheRoundPotShouldRecieved(int roundID)
        {
            //var qry = (from item in _gameRoundInfos
            //           where item.Round == roundID
            //           select item.GamePot).FirstOrDefault();

            //SetupResult.For(Dqr_GetGameRoundPot.Get(new GetGameRoundPotCommand()))
            //    .IgnoreArguments().Return(qry);
            ScenarioContext.Current.Pending();
        }

        [Given(@"sent name: '(.*)' the player's balance should recieved")]
        public void GivenSentNameOhAeThePlayerSBalanceShouldRecieved(string userName)
        {
            var qry = (from item in _playerInfos
                       where item.UserName == userName
                       select item).FirstOrDefault();

            SetupResult.For(Dqr_GetPlayerInfo.Get(new GetPlayerInfoCommand()))
                .IgnoreArguments().Return(qry);            
        }

        [Given(@"the expected balance should be: '(.*)'")]
        public void GivenTheExpectedBalanceShouldBeX(double expectBalance)
        {
            Action<PlayerInformation, UpdatePlayerInfoBalanceCommand> checkData = (playerInfo, cmd) => 
            {
                Assert.AreEqual(expectBalance, playerInfo.Balance, "Balance");
            };

            Dac_UpdatePlayerInfoBalance.ApplyAction(new PlayerInformation(), new UpdatePlayerInfoBalanceCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [Given(@"the round information\(Round: '(.*)', GamePot: '(.*)'\) should be update")]
        public void GivenTheRoundInformationRoundIDXGamePotXShouldBeUpdate(int roundID, int gamePot)
        {
            Action<GameRoundInformation, UpdateGameRoundPotCommand> checkData = (gameRoundInfo, cmd) => 
            {
                Assert.AreEqual(roundID, gameRoundInfo.Round, "Round");
                //Assert.AreEqual(gamePot, gameRoundInfo.GamePot, "GamePot");
            };

            Dac_UpdateGameRoundPot.ApplyAction(new GameRoundInformation(), new UpdateGameRoundPotCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [Given(@"the bet information\(Round: '(.*)', UserName: '(.*)', BetOrder: '(.*)', BetTrackingID: '(.*)'\) should be create")]
        public void GivenTheBetInformationRoundIDXUserNameXTrackingIDXShouldBeCreate(int roundID, string userName, int betOrder, string trackingID)
        {
            Func<BetInformation, SingleBetCommand, BetInformation> checkData = (betInfo, cmd) => 
            {
                Assert.AreEqual(roundID, betInfo.Round, "Round");
                Assert.AreEqual(userName, betInfo.UserName, "UserName");
                Assert.AreEqual(betOrder, betInfo.BetOrder, "BetOrder");
                Assert.AreEqual(Guid.Parse(trackingID), betInfo.BetTrackingID, "BetTrackingID");
                return betInfo;
            };

            Dac_SingleBet.Create(new BetInformation(), new SingleBetCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [Given(@"the expected balance less than bet cost")]
        public void GivenTheExpectedBalanceLessThanBetCost()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"call SingleBet\(Round: '(.*)', UserName: '(.*)', BetTrackingID: '(.*)'\)")]
        public void WhenCallSingleBetRoundIDXUserNameXTrackingIDX(int roundID, string userName, string trackingID)
        {
            SingleBetCommand cmd = new SingleBetCommand {
                BetInfo = new BetInformation {
                    Round = roundID,
                    UserName = userName,
                    BetTrackingID = Guid.Parse(trackingID),
                }
            };

            SingleBetExecutor.Execute(cmd, (x) => { });
        }

        [Then(@"the result should be create")]
        public void ThenTheResultShouldBeCreate()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }

        [Then(@"server should throw an error")]
        public void ThenServerShouldThrowAnError()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
