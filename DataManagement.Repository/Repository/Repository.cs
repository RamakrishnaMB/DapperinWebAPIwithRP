using Dapper;
using EmpManagement.Repository.Interfaces.Repository_Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace EmpManagement.Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IConfiguration _config;

        public Repository(IConfiguration config)
        {
            _config = config;
        }
        internal IDbConnection DbConnection => new SqlConnection(_config.GetConnectionString("SQLDBConnectionString"));

        public async Task<int> AddAsync(T entity, string spName, DynamicParameters dynamicParameters)
        {
            using (IDbConnection con = DbConnection)
            {
                var result = await SqlMapper.ExecuteAsync(con, spName, param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<int> DeleteAsync(string spName, DynamicParameters dynamicParameters)
        {
            using (IDbConnection con = DbConnection)
            {
                var result = await SqlMapper.ExecuteAsync(con, spName, param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync(string spName)
        {
            using (IDbConnection con = DbConnection)
            {
                return await SqlMapper.QueryAsync<T>(con, spName, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<T> GetByIdAsync(string spName, DynamicParameters dynamicParameters)
        {
            using (IDbConnection con = DbConnection)
            {
                return await SqlMapper.QueryFirstAsync<T>(con, spName, dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> UpdateAsync(T entity, string spName, DynamicParameters dynamicParameters)
        {
            using (IDbConnection con = DbConnection)
            {
                return await SqlMapper.ExecuteAsync(con, spName, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
