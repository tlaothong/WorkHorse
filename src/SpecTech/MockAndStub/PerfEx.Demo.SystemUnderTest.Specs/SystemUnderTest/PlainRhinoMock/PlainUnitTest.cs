using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Security.Principal;

namespace PerfEx.Demo.SystemUnderTest.PlainRhinoMock
{
    [TestClass]
    public class PlainUnitTest
    {
        #region Demo Stub

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

        [TestMethod]
        public void SetupResultForStubMethodWithParam()
        {
            var mocks = new MockRepository();

            TargetOfTest tot = new TargetOfTest();
            var coWorker = mocks.Stub<IWorkTogether>();
            tot.WorkTogether = coWorker;

            SetupResult.For(coWorker.NumberOfFans).Return(7);
            SetupResult.For(coWorker.NumToText(5)).Return("five");
            SetupResult.For(coWorker.NumToText(6)).Return("six");
            SetupResult.For(coWorker.NumToText(7)).Return("seven");

            mocks.ReplayAll();

            var result = tot.HowManyFansInText();

            Assert.AreEqual("There is/are seven fan(s).", result);
        }

        [TestMethod]
        public void HelloStudentVariousCases()
        {
            var mocks = new MockRepository();

            TargetOfTest tot = new TargetOfTest();
            var coWorker = mocks.Stub<IWorkTogether>();
            tot.WorkTogether = coWorker;

            using (mocks.Record()) {
                SetupResult.For(coWorker.GetStudentName(1)).Return("John");
                SetupResult.For(coWorker.GetStudentName(2)).Return("Tom");
                SetupResult.For(coWorker.GetStudentName(0)).IgnoreArguments().Return(null);
            }
            // mocks.ReplayAll();   // can be use here but not neccessary.

            var result = tot.HelloStudent(2);
            Assert.AreEqual("Hello Tom.", result);

            result = tot.HelloStudent(7);
            Assert.AreEqual("There's no student with id# 7", result);
        }

        #endregion Demo Stub

        #region Stub with method action

        [TestMethod]
        public void AddMockMethodWithParameter()
        {
            var mocks = new MockRepository();

            TargetOfTest tot = new TargetOfTest();
            var coWorker = mocks.DynamicMock<IWorkTogether>();
            tot.WorkTogether = coWorker;

            using (mocks.Record()) {
                SetupResult.For(coWorker.NumToText(4)).Return("four");
                SetupResult.For(coWorker.NumToText(5)).Return("five");
                SetupResult.For(coWorker.NumToText(6)).Return("six");
                SetupResult.For(coWorker.NumToText(7)).Return("seven");

                Func<int, int, int> doAdd = (a, b) => a + b;

                Expect.Call(coWorker.Add(0, 0)).IgnoreArguments().Do(doAdd);
            }
            using (mocks.Playback()) {
                var result = tot.AddToText(2, 2);
                Assert.AreEqual("four", result);

                result = tot.AddToText(3, 4);
                Assert.AreEqual("seven", result);
            }
        }

        #endregion Stub with method action

        #region Demo Mock

        [TestMethod]
        public void HelloStudentCallLogCorrectly()
        {
            var mocks = new MockRepository();

            var tot = new TargetOfTest();
            var coWorker = mocks.DynamicMock<IWorkTogether>();
            tot.WorkTogether = coWorker;

            // setup
            // studentId = 3 -> John
            using (mocks.Record()) {
                Expect.Call(coWorker.GetStudentName(3)).Return("John");
                coWorker.Log("HelloStudent");
                coWorker.Log("Found: John");
            }
            using (mocks.Playback()) {
                var result = tot.HelloStudent(3);
                Assert.AreEqual("Hello John.", result);
            }
            // mocks.VerifyAll();   // execute by Playback()
        }

        [TestMethod]
        public void HelloUserGreetsTheCurrentLoggedOnUser()
        {
            var mocks = new MockRepository();

            var tot = new TargetOfTest();
            //var coWorker = mocks.DynamicMock<IWorkTogether>();
            //tot.WorkTogether = coWorker;
            var membership = mocks.DynamicMock<IMembership>();
            tot.Member = membership;

            //var identity = mocks.Stub<IIdentity>();
            //var user = mocks.Stub<IPrincipal>();

            using (mocks.Record()) {
                Expect.Call(membership.User.Identity.Name).Return("jdoe");
                //Expect.Call(user.Identity).Return(identity);
                //Expect.Call(identity.Name).Return("jdoe");
            }
            using (mocks.Playback()) {
                var result = tot.HelloUser();
                Assert.AreEqual("Hello jdoe.", result);
            }
        }

        #endregion Demo Mock
    }
}
