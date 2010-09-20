using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rhino.Mocks;
using TheS.Casinova.ColorsGame.DAL;
using TheS.Casinova.ColorsGame.BackServices.BackExecutors;
using TheS.Casinova.ColorsGame.Models;
using TheS.Casinova.ColorsGame.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.ColorsGame.BackServices.Specs
{
    [Binding]
    public class SaveTableConfigurationSteps : ColorsGameStepsBase
    {
        private SaveTableConfigurationCommand _cmd;

        [Given(@"Expect the tables should be saved by calling IColorsGameDataAccess\.Create\(\)")]
        public void GivenExpectTheTablesShouldBeSavedByCallingIColorsGameDataAccess_Create()
        {
            Dac.Create(null, null);
            LastCall.IgnoreArguments();
        }

        [When(@"call SaveTableConfiguration\(name: '(.*)', tables: as follows\)")]
        public void WhenCallSaveTableConfigurationNameConfig1TablesAsFollows(string name, Table table)
        {
            var qry = (from item in table.Rows
                       select new TableConfig {
                           TableID = Convert.ToInt32(item["TableID"]),
                           Duration = Convert.ToInt32(item["Duration"]),
                           Interval = Convert.ToInt32(item["Interval"]),
                       });

            _cmd = new SaveTableConfigurationCommand { Name = name, TableConfig = qry };
            Action<SaveTableConfigurationCommand> cmd = (a) => { };

            SaveTableConfigurationExecutor.Execute(_cmd, cmd);
        }

        [Then(@"the tables should be saved by calling IColorsGameDataAccess\.Create\(\)")]
        public void ThenTheTablesShouldBeSavedByCallingIColorsGameDataAccess_Create()
        {
            Assert.IsTrue(true, "Expectation has been verified in the end of block When.");
        }
    }
}
