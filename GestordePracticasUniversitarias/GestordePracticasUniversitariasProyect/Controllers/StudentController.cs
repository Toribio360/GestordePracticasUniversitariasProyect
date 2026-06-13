using GestordePracticasUniversitariasProyect.Data;
using GestordePracticasUniversitariasProyect.Models.DTOS.Student;
using GestordePracticasUniversitariasProyect.Models.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestordePracticasUniversitariasProyect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly DataContext _context;

        
        public StudentController(DataContext datacontext)
        {
            _context = datacontext;
        }

        // GET: api/student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListStudentDto>>> Get()
        {
            var students = await _context.Students
                .Select(student => new ListStudentDto
                {
                    Id = student.Id,
                    Name = student.Name,
                    Lastname = student.Lastname,
                    PhoneNumber = student.PhoneNumber,
                    Address = student.Address,
                    IsActive = student.IsActive
                })
                .ToListAsync();

            return Ok(students);
        }

        // GET: api/student/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ListStudentDto>> GetById(int id)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(x => x.Id == id);

            if (student == null)
                return NotFound($"No se encontró el estudiante con ID {id}");

            var dto = new ListStudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Lastname = student.Lastname,
                PhoneNumber = student.PhoneNumber,
                Address = student.Address,
                IsActive = student.IsActive
            };

            return Ok(dto);
        }

        // POST: api/student
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateStudentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var student = new Student
            {
                Name = dto.Name,
                Lastname = dto.Lastname,
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address,
                CompanyId = dto.CompanyId,
                IsActive = true
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetById),
                new { id = student.Id },
                student
            );
        }

        // PUT: api/student/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CreateStudentDto dto)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (student == null)
                return NotFound($"No se encontró el estudiante con ID {id}");

            student.Name = dto.Name;
            student.Lastname = dto.Lastname;
            student.PhoneNumber = dto.PhoneNumber;
            student.Address = dto.Address;
            student.CompanyId = dto.CompanyId;

            await _context.SaveChangesAsync();

            return Ok(student);
        }

        // DELETE: api/student/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (student == null)
                return NotFound($"No se encontró el estudiante con ID {id}");

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}