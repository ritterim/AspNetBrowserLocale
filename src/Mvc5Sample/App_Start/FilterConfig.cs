using System.Web.Mvc;

namespace RimDev.AspNetBrowserLocale.Mvc5Sample
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}