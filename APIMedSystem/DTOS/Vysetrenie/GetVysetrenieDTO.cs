using System;

namespace APIMedSystem.DTOS.Vysetrenie
{
    public class GetVysetrenieDto
    {
        public int Id { get; set; }
        public bool PotvrdeneDoktorom { get; set; }
        public bool ObjednanePacientom { get; set; }
        public DateTime ObjednanyTermin { get; set; }
        public DateTime RealnyTermin { get; set; }
        public string Ambulancia { get; set; }
        public string NazovVysetrenia { get; set; }
        public string MenoPacienta { get; set; }
        public long RodneCisloPacienta { get; set; }
        public string MenoDoktora { get; set; }
    }
}
