using Microsoft.AspNetCore.Mvc;
using TeachersPet.Models;

namespace TeachersPet.Controllers;

[ApiController]
[Route("users")]

public class UserController : Controller
{

    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public JsonResult Get()
    {
        return Json(new User { Id = 1, Name = "John Doe", Email = "test email" });
    }
}