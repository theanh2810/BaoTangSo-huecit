using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HueCIT.Modules.BaoTangSo.Models;
using HueCIT.MVC.ChuyenMucDAL;

namespace HueCIT.Modules.BaoTangSo.Services
{
    [AllowAnonymous]
    public class TestAPIController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage ChuyenMucGetAll()
        {
            try
            {
                List<test> List = ChuyenMucDAL.ChuyenMucGetAll1();
                return Request.CreateResponse(HttpStatusCode.OK, List, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Lỗi :" + ex.Message, "application/json");
            }

        }
    }
}
