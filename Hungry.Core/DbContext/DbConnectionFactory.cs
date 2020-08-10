using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Hungry.Core.DbContext
{
    class DbConnectionFactory
    {
        public static IDbConnection GetInstance()
        {
            var connectionString = "Data Source=.;Initial Catalog=Hungry;Integrated Security=True";
            var connection = DbConnection.GetInstance(connectionString);
            connection.Open();
            return connection;
        }
    }
}
