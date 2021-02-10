using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedSystem.Database.Models
{
    public class Pacient
    {
        public int PacientId { get; set; }

        [Required]
        public int OsobaId { get; set; }
        public virtual Osoba Osoba { get; set; }
        public virtual List<Vysetrenie> Vysetrenie { get; set; }
        public virtual List<Ockovanie> Ockovanie { get; set; }

    }
}
