using System.ComponentModel.DataAnnotations;

namespace EMPLOYEEMANAGEMENT.Models
{
    public class Employee
    {
        [Key]
        public int EMPID { get; set; }
        public string EMPNAME { get; set; }
        public string EMPEMAIL { get; set; }
        public string EMPPHONE { get; set; }
        public string EMPADDRESS { get; set; }
        public int EMPGENDER { get; set; }
        public int EMPSTATE { get; set; }
        public int EMPCITY { get; set; }
        public int EMPDEPT { get; set; }
        public decimal EMPSAL { get; set; }
        //public DateTime EMPDOJ { get; set; }
        //public DateTime EMPDOB { get; set; }
        public char ACTIVEFLAG { get; set; }
        public char DELETEFLAG { get; set; }
    }

    public class EmpExt : Employee
    {
        public string EMPGENDERNAME { get; set; }
        public string EMPSTATENAME { get; set; }
        public string EMPCITYNAME { get; set; }
        public string EMPDEPTNAME { get; set; }
    }
}
