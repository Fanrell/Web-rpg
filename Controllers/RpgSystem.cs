using System.Net;
using Microsoft.AspNetCore.Mvc;
using RPG.Context;
using RPG.Context.Repositories.Interface;
using RPG.Contracts;
using RPG.Models.Enums;

namespace RPG.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RpgSystem : Controller
{
    private readonly RpgDbContext _dbContext;
    private readonly IRpgSystemRepository _rpgSystemRepository;
    public RpgSystem(RpgDbContext dbContext, IRpgSystemRepository rpgSystemRepository)
    {
        _dbContext = dbContext;
        _rpgSystemRepository = rpgSystemRepository;
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
        var rpgSystems = _rpgSystemRepository.GetAll();
        return Ok(rpgSystems);
    }

    [HttpPost]
    public IActionResult CreateRpgSystem([FromBody] RpgSystemContract rpgSystem)
    {
        try
        {
            _dbContext.RpgSystems.Add(new Models.RpgSystem()
            {
                DiceSystem = (BaseDiceSystem) Enum.Parse(typeof(BaseDiceSystem), rpgSystem.DiceSystem),
                Name = rpgSystem.Name,
                AddedDate = DateTime.Now,
                ModifiedDate = rpgSystem.Modified ?? DateTime.Now
            });
        }
        catch (Exception e)
        {
            return BadRequest();
        }

        _dbContext.SaveChanges();
        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteRpgSystem([FromQuery] Guid id)
    {
        _rpgSystemRepository.Delete(id);
        return Ok();
    }
    
}