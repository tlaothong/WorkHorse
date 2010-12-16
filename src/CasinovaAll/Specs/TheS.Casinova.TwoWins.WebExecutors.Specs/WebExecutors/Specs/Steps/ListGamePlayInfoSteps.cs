using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SpecFlowAssist;
using TheS.Casinova.TwoWins.Commands;
using TheS.Casinova.TwoWins.Models;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.TwoWins.WebExecutors.Specs.Steps
{
    [Binding]
    public class ListGamePlayInfoSteps : TwoWinGameStepsBase
    {
        private ListGamePlayInfoCommand _cmd;
        private IEnumerable<TotalBetInformation> _totalBetInfo;
        private IEnumerable<TotalBetInformation> _listTotalBetInfo;

        [Given(@"Server has game play totalbet information as :")]
        public void GivenServerHasGamePlayTotalbetInformationAs(Table table)
        {
            _totalBetInfo = from item in table.Rows
                            select new TotalBetInformation {
                                RoundID = Convert.ToInt32(item["RoundID"]),
                                UserName = Convert.ToString(item["UserName"]),
                                TotalBet = Convert.ToDouble(item["TotalBet"])
                            };
        }

        [Given(@"Sent UserName'(.*)' to list game play information")]
        public void GivenSentUserNameXToListGamePlayInformation(string userName)
        {
            _listTotalBetInfo = (from item in _totalBetInfo
                                     where item.UserName == userName
                                     select item);

            SetupResult.For(Dqr_ListGamePlayInfo.List(new ListGamePlayInfoCommand()))
                .IgnoreArguments().Return(_listTotalBetInfo);

            _cmd = new ListGamePlayInfoCommand {
                TotalBetInfo = new TotalBetInformation { 
                    UserName = userName
                }
            };
        }

        [Given(@"Sent UserName'(.*)' for list game play information validtion")]
        public void GivenSentUserNameForListGamePlayInformationValidtion(string userName)
        {
            _cmd = new ListGamePlayInfoCommand {
                TotalBetInfo = new TotalBetInformation {
                    UserName = userName
                }
            };
        }

        //Validation
        [When(@"Call ListGamePlayInfoExecutor\(\) for validate input")]
        public void WhenCallListGamePlayInfoExecutorForValidateInput()
        {
            try {
                ListGamePlayInfo.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        //Test function
        [When(@"Call ListGamePlayInfoExecutor\(\)")]
        public void WhenCallListGamePlayInfoExecutor()
        {
            ListGamePlayInfo.Execute(_cmd, (x) => { });
        }

        [Then(@"GamePlay information should be as :")]
        public void ThenGamePlayInformationShouldBeAs(Table table)
        {
            var expected = from item in table.Rows
                           select new {
                               RoundID = Convert.ToInt32(item["RoundID"]),
                               UserName = Convert.ToString(item["UserName"]),
                               TotalBet = Convert.ToDouble(item["TotalBet"])
                           };

            var actual = from item in _listTotalBetInfo
                         select new { 
                             RoundID = item.RoundID,
                             UserName = item.UserName,
                             TotalBet = item.TotalBet
                         };

            CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray(), "GamePlay Information");
        }

        [Then(@"GamePlay information should be throw exception")]
        public void ThenGamePlayInformationShouldBeThrowException()
        {
            Assert.IsTrue(true, "Exception has been verified in the end of block When.");
        }
 
    }
}
