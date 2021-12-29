using Microsoft.EntityFrameworkCore;
using WinForm.models;

namespace WinForm;

public class KarabantartoRepository
{
    private readonly KarbantartoDbContext _context;

    public KarabantartoRepository(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<KarbantartoDbContext>();
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
        optionsBuilder.UseMySql(connectionString, serverVersion);
        _context = new KarbantartoDbContext(optionsBuilder.Options);
    }
    
    public void AddKarbantartas(Karbantartas karbantartas)
    {
        _context.Karbantartasoks.Add(karbantartas);
    }
    
}