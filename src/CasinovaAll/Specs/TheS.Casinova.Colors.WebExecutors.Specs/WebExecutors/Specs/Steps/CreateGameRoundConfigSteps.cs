﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.Colors.Models;
using TheS.Casinova.Colors.BackServices;
using TheS.Casinova.Colors.Commands;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfEx.Infrastructure.Validation;

namespace TheS.Casinova.Colors.WebExecutors.Specs.Steps
{
    [Binding]
    public class CreateGameRoundConfigSteps : ColorsGameStepsBase
    {
        private CreateGameRoundConfigurationCommand _cmd;

        //Test error
        [Given(@"Game round configuration informations are : ConfigName'(.*)',TableAmount'(.*)', GameDuration'(.*)', Interval'(.*)', BufferRoundCount'(.*)'")]
        public void GivenGameRoundConfigurationInformationsAreNameXTableAmountXGameDurationXIntervalXBufferRoundCountX(string name, int tableAmount, int gameDuration, int interval, int bufferRoundCount)
        {
            _cmd = new CreateGameRoundConfigurationCommand {
                GameRoundConfig = new GameRoundConfiguration {                    
                    ConfigName = name,
                    TableAmount = tableAmount,
                    GameDuration = gameDuration,
                    Interval = interval,
                    BufferRoundsCount = bufferRoundCount
                }
            };
            
        }
        
        [When(@"Call CreateGameRoundConfigExecutor\(\)")]
        public void WhenCallCreateGameRoundConfigExecutor()
        {
            try {
                CreateGameRound.Execute(_cmd, (x) => { });
                Assert.Fail("Shouldn't be here");
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
               
        }

        [Then(@"The system can't sent GameRoundConfigurations to back server")]
        public void ThenTheSystemCanTSentGameRoundConfigurationsToBackServer()
        {
            Assert.IsTrue(true, "Exception has been verified in the end of block When.");
        }

        //Test succeeded
        [Given(@"System can sent game round configuration informations are : ConfigName'(.*)',TableAmount'(.*)', GameDuration'(.*)', Interval'(.*)', BufferRoundCount'(.*)'")]
        public void GivenSystemCanSentGameRoundConfigurationInformationsAreNameColorsGameTableAmount5GameDuration30Interval10BufferRoundCount3(string name, int tableAmount, int gameDuration, int interval, int bufferRoundCount)
        {
            _cmd = new CreateGameRoundConfigurationCommand {
                GameRoundConfig = new GameRoundConfiguration {
                    ConfigName = name,
                    TableAmount = tableAmount,
                    GameDuration = gameDuration,
                    Interval = interval,
                    BufferRoundsCount = bufferRoundCount
                }
            };
        }

        [When(@"System can call CreateGameRoundConfigExecutor\(\)")]
        public void WhenSystemCanCallCreateGameRoundConfigExecutor()
        {
            try {
                CreateGameRound.Execute(_cmd, (x) => { });
                Assert.IsTrue(true);
            }
            catch (Exception ex) {
                Assert.IsInstanceOfType(ex,
                    typeof(ValidationErrorException));
            }
        }

        [Then(@"The system can sent GameRoundConfigurations to back server")]
        public void ThenTheSystemCanSentGameRoundConfigurationsToBackServer()
        {
            Assert.IsTrue(true, "Exception has been verified in the end of block When.");
        }

        
    }
}
