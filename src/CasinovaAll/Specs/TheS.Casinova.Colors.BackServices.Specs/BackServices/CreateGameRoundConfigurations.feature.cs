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
    public partial class CreateGameRoundConfigurationsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CreateGameRoundConfigurations.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CreateGameRoundConfigurations", "In order to create game round configurations\r\nAs a back server\r\nI want to be crea" +
                    "te game round configuraions", ((string[])(null)));
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ได้รับข้อมูล GameRoundConfigurations, ระบบบันทึกข้อมูลการตั้งค่า")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CreateGameRoundConfigurations")]
        public virtual void ไดรบขอมลGameRoundConfigurationsระบบบนทกขอมลการตงคา()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ได้รับข้อมูล GameRoundConfigurations, ระบบบันทึกข้อมูลการตั้งค่า", new string[] {
                        "record_mock"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
testRunner.Given("The CreateGameRoundConfigurationsExecutor has been created and initialized");
#line 9
testRunner.And("Expect result should be add GameRoundConfiguration(Name: \'config1\', TableAmount: " +
                    "\'4\', GameDuration: \'30\', Interval: \'5\')");
#line 10
testRunner.When("call CreateGameRoundConfiguration(GameRoundConfiguration(Name: \'config1\', TableAm" +
                    "ount: \'4\', GameDuration: \'30\', Interval: \'5\'))");
#line 11
testRunner.Then("the GameRoundConfiguration should be saved to the ICreateGameRoundConfigurations." +
                    "Create(GameRoundConfiguration, CreateGameRoundConfigurationCommand) with expect" +
                    "ed data");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
