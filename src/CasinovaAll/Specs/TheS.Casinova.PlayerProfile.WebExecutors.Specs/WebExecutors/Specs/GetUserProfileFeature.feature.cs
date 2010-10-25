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
namespace TheS.Casinova.PlayerProfile.WebExecutors.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.3.5.2")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class GetUserProfileFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GetUserProfileFeature.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "GetUserProfile", "In order to get user profile\r\nAs a system\r\nI want to get profile of player by use" +
                    "rName", ((string[])(null)));
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
                        "Password",
                        "Email",
                        "CellPhone",
                        "Upline",
                        "Refundable",
                        "NonRefundable",
                        "Active"});
            table1.AddRow(new string[] {
                        "OhAe",
                        "1234",
                        "sirinarin@hotmail.com",
                        "0892165437",
                        "Nit",
                        "500",
                        "200",
                        "True"});
            table1.AddRow(new string[] {
                        "Boy",
                        "5843",
                        "pongsak@gmail.com",
                        "0862202260",
                        "Nit",
                        "4500",
                        "500",
                        "True"});
            table1.AddRow(new string[] {
                        "Nit",
                        "1311",
                        "nayit_nit@hotmail.com",
                        "0892131356",
                        "",
                        "1000",
                        "589",
                        "True"});
#line 8
testRunner.Given("Server has user profile information as:", ((string)(null)), table1);
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบได้รับข้อมูล username ถูกต้อง ระบบสามารถดึงข้อมูล user profile ของผู้เล่นได้")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GetUserProfile")]
        public virtual void ระบบไดรบขอมลUsernameถกตองระบบสามารถดงขอมลUserProfileของผเลนได()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ระบบได้รับข้อมูล username ถูกต้อง ระบบสามารถดึงข้อมูล user profile ของผู้เล่นได้", new string[] {
                        "record_mock",
                        "record_mock"});
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
testRunner.Given("The GetUserProfileExecutor has been created and initialized");
#line 17
testRunner.And("Sent UserName: \'OhAe\'");
#line 18
testRunner.When("Call GetUserProfileExecutor");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "UserName",
                        "Password",
                        "Email",
                        "CellPhone",
                        "Upline",
                        "Refundable",
                        "NonRefundable",
                        "Active"});
            table2.AddRow(new string[] {
                        "OhAe",
                        "1234",
                        "sirinarin@hotmail.com",
                        "0892165437",
                        "Nit",
                        "500",
                        "200",
                        "True"});
#line 19
testRunner.Then("User Profile information should be :", ((string)(null)), table2);
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบได้รับข้อมูล username ไม่ถูกต้อง ระบบไม่สามารถดึงข้อมูล user profile ของผู้เล" +
            "่นได้")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GetUserProfile")]
        public virtual void ระบบไดรบขอมลUsernameไมถกตองระบบไมสามารถดงขอมลUserProfileของผเลนได()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ระบบได้รับข้อมูล username ไม่ถูกต้อง ระบบไม่สามารถดึงข้อมูล user profile ของผู้เล" +
                    "่นได้", new string[] {
                        "record_mock"});
#line 24
this.ScenarioSetup(scenarioInfo);
#line 25
testRunner.Given("The GetUserProfileExecutor has been created and initialized");
#line 26
testRunner.And("Sent UserName: \'\'");
#line 27
testRunner.When("Call GetUserProfileExecutor");
#line 28
testRunner.Then("User Profile information should be null");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
