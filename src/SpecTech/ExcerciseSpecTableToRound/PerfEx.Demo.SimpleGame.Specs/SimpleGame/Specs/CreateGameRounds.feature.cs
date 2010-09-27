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
namespace PerfEx.Demo.SimpleGame.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.3.5.2")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CreateGameRoundsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CreateGameRounds.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Create Game Rounds", "In order to create round from table configuration\r\nAs an Administrator\r\nI want to" +
                    " read the configuration and create the neccessary rounds.", ((string[])(null)));
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
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create GameRounds from the table configuration")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Create Game Rounds")]
        public virtual void CreateGameRoundsFromTheTableConfiguration()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create GameRounds from the table configuration", new string[] {
                        "record_mock"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
testRunner.Given("The GameTableConfigurator has been created and initialized");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "TableID",
                        "GameDuration",
                        "Interval"});
            table1.AddRow(new string[] {
                        "1",
                        "20",
                        "5"});
            table1.AddRow(new string[] {
                        "2",
                        "20",
                        "5"});
            table1.AddRow(new string[] {
                        "3",
                        "20",
                        "5"});
#line 9
testRunner.And("the table configuration set \'config1\' has the following data", ((string)(null)), table1);
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "TableID",
                        "RoundID",
                        "StartTime",
                        "EndTime"});
            table2.AddRow(new string[] {
                        "1",
                        "5",
                        "10:00",
                        "10:20"});
            table2.AddRow(new string[] {
                        "2",
                        "6",
                        "10:05",
                        "10:25"});
#line 14
testRunner.And("the active GameRounds are", ((string)(null)), table2);
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "TableID",
                        "RoundID",
                        "StartTime",
                        "EndTime"});
            table3.AddRow(new string[] {
                        "3",
                        "7",
                        "10:10",
                        "10:30"});
            table3.AddRow(new string[] {
                        "1",
                        "8",
                        "10:15",
                        "10:35"});
#line 18
testRunner.And("Expect result should be add", ((string)(null)), table3);
#line 23
testRunner.When("call CreateGameRounds(\'config1\', 1)");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "TableID",
                        "RoundID",
                        "StartTime",
                        "EndTime"});
            table4.AddRow(new string[] {
                        "1",
                        "5",
                        "10:00",
                        "10:20"});
            table4.AddRow(new string[] {
                        "2",
                        "6",
                        "10:05",
                        "10:25"});
            table4.AddRow(new string[] {
                        "3",
                        "7",
                        "10:10",
                        "10:30"});
            table4.AddRow(new string[] {
                        "1",
                        "8",
                        "10.15",
                        "10.35"});
#line 24
testRunner.Then("the result rounds should be saved to the ICreateGameRound.Create() with data", ((string)(null)), table4);
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create GameRounds from the table configuration2 that interval value not same at a" +
            "ll")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Create Game Rounds")]
        public virtual void CreateGameRoundsFromTheTableConfiguration2ThatIntervalValueNotSameAtAll()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create GameRounds from the table configuration2 that interval value not same at a" +
                    "ll", new string[] {
                        "record_mock"});
#line 32
this.ScenarioSetup(scenarioInfo);
#line 33
testRunner.Given("The GameTableConfigurator has been created and initialized");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "TableID",
                        "GameDuration",
                        "Interval"});
            table5.AddRow(new string[] {
                        "1",
                        "20",
                        "5"});
            table5.AddRow(new string[] {
                        "2",
                        "20",
                        "10"});
            table5.AddRow(new string[] {
                        "3",
                        "20",
                        "7"});
#line 34
testRunner.And("the table configuration set \'config2\' has the following data", ((string)(null)), table5);
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "TableID",
                        "RoundID",
                        "StartTime",
                        "EndTime"});
            table6.AddRow(new string[] {
                        "1",
                        "5",
                        "10:00",
                        "10:20"});
            table6.AddRow(new string[] {
                        "2",
                        "6",
                        "10:05",
                        "10:30"});
