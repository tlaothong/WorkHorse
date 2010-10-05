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
namespace TheS.Casinova.ColorsGame.BackServices
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.3.5.2")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class UpdateWinnerToGamePlayInfoFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "UpdateWinnerToGamePlayInfo.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "UpdateWinnerToGamePlayInfo", "In order to update game play information\r\nAs a back server\r\nI want to be update w" +
                    "inner to game play information", ((string[])(null)));
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบรับข้อมูล GameInformation, ระบบบันทึกข้อมูลลงในฐานข้อมูล")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "UpdateWinnerToGamePlayInfo")]
        public virtual void ระบบรบขอมลGameInformationระบบบนทกขอมลลงในฐานขอมล()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ระบบรับข้อมูล GameInformation, ระบบบันทึกข้อมูลลงในฐานข้อมูล", new string[] {
                        "record_mock"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
testRunner.Given("The PayForColorsWinnerInfoExecutor has been created and initialized");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "UserName",
                        "TableID",
                        "RoundID",
                        "TrackingID",
                        "OnGoingTrackingID",
                        "TotalBlack",
                        "TotalWhite",
                        "Winner",
                        "LastUpdate"});
            table1.AddRow(new string[] {
                        "OhAe",
                        "1",
                        "23",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1",
                        "1231",
                        "2731",
                        "Black",
                        "DateTime.Today"});
#line 9
testRunner.And("Expect game information should be add:", ((string)(null)), table1);
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "UserName",
                        "TableID",
                        "RoundID",
                        "TrackingID",
                        "OnGoingTrackingID",
                        "TotalBlack",
                        "TotalWhite",
                        "Winner",
                        "LastUpdate"});
            table2.AddRow(new string[] {
                        "OhAe",
                        "1",
                        "23",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1",
                        "1231",
                        "2731",
                        "Black",
                        "DateTime.Today"});
#line 13
testRunner.When("call UpdateWinnerToGamePlayInfo(GamePlayInfo)", ((string)(null)), table2);
#line 17
testRunner.Then("the game play information should be saved by calling IColorsGameDataAccess.ApplyA" +
                    "ction(GamePlayInformation, cmd)");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion