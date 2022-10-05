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
    public class DapAnDAL
    {
        protected static IDataContext dataContext = dataContext ?? DataContext.Instance();
        public static List<CauHoi> CauHoiGetAll()
        {
            string sql = "SELECT * FROM CauHoi order by ThuTuHienThi";
            List<CauHoi> list = new GenericRepository<CauHoi>().ExecuteQuery(sql, null);
            return list;
        }

        //t?o m?i chuyên m?c
        public static bool DapAnAdd(int MaCauHoi, Guid MaMauVat, string DapAn, int CauHoiDung, string GhiChu)
        {
            try
            {
                var param = new List<object> {
                    MaCauHoi,
                    MaMauVat,
                    DapAn,
                    CauHoiDung,
                    GhiChu,
                };
                dataContext.Execute(System.Data.CommandType.StoredProcedure, "sp_AnswerAdd", param.ToArray().ToList());
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<Answer> DapAnGetByCauHoi(int MaCauHoi)
        {
            string sql = "select * from DapAn where MaCauHoi = '" + MaCauHoi + "'";
            List<Answer> list = new GenericRepository<Answer>().ExecuteQuery(sql, null);
            return list;
        }

        public static bool DapAnEdit(int ID, string DapAn, int CauHoiDung, string GhiChu)
        {
            try
            {
                var param = new List<object> {
                   ID,
                   DapAn,
                   CauHoiDung,
                   GhiChu,
                };
                dataContext.Execute(System.Data.CommandType.StoredProcedure, "sp_DapAnEdit", param.ToArray().ToList());
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

}
