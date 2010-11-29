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
    public partial class N2NGetActiveGameRoundFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GetActiveGameRound.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "N2N Get active game round", @"1.Game table page loaded (Silverlight)
2.Game has create and initialize game play viewmodel and game service (Silverlight)
3.Send request GetListActiveGameRounds to web server (Silverlight)
4.Web server get request (Web Server)
4.1 Web server have list active game rounds (Web Server)
4.1.1 List active game rounds (Web server)
4.1.2 Send list active game rounds back to client (Web Server)
4.2 Web server don't have list active game round (Web Server)
4.2.1 Send empty list active game round back to client (Web Server)
5.Create game table from list active game rounds and display game tables (Silverlight)", ((string[])(null)));
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
#line 13
#line 14
testRunner.Given("Create and initialize GamePlayViewModel and Colors game service");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Request active game rounds get active list")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "N2N Get active game round")]
        [Microsoft.Silverlight.Testing.TagAttribute("record_mock")]
        public virtual void RequestActiveGameRoundsGetActiveList()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Request active game rounds get active list", new string[] {
                        "record_mock"});
#line 17
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "RoundID",
                        "StartTime",
                        "EndTime"});
            table1.AddRow(new string[] {
                        "1",
                        "2010-11-17 09:00:00",
                        "2010-11-17 09:15:00"});
            table1.AddRow(new string[] {
                        "2",
                        "2010-11-17 09:15:00",
                        "2010-11-17 09:30:00"});
            table1.AddRow(new string[] {
                        "3",
                        "2010-11-17 09:30:00",
                        "2010-11-17 09:45:00"});
#line 18
testRunner.Given("Back service have active game rounds are:", ((string)(null)), table1);
#line 23
testRunner.When("Send request GetListActiveGameRounds() to web server");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Round",
                        "StartTime",
                        "EndTime"});
            table2.AddRow(new string[] {
                        "1",
                        "2010-11-17 09:00:00",
                        "2010-11-17 09:15:00"});
            table2.AddRow(new string[] {
                        "2",
                        "2010-11-17 09:15:00",
                        "2010-11-17 09:30:00"});
            table2.AddRow(new string[] {
                        "3",
                        "2010-11-17 09:30:00",
                        "2010-11-17 09:45:00"});
#line 24
testRunner.Then("Tables in GamePlayViewModel has create from ListActivegameRounds", ((string)(null)), table2);
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Request active game rounds but web server don\'t have active game rounds")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "N2N Get active game round")]
        [Microsoft.Silverlight.Testing.TagAttribute("record_mock")]
        public virtual void RequestActiveGameRoundsButWebServerDonTHaveActiveGameRounds()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Request active game rounds but web server don\'t have active game rounds", new string[] {
                        "record_mock"});
#line 32
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "RoundID",
                        "StartTime",
                        "EndTime"});
#line 33
testRunner.Given("Back service have active game rounds are:", ((string)(null)), table3);
#line 35
testRunner.When("Send request GetListActiveGameRounds() to web server");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "Round",
                        "StartTime",
                        "EndTime"});
#line 36
testRunner.Then("Tables in GamePlayViewModel don\'t create ListActivegameRounds", ((string)(null)), table4);
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Request active game rounds get active list (Request more thand 1 request)")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "N2N Get active game round")]
        [Microsoft.Silverlight.Testing.TagAttribute("record_mock")]
        public virtual void RequestActiveGameRoundsGetActiveListRequestMoreThand1Request()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Request active game rounds get active list (Request more thand 1 request)", new string[] {
                        "record_mock"});
#line 40
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "RoundID",
                        "StartTime",
                        "EndTime"});
            table5.AddRow(new string[] {
                        "1",
                        "2010-11-17 09:00:00",
                        "2010-11-17 09:15:00"});
            table5.AddRow(new string[] {
                        "2",
                        "2010-11-17 09:15:00",
                        "2010-11-17 09:30:00"});
            table5.AddRow(new string[] {
                        "3",
                        "2010-11-17 09:30:00",
                        "2010-11-17 09:45:00"});
#line 41
testRunner.Given("Back service have active game rounds are:", ((string)(null)), table5);
#line 46
testRunner.When("Send request GetListActiveGameRounds() to web server");
#line 47
testRunner.And("Send request GetListActiveGameRounds() to web server");
#line 48
testRunner.And("Send request GetListActiveGameRounds() to web server");
#line 49
testRunner.And("Send request GetListActiveGameRounds() to web server");
#line 50
testRunner.And("Send request GetListActiveGameRounds() to web server");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "Round",
                        "StartTime",
                        "EndTime"});
            table6.AddRow(new string[] {
                        "Colors",
                        "1",
                        "2010-11-17 09:00:00",
                        "2010-11-17 09:15:00"});
            table6.AddRow(new string[] {
                        "Colors",
                        "2",
                        "2010-11-17 09:15:00",
                        "2010-11-17 09:30:00"});
            table6.AddRow(new string[] {
                        "Colors",
                        "3",
                        "2010-11-17 09:30:00",
                        "2010-11-17 09:45:00"});
#line 51
testRunner.Then("Tables in GamePlayViewModel has create from ListActivegameRounds", ((string)(null)), table6);
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Request active game rounds but web server don\'t have active game rounds (Request " +
            "more than 1 request)")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "N2N Get active game round")]
        [Microsoft.Silverlight.Testing.TagAttribute("record_mock")]
        public virtual void RequestActiveGameRoundsButWebServerDonTHaveActiveGameRoundsRequestMoreThan1Request()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Request active game rounds but web server don\'t have active game rounds (Request " +
                    "more than 1 request)", new string[] {
                        "record_mock"});
#line 58
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "RoundID",
                        "StartTime",
                        "EndTime"});
#line 59
testRunner.Given("Back service have active game rounds are:", ((string)(null)), table7);
#line 61
testRunner.When("Send request GetListActiveGameRounds() to web server");
#line 62
testRunner.And("Send request GetListActiveGameRounds() to web server");
#line 63
testRunner.And("Send request GetListActiveGameRounds() to web server");
#line 64
testRunner.And("Send request GetListActiveGameRounds() to web server");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "Round",
                        "StartTime",
                        "EndTime"});
#line 65
testRunner.Then("Tables in GamePlayViewModel don\'t create ListActivegameRounds", ((string)(null)), table8);
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
