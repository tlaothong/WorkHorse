using System.Web.Mvc;

namespace sPerf_Web.Areas.Club
{
    public class ClubAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Club";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Club_default",
                "Club/{controller}/{action}",
                MVC.Club.Club.Index()
            );
        }
    }
}
