using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DynamicRepository : IDynamicRepository
    {
        public readonly string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        public IConnectionFactory ConnectionFactory { get; set; }

        public List<T> All<T>(string uspName, object param = null)
        {
            using (IDbConnection connection = ConnectionFactory.GetConnection(connectionString))
            {
                var result = connection.Query<T>(uspName, param, commandType: CommandType.StoredProcedure).ToList();
                return result;
            };
        }
        public List<T> List<T>(string query, object param = null)
        {
            using (IDbConnection connection = ConnectionFactory.GetConnection(connectionString))
            {
                var result = connection.Query<T>(query, param, commandType: CommandType.Text).ToList();
                return result;
            };
        }
        public T Get<T>(string uspName, object param = null)
        {
            using (IDbConnection connection = ConnectionFactory.GetConnection(connectionString))
            {
                var result = connection.Query<T>(uspName, param, commandTimeout: 100, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return result;
            };
        }
        public T Find<T>(string uspName, int id)
        {
            using (IDbConnection connection = ConnectionFactory.GetConnection(connectionString))
            {
                var result = connection.Query<T>(uspName, new { Id = id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return result;
            };
        }
        public T FindBy<T>(string uspName, object entityParam = null)
        {
            using (IDbConnection connection = ConnectionFactory.GetConnection(connectionString))
            {
                var result = connection.Query<T>(uspName, entityParam, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return result;
            };
        }

        public T Add<T>(string uspName, object entityParam)
        {
            using (IDbConnection connection = ConnectionFactory.GetConnection(connectionString))
            {
                var result = connection.Query<T>(
                     uspName, entityParam, commandType: CommandType.StoredProcedure
                    ).FirstOrDefault();
                return result;
            };
        }

        public int Add<T>(string uspName, T entity)
        {
            return AddorUpdate(uspName, entity, true);
        }
        public int Update<T>(string uspName, T entity)
        {
            return AddorUpdate(uspName, entity);
        }
        public int DeleteMultiple(string uspName, string ids)
        {
            using (IDbConnection connection = ConnectionFactory.GetConnection(connectionString))
            {
                var result = connection.Execute(uspName, new { Id = ids }, transaction: ConnectionFactory.Transaction, commandType: CommandType.StoredProcedure);
                return result;
            };
        }
        public int Delete(string uspName, object param = null)
        {
            int result;
            try
            {
                using (IDbConnection connection = ConnectionFactory.GetConnection(connectionString))
                {
                    result = connection.Execute(uspName, param, commandType: CommandType.StoredProcedure);
                };
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }
        public void Delete<T>(T entity)
        {
            //Delete(entity.TId);
        }
        public T FindByName<T>(string name)
        {
            using (IDbConnection connection = ConnectionFactory.GetConnection(connectionString))
            {
                var result = connection.Query<T>("SELECT * FROM T WHERE Name = @Name", param: new { Name = name }).FirstOrDefault();
                return result;
            };
        }
        private int AddorUpdate<T>(string uspName, T entity, bool isInsert = false)
        {
            int result = -1;
            try
            {
                using (IDbConnection connection = ConnectionFactory.GetConnection(connectionString))
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.AddDynamicParams(entity);

                    if (isInsert)
                        dynamicParameters.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    if (ConnectionFactory.Transaction != null)
                        result = connection.Execute(uspName, dynamicParameters, transaction: ConnectionFactory.Transaction, commandType: CommandType.StoredProcedure);
                    else
                        result = connection.Execute(uspName, dynamicParameters, commandType: CommandType.StoredProcedure);

                    if (isInsert)
                        result = dynamicParameters.Get<int>("@Id");

                    if (ConnectionFactory.Transaction == null && connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        public int AddOrUpdateDynamic(string uspName, dynamic entity)
        {
            int result = -1;
            try
            {
                using (IDbConnection connection = ConnectionFactory.GetConnection(connectionString))
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.AddDynamicParams(entity);

                    dynamicParameters.Add("@res", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    if (ConnectionFactory.Transaction != null)
                        result = connection.Execute(uspName, dynamicParameters, transaction: ConnectionFactory.Transaction, commandType: CommandType.StoredProcedure);
                    else
                        result = connection.Execute(uspName, dynamicParameters, commandType: CommandType.StoredProcedure);

                    result = dynamicParameters.Get<int>("@res");

                    if (ConnectionFactory.Transaction == null && connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
            catch (Exception ex)
            {
                //ExceptionHandling.WriteException(ex);
            }

            return result;
        }
    }
}
