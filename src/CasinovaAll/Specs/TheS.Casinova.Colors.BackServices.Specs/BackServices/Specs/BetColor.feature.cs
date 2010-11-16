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
    public partial class BetColorFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "BetColor.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "BetColor", "In order to bet game round\r\nAs a back server\r\nI want to be update player informat" +
                    "ion and saving bet information", ((string[])(null)));
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
                        "121.99"});
            table1.AddRow(new string[] {
                        "Toommy",
                        "36.95"});
            table1.AddRow(new string[] {
                        "Au",
                        "234.00"});
#line 8
testRunner.Given("(BetColor)server has player information as:", ((string)(null)), table1);
#line hidden
        }
        
        public virtual void ผเลนลงเงนพนนโดยผเลนมเงนพอระบบบนทกประวตการดำเนนการพนนของผเลน(string roundID, string userName, string amount, string color, string trackingID)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ผู้เล่นลงเงินพนัน โดยผู้เล่นมีเงินพอ ระบบบันทึกประวัติการดำเนินการ(พนัน)ของผู้เล่" +
                    "น", new string[] {
                        "record_mock",
                        "record_mock"});
#line 16
this.ScenarioSetup(scenarioInfo);
#line 17
testRunner.Given("The BetColorExecutor has been created and initialized");
#line 18
testRunner.And(string.Format("sent name: {0} the player\'s balance should recieved, for bet color", userName));
#line 19
testRunner.And(string.Format("the player\'s balance should be update correct, Amount: {0}", amount));
#line 20
testRunner.And(string.Format("the player action information should be update as: (UserName: {0}, RoundID: {1}, " +
                        "Amount: {2}, Color: {3}, TrackingID: {4})", userName, roundID, amount, color, trackingID));
#line 21
testRunner.When(string.Format("call BetColorExecutor(UserName: {0}, RoundID: {1}, Amount: {2}, Color: {3}, Track" +
                        "ingID: {4})", userName, roundID, amount, color, trackingID));
#line 22
testRunner.Then("the player action information should be created");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ผู้เล่นลงเงินพนัน โดยผู้เล่นมีเงินพอ ระบบบันทึกประวัติการดำเนินการ(พนัน)ของผู้เล่" +
            "น")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BetColor")]
        public virtual void ผเลนลงเงนพนนโดยผเลนมเงนพอระบบบนทกประวตการดำเนนการพนนของผเลน_Variant0()
        {
            this.ผเลนลงเงนพนนโดยผเลนมเงนพอระบบบนทกประวตการดำเนนการพนนของผเลน("12", "OhAe", "5", "White", "B21F8971-DBAB-400F-9D95-151BA24875C1");
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ผู้เล่นลงเงินพนัน โดยผู้เล่นมีเงินพอ ระบบบันทึกประวัติการดำเนินการ(พนัน)ของผู้เล่" +
            "น")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BetColor")]
        public virtual void ผเลนลงเงนพนนโดยผเลนมเงนพอระบบบนทกประวตการดำเนนการพนนของผเลน_Variant1()
        {
            this.ผเลนลงเงนพนนโดยผเลนมเงนพอระบบบนทกประวตการดำเนนการพนนของผเลน("12", "Toommy", "7", "White", "B21F8971-DBAB-400F-9D95-151BA24875C1");
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ผู้เล่นลงเงินพนัน โดยผู้เล่นมีเงินพอ ระบบบันทึกประวัติการดำเนินการ(พนัน)ของผู้เล่" +
            "น")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BetColor")]
        public virtual void ผเลนลงเงนพนนโดยผเลนมเงนพอระบบบนทกประวตการดำเนนการพนนของผเลน_Variant2()
        {
            this.ผเลนลงเงนพนนโดยผเลนมเงนพอระบบบนทกประวตการดำเนนการพนนของผเลน("13", "Boy", "7.99", "Black", "B21F8971-DBAB-400F-9D95-151BA24875C1");
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ผู้เล่นลงเงินพนัน โดยผู้เล่นมีเงินพอ ระบบบันทึกประวัติการดำเนินการ(พนัน)ของผู้เล่" +
            "น")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BetColor")]
        public virtual void ผเลนลงเงนพนนโดยผเลนมเงนพอระบบบนทกประวตการดำเนนการพนนของผเลน_Variant3()
        {
            this.ผเลนลงเงนพนนโดยผเลนมเงนพอระบบบนทกประวตการดำเนนการพนนของผเลน("12", "Au", "221.21", "White", "B21F8971-DBAB-400F-9D95-151BA24875C1");
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ผู้เล่นลงเงินพนัน โดยผู้เล่นมีเงินพอ ระบบบันทึกประวัติการดำเนินการ(พนัน)ของผู้เล่" +
            "น")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BetColor")]
        public virtual void ผเลนลงเงนพนนโดยผเลนมเงนพอระบบบนทกประวตการดำเนนการพนนของผเลน_Variant4()
        {
            this.ผเลนลงเงนพนนโดยผเลนมเงนพอระบบบนทกประวตการดำเนนการพนนของผเลน("12", "OhAe", "9.99", "White", "B21F8971-DBAB-400F-9D95-151BA24875C1");
        }
    }
}
#endregion
