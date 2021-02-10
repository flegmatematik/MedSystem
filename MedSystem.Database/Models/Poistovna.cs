using System.Collections.Generic;

namespace MedSystem.Database.Models
{
    public class Poistovna
    {
        public int PoistovnaId { get; set; }
        public string Nazov { get; set; }
        public string Adresa { get; set; }
        public string KodPoistovne { get; set; }
        public virtual List<Poistenec> Poistenci { get; set; }
    }
}
