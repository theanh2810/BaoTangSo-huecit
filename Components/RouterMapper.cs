using DotNetNuke.Web.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Http;

namespace HueCIT.Modules.BaoTangSo.Components
{
    public class RouterMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute(
            "BaoTangSo",
            "default",
            "{controller}/{action}",
            new[] { "HueCIT.Modules.BaoTangSo.Services" });
        }
    }
}