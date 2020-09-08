using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmpManagement.Repository.Interfaces.Repository_Interface
{
    public interface IRepository<T> where T : class
    {
        Task<int> AddAsync(T entity, string spName, DynamicParameters dynamicParameters);
        Task<T> GetByIdAsync(string spName, DynamicParameters dynamicParameters);
        Task<IEnumerable<T>> GetAllAsync(string spName);
        Task<int> UpdateAsync(T entity, string spName, DynamicParameters dynamicParameters);
        Task<int> DeleteAsync(string spName, DynamicParameters dynamicParameters);
    }
}
