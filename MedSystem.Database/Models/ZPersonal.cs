using System.ComponentModel.DataAnnotations;

namespace MedSystem.Database.Models
{
    public class ZPersonal
    {
        public int ZPersonalId { get; set; }
        public string Pozicia { get; set; }
        public string Ambulancia { get; set; }

        [Required]
        public int OsobaId { get; set; }
        public virtual Osoba OsobaPersonalu { get; set; }
    }
}
