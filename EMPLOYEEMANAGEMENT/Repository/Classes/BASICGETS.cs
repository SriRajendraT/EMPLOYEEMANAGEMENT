using EMPLOYEEMANAGEMENT.DAL;
using EMPLOYEEMANAGEMENT.Models;
using EMPLOYEEMANAGEMENT.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EMPLOYEEMANAGEMENT.Repository.Classes
{
    public class BASICGETS : IBASICGETS
    {
        private readonly AppDbContext _dbContext;

        public BASICGETS(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Department>> GetAllDepts()
        {
            return await _dbContext.Departments.ToListAsync();
        }

        public async Task<List<Gender>> GetAllGenders()
        {
            return await _dbContext.Genders.ToListAsync();
        }

        public async Task<List<State>> GetAllStates()
        {
            return await _dbContext.States.ToListAsync();
        }

        public async Task<List<City>> GetCitiesByState(KeyValue kv)
        {
            return await _dbContext.Cities.Where(x=>x.STATEID == kv.key1).ToListAsync();
        }
    }
}
