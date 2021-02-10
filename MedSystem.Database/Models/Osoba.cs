namespace MedSystem.Database.Models
{
    public class Osoba
    {
        public int Id { get; set; }
        public long RodneCislo { get; set; }
        public string CeleMeno { get; set; }
        public string Adresa { get; set; }

        public virtual Pacient Pacient { get; set; }

        public virtual Uzivatel Uzivatel { get; set; }
    }
}
