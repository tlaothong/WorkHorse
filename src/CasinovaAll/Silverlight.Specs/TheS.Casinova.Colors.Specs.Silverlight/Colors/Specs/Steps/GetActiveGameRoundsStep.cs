using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.ColorsSvc;
using SpecFlowAssist;
using TheS.Casinova.Colors.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheS.Casinova.Colors.Models;
using System.Threading;

namespace TheS.Casinova.Colors.Specs.Steps
{
    [Binding]
    public class GetActiveGameRoundsStep
    {
        #region Background
        
        [Given(@"Back service have active game rounds are:")]
        public void GivenBackServiceHaveActiveGameRoundsAre(Table table)
        {
            ScenarioContext.Current.Set<IEnumerable<GameRoundInformation>>(
                table.CreateSet<GameRoundInformation>());
        } 

        #endregion Background

        [When(@"Send request GetListActiveGameRounds\(\) to web server")]
        public void WhenSendRequestGetListActiveGameRoundsToWebServer()
        {
            var viewModel = ScenarioContext.Current.Get<GamePlayPageViewModel>();
            viewModel.GetListActiveGameRounds();
            ScenarioContext.Current.Get<AutoResetEvent>().WaitOne(3);
        }

        [Then(@"Tables in GamePlayViewModel has create from ListActivegameRounds")]
        public void ThenServerRespondListActiveGameRoundAre(Table table)
        {
            var actual = ScenarioContext.Current.Get<GamePlayPageViewModel>().Tables;
            var expected = table.CreateSet<GameTable>();


            //CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
            Assert.IsTrue(actual.Count > 0, "Tables should have rows");
            Assert.IsNotNull(actual);
        }
    }
}
