using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Employee.Model
{
    public class _Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        //true meen male and false meen women
        public bool Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public DateTime HireDate { get; set; }

        [MaxLength(50)]
        public string JobTitle { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(11)]
        public string PhoneNumber { get; set; }

        public double Salary { get; set; }
        
        [MaxLength(200)]
        public string Address { get; set; }

        //true meen isActiv and false meen deleted
        [Required]
        public bool Status { get; set; } =true;

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }

        public int? ManagerID { get; set; }
        public _Employee Manager { get; set; }

    }
}
