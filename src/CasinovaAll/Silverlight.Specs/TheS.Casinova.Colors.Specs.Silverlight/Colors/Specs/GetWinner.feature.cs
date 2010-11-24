// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.3.5.2
//      Runtime Version:4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
namespace TheS.Casinova.Colors.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.3.5.2")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class N2NGetWinnerFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GetWinner.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "N2N Get winner", @"1.Player click get winner button (Silverlight)
2.Check account balance (Silverlight)
2.1 Balance lowthan cost of winner information display error end (Silverlight)
3.Save player action in PayLog, subtract account balance and display waiting status (Silverlight)
4.Send get winner identify by username, roundID to web server (Silverlight)
5.Web server generate trakingID and send it back to client (Web Server)
6.Save trackingID into PayLog and sent trackingID to Observer for follow lot until found this trackingID (Silverlight)
7.Send request get list game play information to web server (Silverlight)
8.Server list game play information and send it back to client (Web Server)
9.Display game play information TotalAmountOfBlack, TotalAmountOfWhite and Winner (Silverlight)
10.If OnGoingTrackingID not equal TrackingID and PayLog count low than one repeat step 5 (Silverlight)
11.Delete trackingID in PayLog (Silverlight)
12.If observer don't follow anything, remove waiting state (Silverlight)", ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
            this.FeatureBackground();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void FeatureBackground()
        {
#line 16
#line 17
testRunner.Given("Create and initialize GamePlayViewModel and Colors game service");
#line 18
testRunner.And("Initialize mock for get winner information");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Get winner button has click save player action in PayLog")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "N2N Get winner")]
        [Microsoft.Silverlight.Testing.TagAttribute("record_mock")]
        public virtual void GetWinnerButtonHasClickSavePlayerActionInPayLog()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get winner button has click save player action in PayLog", new string[] {
                        "record_mock"});
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
testRunner.When("Click get winner in game round 20");
#line 23
testRunner.Then("PayLog has save RoundID=\'20\', Count=\'1\'");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Get winner button has click more than one, game view model has save player action" +
            " in PayLog more than one log")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "N2N Get winner")]
        [Microsoft.Silverlight.Testing.TagAttribute("record_mock")]
        public virtual void GetWinnerButtonHasClickMoreThanOneGameViewModelHasSavePlayerActionInPayLogMoreThanOneLog()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get winner button has click more than one, game view model has save player action" +
                    " in PayLog more than one log", new string[] {
                        "record_mock"});
#line 26
this.ScenarioSetup(scenarioInfo);
#line 27
testRunner.When("Click get winner in game round 20");
#line 28
testRunner.And("Click get winner in game round 20");
#line 29
testRunner.And("Click get winner in game round 20");
#line 30
testRunner.Then("PayLog has save RoundID=\'20\', Count=\'3\'");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Get winner button has click in another game roundID, pay log has save")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "N2N Get winner")]
        [Microsoft.Silverlight.Testing.TagAttribute("record_mock")]
        public virtual void GetWinnerButtonHasClickInAnotherGameRoundIDPayLogHasSave()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get winner button has click in another game roundID, pay log has save", new string[] {
                        "record_mock"});
#line 33
this.ScenarioSetup(scenarioInfo);
#line 34
testRunner.When("Click get winner in game round 20");
#line 35
testRunner.And("Click get winner in game round 20");
#line 36
testRunner.And("Click get winner in game round 21");
#line 37
testRunner.And("Click get winner in game round 22");
#line 38
testRunner.And("Click get winner in game round 23");
#line 39
testRunner.And("Click get winner in game round 20");
#line 40
testRunner.Then("PayLog has save RoundID=\'20\', Count=\'3\'");
#line 41
testRunner.And("PayLog has save RoundID=\'21\', Count=\'1\'");
#line 42
testRunner.And("PayLog has save RoundID=\'22\', Count=\'1\'");
#line 43
testRunner.And("PayLog has save RoundID=\'23\', Count=\'1\'");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
