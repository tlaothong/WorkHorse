using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using TechTalk.SpecFlow;
using Rhino.Mocks;

namespace ColorsGame.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {
        public const string Key_Dac = "mockColorsGameService";

        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }

        [Given(@"Create and initialize ShowWinnerPageViewModel and Colors game service")]
        public void GivenCreateAndInitializeShowWinnerPageViewModelAndColorsGameService()
        {
            var dac = Mocks.DynamicMock<Service.IColorsGameService>();

            ScenarioContext.Current[Key_Dac] = dac;
        }
    }
}
