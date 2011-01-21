using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.MLN.Commands;
using TheS.Casinova.MLN.Models;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.MLN.WebExecutors.Specs.Steps
{
    [Binding]
    public class ListMLNInfoSteps : MLNModuleStepsBase
    {
        private ListMLNInfoCommand _cmd;
        private IEnumerable<MLNInformation> _mlnInfo;
        private MLNInformation _getMLNInfo;

        [Given(@"Server has MLN information :")]
        public void GivenServerHasMLNInformation(Table table)
        {
            _mlnInfo = from item in table.Rows
                       select new MLNInformation { 
                           UserName = Convert.ToString(item["UserName"]),
                           BonusThisMonth = Convert.ToDouble(item["BonusThisMonth"]),
                           BonusLastMonth = Convert.ToDouble(item["BonusLastMonth"]),
                           TotalDownLineLevel1 = Convert.ToInt32(item["TotalDownLineLevel1"]),
                           TotalDownLineLevel2 = Convert.ToInt32(item["TotalDownLineLevel2"]),
                           TotalDownLineLevel3 = Convert.ToInt32(item["TotalDownLineLevel3"]),
                           TotalBonus = Convert.ToInt32(item["TotalBonus"])
                       };
        }

        [Given(@"Sent UserName '(.*)' for list MLN information")]
        public void GivenSentUserNameXForListMLNInformation(string userName)
        {
            _getMLNInfo = (from item in _mlnInfo
                           where item.UserName == userName
                           select item).FirstOrDefault();
            SetupResult.For(Dqr_ListMLNInfo.Get(new ListMLNInfoCommand()))
                .IgnoreArguments()
                .Return(_getMLNInfo);

            _cmd = new ListMLNInfoCommand {
                MLNInfo = new MLNInformation { 
                    UserName = userName
                }
            };
                
        }

        [When(@"Call ListMLNInformation\(\)")]
        public void WhenCallListMLNInformation()
        {
            ListMLNInfo.Execute(_cmd, (x) => { });
        }

        [When(@"Call ListMLNInformation\(\) for validation")]
        public void WhenCallListMLNInformationForValidation()
        {
            try {
                ListMLNInfo.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        [Then(@"MLN information should be as: UserName'(.*)' BonusThisMonth'(.*)' BonusLastMonth'(.*)' TotalDownLineLevel1'(.*)' TotalDownLineLevel2'(.*)' TotalDownLineLevel3'(.*)' TotalBonus'(.*)'")]
        public void ThenMLNInformationShouldBeAsUserNameXBonusThisMonthXBonusLastMonthXTotalDownLineLevelXTotalDownLineLevelXTotalDownLineLevelXTotalBonusX(
            string userName, double bonusThisMonth, double bonusLastMonth, int totalDownLineLV1, int totalDownLineLV2, int totalDownLineLV3, double totalBonus)
        {
            Assert.AreEqual(userName, _getMLNInfo.UserName);
            Assert.AreEqual(bonusThisMonth, _getMLNInfo.BonusThisMonth);
            Assert.AreEqual(bonusLastMonth, _getMLNInfo.BonusLastMonth);
            Assert.AreEqual(totalDownLineLV1, _getMLNInfo.TotalDownLineLevel1);
            Assert.AreEqual(totalDownLineLV2, _getMLNInfo.TotalDownLineLevel2);
            Assert.AreEqual(totalDownLineLV3, _getMLNInfo.TotalDownLineLevel3);
            Assert.AreEqual(totalBonus, _getMLNInfo.TotalBonus);
        }

        [Then(@"MLN information should be null")]
        public void ThenMLNInformationShouldBeNull()
        {
            Assert.AreEqual(null, _getMLNInfo);
        }

        [Then(@"MLN information should be throw exception")]
        public void ThenMLNInformationShouldBeThrowException()
        {
            Assert.IsTrue(true, "Exception has been verified in the end of block When.");
        }
    }
}
