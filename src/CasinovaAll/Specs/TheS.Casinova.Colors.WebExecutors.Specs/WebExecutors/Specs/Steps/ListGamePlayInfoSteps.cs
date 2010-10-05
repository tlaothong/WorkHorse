using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.Colors.Models;
using Rhino.Mocks;
using TheS.Casinova.Colors.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheS.Casinova.Colors.WebExecutors.Specs.Steps
{
    [Binding]
    public class ListGamePlayInfoSteps : ColorsGameStepsBase
    {
        [Given(@"The game play information of '(.*)' is :")]
        public void GivenTheGamePlayInformationOfXIs( string userName,Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"The game play information of '(.*)' is null")]
        public void GivenTheGamePlayInformationOfNitIsNull(string userName)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call ListGamePlayInfo\('(.*)'\)")]
        public void WhenCallListGamePlayInfoX(string userName)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The result should be :")]
        public void ThenTheResultShouldBe(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The game play information should be null")]
        public void ThenTheGamePlayInformationShouldBeNull()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
