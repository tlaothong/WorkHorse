using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.Colors.Models;
using TheS.Casinova.Colors.Commands;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.Colors.BackServices.Specs
{
    [Binding]
    public class CreateGameRoundConfigurationsSteps
        : ColorsGameStepsBase
    {
        [Given(@"Expect result should be add GameRoundConfig\(Name: '(.*)', TableAmount: '(.*)', GameDuration: '(.*)', Interval: '(.*)'\)")]
        public void GivenExpectResultShouldBeAddGameRoundConfigurationNameXTableAmountXGameDurationXIntervalX(string name, int tableAmount, int gameDuration, int interval)
        {
            Func<GameRoundConfiguration, CreateGameRoundConfigurationCommand, GameRoundConfiguration> checkdata = (gameRoundConf, cmd) => {
                Assert.AreEqual(name, gameRoundConf.Name, "Config name");
                Assert.AreEqual(tableAmount, gameRoundConf.TableAmount, "Table amount");
                Assert.AreEqual(gameDuration, gameRoundConf.GameDuration, "Game duration");
                Assert.AreEqual(interval, gameRoundConf.Interval, "Interval");
                return gameRoundConf;
            };

            Dac_CreateGameRoundConfigurations.Create(new GameRoundConfiguration(), new CreateGameRoundConfigurationCommand());
            LastCall.IgnoreArguments().Do(checkdata);
        }

        [When(@"call CreateGameRoundConfiguration\(GameRoundConfig\(Name: '(.*)', TableAmount: '(.*)', GameDuration: '(.*)', Interval: '(.*)'\)\)")]
        public void WhenCallCreateGameRoundConfigurationGameRoundConfigurationNameXTableAmountXGameDurationXIntervalX(string name, int tableAmount, int gameDuration, int interval)
        {
            CreateGameRoundConfigurationCommand cmd = new CreateGameRoundConfigurationCommand {
                GameRoundConfig = new GameRoundConfiguration {
                    Name = name,
                    TableAmount = tableAmount,
                    GameDuration = gameDuration,
                    Interval = interval,
                },
            };

            CreateGameRoundConfigurationsExecutor.Execute(cmd, (x) => { });
        }

        [Then(@"the GameRoundConfig should be saved to the ICreateGameRoundConfigurations\.Create\(GameRoundConfig, CreateGameRoundConfigurationCommand\) with expected data")]
        public void ThenTheGameRoundConfigurationShouldBeSavedToTheICreateGameRoundConfigurations_CreateGameRoundConfigurationCreateGameRoundConfigurationsCommandWithExpectedData()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
    }
}
