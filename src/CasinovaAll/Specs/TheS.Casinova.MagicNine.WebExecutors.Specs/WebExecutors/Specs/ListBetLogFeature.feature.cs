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
namespace TheS.Casinova.MagicNine.WebExecutors.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.3.5.2")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class ListBetLogFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ListBetLogFeature.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ListBetLog", "In order to list bet log\r\nAs a system\r\nI want to list bet log of player", ((string[])(null)));
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
                        "UserName",
                        "RoundID",
                        "BetDateTime",
                        "BetOrder",
                        "BetTrackingID"});
            table1.AddRow(new string[] {
                        "Nit",
                        "1",
                        "10:00",
                        "5",
                        "03D51BC1-1656-454B-8CB2-4202BA8C21D7"});
            table1.AddRow(new string[] {
                        "Nit",
                        "1",
                        "10:05",
                        "9",
                        "09630A4D-0B6C-4672-95F0-0AE5E48614FD"});
            table1.AddRow(new string[] {
                        "Nit",
                        "1",
                        "10:10",
                        "17",
                        "2ED52C48-5C9A-471B-9335-DDAE19F44BE6"});
            table1.AddRow(new string[] {
                        "Nit",
                        "1",
                        "10:15",
                        "26",
                        "833278AF-A221-4916-90CD-96951051F40F"});
#line 8
testRunner.Given("server has player information as:", ((string)(null)), table1);
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบได้รับ userName และ roundId ถูกต้อง")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ListBetLog")]
        public virtual void ระบบไดรบUserNameและRoundIdถกตอง()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ระบบได้รับ userName และ roundId ถูกต้อง", new string[] {
                        "record_mock",
                        "record_mock"});
#line 16
this.ScenarioSetup(scenarioInfo);
#line 17
testRunner.Given("The ListBetLogExecutor has been created and initialized");
#line 18
testRunner.And("Expect execute ListBetLogCommand");
#line 19
testRunner.When("Call ListBetLogExecutor(userName\'Nit\', roundId \'1\')");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "UserName",
                        "RoundID",
                        "BetDateTime",
                        "BetOrder",
                        "BetTrackingID"});
            table2.AddRow(new string[] {
                        "Nit",
                        "1",
                        "10:00",
                        "5",
                        "03D51BC1-1656-454B-8CB2-4202BA8C21D7"});
            table2.AddRow(new string[] {
                        "Nit",
                        "1",
                        "10:05",
                        "9",
                        "09630A4D-0B6C-4672-95F0-0AE5E48614FD"});
            table2.AddRow(new string[] {
                        "Nit",
                        "1",
                        "10:10",
                        "17",
                        "2ED52C48-5C9A-471B-9335-DDAE19F44BE6"});
            table2.AddRow(new string[] {
                        "Nit",
                        "1",
                        "10:15",
                        "26",
                        "833278AF-A221-4916-90CD-96951051F40F"});
#line 20
testRunner.Then("The result of BetLog should be :", ((string)(null)), table2);
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบได้รับ userName ไม่ถูกต้อง #ListBetLog")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ListBetLog")]
        public virtual void ระบบไดรบUserNameไมถกตองListBetLog()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ระบบได้รับ userName ไม่ถูกต้อง #ListBetLog", new string[] {
                        "record_mock"});
#line 28
this.ScenarioSetup(scenarioInfo);
#line 29
testRunner.Given("The ListBetLogExecutor has been created and initialized");
#line 30
testRunner.When("Call ListBetLogExecutor(userName\'\', roundId \'1\')");
#line 31
testRunner.Then("The result of BetLog should be null");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบได้รับ roundId  ไม่ถูกต้อง #ListBetLog")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ListBetLog")]
        public virtual void ระบบไดรบRoundIdไมถกตองListBetLog()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ระบบได้รับ roundId  ไม่ถูกต้อง #ListBetLog", new string[] {
                        "record_mock"});
#line 34
this.ScenarioSetup(scenarioInfo);
#line 35
testRunner.Given("The ListBetLogExecutor has been created and initialized");
#line 36
testRunner.When("Call ListBetLogExecutor(userName\'Nit\', roundId \'-1\')");
#line 37
testRunner.Then("The result of BetLog should be null");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบได้รับ userName และ roundId  ไม่ถูกต้อง #ListBetLog")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ListBetLog")]
        public virtual void ระบบไดรบUserNameและRoundIdไมถกตองListBetLog()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ระบบได้รับ userName และ roundId  ไม่ถูกต้อง #ListBetLog", new string[] {
                        "record_mock"});
#line 40
this.ScenarioSetup(scenarioInfo);
#line 41
testRunner.Given("The ListBetLogExecutor has been created and initialized");
#line 42
testRunner.When("Call ListBetLogExecutor(userName\'\', roundId \'-1\')");
#line 43
testRunner.Then("The result of BetLog should be null");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบได้รับ userName และ roundId แต่ใน database ยังไม่มีบันทึกการลงเดิมพันของผู้เล" +
            "่น #ListBetLog")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ListBetLog")]
        public virtual void ระบบไดรบUserNameและRoundIdแตในDatabaseยงไมมบนทกการลงเดมพนของผเลนListBetLog()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ระบบได้รับ userName และ roundId แต่ใน database ยังไม่มีบันทึกการลงเดิมพันของผู้เล" +
                    "่น #ListBetLog", new string[] {
                        "record_mock"});
#line 46
this.ScenarioSetup(scenarioInfo);
#line 47
testRunner.Given("The ListBetLogExecutor has been created and initialized");
#line 48
testRunner.When("Call ListBetLogExecutor(userName\'Ae\', roundId \'2\')");
#line 49
testRunner.Then("The result of BetLog should be null");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
