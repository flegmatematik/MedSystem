using MedSystem.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace MedSystem.Database
{
    
    public class MedSystemDatabaseContext : DbContext
    {
        public DbSet<AccountInfo> Accounts { get; set; }
        public DbSet<Uzivatel> Uzivatelia { get; set; }
        public DbSet<Pacient> Pacienti { get; set; }
        public DbSet<Osoba> Osoby { get; set; }
        public DbSet<ZPersonal> Personal { get; set; }
        public DbSet<Poistovna> Poistovne { get; set; }
        public DbSet<Poistenec> Poistenci { get; set; }
        public DbSet<Vysetrenie> Vysetrenia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(
                @"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog = MedSystem.Dbo; MultipleActiveResultSets=True; Integrated Security = True; Connect Timeout = 30");
        }
    }
}
