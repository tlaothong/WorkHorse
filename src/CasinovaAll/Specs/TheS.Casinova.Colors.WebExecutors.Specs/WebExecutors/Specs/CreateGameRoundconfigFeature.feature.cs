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
namespace TheS.Casinova.Colors.WebExecutors.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.3.5.2")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CreateGameRoundConfigurationFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CreateGameRoundconfigFeature.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CreateGameRoundConfiguration", "In order to sent game round configurations\r\nAs a system\r\nI want to sent game roun" +
                    "d configurations to create", ((string[])(null)));
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[CreateGameRoundConfig]ระบบได้รับข้อมูล GameRoundConfigurations ระบบทำการตรวจสอบข" +
            "้อมูล ข้อมูลถูกต้อง ระบบสามารถส่งข้อมูลไป BackServer ได้")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CreateGameRoundConfiguration")]
        public virtual void CreateGameRoundConfigระบบไดรบขอมลGameRoundConfigurationsระบบทำการตรวจสอบขอมลขอมลถกตองระบบสามารถสงขอมลไปBackServerได()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[CreateGameRoundConfig]ระบบได้รับข้อมูล GameRoundConfigurations ระบบทำการตรวจสอบข" +
                    "้อมูล ข้อมูลถูกต้อง ระบบสามารถส่งข้อมูลไป BackServer ได้", new string[] {
                        "record_mock"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
testRunner.Given("The CreateGameRoundConfigExecutor has been created and initialized");
#line 9
testRunner.And("System can sent game round configuration informations are : ConfigName\'ColorsGame" +
                    "\',TableAmount\'5\', GameDuration\'30\', Interval\'10\', BufferRoundCount\'3\'");
#line 10
testRunner.When("System can call CreateGameRoundConfigExecutor()");
#line 11
testRunner.Then("The system can sent GameRoundConfigurations to back server");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[CreateGameRoundConfig]ระบบได้รับข้อมูล GameRoundConfigurations ระบบทำการตรวจสอบข" +
            "้อมูล ข้อมูล Name ไม่ถูกต้อง ระบบไม่สามารถส่งข้อมูลไป BackServer ได้")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CreateGameRoundConfiguration")]
        public virtual void CreateGameRoundConfigระบบไดรบขอมลGameRoundConfigurationsระบบทำการตรวจสอบขอมลขอมลNameไมถกตองระบบไมสามารถสงขอมลไปBackServerได()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[CreateGameRoundConfig]ระบบได้รับข้อมูล GameRoundConfigurations ระบบทำการตรวจสอบข" +
                    "้อมูล ข้อมูล Name ไม่ถูกต้อง ระบบไม่สามารถส่งข้อมูลไป BackServer ได้", new string[] {
                        "record_mock"});
#line 14
this.ScenarioSetup(scenarioInfo);
#line 15
testRunner.Given("The CreateGameRoundConfigExecutor has been created and initialized");
#line 16
testRunner.And("Game round configuration informations are : ConfigName\'no\',TableAmount\'5\', GameDu" +
                    "ration\'30\', Interval\'10\', BufferRoundCount\'3\'");
#line 17
testRunner.When("Call CreateGameRoundConfigExecutor()");
#line 18
testRunner.Then("The system can\'t sent GameRoundConfigurations to back server");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[CreateGameRoundConfig]ระบบได้รับข้อมูล GameRoundConfigurations ระบบทำการตรวจสอบข" +
            "้อมูล ไม่มีข้อมูล Name ระบบไม่สามารถส่งข้อมูลไป BackServer ได้")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CreateGameRoundConfiguration")]
        public virtual void CreateGameRoundConfigระบบไดรบขอมลGameRoundConfigurationsระบบทำการตรวจสอบขอมลไมมขอมลNameระบบไมสามารถสงขอมลไปBackServerได()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[CreateGameRoundConfig]ระบบได้รับข้อมูล GameRoundConfigurations ระบบทำการตรวจสอบข" +
                    "้อมูล ไม่มีข้อมูล Name ระบบไม่สามารถส่งข้อมูลไป BackServer ได้", new string[] {
                        "record_mock"});
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
testRunner.Given("The CreateGameRoundConfigExecutor has been created and initialized");
#line 23
testRunner.And("Game round configuration informations are : ConfigName\'\',TableAmount\'5\', GameDura" +
                    "tion\'30\', Interval\'10\', BufferRoundCount\'3\'");
#line 24
testRunner.When("Call CreateGameRoundConfigExecutor()");
#line 25
testRunner.Then("The system can\'t sent GameRoundConfigurations to back server");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[CreateGameRoundConfig]ระบบได้รับข้อมูล GameRoundConfigurations ระบบทำการตรวจสอบข" +
            "้อมูล ข้อมูล TableAmount ไม่ถูกต้อง ระบบไม่สามารถส่งข้อมูลไป BackServer ได้")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CreateGameRoundConfiguration")]
        public virtual void CreateGameRoundConfigระบบไดรบขอมลGameRoundConfigurationsระบบทำการตรวจสอบขอมลขอมลTableAmountไมถกตองระบบไมสามารถสงขอมลไปBackServerได()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[CreateGameRoundConfig]ระบบได้รับข้อมูล GameRoundConfigurations ระบบทำการตรวจสอบข" +
                    "้อมูล ข้อมูล TableAmount ไม่ถูกต้อง ระบบไม่สามารถส่งข้อมูลไป BackServer ได้", new string[] {
                        "record_mock"});
