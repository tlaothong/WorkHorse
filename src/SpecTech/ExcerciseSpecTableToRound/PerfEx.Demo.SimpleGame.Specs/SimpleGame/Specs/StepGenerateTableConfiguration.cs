using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using PerfEx.Demo.SimpleGame.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PerfEx.Demo.SimpleGame.Specs {
    [Binding]
    public class StepDefinitions {

        private int _tableCount;
        private int _gameDuration;
        private int _gameinterval;
        GameTableConfigurator gcfg;
        IEnumerable<GameTable> gt;

        [Given(@"amountOfTable is 12 , durationTime is 60 min and nextGen is 5 min")]
        public void GivenAmountOfTableIs12DurationTimeIs60MinAndNextGenIs5Min() {
            _tableCount = 12;
            _gameDuration = 60;
            _gameinterval = 5;
        }

        [When(@"I press create")]
        public void WhenIPressCreate() {
            gcfg = new GameTableConfigurator();
            gt = gcfg.GenerateTableConfiguration(_tableCount, _gameDuration, _gameinterval);

        }

        [Then(@"the result should have amount of table list is equal 12")]
        public void ThenTheResultShouldHaveAmountOfTableListIsEqual12() {
            Assert.AreEqual(12, gt.Count());
        }

    }
}
