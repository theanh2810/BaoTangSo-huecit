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

namespace HueCIT.Modules.BaoTangSo.Services
{
    [System.Web.Http.AllowAnonymous]
    public class ChuyenMucAPIController : ApiController
    {
        GenericRepository<ChuyenMuc> repository = new GenericRepository<ChuyenMuc>();
        [System.Web.Http.HttpPost]
        public HttpResponseMessage ChuyenMucAdd(ChuyenMuc item)
        {
            try
            {
                Guid g = Guid.NewGuid();
                bool check = ChuyenMucDAL.ChuyenMucAdd(g, item.TenChuyenMuc, item.IDChuyenMucCha, item.MoTa, item.ThuTuHienThi);
                if (check == true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Thêm chuyên mục thành công!", "application/json");
                }
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Thêm chuyên mục lỗi!", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Thêm chuyên mục lỗi:" + ex.Message, "application/json");
            }

        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage ChuyenMucGetAll()
        {
            try
            {
                List<ChuyenMuc> List = ChuyenMucDAL.ChuyenMucGetAll();
                return Request.CreateResponse(HttpStatusCode.OK, List, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Lỗi :" + ex.Message, "application/json");
            }

        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage ChuyenMucGetByID(string IDChuyenMuc)
        {
            try
            {
                ChuyenMuc item = ChuyenMucDAL.ChuyenMucGetByID(IDChuyenMuc);
                return Request.CreateResponse(HttpStatusCode.OK, item, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Lỗi :" + ex.Message, "application/json");
            }

        }

        [System.Web.Http.HttpDelete]
        public HttpResponseMessage ChuyenMucDelete(Guid ID)
        {
            try
            {
                bool check = ChuyenMucDAL.ChuyenMucDelete(ID);
                if (check == true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Xóa thành công!", "application/json");
                }
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Xóa Lỗi. vui lòng thực hiện lại!", "application/json");

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Xóa Lỗi :" + ex.Message, "application/json");
            }

        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage ChuyenMucEdit(ChuyenMuc item)
        {
            try
            {
                bool check = ChuyenMucDAL.ChuyenMucEdit(item.ID, item.TenChuyenMuc, item.IDChuyenMucCha, item.MoTa, item.ThuTuHienThi);

                if (check == true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Sửa chuyên mục thành công!", "application/json");
                }
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Sửa chuyên mục lỗi!", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Sửa chuyên mục lỗi:" + ex.Message, "application/json");
            }

        }
    }
}
