using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.ColorsGame.Models;
using Rhino.Mocks;
using TheS.Casinova.ColorsGame.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.ColorsGame.BackServices.Specs
{
    [Binding]
    public class ListGameTableConfigurationsSteps
        : ColorsGameStepsBase
    {
        private IEnumerable<TableConfiguration> result;

        [Given(@"sent Configuration name: '(.*)' and expected game configuration as:")]
        public void GivenSentConfigurationNameConfig1AndExpectedGameConfigurationAs(string name, Table table)
        {
            result = (from item in table.Rows
                      where item["Name"] == name
                      select new TableConfiguration {
                          TableID = Convert.ToInt32(item["TableID"]),
                          GameDuration = Convert.ToInt32(item["GameDuration"]),
                          Interval = Convert.ToInt32(item["Interval"]),
                      });

            SetupResult.For(Dqr.List(new ListGameTableConfigurationsCommand { Name = name }))
                .IgnoreArguments().Return(result);
        }

        [When(@"call ListGameTableConfigurations\(name: '(.*)'\)")]
        public void WhenCallListGameTableConfigurationsNameConfig1(string name)
        {
            ListGameTableConfigurationsCommand cmd = new ListGameTableConfigurationsCommand { Name = name };
            ListGameTableConfigurationsExecutor.Execute(cmd, x => { });
        }

        [Then(@"the game configurations should be\('(.*)'\):")]
        public void ThenTheGameConfigurationsShouldBeConfig1(string name, Table table)
        {
            var expected = (from item in table.Rows
                            where item["Name"] == name
                            select new {
                                TableID = Convert.ToInt32(item["TableID"]),
                                GameDuration = Convert.ToInt32(item["GameDuration"]),
                                Interval = Convert.ToInt32(item["Interval"]),
                            });

            var actual = (from item in result
                            select new {
                                TableID = item.TableID,
                                GameDuration = item.GameDuration,
                                Interval = item.Interval,
                            });

            CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
        }
    }
}
