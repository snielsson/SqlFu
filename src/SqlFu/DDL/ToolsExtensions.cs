﻿using SqlFu.DDL;
using SqlFu.Internals;

namespace SqlFu
{
    public static class ToolsExtensions
    {
        /// <summary>
        /// Drops table specified by type param
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db"></param>
        public static void Drop<T>(this IAccessDb db)
         {
             var ti = TableInfo.ForType(typeof (T));
             db.DatabaseTools.DropTable(ti.Name);
         }

        /// <summary>
        /// Truncate table specified by type param
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db"></param>
        public static void Truncate<T>(this IAccessDb db)
        {
            var ti = TableInfo.ForType(typeof(T));
            db.DatabaseTools.TruncateTable(ti.Name);
        }

        public static bool TableExists<T>(this IAccessDb db)
        {
            var ti = TableInfo.ForType(typeof(T));
            return db.DatabaseTools.TableExists(ti.Name);
        }

        public static void CreateTable<T>(this IAccessDb db)
        {
            db.DatabaseTools.GetCreateTableBuilder<T>().ExecuteDDL();
        }
    }
}