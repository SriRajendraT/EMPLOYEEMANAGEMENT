using System.ComponentModel.DataAnnotations;

namespace EMPLOYEEMANAGEMENT.Models
{
    public class City
    {
        [Key]
        public int CITYID { get; set; }
        public string CITYNAME { get; set; }
        public int STATEID { get; set; }
    }
}
