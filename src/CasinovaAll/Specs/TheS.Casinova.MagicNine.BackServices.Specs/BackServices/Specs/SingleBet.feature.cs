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
    public partial class SingleBetFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SingleBet.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SingleBet", "In order to bet game by player\r\nAs a back server\r\nI want to be create bet informa" +
                    "tion to server", ((string[])(null)));
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
                        "00.00"});
#line 8
testRunner.Given("server has player information as:", ((string)(null)), table1);
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Round",
                        "StartTime",
                        "EndTime",
                        "WinnerPoint",
                        "GamePot",
                        "Active"});
            table2.AddRow(new string[] {
                        "1",
                        "2553/3/12 10:00",
                        "",
                        "9",
                        "4329",
                        "True"});
            table2.AddRow(new string[] {
                        "2",
                        "2553/3/12 10:00",
                        "",
                        "99",
                        "272",
                        "True"});
            table2.AddRow(new string[] {
                        "3",
                        "2553/3/12 10:00",
                        "",
                        "999",
                        "712",
                        "True"});
            table2.AddRow(new string[] {
                        "4",
                        "2553/3/12 10:00",
                        "",
                        "9999",
                        "432",
                        "True"});
#line 15
testRunner.And("server has game round information as:", ((string)(null)), table2);
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ได้รับข้อมูล Round, UserName, ระบบตรวจสอบเงินสำหรับลงพนันพอ, ระบบหักเงินผู้เล่น" +
            "และบันทึกข้อมูลการลงพนัน")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SingleBet")]
        public virtual void ไดรบขอมลRoundIDUserNameระบบตรวจสอบเงนสำหรบลงพนนพอระบบหกเงนผเลนและบนทกขอมลการลงพนน()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ได้รับข้อมูล Round, UserName, ระบบตรวจสอบเงินสำหรับลงพนันพอ, ระบบหักเงินผู้เล่น" +
                    "และบันทึกข้อมูลการลงพนัน", new string[] {
                        "record_mock",
                        "record_mock"});
#line 23
this.ScenarioSetup(scenarioInfo);
#line 24
testRunner.Given("The SingleBetExecutor has been created and initialized");
#line 25
testRunner.And("sent name: \'OhAe\' the player\'s balance should recieved");
#line 26
testRunner.And("sent Round: \'1\' the round pot should recieved");
#line 27
testRunner.And("the expected balance should be: \'462.61\'");
#line 28
testRunner.And("the round information(Round: \'1\', GamePot: \'4330\') should be update");
#line 29
testRunner.And("the bet information(Round: \'1\', UserName: \'OhAe\', BetOrder: \'4330\', BetTrackingID:" +
                    " \'B21F8971-DBAB-400F-9D95-151BA24875C1\') should be create");
#line 30
testRunner.When("call SingleBet(Round: \'1\', UserName: \'OhAe\', BetTrackingID: \'B21F8971-DBAB-400F-9D" +
                    "95-151BA24875C1\')");
#line 31
testRunner.Then("the result should be create");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ได้รับข้อมูล Round, UserName, ระบบตรวจสอบเงินสำหรับลงพนันพอ, ระบบหักเงินผู้เล่น" +
            "และบันทึกข้อมูลการลงพนัน2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SingleBet")]
        public virtual void ไดรบขอมลRoundIDUserNameระบบตรวจสอบเงนสำหรบลงพนนพอระบบหกเงนผเลนและบนทกขอมลการลงพนน2()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ได้รับข้อมูล Round, UserName, ระบบตรวจสอบเงินสำหรับลงพนันพอ, ระบบหักเงินผู้เล่น" +
                    "และบันทึกข้อมูลการลงพนัน2", new string[] {
                        "record_mock"});
#line 34
this.ScenarioSetup(scenarioInfo);
#line 35
testRunner.Given("The SingleBetExecutor has been created and initialized");
#line 36
testRunner.And("sent name: \'Nit\' the player\'s balance should recieved");
#line 37
testRunner.And("sent Round: \'3\' the round pot should recieved");
#line 38
testRunner.And("the expected balance should be: \'35.99\'");
#line 39
testRunner.And("the round information(Round: \'3\', GamePot: \'713\') should be update");
#line 40
testRunner.And("the bet information(Round: \'3\', UserName: \'Nit\', BetOrder: \'713\', BetTrackingID: \'" +
                    "B21F8971-DBAB-400F-9D95-151BA24875C1\') should be create");
#line 41
testRunner.When("call SingleBet(Round: \'3\', UserName: \'Nit\', BetTrackingID: \'B21F8971-DBAB-400F-9D9" +
                    "5-151BA24875C1\')");
#line 42
testRunner.Then("the result should be create");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ได้รับข้อมูล Round, UserName, ระบบตรวจสอบเงินสำหรับลงพนันไม่พอ, ระบบแจ้งเตือนว่" +
            "าเงินผู้เล่นไม่พอ")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SingleBet")]
        public virtual void ไดรบขอมลRoundIDUserNameระบบตรวจสอบเงนสำหรบลงพนนไมพอระบบแจงเตอนวาเงนผเลนไมพอ()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ได้รับข้อมูล Round, UserName, ระบบตรวจสอบเงินสำหรับลงพนันไม่พอ, ระบบแจ้งเตือนว่" +
                    "าเงินผู้เล่นไม่พอ", new string[] {
                        "record_mock"});
#line 45
this.ScenarioSetup(scenarioInfo);
#line 46
testRunner.Given("The SingleBetExecutor has been created and initialized");
#line 47
testRunner.And("sent name: \'Au\' the player\'s balance should recieved");
#line 48
testRunner.And("sent Round: \'2\' the round pot should recieved");
#line 49
testRunner.And("the expected balance less than bet cost");
#line 50
testRunner.When("call SingleBet(Round: \'2\', UserName: \'Au\', BetTrackingID: \'B21F8971-DBAB-400F-9D95" +
                    "-151BA24875C1\')");
#line 51
testRunner.Then("server should throw an error");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
