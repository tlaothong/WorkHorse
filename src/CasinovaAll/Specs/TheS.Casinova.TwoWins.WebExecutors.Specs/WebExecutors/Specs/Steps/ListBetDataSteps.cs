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
    public class ListBetDataSteps : TwoWinGameStepsBase
    {
        private ListBetDataCommand _cmd;
        private IEnumerable<ActionLogInformation> _betData;
        private IEnumerable<ActionLogInformation> _listBetData;

        [Given(@"Server has bet data of finished game")]
        public void GivenServerHasBetDataOfFinishedGame(Table table)
        {
            _betData =  from item in table.Rows
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

        [Given(@"Sent FromRoundID'(.*)' ThruRoundID'(.*)' to list bet data")]
        public void GivenSentFromRoundIDXThruRoundIDXToListBetData(int fromRoundID, int thruRoundID)
        {
            List<ActionLogInformation> listBetData = new List<ActionLogInformation>();

            for(int i = fromRoundID ; i <= thruRoundID ; i++)
            {
                var qry = (from item in _betData
                                where item.RoundID == i
                                select item).ToList();

                foreach (var item in qry) {
                    listBetData.Add(item);
                }
            }
            _listBetData = listBetData;

            SetupResult.For(Dqr_ListBetData.List(new ListBetDataCommand()))
                .IgnoreArguments().Return(_listBetData);
         
            _cmd = new ListBetDataCommand {
                ActionLogInfo = new ActionLogInformation { 
                    FromRoundID = fromRoundID,
                    ThruRoundID = thruRoundID
                }
            };
        }

        [Given(@"Sent FromRoundID'(.*)' ThruRoundID'(.*)' for list bet data validation")]
        public void GivenSentFromRoundIDXThruRoundIDXForListBetDataValidation(int fromRoundID, int thruRoundID)
        {
            _cmd = new ListBetDataCommand {
                ActionLogInfo = new ActionLogInformation {
                    FromRoundID = fromRoundID,
                    ThruRoundID = thruRoundID
                }
            };
        }

        //Validation
        [When(@"Call ListBetDataExecutor\(\) for validate input")]
        public void WhenCallListBetDataExecutorForValidateInput()
        {
            try {
                ListBetData.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        //Test function
        [When(@"Call ListBetDataExecutor\(\)")]
        public void WhenCallListBetDataExecutor()
        {
            ListBetData.Execute(_cmd, (x) => { });
        }

        [Then(@"BetData information should be as :")]
        public void ThenBetDataInformationShouldBeAs(Table table)
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
            var actual = from item in _listBetData
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
            CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray(), "Bet data");
        }

        [Then(@"BetData information should be throw exception")]
        public void ThenBetDataInformationShouldBeThrowException()
        {
            Assert.IsTrue(true, "Exception has been verified in the end of block When.");
        }
    }
}
