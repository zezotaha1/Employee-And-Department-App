using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Employee.Model;
using Microsoft.EntityFrameworkCore;
using Employee.DTO;
using System.Net;
using System.Reflection;
using System;

namespace EmployeeP.Controllers
{
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult> GetAllEmployees()
        {
            var employeesList = await _context.Employees.ToListAsync();
            var _employees = new employeesDTO();
            _employees.employees=new List<employeeDTO>();
            foreach (var e in employeesList)
            {
                if (e.Status == true)
                {
                    _employees.employees.Add(new employeeDTO()
                    {
                        EmployeeID = e.EmployeeID,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        Gender = e.Gender,
                        DateOfBirth = DateOnly.FromDateTime(e.DateOfBirth),
                        HireDate = DateOnly.FromDateTime(e.HireDate),
                        JobTitle = e.JobTitle,
                        Email = e.Email,
                        PhoneNumber = e.PhoneNumber,
                        Salary = e.Salary,
                        Address = e.Address,
                        DepartmentID = e.DepartmentID,
                        Status = e.Status
                    });
                }
            }
            return Ok(_employees);
        }

        // GET: api/Employee/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployeeById(int id)
        {
            var e = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeID == id);
            if (e == null) return BadRequest("the employee not found");
            return Ok(new employeeDTO()
            {
                EmployeeID = e.EmployeeID,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Gender = e.Gender,
                DateOfBirth = DateOnly.FromDateTime(e.DateOfBirth),
                HireDate = DateOnly.FromDateTime(e.HireDate),
                JobTitle = e.JobTitle,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                Salary = e.Salary,
                Address = e.Address,
                DepartmentID = e.DepartmentID,
                Status = e.Status
            }
            );
        }

        // POST: api/Employee
        [HttpPost]
        public async Task<ActionResult> AddEmployee(employeeDTO employee)
        {
            if (employee == null)
            {
                return BadRequest("Null Opject");
            }
            try
            {
                if(_context.Departments.SingleOrDefault(d=>d.DepartmentID == employee.DepartmentID) == null)
                {
                    return BadRequest("the department not found");
                }

                var emp = new _Employee()
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Gender = employee.Gender,
                    DateOfBirth = employee.DateOfBirth.ToDateTime(new TimeOnly(0, 0)),
                    HireDate = employee.HireDate.ToDateTime(new TimeOnly(0,0)),
                    JobTitle = employee.JobTitle,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    Status = true,
                    Address = employee.Address,
                    DepartmentID = employee.DepartmentID,
                    PhoneNumber = employee.PhoneNumber
                };

                await _context.Employees.AddAsync(emp);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Employee/{id}
        [HttpPut]
        public async Task<ActionResult> UpdateEmployee(employeeDTO employee)
        {
            if (employee == null)
            {
                return BadRequest("Null Opject");
            }
            var emp = _context.Employees.SingleOrDefault(e => e.EmployeeID == employee.EmployeeID);

            if (emp is null) return BadRequest("the employee not found");


            try
            {
                
                if ((employee.DepartmentID!=null|| employee.DepartmentID !=0) &&_context.Departments.SingleOrDefault(d=>d.DepartmentID==employee.DepartmentID)is null)
                {
                    return BadRequest("this department ID is wromg"); 
                }

                

                emp.FirstName = employee.FirstName;
                emp.LastName = employee.LastName;
                emp.Gender = employee.Gender;
                emp.DateOfBirth = employee.DateOfBirth.ToDateTime(new TimeOnly(0,0));
                emp.HireDate = employee.HireDate.ToDateTime(new TimeOnly(0, 0));
                emp.JobTitle = employee.JobTitle;
                emp.Email = employee.Email;
                emp.PhoneNumber = employee.PhoneNumber;
                emp.Salary = employee.Salary;
                emp.Address = employee.Address;
                emp.Status = employee.Status;
                emp.DepartmentID = employee.DepartmentID;


                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Employees.Any(e => e.EmployeeID == employee.EmployeeID)) return NotFound();
                throw;
            }

            return Ok();
        }

        // DELETE: api/Employee/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var employee = _context.Employees.SingleOrDefault(e=>e.EmployeeID==id);
            if (employee == null) return BadRequest("the employee not found");

            employee.Status = false;
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
