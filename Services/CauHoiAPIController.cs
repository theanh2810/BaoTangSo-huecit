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
    public class CauHoiAPIController : ApiController
    {
        GenericRepository<MauVat> repository = new GenericRepository<MauVat>();
        [System.Web.Http.HttpPost]
        public HttpResponseMessage CauHoiAdd(CauHoi item)
        {
            try
            {
                bool check = CauHoiDAL.CauHoiAdd(item.MaMauVat,item.MoTa,item.NoiDungCauHoi,item.ThuTuHienThi);
                if (check == true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Thêm mẫu vật thành công!", "application/json");
                }
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Thêm mẫu vật lỗi!", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Thêm mẫu vật lỗi:" + ex.Message, "application/json");
            }

        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage CauHoiGetAll()
        {
            try
            {
                List<CauHoi> list = CauHoiDAL.CauHoiGetAll();
                return Request.CreateResponse(HttpStatusCode.OK, list, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Lỗi :" + ex.Message, "application/json");
            }

        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage CauHoiGetMaxID()
        {
            try
            {
                int max = CauHoiDAL.CauHoiGetMaxID();
                return Request.CreateResponse(HttpStatusCode.OK, max, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Lỗi :" + ex.Message, "application/json");
            }

        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage CauHoiGetByMauVat(string IDMauVat)
        {
            try
            {
                List<CauHoi> List = CauHoiDAL.CauHoiGetByMauVat(IDMauVat);
                return Request.CreateResponse(HttpStatusCode.OK, List, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Lỗi :" + ex.Message, "application/json");
            }

        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage CauHoiGetByID(int ID)
        {
            try
            {
                CauHoi item = CauHoiDAL.CauHoiGetByID(ID);
                return Request.CreateResponse(HttpStatusCode.OK, item, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Lỗi :" + ex.Message, "application/json");
            }

        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage CauHoiEdit(CauHoi item)
        {
            try
            {
                bool check = CauHoiDAL.CauHoiEdit(item.ID, item.MoTa, item.NoiDungCauHoi, item.ThuTuHienThi);
                if (check == true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Sửa câu hỏi thành công!", "application/json");
                }
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Sửa câu hỏi lỗi!", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Sửa câu hỏi lỗi:" + ex.Message, "application/json");
            }

        }

        [System.Web.Http.HttpDelete]
        public HttpResponseMessage CauHoiDelete(int ID)
        {
            try
            {
                bool check = CauHoiDAL.CauHoiDelete(ID);
                if (check == true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Xóa câu hỏi thành công!", "application/json");
                }
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Xóa câu hỏi lỗi!", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Xóa câu hỏi lỗi:" + ex.Message, "application/json");
            }

        }
    }
}
