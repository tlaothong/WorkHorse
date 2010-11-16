using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TheS.Casinova.Colors.Models;
using Rhino.Mocks;
using TheS.Casinova.Colors.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks.Constraints;

namespace TheS.Casinova.Colors.WebExecutors.Specs.Steps
{
    [Binding]
    public class ListGamePlayInfoSteps : ColorsGameStepsBase
    {
        //private ListGamePlayInfoCommand _cmd;
        //private IEnumerable<GamePlayInformation> _expectGamePlayInfo;
        //private string _userName;

        [Given(@"The game play information of '(.*)' is :")]
        public void GivenTheGamePlayInformationOfXIs(string userName, Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Call ListGamePlayInfo\('(.*)'\)")]
        public void WhenCallListGamePlayInfoX(string userName)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The game play information should be :")]
        public void ThenTheGamePlayInformationShouldBe(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The game play information should be null")]
        public void ThenTheGamePlayInformationShouldBeNull()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The game play information should be throw exception")]
        public void ThenTheGamePlayInformationShouldBeThrowException()
        {
            ScenarioContext.Current.Pending();
            
        }
    }
}
