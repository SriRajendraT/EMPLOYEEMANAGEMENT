using EMPLOYEEMANAGEMENT.Models;
using EMPLOYEEMANAGEMENT.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMPLOYEEMANAGEMENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicGetController : ControllerBase
    {
        private readonly IBASICGETS _BASICGETS;

        public BasicGetController(IBASICGETS bASICGETS)
        {
            _BASICGETS = bASICGETS;
        }

        [HttpPost("GetAllGenders")]
        public async Task<List<Gender>> GetAllGenders()
        {
            var genders = await _BASICGETS.GetAllGenders();
            return genders;
        }

        [HttpPost("GetAllDepts")]
        public async Task<List<Department>> GetAllDepts()
        {
            var depts = await _BASICGETS.GetAllDepts();
            return depts;
        }

        [HttpPost("GetAllStates")]
        public async Task<List<State>> GetAllStates()
        {
            var st = await _BASICGETS.GetAllStates();
            return st;
        }

        [HttpPost("GetCitiesByStates")]
        public async Task<List<City>> GetCitiesByStates([FromBody] KeyValue kv)
        {
            var cty = await _BASICGETS.GetCitiesByState(kv);
            return cty;
        }
    }
}
