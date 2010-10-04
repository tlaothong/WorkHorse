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
namespace TheS.Casinova.ColorsGame.WebExecutors.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.3.5.2")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class GetGameRoundWinnerFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GetGameRoundWinner.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Get game round winner", "In order to get information of winner in the round\r\nAs as system\r\nI want to be to" +
                    "ld the game information of winner that a user has play and game is active", ((string[])(null)));
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Sent username that available in game and get information success")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Get game round winner")]
        public virtual void SentUsernameThatAvailableInGameAndGetInformationSuccess()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sent username that available in game and get information success", new string[] {
                        "record_mock"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 9
testRunner.Given("The GameRoundWinner has been created and initialized");
#line 10
testRunner.And("Sent username \'J.Doe\' Game active formtime \'10:00\'");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Username",
                        "TableID",
                        "RoundID",
                        "TotalBetAmountOfBlack",
                        "TotalBetAmountOfWhite",
                        "LastUpdate",
                        "TrackingID",
                        "OnGoingTrackingID",
                        "Winner"});
            table1.AddRow(new string[] {
                        "J.Doe",
                        "1",
                        "5",
                        "10",
                        "20",
                        "10:00",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1",
                        "White"});
            table1.AddRow(new string[] {
                        "J.Doe",
                        "2",
                        "6",
                        "34",
                        "32",
                        "10:00",
                        "C6BF4092-836B-4069-B2DD-392F8452FA91",
                        "C6BF4092-836B-4069-B2DD-392F8452FA91",
                        "Black"});
            table1.AddRow(new string[] {
                        "J.Doe",
                        "3",
                        "7",
                        "143",
                        "352",
                        "10:00",
                        "496B30C2-8849-49A2-B27F-CD0F5796D912",
                        "496B30C2-8849-49A2-B27F-CD0F5796D912",
                        "White"});
#line 11
testRunner.And("server have J.Doe\'s gameRoundWinner as", ((string)(null)), table1);
#line 18
testRunner.When("Call GetGameRoundWinner(\'J.Doe\')");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Username",
                        "TableID",
                        "RoundID",
                        "TotalBetAmountOfBlack",
                        "TotalBetAmountOfWhite",
                        "LastUpdate",
                        "TrackingID",
                        "OnGoingTrackingID",
                        "Winner"});
            table2.AddRow(new string[] {
                        "J.Doe",
                        "1",
                        "5",
                        "10",
                        "20",
                        "10:00",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1",
                        "White"});
            table2.AddRow(new string[] {
                        "J.Doe",
                        "2",
                        "6",
                        "34",
                        "32",
                        "10:00",
                        "C6BF4092-836B-4069-B2DD-392F8452FA91",
                        "C6BF4092-836B-4069-B2DD-392F8452FA91",
                        "Black"});
            table2.AddRow(new string[] {
                        "J.Doe",
                        "3",
                        "7",
                        "143",
                        "352",
                        "10:00",
                        "496B30C2-8849-49A2-B27F-CD0F5796D912",
                        "496B30C2-8849-49A2-B27F-CD0F5796D912",
                        "White"});
#line 19
testRunner.Then("the result should be", ((string)(null)), table2);
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Sent username that available in game but database do not have information")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Get game round winner")]
        public virtual void SentUsernameThatAvailableInGameButDatabaseDoNotHaveInformation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sent username that available in game but database do not have information", new string[] {
                        "record_mock"});
#line 26
this.ScenarioSetup(scenarioInfo);
#line 28
testRunner.Given("The GameRoundWinner has been created and initialized");
#line 29
testRunner.And("Sent username \'J.Doe\' Game active formtime \'10:00\'");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Username",
                        "TableID",
                        "RoundID",
                        "TotalBetAmountOfBlack",
                        "TotalBetAmountOfWhite",
                        "LastUpdate",
                        "TrackingID",
                        "OnGoingTrackingID",
                        "Winner"});
#line 30
testRunner.And("server have J.Doe\'s gameRoundWinner as", ((string)(null)), table3);
#line 34
testRunner.When("Call GetGameRoundWinner(\'J.Doe\')");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Username",
                        "TableID",
                        "RoundID",
                        "TotalBetAmountOfBlack",
                        "TotalBetAmountOfWhite",
                        "LastUpdate",
                        "TrackingID",
                        "OnGoingTrackingID",
                        "Winner"});
#line 35
testRunner.Then("the result should be", ((string)(null)), table4);
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("username not available")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Get game round winner")]
        public virtual void UsernameNotAvailable()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("username not available", new string[] {
                        "record_mock"});
#line 40
this.ScenarioSetup(scenarioInfo);
#line 42
testRunner.Given("The GameRoundWinner has been created and initialized");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Username",
                        "TableID",
                        "RoundID",
                        "TotalBetAmountOfBlack",
                        "TotalBetAmountOfWhite",
                        "LastUpdate",
                        "TrackingID",
                        "OnGoingTrackingID",
                        "Winner"});
            table5.AddRow(new string[] {
                        "John",
                        "1",
                        "5",
                        "10",
                        "20",
                        "10:00",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1",
                        "White"});
            table5.AddRow(new string[] {
                        "John",
                        "2",
                        "6",
                        "34",
                        "32",
                        "10:00",
                        "C6BF4092-836B-4069-B2DD-392F8452FA91",
                        "C6BF4092-836B-4069-B2DD-392F8452FA91",
                        "Black"});
            table5.AddRow(new string[] {
                        "John",
                        "3",
                        "7",
                        "143",
                        "352",
                        "10:00",
                        "496B30C2-8849-49A2-B27F-CD0F5796D912",
                        "496B30C2-8849-49A2-B27F-CD0F5796D912",
                        "White"});
#line 43
testRunner.And("server have John\'s gameRoundWinner as", ((string)(null)), table5);
#line 50
testRunner.When("Call GetGameRoundWinner(\'John\')");
#line 51
testRunner.Then("the result should be empty");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
