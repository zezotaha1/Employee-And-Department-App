using Employee.DTO;
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
            var deps = await _context.Departments.ToListAsync();

            var departments = new departmentsDTO();
            departments.departments = new List<departmentDTO>();
            foreach (var e in deps)
            {
                if (e.Status == true)
                {
                    departments.departments.Add(new departmentDTO()
                    {
                        DepartmentID = e.DepartmentID,
                        DepartmentName = e.DepartmentName,
                        Location = e.Location,
                        Status = e.Status
                    });
                }
            }
            return Ok(departments);
        }

        // GET: api/Department/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult> GetDepartmentById(int id)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentID == id);
            if (department == null) return BadRequest("this department not found");

            return Ok(new departmentDTO()
            {
                DepartmentID = department.DepartmentID,
                DepartmentName = department.DepartmentName,
                Location = department.Location,
                Status = department.Status
            });
        }

        // POST: api/Department
        [HttpPost]
        public async Task<ActionResult> AddDepartment(departmentDTO department)
        {
            if (department == null)
            {
                return BadRequest("Null Opject");
            }
            try
            {
                _context.Departments.Add(new Department()
                {
                    DepartmentName= department.DepartmentName,
                    Location = department.Location,
                    Status =true,
                });
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Department/{id}
        [HttpPut]
        public async Task<ActionResult> UpdateDepartment(departmentDTO department)
        {
            if (department == null)
            {
                return BadRequest("Null Opject");
            }
            var dep = _context.Departments.SingleOrDefault(d => d.DepartmentID == department.DepartmentID);
            if (dep == null)
            {
                return BadRequest("this department not found" );
            }

            try
            {
                
                dep.DepartmentName= department.DepartmentName;
                dep.Status = department.Status;
                dep.Location = department.Location;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Departments.Any(d => d.DepartmentID == department.DepartmentID)) return NotFound();
                throw;
            }

            return Ok();
        }

        // DELETE: api/Department/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            var department =  _context.Departments.SingleOrDefault(d=>d.DepartmentID==id);
            if (department == null) return BadRequest("this department not found");

            department.Status = false;

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
