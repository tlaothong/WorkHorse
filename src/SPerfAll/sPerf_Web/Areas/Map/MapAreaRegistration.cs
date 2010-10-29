using System.Web.Mvc;

namespace sPerf_Web.Areas.Map
{
    public class MapAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Map"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Map_default",
                "Map/{controller}/{action}",
                MVC.Map.Map.Index()
            );
        }
    }
}