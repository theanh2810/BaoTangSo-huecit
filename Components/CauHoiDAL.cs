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
    public class CauHoiDAL
    {
        protected static IDataContext dataContext = dataContext ?? DataContext.Instance();
        public static int CauHoiGetMaxID()
        {
            var param = new List<object>
            {
            };
            int max = dataContext.ExecuteSingleOrDefault<int>(System.Data.CommandType.StoredProcedure, "sp_GetMaxIDCauHoi", param.ToArray());
            return max > 0? max : 0;
        }

        //t?o m?i câu h?i
        public static bool CauHoiAdd(Guid MaMauVat, string MoTa, string NoiDungCauHoi, int ThuTuHienThi)
        {
            try
            {
                var param = new List<object> {
                   MaMauVat,
                   MoTa,
                   NoiDungCauHoi,
                   ThuTuHienThi,
                };
                dataContext.Execute(System.Data.CommandType.StoredProcedure, "sp_QuestionAdd", param.ToArray().ToList());
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<CauHoi> CauHoiGetByMauVat(string IDMauVat)
        {
            string sql = "SELECT * FROM CauHoi where MaMauVat = '" + IDMauVat + "'";
            List<CauHoi> list = new GenericRepository<CauHoi>().ExecuteQuery(sql, null);
            return list;
        }

        public static CauHoi CauHoiGetByID(int ID)
        {
            string sql = "select * from CauHoi where ID = '" + ID + "'";
            CauHoi item = dataContext.ExecuteSingleOrDefault<CauHoi>(System.Data.CommandType.Text, sql);
            return item;
        }

        public static bool CauHoiEdit(int ID, string MoTa, string NoiDungCauHoi, int ThuTuHienThi)
        {
            try
            {
                var param = new List<object> {
                   ID,
                   MoTa,
                   NoiDungCauHoi,
                   ThuTuHienThi,
                };
                dataContext.Execute(System.Data.CommandType.StoredProcedure, "sp_CauHoiEdit", param.ToArray().ToList());
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

}
