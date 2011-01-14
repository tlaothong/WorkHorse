using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;
using TheS.Casinova.DevilSix.Commands;
using TheS.Casinova.DevilSix.Models;

namespace TheS.Casinova.DevilSix.WebExecutors.Specs.Steps
{
    [Binding]
    public class ListBetLogSteps : DevilSixGameStepsBase
    {
        private ListBetLogCommand _cmd;
        private IEnumerable<BetInformation> _betLog;
        private IEnumerable<BetInformation> _listBetLog;

        [Given(@"server has BetLog information as:")]
        public void GivenServerHasBetLogInformationAs(Table table)
        {
            _betLog = from item in table.Rows
                      select new BetInformation { 
                          RoundID = Convert.ToInt32(item["RoundID"]),
                          UserName = Convert.ToString(item["UserName"]),
                          BetOrder = Convert.ToInt32(item["BetOrder"]),
                          BetDateTime = DateTime.Parse(item["BetDateTime"]),
                          BetTrackingID = Guid.Parse(item["BetTrackingID"]),
                      };
        }

        [Given(@"Sent UserName'(.*)', RoundID '(.*)' for test function")]
        public void GivenSentUserNameXRoundIDXForTestFunction(string userName, int roundID)
        {
            _listBetLog = (from item in _betLog
                           where item.UserName == userName && item.RoundID == roundID
                           select item);

            SetupResult.For(Dqr_ListBetLog.List(new ListBetLogCommand()))
               .IgnoreArguments().Return(_listBetLog);

            _cmd = new ListBetLogCommand {
                BetInfo = new BetInformation {
                    UserName = userName,
                    RoundID = roundID
                }
            };
        }

         [Given(@"Sent UserName'(.*)', RoundID '(.*)' for validate")]
        public void GivenSentUserNameXRoundIDXForValidate(string userName, int roundID)
        {
            _cmd = new ListBetLogCommand {
                BetInfo = new BetInformation { 
                    UserName = userName,
                    RoundID = roundID
                }
            };
        }

        //Test Function
        [When(@"Call ListBetLogExecutor\(\)")]
        public void WhenCallListBetLogExecutor()
        {
             ListBetLog.Execute(_cmd, (x) => { });

        }

        //Validation
        [When(@"Call ListBetLogExecutor\(\) for validate input information")]
        public void WhenCallListBetLogExecutorForValidateInputInformation()
        {
            try {
                ListBetLog.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        [Then(@"The result of BetLog should be :")]
        public void ThenTheResultOfBetLogShouldBe(Table table)
        {
            var expected = from item in table.Rows
                           select new {
                               RoundID = Convert.ToInt32(item["RoundID"]),
                               UserName = Convert.ToString(item["UserName"]),
                               BetOrder = Convert.ToInt32(item["BetOrder"]),
                               BetDateTime = DateTime.Parse(item["BetDateTime"]),
                               BetTrackingID = Guid.Parse(item["BetTrackingID"]),
                           };

            var actual = from item in _listBetLog
                         select new {
                             RoundID = item.RoundID,
                             UserName = item.UserName,
                             BetOrder = item.BetOrder,
                             BetDateTime = item.BetDateTime,
                             BetTrackingID = item.BetTrackingID
 
                         };

            CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray(),"Bet log information");
        }

        [Then(@"The result of BetLog should be throw exception")]
        public void ThenTheResultOfBetLogShouldBeThrowException()
        {
            Assert.IsTrue(true, "Exception has been verified in the end of block When.");
        }
    }
}
