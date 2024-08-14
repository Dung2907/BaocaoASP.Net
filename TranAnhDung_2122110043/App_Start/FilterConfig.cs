using System.Web;
using System.Web.Mvc;

namespace TranAnhDung_2122110043
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
