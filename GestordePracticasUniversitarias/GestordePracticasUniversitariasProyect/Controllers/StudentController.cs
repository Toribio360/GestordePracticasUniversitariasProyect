using GestordePracticasUniversitariasProyect.Models.DTOS.Student;
using GestordePracticasUniversitariasProyect.Models.Entites;
using Microsoft.AspNetCore.Mvc;

namespace GestordePracticasUniversitariasProyect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private static List<Student> Students = new();

        // GET: api/student
        [HttpGet]
        public ActionResult<IEnumerable<ListStudentDto>> Get()
        {
            var students = Students.Select(student => new ListStudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Lastname = student.Lastname,
                PhoneNumber = student.PhoneNumber,
                Address = student.Address,
                IsActive = student.IsActive
            }).ToList();

            return Ok(students);
        }

        // GET: api/student/1
        [HttpGet("{id}")]
        public ActionResult<ListStudentDto> GetById(int id)
        {
            var student = Students.FirstOrDefault(x => x.Id == id);

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
        public IActionResult Post([FromBody] CreateStudentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var student = new Student
            {
                Id = Students.Count == 0 ? 1 : Students.Max(x => x.Id) + 1,
                Name = dto.Name,
                Lastname = dto.Lastname,
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address,
                IsActive = true
            };

            Students.Add(student);

            return CreatedAtAction(
                nameof(GetById),
                new { id = student.Id },
                student
            );
        }

        // PUT: api/student/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CreateStudentDto dto)
        {
            var student = Students.FirstOrDefault(x => x.Id == id);

            if (student == null)
                return NotFound($"No se encontró el estudiante con ID {id}");

            student.Name = dto.Name;
            student.Lastname = dto.Lastname;
            student.PhoneNumber = dto.PhoneNumber;
            student.Address = dto.Address;

            return Ok(student);
        }

        // DELETE: api/student/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = Students.FirstOrDefault(x => x.Id == id);

            if (student == null)
                return NotFound($"No se encontró el estudiante con ID {id}");

            Students.Remove(student);

            return NoContent();
        }
    }
}