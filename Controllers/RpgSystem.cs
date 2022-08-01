using Microsoft.AspNetCore.Mvc;
using RPG.Context;
using RPG.Models.Enums;

namespace RPG.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RpgSystem : Controller
{
    private readonly RpgDbContext _dbContext;
    public RpgSystem(RpgDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // [HttpGet]
    // public IActionResult GetRpgSystemBy([FromQuery] string? name, [FromQuery] string? diceSystem)
    // {
    //     var rpgSystem = _dbContext.RpgSystems.Where(system =>
    //         system.Name == name || system.DiceSystem == (BaseDiceSystem)Enum.Parse(typeof(BaseDiceSystem), diceSystem))
    //         .ToList();
    //     return Ok(rpgSystem);
    // }

    [HttpGet]
    public IActionResult GetAllRpgSystem()
    {
        var rpgSystems = _dbContext.RpgSystems.ToList();
        return Ok(rpgSystems);
    }

    [HttpPost]
    public IActionResult CreateRpgSystem([FromBody] Contracts.RpgSystem rpgSystem)
    {
        _dbContext.RpgSystems.Add(new Models.RpgSystem()
        {
            DiceSystem = (BaseDiceSystem) Enum.Parse(typeof(BaseDiceSystem), rpgSystem.DiceSystem),
            Name = rpgSystem.Name
        });
        _dbContext.SaveChanges();
        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteRpgSystem([FromBody] string name)
    {
        var toDelete = _dbContext.RpgSystems.Where(system => system.Name == name).FirstOrDefault();
        _dbContext.Remove(toDelete);
        _dbContext.SaveChanges();

        return Ok();
    }
    
}