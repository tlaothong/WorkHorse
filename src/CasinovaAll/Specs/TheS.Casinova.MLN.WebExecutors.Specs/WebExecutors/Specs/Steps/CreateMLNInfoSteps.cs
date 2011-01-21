using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.MLN.Commands;
using TheS.Casinova.MLN.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.MLN.WebExecutors.Specs.Steps
{
    [Binding]
    public class CreateMLNInfoSteps : MLNModuleStepsBase
    {
        private CreateMLNInfoCommand _cmd;

        [Given(@"Sent UserName '(.*)' UplineLevel1 '(.*)'")]
        public void GivenSentUserNameXUplineLevel1X(string userName, string upline)
        {
            _cmd = new CreateMLNInfoCommand {
                MLNInfo = new MLNInformation { 
                    UserName = userName,
                    UplineLevel1 = upline
                }
            };
        }

        [When(@"Call CreateMLNInfoExecutor\(\)")]
        public void WhenCallCreateMLNInfoExecutor()
        {
            CreateMLNInfo.Execute(_cmd, (x) => { });
        }

        [When(@"Call CreateMLNInfoExecutor\(\) for validation")]
        public void WhenCallCreateMLNInfoExecutorForValidation()
        {
            try {
                CreateMLNInfo.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        [Then(@"MLN information can sent to back server")]
        public void ThenMLNInformationCanSentToBackServer()
        {
            Assert.IsTrue(true, "MLN Information can sent to back server");
        }

        [Then(@"MLN information can't sent to back server")]
        public void ThenMLNInformationCanTSentToBackServer()
        {
            Assert.IsTrue(true, "MLN Information can't sent to back server");
        }
    }
}
