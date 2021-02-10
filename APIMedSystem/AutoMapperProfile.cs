using APIMedSystem.DTOS.Login;
using APIMedSystem.DTOS.Osoba;
using APIMedSystem.DTOS.Uzivatel;
using APIMedSystem.DTOS.Vysetrenie;
using AutoMapper;
using MedSystem.Database.Models;

namespace APIMedSystem
{
    /// <summary>
    /// Profil automappera v ktorom sú definované jednotlivé mapy podľa ktorých dokáže automapper premieňať dáta z databázy
    /// na Dto a naopak 
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Osoba, GetOsobaDto>();
            CreateMap<AddOsobaDto, Osoba>();

            CreateMap<Uzivatel, GetUzivatelDto>();
            CreateMap<AddUzivatelDto, Uzivatel>();

            CreateMap<LoginDto, AccountInfo>();

            CreateMap<RegisterDto, AccountInfo>();
            CreateMap<RegisterDto, Osoba>();
            CreateMap<RegisterDto, Uzivatel>();

            // veľmi specifická mapa, ktorá sa musela manuálne zostrojiť
            CreateMap<Vysetrenie, GetVysetrenieDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Ambulancia, opt => opt.MapFrom(s => s.Ambulancia))
                .ForMember(t => t.ObjednanyTermin, opt => opt.MapFrom(s => s.ObjednanyTermin))
                .ForMember(t => t.RealnyTermin, opt => opt.MapFrom(s => s.RealnyTermin))
                .ForMember(t => t.PotvrdeneDoktorom, opt => opt.MapFrom(s => s.PotvrdeneDoktorom))
                .ForMember(t => t.ObjednanePacientom, opt => opt.MapFrom(s => s.ObjednanePacientom))
                .ForMember(t => t.MenoPacienta, opt => opt.MapFrom(s => s.Pacient.Osoba.CeleMeno))
                .ForMember(t => t.RodneCisloPacienta, opt => opt.MapFrom(s => s.Pacient.Osoba.RodneCislo))
                .ForMember(t => t.NazovVysetrenia, opt => opt.MapFrom(s => s.TypVysetrenia.Nazov))
                .ForMember(t => t.MenoDoktora, opt => opt.MapFrom(s => s.ZPersonal.OsobaPersonalu.CeleMeno));

            CreateMap<AddVysetrenieDto, Vysetrenie>();
        }
    }
}
