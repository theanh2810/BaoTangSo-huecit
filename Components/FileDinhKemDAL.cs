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
    public class FileDinhKemDAL
    {
        protected static IDataContext dataContext = dataContext ?? DataContext.Instance();

        public static bool FileDinhKemAdd(Guid ID, Guid MaMauVat, string TenTep, string MoTa, string ViTriLuuTru, int LoaiFile, string AnhDaiDien)
        {
            try
            {
                var param = new List<object> {
                    ID, 
                    MaMauVat, 
                    TenTep, 
                    MoTa,
                    ViTriLuuTru,
                    LoaiFile,
                    AnhDaiDien
                };
                dataContext.Execute(System.Data.CommandType.StoredProcedure, "sp_FileDinhKemAdd", param.ToArray().ToList());
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static FileDinhKem FileDinhKemGetByID(string ID)
        {
            string sql = "select * from FileDinhKem where ID = '" + ID + "'";
            FileDinhKem item = dataContext.ExecuteSingleOrDefault<FileDinhKem>(System.Data.CommandType.Text, sql);
            return item;
        }

        public static bool FileDinhKemDelete(Guid ID)
        {
            try
            {
                var param = new List<object> {
                 ID,
                };
                dataContext.Execute(System.Data.CommandType.StoredProcedure, "sp_FileDinhKemDelete", param.ToArray().ToList());
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