#line 28
this.ScenarioSetup(scenarioInfo);
#line 29
testRunner.Given("The CreateGameRoundConfigExecutor has been created and initialized");
#line 30
testRunner.And("Game round configuration informations are : ConfigName\'ColorsGame1\',TableAmount\'-" +
                    "2\', GameDuration\'30\', Interval\'10\', BufferRoundCount\'3\'");
#line 31
testRunner.When("Call CreateGameRoundConfigExecutor()");
#line 32
testRunner.Then("The system can\'t sent GameRoundConfigurations to back server");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[CreateGameRoundConfig]ระบบได้รับข้อมูล GameRoundConfigurations ระบบทำการตรวจสอบข" +
            "้อมูล ข้อมูล GameDuration ไม่ถูกต้อง ระบบไม่สามารถส่งข้อมูลไป BackServer ได้")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CreateGameRoundConfiguration")]
        public virtual void CreateGameRoundConfigระบบไดรบขอมลGameRoundConfigurationsระบบทำการตรวจสอบขอมลขอมลGameDurationไมถกตองระบบไมสามารถสงขอมลไปBackServerได()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[CreateGameRoundConfig]ระบบได้รับข้อมูล GameRoundConfigurations ระบบทำการตรวจสอบข" +
                    "้อมูล ข้อมูล GameDuration ไม่ถูกต้อง ระบบไม่สามารถส่งข้อมูลไป BackServer ได้", new string[] {
                        "record_mock"});
#line 35
this.ScenarioSetup(scenarioInfo);
#line 36
testRunner.Given("The CreateGameRoundConfigExecutor has been created and initialized");
#line 37
testRunner.And("Game round configuration informations are : ConfigName\'ColorsGame1\',TableAmount\'5" +
                    "\', GameDuration\'1550\', Interval\'10\', BufferRoundCount\'3\'");
#line 38
testRunner.When("Call CreateGameRoundConfigExecutor()");
#line 39
testRunner.Then("The system can\'t sent GameRoundConfigurations to back server");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[CreateGameRoundConfig]ระบบได้รับข้อมูล GameRoundConfigurations ระบบทำการตรวจสอบข" +
            "้อมูล ข้อมูล Interval ไม่ถูกต้อง ระบบไม่สามารถส่งข้อมูลไป BackServer ได้")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CreateGameRoundConfiguration")]
        public virtual void CreateGameRoundConfigระบบไดรบขอมลGameRoundConfigurationsระบบทำการตรวจสอบขอมลขอมลIntervalไมถกตองระบบไมสามารถสงขอมลไปBackServerได()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[CreateGameRoundConfig]ระบบได้รับข้อมูล GameRoundConfigurations ระบบทำการตรวจสอบข" +
                    "้อมูล ข้อมูล Interval ไม่ถูกต้อง ระบบไม่สามารถส่งข้อมูลไป BackServer ได้", new string[] {
                        "record_mock"});
#line 42
this.ScenarioSetup(scenarioInfo);
#line 43
testRunner.Given("The CreateGameRoundConfigExecutor has been created and initialized");
#line 44
testRunner.And("Game round configuration informations are : ConfigName\'ColorsGame1\',TableAmount\'5" +
                    "\', GameDuration\'30\', Interval\'-30\', BufferRoundCount\'3\'");
#line 45
testRunner.When("Call CreateGameRoundConfigExecutor()");
#line 46
testRunner.Then("The system can\'t sent GameRoundConfigurations to back server");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[CreateGameRoundConfig]ระบบได้รับข้อมูล GameRoundConfigurations ระบบทำการตรวจสอบข" +
            "้อมูล ข้อมูล BufferRoundCount ไม่ถูกต้อง ระบบไม่สามารถส่งข้อมูลไป BackServer ได้" +
            "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CreateGameRoundConfiguration")]
        public virtual void CreateGameRoundConfigระบบไดรบขอมลGameRoundConfigurationsระบบทำการตรวจสอบขอมลขอมลBufferRoundCountไมถกตองระบบไมสามารถสงขอมลไปBackServerได()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[CreateGameRoundConfig]ระบบได้รับข้อมูล GameRoundConfigurations ระบบทำการตรวจสอบข" +
                    "้อมูล ข้อมูล BufferRoundCount ไม่ถูกต้อง ระบบไม่สามารถส่งข้อมูลไป BackServer ได้" +
                    "", new string[] {
                        "record_mock"});
#line 49
this.ScenarioSetup(scenarioInfo);
#line 50
testRunner.Given("The CreateGameRoundConfigExecutor has been created and initialized");
#line 51
testRunner.And("Game round configuration informations are : ConfigName\'ColorsGame1\',TableAmount\'5" +
                    "\', GameDuration\'30\', Interval\'10\', BufferRoundCount\'-3\'");
#line 52
testRunner.When("Call CreateGameRoundConfigExecutor()");
#line 53
testRunner.Then("The system can\'t sent GameRoundConfigurations to back server");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
