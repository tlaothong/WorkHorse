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
    public class ListSingleActionLogSteps : TwoWinGameStepsBase
    {
        private ListSingleActionLogCommand _cmd;
        private IEnumerable<ActionLogInformation> _actionLog;
        private IEnumerable<ActionLogInformation> _listSingleActionLog;

        [Given(@"Server has action log information")]
        public void GivenServerHasActionLogInformation(Table table)
        {
            _actionLog = from item in table.Rows
                         select new ActionLogInformation { 
                             RoundID = Convert.ToInt32(item["RoundID"]),
                             UserName = Convert.ToString(item["UserName"]),
                             HandID = Convert.ToString(item["HandID"]),
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

        [Given(@"I sent RoundID '(.*)' to list single action log")]
        public void GivenISentRoundIDXToListSingleActionLog(int roundID)
        {
            _listSingleActionLog = (from item in _actionLog
                              where item.RoundID == roundID
                              select item);

            SetupResult.For(Dqr_ListSingleActionLog.List(new ListSingleActionLogCommand()))
               .IgnoreArguments().Return(_listSingleActionLog);

            _cmd = new ListSingleActionLogCommand {
                ActionLogInfo = new ActionLogInformation {
                    RoundID = roundID
                }
            };
        }

        [Given(@"I sent RoundID '(.*)' for list single action log validation")]
        public void GivenISentRoundIDXForListSingleActionLogValidation(int roundID)
        {
            _cmd = new ListSingleActionLogCommand {
                ActionLogInfo = new ActionLogInformation {
                    RoundID = roundID
                }
            };
        }

        //Validation
        [When(@"Call ListSingleActionLogExecutor\(\) for validate input")]
        public void WhenCallListSingleActionLogExecutorForValidateInput()
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

        //Test function
        [When(@"Call ListSingleActionLogExecutor\(\)")]
        public void WhenCallListSingleActionLogExecutor()
        {
            ListSingleActionLog.Execute(_cmd, (x) => { });
        }

        [Then(@"SingleActionLog information should be as :")]
        public void ThenSingleActionLogInformationShouldBeAs(Table table)
        {
           var expected = from item in table.Rows
                         select new{
                             RoundID = Convert.ToInt32(item["RoundID"]),
                             UserName = Convert.ToString(item["UserName"]),
                             HandID = Convert.ToString(item["HandID"]),
                             Amount = Convert.ToDouble(item["Amount"]),
                             OldAmount = Convert.ToDouble(item["OldAmount"]),
                             Pot = Convert.ToDouble(item["Pot"]),
                             WinState = Convert.ToString(item["WinState"]),
                             Reward = Convert.ToDouble(item["Reward"]),
                             HandStatus = Convert.ToString(item["HandStatus"]),
                             Change = Convert.ToBoolean(item["Change"]),
                             DateTime = DateTime.Parse(item["DateTime"])
                         };

           var actual = from item in _listSingleActionLog
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

           CollectionAssert.AreEqual(expected.ToArray(),actual.ToArray(),"Single action log information");
        }

        [Then(@"SingleActionLog information should be throw exception")]
        public void ThenSingleActionLogInformationShouldBeThrowException()
        {
            Assert.IsTrue(true, "Exception has been verified in the end of block When.");
        }
    }
}
