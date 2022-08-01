using Microsoft.EntityFrameworkCore;
using RPG.Models;

namespace RPG.Context;

public class RpgDbContext : DbContext
{
    public RpgDbContext(DbContextOptions<RpgDbContext> options) : base(options)
    {
        
    }

    private DbSet<User> Users { get; set; }
}