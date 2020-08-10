using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Hungry.Core.DbContext
{
    class DbDataParameter : IDbDataParameter
    {
        private readonly IDbDataParameter _dbDataParameter = null;

        private DbDataParameter(string parameterName, object value)
        {
            _dbDataParameter = new SqlParameter(parameterName, value);
        }

        public byte Precision { get => _dbDataParameter.Precision; set => _dbDataParameter.Precision = value; }
        public byte Scale { get => _dbDataParameter.Scale; set => _dbDataParameter.Scale = value; }
        public int Size { get => _dbDataParameter.Size; set => _dbDataParameter.Size = value; }
        public DbType DbType { get => _dbDataParameter.DbType; set => _dbDataParameter.DbType = value; }
        public ParameterDirection Direction { get => _dbDataParameter.Direction; set => _dbDataParameter.Direction = value; }

        public bool IsNullable => _dbDataParameter.IsNullable;

        public string ParameterName { get => _dbDataParameter.ParameterName; set => _dbDataParameter.ParameterName = value; }
        public string SourceColumn { get => _dbDataParameter.SourceColumn; set => _dbDataParameter.SourceColumn = value; }
        public DataRowVersion SourceVersion { get => _dbDataParameter.SourceVersion; set => _dbDataParameter.SourceVersion = value; }
        public object Value { get => _dbDataParameter.Value; set => _dbDataParameter.Value = value; }

        public static IDbDataParameter GetInstance(string parameterName, object value)
        {
            return new DbDataParameter(parameterName, value)._dbDataParameter;
        }
    }
}
