using System.ComponentModel.DataAnnotations;

namespace Employee.DTO
{
    public class employeeDTO
    {
        public int EmployeeID { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        //true meen male and false meen women
        public bool Gender { get; set; }

        [Required]
        public DateOnly DateOfBirth { get; set; }

        public DateOnly HireDate { get; set; }

        [MaxLength(50)]
        public string JobTitle { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(11)]
        public string PhoneNumber { get; set; }

        public double Salary { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }
        public int DepartmentID { get; set; }
        public bool Status { get; set; }
    }
}
