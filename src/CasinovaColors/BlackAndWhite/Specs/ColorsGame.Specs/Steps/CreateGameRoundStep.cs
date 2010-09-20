﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ColorsGame.Specs.Steps
{
    [Binding]
    public class CreateGameRoundStep
    {
        private ViewModels.CreateGameRoundPage _createGameRound;
        
        [Given(@"Create and initialize CreateGameRoundPage")]
        public void GivenCreateAndInitializeCreateGameRoundPage()
        {
            _createGameRound = new ViewModels.CreateGameRoundPage();
        }

        [Given(@"Config TableCount: (.*), DurationTime: (.*) minute, IntervalTime: (.*) minute")]
        public void GivenConfigTableCountDurationTimeMinuteIntervaleTimeMinute(int tableCount ,int durationTime,int intervalTime)
        {
            _createGameRound.TableCount = tableCount;
            _createGameRound.DurationTime = durationTime;
            _createGameRound.IntervalTime = intervalTime;
        }

        [When(@"I press Save")]
        public void WhenIPressSave()
        {
            _createGameRound.Save();
        }

        [Then(@"sample tables has created")]
        public void ThenSampleTablesHasCreated(Table table)
        {
            var espect = from c in table.Rows
                         select new Models.GameTable{
                             TableID = int.Parse(c["TableID"]),
                             GameDuration = int.Parse(c["GameDuration"]),
                             Interval = int.Parse(c["Interval"])
                         };

            for (int index = 0; index < espect.Count(); index++) {
                Assert.AreEqual(espect.ToArray()[index].TableID, _createGameRound.SampleTable[index].TableID, "TableID");
                Assert.AreEqual(espect.ToArray()[index].GameDuration, _createGameRound.SampleTable[index].GameDuration, "GameDuration");
                Assert.AreEqual(espect.ToArray()[index].Interval, _createGameRound.SampleTable[index].Interval, "Interval");
            }
        }

        [Then(@"display sample tables has skip")]
        public void ThenDisplaySampleTablesHasSkip()
        {
            Console.WriteLine("Skip display sample tables.");
        }
    }
}
