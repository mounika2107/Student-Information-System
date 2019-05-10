using System.Web;
using System.Web.Mvc;

namespace S2G5_SISAPPLICATION
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
