using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Employee.DTO
{
    public class departmentDTO
    {
        public int DepartmentID { get; set; }

        [Required]
        [MaxLength(100)]
        public string DepartmentName { get; set; }
        public string Location { get; set; }
        //true meen isActiv and false meen deleted
        public bool Status { get; set; }
    }
}
