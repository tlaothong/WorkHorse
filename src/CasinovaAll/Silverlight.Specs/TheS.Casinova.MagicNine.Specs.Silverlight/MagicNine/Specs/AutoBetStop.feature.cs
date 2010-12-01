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
namespace TheS.Casinova.MagicNine.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.3.5.2")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class N2NAutoBetStopFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "AutoBetStop.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "N2N Auto bet stop", @"1.Player click auto bet stop (Silverlight)
2.Sent auto bet stop to web server (Silverlight)
3.Generate trackingID and sent it back to client (Web Server)
4.Observer follow trackingID from lot (Silverlight)
5.Found trackingID change state autobet button to ""Start"" (Silverlight)", ((string[])(null)));
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
#line 8
#line 9
testRunner.Given("Create and initialize GamePlayViewModel and MagicNine game service");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "RoundID",
                        "WinnerPoint"});
            table1.AddRow(new string[] {
                        "20",
                        "9"});
            table1.AddRow(new string[] {
                        "21",
                        "99"});
            table1.AddRow(new string[] {
                        "22",
                        "999"});
            table1.AddRow(new string[] {
                        "23",
                        "9999"});
            table1.AddRow(new string[] {
                        "24",
                        "99999"});
            table1.AddRow(new string[] {
                        "25",
                        "999999"});
            table1.AddRow(new string[] {
                        "26",
                        "9999999"});
#line 10
testRunner.And("Back service have active game rounds are:", ((string)(null)), table1);
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "RoundID",
                        "UserName",
                        "BetOrder",
                        "BetDateTime"});
            table2.AddRow(new string[] {
                        "20",
                        "Sakul",
                        "72",
                        "2010-11-17 09:00:00"});
            table2.AddRow(new string[] {
                        "21",
                        "Sakul",
                        "11",
                        "2010-11-17 09:00:30"});
            table2.AddRow(new string[] {
                        "22",
                        "Sakul",
                        "91",
                        "2010-11-17 09:00:59"});
            table2.AddRow(new string[] {
                        "23",
                        "Sakul",
                        "0",
                        "2010-11-17 09:01:00"});
            table2.AddRow(new string[] {
                        "24",
                        "Miolynet",
                        "12",
                        "2010-11-17 10:11:00"});
            table2.AddRow(new string[] {
                        "25",
                        "Miolynet",
                        "13",
                        "2010-11-18 07:23:50"});
            table2.AddRow(new string[] {
                        "26",
                        "Miolynet",
                        "17",
                        "2010-11-18 07:23:50"});
#line 19
testRunner.And("Web server have list bet log are", ((string)(null)), table2);
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "TrackingID"});
            table3.AddRow(new string[] {
                        "{60AD85F6-3978-48AA-9286-E5A7344B77EC}"});
            table3.AddRow(new string[] {
                        "{A82FA8E6-1BCC-443E-A61A-F81B8B4DED83}"});
            table3.AddRow(new string[] {
                        "{CF24E43D-49FA-482B-9AD2-DCF0159F0C41}"});
            table3.AddRow(new string[] {
                        "{2C8EE9D1-A106-4216-AA57-E44554F822A8}"});
            table3.AddRow(new string[] {
                        "{89D5613E-8007-4AAA-8A4D-AF16014B2D5F}"});
            table3.AddRow(new string[] {
                        "{50EA817A-512E-469E-982F-8377F0EF84A6}"});
            table3.AddRow(new string[] {
                        "{37C87086-FFBB-4C9A-87F9-F9A4C0CF6FB0}"});
#line 28
testRunner.And("Setup web service trackingID for auto bet stop are", ((string)(null)), table3);
#line 37
testRunner.When("Send request GetListActiveGameRounds() to web server");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Request stop auto bet")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "N2N Auto bet stop")]
        [Microsoft.Silverlight.Testing.TagAttribute("record_mock")]
        public virtual void RequestStopAutoBet()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Request stop auto bet", new string[] {
                        "record_mock"});
