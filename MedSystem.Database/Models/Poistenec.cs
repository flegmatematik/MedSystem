using System;
using System.ComponentModel.DataAnnotations;

namespace MedSystem.Database.Models
{
    public class Poistenec
    {
        public int Id { get; set; }
        public DateTime PlatnostOd { get; set; }
        public DateTime PlatnostDo { get; set; }

        [Required]
        public int PoistovnaId { get; set; }
        public virtual Poistovna Poistovna { get; set; }

        [Required]
        public int PacientId { get; set; }
        public virtual Pacient Pacient { get; set; }
    }
}
