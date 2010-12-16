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
    public partial class RangeBetFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "RangeBet.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "RangeBet", "In order to range betting\r\nAs a back server\r\nI want to be create range bet inform" +
                    "ation and each bet information", ((string[])(null)));
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
                        "NonRefundable",
                        "Refundable"});
            table1.AddRow(new string[] {
                        "OhAe",
                        "15.00",
                        "0"});
            table1.AddRow(new string[] {
                        "Boy",
                        "0.99",
                        "0"});
            table1.AddRow(new string[] {
                        "Toommy",
                        "36.95",
                        "37"});
            table1.AddRow(new string[] {
                        "Au",
                        "100.00",
                        "326"});
            table1.AddRow(new string[] {
                        "Game",
                        "1",
                        "5"});
            table1.AddRow(new string[] {
                        "Khag",
                        "0.52",
                        "45"});
            table1.AddRow(new string[] {
                        "Ple",
                        "0.99",
                        "452"});
#line 8
testRunner.Given("(Twowins_RangeBet)server has player information as:", ((string)(null)), table1);
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "RoundID",
                        "FromDateTime",
                        "ThruDateTime",
                        "CriticalTime",
                        "Pot"});
            table2.AddRow(new string[] {
                        "1",
                        "-20",
                        "30",
                        "25",
                        "759.00"});
            table2.AddRow(new string[] {
                        "2",
                        "-5",
                        "5",
                        "-3",
                        "5266.00"});
            table2.AddRow(new string[] {
                        "3",
                        "-10",
                        "90",
                        "85",
                        "165.00"});
            table2.AddRow(new string[] {
                        "4",
                        "0",
                        "0",
                        "0",
                        "15648.00"});
#line 18
testRunner.And("(Twowins_RangeBet)server has round information as:", ((string)(null)), table2);
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("(Twowins_RangeBet)ผู้เล่นลงพนันช่วงปกติของโต๊ะเกม โดยผู้เล่นมีชิฟพอและชิฟตายมากกว" +
            "่าจำนวนเงินที่ลงพนัน ระบบบันทึกข้อมูลการลงพนัน, ประวัติการดำเนินการ และหักเฉพาะช" +
            "ิฟตายของผู้เล่น")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RangeBet")]
        public virtual void Twowins_RangeBetผเลนลงพนนชวงปกตของโตะเกมโดยผเลนมชฟพอและชฟตายมากกวาจำนวนเงนทลงพนนระบบบนทกขอมลการลงพนนประวตการดำเนนการและหกเฉพาะชฟตายของผเลน()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("(Twowins_RangeBet)ผู้เล่นลงพนันช่วงปกติของโต๊ะเกม โดยผู้เล่นมีชิฟพอและชิฟตายมากกว" +
                    "่าจำนวนเงินที่ลงพนัน ระบบบันทึกข้อมูลการลงพนัน, ประวัติการดำเนินการ และหักเฉพาะช" +
                    "ิฟตายของผู้เล่น", new string[] {
                        "record_mock",
                        "record_mock"});
#line 26
this.ScenarioSetup(scenarioInfo);
#line 27
testRunner.Given("(Twowins_RangeBet)The RangeBetExecutor has been created and initialized");
#line 28
testRunner.And("(Twowins_RangeBet)sent name: \'OhAe\' the player\'s balance should recieved");
#line 29
testRunner.And("(Twowins_RangeBet)sent roundID: \'1\' the round information should recieved");
#line 30
testRunner.And("(Twowins_RangeBet)the round pot information should be update(RoundID: \'1\', Pot: \'" +
                    "774\')");
#line 31
testRunner.And("(Twowins_RangeBet)the player\'s balance should be update only bonuschips(UserName:" +
                    " \'OhAe\', BonusChips: \'0\', Chips: \'0\')");
#line 32
testRunner.And("(Twowins_RangeBet)the action log information should be create(RoundID: \'1\', UserN" +
                    "ame: \'OhAe\', ActionType: \'RangeBet\', Amount: \'15\', OldAmount: \'-1\', HandStatus: " +
                    "\'Normal\', CanChange: \'true\')");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "RoundID",
                        "UserName",
                        "BetTrackingID",
                        "Status",
                        "BonusChips",
                        "Chips",
                        "CanChange"});
            table3.AddRow(new string[] {
                        "1",
                        "OhAe",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1",
                        "Normal",
                        "1",
                        "0",
                        "true"});
            table3.AddRow(new string[] {
                        "1",
                        "OhAe",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1",
                        "Normal",
                        "2",
                        "0",
                        "true"});
            table3.AddRow(new string[] {
                        "1",
                        "OhAe",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1",
                        "Normal",
                        "3",
                        "0",
                        "true"});
            table3.AddRow(new string[] {
                        "1",
                        "OhAe",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1",
                        "Normal",
                        "4",
                        "0",
                        "true"});
            table3.AddRow(new string[] {
                        "1",
                        "OhAe",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1",
                        "Normal",
                        "5",
                        "0",
                        "true"});
#line 33
testRunner.And("(Twowins_RangeBet)expected the bet information should be create", ((string)(null)), table3);
#line 41
testRunner.When("(Twowins_RangeBet)call RangeBetExecutor(RoundID: \'1\', UserName: \'OhAe\', FromAmoun" +
                    "t: \'1\', ThruAmoutn: \'5\', BetTrackingID: \'B21F8971-DBAB-400F-9D95-151BA24875C1\')");
#line 42
testRunner.Then("the result should be create");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("(Twowins_RangeBet)ผู้เล่นลงพนันช่วงวิกฤตของโต๊ะเกม โดยผู้เล่นมีชิฟพอและชิฟตายมากก" +
            "ว่าจำนวนเงินที่ลงพนัน ระบบบันทึกข้อมูลการลงพนัน, ประวัติการดำเนินการ และหักเฉพาะ" +
            "ชิฟตายของผู้เล่นและชิฟเป็น")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RangeBet")]
        public virtual void Twowins_RangeBetผเลนลงพนนชวงวกฤตของโตะเกมโดยผเลนมชฟพอและชฟตายมากกวาจำนวนเงนทลงพนนระบบบนทกขอมลการลงพนนประวตการดำเนนการและหกเฉพาะชฟตายของผเลนและชฟเปน()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("(Twowins_RangeBet)ผู้เล่นลงพนันช่วงวิกฤตของโต๊ะเกม โดยผู้เล่นมีชิฟพอและชิฟตายมากก" +
                    "ว่าจำนวนเงินที่ลงพนัน ระบบบันทึกข้อมูลการลงพนัน, ประวัติการดำเนินการ และหักเฉพาะ" +
                    "ชิฟตายของผู้เล่นและชิฟเป็น", new string[] {
                        "record_mock"});
#line 45
this.ScenarioSetup(scenarioInfo);
#line 46
testRunner.Given("(Twowins_RangeBet)The RangeBetExecutor has been created and initialized");
#line 47
testRunner.And("(Twowins_RangeBet)sent name: \'Au\' the player\'s balance should recieved");
#line 48
testRunner.And("(Twowins_RangeBet)sent roundID: \'2\' the round information should recieved");
#line 49
testRunner.And("(Twowins_RangeBet)the round pot information should be update(RoundID: \'2\', Pot: \'" +
                    "5466\')");
#line 50
testRunner.And("(Twowins_RangeBet)the player\'s balance should be update only bonuschips(UserName:" +
                    " \'Au\', BonusChips: \'0\', Chips: \'226\')");
#line 51
testRunner.And("(Twowins_RangeBet)the action log information should be create(RoundID: \'2\', UserN" +
                    "ame: \'Au\', ActionType: \'RangeBet\', Amount: \'200\', OldAmount: \'-1\', HandStatus: \'" +
                    "Critical\', CanChange: \'true\')");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "RoundID",
                        "UserName",
                        "BetTrackingID",
                        "Status",
                        "BonusChips",
                        "Chips",
                        "CanChange"});
            table4.AddRow(new string[] {
                        "2",
                        "Au",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1",
                        "Critical",
                        "5",
                        "0",
                        "true"});
            table4.AddRow(new string[] {
                        "2",
                        "Au",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1",
                        "Critical",
                        "6",
                        "0",
                        "true"});
            table4.AddRow(new string[] {
                        "2",
                        "Au",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1",
                        "Critical",
                        "7",
                        "0",
                        "true"});
            table4.AddRow(new string[] {
                        "2",
                        "Au",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1",
                        "Critical",
                        "8",
                        "0",
                        "true"});
            table4.AddRow(new string[] {
                        "2",
                        "Au",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1",
                        "Critical",
                        "9",
                        "0",
                        "true"});
            table4.AddRow(new string[] {
                        "2",
                        "Au",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1",
                        "Critical",
                        "10",
                        "0",
                        "true"});
            table4.AddRow(new string[] {
                        "2",
                        "Au",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1",
                        "Critical",
                        "11",
                        "0",
                        "true"});
            table4.AddRow(new string[] {
                        "2",
                        "Au",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1",
                        "Critical",
                        "12",
                        "0",
                        "true"});
            table4.AddRow(new string[] {
                        "2",
                        "Au",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1",
                        "Critical",
                        "13",
                        "0",
                        "true"});
            table4.AddRow(new string[] {
                        "2",
                        "Au",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1",
                        "Critical",
                        "14",
                        "0",
                        "true"});
            table4.AddRow(new string[] {
                        "2",
                        "Au",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1",
                        "Critical",
                        "5",
                        "10",
                        "true"});
            table4.AddRow(new string[] {
                        "2",
                        "Au",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1",
                        "Critical",
                        "0",
                        "16",
                        "true"});
            table4.AddRow(new string[] {
                        "2",
                        "Au",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1",
                        "Critical",
                        "0",
                        "17",
                        "true"});
            table4.AddRow(new string[] {
                        "2",
                        "Au",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1",
                        "Critical",
                        "0",
                        "18",
                        "true"});
            table4.AddRow(new string[] {
                        "2",
                        "Au",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1",
                        "Critical",
                        "0",
                        "19",
                        "true"});
            table4.AddRow(new string[] {
                        "2",
                        "Au",
                        "B21F8971-DBAB-400F-9D95-151BA24875C1",
                        "Critical",
                        "0",
                        "20",
                        "true"});
#line 52
testRunner.And("(Twowins_RangeBet)expected the bet information should be create", ((string)(null)), table4);
#line 71
testRunner.When("(Twowins_RangeBet)call RangeBetExecutor(RoundID: \'2\', UserName: \'Au\', FromAmount:" +
                    " \'5\', ThruAmoutn: \'20\', BetTrackingID: \'B21F8971-DBAB-400F-9D95-151BA24875C1\')");
#line 72
testRunner.Then("the result should be create");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("(Twowins_RangeBet)ผู้เล่นลงพนันในโต๊ะเกมที่จบรอบแล้ว ระบบแจ้งเตือนผู้เล่น")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RangeBet")]
        public virtual void Twowins_RangeBetผเลนลงพนนในโตะเกมทจบรอบแลวระบบแจงเตอนผเลน()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("(Twowins_RangeBet)ผู้เล่นลงพนันในโต๊ะเกมที่จบรอบแล้ว ระบบแจ้งเตือนผู้เล่น", new string[] {
                        "record_mock"});
#line 75
this.ScenarioSetup(scenarioInfo);
#line 76
testRunner.Given("(Twowins_RangeBet)The RangeBetExecutor has been created and initialized");
#line 77
testRunner.And("(Twowins_RangeBet)sent name: \'Au\' the player\'s balance should recieved");
#line 78
testRunner.And("(Twowins_RangeBet)sent roundID: \'4\' the round information should recieved");
#line 79
testRunner.When("(Twowins_RangeBet)Expected exception and call RangeBetExecutor(RoundID: \'4\', User" +
                    "Name: \'Au\', FromAmount: \'5\', ThruAmoutn: \'20\', BetTrackingID: \'B21F8971-DBAB-400" +
                    "F-9D95-151BA24875C1\')");
#line 80
testRunner.Then("the result should be throw exception");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
