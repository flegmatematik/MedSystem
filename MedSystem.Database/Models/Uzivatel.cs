using System.ComponentModel.DataAnnotations;

namespace MedSystem.Database.Models
{
    public class Uzivatel
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        public string TelefonneCislo { get; set; }
        public TypPristupu TypPristupu { get; set; }

        [Required]
        public int OsobaId { get; set; }
        public virtual Osoba Osoba { get; set; }
    }
}
