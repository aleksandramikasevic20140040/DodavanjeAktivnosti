﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NNProjekat.Data;
using NNProjekat.Models;

namespace NNProjekat.Services
{
    public class SqlSlusanjaData : ISlusanjaData
    {
        private NNProjekatDbContext _context;

        public SqlSlusanjaData(NNProjekatDbContext context)
        {
            _context = context;
        }
        public void IzracunajOcenu(string JMBG, string sifraPredmeta, IEnumerable<Aktivnost> aktivnostiStudenta)
        {
            Slusa slusanja = _context.Slusanja.Include(s => s.Predmet).Include(s => s.Predmet.TipoviAktivnosti).Include(s => s.Student).Where(s => s.Predmet.SifraPredmeta == sifraPredmeta).Where(s => s.Student.JMBG == JMBG).FirstOrDefault();
            Console.WriteLine(slusanja.Predmet.Naziv + "              SLUSANJA");
            int konacnaOcena = 0;
           /* if (slusanja.Predmet.Naziv == "Programiranje 1")
            {
                konacnaOcena = ocenaProgramiranje1(slusanja, aktivnostiStudenta.ToList());
                Console.WriteLine("KonacnaOcena " + konacnaOcena);
            }*/
            //else
            //{
                konacnaOcena = ocenaUpravljanjeDokumentacijom(slusanja, aktivnostiStudenta.ToList());
            //}
            slusanja.PredlozenaOcena = konacnaOcena;
            _context.Slusanja.Update(slusanja);
            _context.SaveChanges();
        }

        public int ocenaUpravljanjeDokumentacijom(Slusa slusanja, List<Aktivnost> aktivnostiStudenta)
        {
            int konacnaOcena = 0;
            double poeni = 0;
            bool nijePao = true;
            foreach (TipAktivnosti tipAktivnosti in slusanja.Predmet.TipoviAktivnosti)
            {
                bool nijePronadjen = true;
                foreach (Aktivnost aktivnost in aktivnostiStudenta)
                {
                    if (aktivnost.SifraTipaAktivnosti == tipAktivnosti.SifraTipaAktivnosti  && aktivnost.Validna == true)
                    {
                        nijePronadjen = false;
                        if (tipAktivnosti.Obavezna == true && aktivnost.Status == false)
                        {
                            return 5;
                        }
                        if (aktivnost.Status == true)
                        {
                            poeni = poeni + aktivnost.BrojPoena * tipAktivnosti.TezinskiKoeficijent;
                        }
                    }
                }
                if (nijePronadjen == true && tipAktivnosti.Obavezna == true)
                {
                    nijePao = false;
                }
            }
            if (nijePao == false) {
                return 0;
            }
            if (poeni <= 50)
            {
                konacnaOcena = 5;
            }
            if (poeni > 50 && poeni <= 60)
            {
                konacnaOcena = 6;
            }
            if (poeni > 60 && poeni <= 70)
            {
                konacnaOcena = 7;
            }
            if (poeni > 70 && poeni <= 80)
            {
                konacnaOcena = 8;
            }
            if (poeni > 80 && poeni <= 90)
            {
                konacnaOcena = 9;
            }
            if (poeni >= 91)
            {
                konacnaOcena = 10;
            }
            return konacnaOcena;
        }

        public int ocenaProgramiranje1(Slusa slusanja, List<Aktivnost> aktivnostiStudenta)
        {
            int konacnaOcena = 0;
            int ocena1 = 0;
            double poeni1 = 0;
            int ocena2 = 0;
            double poeni2 = 0;
            bool nijePao = true;

            foreach (TipAktivnosti tipAktivnosti in slusanja.Predmet.TipoviAktivnosti)
            {
                bool nijePronadjen = true;

                foreach (Aktivnost aktivnost in aktivnostiStudenta)
                {
                    Console.WriteLine("STATUS " + aktivnost.Status);
                    Console.WriteLine("STATUS " + aktivnost.Status);

                    if (aktivnost.SifraTipaAktivnosti == tipAktivnosti.SifraTipaAktivnosti)
                    {
                        nijePronadjen = false;

                        if (aktivnost.Validna == true)
                        {
                            if (tipAktivnosti.Obavezna == true && aktivnost.Status == false)
                            {
                                return 5;
                            }
                        }

                        if (aktivnost.Status == true && aktivnost.Validna == true)
                        {
                            Console.WriteLine(tipAktivnosti.Naziv + " tipaAktivnosti: " + aktivnost.BrojPoena);

                            if (tipAktivnosti.Naziv == "Kolokvijum 1")
                            {
                                poeni1 = poeni1 + aktivnost.BrojPoena;
                            }
                            if (tipAktivnosti.Naziv == "Kolokvijum 2")
                            {
                                poeni1 = poeni1 + aktivnost.BrojPoena;
                            }
                            if (tipAktivnosti.Naziv == "Pisani deo ispita")
                            {
                                poeni1 = poeni1 + aktivnost.BrojPoena;
                            }
                            if (tipAktivnosti.Naziv == "Seminarski rad")
                            {
                                poeni2 = poeni2 + aktivnost.BrojPoena;
                            }
                            if (tipAktivnosti.Naziv == "Usmeni deo ispita")
                            {
                                poeni2 = poeni2 + aktivnost.BrojPoena;
                            }
                        }
                    }
                }
                if (nijePronadjen == true && tipAktivnosti.Obavezna == true)
                {
                    nijePao = false;
                }
            }
            if (nijePao == false)
            {
                return 0;
            }
            if (poeni1 <= 50)
            {
                ocena1 = 5;
            }
            if (poeni1 > 50 && poeni1 <= 60)
            {
                ocena1 = 6;
            }
            if (poeni1 > 60 && poeni1 <= 70)
            {
                ocena1 = 7;
            }
            if (poeni1 > 70 && poeni1 <= 80)
            {
                ocena1 = 8;
            }
            if (poeni1 > 80 && poeni1 <= 90)
            {
                ocena1 = 9;
            }
            if (poeni1 >= 91)
            {
                ocena1 = 10;
            }
            if (poeni2 <= 50)
            {
                ocena2 = 5;
            }
            if (poeni2 > 50 && poeni2 <= 60)
            {
                ocena2 = 6;
            }
            if (poeni2 > 60 && poeni2 <= 70)
            {
                ocena2 = 7;
            }
            if (poeni2 > 70 && poeni2 <= 80)
            {
                ocena2 = 8;
            }
            if (poeni2 > 80 && poeni2 <= 90)
            {
                ocena2 = 9;
            }
            if (poeni2 >= 91)
            {
                ocena2 = 10;
            }
            konacnaOcena = (ocena1 + ocena2) / 2;
            Console.WriteLine(konacnaOcena + " ocenaaaaa");
            return konacnaOcena;
        }

