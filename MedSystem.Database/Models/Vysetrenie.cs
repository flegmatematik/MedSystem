using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MedSystem.Database.Models
{
    public class Vysetrenie
    {
        public int Id { get; set; }
        public string Zaznam { get; set; }
        public bool PotvrdeneDoktorom { get; set; }
        public bool ObjednanePacientom { get; set; }
        [AllowNull]
        public DateTime ObjednanyTermin { get; set; }
        [AllowNull]
        public DateTime RealnyTermin { get; set; }
        public string Ambulancia { get; set; }

        [Required]
        public int TypVysetreniaId { get; set; }
        public virtual TypVysetrenia TypVysetrenia { get; set; }

        [Required]
        public int PacientId { get; set; }
        public virtual Pacient Pacient { get; set; }

        [Required]
        public int ZPersonalId { get; set; }
        public virtual ZPersonal ZPersonal { get; set; }

    }
}
