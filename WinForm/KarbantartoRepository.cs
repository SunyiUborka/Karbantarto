using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinForm.models;
using System.IO;

namespace WinForm
{
    class KarbantartoRepository
    {
        private readonly KarbantartoDbContext _context;
        
        public KarbantartoRepository(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<KarbantartoDbContext>();
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
            optionsBuilder.UseMySql(connectionString, serverVersion);
            _context = new KarbantartoDbContext(optionsBuilder.Options);
            _context.Database.EnsureCreated();
        }
        private Szerelok GetByNevSzerelo(string Name)
        {
            return _context.szerelok.FirstOrDefault(x => x.nev == Name);
        }
        private Megrendelok GetByNevMegrendelo(string Name)
        {
            return _context.megrendelok.FirstOrDefault(x => x.nev == Name);
        }
        public List<string> GetAllSzereloName()
        {
            List<string> Names = new List<string>();
            var s = _context.szerelok.Select(x => x.nev).Distinct().ToList();
            foreach (var item in s)
            {
                Names.Add(item);
            }
            return Names;
        }
        public List<string> GetAllMegrendeloName()
        {
            List<string> Names = new List<string>();
            var s = _context.megrendelok.Select(x => x.nev).Distinct().ToList();
            foreach (var item in s)
            {
                Names.Add(item);
            }
            return Names;
        }
        public List<KarbantartasokList> SelectedItem(string szerelo, int cost = 5000)
        {
            var list = GetKarbantartasok();
            var selectedList = list.Where(x => (x.szerNev == szerelo) && (x.ar >= cost)).ToList();
            if (selectedList.Count == 0) System.Windows.Forms.MessageBox.Show("Nincs ilyen szerelő!");
            return selectedList;
        }
        public void SaveFile(string path)
        {
            DateTime date = DateTime.Now;
            if (Directory.Exists(path))
            {
                string fileName = $"{path}karbantartasok_{date.ToString("yyyy-MM-dd")}_{date.ToString("HH-mm")}.csv";
                if (!File.Exists(fileName))
                {
                    StreamWriter sw = new StreamWriter(fileName, true, Encoding.UTF8);
                    foreach (var item in GetKarbantartasok())
                    {
                        sw.WriteLine($"{item.megNev};{item.cim};{item.tipus};{item.telefon};{item.szerNev};{item.date.ToString("yyyy/MM/dd")};{item.ar}");
                    }
                    sw.Close();
                }
                else {
                    System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show("A fájl már létezik! Felül szeretnéd írni?", "Létező fájl!", System.Windows.Forms.MessageBoxButtons.YesNo);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        StreamWriter sw = new StreamWriter(fileName, true, Encoding.UTF8);
                        foreach (var item in GetKarbantartasok())
                        {
                            sw.WriteLine($"{item.megNev};{item.cim};{item.tipus};{item.telefon};{item.szerNev};{item.date.ToString("yyyy/MM/dd")};{item.ar}");
                        }
                        sw.Close();
                    }
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Útvonal nem létezik!");
            }
        }
        private Megrendelok GetByIdMegrendelo(int id)
        {
            return _context.megrendelok.FirstOrDefault(x => x.megrendelo_id == id);
        }
        private string GetByIdSzakterulet(int id)
        {
            return _context.szakteruletek.FirstOrDefault(x => x.szakterulet_id == id).megnevezes;
        }
        private Szerelok GetByIdSzerelo(int id)
        {
            return _context.szerelok.FirstOrDefault(x => x.szerelo_id == id);
        }
        public List<KarbantartasokList> GetKarbantartasok()
        {
            var s = _context.karbantartasok.ToList();
            List<KarbantartasokList> data = new List<KarbantartasokList>();
            foreach(Karbantartasok item in s)
            {
                KarbantartasokList d = new KarbantartasokList();
                d.megNev = GetByIdMegrendelo(item.megrendelo_id).nev;
                d.cim = GetByIdMegrendelo(item.megrendelo_id).cim;
                d.tipus = GetByIdSzakterulet(GetByIdSzerelo(item.szerelo_id).szakterulet_id);
                d.telefon = GetByIdMegrendelo(item.megrendelo_id).telefon;
                d.szerNev = GetByIdSzerelo(item.szerelo_id).nev;
                d.date = item.datum;
                d.ar = (item.javido * GetByIdSzerelo(item.szerelo_id).oradij) - (item.javido * GetByIdSzerelo(item.szerelo_id).oradij) * (GetByIdMegrendelo(item.megrendelo_id).kedvezmeny * 0.01);
                data.Add(d);
            }
            var ordereddata = data.OrderBy(x => x.szerNev).ThenBy(x => x.date).ToList();
            return ordereddata;
        }
        public void AddKarbantartas(string MegNev, string SzerNev, int Time, DateTime Date)
        {
            Karbantartasok karbantartas = new Karbantartasok();
            if (Time >= 1 && Time <= 8 && Date <= DateTime.Now)
            {
                try
                {
                    karbantartas.javido = Time;
                    karbantartas.datum = Date;
                    karbantartas.megrendelo_id = GetByNevMegrendelo(MegNev).megrendelo_id;
                    karbantartas.szerelo_id = GetByNevSzerelo(SzerNev).szerelo_id;
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Hibás adat!");
                }
                _context.karbantartasok.Add(karbantartas);
                _context.SaveChanges();
            }
            else System.Windows.Forms.MessageBox.Show("Hibás adat!");
        }
    }
}