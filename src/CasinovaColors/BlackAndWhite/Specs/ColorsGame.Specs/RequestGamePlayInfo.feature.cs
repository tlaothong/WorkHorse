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
namespace ColorsGame.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.3.5.2")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class RequestGameInformationFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "RequestGamePlayInfo.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Request game information", "In order to receive game play information\r\nAs a silverlight\r\nI want to request Ga" +
                    "mePlayInfo", ((string[])(null)));
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
#line 8
testRunner.Given("Create and initialize ShowWinnerPageViewModel and Colors game service");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "TableID",
                        "RoundID",
                        "UserName",
                        "TrackingID",
                        "OnGoingTrackingID",
                        "LastUpdate",
                        "Winner"});
            table1.AddRow(new string[] {
                        "1",
                        "1",
                        "TitleUpz",
                        "625604D9-082A-4C58-A7FC-3023A4EC1430",
                        "625604D9-082A-4C58-A7FC-3023A4EC1430",
                        "15-08-2010",
                        "White"});
            table1.AddRow(new string[] {
                        "2",
                        "2",
                        "TitleUpz",
                        "B36ECC48-89D8-44AA-B80F-15708E12B1D3",
                        "B36ECC48-89D8-44AA-B80F-15708E12B1D3",
                        "15-08-2010",
                        "Black"});
            table1.AddRow(new string[] {
                        "3",
                        "3",
                        "TitleUpz",
                        "779417EE-DD7E-4B74-8372-E51985938AF5",
                        "926FFFD8-6109-4ADF-ABFF-38CD348516D1",
                        "15-08-2010",
                        "Black"});
            table1.AddRow(new string[] {
                        "4",
                        "4",
                        "TitleUpz",
                        "F7718534-39C3-487F-A9C8-E0F746D77AEF",
                        "F7718534-39C3-487F-A9C8-E0F746D77AEF",
                        "15-08-2010",
                        "White"});
#line 9
testRunner.And("Game Play Information on BackServer is:", ((string)(null)), table1);
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("OngoingTrackingID is available")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Request game information")]
        [Microsoft.Silverlight.Testing.TagAttribute("record_mock")]
        public virtual void OngoingTrackingIDIsAvailable()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("OngoingTrackingID is available", new string[] {
                        "record_mock"});
#line 17
this.ScenarioSetup(scenarioInfo);
#line 18
testRunner.Given("I have call PayForWinnerInformation(tableID=\'1\',roundID=\'1\')");
#line 19
testRunner.When("recieve TrackingID from called");
#line 20
testRunner.Then("I will receive trackingID then execute GetGamePlayInformation");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("OngoingTrackingID2 is available")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Request game information")]
        [Microsoft.Silverlight.Testing.TagAttribute("record_mock")]
        public virtual void OngoingTrackingID2IsAvailable()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("OngoingTrackingID2 is available", new string[] {
                        "record_mock"});
#line 23
this.ScenarioSetup(scenarioInfo);
#line 24
testRunner.Given("I have call PayForWinnerInformation(tableID=\'3\',roundID=\'3\')");
#line 25
testRunner.When("recieve TrackingID from called");
#line 26
testRunner.Then("I will receive trackingID then execute GetGamePlayInformation");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("OngoingTrackingID is unavailable")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Request game information")]
        [Microsoft.Silverlight.Testing.TagAttribute("record_mock")]
        public virtual void OngoingTrackingIDIsUnavailable()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("OngoingTrackingID is unavailable", new string[] {
                        "record_mock"});
#line 29
this.ScenarioSetup(scenarioInfo);
#line 30
testRunner.Given("I have call PayForWinnerInformation(tableID=\'2\',roundID=\'2\')");
#line 31
testRunner.When("had not recieved TrackingID from called");
#line 32
testRunner.Then("recall PayForWinnerInformation again");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
