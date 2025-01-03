using EMPLOYEEMANAGEMENT.Models;

namespace EMPLOYEEMANAGEMENT.Repository.Interfaces
{
    public interface IBASICGETS
    {
        Task<List<Gender>> GetAllGenders();
        Task<List<Department>> GetAllDepts();
        Task<List<State>> GetAllStates();
        Task<List<City>> GetCitiesByState(KeyValue kv);
    }
}
