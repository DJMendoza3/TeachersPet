using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeachersPet.Context;
using TeachersPet.Entities;
using TeachersPet.Models;

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
    public async Task<ActionResult> Login(CredentialsDto credentials)
    {
        if (await _context.Users.AnyAsync(u => u.UserName == credentials.Username) == false)
            {
                return BadRequest(Json("User not found"));
            }
        try
        {
            
            User user = await _context.Users.FirstAsync(u => u.UserName == credentials.Username);

            if (user.Password == credentials.Password)
            {
                //eventually this should return a token that can be used to authenticate the user
                return Ok("User logged in");
            }

            return BadRequest(Json("Incorrect Password"));
        } 
        catch
        {
             return BadRequest(Json("Error logging in"));
        }


    }

    [HttpPost("register")]
    public async Task<ActionResult> Register(User user)
    {
        if (await _context.Users.AnyAsync(u => u.Name == user.Name))
        {
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