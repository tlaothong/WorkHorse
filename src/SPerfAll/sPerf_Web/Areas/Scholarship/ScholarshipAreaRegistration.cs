using System.Web.Mvc;

namespace sPerf_Web.Areas.Scholarship
{
    public class ScholarshipAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Scholarship"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Scholarship_default",
                "Scholarship/{controller}/{action}",
                MVC.Scholarship.Scholarship.Index()
            );
        }
    }
}