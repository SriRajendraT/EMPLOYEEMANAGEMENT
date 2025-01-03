using System.ComponentModel.DataAnnotations.Schema;

namespace EMPLOYEEMANAGEMENT.Models
{
    [NotMapped]
    public class KeyValue
    {
        public int key1 { get; set; }
        public int key2 { get; set; }
        public int key3 { get; set; }
        public string value1 { get; set; }
        public string value2 { get; set; }
        public string value3 { get; set; }
    }
}
