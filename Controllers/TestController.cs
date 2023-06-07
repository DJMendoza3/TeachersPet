using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TeachersPet.Context;
using TeachersPet.Services;
using TeachersPet.Models;
using TeachersPet.Entities;
using TeachersPet.Profiles;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace TeachersPet.Controllers
{
    [ApiController]
    [Route("api")]
    [Authorize]
    public class TestController : Controller
    {
        private readonly SiteContext _context;
        private readonly ITestRepository _testRepository;
        private readonly IUserRepository _userRepository;


        private IMapper Mapper {
            get;
        }

        public TestController(SiteContext context, ITestRepository testRepository, IMapper mapper, IUserRepository userRepository)
        {
            _context = context;
            _testRepository = testRepository;
            this.Mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet("mytests")]
        public async Task<ActionResult> GetTests()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized();
            }
            var tests = await _testRepository.GetTests(int.Parse(userId));
            var testDtos = Mapper.Map<TestDto[]>(tests);
            return Ok(Json(testDtos));
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
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized();
            }

            var test = Mapper.Map<Test>(testDto);
            await _testRepository.CreateTest(test, int.Parse(userId));
            return Ok(Json("Test added successfully"));
        }

        [HttpPut("test/{id}")]
        public async Task<ActionResult> UpdateTest(TestDto testDto)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized();
            }
            if(!await _testRepository.TestExists(testDto.Id))
            {
                return NotFound();
            }
            if (!await _userRepository.UserExists(userId))
            {
                return Unauthorized();
            }
            if (!await _userRepository.UserOwnsTest(int.Parse(userId), testDto.Id))
            {
                return Unauthorized();
            }
            
            var test = Mapper.Map<Test>(testDto);

            await _testRepository.UpdateTest(test);
            return Ok(Json("Test updated successfully"));
        }
    }
}