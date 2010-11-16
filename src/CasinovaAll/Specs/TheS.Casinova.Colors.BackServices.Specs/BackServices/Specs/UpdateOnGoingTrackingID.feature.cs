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
namespace TheS.Casinova.Colors.BackServices.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.3.5.2")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class UpdateOnGoingTrackingIDFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "UpdateOnGoingTrackingID.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "UpdateOnGoingTrackingID", "In order to update game play information\r\nAs a back server\r\nI want to be update O" +
                    "nGoingTrackingID into game play information", ((string[])(null)));
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
                        "OnGoingTrackingID"});
            table1.AddRow(new string[] {
                        "123",
                        "OhAe",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1"});
#line 8
testRunner.Given("Define GamePlayInformation input as:", ((string)(null)), table1);
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ได้รับข้อมูล GamePlayInformation, ระบบ update OnGoingTrackingID")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "UpdateOnGoingTrackingID")]
        public virtual void ไดรบขอมลGamePlayInformationระบบUpdateOnGoingTrackingID()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ได้รับข้อมูล GamePlayInformation, ระบบ update OnGoingTrackingID", new string[] {
                        "record_mock",
                        "record_mock"});
#line 13
this.ScenarioSetup(scenarioInfo);
#line 14
testRunner.Given("The PayForColorsWinnerInfoExecutor has been created and initialized");
#line 15
testRunner.And("Expect GamePlayInformation(RoundID: \'123\', UserName: \'OhAe\', OnGoingTrackingID: \'" +
                    "B21F8971-DBAB-400F-9D95-151BA24875C1\') input should be add");
#line 16
testRunner.When("call UpdateOnGoingTrackingID(GamePlayInformation(RoundID: \'123\', UserName: \'OhAe\'" +
                    ", OnGoingTrackingID: \'B21F8971-DBAB-400F-9D95-151BA24875C1\'))");
#line 17
testRunner.Then("the game play information should be saved by calling IColorsGameDataAccess.ApplyA" +
                    "ction(GamePlayInformation, PayForWinnerColorsInfoCommand)");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
