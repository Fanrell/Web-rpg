using Microsoft.EntityFrameworkCore;
using RPG.Models;

namespace RPG.Context;

public class RpgDbContext : DbContext
{
    public RpgDbContext(DbContextOptions<RpgDbContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }
    public DbSet<RpgSystem> RpgSystems { get; set; }
    public DbSet<CharacterSheet> CharacterSheets { get; set; }

    
}