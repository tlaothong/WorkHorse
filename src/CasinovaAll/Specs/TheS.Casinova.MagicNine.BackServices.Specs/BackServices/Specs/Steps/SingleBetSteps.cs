using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.MagicNine.Models;
using Rhino.Mocks;
using TheS.Casinova.MagicNine.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheS.Casinova.PlayerProfile.Models;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.PlayerProfile.Commands;

namespace TheS.Casinova.MagicNine.BackServices.Specs.Steps
{
    [Binding]
    public class SingleBetSteps
        : MagicNineStepsBase
    {
        private IEnumerable<UserProfile> _playerProfiles;
        private IEnumerable<BetInformation> _betInfos;
        private IEnumerable<GameRoundInformation> _gameRoundInfos;
        private UserProfile _playerProfile;
        private double _gamePot;
        private GameRoundInformation _gameRoundInfo;

        [Given(@"\(SingleBet\)server has player information as:")]
        public void GivenSingleBetServerHasPlayerInformationAs(Table table)
        {
            _playerProfiles = (from item in table.Rows
                            select new UserProfile { 
                                UserName = item["UserName"],
                                Refundable = Convert.ToDouble(item["Refundable"]),
                                NonRefundable = Convert.ToDouble(item["NonRefundable"]),
                            });
        }

        [Given(@"\(SingleBet\)server has bet information as:")]
        public void GivenSingleBetServerHasBetInformationAs(Table table)
        {
            _betInfos = (from item in table.Rows
                         select new BetInformation {
                             RoundID = Convert.ToInt32(item["RoundID"]),
                             UserName = item["UserName"],
                             BetDateTime = DateTime.Parse(item["BetDateTime"]),
                         });
        }

        [Given(@"\(SingleBet\)server has game round information as:")]
        public void GivenSingleBetServerHasGameRoundInformationAs(Table table)
        {
            _gameRoundInfos = (from item in table.Rows
                               select new GameRoundInformation {
                                   RoundID = Convert.ToInt32(item["RoundID"]),
                                   WinnerPoint = Convert.ToDouble(item["WinnerPoint"]),
                               });
        }

        [Given(@"\(MagicNine_SingleBet\)sent name: '(.*)' the player's balance should recieved")]
        public void GivenMagicNine_SingleBetSentNameXThePlayerSBalanceShouldRecieved(string userName)
        {
            var _expectPlayerProfile = (from item in _playerProfiles
                                        where item.UserName == userName
                                        select item).FirstOrDefault();

            SetupResult.For(Dqr_GetPlayerInfo.Get(new GetPlayerInfoCommand()))
                .IgnoreArguments().Return(_expectPlayerProfile);

            _playerProfile = new UserProfile {
                UserName = _expectPlayerProfile.UserName,
                NonRefundable = _expectPlayerProfile.NonRefundable,
                Refundable = _expectPlayerProfile.Refundable,
            };
        }
        
        [Given(@"\(MagicNine_SingleBet\)sent roundID: '(.*)' the game pot should be calculate")]
        public void GivenMagicNine_SingleBetSentRoundIDXTheGamePotShouldBeCalculate(int roundID)
        {            
            var qry = (from item in _betInfos
                       where item.RoundID == roundID
                       select item);
            _gamePot = qry.Count();
            SetupResult.For(Dqr_GetGameRoundPot.Get(new GetGameRoundPotCommand()))
                .IgnoreArguments().Return(_gamePot);
        }

        [Given(@"\(MagicNine_SingleBet\)sent roundID: '(.*)' the game round information should recieved")]
        public void GivenMagicNine_SingleBetSentRoundIDXTheGameRoundInformationShouldRecieved(int roundID)
        {
            _gameRoundInfo = (from item in _gameRoundInfos
                              where item.RoundID == roundID
                              select item).FirstOrDefault();
            SetupResult.For(Dqr_GetGameRoundInfo.Get(new GetGameRoundInfoCommand()))
                .IgnoreArguments().Return(_gameRoundInfo);
        }

        [Given(@"\(MagicNine_SingleBet\)the player's balance should be update\(UserName: '(.*)', BonusChips: '(.*)', Chips: '(.*)'\)")]
        public void GivenMagicNine_SingleBetThePlayerSBalanceShouldBeUpdateUserNameKhagBonusChipsXChipsX(string userName, double bonusChips, double chips)
        {
            Action<UserProfile, UpdatePlayerInfoBalanceCommand> checkData = (userProfile, cmd) => {
                Assert.AreEqual(userName, userProfile.UserName, "UserName");
                Assert.AreEqual(bonusChips, userProfile.NonRefundable, "BonusChips");
                Assert.AreEqual(chips, userProfile.Refundable, "Chips");
            };
            Dac_UpdatePlayerInfoBalance.ApplyAction(new UserProfile(), new UpdatePlayerInfoBalanceCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }

        [Given(@"the bet information assume dateTime as: '(.*)'\(RoundID: '(.*)', UserName: '(.*)', TrackingID: '(.*)', DateTime: '(.*)'\) should be create")]
        public void GivenTheBetInformationAssumeDateTimeAsXRoundIDXUserNameXTrackingIDXDateTimeXShouldBeCreate(DateTime assumeDateTime, int roundID, string userName, string trackingID, DateTime dateTime)
        {
            Func<BetInformation, SingleBetCommand, BetInformation> checkData = (betInfo, cmd) => {
                Assert.AreEqual(roundID, betInfo.RoundID, "RoundID");
                Assert.AreEqual(userName, betInfo.UserName, "UserName");
                Assert.AreEqual(Guid.Parse(trackingID), betInfo.BetTrackingID, "BetTrackingID");

                //define datetime by assume datetime
                return betInfo;
            };

            Dac_SingleBet.Create(new BetInformation(), new SingleBetCommand());
            LastCall.IgnoreArguments().Do(checkData);
        }
       
        [Given(@"Expected ReturnRewardExecutor should be call\(UserName: '(.*)', NonRefundable: '(.*)', Refundable: '(.*)'\)")]
        public void GivenExpectedReturnRewardExecutorShouldBeCallUserNameXNonRefundableXRefundableX(string userName, double nonRefundable, double refundable)
        {
            Action<ReturnRewardCommand> checkData = (cmd) => {
                Assert.AreEqual(userName, cmd.UserProfile.UserName, "UserName");
                Assert.AreEqual(nonRefundable, cmd.UserProfile.NonRefundable, "NonRefundable");
                Assert.AreEqual(refundable, cmd.UserProfile.Refundable, "Refundable");
            };

            ReturnRewardExecutor.Execute(new ReturnRewardCommand(), (x) => { });
            LastCall.IgnoreArguments().Do(checkData);
        }

        [When(@"call SingleBetExecutor\(RoundID: '(.*)', UserName: '(.*)', TrackingID: '(.*)'\)")]
        public void WhenCallSingleBetExecutorRoundIDXUserNameXTrackingIDX(int roundID, string userName, string betTrackingID)
        {
            SingleBetCommand cmd = new SingleBetCommand {
                BetInfo = new BetInformation {
                    RoundID = roundID,
                    UserName = userName,
                    BetTrackingID = Guid.Parse(betTrackingID),
                },
            };

            SingleBetExecutor.Execute(cmd, (x) => { });
        }

        [When(@"Expected exception and call SingleBetExecutor\(RoundID: '(.*)', UserName: '(.*)', TrackingID: '(.*)'\)")]
        public void WhenExpectedExceptionAndCallSingleBetExecutorRoundIDXUserNameXTrackingIDX(int roundID, string userName, string betTrackingID)
        {
            try {
                SingleBetCommand cmd = new SingleBetCommand {
                    BetInfo = new BetInformation {
                        RoundID = roundID,
                        UserName = userName,
                        BetTrackingID = Guid.Parse(betTrackingID),
                    },
                };
                SingleBetExecutor.Execute(cmd, (x) => { });
                Assert.Fail("Shouldn't be here!");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex, typeof(ValidationErrorException));
            }
        }

        [Then(@"the result should be create")]
        public void ThenTheResultShouldBeCreate()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }

        [Then(@"the result should be throw exception")]
        public void ThenTheResultShouldBeThrowException()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
    }
}
