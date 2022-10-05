
using DotNetNuke.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HueCIT.Modules.BaoTangSo.Models
{
    [TableName("MauVat")]
    //setup the primary key for table
    [PrimaryKey("IDMauVat", AutoIncrement = true)]
    public class MauVat
    {
        public Guid IDMauVat { get; set; }
        public string TenMauVat { get; set; }
        public Guid IDChuyenMuc { get; set; }

        public string TenKhoaHoc { get; set; }

        public string TenGoiKhac { get; set; }

        public string Ho { get; set; }

        public string DacDiemNhanDang { get; set; }
        public string TinhTrangBaoTon { get; set; }
        public string DiaDiemSuuTam { get; set; }
        public string ChatLieu { get; set; }
        public string KichThuocTrongLuong { get; set; }
        public string NienDai { get; set; }
        public string PhanBo { get; set; }
        public string ViTriTinhChatSuDung { get; set; }
        public string DonViTraoTang { get; set; }
        public string HinhAnhTaiVe { get; set; }
        public string HinhAnhTieuBan { get; set; }
        public string Video { get; set; }
        public string HinhAnh3D { get; set; }
        public string BaiNghienCuu { get; set; }
        public string TaiLieu { get; set; }
        public string Sach { get; set; }
        public string AnhPhanBo { get; set; }
        public string FileThuyetMinh { get; set; }
        public string AnhDaiDien { get; set; }

        public string NoiDungThuyetMinh { get; set; }
        public MauVat()
        {
            this.HinhAnhTaiVe = null;
            this.HinhAnhTieuBan = null;
            this.Video = null;
            this.HinhAnh3D = null;
            this.BaiNghienCuu = null;
            this.TaiLieu = null;
            this.Sach = null;
            this.AnhPhanBo = null;
            this.FileThuyetMinh = null;
            this.AnhDaiDien = null;
        }
    }
}