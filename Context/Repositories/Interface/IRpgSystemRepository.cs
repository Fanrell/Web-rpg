using RPG.Models;

namespace RPG.Context.Repositories.Interface;

public interface IRpgSystemRepository : IRepository<RpgSystem>
{
    RpgSystem Find(string? name, string? diceSystem);
}