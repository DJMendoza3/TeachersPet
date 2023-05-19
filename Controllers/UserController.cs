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
        return Json(new User { Name = "John Doe" });
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register(User user)
    {
        Console.WriteLine(user.Name);
        HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
        if(await _context.Users.AnyAsync(u => u.Name == user.Name)) {
            return BadRequest(Json("A user with name " + user.Name + " already exists"));
        }
        try
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok("User created");
        } 
        catch 
        {
            return BadRequest(Json("Error creating user"));
        }
    }

    [HttpGet("refresh")]
    public JsonResult Refresh()
    {
        return Json(new User { Name = "John Doe" });
    }
    [HttpGet("logout")]
    public JsonResult Logout()
    {
        return Json(new User { Name = "John Doe" });
    }

}