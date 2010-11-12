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
    public partial class PayForColorsWinnerInformationFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "PayForColorsWinnerInfoFeature.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "PayForColorsWinnerInformation", "In order to pay for colors winner information\r\nAs a system\r\nI want to sent inform" +
                    "ation of pay for colors winner", ((string[])(null)));
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบ generate TrackingID และส่ง TrackingID ไปยัง client และ backserver ได้")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PayForColorsWinnerInformation")]
        public virtual void ระบบGenerateTrackingIDและสงTrackingIDไปยงClientและBackserverได()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ระบบ generate TrackingID และส่ง TrackingID ไปยัง client และ backserver ได้", new string[] {
                        "record_mock"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
testRunner.Given("The PayForcolorsWinnerInfo has been created and initialized");
#line 9
testRunner.And("TrackingID is \'6443B518-5F7F-4BE6-8E94-AD14F931FE08\'");
#line 10
testRunner.And("Expected call PayForWinnerInfo");
#line 11
testRunner.When("Call PayForWinnerInfo(RoundID \'5\') by userName \'nit\'");
#line 12
testRunner.Then("TrackingID of PayForWinner should be \'6443B518-5F7F-4BE6-8E94-AD14F931FE08\'");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบได้รับค่า RoundID เป็นค่าลบ ระบบไม่สามารถ generate TrackingID ได้")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PayForColorsWinnerInformation")]
        public virtual void ระบบไดรบคาRoundIDเปนคาลบระบบไมสามารถGenerateTrackingIDได()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ระบบได้รับค่า RoundID เป็นค่าลบ ระบบไม่สามารถ generate TrackingID ได้", new string[] {
                        "record_mock"});
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
testRunner.Given("The PayForcolorsWinnerInfo has been created and initialized");
#line 17
testRunner.When("Call PayForWinnerInfo(RoundID \'-5\') by userName \'nit\'");
#line 18
testRunner.Then("TrackingID  of PayForWinner should be null");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบได้รับค่าข้อมูล UserName ที่ไม่มีในระบบ ระบบไม่สามารถ generate TrackingID ได้" +
            "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PayForColorsWinnerInformation")]
        public virtual void ระบบไดรบคาขอมลUserNameทไมมในระบบระบบไมสามารถGenerateTrackingIDได()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ระบบได้รับค่าข้อมูล UserName ที่ไม่มีในระบบ ระบบไม่สามารถ generate TrackingID ได้" +
                    "", new string[] {
                        "record_mock"});
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
testRunner.Given("The PayForcolorsWinnerInfo has been created and initialized");
#line 23
testRunner.And("System has userName \'tle\',\'boy\',\'ae\',\'ku\',\'au\'");
#line 24
testRunner.When("Call PayForWinnerInfo(RoundID \'5\') by userName \'nit\'");
#line 25
testRunner.Then("TrackingID  of PayForWinner should be null");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบไม่ได้รับค่า UserName ระบบไม่สามารถ generate TrackingID ได้")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PayForColorsWinnerInformation")]
        public virtual void ระบบไมไดรบคาUserNameระบบไมสามารถGenerateTrackingIDได()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ระบบไม่ได้รับค่า UserName ระบบไม่สามารถ generate TrackingID ได้", new string[] {
                        "record_mock"});
#line 28
this.ScenarioSetup(scenarioInfo);
#line 29
testRunner.Given("The PayForcolorsWinnerInfo has been created and initialized");
#line 30
testRunner.When("Call PayForWinnerInfo(RoundID \'5\') by userName \' \'");
#line 31
testRunner.Then("TrackingID  of PayForWinner should be null");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
