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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Bet", "In order to generate TrackingID\r\nAs a math idiot\r\nI want to Generate TrackingID f" +
                    "or client and back server", ((string[])(null)));
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ผู้เล่นมีเงินในบัญชีมากกว่าจำนวนเงินที่ลงเดิมพัน ระบบ generate TrackingID และส่ง " +
            "TrackingID ไปยัง client และ backserver ได้")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Bet")]
        public virtual void ผเลนมเงนในบญชมากกวาจำนวนเงนทลงเดมพนระบบGenerateTrackingIDและสงTrackingIDไปยงClientและBackserverได()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ผู้เล่นมีเงินในบัญชีมากกว่าจำนวนเงินที่ลงเดิมพัน ระบบ generate TrackingID และส่ง " +
                    "TrackingID ไปยัง client และ backserver ได้", new string[] {
                        "record_mock"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
testRunner.Given("The BetInformation has been created and initialized");
#line 9
testRunner.And("Balance is \'100\'");
#line 10
testRunner.And("TrackingID of PlayerBet is \'6443B518-5F7F-4BE6-8E94-AD14F931FE08\'");
#line 11
testRunner.And("Expected call PlayerBet");
#line 12
testRunner.When("Call PlayerBet(RoundID \'5\', Amount \'50\', Color \'Black\') by userName \'nit\'");
#line 13
testRunner.Then("TrackingID of PlayerBet should be \'6443B518-5F7F-4BE6-8E94-AD14F931FE08\'");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ผู้เล่นมีเงินในบัญชีเท่ากับจำนวนเงินที่ลงเดิมพัน ระบบ generate TrackingID และส่ง " +
            "TrackingID ไปยัง client และ backserver ได้")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Bet")]
        public virtual void ผเลนมเงนในบญชเทากบจำนวนเงนทลงเดมพนระบบGenerateTrackingIDและสงTrackingIDไปยงClientและBackserverได()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ผู้เล่นมีเงินในบัญชีเท่ากับจำนวนเงินที่ลงเดิมพัน ระบบ generate TrackingID และส่ง " +
                    "TrackingID ไปยัง client และ backserver ได้", new string[] {
                        "record_mock"});
#line 16
this.ScenarioSetup(scenarioInfo);
#line 17
testRunner.Given("The BetInformation has been created and initialized");
#line 18
testRunner.And("Balance is \'50\'");
#line 19
testRunner.And("TrackingID of PlayerBet is \'6443B518-5F7F-4BE6-8E94-AD14F931FE08\'");
#line 20
testRunner.And("Expected call PlayerBet");
#line 21
testRunner.When("Call PlayerBet(RoundID \'5\', Amount \'50\', Color \'Black\') by userName \'nit\'");
#line 22
testRunner.Then("TrackingID of PlayerBet should be \'6443B518-5F7F-4BE6-8E94-AD14F931FE08\'");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ผู้เล่นมีเงินในบัญชีน้อยกว่าเงินที่ลงเดิมพัน ระบบ generate TrackingID ไม่ได้ และส" +
            "่งค่า balance กลับไปให้ client")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Bet")]
        public virtual void ผเลนมเงนในบญชนอยกวาเงนทลงเดมพนระบบGenerateTrackingIDไมไดและสงคาBalanceกลบไปใหClient()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ผู้เล่นมีเงินในบัญชีน้อยกว่าเงินที่ลงเดิมพัน ระบบ generate TrackingID ไม่ได้ และส" +
                    "่งค่า balance กลับไปให้ client", new string[] {
                        "record_mock"});
