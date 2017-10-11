using System.Web;
using System.Web.Mvc;

namespace NxtPort.Sample.MVC.CallApiHybridFlow
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
