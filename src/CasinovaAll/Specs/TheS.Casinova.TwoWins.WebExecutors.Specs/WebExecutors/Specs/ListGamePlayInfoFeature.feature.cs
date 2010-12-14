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
    public partial class ListGamePlayInfoFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ListGamePlayInfoFeature.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ListGamePlayInfo", "In order to list game play information\r\nAs a system\r\nI want to list game play inf" +
                    "ormation", ((string[])(null)));
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
                        "TotalBet"});
            table1.AddRow(new string[] {
                        "1",
                        "Sak",
                        "1"});
            table1.AddRow(new string[] {
                        "1",
                        "Nayit",
                        "55"});
            table1.AddRow(new string[] {
                        "1",
                        "Ae",
                        "700"});
            table1.AddRow(new string[] {
                        "2",
                        "Nayit",
                        "99"});
            table1.AddRow(new string[] {
                        "2",
                        "Ae",
                        "78"});
            table1.AddRow(new string[] {
                        "3",
                        "Meaw",
                        "34"});
            table1.AddRow(new string[] {
                        "3",
                        "Sak",
                        "56"});
            table1.AddRow(new string[] {
                        "3",
                        "Au",
                        "1"});
            table1.AddRow(new string[] {
                        "4",
                        "Nat",
                        "100"});
            table1.AddRow(new string[] {
                        "5",
                        "Nayit",
                        "7"});
            table1.AddRow(new string[] {
                        "5",
                        "Krai",
                        "560"});
#line 8
testRunner.Given("Server has game play totalbet information as :", ((string)(null)), table1);
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[ListGamePlayInfo] ระบบได้รับข้อมูล UserName ถูกต้อง ระบบสามารถดึงข้อมูล GamePlay" +
            "Information ได้")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ListGamePlayInfo")]
        public virtual void ListGamePlayInfoระบบไดรบขอมลUserNameถกตองระบบสามารถดงขอมลGamePlayInformationได()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[ListGamePlayInfo] ระบบได้รับข้อมูล UserName ถูกต้อง ระบบสามารถดึงข้อมูล GamePlay" +
                    "Information ได้", new string[] {
                        "record_mock",
                        "record_mock"});
#line 24
this.ScenarioSetup(scenarioInfo);
#line 25
testRunner.Given("The ListGamePlayInfoExecutor has been created and initialized");
#line 26
testRunner.And("Sent UserName\'Nayit\' to list game play information");
#line 27
testRunner.When("Call ListGamePlayInfoExecutor()");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "RoundID",
                        "UserName",
                        "TotalBet"});
            table2.AddRow(new string[] {
                        "1",
                        "Nayit",
                        "55"});
            table2.AddRow(new string[] {
                        "2",
                        "Nayit",
                        "99"});
            table2.AddRow(new string[] {
                        "5",
                        "Nayit",
                        "7"});
#line 28
testRunner.Then("GamePlay information should be as :", ((string)(null)), table2);
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[ListGamePlayInfo] ระบบได้รับข้อมูล UserName ถูกต้อง แต่ใน database ยังไม่มีข้อมู" +
            "ล GamePlayInformation จะได้ข้อมูลเป็น null")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ListGamePlayInfo")]
        public virtual void ListGamePlayInfoระบบไดรบขอมลUserNameถกตองแตในDatabaseยงไมมขอมลGamePlayInformationจะไดขอมลเปนNull()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[ListGamePlayInfo] ระบบได้รับข้อมูล UserName ถูกต้อง แต่ใน database ยังไม่มีข้อมู" +
                    "ล GamePlayInformation จะได้ข้อมูลเป็น null", new string[] {
                        "record_mock"});
#line 35
this.ScenarioSetup(scenarioInfo);
#line 36
testRunner.Given("The ListGamePlayInfoExecutor has been created and initialized");
#line 37
testRunner.And("Sent UserName\'Art\' to list game play information");
#line 38
testRunner.When("Call ListGamePlayInfoExecutor()");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "RoundID",
                        "UserName",
                        "TotalBet"});
#line 39
testRunner.Then("GamePlay information should be as :", ((string)(null)), table3);
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[ListGamePlayInfo] ระบบไม่ได้รับข้อมูล UserName ระบบไม่สามารถดึงข้อมูล GamePlayIn" +
            "formation ได้")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ListGamePlayInfo")]
        public virtual void ListGamePlayInfoระบบไมไดรบขอมลUserNameระบบไมสามารถดงขอมลGamePlayInformationได()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[ListGamePlayInfo] ระบบไม่ได้รับข้อมูล UserName ระบบไม่สามารถดึงข้อมูล GamePlayIn" +
                    "formation ได้", new string[] {
                        "record_mock"});
#line 43
this.ScenarioSetup(scenarioInfo);
#line 44
testRunner.Given("The ListGamePlayInfoExecutor has been created and initialized");
#line 45
testRunner.And("Sent UserName\'\' for list game play information validtion");
#line 46
testRunner.When("Call ListGamePlayInfoExecutor() for validate input");
#line 47
testRunner.Then("GamePlay information should be throw exception");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
