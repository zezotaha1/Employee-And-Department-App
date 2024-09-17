using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Employee.Model;
using Microsoft.EntityFrameworkCore;

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
            var employees = await _context.Employees.ToListAsync();
            return Ok(employees);
        }

        // GET: api/Employee/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployeeById(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeID == id&&e.Status==true);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        // POST: api/Employee
        [HttpPost]
        public async Task<ActionResult> AddEmployee(_Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Null Opject");
            }
            try
            {
                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();
                return Ok(employee);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Employee/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, _Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Null Opject");
            }

            if (id != employee.EmployeeID) return BadRequest();


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Employees.Any(e => e.EmployeeID == id)) return NotFound();
                throw;
            }

            return Ok("Updated Done");
        }

        // DELETE: api/Employee/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();

            employee.Status = false;
            await _context.SaveChangesAsync();
            return Ok("Deleted Done");
        }
    }
}
