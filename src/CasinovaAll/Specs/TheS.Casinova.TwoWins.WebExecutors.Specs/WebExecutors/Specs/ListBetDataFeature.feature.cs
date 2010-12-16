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
namespace TheS.Casinova.TwoWins.WebExecutors.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.3.5.2")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class ListBetDataFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ListBetDataFeature.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ListBetData", "In order to list bet data\r\nAs a system\r\nI want to list bet data of all players", ((string[])(null)));
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
#line 7
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "RoundID",
                        "UserName",
                        "HandID",
                        "Amount",
                        "OldAmount",
                        "Pot",
                        "WinState",
                        "Reward",
                        "HandStatus",
                        "Change",
                        "DateTime"});
            table1.AddRow(new string[] {
                        "1",
                        "Nayit",
                        "1",
                        "700",
                        "0",
                        "700",
                        "",
                        "0",
                        "Normal",
                        "False",
                        "10:54 12/13/2010"});
            table1.AddRow(new string[] {
                        "2",
                        "Nayit",
                        "1",
                        "28",
                        "0",
                        "28",
                        "Low",
                        "78",
                        "Normal",
                        "False",
                        "10:58 12/13/2010"});
            table1.AddRow(new string[] {
                        "1",
                        "Nayit",
                        "2",
                        "1500",
                        "700",
                        "1500",
                        "Hight",
                        "1901",
                        "Normal",
                        "True",
                        "11:02 12/13/2010"});
            table1.AddRow(new string[] {
                        "1",
                        "Kob",
                        "3",
                        "44",
                        "0",
                        "1544",
                        "Low",
                        "99",
                        "Normal",
                        "False",
                        "11:14 12/13/2010"});
            table1.AddRow(new string[] {
                        "2",
                        "Eye",
                        "2",
                        "550",
                        "0",
                        "578",
                        "",
                        "0",
                        "Normal",
                        "False",
                        "11:20 12/13/2010"});
            table1.AddRow(new string[] {
                        "1",
                        "Krai",
                        "4",
                        "133",
                        "0",
                        "1677",
                        "",
                        "0",
                        "Normal",
                        "False",
                        "11:21 12/13/2010"});
            table1.AddRow(new string[] {
                        "2",
                        "Jae",
                        "3",
                        "1000",
                        "0",
                        "1578",
                        "Hight",
                        "1500",
                        "Critical",
                        "False",
                        "11:29 12/13/2010"});
            table1.AddRow(new string[] {
                        "1",
                        "Sak",
                        "5",
                        "323",
                        "0",
                        "2000",
                        "",
                        "0",
                        "Critical",
                        "False",
                        "11:30 12/13/2010"});
#line 8
testRunner.Given("Server has bet data of finished game", ((string)(null)), table1);
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[ListBetData]ระบบได้รับข้อมูล FromRoundID, ThruRoundID ถูกต้อง ระบบสามารถดึงข้อมู" +
            "ล BetData ได้")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ListBetData")]
        public virtual void ListBetDataระบบไดรบขอมลFromRoundIDThruRoundIDถกตองระบบสามารถดงขอมลBetDataได()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[ListBetData]ระบบได้รับข้อมูล FromRoundID, ThruRoundID ถูกต้อง ระบบสามารถดึงข้อมู" +
                    "ล BetData ได้", new string[] {
                        "record_mock",
                        "record_mock"});
