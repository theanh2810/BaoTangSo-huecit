using System;
using System.Data;
using System.Reflection;
using System.Collections.Generic;
using DotNetNuke.Data;
using DotNetNuke.Collections;
using DotNetNuke.ComponentModel.DataAnnotations;
using System.Linq;
using HueCIT.Modules.BaoTangSo.Models;
using HueCIT.MVC.GenericDAL;

namespace HueCIT.MVC.ChuyenMucDAL
{
    public class MauVatDAL
    {
        protected static IDataContext dataContext = dataContext ?? DataContext.Instance();
        
        public static bool MauVatAdd(Guid IDMauVat, string TenMauVat, Guid IDChuyenMuc, string TenKhoaHoc, string TenGoiKhac, string Ho, string DacDiemNhanDang, string TinhTrangBaoTon, 
            string DiaDiemSuuTam, string ChatLieu, string KichThuocTrongLuong, string NienDai, string PhanBo, string ViTriTinhChatSuDung, string DonViTraoTang, string HinhAnhTaiVe, string HinhAnhTieuBan,
            string Video, string HinhAnh3D, string BaiNghienCuu, string TaiLieu, string Sach, string AnhPhanBo, string FileThuyetMinh, string AnhDaiDien, string NoiDungThuyetMinh)
        {
            try
            {
                var param = new List<object> {
                    IDMauVat,
                    TenMauVat,
                    IDChuyenMuc,
                    TenKhoaHoc,
                    TenGoiKhac,
                    Ho,
                    DacDiemNhanDang,
                    TinhTrangBaoTon,
                    DiaDiemSuuTam,
                    ChatLieu,
                    KichThuocTrongLuong,
                    NienDai,
                    PhanBo,
                    ViTriTinhChatSuDung,
                    DonViTraoTang,
                    HinhAnhTaiVe,
                    HinhAnhTieuBan,
                    Video,
                    HinhAnh3D,
                    BaiNghienCuu,
                    TaiLieu,
                    Sach,
                    AnhPhanBo,
                    FileThuyetMinh,
                    AnhDaiDien,
                    NoiDungThuyetMinh,
                };
                dataContext.Execute(System.Data.CommandType.StoredProcedure, "sp_MauVatAdd", param.ToArray().ToList());
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<MauVat> MauVatGetAll()
        {
            string sql = "SELECT * FROM MauVat";
            List<MauVat> list = new GenericRepository<MauVat>().ExecuteQuery(sql, null);
            return list;
        }

        public static List<MauVat> MauVatGetByChuyenMuc(string IDChuyenMuc)
        {
            string sql = "SELECT * FROM MauVat where IDChuyenMuc = '" + IDChuyenMuc + "'";
            List<MauVat> list = new GenericRepository<MauVat>().ExecuteQuery(sql, null);
            return list;
        }

        public static MauVat MauVatGetByID(string IDMauVat)
        {
            string sql = "select * from MauVat where IDMauVat =  '" + IDMauVat + "'";
            MauVat item = dataContext.ExecuteSingleOrDefault<MauVat>(System.Data.CommandType.Text, sql);
            return item;
        }


        //xóa m?u v?t
        public static bool MauVatDelete(Guid ID)
        {
            try
            {
                var param = new List<object> {
                 ID,
                };
                dataContext.Execute(System.Data.CommandType.StoredProcedure, "sp_MauVatDelete", param.ToArray().ToList());
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool MauVatUpdate(Guid ID, string Sach, string BaiNghienCuu, string TaiLieu)
        {
            try
            {
                var param = new List<object> {
                 ID,
                 Sach,
                 BaiNghienCuu,
                 TaiLieu
                };
                dataContext.Execute(System.Data.CommandType.StoredProcedure, "sp_MauVatUpdate", param.ToArray().ToList());
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool MauVatUpdateVideo(Guid IDMauVat, string ListVideo)
        {
            try
            {
                var param = new List<object> {
                 IDMauVat,
                 ListVideo,
                };
                dataContext.Execute(System.Data.CommandType.StoredProcedure, "sp_MauVatUpdateVideo", param.ToArray().ToList());
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool MauVatUpdateHinhAnhTaiVe(Guid ID, string List)
        {
            try
            {
                var param = new List<object> {
                 ID,
                 List,
                };
                dataContext.Execute(System.Data.CommandType.StoredProcedure, "sp_MauVatUpdateHinhAnhTaiVe", param.ToArray().ToList());
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool MauVatUpdateHinhAnhTieuBan(Guid ID, string List)
        {
            try
            {
                var param = new List<object> {
                 ID,
                 List,
                };
                dataContext.Execute(System.Data.CommandType.StoredProcedure, "sp_MauVatUpdateHinhAnhTieuBan", param.ToArray().ToList());
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool MauVatEdit(Guid IDMauVat, string TenMauVat,  string TenKhoaHoc, string TenGoiKhac, string Ho, string DacDiemNhanDang, string TinhTrangBaoTon,
            string DiaDiemSuuTam, string ChatLieu, string KichThuocTrongLuong, string NienDai, string PhanBo, string ViTriTinhChatSuDung, string DonViTraoTang, 
            string HinhAnh3D,  string AnhPhanBo, string FileThuyetMinh, string AnhDaiDien, string NoiDungThuyetMinh)
        {
            try
            {
                var param = new List<object> {
                    IDMauVat,
                    TenMauVat,
                    TenKhoaHoc,
                    TenGoiKhac,
                    Ho,
                    DacDiemNhanDang,
                    TinhTrangBaoTon,
                    DiaDiemSuuTam,
                    ChatLieu,
                    KichThuocTrongLuong,
                    NienDai,
                    PhanBo,
                    ViTriTinhChatSuDung,
                    DonViTraoTang,
                    HinhAnh3D,
                    AnhPhanBo,
                    FileThuyetMinh,
                    AnhDaiDien,
                    NoiDungThuyetMinh,
                };
                dataContext.Execute(System.Data.CommandType.StoredProcedure, "sp_MauVatEdit", param.ToArray().ToList());
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
