using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PerfEx.Infrastructure.LotUpdate.SpecFlow {
    [Binding]
    public class StepDefinitions {
        private int _num1;
        private int _num2;
        private int _sum;

        [Given(@"I have entered 50 into the calculator")]
        public void GivenIHaveEntered50IntoTheCalculator() {
            _num1 = 50;
        }

        [Given(@"I have entered 70 into the calculator")]
        public void GivenIHaveEntered70IntoTheCalculator() {
            _num2 = 70;
        }

        [Then(@"the result should be 120 on the screen")]
        public void ThenTheResultShouldBe120OnTheScreen() {
            Assert.AreEqual(_sum, 120);
        }

        [When(@"I press add")]
        public void WhenIPressAdd() {
            _sum = _num1 + _num2;
        }
    }
}
