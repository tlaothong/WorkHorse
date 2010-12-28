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
    public partial class ChangePassWordFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ChangePasswordFeature.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ChangePassWord", "In order to change password\r\nAs a system\r\nI want to change new password", ((string[])(null)));
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
        
        public virtual void ChangePasswordระบบไดรบขอมลรหสผานใหมจากผเลนระบบทำการตรวจสอบขอมลขอมลไมถกตองระบบไมสามารถเปลยนPasswordใหมได(string userName, string oldPassWord, string newPassword)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[ChangePassword]ระบบได้รับข้อมูลรหัสผ่านใหม่จากผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อ" +
                    "มูลไม่ถูกต้อง ระบบไม่สามารถเปลี่ยน password ใหม่ได้", new string[] {
                        "record_mock"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
testRunner.Given("The ChangePasswordExecutor has been created and initialized");
#line 9
testRunner.And(string.Format("Sent UserName \'{0}\' OldPassword \'{1}\' NewPassword \'{2}\'", userName, oldPassWord, newPassword));
#line 10
testRunner.When("Call ChangePasswordExecutor() for validation input");
#line 11
testRunner.Then("Skip call membership service to change new password");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[ChangePassword]ระบบได้รับข้อมูลรหัสผ่านใหม่จากผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อ" +
            "มูลไม่ถูกต้อง ระบบไม่สามารถเปลี่ยน password ใหม่ได้")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ChangePassWord")]
        public virtual void ChangePasswordระบบไดรบขอมลรหสผานใหมจากผเลนระบบทำการตรวจสอบขอมลขอมลไมถกตองระบบไมสามารถเปลยนPasswordใหมได_Variant0()
        {
            this.ChangePasswordระบบไดรบขอมลรหสผานใหมจากผเลนระบบทำการตรวจสอบขอมลขอมลไมถกตองระบบไมสามารถเปลยนPasswordใหมได("Nit", "1311", "538956");
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[ChangePassword]ระบบได้รับข้อมูลรหัสผ่านใหม่จากผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อ" +
            "มูลไม่ถูกต้อง ระบบไม่สามารถเปลี่ยน password ใหม่ได้")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ChangePassWord")]
        public virtual void ChangePasswordระบบไดรบขอมลรหสผานใหมจากผเลนระบบทำการตรวจสอบขอมลขอมลไมถกตองระบบไมสามารถเปลยนPasswordใหมได_Variant1()
        {
            this.ChangePasswordระบบไดรบขอมลรหสผานใหมจากผเลนระบบทำการตรวจสอบขอมลขอมลไมถกตองระบบไมสามารถเปลยนPasswordใหมได("Nit", "131144", "1234");
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[ChangePassword]ระบบได้รับข้อมูลรหัสผ่านใหม่จากผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อ" +
            "มูลไม่ถูกต้อง ระบบไม่สามารถเปลี่ยน password ใหม่ได้")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ChangePassWord")]
        public virtual void ChangePasswordระบบไดรบขอมลรหสผานใหมจากผเลนระบบทำการตรวจสอบขอมลขอมลไมถกตองระบบไมสามารถเปลยนPasswordใหมได_Variant2()
        {
            this.ChangePasswordระบบไดรบขอมลรหสผานใหมจากผเลนระบบทำการตรวจสอบขอมลขอมลไมถกตองระบบไมสามารถเปลยนPasswordใหมได("", "131154", "538956");
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[ChangePassword]ระบบได้รับข้อมูลรหัสผ่านใหม่จากผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อ" +
            "มูลไม่ถูกต้อง ระบบไม่สามารถเปลี่ยน password ใหม่ได้")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ChangePassWord")]
        public virtual void ChangePasswordระบบไดรบขอมลรหสผานใหมจากผเลนระบบทำการตรวจสอบขอมลขอมลไมถกตองระบบไมสามารถเปลยนPasswordใหมได_Variant3()
        {
            this.ChangePasswordระบบไดรบขอมลรหสผานใหมจากผเลนระบบทำการตรวจสอบขอมลขอมลไมถกตองระบบไมสามารถเปลยนPasswordใหมได("Nit", "130055", "");
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[ChangePassword]ระบบได้รับข้อมูลรหัสผ่านใหม่จากผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อ" +
            "มูลไม่ถูกต้อง ระบบไม่สามารถเปลี่ยน password ใหม่ได้")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ChangePassWord")]
        public virtual void ChangePasswordระบบไดรบขอมลรหสผานใหมจากผเลนระบบทำการตรวจสอบขอมลขอมลไมถกตองระบบไมสามารถเปลยนPasswordใหมได_Variant4()
        {
            this.ChangePasswordระบบไดรบขอมลรหสผานใหมจากผเลนระบบทำการตรวจสอบขอมลขอมลไมถกตองระบบไมสามารถเปลยนPasswordใหมได("Nit", "12345678901234567", "53895");
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[ChangePassword]ระบบได้รับข้อมูลรหัสผ่านใหม่จากผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อ" +
            "มูลถูกต้อง ระบบสามารถเปลี่ยน password ใหม่ได้")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ChangePassWord")]
        public virtual void ChangePasswordระบบไดรบขอมลรหสผานใหมจากผเลนระบบทำการตรวจสอบขอมลขอมลถกตองระบบสามารถเปลยนPasswordใหมได()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[ChangePassword]ระบบได้รับข้อมูลรหัสผ่านใหม่จากผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อ" +
                    "มูลถูกต้อง ระบบสามารถเปลี่ยน password ใหม่ได้", new string[] {
                        "record_mock"});
#line 23
this.ScenarioSetup(scenarioInfo);
#line 24
testRunner.Given("The ChangePasswordExecutor has been created and initialized");
#line 25
testRunner.And("Sent UserName \'Nayit\' OldPassword \'123br4\' NewPassword \'nit4532\'");
#line 26
testRunner.And("Call membership service to validate change password information : UserName \'Nayit" +
                    "\' OldPassword \'123br4\' NewPassword \'nit4532\'");
#line 27
testRunner.When("Call ChangePasswordExecutor()");
#line 28
testRunner.Then("Membership service can change new password");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
