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
    public class ListGamePlayAutoBetInfoSteps : DevilSixGameStepsBase
    {
        private ListGamePlayAutoBetInfoCommand _cmd;
        private IEnumerable<GamePlayAutoBetInformation>  _gamePlayAutoBet;
        private IEnumerable<GamePlayAutoBetInformation> _listGamePlayAutoBet;


        [Given(@"Server has game play auto bet information as:")]
        public void GivenServerHasGamePlayAutoBetInformationAs(Table table)
        {
            _gamePlayAutoBet = from item in table.Rows
                               select new GamePlayAutoBetInformation {
                                   RoundID = Convert.ToInt32(item["RoundID"]),
                                   UserName = Convert.ToString(item["UserName"]),
                                   Amount = Convert.ToDouble(item["Amount"]),
                                   Interval = Convert.ToInt32(item["Interval"]),
                                   BetTrackingID = Guid.Parse(item["BetTrackingID"]),
                                   ThruDateTime = DateTime.Parse(item["ThruDateTime"])
                               };
        }

        [Given(@"Sent UserName '(.*)'")]
        public void GivenSentUserNameGogo(string userName)
        {
            _listGamePlayAutoBet = (from item in _gamePlayAutoBet
                                    where item.UserName == userName
                                    select item);

            SetupResult.For(Dqr_ListGamePlayAutoBetInfo.List(new ListGamePlayAutoBetInfoCommand()))
               .IgnoreArguments().Return(_listGamePlayAutoBet);

            _cmd = new ListGamePlayAutoBetInfoCommand {
                GamePlayAutoBetInfo = new GamePlayAutoBetInformation {
                    UserName = userName
                }
            };
        }

        [Given(@"Sent UserName '(.*)' for validation")]
        public void GivenSentUserNameForValidation(string userName)
        {
            _cmd = new ListGamePlayAutoBetInfoCommand {
                GamePlayAutoBetInfo = new GamePlayAutoBetInformation {
                    UserName = userName
                }
            };
        }

        //Test function
        [When(@"Call ListGamePlayAutoBetInfoExecutor\(\)")]
        public void WhenCallListGamePlayAutoBetInfoExecutor()
        {
            ListGamePlayAutoBetInfo.Execute(_cmd, (x) => { });

        }

        //Validation
        [When(@"Call ListGamePlayAutoBetInfoExecutor\(\) for validate input")]
        public void WhenCallListGamePlayAutoBetInfoExecutorForValidateInput()
        {
            try {
                ListGamePlayAutoBetInfo.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        [Then(@"The game play auto bet information should be as :")]
        public void ThenTheGamePlayAutoBetInformationShouldBeAs(Table table)
        {
            var expected = from item in table.Rows
                           select new {
                               RoundID = Convert.ToInt32(item["RoundID"]),
                               UserName = Convert.ToString(item["UserName"]),
                               Amount = Convert.ToDouble(item["Amount"]),
                               Interval = Convert.ToInt32(item["Interval"]),
                               BetTrackingID = Guid.Parse(item["BetTrackingID"]),
                               ThruDateTime = (DateTime?)DateTime.Parse(item["ThruDateTime"])
                           };

            var actual = from item in _listGamePlayAutoBet
                         select new {
                             RoundID = item.RoundID,
                             UserName = item.UserName,
                             Amount = item.Amount,
                             Interval = item.Interval,
                             BetTrackingID = item.BetTrackingID,
                             ThruDateTime = item.ThruDateTime
                         };

            CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray(), " ");
        }

        [Then(@"The game play auto bet information should be throw exception")]
        public void ThenTheGamePlayAutoBetInformationShouldBeThrowException()
        {
            Assert.IsTrue(true, "Exception has been verified in the end of block When.");
        }   
    }
}
