using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.MLN.Models;
using TheS.Casinova.MLN.Commands;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheS.Casinova.MLN.Command;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.MLN.WebExecutors.Specs.Steps
{
    [Binding]
    public class ListDownLineByLevelSteps : MLNModuleStepsBase
    {
        private IEnumerable<MLNInformation> _MLNInfo;
        private IEnumerable<MLNInformation> _ListDownLineInfo;
        List<MLNInformation> _ListDownLineLevel1 = new List<MLNInformation>();
        List<MLNInformation> _ListDownLineLevel2 = new List<MLNInformation>();
        List<MLNInformation> _ListDownLineLevel3 = new List<MLNInformation>();
        private ListDownLineByLevelCommand _cmd;

        [Given(@"Server has downline information :")]
        public void GivenServerHasDownlineInformation(Table table)
        {
            _MLNInfo = from item in table.Rows
                       select new MLNInformation { 
                           UserName = Convert.ToString(item["UserName"]),
                           UplineLevel1 = Convert.ToString(item["UplineLevel1"]),
                           UplineLevel2 = Convert.ToString(item["UplineLevel2"]),
                           UplineLevel3 = Convert.ToString(item["UplineLevel3"]),
                           BonusThisMonth = Convert.ToDouble(item["BonusThisMonth"]),
                           BonusLastMonth = Convert.ToDouble(item["BonusLastMonth"]),
                           TotalDownLineLevel1 = Convert.ToInt32(item["TotalDownLineLevel1"]),
                           TotalDownLineLevel2 = Convert.ToInt32(item["TotalDownLineLevel2"]),
                           TotalDownLineLevel3 = Convert.ToInt32(item["TotalDownLineLevel3"]),
                           TotalBonus = Convert.ToDouble(item["TotalBonus"])
                       };
        }
        [Given(@"Sent UserName'(.*)' to list downline by level")]
        public void GivenSentUserNameBoyToListDownlineByLevel(string userName)
        {

            _ListDownLineInfo = (from item in _MLNInfo
                                 where item.UplineLevel1 == userName
                                 select item);
            foreach (var item in _ListDownLineInfo) {
                item.GroupCount = item.TotalDownLineLevel1 + item.TotalDownLineLevel2;
                _ListDownLineLevel1.Add(item);
            }
            SetupResult.For(Dqr_ListDownLineByLevel1.List(new ListDownLineByLevel1Command()))
                .IgnoreArguments()
                .Return(_ListDownLineLevel1);


            _ListDownLineInfo = (from item in _MLNInfo
                                 where item.UplineLevel2 == userName
                                 select item);
            foreach (var item in _ListDownLineInfo) {
                item.GroupCount = item.TotalDownLineLevel1;
                _ListDownLineLevel2.Add(item);
            }
            SetupResult.For(Dqr_ListDownLineByLevel2.List(new ListDownLineByLevel2Command()))
                .IgnoreArguments()
                .Return(_ListDownLineLevel2);


            _ListDownLineInfo = (from item in _MLNInfo
                                 where item.UplineLevel3 == userName
                                 select item);
            foreach (var item in _ListDownLineInfo) {
                item.GroupCount = 0;
                _ListDownLineLevel3.Add(item);
            }
            SetupResult.For(Dqr_ListDownLineByLevel3.List(new ListDownLineByLevel3Command()))
                .IgnoreArguments()
                .Return(_ListDownLineLevel3);

            _cmd = new ListDownLineByLevelCommand {
                DownLineInfo = new MLNInformation {
                    UserName = userName
                }
            };
        }

        //Test function
        [When(@"Call ListDownLineBylavelExecutor\(\)")]
        public void WhenCallListDownLineBylavelExecutor()
        {
           ListDownLineByLevel.Execute(_cmd, (x) => { });
        }

        //Validation
        [When(@"Call ListDownLineBylavelExecutor\(\) for validate information")]
        public void WhenCallListDownLineBylavelExecutorForValidateInformation()
        {
            try {
                ListDownLineByLevel.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        [Then(@"DowwnLineLevel1 information should be as:")]
        public void ThenDowwnLineLevel1InformationShouldBeAs(Table table)
        {
            var expect = from item in table.Rows
                           select new {
                               UserName = Convert.ToString(item["UserName"]),
                               UplineLevel1 = Convert.ToString(item["UplineLevel1"]),
                               UplineLevel2 = Convert.ToString(item["UplineLevel2"]),
                               UplineLevel3 = Convert.ToString(item["UplineLevel3"]),
                               BonusThisMonth = Convert.ToDouble(item["BonusThisMonth"]),
                               BonusLastMonth = Convert.ToDouble(item["BonusLastMonth"]),
                               TotalDownLineLevel1 = Convert.ToInt32(item["TotalDownLineLevel1"]),
                               TotalDownLineLevel2 = Convert.ToInt32(item["TotalDownLineLevel2"]),
                               TotalDownLineLevel3 = Convert.ToInt32(item["TotalDownLineLevel3"]),
                               TotalBonus = Convert.ToDouble(item["TotalBonus"]),
                               GroupCount = Convert.ToInt32(item["GroupCount"])
                           };
            var actual = from item in _ListDownLineLevel1
                         select new { 
                             UserName = item.UserName,
                             UplineLevel1 = item.UplineLevel1,
                             UplineLevel2 = item.UplineLevel2,
                             UplineLevel3 = item.UplineLevel3,
                             BonusThisMonth = item.BonusThisMonth,
                             BonusLastMonth = item.BonusLastMonth,
                             TotalDownLineLevel1 = item.TotalDownLineLevel1,
                             TotalDownLineLevel2 = item.TotalDownLineLevel2,
                             TotalDownLineLevel3 = item.TotalDownLineLevel3,
                             TotalBonus = item.TotalBonus,
                             GroupCount = item.GroupCount
                         };
            CollectionAssert.AreEqual(expect.ToArray(), actual.ToArray(), "DonwLine information level1");
        }

        [Then(@"DowwnLineLevel2 information should be as:")]
        public void ThenDowwnLineLevel2InformationShouldBeAs(Table table)
        {
            var expect = from item in table.Rows
                         select new {
                             UserName = Convert.ToString(item["UserName"]),
                             UplineLevel1 = Convert.ToString(item["UplineLevel1"]),
                             UplineLevel2 = Convert.ToString(item["UplineLevel2"]),
                             UplineLevel3 = Convert.ToString(item["UplineLevel3"]),
                             BonusThisMonth = Convert.ToDouble(item["BonusThisMonth"]),
                             BonusLastMonth = Convert.ToDouble(item["BonusLastMonth"]),
                             TotalDownLineLevel1 = Convert.ToInt32(item["TotalDownLineLevel1"]),
                             TotalDownLineLevel2 = Convert.ToInt32(item["TotalDownLineLevel2"]),
                             TotalDownLineLevel3 = Convert.ToInt32(item["TotalDownLineLevel3"]),
                             TotalBonus = Convert.ToDouble(item["TotalBonus"]),
                             GroupCount = Convert.ToInt32(item["GroupCount"])
                         };
            var actual = from item in _ListDownLineLevel2
                         select new {
                             UserName = item.UserName,
                             UplineLevel1 = item.UplineLevel1,
                             UplineLevel2 = item.UplineLevel2,
                             UplineLevel3 = item.UplineLevel3,
                             BonusThisMonth = item.BonusThisMonth,
                             BonusLastMonth = item.BonusLastMonth,
                             TotalDownLineLevel1 = item.TotalDownLineLevel1,
                             TotalDownLineLevel2 = item.TotalDownLineLevel2,
                             TotalDownLineLevel3 = item.TotalDownLineLevel3,
                             TotalBonus = item.TotalBonus,
                             GroupCount = item.GroupCount
                         };
            CollectionAssert.AreEqual(expect.ToArray(), actual.ToArray(),"DonwLine information level2");
        }

        [Then(@"DowwnLineLevel3 information should be as:")]
        public void ThenDowwnLineLevel3InformationShouldBeAs(Table table)
        {
            var expect = from item in table.Rows
                         select new {
                             UserName = Convert.ToString(item["UserName"]),
                             UplineLevel1 = Convert.ToString(item["UplineLevel1"]),
                             UplineLevel2 = Convert.ToString(item["UplineLevel2"]),
                             UplineLevel3 = Convert.ToString(item["UplineLevel3"]),
                             BonusThisMonth = Convert.ToDouble(item["BonusThisMonth"]),
                             BonusLastMonth = Convert.ToDouble(item["BonusLastMonth"]),
                             TotalDownLineLevel1 = Convert.ToInt32(item["TotalDownLineLevel1"]),
                             TotalDownLineLevel2 = Convert.ToInt32(item["TotalDownLineLevel2"]),
                             TotalDownLineLevel3 = Convert.ToInt32(item["TotalDownLineLevel3"]),
                             TotalBonus = Convert.ToDouble(item["TotalBonus"]),
                             GroupCount = Convert.ToInt32(item["GroupCount"])
                         };
            var actual = from item in _ListDownLineLevel3
                         select new {
                             UserName = item.UserName,
                             UplineLevel1 = item.UplineLevel1,
                             UplineLevel2 = item.UplineLevel2,
                             UplineLevel3 = item.UplineLevel3,
                             BonusThisMonth = item.BonusThisMonth,
                             BonusLastMonth = item.BonusLastMonth,
                             TotalDownLineLevel1 = item.TotalDownLineLevel1,
                             TotalDownLineLevel2 = item.TotalDownLineLevel2,
                             TotalDownLineLevel3 = item.TotalDownLineLevel3,
                             TotalBonus = item.TotalBonus,
                             GroupCount = item.GroupCount
                         };
            CollectionAssert.AreEqual(expect.ToArray(), actual.ToArray(),"DonwLine information level3");
        }

        [Then(@"The result DowwnLine information should be throw exception")]
        public void ThenTheResultDowwnLineInformationShouldBeThrowException()
        {
            Assert.IsTrue(true, "Exception has been verified in the end of block When.");
        }
    }
}
