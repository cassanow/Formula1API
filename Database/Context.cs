using Microsoft.EntityFrameworkCore;

namespace Formula1API.Model;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
        
    }
    public DbSet<Piloto> Pilotos { get; set; }
    
    public DbSet<Equipe> Equipes { get; set; }
}