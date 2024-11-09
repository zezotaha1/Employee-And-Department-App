using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Employee.Model
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        [Required]
        [MaxLength(100)]
        public string DepartmentName { get; set; }

        [MaxLength(100)]
        public string Location { get; set; }
        //true meen isActiv and false meen deleted
        [Required]
        public bool Status { get; set; } = true;

        public ICollection<_Employee> Employees { get; set; }
    }
}
