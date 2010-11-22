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
namespace TheS.Casinova.Colors.WebExecutors.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.3.5.2")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class ListActiveGameRoundsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ListActiveGameRoundsFeature.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ListActiveGameRounds", "In order to list active game rounds\r\nAs a system\r\nI want to list active game roun" +
                    "ds at now", ((string[])(null)));
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ลิสต์ข้อมูลโต๊ะเกมที่กำลัง active ณ เวลาปัจจุบันที่ผู้เล่นเข้าห้องเกม")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ListActiveGameRounds")]
        public virtual void ลสตขอมลโตะเกมทกำลงActiveณเวลาปจจบนทผเลนเขาหองเกม()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ลิสต์ข้อมูลโต๊ะเกมที่กำลัง active ณ เวลาปัจจุบันที่ผู้เล่นเข้าห้องเกม", new string[] {
                        "record_mock"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
testRunner.Given("The ListActiveGameRoundsExecutor has been created and initialized");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Round",
                        "StartTime",
                        "EndTime"});
            table1.AddRow(new string[] {
                        "3",
                        "10:30",
                        "15:30"});
            table1.AddRow(new string[] {
                        "4",
                        "13:00",
                        "16:00"});
            table1.AddRow(new string[] {
                        "5",
                        "13:30",
                        "18:30"});
            table1.AddRow(new string[] {
                        "6",
                        "14:00",
                        "19:00"});
#line 9
testRunner.And("The active game rounds are :", ((string)(null)), table1);
#line 15
testRunner.When("Call ListActiveGameRoundsExecutor()");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Round",
                        "StartTime",
                        "EndTime"});
            table2.AddRow(new string[] {
                        "3",
                        "10:30",
                        "15:30"});
            table2.AddRow(new string[] {
                        "4",
                        "13:00",
                        "16:00"});
            table2.AddRow(new string[] {
                        "5",
                        "13:30",
                        "18:30"});
            table2.AddRow(new string[] {
                        "6",
                        "14:00",
                        "19:00"});
#line 16
testRunner.Then("The result should be:", ((string)(null)), table2);
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ลิสต์ข้อมูลโต๊ะเกมที่กำลัง active แต่ใน database ยังไม่มีข้อมูล")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ListActiveGameRounds")]
        public virtual void ลสตขอมลโตะเกมทกำลงActiveแตในDatabaseยงไมมขอมล()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ลิสต์ข้อมูลโต๊ะเกมที่กำลัง active แต่ใน database ยังไม่มีข้อมูล", new string[] {
                        "record_mock"});
#line 24
this.ScenarioSetup(scenarioInfo);
#line 25
testRunner.Given("The ListActiveGameRoundsExecutor has been created and initialized");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "RoundId",
                        "StartTime",
                        "EndTime"});
#line 26
testRunner.And("The active game rounds are :", ((string)(null)), table3);
#line 29
testRunner.When("Call ListActiveGameRoundsExecutor()");
#line 30
testRunner.Then("The active game rounds should be null:");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
