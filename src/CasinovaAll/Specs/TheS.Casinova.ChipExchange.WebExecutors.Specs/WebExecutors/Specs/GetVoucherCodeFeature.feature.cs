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
namespace TheS.Casinova.ChipExchange.WebExecutors.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.3.5.2")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class GetVoucherCodeFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GetVoucherCodeFeature.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "GetVoucherCode", "In order to get voucher code\r\nAs a system\r\nI want to get voucher code", ((string[])(null)));
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
                        "VoucherCode",
                        "Amount",
                        "CanUse"});
            table1.AddRow(new string[] {
                        "OhAe",
                        "630041228BAD10C2",
                        "500",
                        "True"});
            table1.AddRow(new string[] {
                        "Boy",
                        "128031228BF210E4",
                        "300",
                        "True"});
            table1.AddRow(new string[] {
                        "Nit",
                        "448021228C7A10D3",
                        "200",
                        "True"});
#line 8
testRunner.Given("Server has voucher information for get voucher code :", ((string)(null)), table1);
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[GetVoucherCode]ระบบได้รับข้อมูล userName ถูกต้อง ระบบสามารถดึงข้อมูลคูปองได้")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GetVoucherCode")]
        public virtual void GetVoucherCodeระบบไดรบขอมลUserNameถกตองระบบสามารถดงขอมลคปองได()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[GetVoucherCode]ระบบได้รับข้อมูล userName ถูกต้อง ระบบสามารถดึงข้อมูลคูปองได้", new string[] {
                        "record_mock",
                        "record_mock"});
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
testRunner.Given("The GetVoucherCodeExecutor has been created and initialized");
#line 17
testRunner.And("Sent UserName \'Boy\' for get voucher code");
#line 18
testRunner.When("Call GetVoucherCodeExecutor()");
#line 19
testRunner.Then("The result should be Username\'Boy\' VoucherCode \'128031228BF210E4\' Amount \'300\'");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[GetVoucherCode]ระบบได้รับข้อมูล userName ที่ไม่มีใน server ระบบได้ข้อมูลคูปองเป็" +
            "น null")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GetVoucherCode")]
        public virtual void GetVoucherCodeระบบไดรบขอมลUserNameทไมมในServerระบบไดขอมลคปองเปนNull()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[GetVoucherCode]ระบบได้รับข้อมูล userName ที่ไม่มีใน server ระบบได้ข้อมูลคูปองเป็" +
                    "น null", new string[] {
                        "record_mock"});
#line 22
this.ScenarioSetup(scenarioInfo);
#line 23
testRunner.Given("The GetVoucherCodeExecutor has been created and initialized");
#line 24
testRunner.And("Sent UserName \'Noy\' for get voucher code");
#line 25
testRunner.When("Call GetVoucherCodeExecutor()");
#line 26
testRunner.Then("VoucherCode should be null");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[GetVoucherCode]ระบบไม่ได้รับข้อมูล userName ระบบไม่สามารถดึงข้อมูลรหัสคูปองได้")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GetVoucherCode")]
        public virtual void GetVoucherCodeระบบไมไดรบขอมลUserNameระบบไมสามารถดงขอมลรหสคปองได()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[GetVoucherCode]ระบบไม่ได้รับข้อมูล userName ระบบไม่สามารถดึงข้อมูลรหัสคูปองได้", new string[] {
                        "record_mock"});
#line 29
this.ScenarioSetup(scenarioInfo);
#line 30
testRunner.Given("The GetVoucherCodeExecutor has been created and initialized");
#line 31
testRunner.And("Sent UserName \'\' for validation");
#line 32
testRunner.When("Call GetVoucherCodeExecutor() for validate input");
#line 33
testRunner.Then("VoucherCode should be throw exception");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
