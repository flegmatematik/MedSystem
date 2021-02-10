using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using APIMedSystem.DBEF;
using APIMedSystem.DTOS.Login;
using APIMedSystem.DTOS.Osoba;
using APIMedSystem.DTOS.Uzivatel;
using AutoMapper;
using MedSystem.Database;
using MedSystem.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace APIMedSystem.Services.LoginService
{
    /// <summary>
    /// Service ktorý poskytuje možnosti prihlásenia a registrácie
    /// </summary>
    public class LoginService : ILoginService
    {
        private readonly IMapper _mapper;

        private readonly MedSystemDatabaseContext _context;

        public LoginService(MedSystemDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Z formulára poskytnutom pri registrácií - RegisterDto, vytvorí jednotlivé záznamy na uloženie v databáze.
        /// Heslá sa hashujú a saltujú. Nedovoľuje vytvoriť užívateľa s už existujúcim emailom alebo rodným číslom
        /// </summary>
        /// <param name="novyUzivatelDto"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<GetUzivatelDto>> RegisterUser(RegisterDto novyUzivatelDto)
        {
            ServiceResponse<GetUzivatelDto> serviceResponse = new ServiceResponse<GetUzivatelDto>();

            if (!_context.Osoby.Any(o => o.RodneCislo == novyUzivatelDto.RodneCislo) && !_context.Accounts.Any(a => a.Email == novyUzivatelDto.Email))
            {
                //Osoba
                Osoba osoba = _mapper.Map<Osoba>(novyUzivatelDto);
                await _context.Osoby.AddAsync(osoba);
                await _context.SaveChangesAsync();

                //Uzivatel
                Uzivatel uzivatel = _mapper.Map<Uzivatel>(novyUzivatelDto);
                uzivatel.OsobaId = osoba.Id;
                await _context.Uzivatelia.AddAsync(uzivatel);

                //Pacient
                Pacient pacient = new Pacient() { OsobaId = osoba.Id };
                await _context.Pacienti.AddAsync(pacient);

                await _context.SaveChangesAsync();

                //Account info
                AccountInfo accountInfo = _mapper.Map<AccountInfo>(novyUzivatelDto);
                accountInfo.Uzivatel = uzivatel;
                var salt = GenerateSalt();
                var hash = Pbkdf2Hash(novyUzivatelDto.Heslo, salt);
                accountInfo.Salt = salt;
                accountInfo.Password = hash;

                await _context.Accounts.AddAsync(accountInfo);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetUzivatelDto>(uzivatel);
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "User with this username or id number is already registered";
            }
            return serviceResponse;

        }

        /// <summary>
        /// Metóda podľa prihlasovacieho formulára zistí, či sa daný užívateľ nachádza v databáze
        /// Následne sa overí jeho heslo a následne odošle odozvu v podobe údajov o užívateľovi
        /// </summary>
        /// <param name="prihlasovacieUdaje"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<GetOsobaDto>> LoginUser(LoginDto prihlasovacieUdaje)
        {
            ServiceResponse<GetOsobaDto> serviceResponse = new ServiceResponse<GetOsobaDto>();

            AccountInfo account = await 
                _context.Accounts.FirstOrDefaultAsync(a => a.Email == prihlasovacieUdaje.Email);

            if (account != null)
            {
                var hash = Pbkdf2Hash(prihlasovacieUdaje.Heslo, account.Salt);

                if (hash.SequenceEqual(account.Password))
                {
                    serviceResponse.Success = true;
                    serviceResponse.Data = _mapper.Map<GetOsobaDto>(account.Uzivatel.Osoba);

                    return serviceResponse;
                }
            }

            serviceResponse.Success = false;
            serviceResponse.Message = "Nesprávne meno alebo heslo.";
            
            return serviceResponse;
        }

        /// <summary>
        /// Hash ktorý na základe poskytnutého hesla a saltu, vytvorí hash na uloženie do databázy
        /// alebo na spätné zistenie správneho hesla
        /// </summary>
        /// <param name="input"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        private static byte[] Pbkdf2Hash(string input, byte[] salt)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(input, salt, iterations: 5000);
            return pbkdf2.GetBytes(20);
        }

        /// <summary>
        /// Metóda na vygenerovanie saltu
        /// </summary>
        /// <returns></returns>
        private static byte[] GenerateSalt()
        {
            var random = new RNGCryptoServiceProvider();
            byte[] salt = new byte[32];
            random.GetNonZeroBytes(salt);

            return salt;
        }
    }
}
