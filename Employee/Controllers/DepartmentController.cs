using Employee.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee.Controllers
{
    [Route("api/Department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Department
        [HttpGet]
        public async Task<ActionResult> GetAllDepartments()
        {
            var departments = await _context.Departments.ToListAsync();
            return Ok(departments);
        }

        // GET: api/Department/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult> GetDepartmentById(int id)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentID == id&&d.Status==true);
            if (department == null) return NotFound();
            return Ok(department);
        }

        // POST: api/Department
        [HttpPost]
        public async Task<ActionResult> AddDepartment(Department department)
        {
            if (department == null)
            {
                return BadRequest("Null Opject");
            }
            try
            {
                _context.Departments.Add(department);
                await _context.SaveChangesAsync();
                return Ok(department);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Department/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDepartment(int id, Department department)
        {
            if (department == null)
            {
                return BadRequest("Null Opject");
            }

            if (id != department.DepartmentID) return BadRequest();

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Departments.Any(d => d.DepartmentID == id)) return NotFound();
                throw;
            }

            return Ok("Updated Done");
        }

        // DELETE: api/Department/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null) return NotFound();

            department.Status=false;

            await _context.SaveChangesAsync();
            return Ok("Deleted Done");
        }
    }
}
