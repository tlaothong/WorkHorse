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
    public partial class BetFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "BetFeature.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Bet", "In order to bet colors game\r\nAs a system\r\nI want to get trackingID to return clie" +
                    "nt and sent bet information to back server", ((string[])(null)));
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
        
        public virtual void ระบบไดรบขอมลการลงเดมพนในเกมColorsของผเลนระบบทำการตรวจสอบขอมลขอมลไมถกตองระบบไมทำการGenerateTrackingID(string userName, string roundID, string actionType, string amount)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ระบบได้รับข้อมูลการลงเดิมพันในเกม colors ของผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อมูล" +
                    "ไม่ถูกต้อง ระบบไม่ทำการ generate trackingID", new string[] {
                        "record_mock"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
testRunner.Given("The BetColorsExecutor has been created and initialized");
#line 9
testRunner.And(string.Format("Bet Informations as : UserName \'{0}\' Round \'{1}\', ActionType \'{2}\', Amount \'{3}" +
                        "\'", userName, roundID, actionType, amount));
#line 10
testRunner.When("Call BetColorsExecutor() for validate bet information");
#line 11
testRunner.Then("Get null and skip checking trackingID");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบได้รับข้อมูลการลงเดิมพันในเกม colors ของผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อมูล" +
            "ไม่ถูกต้อง ระบบไม่ทำการ generate trackingID")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Bet")]
        public virtual void ระบบไดรบขอมลการลงเดมพนในเกมColorsของผเลนระบบทำการตรวจสอบขอมลขอมลไมถกตองระบบไมทำการGenerateTrackingID_Variant0()
        {
            this.ระบบไดรบขอมลการลงเดมพนในเกมColorsของผเลนระบบทำการตรวจสอบขอมลขอมลไมถกตองระบบไมทำการGenerateTrackingID("Nit", "4", "White", "-50");
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบได้รับข้อมูลการลงเดิมพันในเกม colors ของผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อมูล" +
            "ไม่ถูกต้อง ระบบไม่ทำการ generate trackingID")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Bet")]
        public virtual void ระบบไดรบขอมลการลงเดมพนในเกมColorsของผเลนระบบทำการตรวจสอบขอมลขอมลไมถกตองระบบไมทำการGenerateTrackingID_Variant1()
        {
            this.ระบบไดรบขอมลการลงเดมพนในเกมColorsของผเลนระบบทำการตรวจสอบขอมลขอมลไมถกตองระบบไมทำการGenerateTrackingID("Nit", "4", "", "50");
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบได้รับข้อมูลการลงเดิมพันในเกม colors ของผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อมูล" +
            "ไม่ถูกต้อง ระบบไม่ทำการ generate trackingID")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Bet")]
        public virtual void ระบบไดรบขอมลการลงเดมพนในเกมColorsของผเลนระบบทำการตรวจสอบขอมลขอมลไมถกตองระบบไมทำการGenerateTrackingID_Variant2()
        {
            this.ระบบไดรบขอมลการลงเดมพนในเกมColorsของผเลนระบบทำการตรวจสอบขอมลขอมลไมถกตองระบบไมทำการGenerateTrackingID("Nit", "-2", "White", "50");
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบได้รับข้อมูลการลงเดิมพันในเกม colors ของผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อมูล" +
            "ไม่ถูกต้อง ระบบไม่ทำการ generate trackingID")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Bet")]
        public virtual void ระบบไดรบขอมลการลงเดมพนในเกมColorsของผเลนระบบทำการตรวจสอบขอมลขอมลไมถกตองระบบไมทำการGenerateTrackingID_Variant3()
        {
            this.ระบบไดรบขอมลการลงเดมพนในเกมColorsของผเลนระบบทำการตรวจสอบขอมลขอมลไมถกตองระบบไมทำการGenerateTrackingID("", "4", "White", "50");
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบได้รับข้อมูลการลงเดิมพันในเกม colors ของผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อมูล" +
            "ถูกต้อง ระบบทำการ generate trackingID")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Bet")]
        public virtual void ระบบไดรบขอมลการลงเดมพนในเกมColorsของผเลนระบบทำการตรวจสอบขอมลขอมลถกตองระบบทำการGenerateTrackingID()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ระบบได้รับข้อมูลการลงเดิมพันในเกม colors ของผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อมูล" +
                    "ถูกต้อง ระบบทำการ generate trackingID", new string[] {
                        "record_mock"});
#line 22
this.ScenarioSetup(scenarioInfo);
#line 23
testRunner.Given("The BetColorsExecutor has been created and initialized");
#line 24
testRunner.And("Bet Informations as : UserName \'Nit\' Round \'3\', ActionType \'White\', Amount \'300" +
                    "\'");
#line 25
testRunner.And("The system generated TrackingID:\'955D6ACDE4E04D1C90ACF3715BB2685A\'");
#line 26
testRunner.When("Call BetColorsExecutor()");
#line 27
testRunner.Then("TrackingID should be :\'955D6ACDE4E04D1C90ACF3715BB2685A\'");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
