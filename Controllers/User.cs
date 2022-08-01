using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using RPG.Context;

namespace RPG.Controllers;

[Route("api/[controller]")]
[ApiController]
public class User : Controller
{
    private readonly RpgDbContext _dbContext;
    public User(RpgDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public ActionResult GetUser([FromQuery] string id)
    {
        var user = _dbContext.Find<User>(id);
        if (user is null)
            return NotFound();
        return Ok(user);
    }
}