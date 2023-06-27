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
using AutoMapper;

namespace TeachersPet.Controllers;

[ApiController]
[Route("api")]

public class AuthController : Controller
{

    // private readonly ILogger<AuthController> _logger;
    // private readonly SiteContext _context;
    // private readonly IUserRepository _userRepository;
    // private readonly IConfiguration _configuration;
    // private readonly JwtTokenCreator _jwtTokenCreator;
    // private readonly IMapper _mapper;

    // public AuthController(ILogger<AuthController> logger, SiteContext context, IUserRepository userRepository, IConfiguration configuration, JwtTokenCreator jwtTokenCreator, IMapper mapper)
    // {
    //     _logger = logger;
    //     _context = context;
    //     _userRepository = userRepository;
    //     _jwtTokenCreator = jwtTokenCreator;
    //     _mapper = mapper;
    //     _configuration = configuration ?? 
    //             throw new ArgumentNullException(nameof(configuration));
    // }

    // [HttpPost("login")]
    // public async Task<ActionResult<string>> Login(CredentialsDto credentials)
    // {
    //     if(!await _userRepository.UserExists(credentials.Username, UserTypes.Teacher))
    //     {
    //         return BadRequest(Json("Teacher does not exist"));
    //     }

    //     var user = await _userRepository.GetUser(credentials.Username, UserTypes.Teacher);
        
    //     try
    //     {
    //         if (BC.Verify(credentials.Password, user.Password))
    //         {
    //            // Step 2: create a token
    //         var token = _jwtTokenCreator.Generate(user.Name, user.Id);

    //         Response.Cookies.Append("TeachersPetCookie", token, new CookieOptions
    //         {
    //             HttpOnly = true,
    //             SameSite = SameSiteMode.Strict
    //         });
    //         return Ok(Json("Logged in"));
    //         }

    //         return BadRequest(Json("Incorrect Password"));
    //     } 
    //     catch
    //     {
    //          return BadRequest(Json("Error logging in"));
    //     }


    // }

    // [HttpPost("register")]
    // public async Task<ActionResult> Register(RegisterDto userData)
    // {
    //     if (await _context.Teachers.AnyAsync(u => u.Name == userData.Name))
    //     {
    //         return BadRequest(Json("A user with name " + userData.Name + " already exists"));
    //     }
    //     try
    //     {
    //         var user = _mapper.Map<Teacher>(userData);
    //         user.Password = BC.HashPassword(user.Password);
    //         user.Tests = new List<Test>();
    //         _context.Teachers.Add(user);
    //         await _context.SaveChangesAsync();
    //         return Ok(Json("Teacher created"));
    //     }
    //     catch (Exception ex)
    //     {
    //         _logger.LogError(ex, "Error creating user");
    //         throw;
    //         return BadRequest(Json("Error creating user"));

    //     }
    // }

    // [HttpGet("refresh")]
    
    // public JsonResult Refresh()
    // {
    //     return Json(new Teacher { Name = "John Doe" });
    // }
    // [HttpGet("logout")]
    // public JsonResult Logout()
    // {
    //     return Json(new Teacher { Name = "John Doe" });
    // }

}