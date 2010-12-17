using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.TwoWins.Commands;
using TheS.Casinova.TwoWins.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.TwoWins.WebExecutors.Specs.Steps
{
    [Binding]
    public class ListBetLogInfoSteps : TwoWinGameStepsBase
    {
        private ListBetLogInfoCommand _cmd;
        private IEnumerable<BetInformation> _betInfo;
        private IEnumerable<BetInformation> _listBetLogInfo;

        [Given(@"Server has bet log information as :")]
        public void GivenServerHasBetLogInformationAs(Table table)
        {
            _betInfo = from item in table.Rows
                       select new BetInformation { 
                           RoundID = Convert.ToInt32(item["RoundID"]),
                           UserName = Convert.ToString(item["UserName"]),
                           HandID = Convert.ToInt32(item["HandID"]),
                           Amount = Convert.ToDouble(item["Amount"]),
                           HandStatus = Convert.ToString(item["HandStatus"]),
                           BetDateTime = DateTime.Parse(item["BetDateTime"])
                       };
        }

        [Given(@"Sent UserName'(.*)' RoundID'(.*)' to list bet log information")]
        public void GivenSentUserNameXRoundIDXToListBetLogInformation(string userName, int roundID)
        {
            _listBetLogInfo = (from item in _betInfo
                               where item.RoundID == roundID && item.UserName == userName
                               select item);

            _cmd = new ListBetLogInfoCommand {
                BetInfo = new BetInformation { 
                    UserName = userName,
                    RoundID = roundID
                }
            };
        }

        [Given(@"Sent UserName'(.*)' RoundID'(.*)' for list bet log information validation")]
        public void GivenSentUserNameXRoundIDXForListBetLogInformationValidation(string userName, int roundID)
        {
            _cmd = new ListBetLogInfoCommand {
                BetInfo = new BetInformation {
                    UserName = userName,
                    RoundID = roundID
                }
            };
        }

        //Validation
        [When(@"Call ListBetLogInfoExecutor\(\) for validate input")]
        public void WhenCallListBetLogInfoExecutorForValidateInput()
        {
            try {
                ListBetLogInfo.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        //Test function
        [When(@"Call ListBetLogInfoExecutor\(\)")]
        public void WhenCallListBetLogInfoExecutor()
        {
            ListBetLogInfo.Execute(_cmd, (x) => { });
        }

        [Then(@"BetLog information should be as :")]
        public void ThenBetLogInformationShouldBeAs(Table table)
        {
            var expected = from item in table.Rows
                           select new {
                               RoundID = Convert.ToInt32(item["RoundID"]),
                               UserName = Convert.ToString(item["UserName"]),
                               HandID = Convert.ToInt32(item["HandID"]),
                               Amount = Convert.ToDouble(item["Amount"]),
                               HandStatus = Convert.ToString(item["HandStatus"]),
                               BetDateTime = DateTime.Parse(item["BetDateTime"])
                           };

            var actual = from item in _listBetLogInfo
                           select new {
                               RoundID = item.RoundID,
                               UserName = item.UserName,
                               HandID = item.HandID,
                               Amount = item.Amount,
                               HandStatus = item.HandStatus,
                               BetDateTime = item.BetDateTime
                           };

            CollectionAssert.AreEqual(expected.ToArray(),actual.ToArray(),"Bet Log Information");
        }

        [Then(@"BetLog information should be throw exception")]
        public void ThenBetLogInformationShouldBeThrowException()
        {
            Assert.IsTrue(true, "Exception has been verified in the end of block When.");
        }
    }
}
