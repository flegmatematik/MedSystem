namespace APIMedSystem.DTOS.Vysetrenie
{
    public class AddVysetrenieDto
    {
        public string Ambulancia { get; set; }
        public int TypVysetreniaId { get; set; }
        public int PacientId { get; set; }
        public int ZPersonalId { get; set; }

    }
}