#line 20
this.ScenarioSetup(scenarioInfo);
#line 21
testRunner.Given("The ListBetDataExecutor has been created and initialized");
#line 22
testRunner.And("Sent FromRoundID\'1\' ThruRoundID\'2\' to list bet data");
#line 23
testRunner.When("Call ListBetDataExecutor()");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "RoundID",
                        "UserName",
                        "HandID",
                        "Amount",
                        "OldAmount",
                        "Pot",
                        "WinState",
                        "Reward",
                        "HandStatus",
                        "Change",
                        "DateTime"});
            table2.AddRow(new string[] {
                        "1",
                        "Nayit",
                        "1",
                        "700",
                        "0",
                        "700",
                        "",
                        "0",
                        "Normal",
                        "False",
                        "10:54 12/13/2010"});
            table2.AddRow(new string[] {
                        "1",
                        "Nayit",
                        "2",
                        "1500",
                        "700",
                        "1500",
                        "Hight",
                        "1901",
                        "Normal",
                        "True",
                        "11:02 12/13/2010"});
            table2.AddRow(new string[] {
                        "1",
                        "Kob",
                        "3",
                        "44",
                        "0",
                        "1544",
                        "Low",
                        "99",
                        "Normal",
                        "False",
                        "11:14 12/13/2010"});
            table2.AddRow(new string[] {
                        "1",
                        "Krai",
                        "4",
                        "133",
                        "0",
                        "1677",
                        "",
                        "0",
                        "Normal",
                        "False",
                        "11:21 12/13/2010"});
            table2.AddRow(new string[] {
                        "1",
                        "Sak",
                        "5",
                        "323",
                        "0",
                        "2000",
                        "",
                        "0",
                        "Critical",
                        "False",
                        "11:30 12/13/2010"});
            table2.AddRow(new string[] {
                        "2",
                        "Nayit",
                        "1",
                        "28",
                        "0",
                        "28",
                        "Low",
                        "78",
                        "Normal",
                        "False",
                        "10:58 12/13/2010"});
            table2.AddRow(new string[] {
                        "2",
                        "Eye",
                        "2",
                        "550",
                        "0",
                        "578",
                        "",
                        "0",
                        "Normal",
                        "False",
                        "11:20 12/13/2010"});
            table2.AddRow(new string[] {
                        "2",
                        "Jae",
                        "3",
                        "1000",
                        "0",
                        "1578",
                        "Hight",
                        "1500",
                        "Critical",
                        "False",
                        "11:29 12/13/2010"});
#line 24
testRunner.Then("BetData information should be as :", ((string)(null)), table2);
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[ListBetData]ระบบได้รับข้อมูล ThruRoundID ที่ยังไม่จบเกม ระบบดึงข้อมูล BetData ถึ" +
            "งโต๊ะเกมสุดท้ายที่จบเกม")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ListBetData")]
        public virtual void ListBetDataระบบไดรบขอมลThruRoundIDทยงไมจบเกมระบบดงขอมลBetDataถงโตะเกมสดทายทจบเกม()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[ListBetData]ระบบได้รับข้อมูล ThruRoundID ที่ยังไม่จบเกม ระบบดึงข้อมูล BetData ถึ" +
                    "งโต๊ะเกมสุดท้ายที่จบเกม", new string[] {
                        "record_mock"});
#line 36
this.ScenarioSetup(scenarioInfo);
#line 37
testRunner.Given("The ListBetDataExecutor has been created and initialized");
#line 38
testRunner.And("Sent FromRoundID\'1\' ThruRoundID\'4\' to list bet data");
#line 39
testRunner.When("Call ListBetDataExecutor()");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "RoundID",
                        "UserName",
                        "HandID",
                        "Amount",
                        "OldAmount",
                        "Pot",
                        "WinState",
                        "Reward",
                        "HandStatus",
                        "Change",
                        "DateTime"});
            table3.AddRow(new string[] {
                        "1",
                        "Nayit",
                        "1",
                        "700",
                        "0",
                        "700",
                        "",
                        "0",
                        "Normal",
                        "False",
                        "10:54 12/13/2010"});
            table3.AddRow(new string[] {
                        "1",
                        "Nayit",
                        "2",
                        "1500",
                        "700",
                        "1500",
                        "Hight",
                        "1901",
                        "Normal",
                        "True",
                        "11:02 12/13/2010"});
            table3.AddRow(new string[] {
                        "1",
                        "Kob",
                        "3",
                        "44",
                        "0",
                        "1544",
                        "Low",
                        "99",
                        "Normal",
                        "False",
                        "11:14 12/13/2010"});
            table3.AddRow(new string[] {
                        "1",
                        "Krai",
                        "4",
                        "133",
                        "0",
                        "1677",
                        "",
                        "0",
                        "Normal",
                        "False",
                        "11:21 12/13/2010"});
            table3.AddRow(new string[] {
                        "1",
                        "Sak",
                        "5",
                        "323",
                        "0",
                        "2000",
                        "",
                        "0",
                        "Critical",
                        "False",
                        "11:30 12/13/2010"});
            table3.AddRow(new string[] {
                        "2",
                        "Nayit",
                        "1",
                        "28",
                        "0",
                        "28",
                        "Low",
                        "78",
                        "Normal",
                        "False",
                        "10:58 12/13/2010"});
            table3.AddRow(new string[] {
                        "2",
                        "Eye",
                        "2",
                        "550",
                        "0",
                        "578",
                        "",
                        "0",
                        "Normal",
                        "False",
                        "11:20 12/13/2010"});
            table3.AddRow(new string[] {
                        "2",
                        "Jae",
                        "3",
                        "1000",
                        "0",
                        "1578",
                        "Hight",
                        "1500",
                        "Critical",
                        "False",
                        "11:29 12/13/2010"});
