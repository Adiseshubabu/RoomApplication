using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ConnectionFactory : IConnectionFactory
    {
        private IDbTransaction _transaction = null;
        public IDbTransaction Transaction
        {
            get
            {
                return _transaction;
            }
        }
        public IDbConnection GetConnection(string connectionString)
        {
            var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            var conn = factory.CreateConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            return conn;
        }
    }
}
