
using System;
using System.Data;
using System.Reflection;
using System.Collections.Generic;
using DotNetNuke.Data;
using DotNetNuke.Collections;
using DotNetNuke.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace HueCIT.MVC.GenericDAL
{
    public class GenericRepository<T> where T : class
    {
        protected static IDataContext dataContext = dataContext ?? DataContext.Instance();
        protected static IRepository<T> repository = repository ?? dataContext.GetRepository<T>();

        public void Create(T Item)
        {
            repository.Insert(Item);
        }

        public void Update(T Item)
        {
            repository.Update(Item);
        }

        public void Delete(object ItemID)
        {
            T Item = GetById(ItemID);
            Delete(Item);
        }

        public void Delete(T Item)
        {
            repository.Delete(Item);
        }


        public List<T> Get()
        {
            return repository.Get().ToList();
        }

        public List<T> Get(string sqlCondition, object[] args = null)
        {
            return repository.Find(sqlCondition, args).ToList();
        }

        public T GetById(object ItemID)
        {
            string sql = String.Format("WHERE {0} = @0", PrimaryKey.ColumnName);
            return dataContext.ExecuteSingleOrDefault<T>(CommandType.Text, sql, new object[] { ItemID });
        }

        public IPagedList<T> GetPage(object scopeValue, int pageIndex, int pageSize)
        {
            return repository.GetPage(scopeValue, pageIndex, pageSize);
        }

        /// <summary>
        /// Ph??ng th?c l?u tr? ??i t??ng. N?u ??i t??ng ?ã có s?n th?c hi?n c?p nh?t thông tin, n?u ch?a có s? t?o m?i.
        /// </summary>
        public void Save(T Item)
        {
            object keyValue = Item.GetType().GetProperty(PrimaryKey.ColumnName).GetValue(Item);
            T result = GetById(keyValue);
            if (result == null)
                Create(Item);
            else
                Update(Item);
        }

        public void ExecuteNonQuery(string sql, object[] args = null)
        {
            dataContext.Execute(CommandType.Text, sql, args);
        }

        /// <summary>
        /// S? d?ng truy v?n các tr??ng xác ??nh c?a m?t b?ng và ánh x? t??ng ?ng v?i các thu?c tính c?a l?p d? li?u t? ??nh ngh?a
        /// </summary>
        public List<T> ExecuteQuery(string sql, object[] args = null)
        {
            return dataContext.ExecuteQuery<T>(CommandType.Text, sql, args).ToList();
        }

        public List<T> ExcuteQueryWithProcedure(string sql, object[] args = null)
        {
            return dataContext.ExecuteQuery<T>(CommandType.StoredProcedure, sql, args).ToList();
        }

        /// <summary>
        /// S? d?ng truy v?n các tr??ng xác ??nh c?a m?t b?ng và ánh x? t??ng ?ng v?i các thu?c tính c?a l?p d? li?u t? ??nh ngh?a
        /// </summary>
        public IEnumerable<T> IExecuteQuery(string sql, object[] args = null)
        {
            IEnumerable<T> list = dataContext.ExecuteQuery<T>(CommandType.Text, sql, args);
            return (list.Any()) ? list : null;
        }

        /// <summary>
        /// L?y c?t khóa chính c?a ??i t??ng b?ng d? li?u (ColumnName: Tên c?t trong b?ng d? li?u; PropertyName: Tên thu?c tính c?a l?p ??i t??ng; AutoIncrement: True n?u giá tr? t? ??ng t?ng)
        /// </summary>
        protected PrimaryKeyAttribute PrimaryKey
        {
            get
            {
                // Tr??ng h?p khai báo thu?c tính PrimaryKey t?i ph?n class header
                IEnumerable<Attribute> customAttributes = typeof(T).GetCustomAttributes();
                foreach (Attribute attribute in customAttributes)
                    if (attribute.GetType().Name.Equals("PrimaryKeyAttribute"))
                        return attribute as PrimaryKeyAttribute;

                // Tr??ng h?p khai báo thu?c tính PrimaryKey t?i ph?n ??nh ngh?a thu?c tính khóa chính c?a l?p
                PropertyInfo[] propertyInfos = typeof(T).GetProperties();
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    customAttributes = propertyInfo.GetCustomAttributes();
                    foreach (Attribute attribute in customAttributes)
                        if (attribute.GetType().Name.Equals("PrimaryKeyAttribute"))
                            return attribute as PrimaryKeyAttribute;
                }
                return null;
            }
        }

        /// <summary>
        /// Tr? v? m?t trang d? li?u theo s? th? t? trang
        /// </summary>
        /// <param name="pageIndex">S? th? t? trang</param>
        /// <param name="pageSize">S? l??ng dòng/trang</param>
        /// <param name="sortColumn">Tên c?t mu?n s?p x?p</param>
        /// <param name="sortOrder">Th? t? s?p x?p (ASC ho?c DESC)</param>        
        public IEnumerable<T> ExecWithStoreProcedure(string query, params object[] parameters)
        {
            return dataContext.ExecuteQuery<T>(System.Data.CommandType.StoredProcedure, query, parameters);
        }
        public void ExecStoreProcedureNonQuery(string query, params object[] parameters)
        {
            dataContext.Execute(System.Data.CommandType.StoredProcedure, query, parameters);
        }
    }

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}