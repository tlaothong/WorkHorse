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
namespace TheS.Casinova.Colors.BackServices
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.3.5.2")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class UpdatePlayerBalanceToPayForColorsWinnerInfoFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "UpdatePlayerBalanceToPayForColorsWinnerInfo.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "UpdatePlayerBalanceToPayForColorsWinnerInfo", "In order to update player balance\r\nAs a back server\r\nI want to be update player b" +
                    "alance to pay for colors winner information", ((string[])(null)));
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
#line 6
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "UserName",
                        "Balance"});
            table1.AddRow(new string[] {
                        "OhAe",
                        "463.61"});
            table1.AddRow(new string[] {
                        "Boy",
                        "121.21"});
            table1.AddRow(new string[] {
                        "Nit",
                        "36.99"});
            table1.AddRow(new string[] {
                        "Au",
                        "234.00"});
#line 7
testRunner.Given("server has player information as:", ((string)(null)), table1);
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "RoundID",
                        "UserName",
                        "ActionType",
                        "DateTime(for example, not use this row)"});
            table2.AddRow(new string[] {
                        "12",
                        "OhAe",
                        "GetWinner",
                        "12/3/2553 10:00"});
            table2.AddRow(new string[] {
                        "12",
                        "Boy",
                        "GetWinner",
                        "12/3/2553 11:20"});
            table2.AddRow(new string[] {
                        "12",
                        "OhAe",
                        "Black",
                        "12/3/2553 11:22"});
            table2.AddRow(new string[] {
                        "12",
                        "OhAe",
                        "GetWinner",
                        "12/3/2553 11:28"});
            table2.AddRow(new string[] {
                        "13",
                        "Nit",
                        "GetWinner",
                        "13/3/2553 10:00"});
            table2.AddRow(new string[] {
                        "13",
                        "Boy",
                        "White",
                        "13/3/2553 11:20"});
            table2.AddRow(new string[] {
                        "14",
                        "OhAe",
                        "GetWinner",
                        "15/3/2553 11:22"});
            table2.AddRow(new string[] {
                        "14",
                        "OhAe",
                        "Black",
                        "15/3/2553 11:28"});
#line 14
testRunner.And("server has player action informations as:", ((string)(null)), table2);
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "RoundID",
                        "BlackPot",
                        "WhitePot"});
            table3.AddRow(new string[] {
                        "10",
                        "21.31",
                        "235.12"});
            table3.AddRow(new string[] {
                        "11",
                        "2841.23",
                        "382.2"});
            table3.AddRow(new string[] {
                        "12",
                        "98.98",
                        "632.01"});
            table3.AddRow(new string[] {
                        "13",
                        "65.83",
                        "23.55"});
            table3.AddRow(new string[] {
                        "14",
                        "2.99",
                        "7.01"});
#line 25
testRunner.And("server has round informations as:", ((string)(null)), table3);
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("หักเงินผู้เล่นจากข้อมูลที่ได้รับมา โดยผู้เล่นเคยเสียค่าดูข้อมูลแล้ว และส่งข้อมูลผ" +
            "ู้ชนะกลับ")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "UpdatePlayerBalanceToPayForColorsWinnerInfo")]
        public virtual void หกเงนผเลนจากขอมลทไดรบมาโดยผเลนเคยเสยคาดขอมลแลวและสงขอมลผชนะกลบ()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("หักเงินผู้เล่นจากข้อมูลที่ได้รับมา โดยผู้เล่นเคยเสียค่าดูข้อมูลแล้ว และส่งข้อมูลผ" +
                    "ู้ชนะกลับ", new string[] {
                        "record_mock"});
#line 34
this.ScenarioSetup(scenarioInfo);
#line 35
testRunner.Given("The PayForColorsWinnerInfoExecutor has been created and initialized");
#line 36
testRunner.And("the player\'s balance should recieved, name: \'OhAe\'");
#line 37
testRunner.And("the player\'s action information should recieved, RoundID: \'12\', UserName: \'OhAe\'");
#line 38
testRunner.And("the round information should recieved, roundID: \'12\'");
#line 39
testRunner.And("the expected balance should be: \'462.61\'");
#line 40
testRunner.And("the player\'s action information(RoundID: \'12\', UserName: \'OhAe\', ActionType: \'Get" +
                    "Winner\', Amount: \'1.0\') should be create");
#line 41
testRunner.And("the game play information(RoundID: \'12\', UserName: \'OhAe\', OnGoingTrackingID: \'B2" +
                    "1F8971-DBAB-400F-9D95-151BA24875C1\') should be update");
#line 42
testRunner.And("the game play information(RoundID: \'12\', UserName: \'OhAe\', TrackingID: \'B21F8971-" +
                    "DBAB-400F-9D95-151BA24875C1\', Winner: \'Black\') should be update");
#line 43
testRunner.When("call PayForColorsWinnerInfo(UserName: \'OhAe\', RoundID: \'12\', OnGoingTrackingID: \'" +
                    "B21F8971-DBAB-400F-9D95-151BA24875C1\')");
#line 44
testRunner.Then("the update player\'s balance part should be updated");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("หักเงินผู้เล่นจากข้อมูลที่ได้รับมา โดยผู้เล่นยังไม่เคยเสียค่าดูข้อมูล และส่งข้อมู" +
            "ลผู้ชนะกลับ")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "UpdatePlayerBalanceToPayForColorsWinnerInfo")]
        public virtual void หกเงนผเลนจากขอมลทไดรบมาโดยผเลนยงไมเคยเสยคาดขอมลและสงขอมลผชนะกลบ()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("หักเงินผู้เล่นจากข้อมูลที่ได้รับมา โดยผู้เล่นยังไม่เคยเสียค่าดูข้อมูล และส่งข้อมู" +
                    "ลผู้ชนะกลับ", new string[] {
                        "record_mock"});
#line 47
this.ScenarioSetup(scenarioInfo);
#line 48
testRunner.Given("The PayForColorsWinnerInfoExecutor has been created and initialized");
#line 49
testRunner.And("the player\'s balance should recieved, name: \'Boy\'");
#line 50
testRunner.And("the player\'s action information should recieved, RoundID: \'13\', UserName: \'Boy\'");
#line 51
testRunner.And("the round information should recieved, roundID: \'13\'");
#line 52
testRunner.And("the expected balance should be: \'116.21\'");
#line 53
testRunner.And("the player\'s action information(RoundID: \'13\', UserName: \'Boy\', ActionType: \'GetW" +
                    "inner\', Amount: \'5.0\') should be create");
#line 54
testRunner.And("the game play information(RoundID: \'13\', UserName: \'Boy\', OnGoingTrackingID: \'B21" +
                    "F8971-DBAB-400F-9D95-151BA24875C1\') should be update");
#line 55
testRunner.And("the game play information(RoundID: \'13\', UserName: \'Boy\', TrackingID: \'B21F8971-D" +
                    "BAB-400F-9D95-151BA24875C1\', Winner: \'White\') should be update");
#line 56
testRunner.When("call PayForColorsWinnerInfo(UserName: \'Boy\', RoundID: \'13\', OnGoingTrackingID: \'B" +
                    "21F8971-DBAB-400F-9D95-151BA24875C1\')");
#line 57
testRunner.Then("the update player\'s balance part should be updated");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
