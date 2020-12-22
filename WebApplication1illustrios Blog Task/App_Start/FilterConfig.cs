using System.Web;
using System.Web.Mvc;

namespace WebApplication1illustrios_Blog_Task
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
