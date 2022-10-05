using System;
using System.Linq;
using System.Web.Mvc;
using HueCIT.Modules.BaoTangSo.Components;
using HueCIT.Modules.BaoTangSo.Models;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Entities.Users;
using DotNetNuke.Framework.JavaScriptLibraries;

namespace HueCIT.Modules.BaoTangSo.Controllers
{
    public class CauHoiController : DnnController
    {
        // GET: BaoVat
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ThemCauHoi()
        {
            return View();
        }

        public ActionResult SuaCauHoi()
        {
            return View();
        }
    }
}