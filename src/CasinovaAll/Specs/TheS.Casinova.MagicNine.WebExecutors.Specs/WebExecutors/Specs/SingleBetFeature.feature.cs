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
    public partial class SingleBetFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SingleBetFeature.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SingleBet", "In order to single bet\r\nAs a system\r\nI want to get trackingID to return client an" +
                    "d sent single bet information to back server", ((string[])(null)));
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
        
        public virtual void ระบบไดรบขอมลการลงเดมพนในเกมMagicNineของผเลนระบบทำการตรวจสอบขอมลขอมลไมถกตองระบบไมทำการGenerateTrackingID(string userName, string roundID)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ระบบได้รับข้อมูลการลงเดิมพันในเกม MagicNine ของผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อ" +
                    "มูลไม่ถูกต้อง ระบบไม่ทำการ generate trackingID", new string[] {
                        "record_mock"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
testRunner.Given("The SingleBetExecutor has been created and initialized");
#line 9
testRunner.And(string.Format("SingleBet Informations as : UserName \'{0}\' RoundID \'{1}\'", userName, roundID));
#line 10
testRunner.When("Call SingleBetExecutor() for validate single bet information");
#line 11
testRunner.Then("Get null and skip checking trackingID");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบได้รับข้อมูลการลงเดิมพันในเกม MagicNine ของผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อ" +
            "มูลไม่ถูกต้อง ระบบไม่ทำการ generate trackingID")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SingleBet")]
        public virtual void ระบบไดรบขอมลการลงเดมพนในเกมMagicNineของผเลนระบบทำการตรวจสอบขอมลขอมลไมถกตองระบบไมทำการGenerateTrackingID_Nit()
        {
            this.ระบบไดรบขอมลการลงเดมพนในเกมMagicNineของผเลนระบบทำการตรวจสอบขอมลขอมลไมถกตองระบบไมทำการGenerateTrackingID("Nit", "-2");
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบได้รับข้อมูลการลงเดิมพันในเกม MagicNine ของผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อ" +
            "มูลไม่ถูกต้อง ระบบไม่ทำการ generate trackingID")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SingleBet")]
        public virtual void ระบบไดรบขอมลการลงเดมพนในเกมMagicNineของผเลนระบบทำการตรวจสอบขอมลขอมลไมถกตองระบบไมทำการGenerateTrackingID_()
        {
            this.ระบบไดรบขอมลการลงเดมพนในเกมMagicNineของผเลนระบบทำการตรวจสอบขอมลขอมลไมถกตองระบบไมทำการGenerateTrackingID("", "4");
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบได้รับข้อมูลการลงเดิมพันในเกม MagicNine ของผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อ" +
            "มูลถูกต้อง ระบบทำการ generate trackingID")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SingleBet")]
        public virtual void ระบบไดรบขอมลการลงเดมพนในเกมMagicNineของผเลนระบบทำการตรวจสอบขอมลขอมลถกตองระบบทำการGenerateTrackingID()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ระบบได้รับข้อมูลการลงเดิมพันในเกม MagicNine ของผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อ" +
                    "มูลถูกต้อง ระบบทำการ generate trackingID", new string[] {
                        "record_mock"});
#line 20
this.ScenarioSetup(scenarioInfo);
#line 21
testRunner.Given("The SingleBetExecutor has been created and initialized");
#line 22
testRunner.And("SingleBet Informations as : UserName \'Sakanit\' RoundID \'4\'");
#line 23
testRunner.And("The system generated TrackingID for SingleBet:\'942D2F350FAA4A32870CF9CF9A5C7A2E\'");
#line 24
testRunner.When("Call SingleBetExecutor()");
#line 25
testRunner.Then("TrackingID for SingleBet should be :\'942D2F350FAA4A32870CF9CF9A5C7A2E\'");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
