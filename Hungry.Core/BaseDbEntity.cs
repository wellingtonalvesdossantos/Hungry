using Hungry.Core.DbContext;
using System;
using System.Collections.Generic;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Hungry.Core
{
    public class BaseDbEntity<T>
    {
        public int Id { get; set; }

        public static IEnumerable<T> GetAll()
        {
            using (var conn = DbConnectionFactory.GetInstance())
            {
                return conn.Query<T>("select * from "+ typeof(T).Name);
            }
        }

        public static T GetById(int id)
        {
            using (var conn = DbConnectionFactory.GetInstance())
            {
                return conn.QueryFirstOrDefault<T>("select * from " + typeof(T).Name + " where id = @id", new { id });
            }
        }

        public virtual void Create()
        {
            using (var conn = DbContext.DbConnectionFactory.GetInstance())
            {
                conn.Insert(this);
            }
        }
    }
}
