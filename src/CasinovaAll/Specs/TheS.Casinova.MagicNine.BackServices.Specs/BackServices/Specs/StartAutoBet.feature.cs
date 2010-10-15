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
namespace TheS.Casinova.MagicNine.BackServices.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.3.5.2")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class StartAutoBetFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "StartAutoBet.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "StartAutoBet", "In order to bet\r\nAs a back server\r\nI want to be automatic betting by server", ((string[])(null)));
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
                        "121.99"});
            table1.AddRow(new string[] {
                        "Toommy",
                        "36.95"});
            table1.AddRow(new string[] {
                        "Au",
                        "234.00"});
#line 8
testRunner.Given("(AutoBet)server has player information as:", ((string)(null)), table1);
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ได้รับข้อมูลการลงเงิน, ผู้เล่นมีเงินพอ ระบบหักเงินผู้เล่นตามเงินที่ลงพนัน และส่งข" +
            "้อมูลให้ระบบลงเงินอัตโนมัติ")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "StartAutoBet")]
        public virtual void ไดรบขอมลการลงเงนผเลนมเงนพอระบบหกเงนผเลนตามเงนทลงพนนและสงขอมลใหระบบลงเงนอตโนมต()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ได้รับข้อมูลการลงเงิน, ผู้เล่นมีเงินพอ ระบบหักเงินผู้เล่นตามเงินที่ลงพนัน และส่งข" +
                    "้อมูลให้ระบบลงเงินอัตโนมัติ", new string[] {
                        "record_mock",
                        "record_mock"});
#line 16
this.ScenarioSetup(scenarioInfo);
#line 17
testRunner.Given("The StartAutoBetExecutor has been created and initialized");
#line 18
testRunner.And("sent name: \'OhAe\' the player\'s balance should recieved, for autobet");
#line 19
testRunner.And("the player\'s balance should be update correct, Amount: \'200\'");
#line 20
testRunner.And("the AutoBetEngine shoule be call as: (UserName: \'OhAe\', RoundID: \'1\', Amount: \'20" +
                    "0\', Interval: \'5\', TrackingID: \'B21F8971-DBAB-400F-9D95-151BA24875C1\')");
#line 21
testRunner.When("call StartAutoBetExecutor(UserName: \'OhAe\', RoundID: \'1\', Amount: \'200\', Interval" +
                    ": \'5\', TrackingID: \'B21F8971-DBAB-400F-9D95-151BA24875C1\')");
#line 22
testRunner.Then("the player action information should be created");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
