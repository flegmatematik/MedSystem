using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MedSystem.Database.Models
{
    public class Ockovanie
    {
        public int Id { get; set; }

        [Required]
        public int IdOckovanie { get; set; }
        public virtual TypOckovania TypOckovania { get; set; }

        [Required]
        public int IdPacient { get; set; } 
        public virtual Pacient Pacient { get; set; }

        [Required]
        public DateTime DatumOckovania { get; set; }
        [AllowNull]
        public string PopisReakcie { get; set; }
    }
}
