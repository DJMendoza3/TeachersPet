using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TeachersPet.Context;
using TeachersPet.Entities;
using TeachersPet.Models;
using TeachersPet.Services;
using TeachersPet.Infrastructure;
using BC = BCrypt.Net.BCrypt;

namespace TeachersPet.Controllers;

[ApiController]
[Route("api")]

public class AuthController : Controller
{

    private readonly ILogger<AuthController> _logger;
    private readonly SiteContext _context;
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;
    private readonly JwtTokenCreator _jwtTokenCreator;

    public AuthController(ILogger<AuthController> logger, SiteContext context, IUserRepository userRepository, IConfiguration configuration, JwtTokenCreator jwtTokenCreator)
    {
        _logger = logger;
        _context = context;
        _userRepository = userRepository;
        _jwtTokenCreator = jwtTokenCreator;
        _configuration = configuration ?? 
                throw new ArgumentNullException(nameof(configuration));
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(CredentialsDto credentials)
    {
        if(!await _userRepository.UserExists(credentials.Username))
        {
            return BadRequest(Json("User does not exist"));
        }

        var user = await _userRepository.GetUser(credentials.Username);
        
        try
        {
            if (BC.Verify(credentials.Password, user.Password))
            {
               // Step 2: create a token
            var token = _jwtTokenCreator.Generate(user.Name, user.Id);

            Response.Cookies.Append("TeachersPetCookie", token, new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.Strict
            });
            return Ok(Json("Logged in"));
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