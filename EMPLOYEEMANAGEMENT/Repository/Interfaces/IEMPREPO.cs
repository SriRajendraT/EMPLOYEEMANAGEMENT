using EMPLOYEEMANAGEMENT.Models;

namespace EMPLOYEEMANAGEMENT.Repository.Interfaces
{
    public interface IEMPREPO
    {
        Task<List<EmpExt>> GetAllEmps();
        Task<List<EmpExt>> GetAllEmpsByName(KeyValue kv);
        Task<EmpExt> GetEmpById(KeyValue kv);
        Task<bool> AddOrUpdateEmp(Employee employee);
        Task<bool> DeleteEmp(Employee employee);
        Task<int> GetTotalEmployeeCount();
    }
}
