using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Hungry.Core.DbContext
{
    class DbCommand : IDbCommand
    {
        private readonly IDbCommand _dbCommand = null;

        private DbCommand(string cmdText, IDbConnection connection)
        {
            _dbCommand = new SqlCommand(cmdText, (SqlConnection)connection);
        }

        public string CommandText { get => _dbCommand.CommandText; set => _dbCommand.CommandText = value; }
        public int CommandTimeout { get => _dbCommand.CommandTimeout; set => _dbCommand.CommandTimeout = value; }
        public CommandType CommandType { get => _dbCommand.CommandType; set => _dbCommand.CommandType = value; }
        public IDbConnection Connection { get => _dbCommand.Connection; set => _dbCommand.Connection = value; }

        public IDataParameterCollection Parameters => _dbCommand.Parameters;

        public IDbTransaction Transaction { get => _dbCommand.Transaction; set => _dbCommand.Transaction = value; }
        public UpdateRowSource UpdatedRowSource { get => _dbCommand.UpdatedRowSource; set => _dbCommand.UpdatedRowSource = value; }

        public static IDbCommand GetInstance(string cmdText, IDbConnection connection)
        {
            return new DbCommand(cmdText, connection)._dbCommand;
        }

        public void Cancel()
        {
            _dbCommand.Cancel();
        }

        public IDbDataParameter CreateParameter()
        {
            return _dbCommand.CreateParameter();
        }

        public void Dispose()
        {
            _dbCommand.Dispose();
        }

        public int ExecuteNonQuery()
        {
            return _dbCommand.ExecuteNonQuery();
        }

        public IDataReader ExecuteReader()
        {
            return _dbCommand.ExecuteReader();
        }

        public IDataReader ExecuteReader(CommandBehavior behavior)
        {
            return _dbCommand.ExecuteReader(behavior);
        }

        public object ExecuteScalar()
        {
            return _dbCommand.ExecuteScalar();
        }

        public void Prepare()
        {
            _dbCommand.Prepare();
        }
    }
}
