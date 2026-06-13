using System.ComponentModel.DataAnnotations;

namespace GestordePracticasUniversitariasProyect.Models.Entites
{
    public class Student
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Lastname { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string? Address { get; set; }

        public bool IsActive { get; set; } = true;


    }
}
