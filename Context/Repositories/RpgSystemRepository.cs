using RPG.Context.Repositories.Interface;
using RPG.Models;

namespace RPG.Context.Repositories;

public class RpgSystemRepository : Repository<RpgSystem>, IRpgSystemRepository
{
    public RpgSystemRepository(RpgDbContext dbContext) : base(dbContext)
    {
    }

    public RpgSystem Find(string? name, string? diceSystem)
    {
        throw new NotImplementedException();
    }
}