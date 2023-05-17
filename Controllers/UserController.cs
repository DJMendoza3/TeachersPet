using Microsoft.AspNetCore.Mvc;
using TeachersPet.Models;

namespace TeachersPet.Controllers;

[ApiController]
[Route("users")]

public class UserController: Controller
{
    [HttpGet] 
    public JsonResult Get()
    {
        return Json(new User { Id = 1, Name = "John Doe", Email = "test email" });
    }
}