using System.Web.Mvc;

namespace sPerf_Web.Areas.KnowledgeCenter
{
    public class KnowledgeCenterAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "KnowledgeCenter";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "KnowledgeCenter_default",
                "KnowledgeCenter/{controller}/{action}",
                MVC.KnowledgeCenter.KnowledgeCenter.Index()
            );
        }
    }
}
