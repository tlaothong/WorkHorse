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
namespace TheS.Casinova.PlayerProfile.BackServices.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.3.5.2")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class ChangeEmailFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ChangeEmail.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ChangeEmail", "In order to change e-mail\r\nAs a back server\r\nI want to be update new e-mail", ((string[])(null)));
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ได้รับรหัส E-mail ที่ต้องการเปลี่ยน, ระบบเปลี่ยนแปลงรหัส E-mail ของผู้เล่นในระบบ")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ChangeEmail")]
        public virtual void ไดรบรหสE_MailทตองการเปลยนระบบเปลยนแปลงรหสE_Mailของผเลนในระบบ()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ได้รับรหัส E-mail ที่ต้องการเปลี่ยน, ระบบเปลี่ยนแปลงรหัส E-mail ของผู้เล่นในระบบ", new string[] {
                        "record_mock"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
testRunner.Given("The ChangeEmail has been created and initialized");
#line 9
testRunner.And("the user profile should be update(UserName: \'OhAe\', E-mail: \'def@def.com\')");
#line 10
testRunner.When("call ChangeEmailExecutor(UserName: \'OhAe\', E-mail: \'def@def.com\')");
#line 11
testRunner.Then("the result should be update");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
