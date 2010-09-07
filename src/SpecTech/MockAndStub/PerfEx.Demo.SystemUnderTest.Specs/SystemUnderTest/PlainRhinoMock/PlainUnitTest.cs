using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace PerfEx.Demo.SystemUnderTest.PlainRhinoMock
{
    [TestClass]
    public class PlainUnitTest
    {
        [TestMethod]
        public void HelloPassingCorrectName()
        {
            // setup
            MockRepository mocks = new MockRepository();

            TargetOfTest tot = new TargetOfTest();
            IWorkTogether coWorker = mocks.Stub<IWorkTogether>();
            tot.WorkTogether = coWorker;

            SetupResult.For(coWorker.ReadText()).Return("Tom");

            mocks.ReplayAll();
            // execute
            string result = tot.Hello();
            // check
            Assert.AreEqual("Hello Tom. How are you?", result);
        }

        [TestMethod]
        public void UsingPropertyInStub()
        {
            var mocks = new MockRepository();

            TargetOfTest tot = new TargetOfTest();
            var coWorker = mocks.Stub<IWorkTogether>();
            tot.WorkTogether = coWorker;

            SetupResult.For(coWorker.NumberOfFans).Return(4);
            mocks.ReplayAll();

            int result = tot.HowManyFans();

            Assert.AreEqual(4, result, "The result should be the same as NumberOfFans");
        }
    }
}
