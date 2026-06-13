using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace GestordePracticasUniversitariasProyect.Models.Entites
{
    public class  Company
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } =string.Empty;

        public List<Student> Students { get; set; } = new();
    

        public bool IsActive { get; set; } = true;


    }
}
