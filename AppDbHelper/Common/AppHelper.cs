using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;

namespace DbContextHelper.Common
{
    public static class AppHelper
    {
        const string Letters = "12346789ABCDEFGHJKLMNPRTUVWXYZ";
        public static string GeneratePassword(int length)
        {
            Random rand = new Random();
            int maxRand = Letters.Length - 1;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                int index = rand.Next(maxRand);
                sb.Append(Letters[index]);
            }
            return sb.ToString();
        }

        public static DataTable ToDataTable<T>(this IEnumerable<T> list)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();
            DataTable dataTable = new DataTable();
            dataTable.TableName = typeof(T).FullName;
            foreach (PropertyInfo info in properties)
            {
                dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }

            foreach (T entity in list)
            {
                object[] values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
#pragma warning disable CS8601 // Possible null reference assignment.
                    values[i] = properties[i].GetValue(entity);
#pragma warning restore CS8601 // Possible null reference assignment.
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        public static DataTable ToDataTable(this Object obj)
        {
            DataTable dataTable = new DataTable();
            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                dataTable.Columns.Add(new DataColumn(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType));
            }
            dataTable.Rows.Add(obj);
            return dataTable;
        }

        public static Dictionary<string, dynamic> ToDictionary(this Object obj)
        {
            Dictionary<string, dynamic> dictionary = new Dictionary<string, dynamic>();
            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                dictionary.Add(prop.Name, prop.GetValue(obj));
            }
            return dictionary;
        }
    }
}
