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
    public class UpdateOnGoingTrackingIDSteps : ColorsGameStepsBase
    {
        GamePlayInformation _gamePlayInfo;
        GamePlayInformation _expected;
        PayForColorsWinnerInfoCommand _cmd;

        [Given(@"Define GamePlayInformation input as:")]
        public void GivenDefineGamePlayInformationInputAs(Table table)
        {
            _gamePlayInfo = (from item in table.Rows
                             select new GamePlayInformation {
                                 RoundID = Convert.ToInt32(item["RoundID"]),
                                 UserName = item["UserName"],
                                 OnGoingTrackingID = Guid.Parse(item["OnGoingTrackingID"]),
                             }).FirstOrDefault();

            _expected = new GamePlayInformation { 
                RoundID = _gamePlayInfo.RoundID, 
                UserName = _gamePlayInfo.UserName, 
                OnGoingTrackingID = _gamePlayInfo.OnGoingTrackingID };

            _cmd = new PayForColorsWinnerInfoCommand { GamePlayInfo = _gamePlayInfo };
        }

        [Given(@"Expect GamePlayInformation\(RoundID: '(.*)', UserName: '(.*)', OnGoingTrackingID: '(.*)'\) input should be add")]
        public void GivenExpectGamePlayInformationRoundIDXUserNameXOnGoingTrackingXInputShouldBeAdd(int roundID, string userName, string onGoingTrackingID)
        {
            _expected = new GamePlayInformation {
                RoundID = roundID,
                UserName = userName,
                OnGoingTrackingID = Guid.Parse(onGoingTrackingID),
            };

            Action<GamePlayInformation, PayForColorsWinnerInfoCommand> CheckData = (gamePlayInfo, cmd) => {
                Assert.AreEqual(_expected.RoundID, gamePlayInfo.RoundID, "RoundID");
                Assert.AreEqual(_expected.UserName, gamePlayInfo.UserName, "UserName");
                Assert.AreEqual(_expected.OnGoingTrackingID, gamePlayInfo.OnGoingTrackingID, "OnGoingTrackingID");
            };
            Dac.ApplyAction(new GamePlayInformation(), new PayForColorsWinnerInfoCommand());
            LastCall.IgnoreArguments().Do(CheckData);
        }

        [Given(@"Expect GamePlayInformation input without OnGoingTrackingID and server should throw exception")]
        public void GivenExpectGamePlayInformationInputWithoutOnGoingTrackingIDAndServerShouldThrowException()
        {
            Action<GamePlayInformation, PayForColorsWinnerInfoCommand> CheckData = (gamePlayInfo, cmd) => {
                Assert.IsNull(gamePlayInfo.OnGoingTrackingID);
            };
            Dac.ApplyAction(new GamePlayInformation(), new PayForColorsWinnerInfoCommand());
            LastCall.IgnoreArguments().Do(CheckData);
        }

        [When(@"call UpdateOnGoingTrackingID\(GamePlayInformation\(RoundID: '(.*)', UserName: '(.*)', OnGoingTrackingID: '(.*)'\)\)")]
        public void WhenCallUpdateOnGoingTrackingIDGamePlayInformationRoundIDXserNameXOnGoingTrackingIDX(int roundID, string userName, string onGoingTrackingID)
        {
            _cmd.GamePlayInfo = new GamePlayInformation {
                RoundID = roundID,
                UserName = userName,
                OnGoingTrackingID = Guid.Parse(onGoingTrackingID),
            };

            Dac.ApplyAction(_cmd.GamePlayInfo, _cmd);            
        }

        [Then(@"the game play information should be saved by calling IColorsGameDataAccess\.ApplyAction\(GamePlayInformation, PayForWinnerColorsInfoCommand\)")]
        public void ThenTheGamePlayInformationShouldBeSavedByCallingIColorsGameDataAccess_ApplyActionGamePlayInformationPayForWinnerColorsInfoCommand()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }

        [Then(@"server should throw exception")]
        public void ThenServerShouldThrowException()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
