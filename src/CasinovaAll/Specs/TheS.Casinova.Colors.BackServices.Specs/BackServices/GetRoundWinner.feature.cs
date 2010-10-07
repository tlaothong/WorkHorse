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
    public partial class GetRoundWinnerFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GetRoundWinner.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "GetRoundWinner", "In order to get black pot and white pot of round\r\nAs a math idiot\r\nI want to be t" +
                    "old the round winner at that time", ((string[])(null)));
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
                        "BlackPot",
                        "WhitePot"});
            table1.AddRow(new string[] {
                        "10",
                        "123.24",
                        "231.00"});
            table1.AddRow(new string[] {
                        "11",
                        "42.00",
                        "83.00"});
            table1.AddRow(new string[] {
                        "12",
                        "10.01",
                        "15.23"});
#line 8
testRunner.Given("server has round information as:", ((string)(null)), table1);
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ได้รับข้อมูล RoundID, ระบบดึงข้อมูล black pot, white pot เพื่อคำนวณผู้ชนะและส่งกล" +
            "ับ")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GetRoundWinner")]
        public virtual void ไดรบขอมลRoundIDระบบดงขอมลBlackPotWhitePotเพอคำนวณผชนะและสงกลบ()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ได้รับข้อมูล RoundID, ระบบดึงข้อมูล black pot, white pot เพื่อคำนวณผู้ชนะและส่งกล" +
                    "ับ", new string[] {
                        "record_mock",
                        "record_mock"});
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
testRunner.Given("The PayForColorsWinnerInfoExecutor has been created and initialized");
#line 17
testRunner.And("sent RoundID: \'12\' expected result should be BlackPot: \'10.01\', WhitePot: \'15.23\'" +
                    "");
#line 18
testRunner.When("call Get(PayForColorsWinnerInfoCommand), Round: \'12\'");
#line 19
testRunner.Then("the result should be same as expected BlackPot and WhitePot");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ได้รับข้อมูล RoundID, ระบบดึงข้อมูล black pot, white pot เพื่อคำนวณผู้ชนะและส่งกล" +
            "ับ2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GetRoundWinner")]
        public virtual void ไดรบขอมลRoundIDระบบดงขอมลBlackPotWhitePotเพอคำนวณผชนะและสงกลบ2()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ได้รับข้อมูล RoundID, ระบบดึงข้อมูล black pot, white pot เพื่อคำนวณผู้ชนะและส่งกล" +
                    "ับ2", new string[] {
                        "record_mock"});
#line 22
this.ScenarioSetup(scenarioInfo);
#line 23
testRunner.Given("The PayForColorsWinnerInfoExecutor has been created and initialized");
#line 24
testRunner.And("sent RoundID: \'11\' expected result should be BlackPot: \'42.00\', WhitePot: \'83.00\'" +
                    "");
#line 25
testRunner.When("call Get(PayForColorsWinnerInfoCommand), Round: \'11\'");
#line 26
testRunner.Then("the result should be same as expected BlackPot and WhitePot");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
