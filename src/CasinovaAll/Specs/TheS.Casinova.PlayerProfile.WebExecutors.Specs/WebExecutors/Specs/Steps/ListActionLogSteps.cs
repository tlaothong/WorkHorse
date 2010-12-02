using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.PlayerProfile.Models;
using TheS.Casinova.PlayerProfile.Commands;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.PlayerProfile.WebExecutors.Specs.Steps
{
    [Binding]
    public class ListActionLogSteps : PlayerProfileModuleStepsBase
    {
        private ListActionLogCommand _cmd;
        private IEnumerable<ActionLog> _ActionLog;
        private IEnumerable<ActionLog> _ListActionLog;

        [Given(@"Server has action log information as:")]
        public void GivenServerHasActionLogInformationAs(Table table)
        {
            _ActionLog = from item in table.Rows
                         select new ActionLog {
                             UserName = Convert.ToString(item["UserName"]),
                             Action = Convert.ToString(item["Action"]),
                             GameName = Convert.ToString(item["GameName"]),
                             Amount = Convert.ToDouble(item["Amount"]),
                             DateTime = DateTime.Parse(item["DateTime"])
                         };
        }

        [Given(@"Sent UserName: '(.*)' for list action log")]
        public void GivenSentUserNameXForListActionLog(string userName)
        {
            _ListActionLog = (from item in _ActionLog
                              where item.UserName == userName
                              select item);
            SetupResult.For(Dqr_ListActionLog.List(new ListActionLogCommand()))
                .IgnoreArguments().Return(_ListActionLog);

            _cmd = new ListActionLogCommand {
                ListActionLogInfo = new ActionLog {
                    UserName = userName
                }
            };
        }

        [Given(@"Sent UserName: '(.*)' for validation")]
        public void GivenSentUserNameForValidation(string userName)
        {
            _cmd = new ListActionLogCommand {
                ListActionLogInfo = new ActionLog {
                    UserName = userName
                }
            };
        }

        //Test function
        [When(@"Call ListActionLogExecutor\(\)")]
        public void WhenCallListActionLogExecutor()
        {
            ListActionLog.Execute(_cmd, (x) => { });
        }

        //Validation
        [When(@"Call ListActionLogExecutor\(\) for validate input")]
        public void WhenCallListActionLogExecutorForValidateInput()
        {
            try {
                ListActionLog.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        [Then(@"Action log information should be :")]
        public void ThenActionLogInformationShouldBe(Table table)
        {
            var expected = from item in table.Rows
                           select new {
                               UserName = Convert.ToString(item["UserName"]),
                               Action = Convert.ToString(item["Action"]),
                               GameName = Convert.ToString(item["GameName"]),
                               Amount = Convert.ToDouble(item["Amount"]),
                               DateTime = DateTime.Parse(item["DateTime"])
                           };

            var actual = from item in _ListActionLog
                         select new {
                             UserName = item.UserName,
                             Action = item.Action,
                             GameName = item.GameName,
                             Amount = item.Amount,
                             DateTime = item.DateTime
                         };

            CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray(), "Action log");
        }

        [Then(@"Action log information should be throw exception")]
        public void ThenActionLogInformationShouldBeThrowException()
        {
            Assert.IsTrue(true, "Exception has been verified in the end of block When.");

        }
    }
}
