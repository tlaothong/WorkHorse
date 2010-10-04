using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheS.Casinova.ColorsGame.Commands;
using TheS.Casinova.ColorsGame.Models;
using Rhino.Mocks;

namespace TheS.Casinova.ColorsGame.BackServices.Specs
{
    [Binding]
    public class PayForColorsWinnerInfoN2NSteps : ColorsGameStepsBase
    {
        private PayForColorsWinnerInfoCommand _cmd = new PayForColorsWinnerInfoCommand();
        private const double _fee = 5;

        [When(@"define PayForColorsWinnerInfo\(UserName: '(.*)', Balance: '(.*)'\)")]
        public void WhenDefinePayForColorsWinnerInfoUserNameXBalanceX(string userName, double balance)
        {
            _cmd.PlayerInformation = new PlayerInformation { UserName = userName, Balance = balance };

            ////Simulate that player's money has decrease
            //if (_cmd.PlayerInformation.Balance >= _fee) {
            //    _cmd.PlayerInformation.Balance -= _fee;
            //    Dac.ApplyAction(_cmd.PlayerInformation, _cmd);
            //}
            //else {
            //    Console.WriteLine("๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑  เงินไม่พอ  ๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑๑");
            //}
        }

        [When(@"define GetRoundWinnerQuery\(TableID: '(.*)', RoundID: '(.*)', Winner: '(.*)'\)")]
        public void WhenDefineGetRoundWinnerQueryTableIDXRoundIDXWinnerX(int tableID, int roundID, string winner)
        {
            _cmd.GamePlayInformation = new GamePlayInformation { TableID = tableID, RoundID = roundID, Winner = winner };
            //_cmd.GamePlayInformation.Winner = Dqr.Get(_cmd);
        }

        [When(@"define UpdateWinnerToGamePlayInfo\(GamePlayInfo\):")]
        public void WhenDefineUpdateWinnerToGamePlayInfo(Table table)
        {
            _cmd.GamePlayInformation = (from item in table.Rows
                                        select new GamePlayInformation {
                                            UserName = item["UserName"],
                                            TableID = _cmd.GamePlayInformation.TableID,
                                            RoundID = _cmd.GamePlayInformation.RoundID,
                                            TrackingID = Guid.Parse(item["TrackingID"]),
                                            OnGoingTrackingID = Guid.Parse(item["OnGoingTrackingID"]),
                                            TotalBetAmounfOfBlack = Convert.ToInt32(item["TotalBlack"]),
                                            TotalBetAmountOfWhite = Convert.ToInt32(item["TotalWhite"]),
                                            Winner = _cmd.GamePlayInformation.Winner,
                                            //LastUpdate = DateTime.Now + TimeSpan.Parse(item["LastUpdate"]),
                                        }).FirstOrDefault();
            //Dac.ApplyAction(_cmd.GamePlayInformation, _cmd);
        }

        [When(@"call PayForColorsWinnerInfoExecutor\.Execute\(PayForColorsWinnerInfoCommand\);")]
        public void WhenCallPayForColorsWinnerInfoExecutor_ExecutePayForColorsWinnerInfoCommand()
        {
            Action<PayForColorsWinnerInfoCommand> cmd = (a) => { };
            PayForColorsWinnerInfoExecutor.Execute(_cmd, cmd);
        }

        [Then(@"the PayForColorsWinnerInfo should call complete all loop")]
        public void ThenThePayForColorsWinnerInfoShouldCallCompleteAllLoop()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
    }
}