#line 41
this.ScenarioSetup(scenarioInfo);
#line 42
testRunner.Given("Setup Amount=20 in game roundID=20");
#line 43
testRunner.When("I press AutoBetStop() in game roundID=20");
#line 44
testRunner.Then("PayLog has save RoundID=\'20\', Count=\'1\'");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "TrackingID"});
            table4.AddRow(new string[] {
                        "{60AD85F6-3978-48AA-9286-E5A7344B77EC}"});
#line 45
testRunner.And("Lot of TrackingIDs has Retrieved are", ((string)(null)), table4);
#line 48
testRunner.And("PayLog has empty");
#line 49
testRunner.And("IsAutoBetOn is false, in game roundID=20");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Request stop auto bet (request more than 1 )")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "N2N Auto bet stop")]
        [Microsoft.Silverlight.Testing.TagAttribute("record_mock")]
        public virtual void RequestStopAutoBetRequestMoreThan1()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Request stop auto bet (request more than 1 )", new string[] {
                        "record_mock"});
#line 52
this.ScenarioSetup(scenarioInfo);
#line 53
testRunner.Given("Setup Amount=20 in game roundID=20");
#line 54
testRunner.When("I press AutoBetStop() in game roundID=20");
#line 55
testRunner.And("I press AutoBetStop() in game roundID=20");
#line 56
testRunner.And("I press AutoBetStop() in game roundID=20");
#line 57
testRunner.And("I press AutoBetStop() in game roundID=20");
#line 58
testRunner.And("I press AutoBetStop() in game roundID=20");
#line 59
testRunner.And("I press AutoBetStop() in game roundID=20");
#line 60
testRunner.And("I press AutoBetStop() in game roundID=20");
#line 61
testRunner.Then("PayLog has save RoundID=\'20\', Count=\'7\'");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "TrackingID"});
            table5.AddRow(new string[] {
                        "{60AD85F6-3978-48AA-9286-E5A7344B77EC}"});
            table5.AddRow(new string[] {
                        "{A82FA8E6-1BCC-443E-A61A-F81B8B4DED83}"});
            table5.AddRow(new string[] {
                        "{CF24E43D-49FA-482B-9AD2-DCF0159F0C41}"});
            table5.AddRow(new string[] {
                        "{2C8EE9D1-A106-4216-AA57-E44554F822A8}"});
            table5.AddRow(new string[] {
                        "{89D5613E-8007-4AAA-8A4D-AF16014B2D5F}"});
            table5.AddRow(new string[] {
                        "{50EA817A-512E-469E-982F-8377F0EF84A6}"});
            table5.AddRow(new string[] {
                        "{37C87086-FFBB-4C9A-87F9-F9A4C0CF6FB0}"});
#line 62
testRunner.And("Lot of TrackingIDs has Retrieved are", ((string)(null)), table5);
#line 71
testRunner.And("PayLog has empty");
#line 72
testRunner.And("IsAutoBetOn is false, in game roundID=20");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Request stop auto bet (request more than 1 ) difference game roundID")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "N2N Auto bet stop")]
        [Microsoft.Silverlight.Testing.TagAttribute("record_mock")]
        public virtual void RequestStopAutoBetRequestMoreThan1DifferenceGameRoundID()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Request stop auto bet (request more than 1 ) difference game roundID", new string[] {
                        "record_mock"});
