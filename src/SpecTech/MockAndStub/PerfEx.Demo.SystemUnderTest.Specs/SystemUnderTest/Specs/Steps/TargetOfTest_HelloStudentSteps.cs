using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PerfEx.Demo.SystemUnderTest.Specs.Steps
{
    [Binding]
    public class TargetOfTest_HelloStudentSteps
    {
        private TargetOfTest _tot;
        private IWorkTogether _coWorker;

        private MockRepository _mocks;
        public MockRepository Mocks
        {
            get
            {
                if (_mocks == null) {
                    _mocks = new MockRepository();
                }
                return _mocks;
            }
        }

        private string _result;

        [Given(@"an instance of TargetOfTest initializes with mock up of IWorkTogether")]
        public void GivenAnInstanceOfTargetOfTestInitializesWithMockUpOfIWorkTogether()
        {
            var mocks = Mocks;

            var tot = new TargetOfTest();
            _tot = tot;

            var coWorker = mocks.Stub<IWorkTogether>();
            _coWorker = coWorker;

            tot.WorkTogether = coWorker;
        }

        [Given(@"There is a student id \#(.*) names '(.*)'")]
        public void GivenThereIsAStudentId1NamesJohn(int studentId, string name)
        {
            var coWorker = _coWorker;

            SetupResult.For(coWorker.GetStudentName(studentId)).Return(name);

            Mocks.Replay(coWorker);
        }

        [When(@"call HelloStudent\((.*)\)")]
        public void WhenCallHelloStudent1(int studentId)
        {
            var tot = _tot;
            _result = tot.HelloStudent(studentId);
        }

        [Then(@"the result should be '(.*)'")]
        public void ThenTheResultShouldBeHelloJohn_(string expectedResult)
        {
            Assert.AreEqual(expectedResult, _result);
        }
    }
}
