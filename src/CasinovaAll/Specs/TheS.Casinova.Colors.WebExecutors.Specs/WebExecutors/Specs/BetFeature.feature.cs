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
    public partial class BetFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "BetFeature.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Bet", "In order to bet colors game\r\nAs a system\r\nI want to sent bet information to back " +
                    "server", ((string[])(null)));
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
        
        public virtual void ระบบไดรบขอมลการลงเดมพนเกมในColorsของผเลนระบบทำการตรวจสอบขอมลเพอทำการGenereteTrackingIDและสงขอมลไปยงBckServerตอไป(string userName, string roundID, string actionType, string amount)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ระบบได้รับข้อมูลการลงเดิมพันเกมใน colors ของผู้เล่น ระบบทำการตรวจสอบข้อมูล เพื่อท" +
                    "ำการ generete trackingID และส่งข้อมูลไปยัง bck server ต่อไป", new string[] {
                        "record_mock"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
testRunner.Given("The BetColorsExecutor has been created and initialized");
#line 9
testRunner.When(string.Format("Call BetColorsExecutor(UserProfileBalance \'{0}\' GameRoundInfoRoundID \'{1}\', ActionType \'{2}\', Amount \'{3" +
                        "}\')", userName, roundID, actionType, amount));
#line 10
testRunner.Then("The system can generate trckingID for bet colors game");
#line 11
testRunner.Then("The system can\'t generate trackingID for bet colors game");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบได้รับข้อมูลการลงเดิมพันเกมใน colors ของผู้เล่น ระบบทำการตรวจสอบข้อมูล เพื่อท" +
            "ำการ generete trackingID และส่งข้อมูลไปยัง bck server ต่อไป")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Bet")]
        public virtual void ระบบไดรบขอมลการลงเดมพนเกมในColorsของผเลนระบบทำการตรวจสอบขอมลเพอทำการGenereteTrackingIDและสงขอมลไปยงBckServerตอไป_Variant0()
        {
            this.ระบบไดรบขอมลการลงเดมพนเกมในColorsของผเลนระบบทำการตรวจสอบขอมลเพอทำการGenereteTrackingIDและสงขอมลไปยงBckServerตอไป("Nit", "4", "White", "50");
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบได้รับข้อมูลการลงเดิมพันเกมใน colors ของผู้เล่น ระบบทำการตรวจสอบข้อมูล เพื่อท" +
            "ำการ generete trackingID และส่งข้อมูลไปยัง bck server ต่อไป")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Bet")]
        public virtual void ระบบไดรบขอมลการลงเดมพนเกมในColorsของผเลนระบบทำการตรวจสอบขอมลเพอทำการGenereteTrackingIDและสงขอมลไปยงBckServerตอไป_Variant1()
        {
            this.ระบบไดรบขอมลการลงเดมพนเกมในColorsของผเลนระบบทำการตรวจสอบขอมลเพอทำการGenereteTrackingIDและสงขอมลไปยงBckServerตอไป("Nit", "4", "White", "-50");
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบได้รับข้อมูลการลงเดิมพันเกมใน colors ของผู้เล่น ระบบทำการตรวจสอบข้อมูล เพื่อท" +
            "ำการ generete trackingID และส่งข้อมูลไปยัง bck server ต่อไป")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Bet")]
        public virtual void ระบบไดรบขอมลการลงเดมพนเกมในColorsของผเลนระบบทำการตรวจสอบขอมลเพอทำการGenereteTrackingIDและสงขอมลไปยงBckServerตอไป_Variant2()
        {
            this.ระบบไดรบขอมลการลงเดมพนเกมในColorsของผเลนระบบทำการตรวจสอบขอมลเพอทำการGenereteTrackingIDและสงขอมลไปยงBckServerตอไป("Nit", "4", "", "50");
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบได้รับข้อมูลการลงเดิมพันเกมใน colors ของผู้เล่น ระบบทำการตรวจสอบข้อมูล เพื่อท" +
            "ำการ generete trackingID และส่งข้อมูลไปยัง bck server ต่อไป")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Bet")]
        public virtual void ระบบไดรบขอมลการลงเดมพนเกมในColorsของผเลนระบบทำการตรวจสอบขอมลเพอทำการGenereteTrackingIDและสงขอมลไปยงBckServerตอไป_Variant3()
        {
            this.ระบบไดรบขอมลการลงเดมพนเกมในColorsของผเลนระบบทำการตรวจสอบขอมลเพอทำการGenereteTrackingIDและสงขอมลไปยงBckServerตอไป("Nit", "-2", "White", "50");
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ระบบได้รับข้อมูลการลงเดิมพันเกมใน colors ของผู้เล่น ระบบทำการตรวจสอบข้อมูล เพื่อท" +
            "ำการ generete trackingID และส่งข้อมูลไปยัง bck server ต่อไป")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Bet")]
        public virtual void ระบบไดรบขอมลการลงเดมพนเกมในColorsของผเลนระบบทำการตรวจสอบขอมลเพอทำการGenereteTrackingIDและสงขอมลไปยงBckServerตอไป_Variant4()
        {
            this.ระบบไดรบขอมลการลงเดมพนเกมในColorsของผเลนระบบทำการตรวจสอบขอมลเพอทำการGenereteTrackingIDและสงขอมลไปยงBckServerตอไป("", "4", "White", "50");
        }
    }
}
#endregion
