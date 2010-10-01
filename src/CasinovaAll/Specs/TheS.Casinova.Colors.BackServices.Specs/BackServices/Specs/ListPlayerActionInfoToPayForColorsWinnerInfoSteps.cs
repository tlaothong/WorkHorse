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
    public class ListPlayerActionInfoToPayForColorsWinnerInfoSteps 
        : ColorsGameStepsBase
    {
        private IEnumerable<PlayerActionInformation> _playerActionInfos;
        private IEnumerable<PlayerActionInformation> _result;
        private PayForColorsWinnerInfoCommand _cmd;

        [Given(@"server has player action information as:")]
        public void GivenServerHasPlayerActionInformationAs(Table table)
        {
            _playerActionInfos = (from item in table.Rows
                                  select new PlayerActionInformation {
                                      RoundID = Convert.ToInt32(item["RoundID"]),
                                      UserName = item["UserName"],
                                      ActionType = item["ActionType"],
                                  });
        }

        [Given(@"sent RoundID: '(.*)', UserName: '(.*)' and expected PlayerActionInfo\(s\) in server")]
        public void GivenSentRoundID12UserNameOhAeAndExpectedPlayerActionInfoSInServer(int roundID, string userName)
        {
            var result = (from item in _playerActionInfos
                       where item.RoundID == roundID
                       && item.UserName == userName
                       && item.ActionType == "GetWinner"
                       select item);

            SetupResult.For(Dqr_ListPlayerActionInfo.List(new PayForColorsWinnerInfoCommand()))
                .IgnoreArguments().Return(result);
        }

        [When(@"call List\(PayForColorsWinnerInfoCommand\), RoundID: '(.*)', UserName: '(.*)'")]
        public void WhenCallListPayForColorsWinnerInfoCommandRoundID12UserNameOhAe(int roundID, string userName)
        {
            _cmd = new PayForColorsWinnerInfoCommand {
                PlayerInfo = new PlayerInformation {
                    UserName = userName
                },
                GameRoundInfo = new GameRoundInformation {
                    RoundID = roundID
                },
            };
            _result = Dqr_ListPlayerActionInfo.List(_cmd);
        }

        [Then(@"player should have PlayerActionInfo on this round as:")]
        public void ThenPlayerShouldHavePlayerActionInfoOnThisRoundAs(Table table)
        {
            var expected = (from item in table.Rows
                            select new {
                                RoundID = Convert.ToInt32(item["RoundID"]),
                                UserName = item["UserName"],
                                ActionType = item["ActionType"],
                            }).ToArray();

            var actual = (from item in _result
                            select new {
                                RoundID = item.RoundID,
                                UserName = item.UserName,
                                ActionType = item.ActionType,
                            }).ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
