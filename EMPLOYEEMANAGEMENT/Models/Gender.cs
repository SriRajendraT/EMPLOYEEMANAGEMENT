using System.ComponentModel.DataAnnotations;

namespace EMPLOYEEMANAGEMENT.Models
{
    public class Gender
    {
        [Key]
        public int GENDERID { get; set; }
        public string GENDERNAME { get; set; }
    }
}
