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
    public class MauVatAPIController : ApiController
    {
        GenericRepository<MauVat> repository = new GenericRepository<MauVat>();
        [System.Web.Http.HttpPost]
        public HttpResponseMessage MauVatAdd(MauVat item)
        {
            try
            {
                bool check = MauVatDAL.MauVatAdd(item.IDMauVat,item.TenMauVat,item.IDChuyenMuc,item.TenKhoaHoc,item.TenGoiKhac,item.Ho,item.DacDiemNhanDang,item.TinhTrangBaoTon,item.DiaDiemSuuTam,item.ChatLieu,
                    item.KichThuocTrongLuong,item.NienDai,item.PhanBo,item.ViTriTinhChatSuDung,item.DonViTraoTang,item.HinhAnhTaiVe,item.HinhAnhTieuBan,item.Video,item.HinhAnh3D,item.BaiNghienCuu,item.TaiLieu,
                    item.Sach,item.AnhPhanBo,item.FileThuyetMinh,item.AnhDaiDien,item.NoiDungThuyetMinh);
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

        [System.Web.Http.HttpPost]
        public HttpResponseMessage MauVatUpdate(Guid ID, string Sach, string BaiNghienCuu, string TaiLieu)
        {
            try
            {
                bool check = MauVatDAL.MauVatUpdate(ID,Sach,BaiNghienCuu,TaiLieu);
                if (check == true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Update thanh cong", "application/json");
                }
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Thêm mẫu vật lỗi!", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Thêm mẫu vật lỗi:" + ex.Message, "application/json");
            }

        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage MauVatUpdateVideo(Guid IDMauVat, string ListVideo)
        {
            try
            {
                bool check = MauVatDAL.MauVatUpdateVideo(IDMauVat, ListVideo);
                if (check == true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Sửa thành công", "application/json");
                }
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Sửa mẫu vật lỗi!", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Sửa mẫu vật lỗi:" + ex.Message, "application/json");
            }

        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage MauVatUpdateHinhAnhTaiVe(Guid ID, string List)
        {
            try
            {
                bool check = MauVatDAL.MauVatUpdateHinhAnhTaiVe(ID, List);
                if (check == true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Sửa thành công", "application/json");
                }
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Sửa mẫu vật lỗi!", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Sửa mẫu vật lỗi:" + ex.Message, "application/json");
            }

        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage MauVatUpdateHinhAnhTieuBan(Guid ID, string List)
        {
            try
            {
                bool check = MauVatDAL.MauVatUpdateHinhAnhTieuBan(ID, List);
                if (check == true)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Sửa thành công", "application/json");
                }
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Sửa mẫu vật lỗi!", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Sửa mẫu vật lỗi:" + ex.Message, "application/json");
            }

        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage MauVatGetAll()
        {
            try
            {
                List<MauVat> List = MauVatDAL.MauVatGetAll();
                return Request.CreateResponse(HttpStatusCode.OK, List, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Lỗi :" + ex.Message, "application/json");
            }

        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage MauVatGetByChuyenMuc(string IDChuyenMuc)
        {
            try
            {
                List<MauVat> List = MauVatDAL.MauVatGetByChuyenMuc(IDChuyenMuc);
                return Request.CreateResponse(HttpStatusCode.OK, List, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Lỗi :" + ex.Message, "application/json");
            }

        }



        [System.Web.Http.HttpPost]
        public HttpResponseMessage FileUpload(string TenMauVat)
        {
            try
            {
                var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
                string web_dir = "Portals\\0\\BaoTangSo\\images\\";
                var dir = HttpContext.Current.Server.MapPath(web_dir); // đường dẫn lưu ảnh
                dir = dir.Replace("api\\BaoTangSo\\MauVatAPI\\", "");
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                file.SaveAs(dir + file.FileName);
                return Request.CreateResponse(HttpStatusCode.OK, "Thêm file thành công", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Thêm file lỗi:" + ex.Message, "application/json");
            }

        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage FileUploadAnhTaiVe(string TenMauVat)
        {
            try
            {
                var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
                string web_dir = "Portals\\0\\BaoTangSo\\images\\";
                var dir = HttpContext.Current.Server.MapPath(web_dir); // đường dẫn lưu ảnh
                dir = dir.Replace("api\\BaoTangSo\\MauVatAPI\\", "");
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                file.SaveAs(dir + file.FileName);
                return Request.CreateResponse(HttpStatusCode.OK, "Thêm file thành công", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Thêm file lỗi:" + ex.Message, "application/json");
            }

        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage FileUploadAnhTieuBan(string TenMauVat)
        {
            try
            {
                var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
                string web_dir = "Portals\\0\\BaoTangSo\\images\\";
                var dir = HttpContext.Current.Server.MapPath(web_dir); // đường dẫn lưu ảnh
                dir = dir.Replace("api\\BaoTangSo\\MauVatAPI\\", "");
                //dir = "D:\\BaoTangSo\\Portals\\images";
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                file.SaveAs(dir + file.FileName);
                return Request.CreateResponse(HttpStatusCode.OK, "Thêm file thành công", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Thêm file lỗi:" + ex.Message, "application/json");
            }

        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage FileUploadVideo(string TenMauVat)
        {
            try
            {
                var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
                string web_dir = "Portals\\0\\BaoTangSo\\videos\\";
                var dir = HttpContext.Current.Server.MapPath(web_dir); // đường dẫn lưu ảnh
                dir = dir.Replace("api\\BaoTangSo\\MauVatAPI\\", "");
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                file.SaveAs(dir + file.FileName);
                return Request.CreateResponse(HttpStatusCode.OK, "Thêm file thành công", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Thêm file lỗi:" + ex.Message, "application/json");
            }

        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage FileUploadThuyetMinh(string TenMauVat)
        {
            try
            {
                var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
                string web_dir = "Portals\\0\\BaoTangSo\\audios\\";
                var dir = HttpContext.Current.Server.MapPath(web_dir); // đường dẫn lưu ảnh
                dir = dir.Replace("api\\BaoTangSo\\MauVatAPI\\", "");
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                file.SaveAs(dir + file.FileName);
                return Request.CreateResponse(HttpStatusCode.OK, "Thêm file thành công", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Thêm file lỗi:" + ex.Message, "application/json");
            }

        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage FileUploadSach(string TenMauVat)
        {
            try
            {
                var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
                var fileAvatar = HttpContext.Current.Request.Files.Count > 1 ? HttpContext.Current.Request.Files[1] : null;
                string web_dir = "Portals\\0\\BaoTangSo\\files\\";
                var dir = HttpContext.Current.Server.MapPath(web_dir); // đường dẫn lưu ảnh
                dir = dir.Replace("api\\BaoTangSo\\MauVatAPI\\", "");
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                file.SaveAs(dir + file.FileName);
                fileAvatar.SaveAs(dir + fileAvatar.FileName);
                return Request.CreateResponse(HttpStatusCode.OK, "Thêm file thành công", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Thêm file lỗi:" + ex.Message, "application/json");
            }

        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage FileUploadBaiNghienCuu(string TenMauVat)
        {
            try
            {
                var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
                string web_dir = "Portals\\0\\BaoTangSo\\files\\";
                var dir = HttpContext.Current.Server.MapPath(web_dir); // đường dẫn lưu ảnh
                dir = dir.Replace("api\\BaoTangSo\\MauVatAPI\\", "");
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                file.SaveAs(dir + file.FileName);
                return Request.CreateResponse(HttpStatusCode.OK, "Thêm file thành công", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Thêm file lỗi:" + ex.Message, "application/json");
            }

        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage FileUploadTaiLieu(string TenMauVat)
        {
            try
            {
                var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
                string web_dir = "Portals\\0\\BaoTangSo\\files\\";
                var dir = HttpContext.Current.Server.MapPath(web_dir); // đường dẫn lưu ảnh
                dir = dir.Replace("api\\BaoTangSo\\MauVatAPI\\", "");
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                file.SaveAs(dir + file.FileName);
                return Request.CreateResponse(HttpStatusCode.OK, "Thêm file thành công", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Thêm file lỗi:" + ex.Message, "application/json");
            }

        }

        [System.Web.Http.HttpDelete]
        public HttpResponseMessage DeleteFile(string TenMauVat, string TenFile, int LoaiFile)
        {
            try
            {
                string thumuc = "";
                //nếu là file hình ảnh tiêu bản
                if(LoaiFile == 1)
                {
                    thumuc = "HinhAnhTieuBan";
                }
                string web_dir = "Portals\\0\\" + TenMauVat + "\\" + thumuc +"\\";
                var dir = HttpContext.Current.Server.MapPath(web_dir); // đường dẫn lưu ảnh
                dir = dir.Replace("api\\BaoTangSo\\MauVatAPI\\", "");
                //dir = "D:\\BaoTangSo\\Portals\\TaiLieu";
                System.IO.File.Delete(dir + TenFile);
                return Request.CreateResponse(HttpStatusCode.OK, "Xóa ảnh thành công", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Xóa ảnh lỗi:" + ex.Message, "application/json");
            }

        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage MauVatGetByID(string IDMauVat)
        {
            try
            {
                MauVat item = MauVatDAL.MauVatGetByID(IDMauVat);
                return Request.CreateResponse(HttpStatusCode.OK, item, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Lỗi :" + ex.Message, "application/json");
            }

        }


        [System.Web.Http.HttpDelete]
        public HttpResponseMessage MauVatDelete(Guid ID)
        {
            try
            {
                bool check = MauVatDAL.MauVatDelete(ID);
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

        [System.Web.Http.HttpGet]
        public HttpResponseMessage TaoIDMauVat()
        {
            try
            {
                Guid id = Guid.NewGuid();
                return Request.CreateResponse(HttpStatusCode.OK, id, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Lỗi :" + ex.Message, "application/json");
            }

        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage MauVatEdit(MauVat item)
        {
            try
            {
                bool check = MauVatDAL.MauVatEdit(item.IDMauVat, item.TenMauVat, item.TenKhoaHoc, item.TenGoiKhac, item.Ho, item.DacDiemNhanDang, item.TinhTrangBaoTon, item.DiaDiemSuuTam, item.ChatLieu,
                    item.KichThuocTrongLuong, item.NienDai, item.PhanBo, item.ViTriTinhChatSuDung, item.DonViTraoTang, item.HinhAnh3D, item.AnhPhanBo, item.FileThuyetMinh, item.AnhDaiDien, item.NoiDungThuyetMinh);
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
    }
}
