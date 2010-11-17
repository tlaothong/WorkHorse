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
    public partial class N2NGetGameStatisticsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GetGameStatistics.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "N2N Get game statistics", @"1.Game timeout (Silverlight)
2.Send request get game result identify game round by roundID to web server (Silverlight)
3.Send POT TotalAmountOfBlack and TotablAmountOfWhite where GameRoundID and roundID match back to client (Web Server)
4.Compare POT between TotalAmountOfBlack and TotalAmountOfWhite for winner (Silverlight)
5.Display winner, TotalAmountOfBlack and TotalAmountOfWhite (Silverlight)
6.If player have bet in winner pot gmae has display congratulation and pay award (Silverlight)", ((string[])(null)));
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
#line 9
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "RoundID",
                        "StartTime",
                        "EndTime",
                        "BlackPot",
                        "WhitePot",
                        "HandCount"});
            table1.AddRow(new string[] {
                        "1",
                        "",
                        "",
                        "1523",
                        "4526",
                        "452"});
            table1.AddRow(new string[] {
                        "2",
                        "",
                        "",
                        "445",
                        "12399",
                        "1155"});
            table1.AddRow(new string[] {
                        "3",
                        "",
                        "",
                        "75663",
                        "45266",
                        "5632"});
#line 10
testRunner.Given("Web server have game results are", ((string)(null)), table1);
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Request game result to web server, server have roundID match (roundID = 1)")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "N2N Get game statistics")]
        [Microsoft.Silverlight.Testing.TagAttribute("record_mock")]
        public virtual void RequestGameResultToWebServerServerHaveRoundIDMatchRoundID1()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Request game result to web server, server have roundID match (roundID = 1)", new string[] {
                        "record_mock"});
#line 18
this.ScenarioSetup(scenarioInfo);
#line 19
testRunner.When("Request GetGameResult( roundID = \'1\' )");
#line 20
testRunner.Then("Game has display game result roundID=\'1\', Winner=\'Black\', BlackPot=\'1523\', WhiteP" +
                    "ot=\'4526\', Hands=\'452\'");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Request game result to web server, server have roundID match (roundID = 2)")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "N2N Get game statistics")]
        [Microsoft.Silverlight.Testing.TagAttribute("record_mock")]
        public virtual void RequestGameResultToWebServerServerHaveRoundIDMatchRoundID2()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Request game result to web server, server have roundID match (roundID = 2)", new string[] {
                        "record_mock"});
#line 23
this.ScenarioSetup(scenarioInfo);
#line 24
testRunner.When("Request GetGameResult( roundID = \'2\' )");
#line 25
testRunner.Then("Game has display game result roundID=\'2\', Winner=\'Black\', BlackPot=\'445\', WhitePo" +
                    "t=\'12399\', Hands=\'1155\'");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Request game result to web server, server have roundID match (roundID = 3)")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "N2N Get game statistics")]
        [Microsoft.Silverlight.Testing.TagAttribute("record_mock")]
        public virtual void RequestGameResultToWebServerServerHaveRoundIDMatchRoundID3()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Request game result to web server, server have roundID match (roundID = 3)", new string[] {
                        "record_mock"});
#line 28
this.ScenarioSetup(scenarioInfo);
#line 29
testRunner.When("Request GetGameResult( roundID = \'3\' )");
#line 30
testRunner.Then("Game has display game result roundID=\'3\', Winner=\'White\', BlackPot=\'75663\', White" +
                    "Pot=\'45266\', Hands=\'5632\'");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
