using GestordePracticasUniversitariasProyect.Models.Entites;
using Microsoft.AspNetCore.Mvc;

namespace GestordePracticasUniversitariasProyect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private static List<Company> Companies = new();

        // GET: api/company
        [HttpGet]
        public IEnumerable<Company> Get()
        {
            return Companies;
        }

        // GET: api/company/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var company = Companies.FirstOrDefault(x => x.Id == id);

            if (company == null)
                return NotFound($"No se encontró la empresa con ID {id}");

            return Ok(company);
        }

        // POST: api/company
        [HttpPost]
        public IActionResult Post([FromBody] Company company)
        {
            if (Companies.Any(x => x.Id == company.Id))
                return BadRequest($"Ya existe una empresa con ID {company.Id}");

            Companies.Add(company);

            return CreatedAtAction(
                nameof(GetById),
                new { id = company.Id },
                company
            );
        }

        // PUT: api/company/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Company companyUpdate)
        {
            var company = Companies.FirstOrDefault(x => x.Id == id);

            if (company == null)
                return NotFound($"No se encontró la empresa con ID {id}");

            company.Name = companyUpdate.Name;
            company.Address = companyUpdate.Address;
            company.IsActive = companyUpdate.IsActive;

            return Ok(company);
        }

        // DELETE: api/company/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var company = Companies.FirstOrDefault(x => x.Id == id);

            if (company == null)
                return NotFound($"No se encontró la empresa con ID {id}");

            Companies.Remove(company);

            return NoContent();
        }
    }
}