#line 39
testRunner.And("the active GameRounds are", ((string)(null)), table6);
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "TableID",
                        "RoundID",
                        "StartTime",
                        "EndTime"});
            table7.AddRow(new string[] {
                        "3",
                        "7",
                        "10:15",
                        "10:35"});
            table7.AddRow(new string[] {
                        "1",
                        "8",
                        "10:25",
                        "10:45"});
#line 43
testRunner.And("Expect result should be add", ((string)(null)), table7);
#line 48
testRunner.When("call CreateGameRounds(\'config2\', 1)");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "TableID",
                        "RoundID",
                        "StartTime",
                        "EndTime"});
            table8.AddRow(new string[] {
                        "1",
                        "5",
                        "10:00",
                        "10:20"});
            table8.AddRow(new string[] {
                        "2",
                        "6",
                        "10:05",
                        "10:25"});
            table8.AddRow(new string[] {
                        "3",
                        "7",
                        "10:15",
                        "10:35"});
            table8.AddRow(new string[] {
                        "1",
                        "8",
                        "10:22",
                        "10:42"});
#line 49
testRunner.Then("the result rounds should be saved to the ICreateGameRound.Create() with data", ((string)(null)), table8);
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create GameRounds from the table configuration3 that interval value not same at a" +
            "ll")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Create Game Rounds")]
        public virtual void CreateGameRoundsFromTheTableConfiguration3ThatIntervalValueNotSameAtAll()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create GameRounds from the table configuration3 that interval value not same at a" +
                    "ll", new string[] {
                        "record_mock"});
#line 57
this.ScenarioSetup(scenarioInfo);
#line 58
testRunner.Given("The GameTableConfigurator has been created and initialized");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "TableID",
                        "GameDuration",
                        "Interval"});
            table9.AddRow(new string[] {
                        "1",
                        "20",
                        "5"});
            table9.AddRow(new string[] {
                        "2",
                        "20",
                        "10"});
            table9.AddRow(new string[] {
                        "3",
                        "20",
                        "7"});
#line 59
testRunner.And("the table configuration set \'config2\' has the following data", ((string)(null)), table9);
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "TableID",
                        "RoundID",
                        "StartTime",
                        "EndTime"});
            table10.AddRow(new string[] {
                        "1",
                        "5",
                        "10:00",
                        "10:20"});
            table10.AddRow(new string[] {
                        "2",
                        "6",
                        "10:05",
                        "10:30"});
#line 64
testRunner.And("the active GameRounds are", ((string)(null)), table10);
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "TableID",
                        "RoundID",
                        "StartTime",
                        "EndTime"});
            table11.AddRow(new string[] {
                        "3",
                        "7",
                        "10:15",
                        "10:35"});
            table11.AddRow(new string[] {
                        "1",
                        "8",
                        "10:25",
                        "10:45"});
            table11.AddRow(new string[] {
                        "2",
                        "9",
                        "10:50",
                        "11:10"});
#line 68
testRunner.And("Expect result should be add", ((string)(null)), table11);
#line 74
testRunner.When("call CreateGameRounds(\'config2\', 1)");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "TableID",
                        "RoundID",
                        "StartTime",
                        "EndTime"});
            table12.AddRow(new string[] {
                        "1",
                        "5",
                        "10:00",
                        "10:20"});
            table12.AddRow(new string[] {
                        "2",
                        "6",
                        "10:05",
                        "10:25"});
            table12.AddRow(new string[] {
                        "3",
                        "7",
                        "10:15",
                        "10:35"});
            table12.AddRow(new string[] {
                        "1",
                        "8",
                        "10:25",
                        "10:45"});
            table12.AddRow(new string[] {
                        "2",
                        "9",
                        "10:50",
                        "11:10"});
#line 75
testRunner.Then("the result rounds should be saved to the ICreateGameRound.Create() with data", ((string)(null)), table12);
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
