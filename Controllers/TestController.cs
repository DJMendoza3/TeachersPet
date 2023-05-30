using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TeachersPet.Context;

namespace TeachersPet.Controllers
{
    [ApiController]
    [Route("api")]
    public class TestController : Controller
    {
        private readonly SiteContext _context;

        public TestController(SiteContext context)
        {
            _context = context;
        }

        [HttpGet("mytests")]
        public async Task<ActionResult> GetTests()
        {
            return Ok(Json("Test"));
        }

        [HttpGet("test/{id}")]
        public async Task<ActionResult> GetTest(
            int id
        )
        {
            return Ok(Json("Test"));
        }

        [HttpPost("test")]
        public async Task<ActionResult> CreateTest()
        {
            return Ok(Json("Test"));
        }
    }
}