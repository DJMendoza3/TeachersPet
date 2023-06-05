using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TeachersPet.Context;
using TeachersPet.Services;
using TeachersPet.Models;
using TeachersPet.Entities;
using TeachersPet.Profiles;

namespace TeachersPet.Controllers
{
    [ApiController]
    [Route("api")]
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
        public async Task<ActionResult> CreateTest()
        {
            if(await _testRepository.TestExists("Test"))
            {
                return BadRequest();
            }
            var test = new Test
            {
                TestName = "Test",
                Text = "Test",
                Questions = new List<Question>
                {
                    new Question
                    {
                        Text = "Test",
                        Answers = new List<Answer>
                        {
                            new Answer
                            {
                                Text = "Test",
                                IsCorrect = true
                            }
                        }
                    }
                }

            };
            await _testRepository.CreateTest(test);
            return Ok(Json("Test"));
        }
    }
}