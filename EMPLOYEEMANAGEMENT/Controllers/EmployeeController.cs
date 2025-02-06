using EMPLOYEEMANAGEMENT.Models;
using EMPLOYEEMANAGEMENT.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMPLOYEEMANAGEMENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEMPREPO _EREPO;

        public EmployeeController(IEMPREPO eREPO)
        {
            _EREPO = eREPO;
        }

        [HttpPost("GetAllEmps")]
        public async Task<List<EmpExt>> GetAllEmps()
        {
            var emps = await _EREPO.GetAllEmps();
            return emps;
        }

        [HttpPost("GetEmpsByName")]
        public async Task<List<EmpExt>> GetEmpsByName([FromBody] KeyValue kv)
        {
            var emp = await _EREPO.GetAllEmpsByName(kv);
            return emp;
        }

        [HttpPost("GetEmpById")]
        public async Task<EmpExt> GetEmpById([FromBody] KeyValue kv)
        {
            var emp = await _EREPO.GetEmpById(kv);
            return emp;
        }

        [HttpPost("AddorUpdateEmp")]
        public async Task<bool> AddorUpdateEmp([FromBody] Employee employee)
        {
            return await _EREPO.AddOrUpdateEmp(employee);
        }

        [HttpPost("DeleteEmp")]
        public async Task<bool> DeleteEmp([FromBody] Employee employee)
        {
            return await _EREPO.DeleteEmp(employee);
        }
    }
}