#line 25
this.ScenarioSetup(scenarioInfo);
#line 26
testRunner.Given("The BetInformation has been created and initialized");
#line 27
testRunner.And("Balance is \'50\'");
#line 28
testRunner.And("Expected call PlayerBet");
#line 29
testRunner.When("Call PlayerBet(RoundID \'5\', Amount \'100\', Color \'Black\') by userName \'nit\'");
#line 30
testRunner.Then("TrackingID of PlayerBet should be null");
#line 31
testRunner.And("Balance should be \'50\'");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ผู้เล่นไม่มีเงินในบัญชี ระบบ generate TrackingID ไม่ได้ และส่งค่า balance กลับไปใ" +
            "ห้ client")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Bet")]
        public virtual void ผเลนไมมเงนในบญชระบบGenerateTrackingIDไมไดและสงคาBalanceกลบไปใหClient()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ผู้เล่นไม่มีเงินในบัญชี ระบบ generate TrackingID ไม่ได้ และส่งค่า balance กลับไปใ" +
                    "ห้ client", new string[] {
                        "record_mock"});
#line 34
this.ScenarioSetup(scenarioInfo);
#line 35
testRunner.Given("The BetInformation has been created and initialized");
#line 36
testRunner.And("Balance is \'0\'");
#line 37
testRunner.And("Expected call PlayerBet");
#line 38
testRunner.When("Call PlayerBet(RoundID \'5\', Amount \'100\', Color \'Black\') by userName \'nit\'");
#line 39
testRunner.Then("TrackingID of PlayerBet should be null");
#line 40
testRunner.And("Balance should be \'0\'");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบได้รับค่า UserName ไม่ถูกต้อง ระบบ generate TrackingID ไม่ได้")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Bet")]
        public virtual void ระบบไดรบคาUserNameไมถกตองระบบGenerateTrackingIDไมได()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ระบบได้รับค่า UserName ไม่ถูกต้อง ระบบ generate TrackingID ไม่ได้", new string[] {
                        "record_mock"});
#line 43
this.ScenarioSetup(scenarioInfo);
#line 44
testRunner.Given("The BetInformation has been created and initialized");
#line 45
testRunner.And("Balance is \'200\'");
#line 46
testRunner.And("Expected call PlayerBet");
#line 47
testRunner.When("Call PlayerBet(RoundID \'5\', Amount \'100\', Color \'Black\') by userName \' \'");
#line 48
testRunner.Then("TrackingID of PlayerBet should be null");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบได้รับค่า RoundID ไม่ถูกต้อง ระบบ generate TrackingID ไม่ได้")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Bet")]
        public virtual void ระบบไดรบคาRoundIDไมถกตองระบบGenerateTrackingIDไมได()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ระบบได้รับค่า RoundID ไม่ถูกต้อง ระบบ generate TrackingID ไม่ได้", new string[] {
                        "record_mock"});
#line 51
this.ScenarioSetup(scenarioInfo);
#line 52
testRunner.Given("The BetInformation has been created and initialized");
#line 53
testRunner.And("Balance is \'200\'");
#line 54
testRunner.And("Expected call PlayerBet");
#line 55
testRunner.When("Call PlayerBet(RoundID \'-5\', Amount \'100\', Color \'Black\') by userName \'nit\'");
#line 56
testRunner.Then("TrackingID of PlayerBet should be null");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบได้รับค่า Color ไม่ถูกต้อง ระบบ generate TrackingID ไม่ได้")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Bet")]
        public virtual void ระบบไดรบคาColorไมถกตองระบบGenerateTrackingIDไมได()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ระบบได้รับค่า Color ไม่ถูกต้อง ระบบ generate TrackingID ไม่ได้", new string[] {
                        "record_mock"});
#line 59
this.ScenarioSetup(scenarioInfo);
#line 60
testRunner.Given("The BetInformation has been created and initialized");
#line 61
testRunner.And("Balance is \'200\'");
#line 62
testRunner.And("Expected call PlayerBet");
#line 63
testRunner.When("Call PlayerBet(RoundID \'5\', Amount \'100\', Color \'Blue\') by userName \'nit\'");
#line 64
testRunner.Then("TrackingID of PlayerBet should be null");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
