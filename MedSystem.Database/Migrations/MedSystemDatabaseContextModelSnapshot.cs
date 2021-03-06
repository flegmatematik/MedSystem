﻿// <auto-generated />
using System;
using MedSystem.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MedSystem.Database.Migrations
{
    [DbContext(typeof(MedSystemDatabaseContext))]
    partial class MedSystemDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MedSystem.Database.Models.AccountInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(20)")
                        .HasMaxLength(20);

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("varbinary(32)")
                        .HasMaxLength(32);

                    b.Property<int>("UzivatelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UzivatelId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("MedSystem.Database.Models.Ockovanie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumOckovania")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdOckovanie")
                        .HasColumnType("int");

                    b.Property<int>("IdPacient")
                        .HasColumnType("int");

                    b.Property<int?>("PacientId")
                        .HasColumnType("int");

                    b.Property<string>("PopisReakcie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TypOckovaniaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PacientId");

                    b.HasIndex("TypOckovaniaId");

                    b.ToTable("Ockovanie");
                });

            modelBuilder.Entity("MedSystem.Database.Models.Osoba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CeleMeno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RodneCislo")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Osoby");
                });

            modelBuilder.Entity("MedSystem.Database.Models.Pacient", b =>
                {
                    b.Property<int>("PacientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OsobaId")
                        .HasColumnType("int");

                    b.HasKey("PacientId");

                    b.HasIndex("OsobaId")
                        .IsUnique();

                    b.ToTable("Pacienti");
                });

            modelBuilder.Entity("MedSystem.Database.Models.Poistenec", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PacientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PlatnostDo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PlatnostOd")
                        .HasColumnType("datetime2");

                    b.Property<int>("PoistovnaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PacientId");

                    b.HasIndex("PoistovnaId");

                    b.ToTable("Poistenci");
                });

            modelBuilder.Entity("MedSystem.Database.Models.Poistovna", b =>
                {
                    b.Property<int>("PoistovnaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KodPoistovne")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazov")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PoistovnaId");

                    b.ToTable("Poistovne");
                });

            modelBuilder.Entity("MedSystem.Database.Models.TypOckovania", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazov")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vyrobca")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypOckovania");
                });

            modelBuilder.Entity("MedSystem.Database.Models.TypVysetrenia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazov")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Popis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Skratka")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypVysetrenia");
                });

            modelBuilder.Entity("MedSystem.Database.Models.Uzivatel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OsobaId")
                        .HasColumnType("int");

                    b.Property<string>("TelefonneCislo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypPristupu")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OsobaId")
                        .IsUnique();

                    b.ToTable("Uzivatelia");
                });

            modelBuilder.Entity("MedSystem.Database.Models.Vysetrenie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ambulancia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ObjednanePacientom")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ObjednanyTermin")
                        .HasColumnType("datetime2");

                    b.Property<int>("PacientId")
                        .HasColumnType("int");

                    b.Property<bool>("PotvrdeneDoktorom")
                        .HasColumnType("bit");

                    b.Property<DateTime>("RealnyTermin")
                        .HasColumnType("datetime2");

                    b.Property<int>("TypVysetreniaId")
                        .HasColumnType("int");

                    b.Property<int>("ZPersonalId")
                        .HasColumnType("int");

                    b.Property<string>("Zaznam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PacientId");

                    b.HasIndex("TypVysetreniaId");

                    b.HasIndex("ZPersonalId");

                    b.ToTable("Vysetrenia");
                });

            modelBuilder.Entity("MedSystem.Database.Models.ZPersonal", b =>
                {
                    b.Property<int>("ZPersonalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ambulancia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OsobaId")
                        .HasColumnType("int");

                    b.Property<string>("Pozicia")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ZPersonalId");

                    b.HasIndex("OsobaId");

                    b.ToTable("Personal");
                });

            modelBuilder.Entity("MedSystem.Database.Models.AccountInfo", b =>
                {
                    b.HasOne("MedSystem.Database.Models.Uzivatel", "Uzivatel")
                        .WithMany()
                        .HasForeignKey("UzivatelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedSystem.Database.Models.Ockovanie", b =>
                {
                    b.HasOne("MedSystem.Database.Models.Pacient", "Pacient")
                        .WithMany("Ockovanie")
                        .HasForeignKey("PacientId");

                    b.HasOne("MedSystem.Database.Models.TypOckovania", "TypOckovania")
                        .WithMany()
                        .HasForeignKey("TypOckovaniaId");
                });

            modelBuilder.Entity("MedSystem.Database.Models.Pacient", b =>
                {
                    b.HasOne("MedSystem.Database.Models.Osoba", "Osoba")
                        .WithOne("Pacient")
                        .HasForeignKey("MedSystem.Database.Models.Pacient", "OsobaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedSystem.Database.Models.Poistenec", b =>
                {
                    b.HasOne("MedSystem.Database.Models.Pacient", "Pacient")
                        .WithMany()
                        .HasForeignKey("PacientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedSystem.Database.Models.Poistovna", "Poistovna")
                        .WithMany("Poistenci")
                        .HasForeignKey("PoistovnaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedSystem.Database.Models.Uzivatel", b =>
                {
                    b.HasOne("MedSystem.Database.Models.Osoba", "Osoba")
                        .WithOne("Uzivatel")
                        .HasForeignKey("MedSystem.Database.Models.Uzivatel", "OsobaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedSystem.Database.Models.Vysetrenie", b =>
                {
                    b.HasOne("MedSystem.Database.Models.Pacient", "Pacient")
                        .WithMany("Vysetrenie")
                        .HasForeignKey("PacientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedSystem.Database.Models.TypVysetrenia", "TypVysetrenia")
                        .WithMany()
                        .HasForeignKey("TypVysetreniaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedSystem.Database.Models.ZPersonal", "ZPersonal")
                        .WithMany()
                        .HasForeignKey("ZPersonalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedSystem.Database.Models.ZPersonal", b =>
                {
                    b.HasOne("MedSystem.Database.Models.Osoba", "OsobaPersonalu")
                        .WithMany()
                        .HasForeignKey("OsobaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
