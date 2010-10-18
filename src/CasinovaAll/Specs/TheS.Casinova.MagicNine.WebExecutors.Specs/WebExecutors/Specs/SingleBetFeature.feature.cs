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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SingleBet", "In order to single bet\r\nAs a player\r\nI want to bet", ((string[])(null)));
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบได้รับ userName และ roundId ถูกต้อง #SingleBet")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SingleBet")]
        public virtual void ระบบไดรบUserNameและRoundIdถกตองSingleBet()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ระบบได้รับ userName และ roundId ถูกต้อง #SingleBet", new string[] {
                        "record_mock"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
testRunner.Given("The SingleBetExecutor has been created and initialized");
#line 9
testRunner.And("Web service has TrackingID : \'DA1FE75E-9042-4FC5-B3CF-1E973D2152F7\'");
#line 10
testRunner.And("Expect execute SingleBetCommand");
#line 11
testRunner.When("Call SingleBetExecutor(userName\'Nit\', roundId \'1\')");
#line 12
testRunner.Then("TrackingID for client and back server should be : \'DA1FE75E-9042-4FC5-B3CF-1E973D" +
                    "2152F7\'");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบได้รับ userName ไม่ถูกต้อง #SingleBet")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SingleBet")]
        public virtual void ระบบไดรบUserNameไมถกตองSingleBet()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ระบบได้รับ userName ไม่ถูกต้อง #SingleBet", new string[] {
                        "record_mock"});
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
testRunner.Given("The SingleBetExecutor has been created and initialized");
#line 17
testRunner.When("Call SingleBetExecutor(userName\'\', roundId \'1\')");
#line 18
testRunner.Then("TrackingID for client and back server should be null");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบได้รับ roundId ไม่ถูกต้อง #SingleBet")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SingleBet")]
        public virtual void ระบบไดรบRoundIdไมถกตองSingleBet()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ระบบได้รับ roundId ไม่ถูกต้อง #SingleBet", new string[] {
                        "record_mock"});
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
testRunner.Given("The SingleBetExecutor has been created and initialized");
#line 23
testRunner.When("Call SingleBetExecutor(userName\'Nit\', roundId \'-1\')");
#line 24
testRunner.Then("TrackingID for client and back server should be null");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบได้รับ userName และ roundId  ไม่ถูกต้อง #SingleBet")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SingleBet")]
        public virtual void ระบบไดรบUserNameและRoundIdไมถกตองSingleBet()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ระบบได้รับ userName และ roundId  ไม่ถูกต้อง #SingleBet", new string[] {
                        "record_mock"});
#line 27
this.ScenarioSetup(scenarioInfo);
#line 28
testRunner.Given("The SingleBetExecutor has been created and initialized");
#line 29
testRunner.When("Call SingleBetExecutor(userName\' \', roundId \'-1\')");
#line 30
testRunner.Then("TrackingID for client and back server should be null");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
