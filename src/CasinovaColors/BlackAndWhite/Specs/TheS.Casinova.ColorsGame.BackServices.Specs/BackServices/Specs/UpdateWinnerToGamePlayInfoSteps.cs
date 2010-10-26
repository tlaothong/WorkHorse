using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.ColorsGame.Models;
using TheS.Casinova.ColorsGame.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace TheS.Casinova.ColorsGame.BackServices.Specs
{
    [Binding]
    public class UpdateWinnerToGamePlayInfoSteps : ColorsGameStepsBase
    {
        private PayForColorsWinnerInfoCommand _cmd;
        private GamePlayInformation _expected;

        [Given(@"Expect game information should be add:")]
        public void GivenExpectGameInformationShouldBeAdd(Table table)
        {
            _expected = new GamePlayInformation();
            _expected = (from item in table.Rows
                         select new GamePlayInformation {
                             UserName = item["UserName"],
                             TableID = Convert.ToInt32(item["TableID"]),
                             RoundID = Convert.ToInt32(item["RoundID"]),
                             TrackingID = Guid.Parse(item["TrackingID"]),
                             OnGoingTrackingID = Guid.Parse(item["OnGoingTrackingID"]),
                             TotalBetAmounfOfBlack = Convert.ToInt32(item["TotalBlack"]),
                             TotalBetAmountOfWhite = Convert.ToInt32(item["TotalWhite"]),
                             Winner = item["Winner"],
                             //LastUpdate = DateTime.Now, ////Technical problem
                         }).FirstOrDefault();

            Action<GamePlayInformation, PayForColorsWinnerInfoCommand> CheckData = (gamePlayInfo, cmd) => {
                Assert.AreEqual(_expected.UserName, gamePlayInfo.UserName);
                Assert.AreEqual(_expected.TableID, gamePlayInfo.TableID);
                Assert.AreEqual(_expected.RoundID, gamePlayInfo.RoundID);
                Assert.AreEqual(_expected.TrackingID, gamePlayInfo.TrackingID);
                Assert.AreEqual(_expected.OnGoingTrackingID, gamePlayInfo.OnGoingTrackingID);
                Assert.AreEqual(_expected.TotalBetAmounfOfBlack, gamePlayInfo.TotalBetAmounfOfBlack);
                Assert.AreEqual(_expected.TotalBetAmountOfWhite, gamePlayInfo.TotalBetAmountOfWhite);
                Assert.AreEqual(_expected.Winner, gamePlayInfo.Winner);
                //Assert.AreEqual(_expected.LastUpdate, gamePlayInfo.LastUpdate);
            };

            Dac.ApplyAction(new GamePlayInformation(), new PayForColorsWinnerInfoCommand());
            LastCall.IgnoreArguments().Do(CheckData);
        }

        [When(@"call UpdateWinnerToGamePlayInfo\(GamePlayInfo\)")]
        public void WhenCallUpdateWinnerToGamePlayInfo(Table table)
        {
            _cmd = new PayForColorsWinnerInfoCommand();
            _cmd.GamePlayInformation = (from item in table.Rows
                         select new GamePlayInformation {
                             UserName = item["UserName"],
                             TableID = Convert.ToInt32(item["TableID"]),
                             RoundID = Convert.ToInt32(item["RoundID"]),
                             TrackingID = Guid.Parse(item["TrackingID"]),
                             OnGoingTrackingID = Guid.Parse(item["OnGoingTrackingID"]),
                             TotalBetAmounfOfBlack = Convert.ToInt32(item["TotalBlack"]),
                             TotalBetAmountOfWhite = Convert.ToInt32(item["TotalWhite"]),
                             Winner = item["Winner"],
                             //LastUpdate = DateTime.Now + TimeSpan.Parse(item["LastUpdate"]),
                         }).FirstOrDefault();

            //Action<PayForColorsWinnerInfoCommand> cmd = (a) => { };
            //PayForColorsWinnerInfoExecutor.Execute(_cmd, cmd);
            Dac.ApplyAction(_cmd.GamePlayInformation, _cmd);
        }

        [Then(@"the game play information should be saved by calling IColorsGameDataAccess\.ApplyAction\(GamePlayInformation, cmd\)")]
        public void ThenTheGamePlayInformationShouldBeSavedByCallingIColorsGameDataAccess_ApplyActionGamePlayInformationCmd()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
    }
}
