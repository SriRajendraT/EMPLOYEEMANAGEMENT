using System.ComponentModel.DataAnnotations;

namespace EMPLOYEEMANAGEMENT.Models
{
    public class Department
    {
        [Key]
        public int DEPTID { get; set; }
        public string DEPTNAME { get; set; }
    }
}
