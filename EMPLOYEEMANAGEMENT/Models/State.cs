using System.ComponentModel.DataAnnotations;

namespace EMPLOYEEMANAGEMENT.Models
{
    public class State
    {
        [Key]
        public int STATEID { get; set; }
        public string STATENAME { get; set; }
    }
}
