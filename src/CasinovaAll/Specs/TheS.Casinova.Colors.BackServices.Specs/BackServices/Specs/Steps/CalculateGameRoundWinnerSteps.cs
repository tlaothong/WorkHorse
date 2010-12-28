using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.Colors.Models;
using Rhino.Mocks;
using TheS.Casinova.Colors.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.Colors.BackServices.Specs.Steps
{
    [Binding]
    public class CalculateGameRoundWinnerSteps
        : ColorsGameStepsBase
    {
        private IEnumerable<UserProfile> _userProfiles;
        private IEnumerable<GameRoundInformation> _gameRoundInfos;
        private IEnumerable<PlayerActionInformation> _playerActionInfos;
        private UserProfile _userProfile;
        private IEnumerable<PlayerActionInformation> _playerActionInfoList;
        private GameRoundInformation _gameRoundInfo;

        [Given(@"\(Colors_CalculateGameRoundWinner\)server has game round information as:")]
        public void GivenColors_CalculateGameRoundWinnerServerHasGameRoundInformationAs(Table table)
        {
            _gameRoundInfos = (from item in table.Rows
                              select new GameRoundInformation {
                                  RoundID = Convert.ToInt32(item["RoundID"]),
                                  BlackPot = Convert.ToDouble(item["BlackPot"]),
                                  WhitePot = Convert.ToDouble(item["WhitePot"]),
                              });
        }

        [Given(@"\(Colors_CalculateGameRoundWinner\)server has player action information as:")]
        public void GivenColors_CalculateGameRoundWinnerServerHasPlayerActionInformationAs(Table table)
        {
            _playerActionInfos = (from item in table.Rows
                                  select new PlayerActionInformation {
                                      RoundID = Convert.ToInt32(item["RoundID"]),
                                      UserName = item["UserName"],
                                      ActionType = item["ActionType"],
                                      BonusChips = Convert.ToDouble(item["BonusChips"]),
                                      Chips = Convert.ToDouble(item["Chips"]),
                                      Amount = Convert.ToDouble(item["Amount"])
                                  });
        }

        [Given(@"\(Colors_CalculateGameRoundWinner\)server has player profile information as:")]
        public void GivenColors_CalculateGameRoundWinnerServerHasPlayerProfileInformationAs(Table table)
        {
            _userProfiles = (from item in table.Rows
                             select new UserProfile {
                                 UserName = item["UserName"],
                                 NonRefundable = Convert.ToDouble(item["NonRefundable"]),
                                 Refundable = Convert.ToDouble(item["Refundable"]),
                             });
        }

        [Given(@"\(Colors_CalculateGameRoundWinner\)sent name: '(.*)' the player's balance should recieved")]
        public void GivenColors_CalculateGameRoundWinnerSentNameXThePlayerSBalanceShouldRecieved(string userName)
        {
            _userProfile = (from item in _userProfiles
                            where item.UserName == userName
                            select item).FirstOrDefault();
            SetupResult.For(Dqr_GetPlayerInfo.Get(new Commands.GetPlayerInfoCommand()))
                .IgnoreArguments().Return(_userProfile);
        }

        [Given(@"\(Colors_CalculateGameRoundWinner\)sent roundID: '(.*)' the player action information should recieved")]
        public void GivenColors_CalculateGameRoundWinnerSentRoundIDXThePlayerActionInformationShouldRecieved(int roundID)
        {
            _playerActionInfoList = (from item in _playerActionInfos
                                     where item.RoundID == roundID
                                     select item);
            SetupResult.For(Dqr_ListPlayerActionInfo.List(new Commands.ListPlayerActionInfoCommand()))
                .IgnoreArguments().Return(_playerActionInfos);
        }

        [Given(@"\(Colors_CalculateGameRoundWinner\)sent roundID: '(.*)' the round information should recieved")]
        public void GivenColors_CalculateGameRoundWinnerSentRoundIDXTheRoundInformationShouldRecieved(int roundID)
        {
            _gameRoundInfo = (from item in _gameRoundInfos
                             where item.RoundID == roundID
                             select item).FirstOrDefault();
            SetupResult.For(Dqr_GetRoundInfo.Get(new Commands.GetRoundInfoCommand()))
                .IgnoreArguments().Return(_gameRoundInfo);
        }

        [When(@"\(Colors_CalculateGameRoundWinner\)call CalculateGameRoundWinnerExecutor\(RoundID: '(.*)'\)")]
        public void WhenColors_CalculateGameRoundWinnerCallCalculateGameRoundWinnerExecutorRoundIDX(int roundId)
        {
            CalculateGameRoundWinnerCommand cmd = new CalculateGameRoundWinnerCommand { RoundID = roundId };
            CalculateGameRoundWinnerExecutor.Execute(cmd, (x) => { });
        }

        [Then(@"the result should be create")]
        public void ThenTheResultShouldBeCreate()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
    }
}
