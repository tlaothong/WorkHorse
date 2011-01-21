using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.DevilSix.Commands;
using TheS.Casinova.DevilSix.Models;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.DevilSix.WebExecutors.Specs.Steps
{
    [Binding]
    public class ListSingleActionLogSteps : DevilSixGameStepsBase
    {
        private ListSingleActionLogCommand _cmd;
        private IEnumerable<BetInformation> _actionLogInfo;
        private IEnumerable<BetInformation> _listActionLogInfo;
        private IEnumerable<GameRoundInformation> _gameRoundInfo;
        private GameRoundInformation _getGameRound;

        [Given(@"Server has single action log information")]
        public void GivenServerHasSingleActionLogInformation(Table table)
        {
            _actionLogInfo = from item in table.Rows
                             select new BetInformation { 
                                 RoundID = Convert.ToInt32(item["RoundID"]),
                                 UserName = Convert.ToString(item["UserName"]),
                                 Amount = Convert.ToDouble(item["Amount"]),
                                 BetOrder = Convert.ToInt32(item["BetOrder"]),
                                 BetDateTime = DateTime.Parse(item["BetDateTime"])
                             };
        }

        [Given(@"Server has game round information")]
        public void GivenServerHasGameRoundInformation(Table table)
        {
            _gameRoundInfo = from item in table.Rows
                             select new GameRoundInformation {
                                 RoundID = Convert.ToInt32(item["RoundID"]),
                                 WinnerPoint = Convert.ToInt32(item["WinnerPoint"])
                             };
        }

        [Given(@"Sent RoundID'(.*)' DateTime'(.*)' the single action log should recieved")]
        public void GivenSentRoundIDXDateTimeXTheSingleActionLogShouldRecieved(int roundId, DateTime dateTime)
        {
            _getGameRound = (from item in _gameRoundInfo
                             where item.RoundID == roundId
                             select item).FirstOrDefault();

            _listActionLogInfo = (from item in _actionLogInfo
                                  where item.RoundID == roundId && item.BetDateTime > dateTime && item.BetOrder > _getGameRound.WinnerPoint
                                  select item);

            SetupResult.For(Dqr_ListSingleActionLog.List(new ListSingleActionLogCommand()))
                .IgnoreArguments()
                .Return(_listActionLogInfo);
        }

        [Given(@"Sent RoundID'(.*)' DateTime'(.*)'")]
        public void GivenSentRoundIDXDateTimeX(int roundId, DateTime dateTime)
        {
            _cmd = new ListSingleActionLogCommand {
                ActionLogInfo = new BetInformation { 
                    RoundID = roundId,
                    BetDateTime = dateTime
                }
            };
        }

        [Given(@"Sent invalid information RoundID'(.*)' DateTime'(.*)'")]
        public void GivenSentInvalidInformationRoundIDXDateTimeX(int roundId, DateTime dateTime)
        {
            _cmd = new ListSingleActionLogCommand {
                ActionLogInfo = new BetInformation {
                    RoundID = roundId,
                    BetDateTime = dateTime
                }
            };
        }

        [Given(@"Sent RoundID'(.*)' DateTime is today")]
        public void GivenSentRoundID1DateTimeIsToday(int roundId)
        {
            DateTime dateTime = DateTime.Today;

            _cmd = new ListSingleActionLogCommand {
                ActionLogInfo = new BetInformation {
                    RoundID = roundId,
                    BetDateTime = dateTime
                }
            };

        }

        [When(@"Call ListSingleActionLogInfoExecutor\(\)")]
        public void WhenCallListSingleActionLogInfoExecutor()
        {
            ListSingleActionLog.Execute(_cmd, (x) => { });
        }

        [When(@"Call ListSingleActionLogInfoExecutor\(\) for validation")]
        public void WhenCallListSingleActionLogInfoExecutorForValidation()
        {
            try {
                ListSingleActionLog.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        [Then(@"Single action log result should be as:")]
        public void ThenSingleActionLogResultShouldBeAs(Table table)
        {
            var expected = from item in table.Rows
                           select new {
                               RoundID = Convert.ToInt32(item["RoundID"]),
                               UserName = Convert.ToString(item["UserName"]),
                               Amount = Convert.ToDouble(item["Amount"]),
                               BetOrder = Convert.ToInt32(item["BetOrder"]),
                               BetDateTime = DateTime.Parse(item["BetDateTime"])
                           };

            var actual = from item in _listActionLogInfo
                         select new {
                             RoundID = item.RoundID,
                             UserName = item.UserName,
                             Amount = item.Amount,
                             BetOrder = item.BetOrder,
                             BetDateTime = item.BetDateTime
                         };

            CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray(), " Single action log information");
        }

        [Then(@"Single action log result should be throw exception")]
        public void ThenSingleActionLogResultShouldBeThrowException()
        {
            Assert.IsTrue(true, "Exception has been verified in the end of block When.");
        }
    }
}
