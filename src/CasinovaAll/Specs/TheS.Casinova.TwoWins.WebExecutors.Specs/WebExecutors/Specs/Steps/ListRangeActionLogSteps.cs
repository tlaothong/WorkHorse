using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.TwoWins.Commands;
using TheS.Casinova.TwoWins.Models;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.TwoWins.WebExecutors.Specs.Steps
{
    [Binding]
    public class ListRangeActionLogSteps : TwoWinGameStepsBase
    {
        private ListRangeActionLogCommand _cmd;
        private IEnumerable<ActionLogInformation> _betData;
        private IEnumerable<ActionLogInformation> _listRangeActionLog;
        private IEnumerable<RoundInformation> _roundInfo;
        private double _pot;
        private int _handsCount;

        [Given(@"Server has bet data of finished game \#ListRangeActionLog")]
        public void GivenServerHasBetDataOfFinishedGameListRangeActionLog(Table table)
        {
            _betData = from item in table.Rows
                       select new ActionLogInformation {
                           RoundID = Convert.ToInt32(item["RoundID"]),
                           UserName = Convert.ToString(item["UserName"]),
                           HandID = Convert.ToInt32(item["HandID"]),
                           Amount = Convert.ToDouble(item["Amount"]),
                           OldAmount = Convert.ToDouble(item["OldAmount"]),
                           Pot = Convert.ToDouble(item["Pot"]),
                           WinState = Convert.ToString(item["WinState"]),
                           Reward = Convert.ToDouble(item["Reward"]),
                           HandStatus = Convert.ToString(item["HandStatus"]),
                           Change = Convert.ToBoolean(item["Change"]),
                           DateTime = DateTime.Parse(item["DateTime"])
                       };
        }

        [Given(@"Server has Pot and HandCount information as:")]
        public void GivenServerHasPotAndHandCountInformationAs(Table table)
        {
            _roundInfo = from item in table.Rows
                         select new RoundInformation { 
                             RoundID = Convert.ToInt32(item["RoundID"]),
                             Pot = Convert.ToDouble(item["Pot"]),
                             HandsCount = Convert.ToInt32(item["HandsCount"])
                         };
        }

        [Given(@"Sent FromRoundID'(.*)' ThruRoundID'(.*)' to list range action log")]
        public void GivenSentFromRoundID1ThruRoundID2ToListRangeActionLog(int fromRoundID, int thruRoundID)
        {
            List<ActionLogInformation> listRangeActionLog = new List<ActionLogInformation>();

            for (int i = fromRoundID; i <= thruRoundID; i++) {
                var qry = (from item in _betData
                           where item.RoundID == i && item.WinState == "Hight" || item.RoundID == i && item.WinState == "Low"
                           select item).ToList();

                foreach (var item in qry) {
                    listRangeActionLog.Add(item);
                }
            }
            _listRangeActionLog = listRangeActionLog;

            SetupResult.For(Dqr_ListRangeActionLog.List(new ListRangeActionLogCommand()))
                .IgnoreArguments().Return(_listRangeActionLog);

            //รวมค่า pot ของทุกโต๊ะเกม
            for (int i = fromRoundID; i <= thruRoundID; i++) {
                _pot += (from item in _roundInfo
                        where item.RoundID == i
                        select item.Pot).FirstOrDefault();
            }

            //รวมค่า handsCount ของทุกโต๊ะเกม
            for (int i = fromRoundID; i <= thruRoundID; i++) {
                _handsCount += (from item in _roundInfo
                        where item.RoundID == i
                        select item.HandsCount).FirstOrDefault();
            }
            
            _cmd = new ListRangeActionLogCommand {
                ActionLogInfo = new ActionLogInformation {
                    FromRoundID = fromRoundID,
                    ThruRoundID = thruRoundID
                }
            };
        }

        [Given(@"Sent FromRoundID'(.*)' ThruRoundID'(.*)' for list range action log validation")]
        public void GivenSentFromRoundID_4ThruRoundID5ForListRangeActionLogValidation(int fromRoundID, int thruRoundID)
        {
            _cmd = new ListRangeActionLogCommand {
                ActionLogInfo = new ActionLogInformation {
                    FromRoundID = fromRoundID,
                    ThruRoundID = thruRoundID
                }
            };
        }

        //Validation
        [When(@"Call ListRangeActionLogExecutor\(\) for validate input")]
        public void WhenCallListRangeActionLogExecutorForValidateInput()
        {
            try {
                ListRangeActionLog.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        //Test function
        [When(@"Call ListRangeActionLogExecutor\(\)")]
        public void WhenCallListRangeActionLogExecutor()
        {
            ListRangeActionLog.Execute(_cmd, (x) => { });
        }

        [Then(@"RangeActionLog information should be as :")]
        public void ThenRangeActionLogInformationShouldBeAs(Table table)
        {
            var expected = from item in table.Rows
                           select new {
                               RoundID = Convert.ToInt32(item["RoundID"]),
                               UserName = Convert.ToString(item["UserName"]),
                               HandID = Convert.ToInt32(item["HandID"]),
                               Amount = Convert.ToDouble(item["Amount"]),
                               OldAmount = Convert.ToDouble(item["OldAmount"]),
                               Pot = Convert.ToDouble(item["Pot"]),
                               WinState = Convert.ToString(item["WinState"]),
                               Reward = Convert.ToDouble(item["Reward"]),
                               HandStatus = Convert.ToString(item["HandStatus"]),
                               Change = Convert.ToBoolean(item["Change"]),
                               DateTime = DateTime.Parse(item["DateTime"])
                           };
            var actual = from item in _listRangeActionLog
                         select new {
                             RoundID = item.RoundID,
                             UserName = item.UserName,
                             HandID = item.HandID,
                             Amount = item.Amount,
                             OldAmount = item.OldAmount,
                             Pot = item.Pot,
                             WinState = item.WinState,
                             Reward = item.Reward,
                             HandStatus = item.HandStatus,
                             Change = item.Change,
                             DateTime = item.DateTime
                         };
            CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray(), "Range Action Log Information");
        }

        [Then(@"Game result Pot'(.*)' HandCount'(.*)'")]
        public void ThenGameResultPot3578HandCount8(double pot, int handCount)
        {
            Assert.AreEqual(pot, _pot, "จำนวนเงินทั้งหมด");
            Assert.AreEqual(handCount, _handsCount, "จำนวนมือทั้งหมด");
        }

        [Then(@"RangeActionLog information should be throw exception")]
        public void ThenRangeActionLogInformationShouldBeThrowException()
        {
            Assert.IsTrue(true, "Exception has been verified in the end of block When.");
        }
    }
}
