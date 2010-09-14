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

namespace TheS.Casinova.ColorsGame.Specs.Specs.Steps
{
    [Binding]
    public class CommonSteps
    {
        MockRepository Mocks { get { return SpecEventDefinitions.Mocks; } }
    }
}
