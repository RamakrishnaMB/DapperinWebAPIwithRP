using Dapper;
using DataManagement.Entities;
using EmpManagement.Repository.Interfaces.Repository_Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmpManagement.Repository.Repository
{
    public class EmployeService : IEmployeService
    {
        private readonly IRepository<Emp> _FormRepository;

        public EmployeService(IRepository<Emp> formRepository)
        {
            _FormRepository = formRepository;
        }

        public async Task<int> AddEmp(Emp objEmp)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("EmpName", objEmp.EmpName);
            parameters.Add("EmpAddress", objEmp.EmpAddress);
            parameters.Add("EmailId", objEmp.EmailId);
            parameters.Add("MobileNum", objEmp.MobileNum);
            return await _FormRepository.AddAsync(objEmp, "AddEmp", parameters);
        }

        public async Task<int> DeleteEmp(int Id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", Id);
            return await _FormRepository.DeleteAsync("DeleteEmp", parameters);
        }

        public async Task<IEnumerable<Emp>> GetAllEmp()
        {
            return await _FormRepository.GetAllAsync("GetAllEmps");
        }

        public async Task<Emp> GetEmpById(int Id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", Id);
            return await _FormRepository.GetByIdAsync("GetEmpById", parameters);
        }

        public async Task<int> UpdateEmp(Emp objEmp)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("EmpName", objEmp.EmpName);
            parameters.Add("EmpAddress", objEmp.EmpAddress);
            parameters.Add("EmailId", objEmp.EmailId);
            parameters.Add("MobileNum", objEmp.MobileNum);
            parameters.Add("Id", objEmp.Id);
            return await _FormRepository.UpdateAsync(objEmp, "UpdateEmp", parameters);
        }
    }
}
