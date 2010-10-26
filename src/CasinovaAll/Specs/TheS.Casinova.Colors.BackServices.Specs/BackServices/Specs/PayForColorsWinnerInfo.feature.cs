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
namespace TheS.Casinova.TwoWins.BackServices.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.3.5.2")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class PayForColorsWinnerInformationFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "PayForColorsWinnerInfo.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "PayForColorsWinnerInformation", "In order to pay for colors winner information\r\nAs a back server\r\nI want to be tol" +
                    "d the round winner at this time", ((string[])(null)));
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
                        "121.21"});
            table1.AddRow(new string[] {
                        "Nit",
                        "36.99"});
            table1.AddRow(new string[] {
                        "Au",
                        "234.00"});
#line 8
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
                        "2553/3/12 10:00"});
            table2.AddRow(new string[] {
                        "12",
                        "Boy",
                        "GetWinner",
                        "2553/3/12 11:20"});
            table2.AddRow(new string[] {
                        "12",
                        "OhAe",
                        "Black",
                        "2553/3/12 11:22"});
            table2.AddRow(new string[] {
                        "12",
                        "OhAe",
                        "GetWinner",
                        "2553/3/12 11:28"});
            table2.AddRow(new string[] {
                        "13",
                        "Nit",
                        "GetWinner",
                        "2553/3/12 10:00"});
            table2.AddRow(new string[] {
                        "13",
                        "Boy",
                        "White",
                        "2553/3/12 11:20"});
            table2.AddRow(new string[] {
                        "14",
                        "OhAe",
                        "GetWinner",
                        "2553/3/12 11:22"});
            table2.AddRow(new string[] {
                        "14",
                        "OhAe",
                        "Black",
                        "2553/3/12 11:28"});
#line 15
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
#line 26
testRunner.And("server has round informations as:", ((string)(null)), table3);
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("หักเงินผู้เล่นจากข้อมูลที่ได้รับมา โดยผู้เล่นเคยเสียค่าดูข้อมูลแล้ว และส่งข้อมูลผ" +
            "ู้ชนะกลับ")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PayForColorsWinnerInformation")]
        public virtual void หกเงนผเลนจากขอมลทไดรบมาโดยผเลนเคยเสยคาดขอมลแลวและสงขอมลผชนะกลบ()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("หักเงินผู้เล่นจากข้อมูลที่ได้รับมา โดยผู้เล่นเคยเสียค่าดูข้อมูลแล้ว และส่งข้อมูลผ" +
                    "ู้ชนะกลับ", new string[] {
                        "record_mock",
                        "record_mock"});
#line 35
this.ScenarioSetup(scenarioInfo);
#line 36
testRunner.Given("The PayForColorsWinnerInfoExecutor has been created and initialized");
#line 37
testRunner.And("sent name: \'OhAe\' the player\'s balance should recieved");
#line 38
testRunner.And("sent roundID: \'12\', userName: \'OhAe\' the player\'s action information should recie" +
                    "ved");
#line 39
testRunner.And("sent roundID: \'12\' the round information should recieved");
#line 40
testRunner.And("the expected balance should be: \'462.61\'");
#line 41
testRunner.And("the player\'s action information(RoundID: \'12\', UserName: \'OhAe\', ActionType: \'Get" +
                    "Winner\', Amount: \'1.0\') should be create");
#line 42
testRunner.And("the game play information(RoundID: \'12\', UserName: \'OhAe\', OnGoingTrackingID: \'B2" +
                    "1F8971-DBAB-400F-9D95-151BA24875C1\') should be update");
#line 43
testRunner.And("the game play information(RoundID: \'12\', UserName: \'OhAe\', TrackingID: \'B21F8971-" +
                    "DBAB-400F-9D95-151BA24875C1\', Winner: \'Black\') should be update");
#line 44
testRunner.When("call PayForColorsWinnerInfo(UserName: \'OhAe\', RoundID: \'12\', OnGoingTrackingID: \'" +
                    "B21F8971-DBAB-400F-9D95-151BA24875C1\')");
#line 45
testRunner.Then("the update player\'s balance part should be updated");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("หักเงินผู้เล่นจากข้อมูลที่ได้รับมา โดยผู้เล่นยังไม่เคยเสียค่าดูข้อมูล และส่งข้อมู" +
            "ลผู้ชนะกลับ")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PayForColorsWinnerInformation")]
        public virtual void หกเงนผเลนจากขอมลทไดรบมาโดยผเลนยงไมเคยเสยคาดขอมลและสงขอมลผชนะกลบ()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("หักเงินผู้เล่นจากข้อมูลที่ได้รับมา โดยผู้เล่นยังไม่เคยเสียค่าดูข้อมูล และส่งข้อมู" +
                    "ลผู้ชนะกลับ", new string[] {
                        "record_mock"});
#line 48
this.ScenarioSetup(scenarioInfo);
#line 49
testRunner.Given("The PayForColorsWinnerInfoExecutor has been created and initialized");
#line 50
testRunner.And("sent name: \'Boy\' the player\'s balance should recieved");
#line 51
testRunner.And("sent roundID: \'13\', userName: \'Boy\' the player\'s action information should reciev" +
                    "ed");
#line 52
testRunner.And("sent roundID: \'13\' the round information should recieved");
#line 53
testRunner.And("the expected balance should be: \'116.21\'");
#line 54
testRunner.And("the player\'s action information(RoundID: \'13\', UserName: \'Boy\', ActionType: \'GetW" +
                    "inner\', Amount: \'5.0\') should be create");
#line 55
testRunner.And("the game play information(RoundID: \'13\', UserName: \'Boy\', OnGoingTrackingID: \'B21" +
                    "F8971-DBAB-400F-9D95-151BA24875C1\') should be update");
#line 56
testRunner.And("the game play information(RoundID: \'13\', UserName: \'Boy\', TrackingID: \'B21F8971-D" +
                    "BAB-400F-9D95-151BA24875C1\', Winner: \'White\') should be update");
#line 57
testRunner.When("call PayForColorsWinnerInfo(UserName: \'Boy\', RoundID: \'13\', OnGoingTrackingID: \'B" +
                    "21F8971-DBAB-400F-9D95-151BA24875C1\')");
#line 58
testRunner.Then("the update player\'s balance part should be updated");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
