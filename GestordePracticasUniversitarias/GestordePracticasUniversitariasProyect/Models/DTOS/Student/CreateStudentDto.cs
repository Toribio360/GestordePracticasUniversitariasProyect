using System.ComponentModel.DataAnnotations;

namespace GestordePracticasUniversitariasProyect.Models.DTOS.Student
{
    public class CreateStudentDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
    
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio")]
      
        public string Lastname { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es obligatorio")]

        public string PhoneNumber { get; set; } = string.Empty;

        public string? Address { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe indicar una empresa válida")]
        public int CompanyId { get; set; }
    }
}