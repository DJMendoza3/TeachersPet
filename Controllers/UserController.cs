using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TeachersPet.Context;
using TeachersPet.Entities;
using TeachersPet.Models;
using BC = BCrypt.Net.BCrypt;

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

            if (BC.Verify(credentials.Password, user.Password))
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>();
                claims.Add(new Claim("name", user.UserName));
                claims.Add(new Claim("role", "user"));
                
                var token = new JwtSecurityToken(
                    issuer: "https://localhost:5295",
                    audience: "https://localhost:5173",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

                var result = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(result);
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
            user.Password = BC.HashPassword(user.Password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(Json("User created"));
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