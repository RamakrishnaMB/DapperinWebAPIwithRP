using DataManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmpManagement.Repository.Interfaces.Repository_Interface
{
    public interface IEmployeService
    {
        Task<int> AddEmp(Emp objEmp);
        Task<IEnumerable<Emp>> GetAllEmp();

        Task<Emp> GetEmpById(int Id);
        Task<int> UpdateEmp(Emp objEmp);

        Task<int> DeleteEmp(int Id);
    }
}
