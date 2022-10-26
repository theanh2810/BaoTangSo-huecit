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
    public class ChuyenMucDAL
    {
        protected static IDataContext dataContext = dataContext ?? DataContext.Instance();
        
        public static List<ChuyenMuc> ChuyenMucGetAll()
        {
            string sql = "SELECT * FROM ChuyenMuc order by ThuTuHienThi";
            List<ChuyenMuc> list = new GenericRepository<ChuyenMuc>().ExecuteQuery(sql, null);
            return list;
        }

        public static List<ChuyenMuc> ChuyenMucChaGetAll()
        {
            string sql = "select * from ChuyenMuc where IDChuyenMucCha is null order by ThuTuHienThi";
            List<ChuyenMuc> list = new GenericRepository<ChuyenMuc>().ExecuteQuery(sql, null);
            return list;
        }

        //t?o m?i chuyên m?c
        public static bool ChuyenMucAdd(Guid ID, string TenChuyenMuc,Guid IDChuyenMucCha,string MoTa, int ThuTuHienThi)
        {
            try
            {
                var param = new List<object> {
                    ID,
                    TenChuyenMuc,
                    IDChuyenMucCha,
                    MoTa,
                    ThuTuHienThi,
                };
                dataContext.Execute(System.Data.CommandType.StoredProcedure, "sp_ChuyenMucAdd", param.ToArray().ToList());
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //xóa chuyên m?c
        public static bool ChuyenMucDelete(Guid ID)
        {
            try
            {
                var param = new List<object> {
                 ID,
                };
                dataContext.Execute(System.Data.CommandType.StoredProcedure, "sp_ChuyenMucDelete", param.ToArray().ToList());
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static ChuyenMuc ChuyenMucGetByID(string IDChuyenMuc)
        {
            string sql = "select * from ChuyenMuc where ID =  '" + IDChuyenMuc + "'";
            ChuyenMuc item = dataContext.ExecuteSingleOrDefault<ChuyenMuc>(System.Data.CommandType.Text, sql);
            return item;
        }

        public static bool ChuyenMucEdit(Guid ID, string TenChuyenMuc, Guid IDChuyenMucCha ,string MoTa, int ThuTuHienThi)
        {
            try
            {
                var param = new List<object> {
                   ID,
                   TenChuyenMuc,
                   IDChuyenMucCha,
                   MoTa,
                   ThuTuHienThi,
                };
                dataContext.Execute(System.Data.CommandType.StoredProcedure, "sp_ChuyenMucEdit", param.ToArray().ToList());
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

}
