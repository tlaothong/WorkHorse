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
namespace PerfEx.Demo.SimpleGame.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.3.5.2")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class N2NSaveTableConfigurationToTheDataStoreFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SaveTableConfiguration_N2N.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "N2N Save Table Configuration to the data store", "In order to use the table configuration again and again\r\nAs an Administrator\r\nI w" +
                    "ant to save the table configuration to the persistence store", ((string[])(null)));
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Save GameTable configuration to the data store")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "N2N Save Table Configuration to the data store")]
        public virtual void SaveGameTableConfigurationToTheDataStore()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Save GameTable configuration to the data store", new string[] {
                        "record_mock"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
testRunner.Given("The GameTableConfigurator has been created and initialized");
#line 9
testRunner.And("Expect the tables should be saved by calling ICreateGameTableConfiguration.Create" +
                    "()");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "GameDuration",
                        "Interval"});
            table1.AddRow(new string[] {
                        "20",
                        "5"});
            table1.AddRow(new string[] {
                        "20",
                        "5"});
            table1.AddRow(new string[] {
                        "20",
                        "5"});
            table1.AddRow(new string[] {
                        "20",
                        "5"});
#line 10
testRunner.When("call SaveTableConfiguration(name: \'config1\', tables: as follows)", ((string)(null)), table1);
#line 16
testRunner.Then("the tables should be saved by calling ICreateGameTableConfiguration.Create()");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion