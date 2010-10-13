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
namespace TheS.Casinova.Colors.BackServices
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.3.5.2")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CreateGameRoundsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CreateGamerRounds.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Create Game Rounds", "In order to create round from table configuration\r\nAs a back server\r\nI want to ge" +
                    "t the configuration and active game round to create the new game round.", ((string[])(null)));
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
#line 6
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "TableAmount",
                        "GameDuration",
                        "Interval"});
            table1.AddRow(new string[] {
                        "config1",
                        "4",
                        "30",
                        "5"});
            table1.AddRow(new string[] {
                        "config2",
                        "5",
                        "20",
                        "8"});
            table1.AddRow(new string[] {
                        "config3",
                        "4",
                        "30",
                        "15"});
            table1.AddRow(new string[] {
                        "config4",
                        "5",
                        "10",
                        "3"});
            table1.AddRow(new string[] {
                        "config5",
                        "7",
                        "15",
                        "10"});
#line 7
testRunner.Given("server has GameRoundConfiguration information as:", ((string)(null)), table1);
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ได้รับข้อมูล config และไม่มีโต๊ะเกมที่เริ่มเล่นอยู่ในระบบ, ระบบสร้างโต๊ะเกมใหม่ทั" +
            "้งหมด")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Create Game Rounds")]
        public virtual void ไดรบขอมลConfigและไมมโตะเกมทเรมเลนอยในระบบระบบสรางโตะเกมใหมทงหมด()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ได้รับข้อมูล config และไม่มีโต๊ะเกมที่เริ่มเล่นอยู่ในระบบ, ระบบสร้างโต๊ะเกมใหม่ทั" +
                    "้งหมด", new string[] {
                        "record_mock"});
#line 16
this.ScenarioSetup(scenarioInfo);
#line 17
testRunner.Given("The CreateGameRoundsExecutor has been created and initialized");
#line 18
testRunner.And("sent Name: \'config1\', the GameRoundConfiguration should recieved data as GameRoun" +
                    "dConfiguration(Name: \'config1\', TableAmount: \'4\', GameDuration: \'30\', Inverval: " +
                    "\'5\')");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "RoundID",
                        "StartTime",
                        "EndTime"});
            table2.AddRow(new string[] {
                        "3",
                        "12/3/2553 10:00",
                        "12/3/2553 10:30"});
            table2.AddRow(new string[] {
                        "4",
                        "12/3/2553 10:05",
                        "12/3/2553 10:35"});
            table2.AddRow(new string[] {
                        "5",
                        "12/3/2553 10:10",
                        "12/3/2553 10:40"});
#line 19
testRunner.And("server should recieved the active game round data as:", ((string)(null)), table2);
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "RoundID",
                        "StartTime",
                        "EndTime"});
            table3.AddRow(new string[] {
                        "6",
                        "12/3/2553 10:15",
                        "12/3/2553 10:45"});
            table3.AddRow(new string[] {
                        "7",
                        "12/3/2553 10:20",
                        "12/3/2553 10:50"});
#line 25
testRunner.And("Expect result should be create as:", ((string)(null)), table3);
#line 30
testRunner.When("call CreateGameRound(ConfigName: \'config1\')");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "RoundID",
                        "StartTime",
                        "EndTime"});
            table4.AddRow(new string[] {
                        "3",
                        "12/3/2553 10:00",
                        "12/3/2553 10:30"});
            table4.AddRow(new string[] {
                        "4",
                        "12/3/2553 10:05",
                        "12/3/2553 10:35"});
            table4.AddRow(new string[] {
                        "5",
                        "12/3/2553 10:10",
                        "12/3/2553 10:40"});
            table4.AddRow(new string[] {
                        "6",
                        "12/3/2553 10:15",
                        "12/3/2553 10:45"});
            table4.AddRow(new string[] {
                        "7",
                        "12/3/2553 10:20",
                        "12/3/2553 10:50"});
#line 31
testRunner.Then("the result should be create data as:", ((string)(null)), table4);
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ได้รับข้อมูล config และไม่มีโต๊ะเกมที่เริ่มเล่นอยู่ในระบบ, ระบบสร้างโต๊ะเกมใหม่ทั" +
            "้งหมด2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Create Game Rounds")]
        public virtual void ไดรบขอมลConfigและไมมโตะเกมทเรมเลนอยในระบบระบบสรางโตะเกมใหมทงหมด2()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ได้รับข้อมูล config และไม่มีโต๊ะเกมที่เริ่มเล่นอยู่ในระบบ, ระบบสร้างโต๊ะเกมใหม่ทั" +
                    "้งหมด2", new string[] {
                        "record_mock"});
#line 40
this.ScenarioSetup(scenarioInfo);
#line 41
testRunner.Given("The CreateGameRoundsExecutor has been created and initialized");
#line 42
testRunner.And("sent Name: \'config1\', the GameRoundConfiguration should recieved data as GameRoun" +
                    "dConfiguration(Name: \'config1\', TableAmount: \'4\', GameDuration: \'30\', Inverval: " +
                    "\'5\')");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "RoundID",
                        "StartTime",
                        "EndTime"});
#line 43
testRunner.And("server should recieved the active game round data as:", ((string)(null)), table5);
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "RoundID",
                        "StartTime",
                        "EndTime"});
            table6.AddRow(new string[] {
                        "1",
                        "2553/3/12 10:00",
                        "2553/3/12 10:30"});
            table6.AddRow(new string[] {
                        "2",
                        "2553/3/12 10:05",
                        "2553/3/12 10:35"});
            table6.AddRow(new string[] {
                        "3",
                        "2553/3/12 10:10",
                        "2553/3/12 10:40"});
            table6.AddRow(new string[] {
                        "4",
                        "2553/3/12 10:15",
                        "2553/3/12 10:45"});
            table6.AddRow(new string[] {
                        "5",
                        "2553/3/12 10:20",
                        "2553/3/12 10:50"});
#line 46
testRunner.And("Expect result should be create as:", ((string)(null)), table6);
#line 54
testRunner.When("call CreateGameRound(ConfigName: \'config1\')");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "RoundID",
                        "StartTime",
                        "EndTime"});
            table7.AddRow(new string[] {
                        "1",
                        "12/3/2553 10:00",
                        "12/3/2553 10:30"});
            table7.AddRow(new string[] {
                        "2",
                        "12/3/2553 10:05",
                        "12/3/2553 10:35"});
            table7.AddRow(new string[] {
                        "3",
                        "12/3/2553 10:10",
                        "12/3/2553 10:40"});
            table7.AddRow(new string[] {
                        "4",
                        "12/3/2553 10:15",
                        "12/3/2553 10:45"});
            table7.AddRow(new string[] {
                        "5",
                        "12/3/2553 10:20",
                        "12/3/2553 10:50"});
#line 55
testRunner.Then("the result should be create data as:", ((string)(null)), table7);
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion