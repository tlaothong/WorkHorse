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
namespace TheS.Casinova.MLN.WebExecutors.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.3.5.2")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class ListDownLineByLevelFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ListDownLineByLevelFeature.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ListDownLineByLevel", "In order to ให้ผู้เล่นทราบรายละเอียดจำนวน DownLine ทั้งหมดที่มีในแต่ละ level\r\nAs " +
                    "a User\r\nI want ดึงข้อมูลรายละเอียด DownLine ทั้งหมดที่มีใน level นั้น ๆ และ Down" +
                    "Line ทั้งหมดที่มีผลต่อผู้ใช้", ((string[])(null)));
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
                        "UplineLevel1",
                        "UplineLevel2",
                        "UplineLevel3",
                        "BonusThisMonth",
                        "BonusLastMonth",
                        "TotalDownLineLevel1",
                        "TotalDownLineLevel2",
                        "TotalDownLineLevel3",
                        "TotalBonus"});
            table1.AddRow(new string[] {
                        "Nit",
                        "TheS",
                        "TheS",
                        "TheS",
                        "200",
                        "300",
                        "3",
                        "3",
                        "4",
                        "2541"});
            table1.AddRow(new string[] {
                        "Boy",
                        "Nit",
                        "TheS",
                        "TheS",
                        "150",
                        "274",
                        "1",
                        "3",
                        "4",
                        "503"});
            table1.AddRow(new string[] {
                        "OhAe",
                        "Boy",
                        "Nit",
                        "TheS",
                        "324",
                        "350",
                        "3",
                        "4",
                        "3",
                        "1056"});
            table1.AddRow(new string[] {
                        "Jay",
                        "OhAe",
                        "Boy",
                        "Nit",
                        "200",
                        "120",
                        "2",
                        "2",
                        "0",
                        "524"});
            table1.AddRow(new string[] {
                        "Art",
                        "Jay",
                        "OhAe",
                        "Boy",
                        "165",
                        "155",
                        "1",
                        "0",
                        "0",
                        "426"});
            table1.AddRow(new string[] {
                        "Of",
                        "OhAe",
                        "Boy",
                        "Nit",
                        "106",
                        "57",
                        "1",
                        "1",
                        "0",
                        "236"});
            table1.AddRow(new string[] {
                        "Kab",
                        "Of",
                        "OhAe",
                        "Boy",
                        "265",
                        "254",
                        "1",
                        "0",
                        "0",
                        "630"});
            table1.AddRow(new string[] {
                        "Sak",
                        "Kab",
                        "Of",
                        "OhAe",
                        "120",
                        "156",
                        "0",
                        "0",
                        "0",
                        "336"});
            table1.AddRow(new string[] {
                        "Boong",
                        "Nit",
                        "TheS",
                        "TheS",
                        "287",
                        "365",
                        "1",
                        "1",
                        "0",
                        "854"});
            table1.AddRow(new string[] {
                        "Khak",
                        "Nit",
                        "TheS",
                        "TheS",
                        "51",
                        "105",
                        "1",
                        "0",
                        "0",
                        "204"});
            table1.AddRow(new string[] {
                        "Toommy",
                        "Khak",
                        "Nit",
                        "TheS",
                        "265",
                        "97",
                        "0",
                        "0",
                        "0",
                        "450"});
            table1.AddRow(new string[] {
                        "Pray",
                        "Boong",
                        "Nit",
                        "TheS",
                        "112",
                        "110",
                        "1",
                        "0",
                        "0",
                        "320"});
            table1.AddRow(new string[] {
                        "Jo",
                        "Jay",
                        "OhAe",
                        "Boy",
                        "55",
                        "25",
                        "1",
                        "0",
                        "0",
                        "110"});
            table1.AddRow(new string[] {
                        "Bird",
                        "Jo",
                        "Jay",
                        "OhAe",
                        "63",
                        "45",
                        "0",
                        "0",
                        "0",
                        "200"});
            table1.AddRow(new string[] {
                        "Top",
                        "OhAe",
                        "Boy",
                        "Nit",
                        "20",
                        "12",
                        "1",
                        "0",
                        "0",
                        "45"});
            table1.AddRow(new string[] {
                        "Toa",
                        "Pray",
                        "Boong",
                        "Nit",
                        "25",
                        "5",
                        "0",
                        "0",
                        "0",
                        "25"});
            table1.AddRow(new string[] {
                        "Map",
                        "Top",
                        "OhAe",
                        "Boy",
                        "12",
                        "10",
                        "0",
                        "0",
                        "0",
                        "20"});
            table1.AddRow(new string[] {
                        "Amp",
                        "Art",
                        "Jay",
                        "OhAe",
                        "2",
                        "4",
                        "0",
                        "0",
                        "0",
                        "20"});
#line 8
testRunner.Given("Server has downline information :", ((string)(null)), table1);
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[ListDownLineByLevel] ระบบได้รับข้อมูลการขอดูข้อมูล DownLine ทำการตรวจสอบข้อมูล ข" +
            "้อมูลถูกต้อง ดึงข้อมูล Downline แต่ละ level ได้")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ListDownLineByLevel")]
        public virtual void ListDownLineByLevelระบบไดรบขอมลการขอดขอมลDownLineทำการตรวจสอบขอมลขอมลถกตองดงขอมลDownlineแตละLevelได()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[ListDownLineByLevel] ระบบได้รับข้อมูลการขอดูข้อมูล DownLine ทำการตรวจสอบข้อมูล ข" +
                    "้อมูลถูกต้อง ดึงข้อมูล Downline แต่ละ level ได้", new string[] {
                        "record_mock",
                        "record_mock"});
#line 30
this.ScenarioSetup(scenarioInfo);
#line 31
testRunner.Given("The ListDownLineByLevelExecutor has been created and initialized");
#line 32
testRunner.And("Sent UserName\'Boy\' to list downline by level");
#line 33
testRunner.When("Call ListDownLineBylavelExecutor()");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "UserName",
                        "UplineLevel1",
                        "UplineLevel2",
                        "UplineLevel3",
                        "BonusThisMonth",
                        "BonusLastMonth",
                        "TotalDownLineLevel1",
                        "TotalDownLineLevel2",
                        "TotalDownLineLevel3",
                        "TotalBonus",
                        "GroupCount"});
            table2.AddRow(new string[] {
                        "OhAe",
                        "Boy",
                        "Nit",
                        "TheS",
                        "324",
                        "350",
                        "3",
                        "4",
                        "3",
                        "1056",
                        "7"});
#line 34
testRunner.Then("DowwnLineLevel1 information should be as:", ((string)(null)), table2);
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "UserName",
                        "UplineLevel1",
                        "UplineLevel2",
                        "UplineLevel3",
                        "BonusThisMonth",
                        "BonusLastMonth",
                        "TotalDownLineLevel1",
                        "TotalDownLineLevel2",
                        "TotalDownLineLevel3",
                        "TotalBonus",
                        "GroupCount"});
            table3.AddRow(new string[] {
                        "Jay",
                        "OhAe",
                        "Boy",
                        "Nit",
                        "200",
                        "120",
                        "2",
                        "2",
                        "0",
                        "524",
                        "2"});
            table3.AddRow(new string[] {
                        "Of",
                        "OhAe",
                        "Boy",
                        "Nit",
                        "106",
                        "57",
                        "1",
                        "1",
                        "0",
                        "236",
                        "1"});
            table3.AddRow(new string[] {
                        "Top",
                        "OhAe",
                        "Boy",
                        "Nit",
                        "20",
                        "12",
                        "1",
                        "0",
                        "0",
                        "45",
                        "1"});
#line 38
testRunner.And("DowwnLineLevel2 information should be as:", ((string)(null)), table3);
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "UserName",
                        "UplineLevel1",
                        "UplineLevel2",
                        "UplineLevel3",
                        "BonusThisMonth",
                        "BonusLastMonth",
                        "TotalDownLineLevel1",
                        "TotalDownLineLevel2",
                        "TotalDownLineLevel3",
                        "TotalBonus",
                        "GroupCount"});
            table4.AddRow(new string[] {
                        "Art",
                        "Jay",
                        "OhAe",
                        "Boy",
                        "165",
                        "155",
                        "1",
                        "0",
                        "0",
                        "426",
                        "0"});
            table4.AddRow(new string[] {
                        "Kab",
                        "Of",
                        "OhAe",
                        "Boy",
                        "265",
                        "254",
                        "1",
                        "0",
                        "0",
                        "630",
                        "0"});
            table4.AddRow(new string[] {
                        "Jo",
                        "Jay",
                        "OhAe",
                        "Boy",
                        "55",
                        "25",
                        "1",
                        "0",
                        "0",
                        "110",
                        "0"});
            table4.AddRow(new string[] {
                        "Map",
                        "Top",
                        "OhAe",
                        "Boy",
                        "12",
                        "10",
                        "0",
                        "0",
                        "0",
                        "20",
                        "0"});
#line 43
testRunner.And("DowwnLineLevel3 information should be as:", ((string)(null)), table4);
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[ListDownLineByLevel] ระบบได้รับข้อมูลการขอดูข้อมูล DownLine แต่ในฐานข้อมูลผู้ใช้" +
            "ดังกล่าวยังไม่มี downline ได้ข้อมูล downline เป็น null")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ListDownLineByLevel")]
        public virtual void ListDownLineByLevelระบบไดรบขอมลการขอดขอมลDownLineแตในฐานขอมลผใชดงกลาวยงไมมDownlineไดขอมลDownlineเปนNull()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[ListDownLineByLevel] ระบบได้รับข้อมูลการขอดูข้อมูล DownLine แต่ในฐานข้อมูลผู้ใช้" +
                    "ดังกล่าวยังไม่มี downline ได้ข้อมูล downline เป็น null", new string[] {
                        "record_mock"});
#line 51
this.ScenarioSetup(scenarioInfo);
#line 52
testRunner.Given("The ListDownLineByLevelExecutor has been created and initialized");
#line 53
testRunner.And("Sent UserName\'Amp\' to list downline by level");
#line 54
testRunner.When("Call ListDownLineBylavelExecutor()");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "UserName",
                        "UplineLevel1",
                        "UplineLevel2",
                        "UplineLevel3",
                        "BonusThisMonth",
                        "BonusLastMonth",
                        "TotalDownLineLevel1",
                        "TotalDownLineLevel2",
                        "TotalDownLineLevel3",
                        "TotalBonus",
                        "GroupCount"});
#line 55
testRunner.Then("DowwnLineLevel1 information should be as:", ((string)(null)), table5);
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "UserName",
                        "UplineLevel1",
                        "UplineLevel2",
                        "UplineLevel3",
                        "BonusThisMonth",
                        "BonusLastMonth",
                        "TotalDownLineLevel1",
                        "TotalDownLineLevel2",
                        "TotalDownLineLevel3",
                        "TotalBonus",
                        "GroupCount"});
#line 58
testRunner.And("DowwnLineLevel2 information should be as:", ((string)(null)), table6);
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "UserName",
                        "UplineLevel1",
                        "UplineLevel2",
                        "UplineLevel3",
                        "BonusThisMonth",
                        "BonusLastMonth",
                        "TotalDownLineLevel1",
                        "TotalDownLineLevel2",
                        "TotalDownLineLevel3",
                        "TotalBonus",
                        "GroupCount"});
#line 61
testRunner.And("DowwnLineLevel3 information should be as:", ((string)(null)), table7);
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[ListDownLineByLevel] ระบบได้รับข้อมูลการขอดูข้อมูล DownLine แต่ในฐานข้อมูลไม่มีช" +
            "ื่อผู้ใช้ดังกล่าว ได้ข้อมูล downline เป็น null")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ListDownLineByLevel")]
        public virtual void ListDownLineByLevelระบบไดรบขอมลการขอดขอมลDownLineแตในฐานขอมลไมมชอผใชดงกลาวไดขอมลDownlineเปนNull()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[ListDownLineByLevel] ระบบได้รับข้อมูลการขอดูข้อมูล DownLine แต่ในฐานข้อมูลไม่มีช" +
                    "ื่อผู้ใช้ดังกล่าว ได้ข้อมูล downline เป็น null", new string[] {
                        "record_mock"});
#line 65
this.ScenarioSetup(scenarioInfo);
#line 66
testRunner.Given("The ListDownLineByLevelExecutor has been created and initialized");
#line 67
testRunner.And("Sent UserName\'Amp\' to list downline by level");
#line 68
testRunner.When("Call ListDownLineBylavelExecutor()");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "UserName",
                        "UplineLevel1",
                        "UplineLevel2",
                        "UplineLevel3",
                        "BonusThisMonth",
                        "BonusLastMonth",
                        "TotalDownLineLevel1",
                        "TotalDownLineLevel2",
                        "TotalDownLineLevel3",
                        "TotalBonus",
                        "GroupCount"});
#line 69
testRunner.Then("DowwnLineLevel1 information should be as:", ((string)(null)), table8);
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "UserName",
                        "UplineLevel1",
                        "UplineLevel2",
                        "UplineLevel3",
                        "BonusThisMonth",
                        "BonusLastMonth",
                        "TotalDownLineLevel1",
                        "TotalDownLineLevel2",
                        "TotalDownLineLevel3",
                        "TotalBonus",
                        "GroupCount"});
#line 72
testRunner.And("DowwnLineLevel2 information should be as:", ((string)(null)), table9);
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "UserName",
                        "UplineLevel1",
                        "UplineLevel2",
                        "UplineLevel3",
                        "BonusThisMonth",
                        "BonusLastMonth",
                        "TotalDownLineLevel1",
                        "TotalDownLineLevel2",
                        "TotalDownLineLevel3",
                        "TotalBonus",
                        "GroupCount"});
#line 75
testRunner.And("DowwnLineLevel3 information should be as:", ((string)(null)), table10);
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[ListDownLineByLevel] ระบบได้รับข้อมูลการขอดูข้อมูล DownLine แต่ข้อมูลไม่ถูกต้อง " +
            "ระบบไม่สามารถดึงข้อมูล downline ได้")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ListDownLineByLevel")]
        public virtual void ListDownLineByLevelระบบไดรบขอมลการขอดขอมลDownLineแตขอมลไมถกตองระบบไมสามารถดงขอมลDownlineได()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[ListDownLineByLevel] ระบบได้รับข้อมูลการขอดูข้อมูล DownLine แต่ข้อมูลไม่ถูกต้อง " +
                    "ระบบไม่สามารถดึงข้อมูล downline ได้", new string[] {
                        "record_mock"});
#line 80
this.ScenarioSetup(scenarioInfo);
#line 81
testRunner.Given("The ListDownLineByLevelExecutor has been created and initialized");
#line 82
testRunner.And("Sent UserName\'\' to list downline by level");
#line 83
testRunner.When("Call ListDownLineBylavelExecutor() for validate information");
#line 84
testRunner.Then("The result DowwnLine information should be throw exception");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