        public IEnumerable<Slusa> UcitajSve()
        {
            return _context.Slusanja;
        }

        public IEnumerable<Slusa> UcitajSve(string JMBG)
        {
            return _context.Slusanja.Include(s => s.Predmet).Where(r => r.JMBG == JMBG);
        }

        public Slusa Vrati(string JMBG, string sifraPredmeta)
        {
            return _context.Slusanja.Include(s => s.Predmet).Include(s => s.Student).Include(s => s.Predmet.TipoviAktivnosti).Where(r => r.JMBG == JMBG && r.SifraPredmeta == sifraPredmeta).FirstOrDefault();
        }

        public void ZakljuciOcenu(string JMBG, string sifraPredmeta)
        {
            Slusa slusanja = _context.Slusanja.Include(s => s.Predmet).Include(s => s.Predmet.TipoviAktivnosti).Include(s => s.Student).Where(s => s.Predmet.SifraPredmeta == sifraPredmeta).Where(s => s.Student.JMBG == JMBG).FirstOrDefault();
            slusanja.ZakljucenaOcena = slusanja.PredlozenaOcena;
            slusanja.DatumZakljucivanja = DateTime.Now;
            _context.Slusanja.Update(slusanja);
            _context.SaveChanges();
        }

        public IEnumerable<Slusa> UcitajSveStudente(string sifraPredmeta)
        {
            return _context.Slusanja.Include(s => s.Student).Where(r => r.SifraPredmeta == sifraPredmeta);
        }

        public void Sacuvaj(Slusa slusa)
        {
            _context.Add(slusa);
            _context.SaveChanges();
        }

        public void Izbrisi(Slusa slusa)
        {
            string sifraPredmeta = slusa.SifraPredmeta;
            string JMBG = slusa.JMBG;
            List<Aktivnost> aktivnosti = _context.Aktivnosti.Where(a => a.SifraPredmeta == sifraPredmeta && a.StudentJMBG == JMBG).ToList();
            foreach (Aktivnost aktivnost in aktivnosti) {
                _context.Aktivnosti.Remove(aktivnost);
            }
            _context.Remove(slusa);
            _context.SaveChanges();
        }

        public void ZakljuciOcenuPromena(string JMBG, string sifraPredmeta, string ocena)
        {
            Slusa slusanja = _context.Slusanja.Include(s => s.Predmet).Include(s => s.Predmet.TipoviAktivnosti).Include(s => s.Student).Where(s => s.Predmet.SifraPredmeta == sifraPredmeta).Where(s => s.Student.JMBG == JMBG).FirstOrDefault();
            if (ocena == null)
            {
                slusanja.ZakljucenaOcena = null;
                slusanja.DatumZakljucivanja = null;
            }
            else
            {
                slusanja.ZakljucenaOcena = Convert.ToInt32(ocena);
                slusanja.DatumZakljucivanja = DateTime.Now;

            }
            _context.Slusanja.Update(slusanja);
            _context.SaveChanges();
        }

        public IEnumerable<Slusa> UcitajSveStudenteIzmedjuDatuma(string id, string datumOd, string datumDo)
        {
            Console.WriteLine("Uslo u service");
            Console.WriteLine(datumOd + " datumOd");
            Console.WriteLine(datumDo + " datumDo");
            DateTime datumOdDate = DateTime.ParseExact(datumOd, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            DateTime datumDoDate = DateTime.ParseExact(datumDo, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            IEnumerable<Slusa> slusanja = _context.Slusanja.Include(s => s.Student).Where(r => r.SifraPredmeta == id && r.DatumZakljucivanja != null
           && DateTime.Compare(datumOdDate, (r.DatumZakljucivanja ?? DateTime.Now)) <= 0 &&
            DateTime.Compare(datumDoDate, (r.DatumZakljucivanja ?? DateTime.Now)) >= 0);

            return slusanja;
        }
    }
}
