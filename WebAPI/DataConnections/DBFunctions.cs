using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WebAPI.DataConnections
{
    public class DBFunctions
    {
        public static void Truncate<T>(DbContext db_con)
        {
            Type type = typeof(T);
            List<Attribute> tableAttributes = type.GetCustomAttributes(typeof(TableAttribute)).ToList();
            if (tableAttributes.Count() > 0)
            {
                string schemaName = ((TableAttribute)tableAttributes[0]).Schema;
                string tableName = ((TableAttribute)tableAttributes[0]).Name;
                db_con.Database.ExecuteSqlCommand($"TRUNCATE TABLE " + schemaName + "." + tableName);
            }
            else
            {
                db_con.Database.ExecuteSqlCommand($"TRUNCATE TABLE {typeof(T).Name}");
            }
        }

        //public void BulkInsert<T>(DbContext db_con, IEnumerable<T> entities)
        //{
        //    SqlBulkCopy
        //    db_con.BulkInsert(entities);
        //}
    }
}