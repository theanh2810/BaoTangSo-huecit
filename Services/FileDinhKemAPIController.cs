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
    public class FileDinhKemAPIController : ApiController
    {
        GenericRepository<MauVat> repository = new GenericRepository<MauVat>();
        [System.Web.Http.HttpPost]
        public HttpResponseMessage FileDinhKemAdd(FileDinhKem item)
        {
            try
            {
                Guid id = Guid.NewGuid();

                bool check = FileDinhKemDAL.FileDinhKemAdd(id,item.MaMauVat,item.TenTep,item.MoTa,item.ViTriLuuTru,item.LoaiFile,item.AnhDaiDien);
                if (check == true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, id, "application/json");
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
        public HttpResponseMessage FileDinhKemGetByID(string ID)
        {
            try
            {
                FileDinhKem item = FileDinhKemDAL.FileDinhKemGetByID(ID);
                return Request.CreateResponse(HttpStatusCode.OK, item, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Lỗi :" + ex.Message, "application/json");
            }

        }

        [System.Web.Http.HttpDelete]
        public HttpResponseMessage FileDinhKemDelete(Guid ID)
        {
            try
            {
                bool check = FileDinhKemDAL.FileDinhKemDelete(ID);
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
    }
}
