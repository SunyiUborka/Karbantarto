using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using WinForm.models;

namespace WinForm;

public class KarbantartoDbContext : DbContext
{
    public KarbantartoDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Szerelo> Szereloks { get; set; }
    public DbSet<Megrendelo> Megrendeloks { get; set; }
    public DbSet<Szakterulet> Szakteruleteks { get; set; }
    public DbSet<Karbantartas> Karbantartasoks { get; set; }
}