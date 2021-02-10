namespace APIMedSystem.DTOS.Uzivatel
{
    public class AddUzivatelDto
    {
        public string Email { get; set; }
        public string TelefonneCislo { get; set; }
        //public TypPristupu TypPristupu { get; set; }
        public int OsobaId { get; set; }
    }
}
