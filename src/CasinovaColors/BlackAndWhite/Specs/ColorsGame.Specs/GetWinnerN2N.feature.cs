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
    public partial class N2NGetWinnerInformationFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GetWinnerN2N.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "N2N Get winner information", @"1.Request pay for colors winner information (Silverlight)
1.1 Check account balance (Silverlight)
1.2 if this first request substract account balance by 1 dollar (Silverlight)
1.3 if this second request substract account balance by 0.25 cent (Silverlight)
1.4 send request pay for colors winner information to server by trackingID and roundID (Silverlight)
2.Substract account balance by first or second request (Web Server)
2.1 Generate tracking id (Web Server)
2.2 Send tracking id to client (Web Server)
2.3 Send tracking id to back server (Web Server)
3.Update game information (Web Server)
3.1 Save Ongoing tracking ID (Web Server)
4.Get game play information from server (Silverlight)
5.Check game play information (Silverlight)
6.Display winner (Silverlight)", ((string[])(null)));
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
#line 17
#line 18
testRunner.Given("Create and initialize ShowWinnerPageViewModel and Colors game service");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "TableID",
                        "RoundID",
                        "UserName",
                        "TrackingID",
                        "OnGoingTrackingID",
                        "LastUpdate"});
            table1.AddRow(new string[] {
                        "9",
                        "11",
                        "sakul",
                        "{955D6ACD-E4E0-4D1C-90AC-F3715BB2685A}",
                        "{955D6ACD-E4E0-4D1C-90AC-F3715BB2685A}",
                        "15-08-2010"});
            table1.AddRow(new string[] {
                        "10",
                        "12",
                        "sakul",
                        "{77C1905A-CD47-4FB4-BF56-4D8EC739474E}",
                        "{48A4E591-A1EA-4C9D-8D38-623F9EBA3128}",
                        "15-08-2010"});
#line 19
testRunner.And("Back server have game play information are:", ((string)(null)), table1);
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Request pay for colors winner information get trackingID accept")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "N2N Get winner information")]
        [Microsoft.Silverlight.Testing.TagAttribute("record_mock")]
        public virtual void RequestPayForColorsWinnerInformationGetTrackingIDAccept()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Request pay for colors winner information get trackingID accept", new string[] {
                        "record_mock"});
#line 25
this.ScenarioSetup(scenarioInfo);
#line 26
testRunner.When("I press GetWinner( TableID: 9, RoundID: 11 )");
#line 27
testRunner.Then("the result should be TrackingID: {955D6ACD-E4E0-4D1C-90AC-F3715BB2685A}");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Request pay for colors winner information but don\'t have TableID, get null and sk" +
            "ip checking trackingID")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "N2N Get winner information")]
        [Microsoft.Silverlight.Testing.TagAttribute("record_mock")]
        public virtual void RequestPayForColorsWinnerInformationButDonTHaveTableIDGetNullAndSkipCheckingTrackingID()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Request pay for colors winner information but don\'t have TableID, get null and sk" +
                    "ip checking trackingID", new string[] {
                        "record_mock"});
#line 30
this.ScenarioSetup(scenarioInfo);
#line 31
testRunner.When("I press GetWinner( TableID: 1, RoundID: 11 )");
#line 32
testRunner.Then("Get null and skip checking trackingID");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Request pay for colors winner information but don\'t have RoundID, get null and sk" +
            "ip checking trackingID")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "N2N Get winner information")]
        [Microsoft.Silverlight.Testing.TagAttribute("record_mock")]
        public virtual void RequestPayForColorsWinnerInformationButDonTHaveRoundIDGetNullAndSkipCheckingTrackingID()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Request pay for colors winner information but don\'t have RoundID, get null and sk" +
                    "ip checking trackingID", new string[] {
                        "record_mock"});
#line 35
this.ScenarioSetup(scenarioInfo);
#line 36
testRunner.When("I press GetWinner( TableID: 9, RoundID: 1 )");
#line 37
testRunner.Then("Get null and skip checking trackingID");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Request pay for colors winner information but don\'t have TableID and RoundID, get" +
            " null and skip checking trackingID")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "N2N Get winner information")]
        [Microsoft.Silverlight.Testing.TagAttribute("record_mock")]
        public virtual void RequestPayForColorsWinnerInformationButDonTHaveTableIDAndRoundIDGetNullAndSkipCheckingTrackingID()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Request pay for colors winner information but don\'t have TableID and RoundID, get" +
                    " null and skip checking trackingID", new string[] {
                        "record_mock"});
#line 40
this.ScenarioSetup(scenarioInfo);
#line 41
testRunner.When("I press GetWinner( TableID: 1, RoundID: 1 )");
#line 42
testRunner.Then("Get null and skip checking trackingID");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Request pay for colors winner information but TableID is minus value, get null an" +
            "d skip checking trackingID")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "N2N Get winner information")]
        [Microsoft.Silverlight.Testing.TagAttribute("record_mock")]
        public virtual void RequestPayForColorsWinnerInformationButTableIDIsMinusValueGetNullAndSkipCheckingTrackingID()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Request pay for colors winner information but TableID is minus value, get null an" +
                    "d skip checking trackingID", new string[] {
                        "record_mock"});
#line 45
this.ScenarioSetup(scenarioInfo);
#line 46
testRunner.When("I press GetWinner( TableID: -1, RoundID: 11 )");
#line 47
testRunner.Then("Get null and skip checking trackingID");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Request pay for colors winner information but RoundID is minus value, get null an" +
            "d skip checking trackingID")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "N2N Get winner information")]
        [Microsoft.Silverlight.Testing.TagAttribute("record_mock")]
        public virtual void RequestPayForColorsWinnerInformationButRoundIDIsMinusValueGetNullAndSkipCheckingTrackingID()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Request pay for colors winner information but RoundID is minus value, get null an" +
                    "d skip checking trackingID", new string[] {
                        "record_mock"});
#line 50
this.ScenarioSetup(scenarioInfo);
#line 51
testRunner.When("I press GetWinner( TableID: 9, RoundID: -1 )");
#line 52
testRunner.Then("Get null and skip checking trackingID");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Request pay for colors winner information but TableID and RoundID is minus value," +
            " get null and skip checking trackingID")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "N2N Get winner information")]
        [Microsoft.Silverlight.Testing.TagAttribute("record_mock")]
        public virtual void RequestPayForColorsWinnerInformationButTableIDAndRoundIDIsMinusValueGetNullAndSkipCheckingTrackingID()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Request pay for colors winner information but TableID and RoundID is minus value," +
                    " get null and skip checking trackingID", new string[] {
                        "record_mock"});
#line 55
this.ScenarioSetup(scenarioInfo);
#line 56
testRunner.When("I press GetWinner( TableID: -1, RoundID: -1 )");
#line 57
testRunner.Then("Get null and skip checking trackingID");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion