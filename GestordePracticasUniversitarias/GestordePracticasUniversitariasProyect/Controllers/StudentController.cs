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
        public IEnumerable<Student> Get()
        {
            return Students;
        }

        // GET: api/student/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = Students.FirstOrDefault(x => x.Id == id);

            if (student == null)
                return NotFound($"No se encontró el estudiante con ID {id}");

            return Ok(student);
        }

        // POST: api/student
        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (Students.Any(x => x.Id == student.Id))
                return BadRequest($"Ya existe un estudiante con ID {student.Id}");

            Students.Add(student);

            return CreatedAtAction(
                nameof(GetById),
                new { id = student.Id },
                student
            );
        }

        // PUT: api/student/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student studentUpdate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var student = Students.FirstOrDefault(x => x.Id == id);

            if (student == null)
                return NotFound($"No se encontró el estudiante con ID {id}");

            student.Name = studentUpdate.Name;
            student.Lastname = studentUpdate.Lastname;
            student.PhoneNumber = studentUpdate.PhoneNumber;
            student.Address = studentUpdate.Address;
            student.IsActive = studentUpdate.IsActive;

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