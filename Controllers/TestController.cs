using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TeachersPet.Context;
using TeachersPet.Services;
using TeachersPet.Models;
using TeachersPet.Entities;
using TeachersPet.Profiles;
using Microsoft.AspNetCore.Authorization;

namespace TeachersPet.Controllers
{
    [ApiController]
    [Route("api")]
    [Authorize]
    public class TestController : Controller
    {
        private readonly SiteContext _context;
        private readonly ITestRepository _testRepository;

        private IMapper Mapper {
            get;
        }

        public TestController(SiteContext context, ITestRepository testRepository, IMapper mapper)
        {
            _context = context;
            _testRepository = testRepository;
            this.Mapper = mapper;
        }

        [HttpGet("mytests")]
        public async Task<ActionResult> GetTests()
        {
            return Ok(Json("Test"));
        }

        [HttpGet("test/{id}")]
        public async Task<ActionResult<TestDto>> GetTest(
            int id
        )
        {
            if (id < 1)
            {
                return BadRequest();
            }
            if(!await _testRepository.TestExists(id))
            {
                return NotFound();
            }
            var test = Mapper.Map<TestDto>(await _testRepository.GetTest(id));

            return Ok(Json(test));
        }

        [HttpPost("test")]
        public async Task<ActionResult> CreateTest(TestDto testDto)
        {
            var test = Mapper.Map<Test>(testDto);
            await _testRepository.CreateTest(test);
            return Ok(Json("Test added successfully"));
        }
    }
}