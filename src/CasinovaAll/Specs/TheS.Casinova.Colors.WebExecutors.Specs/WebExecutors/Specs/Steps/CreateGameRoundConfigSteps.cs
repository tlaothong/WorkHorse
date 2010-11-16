using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.Colors.Models;
using TheS.Casinova.Colors.BackServices;
using TheS.Casinova.Colors.Commands;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.Colors.WebExecutors.Specs.Steps
{
    [Binding]
    public class CreateGameRoundConfigSteps : ColorsGameStepsBase
    {
        private CreateGameRoundConfigurationCommand _cmd;
        
        [Given(@"Game round configuration informations are : \(Name'(.*)',TableAmount'(.*)', GameDuration'(.*)', Interval'(.*)', BufferRoundCount'(.*)'\)")]
        public void GivenGameRoundConfigurationInformationsAreNameTableAmount0GameDuration0Interval0BufferRoundCount_2(string name, int tableAmount, int gameDuration, int interval, int bufferRoundCount)
        {
            _cmd = new CreateGameRoundConfigurationCommand {
                GameRoundConfig = new GameRoundConfiguration {
                    Name = name,
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
                Dac_CreateGameRoundConfig.Create(_cmd);
            }
            catch (Exception ex) { 
                //Assert.IsInstanceOfType
            }
        }

        [Then(@"The system can sent GameRoundConfigurations to back server")]
        public void ThenTheSystemCanSentGameRoundConfigurationsToBackServer()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The system can't sent GameRoundConfigurations to back server")]
        public void ThenTheSystemCanTSentGameRoundConfigurationsToBackServer()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