#line 75
this.ScenarioSetup(scenarioInfo);
#line 76
testRunner.Given("Setup Amount=20 in game roundID=20");
#line 77
testRunner.And("Setup Amount=20 in game roundID=21");
#line 78
testRunner.And("Setup Amount=20 in game roundID=22");
#line 79
testRunner.And("Setup Amount=20 in game roundID=23");
#line 80
testRunner.And("Setup Amount=20 in game roundID=24");
#line 81
testRunner.And("Setup Amount=20 in game roundID=25");
#line 82
testRunner.And("Setup Amount=20 in game roundID=26");
#line 83
testRunner.When("I press AutoBetStop() in game roundID=20");
#line 84
testRunner.And("I press AutoBetStop() in game roundID=21");
#line 85
testRunner.And("I press AutoBetStop() in game roundID=22");
#line 86
testRunner.And("I press AutoBetStop() in game roundID=23");
#line 87
testRunner.And("I press AutoBetStop() in game roundID=24");
#line 88
testRunner.And("I press AutoBetStop() in game roundID=25");
#line 89
testRunner.And("I press AutoBetStop() in game roundID=26");
#line 90
testRunner.Then("PayLog has save RoundID=\'20\', Count=\'1\'");
#line 91
testRunner.Then("PayLog has save RoundID=\'21\', Count=\'1\'");
#line 92
testRunner.Then("PayLog has save RoundID=\'22\', Count=\'1\'");
#line 93
testRunner.Then("PayLog has save RoundID=\'23\', Count=\'1\'");
#line 94
testRunner.Then("PayLog has save RoundID=\'24\', Count=\'1\'");
#line 95
testRunner.Then("PayLog has save RoundID=\'25\', Count=\'1\'");
#line 96
testRunner.Then("PayLog has save RoundID=\'26\', Count=\'1\'");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "TrackingID"});
            table6.AddRow(new string[] {
                        "{60AD85F6-3978-48AA-9286-E5A7344B77EC}"});
            table6.AddRow(new string[] {
                        "{A82FA8E6-1BCC-443E-A61A-F81B8B4DED83}"});
            table6.AddRow(new string[] {
                        "{CF24E43D-49FA-482B-9AD2-DCF0159F0C41}"});
            table6.AddRow(new string[] {
                        "{2C8EE9D1-A106-4216-AA57-E44554F822A8}"});
            table6.AddRow(new string[] {
                        "{89D5613E-8007-4AAA-8A4D-AF16014B2D5F}"});
            table6.AddRow(new string[] {
                        "{50EA817A-512E-469E-982F-8377F0EF84A6}"});
            table6.AddRow(new string[] {
                        "{37C87086-FFBB-4C9A-87F9-F9A4C0CF6FB0}"});
#line 97
testRunner.And("Lot of TrackingIDs has Retrieved are", ((string)(null)), table6);
#line 106
testRunner.And("PayLog has empty");
#line 107
testRunner.And("IsAutoBetOn is false, in game roundID=20");
#line 108
testRunner.And("IsAutoBetOn is false, in game roundID=21");
#line 109
testRunner.And("IsAutoBetOn is false, in game roundID=22");
#line 110
testRunner.And("IsAutoBetOn is false, in game roundID=23");
#line 111
testRunner.And("IsAutoBetOn is false, in game roundID=24");
#line 112
testRunner.And("IsAutoBetOn is false, in game roundID=25");
#line 113
testRunner.And("IsAutoBetOn is false, in game roundID=26");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Request stop auto bet, lot don\'t retrive all")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "N2N Auto bet stop")]
        [Microsoft.Silverlight.Testing.TagAttribute("record_mock")]
        public virtual void RequestStopAutoBetLotDonTRetriveAll()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Request stop auto bet, lot don\'t retrive all", new string[] {
                        "record_mock"});
#line 116
this.ScenarioSetup(scenarioInfo);
#line 117
testRunner.Given("Setup Amount=20 in game roundID=20");
#line 118
testRunner.When("I press AutoBetStop() in game roundID=20");
#line 119
testRunner.And("I press AutoBetStop() in game roundID=20");
#line 120
testRunner.And("I press AutoBetStop() in game roundID=20");
#line 121
testRunner.And("I press AutoBetStop() in game roundID=20");
#line 122
testRunner.And("I press AutoBetStop() in game roundID=20");
#line 123
testRunner.And("I press AutoBetStop() in game roundID=20");
#line 124
testRunner.And("I press AutoBetStop() in game roundID=20");
#line 125
testRunner.Then("PayLog has save RoundID=\'20\', Count=\'7\'");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "TrackingID"});
            table7.AddRow(new string[] {
                        "{60AD85F6-3978-48AA-9286-E5A7344B77EC}"});
            table7.AddRow(new string[] {
                        "{A82FA8E6-1BCC-443E-A61A-F81B8B4DED83}"});
            table7.AddRow(new string[] {
                        "{CF24E43D-49FA-482B-9AD2-DCF0159F0C41}"});
#line 126
testRunner.And("Lot of TrackingIDs has Retrieved are", ((string)(null)), table7);
#line 131
testRunner.And("PayLog has save RoundID=\'20\', Count=\'4\'");
#line 132
testRunner.And("IsAutoBetOn is false, in game roundID=20");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
