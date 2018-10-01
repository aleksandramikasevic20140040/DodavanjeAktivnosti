﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using NNProjekat.Data;
using System;

namespace NNProjekat.Migrations
{
    [DbContext(typeof(NNProjekatDbContext))]
    [Migration("20181001183149_ThirdMigration")]
    partial class ThirdMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NNProjekat.Models.Aktivnost", b =>
                {
                    b.Property<string>("SifraAktivnosti");

                    b.Property<string>("SifraPredmeta");

                    b.Property<double>("MaxBrojPoena");

                    b.Property<double>("MinBrojPoena");

                    b.Property<string>("Naziv");

                    b.Property<bool>("Obavezna");

                    b.Property<double>("TezinskiKoeficijent");

                    b.HasKey("SifraAktivnosti", "SifraPredmeta");

                    b.HasIndex("SifraPredmeta");

                    b.ToTable("Aktivnosti");
                });

            modelBuilder.Entity("NNProjekat.Models.Nastavnik", b =>
                {
                    b.Property<string>("JMBG")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ime");

                    b.Property<string>("Pozicija");

                    b.Property<string>("Prezime");

                    b.HasKey("JMBG");

                    b.ToTable("Nastavnici");
                });

            modelBuilder.Entity("NNProjekat.Models.Ocena", b =>
                {
                    b.Property<string>("BrojIndeksa");

                    b.Property<string>("SifraPredmeta");

                    b.Property<DateTime>("DatumZakljucivanja");

                    b.Property<int>("PredlozenaOcena");

                    b.Property<int>("ZakljucenaOcena");

                    b.HasKey("BrojIndeksa", "SifraPredmeta", "DatumZakljucivanja");

                    b.HasIndex("SifraPredmeta");

                    b.ToTable("Ocene");
                });

            modelBuilder.Entity("NNProjekat.Models.Polagao", b =>
                {
                    b.Property<string>("BrojIndeksa");

                    b.Property<string>("JMBG");

                    b.Property<DateTime>("Datum");

                    b.Property<string>("SifraAktivnosti");

                    b.Property<string>("SifraPredmeta");

                    b.Property<double>("BrojPoena");

                    b.Property<bool>("Status");

                    b.HasKey("BrojIndeksa", "JMBG", "Datum", "SifraAktivnosti", "SifraPredmeta");

                    b.HasIndex("JMBG");

                    b.HasIndex("SifraAktivnosti", "SifraPredmeta");

                    b.ToTable("Polaganja");
                });

            modelBuilder.Entity("NNProjekat.Models.Predmet", b =>
                {
                    b.Property<string>("SifraPredmeta")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrojESPB");

                    b.Property<string>("Naziv");

                    b.HasKey("SifraPredmeta");

                    b.ToTable("Predmeti");
                });

            modelBuilder.Entity("NNProjekat.Models.Slusa", b =>
                {
                    b.Property<string>("SifraPredmeta");

                    b.Property<string>("BrojIndeksa");

                    b.Property<DateTime>("DatumPrvogUpisa");

                    b.HasKey("SifraPredmeta", "BrojIndeksa");

                    b.ToTable("Slusanja");
                });

            modelBuilder.Entity("NNProjekat.Models.Student", b =>
                {
                    b.Property<string>("BrojIndeksa")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ime");

                    b.Property<string>("Prezime");

                    b.HasKey("BrojIndeksa");

                    b.ToTable("Studenti");
                });

            modelBuilder.Entity("NNProjekat.Models.Aktivnost", b =>
                {
                    b.HasOne("NNProjekat.Models.Predmet", "Predmet")
                        .WithMany("Aktivnosti")
                        .HasForeignKey("SifraPredmeta")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NNProjekat.Models.Ocena", b =>
                {
                    b.HasOne("NNProjekat.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("BrojIndeksa")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NNProjekat.Models.Predmet", "Predmet")
                        .WithMany()
                        .HasForeignKey("SifraPredmeta")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NNProjekat.Models.Polagao", b =>
                {
                    b.HasOne("NNProjekat.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("BrojIndeksa")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NNProjekat.Models.Nastavnik", "Nastavnik")
                        .WithMany()
                        .HasForeignKey("JMBG")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NNProjekat.Models.Aktivnost", "Aktivnost")
                        .WithMany()
                        .HasForeignKey("SifraAktivnosti", "SifraPredmeta")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}