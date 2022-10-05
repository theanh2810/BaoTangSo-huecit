using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using HueCIT.Modules.BaoTangSo.Services;
using HueCIT.Modules.BaoTangSo.Models;
using HueCIT.MVC.ChuyenMucDAL;
using HueCIT.MVC.GenericDAL;
using System.Net.Http;
using System.Web.Http;
using System.IO;

namespace HueCIT.Modules.BaoTangSo.Services
{
    [System.Web.Http.AllowAnonymous]
    public class DapAnAPIController : ApiController
    {
        GenericRepository<MauVat> repository = new GenericRepository<MauVat>();
        [System.Web.Http.HttpPost]
        public HttpResponseMessage DapAnAdd(Answer item)
        {
            try
            {
                bool check = DapAnDAL.DapAnAdd(item.MaCauHoi,item.MaMauVat,item.DapAn,item.CauHoiDung,item.GhiChu);
                if (check == true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Thêm đáp án thành công!", "application/json");
                }
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Thêm đáp án lỗi!", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Thêm đáp án lỗi:" + ex.Message, "application/json");
            }

        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage DapAnGetByCauHoi(int MaCauHoi)
        {
            try
            {
                List<Answer> List = DapAnDAL.DapAnGetByCauHoi(MaCauHoi);
                return Request.CreateResponse(HttpStatusCode.OK, List, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Lỗi :" + ex.Message, "application/json");
            }

        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage DapAnEdit(Answer item)
        {
            try
            {
                bool check = DapAnDAL.DapAnEdit(item.ID, item.DapAn, item.CauHoiDung, item.GhiChu);
                if (check == true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Sửa đáp án thành công!", "application/json");
                }
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Sửa đáp án lỗi!", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Sửa đáp án lỗi:" + ex.Message, "application/json");
            }

        }


    }
}
