using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Formula1API.Model;

public class Context : IdentityDbContext<Usuario>
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
        
    }
    public DbSet<Piloto> Pilotos { get; set; }
    
    public DbSet<Equipe> Equipes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        List<IdentityRole> roles = new List<IdentityRole>()
        {
            new IdentityRole
            {
                Id = "Admin",
                Name = "Admin",
                NormalizedName = "ADMIN",
            },

            new IdentityRole
            {
                Id = "User",
                Name = "User",
                NormalizedName = "USER",
            }
        };
        
       builder.Entity<IdentityRole>().HasData(roles);

    }
}