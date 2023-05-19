using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeachersPet.Context;
using TeachersPet.Entities;

namespace TeachersPet.Controllers;

[ApiController]
[Route("api")]

public class UserController : Controller
{

    private readonly ILogger<UserController> _logger;
    private readonly SiteContext _context;

    public UserController(ILogger<UserController> logger, SiteContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpPost("login")]
    public JsonResult Login()
    {
        return Json(new User { Id = 1, Name = "John Doe", Email = "test email" });
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register()
    {
        User user = new User { Name = "John", Email = "Email@test.com" };
        if(await _context.Users.AnyAsync(u => u.Name == user.Name)) {
            return BadRequest("A user with name " + user.Name + " already exists");
        }
        try
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok("User created");
        } 
        catch 
        {
            return BadRequest("Error creating user");
        }
    }

    [HttpGet("refresh")]
    public JsonResult Refresh()
    {
        return Json(new User { Id = 1, Name = "John Doe", Email = "test email" });
    }
    [HttpGet("logout")]
    public JsonResult Logout()
    {
        return Json(new User { Id = 1, Name = "John Doe", Email = "test email" });
    }

}