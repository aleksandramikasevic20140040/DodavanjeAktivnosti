﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using NNProjekat.Data;
using System;

namespace NNProjekat.Migrations
{
    [DbContext(typeof(NNProjekatDbContext))]
    [Migration("20181129231814_Seventh")]
    partial class Seventh
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NNProjekat.Models.Aktivnost", b =>
                {
                    b.Property<string>("StudentJMBG");

                    b.Property<string>("NastavnikJMBG");

                    b.Property<DateTime>("Datum");

                    b.Property<string>("SifraTipaAktivnosti");

                    b.Property<string>("SifraPredmeta");

                    b.Property<double>("BrojPoena");

                    b.Property<bool>("Status");

                    b.Property<bool>("Validna");

                    b.HasKey("StudentJMBG", "NastavnikJMBG", "Datum", "SifraTipaAktivnosti", "SifraPredmeta");

                    b.HasIndex("NastavnikJMBG");

                    b.HasIndex("SifraTipaAktivnosti", "SifraPredmeta");

                    b.ToTable("Aktivnosti");
                });

            modelBuilder.Entity("NNProjekat.Models.Osoba", b =>
                {
                    b.Property<string>("JMBG")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ime");

                    b.Property<string>("Prezime");

                    b.Property<string>("tip_osobe")
                        .IsRequired();

                    b.HasKey("JMBG");

                    b.ToTable("Osobe");

                    b.HasDiscriminator<string>("tip_osobe").HasValue("Osoba");
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

                    b.Property<string>("JMBG");

                    b.Property<DateTime>("DatumPrvogUpisa");

                    b.Property<DateTime?>("DatumZakljucivanja");

                    b.Property<int?>("PredlozenaOcena");

                    b.Property<int?>("ZakljucenaOcena");

                    b.HasKey("SifraPredmeta", "JMBG");

                    b.HasIndex("JMBG");

                    b.ToTable("Slusanja");
                });

            modelBuilder.Entity("NNProjekat.Models.TipAktivnosti", b =>
                {
                    b.Property<string>("SifraTipaAktivnosti");

                    b.Property<string>("SifraPredmeta");

                    b.Property<double>("MaxBrojPoena");

                    b.Property<double>("MinBrojPoena");

                    b.Property<string>("Naziv");

                    b.Property<bool>("Obavezna");

                    b.Property<double>("TezinskiKoeficijent");

                    b.HasKey("SifraTipaAktivnosti", "SifraPredmeta");

                    b.HasIndex("SifraPredmeta");

                    b.ToTable("TipoviAktivnosti");
                });

            modelBuilder.Entity("NNProjekat.Models.Nastavnik", b =>
                {
                    b.HasBaseType("NNProjekat.Models.Osoba");

                    b.Property<string>("Pozicija");

                    b.ToTable("Nastavnik");

                    b.HasDiscriminator().HasValue("nastavnik");
                });

            modelBuilder.Entity("NNProjekat.Models.Student", b =>
                {
                    b.HasBaseType("NNProjekat.Models.Osoba");

                    b.Property<string>("BrojIndeksa");

                    b.ToTable("Student");

                    b.HasDiscriminator().HasValue("student");
                });

            modelBuilder.Entity("NNProjekat.Models.Aktivnost", b =>
                {
                    b.HasOne("NNProjekat.Models.Nastavnik", "Nastavnik")
                        .WithMany("Aktivnosti")
                        .HasForeignKey("NastavnikJMBG")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NNProjekat.Models.Student", "Student")
                        .WithMany("Aktivnosti")
                        .HasForeignKey("StudentJMBG")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NNProjekat.Models.TipAktivnosti", "TipAktivnosti")
                        .WithMany()
                        .HasForeignKey("SifraTipaAktivnosti", "SifraPredmeta")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NNProjekat.Models.Slusa", b =>
                {
                    b.HasOne("NNProjekat.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("JMBG")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NNProjekat.Models.Predmet", "Predmet")
                        .WithMany()
                        .HasForeignKey("SifraPredmeta")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NNProjekat.Models.TipAktivnosti", b =>
                {
                    b.HasOne("NNProjekat.Models.Predmet", "Predmet")
                        .WithMany("TipoviAktivnosti")
                        .HasForeignKey("SifraPredmeta")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
