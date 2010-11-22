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
    public class PayForColorsWinnerInfoSteps
        : ColorsGameStepsBase  
    {
        public PlayerInformation _expectPlayerInfo;

        public IEnumerable<PlayerInformation> _playerInfos;
        public IEnumerable<PlayerActionInformation> _playerActionInfos;
        public IEnumerable<GameRoundInformation> _RoundInfos;

        [Given(@"server has player information as:")]
        public void GivenServerHasPlayerInformationAs(Table table)
        {
            _playerInfos = (from item in table.Rows
                            select new PlayerInformation {
                                UserName = item["UserProfileBalance"],
                                Balance = Convert.ToDouble(item["Balance"]),
                            });
        }

        [Given(@"server has player action informations as:")]
        public void GivenServerHasPlayerActionInformationsAs(Table table)
        {
            _playerActionInfos = (from item in table.Rows
                                  select new PlayerActionInformation {
                                      RoundID = Convert.ToInt32(item["GameRoundInfoRoundID"]),
                                      UserName = item["UserProfileBalance"],
                                      ActionType = item["ActionType"],
                                  });
        }

        [Given(@"server has round informations as:")]
        public void GivenServerHasRoundInformationsAs(Table table)
        {
            _RoundInfos = (from item in table.Rows
                           select new GameRoundInformation {
                               RoundID = Convert.ToInt32(item["GameRoundInfoRoundID"]),
                               BlackPot = Convert.ToDouble(item["BlackPot"]),
                               WhitePot = Convert.ToDouble(item["WhitePot"]),
                           });
        }

        [Given(@"sent name: '(.*)' the player's balance should recieved")]
        public void GivenSentNameXThePlayerSBalanceShouldRecieved(string userName)
        {
            _expectPlayerInfo = (from item in _playerInfos
                                 where item.UserName == userName
                                 select item).FirstOrDefault();

            SetupResult.For(Dqr_GetPlayerInfo.Get(new GetPlayerInfoCommand()))
                .IgnoreArguments().Return(_expectPlayerInfo);
        }

        [Given(@"sent roundID: '(.*)', userName: '(.*)' the player's action information should recieved")]
        public void GivenSentRoundIDXUserNameXThePlayerSActionInformationShouldRecieved(int roundID, string userName)
        {
            var result = (from item in _playerActionInfos
                          where item.RoundID == roundID && item.UserName == userName && item.ActionType == "GetWinner"
                          select item);

            SetupResult.For(Dqr_ListPlayerActionInfo.List(new PayForColorsWinnerInfoCommand()))
                .IgnoreArguments().Return(result);
        }

        [Given(@"the expected balance should be: '(.*)'")]
        public void GivenTheExpectedBalanceShouldBeX(double balance)
        {            
            Action<PlayerInformation, UpdatePlayerInfoBalanceCommand> CheckCallMethod = (playerInfo, cmd) => {
                Assert.AreEqual(_expectPlayerInfo.UserName, playerInfo.UserName, "UserProfileBalance");
                Assert.AreEqual(balance, playerInfo.Balance, "Balance");
            };

            Dac_UpdatePlayerInfoBalance.ApplyAction(new PlayerInformation(), new UpdatePlayerInfoBalanceCommand());
            LastCall.IgnoreArguments().Do(CheckCallMethod);
        }

        [Given(@"the player's action information\(GameRoundInfoRoundID: '(.*)', UserProfileBalance: '(.*)', ActionType: '(.*)', Amount: '(.*)'\) should be create")]
        public void GivenThePlayerSActionInformationRoundIDXUserNameXActionTypeXAmountXShouldBeCreate(int roundID, string userName, string actionType, double amount)
        {
            PlayerActionInformation _expected = new PlayerActionInformation {
                RoundID = roundID,
                UserName = userName,
                ActionType = actionType,
                Amount = amount,
            };

            Func<PlayerActionInformation, CreatePlayerActionInfoCommand, PlayerActionInformation> CheckData = (playerActionInfo, cmd) => {
                Assert.AreEqual(_expected.RoundID, playerActionInfo.RoundID, "GameRoundInfoRoundID");
                Assert.AreEqual(_expected.UserName, playerActionInfo.UserName, "UserProfileBalance");
                Assert.AreEqual(_expected.ActionType, playerActionInfo.ActionType, "ActionType");
                Assert.AreEqual(_expected.Amount, playerActionInfo.Amount, "Amount");

                return playerActionInfo;
            };
            Dac_CreatePlayerActionInfo.Create(new PlayerActionInformation(), new CreatePlayerActionInfoCommand());
            LastCall.IgnoreArguments().Do(CheckData);
        }

        [Given(@"the game play information\(GameRoundInfoRoundID: '(.*)', UserProfileBalance: '(.*)', OnGoingTrackingID: '(.*)'\) should be update")]
        public void GivenTheGamePlayInformationRoundIDXUserNameXOnGoingTrackingIDXShouldBeUpdate(int roundID, string userName, string onGoingTrackingID)
        {
            GamePlayInformation _expected = new GamePlayInformation {
                RoundID = roundID,
                UserName = userName,
                OnGoingTrackingID = Guid.Parse(onGoingTrackingID),
            };

            Action<GamePlayInformation, UpdateOnGoingTrackingIDCommand> CheckData = (gamePlayInfo, cmd) => {
                Assert.AreEqual(_expected.RoundID, gamePlayInfo.RoundID, "GameRoundInfoRoundID");
                Assert.AreEqual(_expected.UserName, gamePlayInfo.UserName, "UserProfileBalance");
                Assert.AreEqual(_expected.OnGoingTrackingID, gamePlayInfo.OnGoingTrackingID, "OnGoingTrackingID");
            };
            Dac_UpdateOnGoingTrackingID.ApplyAction(new GamePlayInformation(), new UpdateOnGoingTrackingIDCommand());
            LastCall.IgnoreArguments().Do(CheckData);
        }

        [Given(@"sent roundID: '(.*)' the round information should recieved")]
        public void GivenSentRoundIDXTheRoundInformationShouldRecieved(int roundID)
        {
            var result = (from item in _RoundInfos
                          where item.RoundID == roundID
                          select item).FirstOrDefault();

            SetupResult.For(Dqr_GetRoundInfo.Get(new GetRoundInfoCommand()))
                .IgnoreArguments().Return(result);
        }

        [Given(@"the game play information\(GameRoundInfoRoundID: '(.*)', UserProfileBalance: '(.*)', BetTrackingID: '(.*)', Winner: '(.*)'\) should be update")]
        public void GivenTheGamePlayInformationRoundIDXUserNameXTrackingIDXShouldBeUpdate(int roundID, string userName, string trackingID, string winner)
        {
            GamePlayInformation _expected = new GamePlayInformation {
                RoundID = roundID,
                UserName = userName,
                Winner = winner,
                TrackingID = Guid.Parse(trackingID),
            };

            Action<GamePlayInformation, UpdateRoundWinnerCommand> CheckData = (gamePlayInfo, cmd) => {
                Assert.AreEqual(_expected.RoundID, gamePlayInfo.RoundID, "GameRoundInfoRoundID");
                Assert.AreEqual(_expected.UserName, gamePlayInfo.UserName, "UserProfileBalance");
                Assert.AreEqual(_expected.Winner, gamePlayInfo.Winner, "Winner");
                Assert.AreEqual(_expected.TrackingID, gamePlayInfo.TrackingID, "BetTrackingID");
            };

            Dac_UpdateRoundWinner.ApplyAction(new GamePlayInformation(), new UpdateRoundWinnerCommand());
            LastCall.IgnoreArguments().Do(CheckData);
        }

        [When(@"call PayForColorsWinnerInfo\(UserProfileBalance: '(.*)', GameRoundInfoRoundID: '(.*)', OnGoingTrackingID: '(.*)'\)")]
        public void WhenCallPayForColorsWinnerInfoUserNameXRoundIDXOnGoingTrackingIDX(string userName, int roundID, string onGoingTrackingID)
        {
            PayForColorsWinnerInfoCommand cmd = new PayForColorsWinnerInfoCommand {
                PlayerActionInfoUserName = new PlayerActionInformation {
                    UserName = userName,
                    RoundID = roundID,
                    TrackingID = Guid.Parse(onGoingTrackingID),
                }
            };
            PayForColorsWinnerInfoExecutor.Execute(cmd, (x) => { });
        }

        [Then(@"the update player's balance part should be updated")]
        public void ThenTheUpdatePlayerSBalancePartShouldBeUpdated()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
    }
}
