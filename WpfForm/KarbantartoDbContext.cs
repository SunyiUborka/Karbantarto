using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WpfForm.models;

namespace WpfForm
{
    class KarbantartoDbContext : DbContext
    {
        public DbSet<Szerelok> szerelok { get; set; }
        public DbSet<Megrendelok> megrendelok { get; set; }
        public DbSet<Szakteruletek> szakteruletek { get; set; }
        public DbSet<Karbantartasok> karbantartasok { get; set; }
        public KarbantartoDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Karbantartasok>().HasKey(s => s.karbantartas_id);
            modelBuilder.Entity<Szakteruletek>().HasKey(s => s.szakterulet_id);
            modelBuilder.Entity<Szerelok>().HasKey(s => s.szerelo_id);
            modelBuilder.Entity<Megrendelok>().HasKey(s => s.megrendelo_id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