#line 40
testRunner.Then("BetData information should be as :", ((string)(null)), table3);
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[ListBetData]ระบบได้รับข้อมูล FromRoundID, ThruRoundID ที่ยังไม่จบเกม ระบบได้ข้อม" +
            "ูล BetData เป็น null")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ListBetData")]
        public virtual void ListBetDataระบบไดรบขอมลFromRoundIDThruRoundIDทยงไมจบเกมระบบไดขอมลBetDataเปนNull()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[ListBetData]ระบบได้รับข้อมูล FromRoundID, ThruRoundID ที่ยังไม่จบเกม ระบบได้ข้อม" +
                    "ูล BetData เป็น null", new string[] {
                        "record_mock"});
#line 52
this.ScenarioSetup(scenarioInfo);
#line 53
testRunner.Given("The ListBetDataExecutor has been created and initialized");
#line 54
testRunner.And("Sent FromRoundID\'3\' ThruRoundID\'4\' to list bet data");
#line 55
testRunner.When("Call ListBetDataExecutor()");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "RoundID",
                        "UserName",
                        "HandID",
                        "Amount",
                        "OldAmount",
                        "Pot",
                        "Reward",
                        "GetBack",
                        "HandStatus",
                        "Change",
                        "DateTime"});
#line 56
testRunner.Then("BetData information should be as :", ((string)(null)), table4);
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[ListBetData]ระบบได้รับข้อมูล FromRoundID ไม่ถูกต้อง ระบบไม่สามารถดึงข้อมูล BetDa" +
            "ta ได้")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ListBetData")]
        public virtual void ListBetDataระบบไดรบขอมลFromRoundIDไมถกตองระบบไมสามารถดงขอมลBetDataได()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[ListBetData]ระบบได้รับข้อมูล FromRoundID ไม่ถูกต้อง ระบบไม่สามารถดึงข้อมูล BetDa" +
                    "ta ได้", new string[] {
                        "record_mock"});
#line 61
this.ScenarioSetup(scenarioInfo);
#line 62
testRunner.Given("The ListBetDataExecutor has been created and initialized");
#line 63
testRunner.And("Sent FromRoundID\'-1\' ThruRoundID\'4\' for list bet data validation");
#line 64
testRunner.When("Call ListBetDataExecutor() for validate input");
#line 65
testRunner.Then("BetData information should be throw exception");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[ListBetData]ระบบได้รับข้อมูล ThruRoundID ไม่ถูกต้อง ระบบไม่สามารถดึงข้อมูล BetDa" +
            "ta ได้")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ListBetData")]
        public virtual void ListBetDataระบบไดรบขอมลThruRoundIDไมถกตองระบบไมสามารถดงขอมลBetDataได()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[ListBetData]ระบบได้รับข้อมูล ThruRoundID ไม่ถูกต้อง ระบบไม่สามารถดึงข้อมูล BetDa" +
                    "ta ได้", new string[] {
                        "record_mock"});
#line 68
this.ScenarioSetup(scenarioInfo);
#line 69
testRunner.Given("The ListBetDataExecutor has been created and initialized");
#line 70
testRunner.And("Sent FromRoundID\'1\' ThruRoundID\'-4\' for list bet data validation");
#line 71
testRunner.When("Call ListBetDataExecutor() for validate input");
#line 72
testRunner.Then("BetData information should be throw exception");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
