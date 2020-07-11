using System.Web.Mvc;

namespace CMS.UI.MVC.Areas.BusinessStructure
{
    public class BusinessStructureAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BusinessStructure";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BusinessStructure_default",
                "BusinessStructure/{controller}/{action}/{id}",
                new { action = "Index", controller = "Home" , id = UrlParameter.Optional }
            );
        }
    }
}