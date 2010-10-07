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
    public partial class GetPlayerInfoForPayForColorsWinnerInfoFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GetPlayerInfo.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "GetPlayerInfoForPayForColorsWinnerInfo", "In order to get player information\r\nAs a back server\r\nI want to be get player inf" +
                    "ormation(balance)", ((string[])(null)));
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
                        "Balance"});
            table1.AddRow(new string[] {
                        "OhAe",
                        "463.61"});
            table1.AddRow(new string[] {
                        "Boy",
                        "121.21"});
            table1.AddRow(new string[] {
                        "Nit",
                        "36.99"});
            table1.AddRow(new string[] {
                        "Au",
                        "234.00"});
#line 8
testRunner.Given("server has user information as:", ((string)(null)), table1);
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ได้รับ username และระบบมีข้อมูล balance ของ username ที่รับมา, ระบบดึงข้อมูลของผู" +
            "้ใช้กลับ")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GetPlayerInfoForPayForColorsWinnerInfo")]
        public virtual void ไดรบUsernameและระบบมขอมลBalanceของUsernameทรบมาระบบดงขอมลของผใชกลบ()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ได้รับ username และระบบมีข้อมูล balance ของ username ที่รับมา, ระบบดึงข้อมูลของผู" +
                    "้ใช้กลับ", new string[] {
                        "record_mock",
                        "record_mock"});
#line 16
this.ScenarioSetup(scenarioInfo);
#line 17
testRunner.Given("The PayForColorsWinnerInfoExecutor has been created and initialized");
#line 18
testRunner.And("sent userName: \'OhAe\' and expected player\'s balance should be \'463.61\'");
#line 19
testRunner.When("call Get(PayForColorsWinnerInfoCommand), UserName: \'OhAe\'");
#line 20
testRunner.Then("the result should be same as expected balance");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ได้รับ username และระบบมีข้อมูล balance ของ username ที่รับมา, ระบบดึงข้อมูลของผู" +
            "้ใช้กลับ2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GetPlayerInfoForPayForColorsWinnerInfo")]
        public virtual void ไดรบUsernameและระบบมขอมลBalanceของUsernameทรบมาระบบดงขอมลของผใชกลบ2()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ได้รับ username และระบบมีข้อมูล balance ของ username ที่รับมา, ระบบดึงข้อมูลของผู" +
                    "้ใช้กลับ2", new string[] {
                        "record_mock"});
#line 23
this.ScenarioSetup(scenarioInfo);
#line 24
testRunner.Given("The PayForColorsWinnerInfoExecutor has been created and initialized");
#line 25
testRunner.And("sent userName: \'Au\' and expected player\'s balance should be \'234.00\'");
#line 26
testRunner.When("call Get(PayForColorsWinnerInfoCommand), UserName: \'Au\'");
#line 27
testRunner.Then("the result should be same as expected balance");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
