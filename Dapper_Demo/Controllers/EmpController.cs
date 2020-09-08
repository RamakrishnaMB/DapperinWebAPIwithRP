using DataManagement.Entities;
using DataManagement.Repository.Interfaces;
using EmpManagement.Repository.Interfaces.Repository_Interface;
using EmpManagement.Repository.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Dapper_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {

        IEmpRepository<Emp> _empRepository;
        private readonly IEmployeService employeService;

        public EmpController(IEmpRepository<Emp> empRepository, IEmployeService employeService)

        {
            _empRepository = empRepository;
            this.employeService = employeService;
        }

        // GET: api/Emp
        [HttpGet]
        public async System.Threading.Tasks.Task<IEnumerable<Emp>> GetAsync()
        {
            //return _empRepository.GetAllEmp();
            return await employeService.GetAllEmp();
        }

        // GET: api/Emp/5
        [HttpGet("{id}", Name = "Get")]
        public async System.Threading.Tasks.Task<Emp> GetAsync(int id)
        {
            //return _empRepository.GetEmpById(id);
            return await employeService.GetEmpById(id);
        }

        // POST: api/Emp
        [HttpPost]
        public async System.Threading.Tasks.Task PostAsync([FromBody] Emp emp)
        {
            // _empRepository.AddEmp(emp);
            var result = await employeService.AddEmp(emp);
        }

        // PUT: api/Emp/5
        [HttpPut("{id}")]
        public async System.Threading.Tasks.Task<int> PutAsync([FromBody] Emp emp, int id)
        {
            emp.Id = id;
            // _empRepository.UpdateEmp(emp);
            return await employeService.UpdateEmp(emp);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async System.Threading.Tasks.Task<int> DeleteAsync(int id)
        {
            // _empRepository.DeleteEmp(id);
            return await employeService.DeleteEmp(id);
        }
    }
}
