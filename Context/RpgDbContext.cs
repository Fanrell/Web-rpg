using Microsoft.EntityFrameworkCore;
namespace RPG.Context;

public class RpgDbContext : DbContext
{
    public RpgDbContext(DbContextOptions<RpgDbContext> options) : base(options)
    {
        
    }
}