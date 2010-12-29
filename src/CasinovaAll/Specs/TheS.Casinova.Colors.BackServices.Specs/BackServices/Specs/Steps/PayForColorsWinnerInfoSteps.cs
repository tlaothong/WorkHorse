using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.Colors.Models;
using Rhino.Mocks;
using TheS.Casinova.Colors.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheS.Casinova.PlayerProfile.Models;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.Colors.BackServices.Specs
{
    [Binding]
    public class PayForColorsWinnerInfoSteps
        : ColorsGameStepsBase  
    {
        public UserProfile _expectPlayerProfile;
        public UserProfile _updatePlayerProfile;

        public IEnumerable<UserProfile> _playerProfiles;
        public IEnumerable<PlayerActionInformation> _playerActionInfos;
        public IEnumerable<GameRoundInformation> _RoundInfos;

        [Given(@"\(PayForcolorsWinnerInformation\)server has player profile information as:")]
        public void GivenPayForcolorsWinnerInformationServerHasPlayerProfileInformationAs(Table table)
        {
            _playerProfiles = (from item in table.Rows
                               select new UserProfile {
                                   UserName = item["UserName"],
                                   NonRefundable = Convert.ToDouble(item["NonRefundable"]),
                                   Refundable = Convert.ToDouble(item["Refundable"]),
                               });
        }

        [Given(@"\(PayForcolorsWinnerInformation\)server has player action informations as:")]
        public void GivenPayForcolorsWinnerInformationServerHasPlayerActionInformationsAs(Table table)
        {
            _playerActionInfos = (from item in table.Rows
                                  select new PlayerActionInformation {
                                      RoundID = Convert.ToInt32(item["RoundID"]),
                                      UserName = item["UserName"],
                                      ActionType = item["ActionType"],
                                  });
        }

        [Given(@"server has round informations as:")]
        public void GivenServerHasRoundInformationsAs(Table table)
        {
            _RoundInfos = (from item in table.Rows
                           select new GameRoundInformation {
                               RoundID = Convert.ToInt32(item["RoundID"]),
                               BlackPot = Convert.ToDouble(item["BlackPot"]),
                               WhitePot = Convert.ToDouble(item["WhitePot"]),
                           });
        }

        [Given(@"sent name: '(.*)' the player's balance should recieved")]
        public void GivenSentNameXThePlayerSBalanceShouldRecieved(string userName)
        {
            _expectPlayerProfile = (from item in _playerProfiles
                                 where item.UserName == userName
                                 select item).FirstOrDefault();

            SetupResult.For(Dqr_GetPlayerInfo.Get(new GetPlayerInfoCommand()))
                .IgnoreArguments().Return(_expectPlayerProfile);

            _updatePlayerProfile = new UserProfile { 
                UserName = _expectPlayerProfile.UserName,
                NonRefundable = _expectPlayerProfile.NonRefundable,
                Refundable = _expectPlayerProfile.Refundable,
            };
        }

        [Given(@"sent roundID: '(.*)', userName: '(.*)' the player's action information should recieved")]
        public void GivenSentRoundIDXUserNameXThePlayerSActionInformationShouldRecieved(int roundID, string userName)
        {
            var result = (from item in _playerActionInfos
                          where item.RoundID == roundID && item.UserName == userName && item.ActionType == "GetWinner"
                          select item);

            SetupResult.For(Dqr_ListPlayerActionInfo.List(new ListPlayerActionInfoCommand()))
                .IgnoreArguments().Return(result);
        }

        [Given(@"\(GetWinner\)the player's balance should be update only bonuschips, Amount: '(.*)'")]
        public void GivenGetWinnerThePlayerSBalanceShouldBeUpdateOnlyBonuschipsAmountX(double amount)
        {
            _updatePlayerProfile.NonRefundable -= amount;

            Action<UserProfile, UpdatePlayerInfoBalanceCommand> CheckCallMethod = (playerProfile, cmd) => {
                Assert.AreEqual(_updatePlayerProfile.UserName, playerProfile.UserName, "UserName");
                Assert.AreEqual(_updatePlayerProfile.Refundable, playerProfile.Refundable, "Refundable");
                Assert.AreEqual(_updatePlayerProfile.NonRefundable, playerProfile.NonRefundable, "NonRefundable");
            };

            Dac_UpdatePlayerInfoBalance.ApplyAction(new UserProfile(), new UpdatePlayerInfoBalanceCommand());
            LastCall.IgnoreArguments().Do(CheckCallMethod);
        }

        [Given(@"\(GetWinner\)the player's balance should be update both chips, Amount: '(.*)'")]
        public void GivenGetWinnerThePlayerSBalanceShouldBeUpdateBothChipsAmountX(double amount)
        {
            _updatePlayerProfile.Refundable -= amount - _updatePlayerProfile.NonRefundable;
            _updatePlayerProfile.NonRefundable = 0;

            Action<UserProfile, UpdatePlayerInfoBalanceCommand> CheckCallMethod = (playerProfile, cmd) => {
                Assert.AreEqual(_updatePlayerProfile.UserName, playerProfile.UserName, "UserName");
                Assert.AreEqual(_updatePlayerProfile.Refundable, playerProfile.Refundable, "Refundable");
                Assert.AreEqual(_updatePlayerProfile.NonRefundable, playerProfile.NonRefundable, "NonRefundable");
            };

            Dac_UpdatePlayerInfoBalance.ApplyAction(new UserProfile(), new UpdatePlayerInfoBalanceCommand());
            LastCall.IgnoreArguments().Do(CheckCallMethod);
        }

        [Given(@"the expected update balance should be BonusChips: '(.*)', Chips: '(.*)'")]
        public void GivenTheExpectedUpdateBalanceShouldBeX(double bounusChips, double chips)
        {
            Action<UserProfile, UpdatePlayerInfoBalanceCommand> CheckCallMethod = (playerProfile, cmd) => {
                Assert.AreEqual(_expectPlayerProfile.UserName, playerProfile.UserName, "UserName");
                Assert.AreEqual(_expectPlayerProfile.Refundable, playerProfile.Refundable, "Refundable");
                Assert.AreEqual(_expectPlayerProfile.NonRefundable, playerProfile.NonRefundable, "NonRefundable");
            };

            Dac_UpdatePlayerInfoBalance.ApplyAction(new UserProfile(), new UpdatePlayerInfoBalanceCommand());
            LastCall.IgnoreArguments().Do(CheckCallMethod);
        }

        [Given(@"the player's action information\(RoundID: '(.*)', UserName: '(.*)', ActionType: '(.*)', Amount: '(.*)'\) should be create")]
        public void GivenThePlayerSActionInformationRoundIDXUserNameXActionTypeXAmountXShouldBeCreate(int roundID, string userName, string actionType, double amount)
        {
            PlayerActionInformation _expected = new PlayerActionInformation {
                RoundID = roundID,
                UserName = userName,
                ActionType = actionType,
                Amount = amount,
            };

            Func<PlayerActionInformation, CreatePlayerActionInfoCommand, PlayerActionInformation> CheckData = (playerActionInfo, cmd) => {
                Assert.AreEqual(_expected.RoundID, playerActionInfo.RoundID, "RoundID");
                Assert.AreEqual(_expected.UserName, playerActionInfo.UserName, "UserName");
                Assert.AreEqual(_expected.ActionType, playerActionInfo.ActionType, "ActionType");
                Assert.AreEqual(_expected.Amount, playerActionInfo.Amount, "Amount");

                return playerActionInfo;
            };
            Dac_CreatePlayerActionInfo.Create(new PlayerActionInformation(), new CreatePlayerActionInfoCommand());
            LastCall.IgnoreArguments().Do(CheckData);
        }

        [Given(@"the game play information\(RoundID: '(.*)', UserName: '(.*)', OnGoingTrackingID: '(.*)'\) should be update")]
        public void GivenTheGamePlayInformationRoundIDXUserNameXOnGoingTrackingIDXShouldBeUpdate(int roundID, string userName, string onGoingTrackingID)
        {
            GamePlayInformation _expected = new GamePlayInformation {
                RoundID = roundID,
                UserName = userName,
                OnGoingTrackingID = Guid.Parse(onGoingTrackingID),
            };

            Action<GamePlayInformation, UpdateOnGoingTrackingIDCommand> CheckData = (gamePlayInfo, cmd) => {
                Assert.AreEqual(_expected.RoundID, gamePlayInfo.RoundID, "RoundID");
                Assert.AreEqual(_expected.UserName, gamePlayInfo.UserName, "UserName");
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

        [Given(@"the game play information\(RoundID: '(.*)', UserName: '(.*)', TrackingID: '(.*)', Winner: '(.*)'\) should be update")]
        public void GivenTheGamePlayInformationRoundIDXUserNameXTrackingIDXShouldBeUpdate(int roundID, string userName, string trackingID, string winner)
        {
            GamePlayInformation _expected = new GamePlayInformation {
                RoundID = roundID,
                UserName = userName,
                Winner = winner,
                TrackingID = Guid.Parse(trackingID),
            };

            Action<GamePlayInformation, UpdateRoundWinnerCommand> CheckData = (gamePlayInfo, cmd) => {
                Assert.AreEqual(_expected.RoundID, gamePlayInfo.RoundID, "RoundID");
                Assert.AreEqual(_expected.UserName, gamePlayInfo.UserName, "UserName");
                Assert.AreEqual(_expected.Winner, gamePlayInfo.Winner, "Winner");
                Assert.AreEqual(_expected.TrackingID, gamePlayInfo.TrackingID, "TrackingID");
            };

            Dac_UpdateRoundWinner.ApplyAction(new GamePlayInformation(), new UpdateRoundWinnerCommand());
            LastCall.IgnoreArguments().Do(CheckData);
        }

        [When(@"call PayForColorsWinnerInfo\(UserName: '(.*)', RoundID: '(.*)', OnGoingTrackingID: '(.*)'\)")]
        public void WhenCallPayForColorsWinnerInfoUserNameXRoundIDXOnGoingTrackingIDX(string userName, int roundID, string onGoingTrackingID)
        {
            PayForColorsWinnerInfoCommand cmd = new PayForColorsWinnerInfoCommand {
                PlayerActionInfo = new PlayerActionInformation {
                    UserName = userName,
                    RoundID = roundID,
                },
                OnGoingTrackingID = Guid.Parse(onGoingTrackingID),
            };
            PayForColorsWinnerInfoExecutor.Execute(cmd, (x) => { });
        }

        [When(@"Expected validation exception and call PayForColorsWinnerInfo\(UserName: '(.*)', RoundID: '(.*)', OnGoingTrackingID: '(.*)'\)")]
        public void WhenExpectedValidationExceptionAndCallPayForColorsWinnerInfoUserNameXRoundIDXOnGoingTrackingIDX(string userName, int roundID, string onGoingTrackingID)
        {
            try {
                PayForColorsWinnerInfoCommand cmd = new PayForColorsWinnerInfoCommand {
                    PlayerActionInfo = new PlayerActionInformation {
                        UserName = userName,
                        RoundID = roundID,
                    },
                    OnGoingTrackingID = Guid.Parse(onGoingTrackingID),                    
                };
                PayForColorsWinnerInfoExecutor.Execute(cmd, (x) => { });
                Assert.Fail("Shouldn't be here!");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex, 
                    typeof(ValidationErrorException));
            }
        }

        [Then(@"the update player's balance part should be updated")]
        public void ThenTheUpdatePlayerSBalancePartShouldBeUpdated()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
    }
}
